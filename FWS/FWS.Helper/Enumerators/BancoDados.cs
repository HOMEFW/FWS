namespace FWS.Helper.Enumerators
{
    public class BancoDados
    {
        public enum TipoBanco
        {
            NaoInformado = 0,
            Oracle = 1,
            Sql = 2
        }

        public enum TipoComando
        {
            NaoInformado = 0,
            Text = 1,
            StoredProcedure = 2,
        }
    }
}
