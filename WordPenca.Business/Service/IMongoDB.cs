
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
        string AreaCollection { get; set; }
        string BookingCollection { get; set; }
        string CoachCollection { get; set; }
        string CompetitionCollection { get; set; }
        string FilterCollection { get; set; }
        string GoalCollection { get; set; }
        string OddsCollection { get; set; }
        string PenaltyCollection { get; set; }
        string PlayerCollection { get; set; }
        string ResultSetCollection { get; set; }
        string RootMatchsCollection { get; set; }
        string ScoreCollection { get; set; }
        string ScoreTimeCollection { get; set; }
        string SeasonCollection { get; set; }
        string SubstitutionCollection { get; set; }
        string TeamCollection { get; set; }


    }
}
