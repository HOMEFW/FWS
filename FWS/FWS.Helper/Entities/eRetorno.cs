using System;
using System.Runtime.Serialization;


namespace FWS.Helper.Entities
{
    [Serializable, DataContract]
    public class eRetorno
    {
        [DataMember]
        public bool OperacaoRealizadaComSucesso { get; set; }

        [DataMember]
        public bool OcorreuExcessao { get; set; }

        [DataMember]
        public string MensagemErro { get; set; }

        [DataMember]
        public string MensagemSucesso { get; set; }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int MensagemId { get; set; }

        [DataMember]
        public string Url { get; set; }
    }
}
