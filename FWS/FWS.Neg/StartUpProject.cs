using System;
using FWS.Dao.Context;
using FWS.Log;

namespace FWS.Neg
{
   public class StartUpProject
    {
       public void Initialize()
       {
           try
           {
               new InitializeDataBase().Initialize();
           }
           catch (Exception ex)
           {
               appLog.LogMe(erro.Warning, ex, null, "Erro ao inicializar o projeto");
           }
       }
    }
}
