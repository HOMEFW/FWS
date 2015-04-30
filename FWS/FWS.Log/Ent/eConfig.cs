namespace FWS.Log.Ent
{
    internal class eConfig
    {
        public string ConnectionStringName { get; set; }
        public string TextFilePath { get; set; }
        public string TextFileName { get; set; }
        public int TextFileMaxByte { get; set; }
        public provider LogType { get; set; }
        public string Procedure { get; set; }
    }
}
