export interface CrearMovimiento{
    tipo: string;
    valor: number;
    cuentaId: number;
}

export interface Movimiento{
    movimientoId: number;
    cuentaId: number;
    fecha: Date;
    nombreCliente: string;
    numeroCuenta: number;
    tipoCuenta: string;
    saldoInicial: number;
    estado: boolean;
    tipoMovimiento: string;
    movimiento: number;
    saldoDisponible: number;
}