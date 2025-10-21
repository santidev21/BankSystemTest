import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CrearCliente } from '../../interfaces/Clientes.model';
import { ActivatedRoute, Router } from '@angular/router';
import { ClientesService } from '../../clientes.service';

@Component({
  selector: 'app-nuevo-cliente',
  templateUrl: './nuevo-cliente.component.html',
  styleUrls: ['./nuevo-cliente.component.scss']
})
export class NuevoClienteComponent implements OnInit {
  clienteForm: FormGroup = new FormGroup({});
  generos = ['Masculino', 'Femenino', 'Otro'];
  isEditMode: boolean = false;

  constructor(private fb: FormBuilder,
    private router: Router,
    private activeRoute: ActivatedRoute,
    private clientesService: ClientesService
  ) { }

  ngOnInit(): void {  
    this.clienteForm = this.fb.group({
      nombre: ['', Validators.required],
      genero: ['', Validators.required],
      edad: ['', [Validators.required, Validators.min(0)]],
      identificacion: ['', Validators.required],
      direccion: ['', Validators.required],
      telefono: ['', Validators.required],
      contrasena: ['', [Validators.required, Validators.minLength(4)]],
      estado: [true, Validators.required],
    });

    const id = this.activeRoute.snapshot.paramMap.get('id');
    if(id){
      this.isEditMode = true;
      this.clientesService.getById(parseInt(id)).subscribe(cliente => {
        this.clienteForm.patchValue(cliente);        
      });
    }
    
  }

  onSubmit() : void{
  if (this.clienteForm.valid) {
    if(this.isEditMode){
      let clienteEditado = this.clienteForm.value;
      clienteEditado.personaId = this.activeRoute.snapshot.paramMap.get('id');
      this.clientesService.actualizarCliente(clienteEditado).subscribe(resp => {this.redirect()});
      
    }
    else{
      let clienteNuevo = this.clienteForm.value;
      console.log(clienteNuevo);
      
      this.clientesService.crearCliente(clienteNuevo).subscribe(resp => {this.redirect()});
    }
    } else {
      this.clienteForm.markAllAsTouched();
      return;
    }

  }

  redirect(): void {
    this.router.navigate(['/clientes']);
  }


}
