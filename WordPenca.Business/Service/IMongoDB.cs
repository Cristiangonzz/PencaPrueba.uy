
namespace WordPenca.Business.Domain
{
    public interface IMongoDB
    {
        string Server { get; set; }
        string DataBase { get; set; }
        string ChatCollection { get; set; }
        string ChatHistorialCollection { get; set; }
        string ChatMensajeCollection { get; set; }
        string ChatUsuarioCollection { get; set; }
        string MatchCollection { get; set; }
        string CompetitionCollection { get; set; }
        string RootMatchsCollection { get; set; }
        string TeamCollection { get; set; }


    }
}
