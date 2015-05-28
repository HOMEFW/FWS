using System;

namespace FWS.Domain.Financeira.Entities
{
    public class GrupoLancamento
    {
        public Int16 GrupoLancamentoId { get; set; }

        public string Descricao { get; set; }

        public string Sigla { get; set; }

        public Int16 Tipo { get; set; }
    }
}
