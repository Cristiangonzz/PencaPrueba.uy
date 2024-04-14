export interface IResponseDomain<T>
{
  status: boolean;
  msg?: string;
  value?: T;
}
