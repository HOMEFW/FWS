using System;
using System.Configuration.Provider;
using System.IO;
using System.Linq;
using FWS.Log.Ent;

namespace FWS.Log.Neg
{
    public class nTextLog : ProviderBase
    {
        internal static eRetorno DoLog(eConfig config, eLog log)
        {
            var retorno = new eRetorno();

            try
            {
                var path = Directory.Exists(config.TextFilePath)
                               ? config.TextFilePath
                               : AppDomain.CurrentDomain.BaseDirectory;

                var searchName = config.TextFileName + DateTime.Now.ToString("yyyyMMdd");
                var fileName = "";
                var count = 0;

                foreach (var file in new DirectoryInfo(path).GetFiles().Where(c => c.Name.Contains(searchName)).OrderBy(
                    o => o.CreationTime))
                {
                    if ((file.Length) / 1024 < config.TextFileMaxByte - 1)
                    {
                        fileName = file.Name;
                        break;
                    }
                    count++;
                }

                if (fileName.Equals(""))
                    fileName = searchName + ((count > 0 ? "(" + (count) + ")" : "")) + ".log";

                var pathFile = Path.Combine(path, fileName);
                var writer = new StreamWriter(pathFile, true);
                writer.WriteLine(string.Format("{0} : Class -> {1} | Method -> {2} | Message -> {3} | Error -> {4}",
                                               DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), log.Classe, log.Metodo,
                                               log.Mensagem, log.Message));

                writer.Close();
                retorno.sucesso = true;
            }
            catch (Exception ex)
            {
                retorno.sucesso = false;
                retorno.mensagem = ex.Message;
            }

            return retorno;
        }
    }
}
