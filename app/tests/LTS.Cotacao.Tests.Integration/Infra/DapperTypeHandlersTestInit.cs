using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using LTS.Cotacao.Infrastructure.Data.Util;

namespace LTS.Cotacao.Tests.Integration.Infra
{
    // Garante que DateOnly handlers estão ativos nos testes
    public static class DapperTypeHandlersTestInit
    {
        private static bool _initialized;
        public static void Ensure()
        {
            if (_initialized) return;
            SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
            SqlMapper.AddTypeHandler(new NullableDateOnlyTypeHandler());
            _initialized = true;
        }
    }
}
