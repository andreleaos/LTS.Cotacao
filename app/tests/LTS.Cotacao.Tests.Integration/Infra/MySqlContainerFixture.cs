using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Testcontainers.MySql;

namespace LTS.Cotacao.Tests.Integration.Infra
{
    public sealed class MySqlContainerFixture : IAsyncLifetime
    {
        public string ConnectionString { get; private set; } = string.Empty;
        private MySqlContainer _db = default!;

        public async Task InitializeAsync()
        {
            // 1) Fallback: se você passar IT_MYSQL_CONNECTION no ambiente,
            //    a fixture usa esse banco (compose/local) e não sobe container.
            var fromEnv = Environment.GetEnvironmentVariable("IT_MYSQL_CONNECTION");
            if (!string.IsNullOrWhiteSpace(fromEnv))
            {
                ConnectionString = fromEnv!;
                await WaitForDbAsync(ConnectionString);
                return;
            }

            string dbRoot = "";

            // 2) Sobe container MySQL via Testcontainers
            try
            {
                _db = new MySqlBuilder()
                    .WithImage("mysql:8.0")
                    .WithDatabase("quotesdb")
                    .WithUsername("quotes")
                    .WithPassword("quotespwd")
                    // Opcional: se sua rede/proxy bloqueia o resource reaper (Ryuk), descomente a linha abaixo:
                    // .WithCleanUp(true) // garante limpeza mesmo com reaper desativado globalmente
                    .Build();

                await _db.StartAsync();

                ConnectionString =
                    $"Server={_db.Hostname};Port={_db.GetMappedPublicPort(3306)};" +
                    $"Database=quotesdb;Uid=quotes;Pwd=quotespwd;" +
                    $"AllowPublicKeyRetrieval=True;SslMode=None;";


                // Aguarda o DB aceitar conexões (às vezes StartAsync retorna antes do InnoDB/privileges)
                await WaitForDbAsync(ConnectionString);

                // Resolve caminhos de scripts de modo robusto (procura pasta /db a partir do diretório atual subindo níveis)
                dbRoot = FindFolderUpwards("db") ?? throw new DirectoryNotFoundException("Pasta 'db' não encontrada (procurei por /db).");
                await SqlScriptHelper.RunScriptAsync(ConnectionString, Path.Combine(dbRoot, "init", "01_create_schema.sql"));
                await SqlScriptHelper.RunScriptAsync(ConnectionString, Path.Combine(dbRoot, "init", "02_seed_companies.sql"));
                //await SqlScriptHelper.RunScriptAsync(ConnectionString, Path.Combine(dbRoot, "init", "03_seed_quotes_sept_2025.sql"));

            }
            catch (Exception ex)
            {
                // Diagnóstico amigável (evita NRE “mudo”)
                var hint = BuildDockerHint(ex);
                throw new InvalidOperationException(hint, ex);
            }
        }


        public async Task DisposeAsync()
        {
            if (_db is not null)
                await _db.DisposeAsync();
        }

        private static async Task WaitForDbAsync(string cs, int retries = 30, int delayMs = 500)
        {
            Exception? last = null;
            for (var i = 0; i < retries; i++)
            {
                try
                {
                    await using var conn = new MySqlConnection(cs);
                    await conn.OpenAsync();
                    await using var cmd = new MySqlCommand("SELECT 1;", conn);
                    await cmd.ExecuteScalarAsync();
                    return;
                }
                catch (Exception ex)
                {
                    last = ex;
                    await Task.Delay(delayMs);
                }
            }
            throw new InvalidOperationException("MySQL não ficou pronto a tempo.", last);
        }

        private static string? FindFolderUpwards(string folderName)
        {
            var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            while (dir != null)
            {
                var candidate = Path.Combine(dir.FullName, folderName);
                if (Directory.Exists(candidate)) return candidate;
                dir = dir.Parent;
            }
            return null;
        }

        private static string BuildDockerHint(Exception ex)
        {
            var os = RuntimeInformation.OSDescription;
            return
                $@"Falha ao iniciar o container MySQL de teste.

                Dicas:
                - Verifique se o Docker Desktop/daemon está em execução.
                - Teste: 'docker run --rm hello-world' e 'docker pull mysql:8.0'.
                - Rede corporativa/proxy pode bloquear o download das imagens (inclusive testcontainers/ryuk).
                - Se preferir evitar container, defina IT_MYSQL_CONNECTION apontando para um MySQL acessível, ex.:
                  IT_MYSQL_CONNECTION=""Server=localhost;Port=3307;Database=quotesdb;Uid=quotes;Pwd=quotespwd;AllowPublicKeyRetrieval=True;SslMode=None;""

                SO: {os}
                Exceção interna: {ex.GetType().Name} - {ex.Message}";
        }


    }
}
