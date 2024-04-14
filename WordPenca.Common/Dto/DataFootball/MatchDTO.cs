namespace WordPenca.Common.Dto.DataFootball
{
    public class MatchDTO
    {
        public string id { get; set; }
        public string utcDate { get; set; }
        public string status { get; set; }
        public int matchday { get; set; }
        public string stage { get; set; }
        public string group { get; set; }
        public string lastUpdated { get; set; }
        public AreaDTO area { get; set; }
        public CompetitionDTO competition { get; set; }
        public SeasonDTO season { get; set; }
        public HomeTeamDTO homeTeam { get; set; }
        public AwayTeamDTO awayTeam { get; set; }
        public ScoreDTO score { get; set; }
        public OddsDTO odds { get; set; }
        public List<RefereesDTO> referees { get; set; }
    }
}
