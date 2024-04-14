import { IAreaDomain } from "./IAreaDomain";
import { IAwayTeamDomain } from "./IAwayTeamDomain";
import { ICompetitionDomain } from "./ICompetitionDomain";
import { IHomeTeamDomain } from "./IHomeTeamDomain";
import { IOddsDomain } from "./IOddsDomain";
import { IRefereesDomain } from "./IRefereesDomain";
import { IScoreDomain } from "./IScoreDomain";
import { ISesionDomain } from "./ISesionDomain";

export interface IMatcheDomain {
  id?: number | null;
  utcDate?: string | null;
  status?: string | null;
  matchday?: number | null;
  stage?: string | null;
  group?: string | null;
  lastUpdated?: string | null;
  area: IAreaDomain;
  competition: ICompetitionDomain;
  season: ISesionDomain;
  homeTeam: IHomeTeamDomain;
  awayTeam: IAwayTeamDomain;
  score: IScoreDomain;
  odds: IOddsDomain;
  referees: IRefereesDomain[];

}





