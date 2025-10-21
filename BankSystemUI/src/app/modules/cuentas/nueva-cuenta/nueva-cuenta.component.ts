import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CuentasService } from '../cuentas.service';
import { ClientesService } from '../../clientes/clientes.service';
import { Cliente } from '../../clientes/interfaces/Clientes.model';

@Component({
  selector: 'app-nueva-cuenta',
  templateUrl: './nueva-cuenta.component.html',
  styleUrls: ['./nueva-cuenta.component.scss']
})
export class NuevaCuentaComponent implements OnInit {
  cuentaForm: FormGroup = new FormGroup({});
  tipos = ['Ahorros', 'Corriente'];
  isEditMode: boolean = false;
  listaClientes: Cliente[] = [];

  constructor(private fb: FormBuilder,
    private router: Router,
    private activeRoute: ActivatedRoute,
    private cuentasService: CuentasService,
    private clientesService: ClientesService
  ) { }

  ngOnInit(): void {  
    this.cuentaForm = this.fb.group({
      numeroCuenta: ['', [Validators.required, Validators.min(0)]],
      tipo: ['', Validators.required],
      saldoInicial: ['', [Validators.required, Validators.min(0)]],
      personaId: ['', Validators.required],
      estado: [true, Validators.required],
    });

    const id = this.activeRoute.snapshot.paramMap.get('id');
    if(id){
      this.isEditMode = true;
      this.cuentasService.getById(parseInt(id)).subscribe(cuenta => {
        this.cuentaForm.patchValue(cuenta);
        this.cuentaForm.get('saldoInicial')?.disable();
        this.cuentaForm.get('personaId')?.disable();

      });
    }

    this.clientesService.getAll().subscribe((resp : Cliente[]) => {
      this.listaClientes = resp;
    });
    
  }

  onSubmit() : void{
  if (this.cuentaForm.valid) {
    if(this.isEditMode){
      let cuentaEditado = this.cuentaForm.value;
      cuentaEditado.cuentaId = this.activeRoute.snapshot.paramMap.get('id');
      cuentaEditado.personaId = this.cuentaForm.get('personaId')?.value;
      cuentaEditado.saldoInicial = this.cuentaForm.get('saldoInicial')?.value;
      cuentaEditado.nombreCliente = this.listaClientes.find(c => c.personaId == cuentaEditado.personaId)?.nombre || '';

      console.log(cuentaEditado);
      
      
      this.cuentasService.actualizarCuenta(cuentaEditado).subscribe(resp => {this.redirect()});
      
    }
    else{
      let cuentaNuevo = this.cuentaForm.value;
      this.cuentasService.crearCuenta(cuentaNuevo).subscribe(resp => {this.redirect()});
    }
    } else {
      this.cuentaForm.markAllAsTouched();
      return;
    }

  }

  redirect(): void {
    this.router.navigate(['/cuentas']);
  }


}
