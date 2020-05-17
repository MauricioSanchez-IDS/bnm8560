using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORMNREN
        : System.Windows.Forms.Form
    {


        int lTotNumEmp = 0;
        double dTotalFact = 0;
        double dTotalCart = 0;
        double dToralRenta = 0;
        double dTotRentabolidad = 0;
        int lEmpresa = 0;
        string pszNomEmp = String.Empty;
        int iNoRenglon = 0;
        string msMes = String.Empty;
        double mdRentaMin = 0;
        double dRentFact = 0;
        double dRenCart = 0;
        double mdRentaMax = 0;
        string MsNomEmp = String.Empty;
        string msFechaIni = String.Empty;
        string msFechaFin = String.Empty;
        string pszGpoNom = String.Empty;
        int lGpo = 0;
        string pszCuenta = String.Empty;
        string pszNomEje = String.Empty;
        int lFecha = 0;
        int lTotNumReg = 0;
        double dPauseTime = 0;
        double dStart = 0;
        double mdRenProm = 0;
        int mlConReg = 0;


        bool mbAgrego = false;

        int iErr = 0;
        int iTop = 0;
        int iLeft = 0;
        bool bValMin = false;










        //****************************************************************************
        //**                                                                        **
        //**       Descripción:                                                     **
        //**                   Imprime el total de la rentabilidad en el spread     **
        //**                                                                        **
        //**       Paso de parámetros:maximo de renglones                           **
        //**                                                                        **
        //**       Valor de Regreso:                                                **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 26 nov 98                                   **
        //**                                                                        **
        //****************************************************************************
        //
        //
        private void Calcula_totales(double iMaxRenglones)
        {

            int iNoCol = 0;

            //Asigna el máximo de renglones
            sprRepRenta.MaxRows = Convert.ToInt32(iMaxRenglones);

            if (CORCTREN.DefInstance.Tag.ToString() != "Una")
            {
                sprRepRenta.VisibleCols = 6;
                iNoCol = 6;
            }
            else
            {
                sprRepRenta.VisibleCols = 7;
                iNoCol = 7;
            }

            //Formatea ultimos renglon
            for (int jCont = Convert.ToInt32(iMaxRenglones); jCont <= Convert.ToInt32(iMaxRenglones + 1); jCont++)
            {
                sprRepRenta.Row = jCont;
                for (int iCont = 1; iCont <= iNoCol; iCont++)
                {
                    sprRepRenta.Col = iCont;
                    sprRepRenta.BackColor = Color.Silver;
                }
            }

            //  sprRepRenta.Row = iMaxRenglones - 2

            //Totales
            sprRepRenta.Col = 1;
            sprRepRenta.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            sprRepRenta.TypeHAlign = 0;
            sprRepRenta.Text = "Total";


            //totalde empresas
            sprRepRenta.Col = 2;
            sprRepRenta.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            sprRepRenta.Text = StringsHelper.Format(lTotNumEmp, "###,###,###");


            //total de facturación
            sprRepRenta.Col = 4;
            //  sprRepRenta.CellType = (FPSpreadADO.CellTypeConstants)2
            //  sprRepRenta.TypeFloatSeparator = True
            sprRepRenta.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            sprRepRenta.Text = StringsHelper.Format(dTotalFact, "##,###,###,##0.00");
            int iAncho = Convert.ToInt32(sprRepRenta.get_MaxTextColWidth(4));
            sprRepRenta.set_ColWidth(4, iAncho + 5);

            //total por cartera
            sprRepRenta.Col = 5;
            sprRepRenta.CellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            sprRepRenta.TypeFloatSeparator = true;
            sprRepRenta.Text = StringsHelper.Format(dTotalCart, "##,###,###,##0.00");
            iAncho = Convert.ToInt32(sprRepRenta.get_MaxTextColWidth(5));
            sprRepRenta.set_ColWidth(5, iAncho + 5);


            //gran total
            sprRepRenta.Col = 6;
            sprRepRenta.CellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            sprRepRenta.TypeFloatSeparator = true;
            sprRepRenta.Text = StringsHelper.Format(dToralRenta, "##,###,###,##0.00");
            iAncho = Convert.ToInt32(sprRepRenta.get_MaxTextColWidth(6));
            sprRepRenta.set_ColWidth(6, iAncho + 5);


            if (CORCTREN.DefInstance.Tag.ToString() == "Una")
            {
                sprRepRenta.Col = 7;
                sprRepRenta.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
                sprRepRenta.Text = CORVB.NULL_STRING;
                iAncho = Convert.ToInt32(sprRepRenta.get_MaxTextColWidth(6));
                sprRepRenta.set_ColWidth(6, iAncho);

            }

            sprRepRenta.Row = Convert.ToInt32(iMaxRenglones);

        }


        //****************************************************************************
        //**                                                                        **
        //**       Descripción:                                                     **
        //**                   Imprime el total de la rentabilidad en el spread     **
        //**                                                                        **
        //**       Paso de parámetros:maximo de renglones                           **
        //**                                                                        **
        //**       Valor de Regreso:                                                **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 26 nov 98                                   **
        //**                                                                        **
        //****************************************************************************
        //
        //
        private void Calcula_totales_Detalle(double iMaxRenglones)
        {

            int iNoCol = 0;

            //Asigna el máximo de renglones
            sprRepRenta.MaxRows = Convert.ToInt32(iMaxRenglones);

            if (CORCTREN.DefInstance.Tag.ToString() != "Detalle")
            {
                sprRepRenta.VisibleCols = 6;
                iNoCol = 6;
            }
            else
            {
                sprRepRenta.VisibleCols = 5;
                iNoCol = 5;
            }

            //Formatea ultimos renglon
            for (int jCont = Convert.ToInt32(iMaxRenglones); jCont <= Convert.ToInt32(iMaxRenglones + 1); jCont++)
            {
                sprRepRenta.Row = jCont;
                for (int iCont = 1; iCont <= iNoCol; iCont++)
                {
                    sprRepRenta.Col = iCont;
                    sprRepRenta.BackColor = Color.Silver;
                }
            }

            //  sprRepRenta.Row = iMaxRenglones - 2

            //Totales
            sprRepRenta.Col = 1;
            sprRepRenta.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            sprRepRenta.TypeHAlign = 0;
            sprRepRenta.Text = "Total";


            //totalde empresas
            sprRepRenta.Col = 2;
            sprRepRenta.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            sprRepRenta.Text = StringsHelper.Format(lTotNumReg, "###,###,###");

            //total de facturación
            sprRepRenta.Col = 3;
            sprRepRenta.CellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            sprRepRenta.TypeFloatSeparator = true;
            sprRepRenta.Text = StringsHelper.Format(dTotalFact, "##,###,###,##0.00");
            int iAncho = Convert.ToInt32(sprRepRenta.get_MaxTextColWidth(3));
            sprRepRenta.set_ColWidth(3, iAncho + 5);

            //total por cartera
            sprRepRenta.Col = 4;
            sprRepRenta.CellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            sprRepRenta.TypeFloatSeparator = true;
            sprRepRenta.Text = StringsHelper.Format(dTotalCart, "##,###,###,##0.00");
            iAncho = Convert.ToInt32(sprRepRenta.get_MaxTextColWidth(4));
            sprRepRenta.set_ColWidth(4, iAncho + 5);

            //gran total
            sprRepRenta.Col = 5;
            sprRepRenta.CellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            sprRepRenta.TypeFloatSeparator = true;
            sprRepRenta.Text = StringsHelper.Format(dToralRenta, "##,###,###,##0.00");
            iAncho = Convert.ToInt32(sprRepRenta.get_MaxTextColWidth(5));
            sprRepRenta.set_ColWidth(5, iAncho + 5);

            if (CORCTREN.DefInstance.Tag.ToString() != "Detalle")
            {
                sprRepRenta.Col = 6;
                sprRepRenta.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
                sprRepRenta.Text = CORVB.NULL_STRING;
                iAncho = Convert.ToInt32(sprRepRenta.get_MaxTextColWidth(6));
                sprRepRenta.set_ColWidth(6, iAncho);
            }

            sprRepRenta.Row = Convert.ToInt32(iMaxRenglones);

        }


        //****************************************************************************
        //**                                                                        **
        //**       Descripción:                                                     **
        //**                   Limpia las variables utilizadas en el calculo de     **
        //**                   la rentabilidad                                      **
        //**                                                                        **
        //**       Paso de parámetros:                                              **
        //**                                                                        **
        //**       Valor de Regreso:                                                **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 26nov98                                     **
        //**                                                                        **
        //****************************************************************************
        //
        private void Limpia_Variables()
        {

            dRentFact = CORVB.NULL_INTEGER;
            dRenCart = CORVB.NULL_INTEGER;
            dTotRentabolidad = CORVB.NULL_INTEGER;

            pszNomEmp = CORVB.NULL_STRING;

        }


        //****************************************************************************
        //**                                                                        **
        //**       Descripción:                                                     **
        //**                   Lena el spread con los datos obtenidos               **
        //**                                                                        **
        //**       Paso de parámetros:                                              **
        //**                                                                        **
        //**       Valor de Regreso:                                                **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 26nov98                                     **
        //**                                                                        **
        //****************************************************************************
        //
        //
        private void Llena_Detalle()
        {

            sprRepRenta.Row = sprRepRenta.MaxRows;

            mbAgrego = true;


            //Numero de la Empresa
            sprRepRenta.Col = 1;
            sprRepRenta.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            //***** Código Anterior     ***********
            //  sprRepRenta.Text = Format$(lEmpresa, "00000")
            //***** Fin Código Anterior ***********
            //EISSA 05.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo
            sprRepRenta.Text = StringsHelper.Format(lEmpresa, Formato.sMascara(Formato.iTipo.Empresa));
            //EISSA 05.10.2001 FIN
            lTotNumEmp++; //Acumulamos el numero de empresas

            //Nombre de la Empresa
            sprRepRenta.Col = 2;
            sprRepRenta.Text = new String(' ', 1) + pszNomEmp.Trim();

            //Nombre del grupo
            sprRepRenta.Col = 3;
            sprRepRenta.Text = StringsHelper.Format(lGpo, "000") + "   " + pszGpoNom.Trim();


            //rentabilidad por facturación
            sprRepRenta.Col = 4;
            sprRepRenta.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            sprRepRenta.Text = StringsHelper.Format(dRentFact, "##,###,###,##0.00");
            dTotalFact += dRentFact;

            //rentabilidad por cartera
            sprRepRenta.Col = 5;
            sprRepRenta.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            sprRepRenta.Text = StringsHelper.Format(dRenCart, "##,###,###,##0.00");
            dTotalCart += dRenCart;

            //rentabilidad
            sprRepRenta.Col = 6;
            sprRepRenta.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            sprRepRenta.Text = StringsHelper.Format(dTotRentabolidad, "##,###,###,##0.00");
            dToralRenta += dTotRentabolidad;
            mlConReg++;

            Renta_Max_Min(dTotRentabolidad);

            if (CORCTREN.DefInstance.Tag.ToString() == "Una")
            {
                //mes de corte
                sprRepRenta.Col = 7;
                sprRepRenta.Text = new String(' ', 1) + msMes.Trim();

            }

            sprRepRenta.MaxRows++;

        }




        //****************************************************************************
        //**                                                                        **
        //**       Descripción:                                                     **
        //**                   Lena el spread con los datos obtenidos               **
        //**                                                                        **
        //**       Paso de parámetros:                                              **
        //**                                                                        **
        //**       Valor de Regreso:                                                **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 3 dic98                                     **
        //**                                                                        **
        //****************************************************************************
        //
        //
        private void Llena_Detalle_Rentabilidad()
        {

            sprRepRenta.Row = sprRepRenta.MaxRows;

            mbAgrego = true;


            //Numero de la cuenta
            sprRepRenta.Col = 1;
            sprRepRenta.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            sprRepRenta.Text = pszCuenta;
            lTotNumReg++;

            //Nombre del tarjetahabiente
            sprRepRenta.Col = 2;
            sprRepRenta.Text = new String(' ', 1) + pszNomEje.Trim();

            //rentabilidad por facturación
            sprRepRenta.Col = 3;
            sprRepRenta.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            sprRepRenta.Text = StringsHelper.Format(dRentFact, "##,###,###,##0.00");
            dTotalFact += dRentFact;

            //rentabilidad por cartera
            sprRepRenta.Col = 4;
            sprRepRenta.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            sprRepRenta.Text = StringsHelper.Format(dRenCart, "##,###,###,##0.00");
            dTotalCart += dRenCart;

            //rentabilidad
            sprRepRenta.Col = 5;
            sprRepRenta.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            sprRepRenta.Text = StringsHelper.Format(dTotRentabolidad, "##,###,###,##0.00");
            dToralRenta += dTotRentabolidad;

            mlConReg++;

            if (CORCTREN.DefInstance.Tag.ToString() == "Detalle_Rango")
            {
                //mes de corte
                sprRepRenta.Col = 6;
                sprRepRenta.Text = new String(' ', 1) + msMes.Trim();

            }

            Renta_Max_Min(dTotRentabolidad);

            sprRepRenta.MaxRows++;


        }






        //****************************************************************************
        //**                                                                        **
        //**       Descripción:                                                     **
        //**                   Da formato al spread                                 **
        //**                                                                        **
        //**       Paso de parámetros:                                              **
        //**                                                                        **
        //**       Valor de Regreso:                                                **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 26nov98                                     **
        //**                                                                        **
        //****************************************************************************
        //
        //
        private void Formatea_Spread()
        {

            sprRepRenta.ReDraw = false;
            sprRepRenta.Row = 0;

            if (CORCTREN.DefInstance.Tag.ToString() != "Una")
            {
                sprRepRenta.MaxCols = 6;
            }
            else
            {
                sprRepRenta.MaxCols = 7;
            }


            sprRepRenta.Col = 1;
            sprRepRenta.set_ColWidth(1, 7);
            sprRepRenta.Text = "Número";

            sprRepRenta.Col = 2;
            sprRepRenta.set_ColWidth(2, 30);
            sprRepRenta.Text = "Empresa";

            sprRepRenta.Col = 3;
            sprRepRenta.set_ColWidth(3, 4);
            sprRepRenta.Text = "Gpo";


            sprRepRenta.Col = 4;
            sprRepRenta.set_ColWidth(4, 18);
            sprRepRenta.Text = "Ingresos";
            sprRepRenta.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

            sprRepRenta.Col = 5;
            sprRepRenta.set_ColWidth(5, 18);
            sprRepRenta.Text = "Egresos";
            sprRepRenta.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

            sprRepRenta.Col = 6;
            sprRepRenta.set_ColWidth(6, 18);
            sprRepRenta.Text = "Total";
            sprRepRenta.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;

            if (CORCTREN.DefInstance.Tag.ToString() == "Una")
            {
                sprRepRenta.Col = 7;
                sprRepRenta.set_ColWidth(7, 18);
                sprRepRenta.Text = "Mes";
                sprRepRenta.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            }

            sprRepRenta.MaxRows = 1;
        }






        //****************************************************************************
        //**                                                                        **
        //**       Descripción:                                                     **
        //**                   Da formato al spread para el detaalle                **
        //**                                                                        **
        //**       Paso de parámetros:                                              **
        //**                                                                        **
        //**       Valor de Regreso:                                                **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 3dic 98                                     **
        //**                                                                        **
        //****************************************************************************
        //
        //
        private void Formatea_Spread_Detalle()
        {

            sprRepRenta.ReDraw = false;
            sprRepRenta.Row = 0;

            if (CORCTREN.DefInstance.Tag.ToString() == "Detalle")
            {
                sprRepRenta.MaxCols = 5;
            }
            else
            {
                sprRepRenta.MaxCols = 6;
            }


            sprRepRenta.Col = 1;
            sprRepRenta.set_ColWidth(1, 17);
            sprRepRenta.Text = "Cuenta";

            sprRepRenta.Col = 2;
            sprRepRenta.set_ColWidth(2, 30);
            sprRepRenta.Text = "Nombre de Tarjetahabiente";

            sprRepRenta.Col = 3;
            sprRepRenta.set_ColWidth(3, 18);
            sprRepRenta.Text = "Ingresos";
            sprRepRenta.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

            sprRepRenta.Col = 4;
            sprRepRenta.set_ColWidth(4, 18);
            sprRepRenta.Text = "Egresos";
            sprRepRenta.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

            sprRepRenta.Col = 5;
            sprRepRenta.set_ColWidth(5, 18);
            sprRepRenta.Text = "Total";
            sprRepRenta.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;


            if (CORCTREN.DefInstance.Tag.ToString() != "Detalle")
            {
                sprRepRenta.Col = 6;
                sprRepRenta.set_ColWidth(6, 18);
                sprRepRenta.Text = "Periodo";
                sprRepRenta.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            }

            sprRepRenta.MaxRows = 1;
        }



        //****************************************************************************
        //**                                                                        **
        //**       Descripción:                                                     **
        //**                   Muestra el titulo del spread y datos adicionales     **
        //**                                                                        **
        //**       Paso de parámetros:                                              **
        //**                                                                        **
        //**       Valor de Regreso:                                                **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 26nov98                                     **
        //**                                                                        **
        //****************************************************************************
        //
        //
        private void Llena_Titulo()
        {

            switch (CORCTREN.DefInstance.Tag.ToString())
            {

                case "Una":
                    //***** Código Anterior     *********** 
                    //        lblTituloEmp = Format(lgblNumEmpresa, "00000") & " " & MsNomEmp 
                    //***** Fin Código Anterior *********** 
                    //EISSA 05.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo 
                    lblTituloEmp.Text = StringsHelper.Format(CORVAR.lgblNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + " " + MsNomEmp;
                    //EISSA 05.10.2001 FIN 
                    lblFecha.Text = "Fecha Inicio:";
                    break;
                case "Seleccion":
                    lblTitulo.Text = "Rentabilidad de las Empresas Seleccionadas";
                    break;
                case "Detalle":
                    //***** Código Anterior     *********** 
                    //        lblTituloEmp = Format(lgblNumEmpresa, sMascara(Empresa)) & " " & MsNomEmp 
                    //***** Fin Código Anterior *********** 
                    //EISSA 05.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo 
                    lblTituloEmp.Text = StringsHelper.Format(CORVAR.lgblNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + " " + MsNomEmp;
                    //EISSA 05.10.2001 FIN 
                    break;
                case "Detalle_Rango":
                    //***** Código Anterior     *********** 
                    //        lblTituloEmp = Format(lgblNumEmpresa, sMascara(Empresa)) & " " & MsNomEmp 
                    //***** Fin Código Anterior *********** 
                    //EISSA 05.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo 
                    lblTituloEmp.Text = StringsHelper.Format(CORVAR.lgblNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + " " + MsNomEmp;
                    //EISSA 05.10.2001 FIN 
                    lblFecha.Text = "Fecha Inicio:";
                    break;
            }
            if (mdRentaMin == CORVB.NULL_INTEGER)
            {
                lblMinResp.Text = "0.00";
            }
            else
            {
                lblMinResp.Text = StringsHelper.Format(mdRentaMin, "###,###,###.00");
            }
            lblMaxResp.Text = StringsHelper.Format(mdRentaMax, "###,###,###,###,###.00");
            lblRenPromedio.Text = StringsHelper.Format(mdRenProm, "###,###,###,###.00");
            lblFecFinR.Text = msFechaFin;
            lblFecha.Text = "Fecha :";
            lblFechaRes.Text = msFechaIni;

        }

        //****************************************************************************
        //**                                                                        **
        //**       Descripción:                                                     **
        //**                   Obtiene el mes en texto                              **
        //**                                                                        **
        //**       Paso de parámetros:Numero de mes                                 **
        //**                                                                        **
        //**       Valor de Regreso: Funcion string                                 **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 26nov98                                     **
        //**                                                                        **
        //****************************************************************************
        //

        private string Mes(int iNumMes)
        {
            string result = String.Empty;
            switch (iNumMes)
            {
                case 1:
                    result = "Enero";
                    break;
                case 2:
                    result = "Febrero";
                    break;
                case 3:
                    result = "Marzo";
                    break;
                case 4:
                    result = "Abril";
                    break;
                case 5:
                    result = "Mayo";
                    break;
                case 6:
                    result = "Junio";
                    break;
                case 7:
                    result = "Julio";
                    break;
                case 8:
                    result = "Agosto";
                    break;
                case 9:
                    result = "Septiembre";
                    break;
                case 10:
                    result = "Octubre";
                    break;
                case 11:
                    result = "Noviembre";
                    break;
                case 12:
                    result = "Diciembre";
                    break;
            }

            return result;
        }

        //****************************************************************************
        //**                                                                        **
        //**       Descripción:                                                     **
        //**                   obtiene la rentabilidad  del stored ejecutado        **
        //**                                                                        **
        //**       Paso de parámetros:                                              **
        //**                                                                        **
        //**       Valor de Regreso:                                                **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 26nov98                                     **
        //**                                                                        **
        //****************************************************************************
        //
        //
        private void Obtiene_Rentabilidad()
        {
            int lTransac = 0;
            string pszTipoTra = String.Empty;
            int iMaxRenglon = 0;
            int lEmpresaAnt = 0;
            int lValamd = 0;
            int lTime = 0;
            double dImporte = 0;
            int lNegocio = 0;
            double dTasaRenTra = 0;



            //proceso utilizado para los calculos de remtabilidad de los strores
            CORPROC2.Libera_Memoria(CORVAR.hgblConexion);

            if (CORPROC2.ObtieneRegistros(ref CORVAR.pszgblsql) != 0)
            {
                do
                {
                    //AIS-1609 FSABORIO
                    while ((!CerrarFormulario) && (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS))
                    {


                        lEmpresa = CORVB.NULL_INTEGER;
                        dRentFact = CORVB.NULL_INTEGER;
                        dRenCart = CORVB.NULL_INTEGER;
                        pszNomEmp = CORVB.NULL_STRING;

                        lEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));
                        dRentFact = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4));
                        dRenCart = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 5));
                        pszNomEmp = VBSQL.SqlData(CORVAR.hgblConexion, 6);
                        dTotRentabolidad = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 7));
                        lGpo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 8)));
                        pszGpoNom = VBSQL.SqlData(CORVAR.hgblConexion, 9);

                        if (CORCTREN.DefInstance.Tag.ToString() == "Todas" || CORCTREN.DefInstance.Tag.ToString() == "Tope")
                        {
                            if (lEmpresa != lEmpresaAnt)
                            {
                                iNoRenglon++;
                                iMaxRenglon = iNoRenglon + 4;
                                Llena_Detalle();
                                Limpia_Variables();
                                lEmpresaAnt = lEmpresa;
                                //muestra la empresa procesando
                                //***** Código Anterior     ***********
                                //          CORMDIBN!ID_COR_MSG_TXT.Caption = "Empresa: " & Format(lEmpresa, sMascara(Empresa))
                                //***** Fin Código Anterior ***********

                                //EISSA 05.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo
                                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Empresa: " + StringsHelper.Format(lEmpresa, Formato.sMascara(Formato.iTipo.Empresa));
                                //EISSA 05.10.2001 FIN
                                dPauseTime = 2;
                                dStart = DateTime.Now.TimeOfDay.TotalSeconds;

                                //AIS-1609 FSABORIO
                                while ((!CerrarFormulario) && (DateTime.Now.TimeOfDay.TotalSeconds < dStart + dPauseTime))
                                {
                                    Application.DoEvents();
                                };

                            }

                            //AIS-1609 FSABORIO
                            if (!CerrarFormulario)
                            {
                                if (iNoRenglon > Conversion.Val(CORCTREN.DefInstance.txtMaxima.Text) && CORCTREN.DefInstance.Tag.ToString() == "Tope")
                                {
                                    //cierra la conexion
                                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                                    break;
                                }
                            }
                        }
                    }
                }
                //AIS-1609 FSABORIO
                while ((!CerrarFormulario) && (VBSQL.SqlResults(CORVAR.hgblConexion) != 2));

                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                CORPROC2.Libera_Memoria(CORVAR.hgblConexion);

                //AIS-1609 FSABORIO
                if (!CerrarFormulario)
                {
                    //si es por una empresa
                    if (CORCTREN.DefInstance.Tag.ToString() != "Todas" && CORCTREN.DefInstance.Tag.ToString() != "Tope")
                    {
                        iNoRenglon++;
                        Llena_Detalle();
                    }
                    else
                    {
                        Calcula_totales(iNoRenglon);
                    }
                }
            }
            else
            {
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //AIS-1609 FSABORIO
            if (!CerrarFormulario)
            {

                //calcula la rentabilidad promedio
                if (dToralRenta != 0)
                {
                    mdRenProm = dToralRenta / mlConReg;
                }
                else
                {
                    mdRenProm = CORVB.NULL_INTEGER;
                }
            }

        }



        //****************************************************************************
        //**                                                                        **
        //**       Descripción:                                                     **
        //**                   obtiene la rentabilidad  del stored ejecutado        **
        //**                   para el detalle                                      **
        //**       Paso de parámetros:                                              **
        //**                                                                        **
        //**       Valor de Regreso:                                                **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 3 dic98                                     **
        //**                                                                        **
        //****************************************************************************
        //
        //
        private void Obtiene_Rentabilidad_Detalle()
        {
            int lTransac = 0;
            string pszTipoTra = String.Empty;
            int iMaxRenglon = 0;
            int lValamd = 0;
            int lTime = 0;
            double dImporte = 0;
            int lNegocio = 0;
            double dTasaRenTra = 0;
            string smes = String.Empty;


            //proceso utilizado para los calculos de remtabilidad de los strores
            CORPROC2.Libera_Memoria(CORVAR.hgblConexion);

            if (CORPROC2.ObtieneRegistros(ref CORVAR.pszgblsql) != 0)
            {
                do
                {
                    //AIS-1609 FSABORIO
                    while ((!CerrarFormulario) && (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS))
                    {


                        lEmpresa = CORVB.NULL_INTEGER;
                        dRentFact = CORVB.NULL_INTEGER;
                        dRenCart = CORVB.NULL_INTEGER;
                        pszNomEmp = CORVB.NULL_STRING;
                        pszCuenta = CORVB.NULL_STRING;
                        pszNomEje = CORVB.NULL_STRING;
                        lFecha = CORVB.NULL_INTEGER;
                        lGpo = CORVB.NULL_INTEGER;
                        pszGpoNom = CORVB.NULL_STRING;

                        lEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                        dRentFact = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2));
                        dRenCart = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3));
                        pszNomEmp = VBSQL.SqlData(CORVAR.hgblConexion, 4);
                        dTotRentabolidad = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 5));
                        lGpo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 6)));
                        pszGpoNom = VBSQL.SqlData(CORVAR.hgblConexion, 7);
                        pszCuenta = VBSQL.SqlData(CORVAR.hgblConexion, 8);
                        pszNomEje = VBSQL.SqlData(CORVAR.hgblConexion, 9);
                        lFecha = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 10)));

                        //desglosa la fecha
                        msMes = Mes(StringsHelper.IntValue(Strings.Mid(lFecha.ToString(), 5, 2))) + "  " + Strings.Mid(Conversion.Str(lFecha).Trim(), 1, 4) + "   ";
                        MsNomEmp = pszNomEmp;

                        if (smes != msMes)
                        {
                            smes = msMes;
                            //muestra la fecha procesando
                            CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = msMes;
                            dPauseTime = 2;
                            dStart = DateTime.Now.TimeOfDay.TotalSeconds;

                            //AIS-1609 FSABORIO
                            while ((!CerrarFormulario) && (DateTime.Now.TimeOfDay.TotalSeconds < dStart + dPauseTime))
                            {
                                Application.DoEvents();
                            };
                        }

                        //AIS-1609 FSABORIO
                        if (!CerrarFormulario)
                        {
                            //      If dTotRentabolidad <> NULL_INTEGER Then
                            sprRepRenta.MaxRows = iNoRenglon;
                            Llena_Detalle_Rentabilidad();
                            iNoRenglon++;
                            //      End If
                        }
                    }
                }
                //AIS-1609 FSABORIO
                while ((!CerrarFormulario) && (VBSQL.SqlResults(CORVAR.hgblConexion) != 2));

                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                CORPROC2.Libera_Memoria(CORVAR.hgblConexion);

            }
            else
            {
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //AIS-1609 FSABORIO
            if (!CerrarFormulario)
            {
                //calcula la rentabilidad promedio
                if (dToralRenta != 0)
                {
                    mdRenProm = dToralRenta / mlConReg;
                }
                else
                {
                    mdRenProm = CORVB.NULL_INTEGER;
                }
            }
        }


        //****************************************************************************
        //**                                                                        **
        //**       Descripción:                                                     **
        //**                   Proceso que obtiene la rentabilidad del proceso      **
        //**                                                                        **
        //**       Paso de parámetros:                                              **
        //**                                                                        **
        //**       Valor de Regreso:                                                **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 26nov98                                     **
        //**                                                                        **
        //****************************************************************************
        //

        private bool Rentabilidad()
        {

            bool result = false;
            int iMesCorte = 0;
            int iAñoCorte = 0;

            iNoRenglon = 1;
            lTotNumEmp = CORVB.NULL_INTEGER;
            dTotalFact = CORVB.NULL_INTEGER;
            dTotalCart = CORVB.NULL_INTEGER;
            dToralRenta = CORVB.NULL_INTEGER;
            mdRentaMin = CORVB.NULL_INTEGER;
            mdRentaMax = CORVB.NULL_INTEGER;
            lTotNumReg = CORVB.NULL_INTEGER;
            mdRenProm = CORVB.NULL_INTEGER;
            mlConReg = CORVB.NULL_INTEGER;

            sprRepRenta.ReDraw = true;
            sprRepRenta.Visible = true;

            bValMin = false;

            //formatea el spread
            Formatea_Spread();
            Limpia_Variables();


            //habilita el control de mensajes
            CORMDIBN.DefInstance.ID_COR_MSG_TXT.Visible = true;

            // realiza la consulta de todas  las empresas
            switch (CORCTREN.DefInstance.Tag.ToString())
            {
                case "Todas":
                    msFechaIni = CORCTREN.DefInstance.cboFecha.Text;
                    //realiza la consulta 
                    CORVAR.pszgblsql = "Exec spS_Rentabilidad_Total " + CORVAR.gbllAñoMesIni.ToString() + "," + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
                    //              pszgblSql = "Exec spS_Total_Rentabilidad " & gbllAñoMesIni 

                    //obtiene la rentabilidad 
                    Obtiene_Rentabilidad();
                    //muestra titulos 
                    Llena_Titulo();

                    break;
                case "Tope":
                    msFechaIni = CORCTREN.DefInstance.cboFecha.Text;
                    //realiza la consulta 
                    CORVAR.pszgblsql = "Exec spS_Rentabilidad_Ordena " + CORVAR.gbllAñoMesIni.ToString() + "," + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
                    //              pszgblSql = "Exec spS_Ordena_Rentabilidad " & gbllAñoMesIni 
                    //obtiene la rentabilidad 
                    Obtiene_Rentabilidad();
                    //muestra titulos 
                    Llena_Titulo();

                    break;
                case "Seleccion":
                    msFechaIni = CORCTREN.DefInstance.cboFecha.Text;
                    //realiza el periodo 
                    for (int lPeriodo = 1; lPeriodo <= CORCTREN.DefInstance.lstSeleccion.Items.Count; lPeriodo++)
                    {
                        CORCTREN.DefInstance.lstSeleccion.Text = VB6.GetItemString(CORCTREN.DefInstance.lstSeleccion, lPeriodo - 1);
                        //***** Código Anterior     ***********
                        //                lgblNumEmpresa = Val(Left$(CORCTREN!lstSeleccion.Text, 5))         'El número de la empresa
                        //***** Fin Código Anterior ***********
                        //EISSA 05.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo
                        CORVAR.lgblNumEmpresa = Convert.ToInt32(Conversion.Val(CORCTREN.DefInstance.lstSeleccion.Text.Substring(0, Math.Min(CORCTREN.DefInstance.lstSeleccion.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length)))); //El número de la empresa
                        //EISSA 05.10.2001 FIN
                        //realiza la consulta
                        CORVAR.pszgblsql = "Exec spS_Empresa_Rentabilidad " + CORVAR.gbllAñoMesIni.ToString() + "," + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + CORVAR.lgblNumEmpresa.ToString();
                        //obtiene la rentabilidad
                        Obtiene_Rentabilidad();
                        //limpia variables
                        Limpia_Variables();
                    }
                    //calcula totales 
                    Calcula_totales(iNoRenglon);
                    //muestra titulos 
                    Llena_Titulo();

                    break;
                case "Una":
                    //guada los valores en las variables 
                    msFechaIni = CORCTREN.DefInstance.cboFecha.Text;
                    msFechaFin = CORCTREN.DefInstance.cboFechaFin.Text;

                    //realiza el periodo 
                    //AIS-1609 FSABORIO
                    for (int lPeriodo = CORVAR.gbllAñoMesIni; (!CerrarFormulario) && (lPeriodo <= CORVAR.gbllAñoMesFin); lPeriodo++)
                    {
                        iMesCorte = Convert.ToInt32(Conversion.Val(Strings.Mid(lPeriodo.ToString(), 5, 2)));
                        iAñoCorte = Convert.ToInt32(Conversion.Val(Strings.Mid(lPeriodo.ToString(), 1, 4)));
                        msMes = Mes(iMesCorte) + " " + Conversion.Str(iAñoCorte);


                        if ((iMesCorte < 13) && (iMesCorte != CORVB.NULL_INTEGER))
                        {
                            CORCTREN.DefInstance.lstSeleccion.Text = VB6.GetItemString(CORCTREN.DefInstance.lstSeleccion, 0);
                            CORVAR.lgblNumEmpresa = Convert.ToInt32(Conversion.Val(CORCTREN.DefInstance.lstSeleccion.Text.Substring(0, Math.Min(CORCTREN.DefInstance.lstSeleccion.Text.Length, 5)))); //El número de la empresa

                            //muestra el mes a procesar
                            CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = msMes;
                            dPauseTime = 2;
                            dStart = DateTime.Now.TimeOfDay.TotalSeconds;

                            //AIS-1609 FSABORIO
                            while ((!CerrarFormulario) && (DateTime.Now.TimeOfDay.TotalSeconds < dStart + dPauseTime))
                            {
                                Application.DoEvents();
                            };

                            //AIS-1609 FSABORIO
                            if (!CerrarFormulario)
                            {
                                //realiza la consulta
                                CORVAR.pszgblsql = "Exec spS_Empresa_Rentabilidad " + lPeriodo.ToString() + "," + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + CORVAR.lgblNumEmpresa.ToString();
                                //obtiene la rentabilidad
                                Obtiene_Rentabilidad();
                                //muestrta la fecha procesando
                                if (pszNomEmp != CORVB.NULL_STRING)
                                {
                                    MsNomEmp = pszNomEmp;
                                }
                            }
                            //limpia variables
                            Limpia_Variables();
                        }
                    }

                    CORMDIBN.DefInstance.ID_COR_MSG_TXT.Visible = false;
                    //AIS-1609 FSABORIO
                    if (!CerrarFormulario)
                    {
                        //calcula el total de la empresa 
                        Calcula_totales(iNoRenglon);
                        //muestra titulos 
                        Llena_Titulo();
                    }
                    break;
                case "Detalle":
                case "Detalle_Rango":
                    //reformatea el spread 
                    Formatea_Spread_Detalle();
                    //formatea fecha inicio 
                    iMesCorte = Convert.ToInt32(Conversion.Val(Strings.Mid(CORVAR.gbllAñoMesIni.ToString(), 5, 2)));
                    iAñoCorte = Convert.ToInt32(Conversion.Val(Strings.Mid(CORVAR.gbllAñoMesIni.ToString(), 1, 4)));
                    msFechaIni = Mes(iMesCorte) + " " + Conversion.Str(iAñoCorte);
                    //si es por una fecha asigna el valor a la fecha inicio 
                    if (CORCTREN.DefInstance.Tag.ToString() == "Detalle")
                    {
                        CORVAR.gbllAñoMesFin = CORVAR.gbllAñoMesIni;
                    }
                    else
                    {
                        //formatea fecha fin
                        iMesCorte = Convert.ToInt32(Conversion.Val(Strings.Mid(CORVAR.gbllAñoMesFin.ToString(), 5, 2)));
                        iAñoCorte = Convert.ToInt32(Conversion.Val(Strings.Mid(CORVAR.gbllAñoMesFin.ToString(), 1, 4)));
                        msFechaFin = Mes(iMesCorte) + " " + Conversion.Str(iAñoCorte);
                    }
                    CORCTREN.DefInstance.lstSeleccion.Text = VB6.GetItemString(CORCTREN.DefInstance.lstSeleccion, 0);
                    CORVAR.lgblNumEmpresa = Convert.ToInt32(Conversion.Val(CORCTREN.DefInstance.lstSeleccion.Text.Substring(0, Math.Min(CORCTREN.DefInstance.lstSeleccion.Text.Length, 5))));  //El número de la empresa 
                    //realiza la consulta 
                    CORVAR.pszgblsql = "Exec spS_Detalle_Rentabilidad " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + CORVAR.lgblNumEmpresa.ToString() + "," + CORVAR.gbllAñoMesIni.ToString() + "," + CORVAR.gbllAñoMesFin.ToString();
                    //obtiene la rentabilidad 
                    Obtiene_Rentabilidad_Detalle();
                    //limpia variables 
                    Limpia_Variables();
                    //calcula totales 
                    Calcula_totales_Detalle(iNoRenglon);
                    //muestra titulos 
                    Llena_Titulo();

                    break;
            }

            CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = CORVB.NULL_STRING;

            //inhabilita el control de mensajes
            CORMDIBN.DefInstance.ID_COR_MSG_TXT.Visible = true;


            if (!mbAgrego)
            {
                MessageBox.Show("No hay registros a consultar.", Application.ProductName);
                //AIS-1182 NGONZALEZ
                iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
            }

            return result;
        }





        //****************************************************************************
        //**                                                                        **
        //**       Descripción:                                                     **
        //**                   asigna la rentabilidad maxima y minima a las variables **
        //**                                                                        **
        //**       Paso de parámetros: valor de rentabilidad obtenido               **
        //**                                                                        **
        //**       Valor de Regreso:                                                **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 26nov98                                     **
        //**                                                                        **
        //****************************************************************************
        //
        private void Renta_Max_Min(double dValor)
        {

            if (dValor == CORVB.NULL_INTEGER && dValor <= mdRentaMin)
            {
                mdRentaMin = dValor;
                bValMin = true;
            }
            else
            {
                if (mdRentaMax == CORVB.NULL_INTEGER && mdRentaMin == CORVB.NULL_INTEGER && dValor != CORVB.NULL_INTEGER)
                {
                    mdRentaMax = dValor;
                }

                if (dValor < mdRentaMax && mdRentaMin == CORVB.NULL_INTEGER)
                {
                    if (!bValMin)
                    {
                        mdRentaMin = dValor;
                    }
                }

                if (dValor < mdRentaMax && dValor < mdRentaMin)
                {
                    mdRentaMin = dValor;
                }

                if (dValor > mdRentaMax && dValor > mdRentaMin)
                {
                    if (mdRentaMax > mdRentaMin && mdRentaMin == CORVB.NULL_INTEGER && !bValMin)
                    {
                        mdRentaMin = mdRentaMax;
                    }
                    mdRentaMax = dValor;
                }
            }
        }

        private void cmdGraficar_Click(Object eventSender, EventArgs eventArgs)
        {
            //VB6.ShowForm(CORGRREN.DefInstance, (int) CORVB.MODAL, this);
            //AIS-1199 NGONZALEZ
            CORGRREN.DefInstance.ShowDialog(this);
        }

        private void cmdImprimir_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                CORPROC.Imprime_Reporte();
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(cmdImprimir_Click)", e);
            }

        }

        private void CORMNREN_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;
                CORVAR.igblFormaActiva = CORCONST.INT_ACT_REN;
                CORPROC.Cambia_StatusOpciones(-1);
            }
        }

        //UPGRADE_WARNING: (2065) Form event CORMNREN.Deactivate has a new behavior.
        private void CORMNREN_Deactivate(Object eventSender, EventArgs eventArgs)
        {
            //CORVAR.igblFormaActiva = CORVB.NULL_INTEGER;
            //CORPROC.Cambia_StatusOpciones(0);

        }


        private void CORMNREN_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == CORVB.KEY_ESCAPE)
            {
                this.Close();
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Top = (int)VB6.TwipsToPixelsY(1530);


            this.Cursor = Cursors.WaitCursor;

            CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = CORSTR.STR_LEE_BD;

            this.Cursor = Cursors.WaitCursor;

            //para verificar si agrego renglones
            mbAgrego = false;

            if (CORCTREN.DefInstance.Tag.ToString() == "Una" || CORCTREN.DefInstance.Tag.ToString() == "Detalle_Rango" || CORCTREN.DefInstance.Tag.ToString() == "Detalle")
            {
                if (CORCTREN.DefInstance.Tag.ToString() == "Detalle_Rango" || CORCTREN.DefInstance.Tag.ToString() == "Detalle")
                {
                    lblTitulo.Text = "Detalle de Rentabilidad de la Empresa ";
                }
                else
                {
                    lblTitulo.Text = "Rentabilidad para la Empresa a un rango de fechas. ";
                }
                if (CORCTREN.DefInstance.Tag.ToString() != "Detalle")
                {
                    lblFecFin.Visible = true;
                    lblFecFinR.Visible = true;
                }
                lblRentaMax.Visible = true;
                lblMaxResp.Visible = true;
                lblRentaMin.Visible = true;
                lblMinResp.Visible = true;
                lblTituloEmp.Visible = true;

            }
            else
            {
                switch (CORCTREN.DefInstance.Tag.ToString())
                {
                    case "Todas":
                        lblTitulo.Text = "Rentabilidad para todas las Empresas";
                        break;
                    case "Seleccion":
                        lblTitulo.Text = "Rentabilidad para las Empresas";
                        break;
                    case "Tope":
                        lblTitulo.Text = "Rentabilidad de la(s) " + Conversion.Str(CORCTREN.DefInstance.txtMaxima.Text) + " Empresas mas rentables";
                        break;
                }
                lblRentaMin.Visible = true;
                lblRentaMax.Visible = true;
                lblMinResp.Visible = true;
                lblMaxResp.Visible = true;
            }

            if (CORCTREN.DefInstance.Tag.ToString() == "Detalle" || CORCTREN.DefInstance.Tag.ToString() == "Detalle_Rango")
            {
                cmdGraficar.Visible = false;
            }

            //AIS-1609 FSABORIO
            //Rentabilidad();
            this.Cursor = Cursors.Default;

        }



        private void cmdSalir_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }




        private void CORMNREN_Closed(Object eventSender, EventArgs eventArgs)
        {
            CORPROC.Cambia_StatusOpciones(0);
            this.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        //AIS-1609 FSABORIO
        private bool CalculandoRentabilidad = false;
        private bool CerrarFormulario = false;
        private void CORMNREN_Shown(object sender, EventArgs e)
        {
            this.cmdImprimir.Enabled = false;
            this.cmdGraficar.Enabled = false;

            Application.DoEvents();
            CalculandoRentabilidad = true;
            Rentabilidad();
            CalculandoRentabilidad = false;

            this.cmdImprimir.Enabled = true;
            this.cmdGraficar.Enabled = true;
            if (CerrarFormulario)
                this.Close();
        }

        //AIS-1609 FSABORIO
        private void CORMNREN_FormClosing(object sender, FormClosingEventArgs e)
        {
            //AIS-1609 FSABORIO
            if (CalculandoRentabilidad)
            {
                e.Cancel = true;
                CerrarFormulario = true;
            }
        }


    }
}