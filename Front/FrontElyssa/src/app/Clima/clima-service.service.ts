import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { RequestClima, ResponHistoryseClima, ResponseClima } from '../Interface/climaInterface';

@Injectable({
  providedIn: 'root'
})
export class ClimaServiceService {
  private httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json', "Acces-Control-Allow-Origin": "*" }) };
  private _url = `${environment.apiBAck}Api/Models/ElyssaAccount/ElyssaAccounts`
  private url = `${environment.apiBAck}Api/Models/ElyssaAccount/HistoryClimates`


  constructor(private https: HttpClient) { }

  public historico: RequestClima= {
    city: '',
    lat: '',
    long: '',
    temperature: '',
    idAcElyssa: 0
  }

  temperatura(City:string) {
    return this.https.get<ResponseClima>(`${this._url}/GetClima/${City}`, this.httpOptions);
  }

  guardarHistorico(){
    return this.https.post<ResponHistoryseClima>(`${this.url}/Insert/`, this.historico,this.httpOptions);
  }

}
