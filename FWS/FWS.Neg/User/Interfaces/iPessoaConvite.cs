using System.Collections.Generic;
using FWS.Ent;
using FWS.Ent.User;

namespace FWS.Neg.User.Interfaces
{
    public interface iPessoaConvite
    {
        /// <summary>
        /// Cadastra as informações do convite.
        /// </summary>
        /// <param name="item">Informações do Convite</param>
        eMensagem Registrar(ePessoaConvite item);
        /// <summary>
        /// Lista os convites cadstrados pela pessoa.
        /// </summary>
        /// <param name="pessoa">informações da pessoa utilizada como filtro</param>
        /// <returns>Lista de convites encaminhado pela pessoa</returns>
        List<ePessoaConvite> ListaConvite(eLogin pessoa);
        /// <summary>
        /// Registra o acesso ao site através do convite
        /// </summary>
        /// <param name="item">Informações convite.</param>
        eMensagem Acessar(ePessoaConvite item);
        /// <summary>
        /// Lista os convites não encaminhados.
        /// </summary>
        /// <param name="pessoa">informações da pessoa utilizada como filtro</param>
        /// <returns>Lista de convites pendentes de envio.</returns>
        List<ePessoaConvite> ListaConviteNaoEnviado(eLogin pessoa = null);

    }
}

