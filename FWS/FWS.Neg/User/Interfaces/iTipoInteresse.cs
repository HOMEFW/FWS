using System.Collections.Generic;
using FWS.Ent;
using FWS.Ent.User;

namespace FWS.Neg.User.Interfaces
{
    public interface iTipoInteresse
    {
        /// <summary>
        /// Realiza o cadastro de um Tipo de Interesse
        /// </summary>
        /// <param name="item">Informações sobre o Tipo de Interesse</param>
        /// 
        eMensagem Registrar(eTipoInteresse item);
        /// <summary>
        /// Altera o cadastro do Tipo de Interessse
        /// </summary>
        /// <param name="item">Informações sobre o Tipo de Interesse</param>
        eMensagem Alterar(eTipoInteresse item);
        /// <summary>
        /// Exclui o Tipo de Interesse desde de que não tenha nenhum interesse vinculado.
        /// </summary>
        /// <param name="item">Informações sobre o Tipo de Interesse</param>
        eMensagem Excuir(eTipoInteresse item);
        /// <summary>
        /// Consulta os Tipos de Interesse cadastrados.
        /// </summary>
        /// <param name="item">Dados do Tipo de Interesse a ser utilizado como filtro</param>
        /// <returns>Lista com todos os Tipos de Interesse encontrados de acordo com o fitro.</returns>
        List<eTipoInteresse> Consultar(eTipoInteresse item);
        /// <summary>
        /// Disponibiliza o Tipo de Interesse para a seleção do usuário.
        /// </summary>
        /// <param name="item">Informações sobre o Tipo de Interesse</param>
        eMensagem Habilitar(eTipoInteresse item);
    }
}

