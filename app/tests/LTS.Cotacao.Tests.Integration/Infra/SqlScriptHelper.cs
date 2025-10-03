using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace LTS.Cotacao.Tests.Integration.Infra
{
    public static class SqlScriptHelper
    {
        public static async Task RunScriptAsync(string connectionString, string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Arquivo SQL não encontrado: {filePath}");

            var sql = await File.ReadAllTextAsync(filePath);

            await using var conn = new MySqlConnection(connectionString);
            await conn.OpenAsync();

            foreach (var cmdText in SplitBatches(sql))
            {
                if (string.IsNullOrWhiteSpace(cmdText)) continue;
                await using var cmd = new MySqlCommand(cmdText, conn);
                await cmd.ExecuteNonQueryAsync();
            }
        }


        private static IEnumerable<string> SplitBatches(string sql)
        {
            // split simples por ';' respeitando linhas; suficiente para nossos scripts
            return sql.Split(';')
            .Select(s => s.Trim())
            .Where(s => s.Length > 0)
            .Select(s => s + ";");
        }
    }

}
