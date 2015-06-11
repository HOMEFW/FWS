using System;

namespace FWS.Domain.Entities.Financeira
{
    public class eGrupoLancamento
    {
        public Int16 GrupoLancamentoId { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public Int16 Tipo { get; set; }
    }
}
