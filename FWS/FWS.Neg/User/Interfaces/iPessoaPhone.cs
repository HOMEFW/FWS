using System.Collections.Generic;
using FWS.Ent;
using FWS.Ent.User;

namespace FWS.Neg.User.Interfaces
{
    public interface iPessoaPhone
    {
        /// <summary>
        /// Realiza a inclusão do telefone de uma pessa
        /// </summary>
        /// <param name="item">Dados do telefone da pessoa</param>
        eMensagem Registrar(ePessoaPhone item);
        /// <summary>
        /// Altera as informações do telefone da pessoa
        /// </summary>
        /// <param name="item">Dados do telefone da pessoa</param>
        eMensagem Alterar(ePessoaPhone item);
        /// <summary>
        /// Consulta todos as informações de telefone da pessoa.
        /// </summary>
        /// <param name="pessoa">Identificação da pessoa</param>
        /// <returns>Lista com as informações de telefone informadas pela pessoa.</returns>
        List<ePessoaPhone> Consultar(eLogin pessoa);
        /// <summary>
        /// Exclui a informação do telefone da pessoa
        /// </summary>
        /// <param name="item">Identificação do telefone da pessoa.</param>
        eMensagem Excluir(ePessoaPhone item);
    }
}