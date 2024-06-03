namespace WordPenca.Business.Domain
{
    public class MongoDbSettings : IMongoDB
    {
        public string Server { get; set; }
        public string DataBase { get; set; }
        public string ChatCollection { get; set; }
        public string ChatHistorialCollection { get; set; }
        public string ChatMensajeCollection { get; set; }
        public string ChatUsuarioCollection { get; set; }
        public string MatchCollection { get; set; }


    }
}
