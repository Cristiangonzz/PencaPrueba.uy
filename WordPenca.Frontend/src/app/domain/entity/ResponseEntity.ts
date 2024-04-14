import { IResponseDomain } from "../interfaces/IResponseDomain";

export class ResponseDomainEntity<T> implements IResponseDomain<T>
{
  status: boolean;
  msg?: string;
  value?: T;

  constructor(
    status: boolean,

    msg?: string,
    value?: T,

  ) {
    this.status = status as boolean;
    this.msg = msg as string;
    this.value = value as T;
  }

}
