import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.scss']
})
export class ClientesComponent implements OnInit {
  listaClientes: any[] = [
    { id: 1, nombre: 'Juan Perez'}
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
