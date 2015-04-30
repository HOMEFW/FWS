using System.Collections.Generic;
using FWS.Ent;
using FWS.Ent.User;

namespace FWS.Neg.User.Interfaces
{
    public interface iInteresse
    {
        /// <summary>
        /// Cadastra as informações do interesse.
        /// </summary>
        /// <param name="item">informações do interesse</param>
        eMensagem Registrar(eInteresse item);
        /// <summary>
        /// Altera as informações do interesse
        /// </summary>
        /// <param name="item">informações do interesse</param>
        eMensagem Alterar(eInteresse item);
        /// <summary>
        /// Exclui as informações do interesse somente caso ainda não tenha sido selecionada.
        /// </summary>
        /// <param name="item">informações do interesse</param>
        eMensagem Excluir(eInteresse item);
        /// <summary>
        /// Consulta as informações dos interesses cadastrados
        /// </summary>
        /// <param name="item">informações do interesse utilizados como filtros</param>
        /// <returns>Lista com as informações dos interesses</returns>
        List<eInteresse> Consultar(eInteresse item = null);
    }
}