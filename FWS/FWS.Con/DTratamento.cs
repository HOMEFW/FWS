using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace FWS.Con
{
    public class dTratamento
    {
        /// <summary>
        /// Configura o SqlParamenter configurado para a inclusão no SqlCommand.
        /// </summary>
        /// <param name="obj">Entidadde.</param>
        /// <param name="item">Informações da propriedade da entidade</param>
        /// <returns>Retorma o SqlParamenter configurado </returns>
        public SqlParameter TrataParamentros(object obj, PropertyInfo item)
        {
            var sqlParam = new SqlParameter();
            var nomeTipo = ((Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType).FullName ?? "");
            try
            {
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
            }
            catch (Exception ex)
            {
                try
                {
                    //using (var error = new uLogErro())
                    //    error.EscreverLog(string.Format("Ocorreu um erro durante o tratamento da propriedade {0} da entidade {1} ", item.Name, item.ReflectedType.Name), ex);
                }
                catch (Exception)
                {
                    throw ex;
                }
            }

            return sqlParam;
        }
    }
}
