import { throwError } from 'rxjs';

export abstract class ServiceBase
{
  protected UrlServiceV1: string = "https://localhost:5001/";

  protected extractData(response: any){
    return response || {};
  }

  protected serviceError(error: Response | any){
    let errMsg: string;

    if(error instanceof Response){
      errMsg = `${error.status} - ${error.statusText || ''}`;
    }else{
      errMsg = error.message ? error.message : error.toString();
    }

    console.error(error);
    return throwError(error);
  }

}
