import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MessageService } from 'primeng/api';
import { ResponseLogin } from '../interface/interfaceAuth';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public mensaje_error!: string;
  public validation_messages = {
    usuario: [
      { type: 'email', message: 'No es un formato de correo.' },
      { type: 'required', message: 'Falta información.' },
    ],
    password: [
      { type: 'required', message: 'Falta información.' },
      { type: 'pattern', message: 'Solo se aceptan valores numericos' },
      { type: 'minlength', message: 'Minimo 8 digitos' },
      { type: 'maxlength', message: 'Maximo 10 digitos' },
    ],
  };
  public myform!: FormGroup;
  public vizualizar_password = 'pi pi-eye';
  public tipo_input = 'password';
  private respuesta_login!: ResponseLogin;
  public popUp: boolean = false;


  constructor(public formbuilder: FormBuilder,
    private spinner: NgxSpinnerService,
    private router: Router,
    private messageService: MessageService,
    public servicelogin: AuthService) {
    this.myform = formbuilder.group({
      usuario: new FormControl('', Validators.compose([
        Validators.required,
      ])),
      password: new FormControl('', Validators.compose([
        Validators.required,
        Validators.pattern("^[0-9]*$"), 
        Validators.minLength(8),
        Validators.maxLength(10),
      ])),
    });
  }

  ngOnInit(): void {
  }

  Visualizar_password() {
    if (this.vizualizar_password === 'pi pi-eye') {
      this.vizualizar_password = 'pi pi-eye-slash';
      this.tipo_input = 'text';
    } else {
      this.vizualizar_password = 'pi pi-eye';
      this.tipo_input = 'password';
    }
  }

  login_in() {
    if(this.myform.valid){
      this.spinner.show();
      this.servicelogin.user.user = this.myform.value.usuario;
      this.servicelogin.user.password = this.myform.value.password;
      console.log(JSON.stringify(this.servicelogin.user))
      this.servicelogin.Login().subscribe(
        (res)=>{
          this.spinner.hide();
          if(res.code == 1){
            console.log('injg')
            this.servicelogin.setAccountId(res.identity);
            this.router.navigate(['clima'])

          }else{
            this.mensaje(2, res.description)
          }
          console.log(res)
        }
      )
      
    }else{
      this.mensaje(2,"Por favor ingresa los campos solicitados")
    }

  }

  mensaje(tipo: number, mensaje: string) {
    if (tipo == 1) {
      this.messageService.add({ severity: 'success', summary: mensaje });
    } else {
      this.messageService.add({ severity: 'error', summary: '¡Advertencia!', detail: mensaje });
    }
  }

}
