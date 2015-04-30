using System;

namespace FWS.Domain.Financeira.Entities
{
    public class TipoLancamento
    {
        public int TipoLancamentoId { get; set; }

        public string Descricao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime? DataTermino { get; set; }

        public string Situacao { get; set; }

        public Int16 GrupoLancamentoId { get; set; }

        //public GrupoLancamento GrupoLancamento { get; set; }
    }
}
