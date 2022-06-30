import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClimaComponentComponent } from './Clima/clima-component/clima-component.component';
import {ProgressSpinnerModule} from 'primeng/progressspinner';
import { ToastModule } from 'primeng/toast';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxSpinnerModule } from 'ngx-spinner';
import { CreateAccountComponent } from './Auth/create-account/create-account.component';
import { LoginComponent } from './Auth/login/login.component';
import { ConfirmationService, MessageService } from 'primeng/api';
import {DialogModule, Dialog} from 'primeng/dialog'

@NgModule({
  declarations: [
    AppComponent,
    ClimaComponentComponent,
    CreateAccountComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule, 
    ProgressSpinnerModule,
    NgxSpinnerModule,
    ToastModule,
    BrowserAnimationsModule,
    DialogModule
    
  ],
  providers: [MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
