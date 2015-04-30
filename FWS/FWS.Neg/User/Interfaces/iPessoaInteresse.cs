using System.Collections.Generic;
using FWS.Ent;
using FWS.Ent.User;

namespace FWS.Neg.User.Interfaces
{
    public interface iPessoaInteresse
    {
        /// <summary>
        /// Cadastra a opção selecionada pela pessoa.
        /// </summary>
        /// <param name="item">Informações do Interesse.</param>
        eMensagem Registrar(ePessoaInteresse item);

        /// <summary>
        /// Consulta os interesses já selecionados pela pessoa anteriormente.
        /// </summary>
        /// <param name="pessoa">Identificação da Pessoa</param>
        /// <returns>Lista com os interesses cadastrados.</returns>
        List<ePessoaInteresse> Consultar(eLogin pessoa);

        /// <summary>
        /// Exclui o interesse cadastrado pela pessoa
        /// </summary>
        /// <param name="item">Informações do Interesse.</param>
        eMensagem Excluir(ePessoaInteresse item);
    }
}

