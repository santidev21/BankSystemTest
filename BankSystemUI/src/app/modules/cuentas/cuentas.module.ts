import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CuentasComponent } from './cuentas.component';
import { CuentasRoutingModule } from './cuentas.routing.module';



@NgModule({
  declarations: [
    CuentasComponent
  ],
  imports: [
    CommonModule,
    CuentasRoutingModule
  ]
})
export class CuentasModule { }
