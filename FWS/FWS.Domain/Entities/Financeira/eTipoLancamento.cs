using System;

namespace FWS.Domain.Entities.Financeira
{
    public class eTipoLancamento
    {
        public int TipoLancamentoId { get; set; }
        public string Descricao { get; set; }
        public string Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public int UsuarioId { get; set; }
        public Int16 GrupoLancamentoId { get; set; }
        //public GrupoLancamento GrupoLancamento { get; set; }
    }
}
