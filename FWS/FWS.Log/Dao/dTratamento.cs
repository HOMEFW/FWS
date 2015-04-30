using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace FWS.Log.Dao
{
    public class tratamentoDados
    {
        /// <summary>
        /// Configura o SqlParamenter configurado para a inclusão no SqlCommand.
        /// </summary>
        /// <param name="obj">Entidadde.</param>
        /// <param name="item">Informações da propriedade da entidade</param>
        /// <returns>Retorma o SqlParamenter configurado </returns>
        public SqlParameter tratarParamentros(object obj, PropertyInfo item)
        {
            var sqlParam = new SqlParameter();
            var nomeTipo = ((Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType).FullName ?? string.Empty);
            sqlParam.ParameterName = "@" + item.Name;

            switch (nomeTipo.ToUpper())
            {
                case "INT":
                case "SYSTEM.INT32":
                    sqlParam.Value = item.GetValue(obj, null);
                    sqlParam.DbType = DbType.Int32;
                    break;

                case "SYSTEM.STRING":
                case "SYSTEM.CHAR":
                case "CHAR":
                    var valor = item.GetValue(obj, null);
                    sqlParam.Value = valor.ToString().Replace("_", "").Length > 0 ? valor : null;
                    sqlParam.DbType = DbType.String;
                    break;

                case "SYSTEM.DATETIME":
                    sqlParam.Value = item.GetValue(obj, null);
                    sqlParam.DbType = DbType.DateTime;
                    break;

                case "SYSTEM.DECIMAL":
                case "DECIMAL":
                    sqlParam.Value = item.GetValue(obj, null);
                    sqlParam.DbType = DbType.Decimal;
                    break;

                case "SYSTEM.DOUBLE":
                case "DOUBLE":
                case "SYSTEM.SINGLE":
                case "FLOAT":
                    sqlParam.Value = item.GetValue(obj, null);
                    sqlParam.DbType = DbType.Double;
                    break;

                default:
                    var valorItem = item.GetValue(obj, null);
                    sqlParam.Value = valorItem.ToString().Replace("_", "").Length > 0 ? valorItem : null;
                    sqlParam.DbType = DbType.String;
                    break;
            }

            return sqlParam;
        }
    }
}
