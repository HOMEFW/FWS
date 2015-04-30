using FWS.Ent;
using FWS.Ent.User;

namespace FWS.Neg.User.Interfaces
{
    public interface iPessoa
    {
        /// <summary>
        /// Efetua o login no sistema
        /// </summary>
        /// <param name="pessoa">informações da pessoa para a realização do login</param>
        /// <returns>Informações da pessoa logada. </returns>
        eLogin Login(eLogin pessoa);
        /// <summary>
        /// Cadastra as informações inciais para o cadastro da pessoa.
        /// </summary>
        /// <param name="pessoa">informações da pessoa</param>
        eMensagem Registrar(eLogin pessoa);
        /// <summary>
        /// Regsitra as informações complementares ao cadastro da pessoa.
        /// </summary>
        /// <param name="pessoa">informações da pessoa</param>
        eMensagem Alterar(ePessoa pessoa);
        /// <summary>
        /// Consulta as informações da pessoa
        /// </summary>
        /// <param name="pessoa">Informações da pessoa utilizadas para o filtro</param>
        /// <returns>Informações da pessoa</returns>
        ePessoa Consultar(eLogin pessoa);
        /// <summary>
        /// Bloqueia o acesso da pessoa ao site.
        /// </summary>
        /// <returns>Informações da pessoa</returns>
        eMensagem Bloquear(eLogin pessoa);
        /// <summary>
        /// Indica que a conta não deve estar disponivel para visualização.
        /// </summary>
        /// <returns>Informações da pessoa</returns>
        eMensagem Inativar(eLogin pessoa);
        /// <summary>
        /// Desbloqueia o acesso da pessoa ao site.
        /// </summary>
        /// <returns>Informações da pessoa</returns>
        void Desbloquear(eLogin pessoa);
    }
}