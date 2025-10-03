using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace LTS.Cotacao.Infrastructure.Data.Util
{
    public sealed class NullableDateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly?>
    {
        public override void SetValue(IDbDataParameter parameter, DateOnly? value)
            => parameter.Value = value?.ToDateTime(TimeOnly.MinValue) ?? (object)DBNull.Value;

        public override DateOnly? Parse(object value)
        {
            if (value is null || value is DBNull) return null;
            return value switch
            {
                DateTime dt => DateOnly.FromDateTime(dt),
                string s => DateOnly.FromDateTime(DateTime.Parse(s)),
                _ => throw new DataException($"Não foi possível converter {value.GetType().Name} para DateOnly?")
            };
        }
    }
}
