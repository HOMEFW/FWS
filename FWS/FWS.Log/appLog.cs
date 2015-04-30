using System;
using FWS.Log.Dic;
using FWS.Log.Ent;
using FWS.Log.Neg;

namespace FWS.Log
{
    public enum erro
    {
        Info = 0,
        Degub = 1,
        Warning = 2,
        Critical = 3
    }

    public enum provider
    {
        Sql,
        Text,
        SqlonErrorText,
        All
    }

    public static class appLog
    {
        private static eConfig _config;

        static appLog()
        {
            Initialize();
        }

        private static void Initialize()
        {
            var config = (logSection) System.Configuration.ConfigurationManager.GetSection("logSection");


            if (config == null)
                throw new Exception(Error.SecaoNaoEncontrada);

            if (config.Provider == null)
                throw new Exception(Error.ProviderNaoInformado);

            _config = new eConfig
            {
                ConnectionStringName = config.Connection.Name,
                TextFilePath = config.Text.Path,
                TextFileName = config.Text.Name,
                TextFileMaxByte = config.Text.MaxByte,
                LogType = config.Provider.ProviderName
            };
        }

        public static eRetorno LogMe(erro level, Exception exception = null, Type objType = null, string mensagem = null)
        {
            var log = new eLog
            {
                Level = (int)level,
                Classe = (objType == null) ? null : objType.FullName,
                Mensagem = mensagem
            };

            if (exception == null) return nLog.DoLog(_config, log);

            log.Stack = exception.StackTrace;
            log.Message = exception.Message;
            log.Metodo = exception.TargetSite.Name;

            return nLog.DoLog(_config, log);
        }
    }
}