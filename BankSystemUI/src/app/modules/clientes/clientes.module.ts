import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientesComponent } from './components/inicio/clientes.component';
import { ClientesRoutingModule } from './clientes.routing.module';
import { NuevoClienteComponent } from './components/nuevo-cliente/nuevo-cliente.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    ClientesComponent,
    NuevoClienteComponent
  ],
  imports: [
    CommonModule,
    ClientesRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class ClientesModule { }
