using System;
using System.Collections.Generic;
using FWS.Ent;
using FWS.Ent.User;
using FWS.Neg.User.Interfaces;

namespace FWS.Neg.User.Classes
{
    public class nPessoaConvite : iPessoaConvite
    {


        public eMensagem Registrar(ePessoaConvite item)
        {
            throw new NotImplementedException();
        }

        public List<ePessoaConvite> ListaConvite(eLogin pessoa)
        {
            throw new NotImplementedException();
        }

        public eMensagem Acessar(ePessoaConvite item)
        {
            throw new NotImplementedException();
        }

        public List<ePessoaConvite> ListaConviteNaoEnviado(eLogin pessoa = null)
        {
            throw new NotImplementedException();
        }
    }
}

