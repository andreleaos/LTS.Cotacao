# API de Cotação de Ações (Dapper + MySQL)


## Requisitos
- Docker + Docker Compose


## Subir os serviços
```bash
docker compose up -d --build

## 🔍 Teste rápido (após subir o compose)
```bash
# Listar empresas
curl http://localhost:8080/api/companies


# Cotações de setembro/2025 para a primeira empresa (Id=1)
curl "http://localhost:8080/api/quotes?companyId=1&start=2025-09-01&end=2025-09-30"

###

## ✅ Notas de arquitetura (Hexagonal/Clean)
- **Domínio** (Entities + Ports) é agnóstico a tecnologia.
- **Adapters** (Infra): repositórios Dapper implementam **ports**.
- **Driving Adapters**: Controllers chamam **Services** (Application), que orquestram as **ports**.
- **Configuração**: `Startup` realiza **IoC/DI** – mapeia interfaces para implementações.
- **Infra**: `DapperContext` encapsula a conexão; scripts SQL criam e populam o schema.