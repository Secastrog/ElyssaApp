import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginGuard } from './Auth/guard/login.guard';
import { LoginComponent } from './Auth/login/login.component';
import { ClimaComponentComponent } from './Clima/clima-component/clima-component.component';

const routes: Routes = [
  {path: '', redirectTo: 'login', pathMatch:'full'},
  {path: 'clima', component: ClimaComponentComponent, canActivate: [LoginGuard] },
  {path: 'clima', redirectTo: 'clima', pathMatch:'full'},
  
  //login
  {path: 'login', component: LoginComponent},
  {path: 'login', redirectTo: 'login', pathMatch:'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
