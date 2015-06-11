using System;

namespace FWS.Domain.Entities.Comum
{
    public class eDominio
    {
        public int DominioId { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Alias { get; set; }
        public string Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public int UsuarioCadastroId { get; set; }
    }
}
