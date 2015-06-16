using System;
using FWS.Ent;
using FWS.Ent.User;
using FWS.Neg.User.Interfaces;

namespace FWS.Neg.User.Classes
{
    public class nPessoa : iPessoa
    {


        public eLogin Login(eLogin pessoa)
        {
            throw new NotImplementedException();
        }

        public eMensagem Registrar(eLogin pessoa)
        {
            throw new NotImplementedException();
        }

        public eMensagem Alterar(ePessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public ePessoa Consultar(eLogin pessoa)
        {
            throw new NotImplementedException();
        }

        public eMensagem Bloquear(eLogin pessoa)
        {
            throw new NotImplementedException();
        }

        public eMensagem Inativar(eLogin pessoa)
        {
            throw new NotImplementedException();
        }

        public void Desbloquear(eLogin pessoa)
        {
            throw new NotImplementedException();
        }
    }
}