import { TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { ClientesService } from './clientes.service';
import { Cliente, CrearCliente } from './interfaces/Clientes.model';

describe('ClientesService', () => {
  let service: ClientesService;
  let httpClientSpy: { get: jest.Mock; post: jest.Mock };

  const mockClientes: Cliente[] = [
    { personaId: 1, nombre: 'Juan', genero: 'M', edad: 30, identificacion: 1234, direccion: 'Calle 1', telefono: 1234567890, contrasena: '123', estado: true },
    { personaId: 2, nombre: 'Maria', genero: 'F', edad: 25, identificacion: 5678, direccion: 'Calle 2', telefono: 9876543210, contrasena: 'abc', estado: true }
  ];

  const nuevoCliente: CrearCliente = {
    nombre: 'Pedro',
    genero: 'M',
    edad: 28,
    identificacion: 9999,
    direccion: 'Calle 3',
    telefono: 111222333,
    contrasena: 'xyz',
    estado: true
  };

  beforeEach(() => {
    httpClientSpy = {
      get: jest.fn().mockReturnValue(of(mockClientes)),
      post: jest.fn().mockReturnValue(of({ success: true }))
    };

    TestBed.configureTestingModule({
      providers: [
        ClientesService,
        { provide: 'HttpClient', useValue: httpClientSpy }
      ]
    });

    // @ts-ignore
    service = new ClientesService(httpClientSpy as any);
  });

  it('should fetch all clientes', (done) => {
    service.getAll().subscribe(clientes => {
      expect(clientes).toEqual(mockClientes);
      done();
    });
  });

  it('should create a new cliente', (done) => {
    service.crearCliente(nuevoCliente).subscribe(response => {
      expect(response).toEqual({ success: true });
      expect(httpClientSpy.post).toHaveBeenCalledWith(
        `${service['apiUrl']}`,
        nuevoCliente
      );
      done();
    });
  });
});
