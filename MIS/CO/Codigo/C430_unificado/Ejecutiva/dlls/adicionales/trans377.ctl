'Archivo de Control para la conexion al Sistema S111
'Y generar objetos dinamicos
'Ejemplo:  
'Propiedad:= NombrePropiedad	PosIni:= ##	Longitud:= ##	DelimitadorIni:= XXX DelimitadorFin:= XXX
'Cabe Mencionar que las propiedades ini y  longitud son mutuamente excluyentes
Propiedad:=Cuenta:			DelimitadorIni:= Cuenta:			DelimitadorFin:= TIPO CTA
Propiedad:=TipoCta			DelimitadorIni:= Tipo Cta:		DelimitadorFin:=SUCURSAL
Propiedad:=SUCURSAL			DelimitadorIni:= SUCURSAL:		DelimitadorFin:= SALDO 
Propiedad:=SALDO DEUDOR			DelimitadorIni:= SALDO DEUDOR :		DelimitadorFin:= SALDO ULT.CICLO
Propiedad:=SALDO FAVOR			DelimitadorIni:= SALDO A FAVOR:		DelimitadorFin:= SALDO ULT.CICLO
Propiedad:= SALDO ULTIMO CICLO		DelimitadorIni:= SALDO ULT.CICLO:	Longitud:=15
Propiedad:= LIMITE			DelimitadorIni:= LIM:			DelimitadorFin := MINIMO PAGAR
Propiedad:= MINIMO PAGAR		DelimitadorIni:= MINIMO PAGAR:		DelimitadorFin := IMP ABONO CICLO
Propiedad:= IMP ABONOS CICLO		DelimitadorIni:= IMP ABONO CICLO:	DelimitadorFin := F.U.A.
Propiedad:= FUA				DelimitadorIni:= F.U.A.			Longitud:= 10
Propiedad:= SOBREGIRO			DelimitadorIni:= SOBREGIRO		DelimitadorFin := ULTIMA TRANSACCION
Propiedad:= CREDITO DISPONIBLE		DelimitadorIni:= CREDITO DISP:		DelimitadorFin := ULTIMA TRANSACCION
Propiedad:= ULTIMA TRANSACCION 		DelimitadorIni:= ULTIMA TRANSACCION:	DelimitadorFin := F.U.T.
Propiedad:= FUT				DelimitadorIni:= F.U.T.			DelimitadorFin := VENCE
Propiedad:= VENCE			DelimitadorIni:= VENCE:			DelimitadorFin := CICLO DIA
Propiedad:= CICLO DIA			DelimitadorIni:= CICLO DIA:		DelimitadorFin := USUARIO DESDE
Propiedad:= USUARIO DESDE		DelimitadorIni:= USUARIO DESDE: 	Longitud:=7
Propiedad:= PAGAR ANTES DE		DelimitadorIni:= PAGUE ANTES DEL: 	Longitud:= 10
Propiedad:= IMPORTE DEBITOS		DelimitadorIni:= IMPORTE DEBITOS: 	DelimitadorFin := NO. DEBITOS:
Propiedad:= NO DEBITOS			DelimitadorIni:= NO. DEBITOS:		Longitud:= 6
Propiedad:= VENCIDOS			DelimitadorIni:= VENCIDO:		DelimitadorFin := ATRASADO
Propiedad:= ATRASADO			DelimitadorIni:= ATRASADO		Longitud:= 14
Propiedad:= SALDO FIDEICOMISO		DelimitadorIni:= SDO FIDEICOMISO	Longitud:= 12
Propiedad:= SALDO PROMEDIO		DelimitadorIni:= SDO PROM		Longitud:= 20
Propiedad:= RENDIMIENTO PROMEDIO	DelimitadorIni:= RENDIMIENTO		Longitud:= 14
Propiedad:= NOCONTRATO			DelimitadorIni:= NUM. CONTRATO:		Longitud:= 15
Propiedad:= ESTADO ADICIONAL 		DelimitadorIni:= ADICIONAL :		DelimitadorFin:= BASICA :
Propiedad:= ESTADO BASICA 		DelimitadorIni:= BASICA :		Longitud:= 15
