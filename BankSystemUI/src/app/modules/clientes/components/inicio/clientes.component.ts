import { Component, OnInit } from '@angular/core';
import { ClientesService } from '../../clientes.service';
import { Cliente } from '../../interfaces/Clientes.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.scss']
})
export class ClientesComponent implements OnInit {
  listaClientes: Cliente[] = [];
  filtro: string = '';

  constructor(private clientesService: ClientesService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.clientesService.getAll().subscribe((resp : Cliente[]) => {
      this.listaClientes = resp;
    });
  }

  agregarNuevoCliente() : void{
    this.router.navigate(['/clientes/nuevo']);
  }

  editarCliente(id: number) : void{
  this.router.navigate([`/clientes/editar/${id}`]);
  }

  eliminarCliente(id: number) : void{
    this.clientesService.eliminarCliente(id).subscribe(resp => {
      this.listaClientes = this.listaClientes.filter(c => c.personaId !== id);
    });
  }

  get listaClientesFiltrada() {
    const texto = this.filtro.toLowerCase();
    return this.listaClientes.filter(p =>
      Object.values(p).some(valor =>
        String(valor).toLowerCase().includes(texto)
      )
    );
  }
}
