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
        public string AreaCollection { get; set; }
        public string BookingCollection { get; set; }
        public string CoachCollection { get; set; }
        public string CompetitionCollection { get; set; }
        public string FilterCollection { get; set; }
        public string GoalCollection { get; set; }
        public string OddsCollection { get; set; }
        public string PenaltyCollection { get; set; }
        public string PlayerCollection { get; set; }
        public string ResultSetCollection { get; set; }
        public string RootMatchsCollection { get; set; }
        public string ScoreCollection { get; set; }
        public string ScoreTimeCollection { get; set; }
        public string SeasonCollection { get; set; }
        public string SubstitutionCollection { get; set; }
        public string TeamCollection { get; set; }




    }
}
