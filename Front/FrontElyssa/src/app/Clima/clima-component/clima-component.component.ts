import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MessageService } from 'primeng/api';
import { AuthService } from 'src/app/Auth/services/auth.service';
import { ClimaServiceService } from '../clima-service.service';

@Component({
  selector: 'app-clima-component',
  templateUrl: './clima-component.component.html',
  styleUrls: ['./clima-component.component.scss']
})
export class ClimaComponentComponent implements OnInit {
  public myform!: FormGroup;
  public validation_messages = {
    city: [
      { type: 'required', message: 'Falta información.' },
      { type: 'pattern', message: 'Solo se acepta texto' },
    ],
  };
  public ciudad: string = '';
  public tecmperatura: number = 0;


  constructor(public formbuilder: FormBuilder,
    private spinner: NgxSpinnerService,
    private router: Router,
    private messageService: MessageService,
    public servicelogin: AuthService,
    public ServiceClima: ClimaServiceService) {
    this.myform = formbuilder.group({
      city: new FormControl('', Validators.compose([
        Validators.required,
        Validators.pattern("^[a-zA-Z]+$"),
      ])),
    });
  }

  ngOnInit(): void {
  }

  tomartemperatura() {
    if (this.myform.valid) {
      this.spinner.show();
      console.log(this.myform.value.city);
      this.ServiceClima.temperatura(this.myform.value.city).subscribe(
        (res) => {
          console.log(res);
          if (res == null || res == undefined) {
            this.spinner.hide();
            this.mensaje(2, 'Por favor ingresa una ciudad valida');
          } else {
            this.ciudad = this.myform.value.city;
            this.tecmperatura = res.main.temp - 273, 75;
            this.tecmperatura.toFixed(2);
            this.ServiceClima.historico.city = this.myform.value.city;
            this.ServiceClima.historico.lat = res.coord.lat.toString();
            this.ServiceClima.historico.long = res.coord.lon.toString();
            this.ServiceClima.historico.temperature = this.tecmperatura.toFixed(2);
            this.ServiceClima.historico.idAcElyssa = this.servicelogin.getAccountId();
            console.log(JSON.stringify(this.ServiceClima.historico))
            this.ServiceClima.guardarHistorico().subscribe(
              (resClima) => {
                if (resClima.code == 1) {
                  this.spinner.hide();
                } else {
                  this.spinner.hide();
                  this.mensaje(2, 'No hemos logrado realizar tu solicitud, por favor intenta mas tarde');
                }
              }, (error) => {
                this.spinner.hide();
                this.mensaje(2, 'No hemos logrado realizar tu solicitud, por favor intenta mas tarde');
            }
            )
            this.spinner.hide();

          }

        }, (error) => {
          this.spinner.hide();
          this.mensaje(2, 'Por favor ingresa una ciudad valida');
        }
      )

    } else {
      this.mensaje(2, 'Ingresa la ciudad deseada');
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
