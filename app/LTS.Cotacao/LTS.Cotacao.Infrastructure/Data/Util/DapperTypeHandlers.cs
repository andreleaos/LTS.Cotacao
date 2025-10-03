using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace LTS.Cotacao.Infrastructure.Data.Util
{
    public sealed class DateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly>
    {
        public override void SetValue(IDbDataParameter parameter, DateOnly value)
        {
            // envia para o MySQL como DateTime no dia especificado (meia-noite)
            parameter.Value = value.ToDateTime(TimeOnly.MinValue);
        }

        public override DateOnly Parse(object value)
        {
            // MySQL devolve DateTime ou string; tratamos os dois
            return value switch
            {
                DateTime dt => DateOnly.FromDateTime(dt),
                string s => DateOnly.FromDateTime(DateTime.Parse(s)),
                _ => throw new DataException($"Não foi possível converter {value?.GetType().Name} para DateOnly")
            };
        }
    }

}
