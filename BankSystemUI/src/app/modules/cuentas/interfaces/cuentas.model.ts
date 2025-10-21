export interface Cuenta{
    cuentaId: number;
    numeroCuenta: number;
    tipo: string;
    saldoInicial: number;
    estado: boolean;
    nombreCliente: string
    personaId: number;
}

export interface CrearCuenta{
    numeroCuenta: number;
    tipo: string;
    saldoInicial: number;
    estado: boolean;
    personaId: number;
}