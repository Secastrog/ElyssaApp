import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Login, ResponseLogin } from '../interface/interfaceAuth';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _url = `${environment.apiBAck}Api/Models/ElyssaAccount/ElyssaAccounts`
  private httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
  constructor(private https: HttpClient) { }

  setAccountId(accountId: any) {
   sessionStorage.setItem('accountId', accountId);
  }

  getAccountId(): any {
    return sessionStorage.getItem('accountId');
  }
  
  isLoggedIn(): boolean {
    return  this.getAccountId() !== null;
  }

  logout() {
    sessionStorage.clear();

  }

  public user: Login= {
    password: '',
    user: ''
  }

  Login() {
    console.log(this.user)
    return this.https.post<ResponseLogin>(`${this._url}/Login`, this.user, this.httpOptions);
  }



}
