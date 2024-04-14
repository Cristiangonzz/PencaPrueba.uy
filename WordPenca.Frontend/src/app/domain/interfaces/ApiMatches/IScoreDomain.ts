import { IFullTimeDomain } from "./IFullTimeDomain";
import { IHalfTimeDomain } from "./IHalfTimeDomain";

export interface IScoreDomain {
  winner?: string | null;
  duration?: string | null;
  fullTime?: IFullTimeDomain | null;
  halfTime?: IHalfTimeDomain | null;
}
