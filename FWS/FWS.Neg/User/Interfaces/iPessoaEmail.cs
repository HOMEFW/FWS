using System.Collections.Generic;
using FWS.Ent;
using FWS.Ent.User;

namespace FWS.Neg.User.Interfaces
{
    public interface iPessoaEmail
    {
        /// <summary>
        /// Cadastra as informações de email.
        /// </summary>
        /// <param name="item">Informações do email</param>
        eMensagem Registrar(ePessoaEmail item);
        /// <summary>
        /// Altera as informações de email.
        /// </summary>
        /// <param name="item">Informações do email</param>
        eMensagem Alterar(ePessoaEmail item);
        /// <summary>
        /// Exclui as informações do email
        /// </summary>
        /// <param name="item">Informações do email</param>
        eMensagem Excluir(ePessoaEmail item);
        /// <summary>
        /// Consulta as informações dos emails cadastrados
        /// </summary>
        /// <param name="pessoa">informações dos emails cadastrados para o usuário.</param>
        /// <returns>Lista dos emails cadastradosdo usuário.</returns>
        List<ePessoaEmail> Consultar(eLogin pessoa);
    }
}

