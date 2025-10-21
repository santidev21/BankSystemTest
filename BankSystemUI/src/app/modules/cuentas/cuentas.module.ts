import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CuentasRoutingModule } from './cuentas.routing.module';
import { CuentasComponent } from './inicio/cuentas.component';
import { NuevaCuentaComponent } from './nueva-cuenta/nueva-cuenta.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    CuentasComponent,
    NuevaCuentaComponent
  ],
  imports: [
    CommonModule,
    CuentasRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class CuentasModule { }
