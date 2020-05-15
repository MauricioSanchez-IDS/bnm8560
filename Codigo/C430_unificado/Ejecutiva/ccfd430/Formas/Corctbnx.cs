using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORCTBNX
        : System.Windows.Forms.Form
    {


        bool mbExisteReg = false;
        int iErr = 0;
        int iTop = 0;
        int iLeft = 0;
        int miNoUsuario = 0;
        int miNoRepAnt = 0;
        int mlAñoCorte = 0;
        int igblRetorna2 = 0;
        int lGpoBnx = 0;

        int hgblConexion3 = 0;
        string pszgblSql3 = String.Empty;
        int igblRetorna3 = 0;

        int intCont = 0;


        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Arma la fecha en letras                             **
        //**                                                                        **
        //**                                                                        **
        //**       Paso de parámetros recibe : icorte Fecha de corte                **
        //**                                                                        **
        //**       Valor de Regreso: fecha de corte en letra                        **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 22ene99                                     **
        //**                                                                        **
        //****************************************************************************
        private string Arma_Fecha_Texto(int iCorte)
        {
            string iMes = String.Empty;
            string sMesAnt = String.Empty;

            string smes = CORPROC.Obten_Mes(iCorte);
            int iPos = (smes.IndexOf(' ') + 1);
            smes = Strings.Mid(smes, iPos + 1);
            int lAñoAnt = mlAñoCorte;

            switch (smes)
            {
                case "Enero":
                    sMesAnt = "Dic";
                    lAñoAnt = mlAñoCorte - 1;
                    break;
                case "Febrero":
                    sMesAnt = "Ene";
                    break;
                case "Marzo":
                    sMesAnt = "Feb";
                    break;
                case "Abril":
                    sMesAnt = "Mar";
                    break;
                case "Mayo":
                    sMesAnt = "Abr";
                    break;
                case "Junio":
                    sMesAnt = "May";
                    break;
                case "Julio":
                    sMesAnt = "Jun";
                    break;
                case "Agosto":
                    sMesAnt = "Jul";
                    break;
                case "Septiembre":
                    sMesAnt = "Ago";
                    break;
                case "Octubre":
                    sMesAnt = "Sep";
                    break;
                case "Noviembre":
                    sMesAnt = "Oct";
                    break;
                case "Diciembre":
                    sMesAnt = "Nov";
                    break;
            }

            switch (smes)
            {
                case "Enero":
                    smes = "Ene";
                    break;
                case "Febrero":
                    smes = "Feb";
                    break;
                case "Marzo":
                    smes = "Mar";
                    break;
                case "Abril":
                    smes = "Abr";
                    break;
                case "Mayo":
                    smes = "May";
                    break;
                case "Junio":
                    smes = "Jun";
                    break;
                case "Julio":
                    smes = "Jul";
                    break;
                case "Agosto":
                    smes = "Ago";
                    break;
                case "Septiembre":
                    smes = "Sep";
                    break;
                case "Octubre":
                    smes = "Oct";
                    break;
                case "Noviembre":
                    smes = "Nov";
                    break;
                case "Diciembre":
                    smes = "Dic";
                    break;
            }

            //obtiene el dia de corte
            string iFecCor = StringsHelper.Format(Conversion.Str(iCorte), "0000");
            int iDia = StringsHelper.IntValue(Strings.Mid(iFecCor.Trim(), 3, 2));
            string sTextFecha = Conversion.Str(iDia + 1) + " " + sMesAnt + " " + Conversion.Str(lAñoAnt) + " al " + Conversion.Str(iDia) + " " + smes + " " + Conversion.Str(mlAñoCorte);

            return sTextFecha;

        }

        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Selecciona el stored dependiendo de la opción       **
        //**                                                                        **
        //**                                                                        **
        //**       Paso de parámetros: numero de usuario                            **
        //**                           numero de reporte                            **
        //**                           fecha de corte, tipo de reporte              **
        //**       Valor de Regreso:                                                **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 22ene99                                     **
        //**                                                                        **
        //****************************************************************************
        private void Asigna_Reporte(int iNoUsuario, ref  int iNoRep, int iFecCorte, int iTipo)
        {
            string sNomRep = String.Empty;
            int lContador = 0;
            string sTipo = String.Empty;

            //arma la fecha de texto
            string sFecText = Arma_Fecha_Texto(iFecCorte);

            int lNumeroPro = CORVB.NULL_INTEGER;

            //verifica que el identificador no esteen ceros
            if (Double.Parse(txtIdentificador.Text) == CORVB.NULL_INTEGER)
            {
                if (iTipo == CORVB.NULL_INTEGER)
                { //General
                    sTipo = "General";
                }
                else
                {
                    sTipo = "Individual";
                }
                //obtiene el numero del proceso
                lNumeroPro = Convert.ToInt32(Conversion.Val(cboGrupo.Text.Substring(0, Math.Min(cboGrupo.Text.Length, 6))));

                if (lNumeroPro == CORVB.NULL_INTEGER)
                {
                    MessageBox.Show("No hay seleccionado ningún registro", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            else
            {
                lNumeroPro = Int32.Parse(txtIdentificador.Text);

                if (iTipo == CORVB.NULL_INTEGER)
                { //General
                    sTipo = "General";
                }
                else
                {
                    sTipo = "Individual";
                }
            }

            switch (iNoRep)
            {
                case 1:  //banco 
                    CORVAR.pszgblsql = "Exec spS_Banamex_BCO " + iFecCorte.ToString() + "," + lNumeroPro.ToString() + "," + iNoUsuario.ToString() + "," + iNoRep.ToString() + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();
                    //nombre del reporte 
                    if (iTipo == CORVB.NULL_INTEGER)
                    { //General
                        sNomRep = "Bnx_BCO_G.rpt";
                    }
                    else
                    {
                        sNomRep = "Bnx_BCO_I.rpt";
                    }


                    break;
                case 2:  //area 
                    CORVAR.pszgblsql = "Exec spS_Banamex_Area " + iFecCorte.ToString() + "," + lNumeroPro.ToString() + "," + iNoUsuario.ToString() + "," + iNoRep.ToString() + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();

                    //nombre del reporte 
                    if (iTipo == CORVB.NULL_INTEGER)
                    { //General
                        sNomRep = "Bnx_DGA_G.rpt";
                    }
                    else
                    {
                        sNomRep = "Bnx_DGA_I.rpt";
                    }

                    //inserta en la tabla de MTCRPB01 
                    //     Call Procesa_Reporte(miNoUsuario, iNoRep, pszgblSql) 

                    break;
                case 3:  //division 
                    CORVAR.pszgblsql = "Exec spS_Banamex_Division " + iFecCorte.ToString() + "," + lNumeroPro.ToString() + "," + iNoUsuario.ToString() + "," + iNoRep.ToString() + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();
                    //nombre del reporte 
                    if (iTipo == CORVB.NULL_INTEGER)
                    { //General
                        sNomRep = "Bnx_DIV_G.rpt";
                    }
                    else
                    {
                        sNomRep = "Bnx_DIV_I.rpt";
                    }

                    //inserta en la tabla de MTCRPB01 
                    //       Call Procesa_Reporte(miNoUsuario, iNoRep, pszgblSql) 

                    break;
                case 4:  //subdireccion 
                    CORVAR.pszgblsql = "Exec spS_Banamex_Subdivision " + iFecCorte.ToString() + "," + lNumeroPro.ToString() + "," + iNoUsuario.ToString() + "," + iNoRep.ToString() + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();
                    //nombre del reporte 

                    if (iTipo == CORVB.NULL_INTEGER)
                    { //General
                        sNomRep = "Bnx_SUB_G.rpt";
                    }
                    else
                    {
                        sNomRep = "Bnx_SUB_I.rpt";
                    }

                    //inserta en la tabla de MTCRPB01 
                    //        Call Procesa_Reporte(miNoUsuario, iNoRep, pszgblSql) 

                    break;
                case 5:  //sirh 
                    CORVAR.pszgblsql = "Exec spS_Banamex_SIRH " + iFecCorte.ToString() + "," + lNumeroPro.ToString() + "," + iNoUsuario.ToString() + "," + iNoRep.ToString() + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();
                    //nombre del reporte 
                    if (iTipo == CORVB.NULL_INTEGER)
                    { //General
                        sNomRep = "Bnx_SIR_G.rpt";
                    }
                    else
                    {
                        sNomRep = "Bnx_SIR_I.rpt";
                    }

                    break;
            }

            //inserta en la tabla de MTCRPB01
            Procesa_Reporte(miNoUsuario, iNoRep, ref CORVAR.pszgblsql);


            //si existen registros llena el reporte
            if (mbExisteReg)
            {
                //llama crystal report
                Genera_Reporte_Crystal(sNomRep, iNoRep);
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("No hay registros para el reporte", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }



        private void Llena_spread(string sQuery, int iReporte)
        {
            int lDga = 0;
            int lDiv = 0;
            int lSub = 0;
            int lSirh = 0;
            int lColumna = 0;

            CORVAR.pszgblsql = sQuery;


            vspDatos.MaxRows = 1;
            int lRow = 1;
            switch (iReporte)
            {
                case 1:  //banco 
                    vspDatos.MaxCols = 4;
                    lColumna = 1;
                    break;
                case 2:  //area 
                    vspDatos.MaxCols = 3;
                    lColumna = 1;
                    break;
                case 3:  //division 
                    vspDatos.MaxCols = 2;
                    lColumna = 1;
                    break;
                case 4:  //subdivision 
                    vspDatos.MaxCols = 1;
                    lColumna = 1;


                    break;
            }

            if (CORPROC2.Obtiene_Registros() != 0)
            {

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {

                    switch (iReporte)
                    {
                        case 1:  //banco 
                            vspDatos.Row = vspDatos.MaxRows;

                            lDga = CORVB.NULL_INTEGER;
                            lDiv = CORVB.NULL_INTEGER;
                            lSub = CORVB.NULL_INTEGER;
                            lSirh = CORVB.NULL_INTEGER;

                            lDga = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                            lDiv = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
                            lSub = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));
                            lSirh = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4)));

                            vspDatos.Col = 1;
                            vspDatos.CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                            vspDatos.Text = lDga.ToString();
                            vspDatos.Col = 2;
                            vspDatos.CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                            vspDatos.Text = lDiv.ToString();
                            vspDatos.Col = 3;
                            vspDatos.CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                            vspDatos.Text = lSub.ToString();
                            vspDatos.Col = 4;
                            vspDatos.CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                            vspDatos.Text = lSirh.ToString();

                            lRow++;
                            vspDatos.MaxRows = lRow;

                            break;
                        case 2:  //area 

                            vspDatos.Row = vspDatos.MaxRows;

                            lDiv = CORVB.NULL_INTEGER;
                            lSub = CORVB.NULL_INTEGER;
                            lSirh = CORVB.NULL_INTEGER;

                            lDiv = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                            lSub = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
                            lSirh = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));

                            vspDatos.Col = 1;
                            vspDatos.CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                            vspDatos.Text = lDiv.ToString();
                            vspDatos.Col = 2;
                            vspDatos.CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                            vspDatos.Text = lSub.ToString();
                            vspDatos.Col = 3;
                            vspDatos.CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                            vspDatos.Text = lSirh.ToString();

                            lRow++;
                            vspDatos.MaxRows = lRow;

                            break;
                        case 3:  //division 

                            vspDatos.Row = vspDatos.MaxRows;

                            lSub = CORVB.NULL_INTEGER;
                            lSirh = CORVB.NULL_INTEGER;

                            lSub = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                            lSirh = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));

                            vspDatos.Col = 1;
                            vspDatos.CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                            vspDatos.Text = lSub.ToString();
                            vspDatos.Col = 2;
                            vspDatos.CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                            vspDatos.Text = lSirh.ToString();

                            lRow++;
                            vspDatos.MaxRows = lRow;
                            break;
                        case 4:  //subdivision 

                            vspDatos.Row = vspDatos.MaxRows;

                            lSirh = CORVB.NULL_INTEGER;

                            lSirh = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));

                            vspDatos.Col = 1;
                            vspDatos.CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                            vspDatos.Text = lSirh.ToString();

                            lRow++;
                            vspDatos.MaxRows = lRow;


                            break;
                    }
                };
                vspDatos.MaxRows = lRow - 1;

            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

        }

        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Imprime los reportes desde el nivel donde se        **
        //**                   hasta el ultimo nivel
        //**                                                                        **
        //**                                                                        **
        //**       Paso de parámetros: numero de usuario                            **
        //**                           numero de reporte                            **
        //**                           fecha de corte, tipo de reporte              **
        //**       Valor de Regreso:                                                **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 22ene99                                     **
        //**                                                                        **
        //****************************************************************************
        private void Seleccion_General(int iNoUsuario, ref  int iNoRep, int iFecCorte, int iTipo)
        {
            string sNomRep = String.Empty;
            string sTipo = String.Empty;
            int lSigValor = 0;
            int lDivisonAnt = 0;
            int lSubdivAnt = 0;
            int lSirhAnt = 0;
            int lDivison = 0;
            int lSubdiv = 0;
            int lSirh = 0;
            bool bBandera = false;
            int lPos = 0;
            int lPosIni = 0;
            int lDgaAnt = 0;
            int lDga = 0;


            this.Cursor = Cursors.WaitCursor;

            //arma la fecha de texto
            string sFecText = Arma_Fecha_Texto(iFecCorte);

            int lNumeroPro = CORVB.NULL_INTEGER;

            //verifica que el identificador no esteen ceros
            if (Double.Parse(txtIdentificador.Text) == CORVB.NULL_INTEGER)
            {
                if (iTipo == CORVB.NULL_INTEGER)
                { //General
                    sTipo = "General";
                }
                else
                {
                    sTipo = "Individual";
                }
                //obtiene el numero del proceso
                lNumeroPro = Convert.ToInt32(Conversion.Val(cboGrupo.Text.Substring(0, Math.Min(cboGrupo.Text.Length, 6))));

                if (lNumeroPro == CORVB.NULL_INTEGER)
                {
                    MessageBox.Show("No hay seleccionado ningún registro", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                    return;
                }
            }
            else
            {
                lNumeroPro = Int32.Parse(txtIdentificador.Text);

                if (iTipo == CORVB.NULL_INTEGER)
                { //General
                    sTipo = "General";
                }
                else
                {
                    sTipo = "Individual";
                }
            }



            switch (iNoRep)
            {
                case 1:  //banco 

                    CORVAR.pszgblsql = "Exec spS_Banamex_BCO " + iFecCorte.ToString() + "," + lNumeroPro.ToString() + "," + iNoUsuario.ToString() + "," + iNoRep.ToString() + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();
                    //nombre del reporte 
                    if (iTipo == CORVB.NULL_INTEGER)
                    { //General
                        sNomRep = "Bnx_BCO_G.rpt";
                    }
                    else
                    {
                        sNomRep = "Bnx_BCO_I.rpt";
                    }

                    //inserta en la tabla de MTCRPB01 
                    Procesa_Reporte(miNoUsuario, iNoRep, ref CORVAR.pszgblsql);

                    //si existen registros llena el reporte 
                    if (mbExisteReg)
                    {
                        //llama crystal report
                        Genera_Reporte_Crystal(sNomRep, iNoRep);
                        Borra_No_Usuario(iNoRep);
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("No hay registros para el reporte", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //vacia la informacion al spread 
                    CORVAR.pszgblsql = "SELECT bnx_id_dga, bnx_id_division, bnx_id_subdivision, bnx_id_unicas ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " FROM MTCBNX01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE bnx_id_dga  <> 0 ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " AND bnx_id_unicas <> 0 ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " GROUP BY bnx_id_dga,bnx_id_division, bnx_id_subdivision, bnx_id_unicas ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " ORDER BY  bnx_id_dga,bnx_id_division, bnx_id_subdivision, bnx_id_unicas ";
                    //llena en el spread 
                    Llena_spread(CORVAR.pszgblsql, iNoRep);

                    // lee las columnas del spread por renglones 
                    lDgaAnt = CORVB.NULL_INTEGER;
                    lDivisonAnt = CORVB.NULL_INTEGER;
                    lSubdivAnt = CORVB.NULL_INTEGER;
                    lSirhAnt = CORVB.NULL_INTEGER;
                    bBandera = false;
                    for (int lRenglon = 1; lRenglon <= vspDatos.MaxRows; lRenglon++)
                    {

                        //guarda la posicion
                        lPos = lRenglon;

                        vspDatos.Row = lRenglon;

                        vspDatos.Col = 1; //dag
                        lDga = Convert.ToInt32(Conversion.Val(vspDatos.Text));
                        vspDatos.Col = 2; //division
                        lDivison = Convert.ToInt32(Conversion.Val(vspDatos.Text));
                        vspDatos.Col = 3; //subdivion
                        lSubdiv = Convert.ToInt32(Conversion.Val(vspDatos.Text));
                        vspDatos.Col = 4; //sirh
                        lSirh = Convert.ToInt32(Conversion.Val(vspDatos.Text));

                        if (!bBandera)
                        {

                            //asigna valores por vez primera
                            lDgaAnt = lDga;
                            lDivisonAnt = lDivison;
                            lSubdivAnt = lSubdiv;
                            lSirhAnt = lSirh;

                            bBandera = true;

                            //genera el reporte por dga
                            CORVAR.pszgblsql = "Exec spS_Banamex_Area " + iFecCorte.ToString() + "," + lDga.ToString() + "," + iNoUsuario.ToString() + "," + "2" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();
                            //nombre del reporte
                            if (iTipo == CORVB.NULL_INTEGER)
                            { //General
                                sNomRep = "Bnx_DGA_G.rpt";
                            }
                            else
                            {
                                sNomRep = "Bnx_DGA_I.rpt";
                            }

                            //inserta en la tabla de MTCRPB01
                            Procesa_Reporte(miNoUsuario, 2, ref CORVAR.pszgblsql);

                            //si existen registros llena el reporte
                            if (mbExisteReg)
                            {
                                //llama crystal report
                                Genera_Reporte_Crystal(sNomRep, 2);
                                Borra_No_Usuario(2);
                            }
                            else
                            {
                                Borra_No_Usuario(2);
                            }

                            if (lDivison != 0)
                            {
                                //genera el reporte de divisones
                                CORVAR.pszgblsql = "Exec spS_Banamex_Division " + iFecCorte.ToString() + "," + lDivison.ToString() + "," + iNoUsuario.ToString() + "," + "3" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();

                                if (iTipo == CORVB.NULL_INTEGER)
                                { //General
                                    sNomRep = "Bnx_DIV_G.rpt";
                                }
                                else
                                {
                                    sNomRep = "Bnx_DIV_I.rpt";
                                }

                                //inserta en la tabla de MTCRPB01
                                Procesa_Reporte(miNoUsuario, 3, ref CORVAR.pszgblsql);

                                //si existen registros llena el reporte
                                if (mbExisteReg)
                                {
                                    //llama crystal report
                                    Genera_Reporte_Crystal(sNomRep, 3);
                                    Borra_No_Usuario(3);
                                }
                                else
                                {
                                    Borra_No_Usuario(3);
                                }
                            }

                            if (lSubdiv != 0)
                            {
                                //genera el reporte por subdiviones
                                CORVAR.pszgblsql = "Exec spS_Banamex_Subdivision " + iFecCorte.ToString() + "," + lSubdiv.ToString() + "," + iNoUsuario.ToString() + "," + "4" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();

                                //nombre del reporte
                                if (iTipo == CORVB.NULL_INTEGER)
                                { //General
                                    sNomRep = "Bnx_SUB_G.rpt";
                                }
                                else
                                {
                                    sNomRep = "Bnx_SUB_I.rpt";
                                }

                                //inserta en la tabla de MTCRPB01
                                Procesa_Reporte(miNoUsuario, 4, ref CORVAR.pszgblsql);

                                //si existen registros llena el reporte
                                if (mbExisteReg)
                                {
                                    //llama crystal report
                                    Genera_Reporte_Crystal(sNomRep, 4);
                                    Borra_No_Usuario(4);
                                }
                                else
                                {
                                    Borra_No_Usuario(4);
                                }

                            }
                            lPosIni = lRenglon;

                            if (lSirh != 0)
                            {
                                //genera el reporte por sirh
                                CORVAR.pszgblsql = "Exec spS_Banamex_SIRH " + iFecCorte.ToString() + "," + lSirh.ToString() + "," + iNoUsuario.ToString() + "," + "5" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();

                                //nombre del reporte
                                if (iTipo == CORVB.NULL_INTEGER)
                                { //General
                                    sNomRep = "Bnx_SIR_G.rpt";
                                }
                                else
                                {
                                    sNomRep = "Bnx_SIR_I.rpt";
                                }

                                //inserta en la tabla de MTCRPB01
                                Procesa_Reporte(miNoUsuario, 5, ref CORVAR.pszgblsql);

                                //si existen registros llena el reporte
                                if (mbExisteReg)
                                {
                                    //llama crystal report
                                    Genera_Reporte_Crystal(sNomRep, 5);
                                    Borra_No_Usuario(5);

                                }

                            }

                        }
                        else
                        {
                            //bandera es verdadrea

                            //genera el reporte por dga
                            if (lDgaAnt != lDga)
                            {
                                lDgaAnt = lDga;
                                CORVAR.pszgblsql = "Exec spS_Banamex_Area " + iFecCorte.ToString() + "," + lDga.ToString() + "," + iNoUsuario.ToString() + "," + "2" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();
                                //nombre del reporte
                                if (iTipo == CORVB.NULL_INTEGER)
                                { //General
                                    sNomRep = "Bnx_DGA_G.rpt";
                                }
                                else
                                {
                                    sNomRep = "Bnx_DGA_I.rpt";
                                }

                                //inserta en la tabla de MTCRPB01
                                Procesa_Reporte(miNoUsuario, 2, ref CORVAR.pszgblsql);

                                //si existen registros llena el reporte
                                if (mbExisteReg)
                                {
                                    //llama crystal report
                                    Genera_Reporte_Crystal(sNomRep, 2);
                                    Borra_No_Usuario(2);
                                }
                                else
                                {
                                    Borra_No_Usuario(2);
                                }
                            }

                            if (lDivison != 0)
                            {
                                if (lDivisonAnt != lDivison)
                                {
                                    lDivisonAnt = lDivison;
                                    //genera el reporte de divisiones
                                    CORVAR.pszgblsql = "Exec spS_Banamex_Division " + iFecCorte.ToString() + "," + lDivison.ToString() + "," + iNoUsuario.ToString() + "," + "3" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();

                                    if (iTipo == CORVB.NULL_INTEGER)
                                    { //General
                                        sNomRep = "Bnx_DIV_G.rpt";
                                    }
                                    else
                                    {
                                        sNomRep = "Bnx_DIV_I.rpt";
                                    }

                                    //inserta en la tabla de MTCRPB01
                                    Procesa_Reporte(miNoUsuario, 3, ref CORVAR.pszgblsql);

                                    //si existen registros llena el reporte
                                    if (mbExisteReg)
                                    {
                                        //llama crystal report
                                        Genera_Reporte_Crystal(sNomRep, 3);
                                        Borra_No_Usuario(3);
                                    }
                                    else
                                    {
                                        Borra_No_Usuario(3);
                                    }

                                }
                            }

                            if (lSubdiv != 0)
                            {
                                if (lSubdivAnt != lSubdiv)
                                {

                                    //imprime los sirh de esa subdivision
                                    for (int lContador = lPosIni; lContador <= lPos - 1; lContador++)
                                    {
                                        vspDatos.Row = lContador;
                                        vspDatos.Col = 4; //sirh
                                        lSirh = Convert.ToInt32(Conversion.Val(vspDatos.Text));

                                        //genera el reporte por sirh
                                        CORVAR.pszgblsql = "Exec spS_Banamex_SIRH " + iFecCorte.ToString() + "," + lSirh.ToString() + "," + iNoUsuario.ToString() + "," + "5" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();

                                        //nombre del reporte
                                        if (iTipo == CORVB.NULL_INTEGER)
                                        { //General
                                            sNomRep = "Bnx_SIR_G.rpt";
                                        }
                                        else
                                        {
                                            sNomRep = "Bnx_SIR_I.rpt";
                                        }

                                        //inserta en la tabla de MTCRPB01
                                        Procesa_Reporte(miNoUsuario, 5, ref CORVAR.pszgblsql);

                                        //si existen registros llena el reporte
                                        if (mbExisteReg)
                                        {
                                            //llama crystal report
                                            Genera_Reporte_Crystal(sNomRep, 5);
                                            Borra_No_Usuario(5);
                                        }
                                        else
                                        {
                                            Borra_No_Usuario(5);
                                        }
                                    }

                                    lSubdivAnt = lSubdiv;
                                    //genera el reporte por subdiviones
                                    CORVAR.pszgblsql = "Exec spS_Banamex_Subdivision " + iFecCorte.ToString() + "," + lSubdiv.ToString() + "," + iNoUsuario.ToString() + "," + "4" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();

                                    //nombre del reporte
                                    if (iTipo == CORVB.NULL_INTEGER)
                                    { //General
                                        sNomRep = "Bnx_SUB_G.rpt";
                                    }
                                    else
                                    {
                                        sNomRep = "Bnx_SUB_I.rpt";
                                    }

                                    //inserta en la tabla de MTCRPB01
                                    Procesa_Reporte(miNoUsuario, 4, ref CORVAR.pszgblsql);

                                    //si existen registros llena el reporte
                                    if (mbExisteReg)
                                    {
                                        //llama crystal report
                                        Genera_Reporte_Crystal(sNomRep, 4);
                                        Borra_No_Usuario(4);
                                    }
                                    else
                                    {
                                        Borra_No_Usuario(4);
                                    }
                                    lPosIni = lRenglon;
                                }
                            }
                            else
                            {
                                lPosIni = lRenglon;
                            }
                        }
                    }

                    ////////////////////////////////////////// 

                    break;
                case 2:  //area 

                    CORVAR.pszgblsql = "Exec spS_Banamex_Area " + iFecCorte.ToString() + "," + lNumeroPro.ToString() + "," + iNoUsuario.ToString() + "," + iNoRep.ToString() + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();
                    //nombre del reporte 
                    if (iTipo == CORVB.NULL_INTEGER)
                    { //General
                        sNomRep = "Bnx_DGA_G.rpt";
                    }
                    else
                    {
                        sNomRep = "Bnx_DGA_I.rpt";
                    }

                    //inserta en la tabla de MTCRPB01 
                    Procesa_Reporte(miNoUsuario, iNoRep, ref CORVAR.pszgblsql);

                    //si existen registros llena el reporte 
                    if (mbExisteReg)
                    {
                        //llama crystal report
                        Genera_Reporte_Crystal(sNomRep, iNoRep);
                        Borra_No_Usuario(iNoRep);
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("No hay registros para el reporte", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //vacia la informacion al spread 
                    CORVAR.pszgblsql = "SELECT bnx_id_division, bnx_id_subdivision, bnx_id_unicas ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " FROM MTCBNX01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE bnx_id_dga = " + lNumeroPro.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " AND bnx_id_unicas <> 0 ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " GROUP BY bnx_id_division, bnx_id_subdivision, bnx_id_unicas ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " ORDER BY bnx_id_division, bnx_id_subdivision, bnx_id_unicas ";
                    //llena en el spread 
                    Llena_spread(CORVAR.pszgblsql, iNoRep);

                    // lee las columnas del spread por renglones 
                    lDivisonAnt = CORVB.NULL_INTEGER;
                    lSubdivAnt = CORVB.NULL_INTEGER;
                    lSirhAnt = CORVB.NULL_INTEGER;
                    bBandera = false;
                    for (int lRenglon = 1; lRenglon <= vspDatos.MaxRows; lRenglon++)
                    {

                        //guarda la posicion
                        lPos = lRenglon;

                        vspDatos.Row = lRenglon;

                        vspDatos.Col = 1; //divison
                        lDivison = Convert.ToInt32(Conversion.Val(vspDatos.Text));
                        vspDatos.Col = 2; //subdivion
                        lSubdiv = Convert.ToInt32(Conversion.Val(vspDatos.Text));
                        vspDatos.Col = 3; //sirh
                        lSirh = Convert.ToInt32(Conversion.Val(vspDatos.Text));

                        if (!bBandera)
                        {
                            //asigna valores por vez primera
                            lDivisonAnt = lDivison;
                            lSubdivAnt = lSubdiv;
                            lSirhAnt = lSirh;

                            bBandera = true;

                            if (lDivison != 0)
                            {
                                //genera el reporte de divisones
                                CORVAR.pszgblsql = "Exec spS_Banamex_Division " + iFecCorte.ToString() + "," + lDivison.ToString() + "," + iNoUsuario.ToString() + "," + "3" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();

                                if (iTipo == CORVB.NULL_INTEGER)
                                { //General
                                    sNomRep = "Bnx_DIV_G.rpt";
                                }
                                else
                                {
                                    sNomRep = "Bnx_DIV_I.rpt";
                                }

                                //inserta en la tabla de MTCRPB01
                                Procesa_Reporte(miNoUsuario, 3, ref CORVAR.pszgblsql);

                                //si existen registros llena el reporte
                                if (mbExisteReg)
                                {
                                    //llama crystal report
                                    Genera_Reporte_Crystal(sNomRep, 3);
                                    Borra_No_Usuario(3);
                                }
                            }

                            if (lSubdiv != 0)
                            {
                                //genera el reporte por subdiviones
                                CORVAR.pszgblsql = "Exec spS_Banamex_Subdivision " + iFecCorte.ToString() + "," + lSubdiv.ToString() + "," + iNoUsuario.ToString() + "," + "4" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();

                                //nombre del reporte
                                if (iTipo == CORVB.NULL_INTEGER)
                                { //General
                                    sNomRep = "Bnx_SUB_G.rpt";
                                }
                                else
                                {
                                    sNomRep = "Bnx_SUB_I.rpt";
                                }

                                //inserta en la tabla de MTCRPB01
                                Procesa_Reporte(miNoUsuario, 4, ref CORVAR.pszgblsql);

                                //si existen registros llena el reporte
                                if (mbExisteReg)
                                {
                                    //llama crystal report
                                    Genera_Reporte_Crystal(sNomRep, 4);
                                    Borra_No_Usuario(4);
                                }

                            }
                            lPosIni = lRenglon;

                            if (lSirh != 0)
                            {
                                //genera el reporte por sirh
                                CORVAR.pszgblsql = "Exec spS_Banamex_SIRH " + iFecCorte.ToString() + "," + lSirh.ToString() + "," + iNoUsuario.ToString() + "," + "5" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();

                                //nombre del reporte
                                if (iTipo == CORVB.NULL_INTEGER)
                                { //General
                                    sNomRep = "Bnx_SIR_G.rpt";
                                }
                                else
                                {
                                    sNomRep = "Bnx_SIR_I.rpt";
                                }

                                //inserta en la tabla de MTCRPB01
                                Procesa_Reporte(miNoUsuario, 5, ref CORVAR.pszgblsql);

                                //si existen registros llena el reporte
                                if (mbExisteReg)
                                {
                                    //llama crystal report
                                    Genera_Reporte_Crystal(sNomRep, 5);
                                    Borra_No_Usuario(5);
                                }
                            }
                        }
                        else
                        {
                            //bandera es verdadrea
                            if (lDivison != 0)
                            {
                                if (lDivisonAnt != lDivison)
                                {
                                    lDivisonAnt = lDivison;
                                    //genera el reporte de divisiones
                                    CORVAR.pszgblsql = "Exec spS_Banamex_Division " + iFecCorte.ToString() + "," + lDivison.ToString() + "," + iNoUsuario.ToString() + "," + "3" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();

                                    if (iTipo == CORVB.NULL_INTEGER)
                                    { //General
                                        sNomRep = "Bnx_DIV_G.rpt";
                                    }
                                    else
                                    {
                                        sNomRep = "Bnx_DIV_I.rpt";
                                    }

                                    //inserta en la tabla de MTCRPB01
                                    Procesa_Reporte(miNoUsuario, 3, ref CORVAR.pszgblsql);

                                    //si existen registros llena el reporte
                                    if (mbExisteReg)
                                    {
                                        //llama crystal report
                                        Genera_Reporte_Crystal(sNomRep, 3);
                                        Borra_No_Usuario(3);
                                    }

                                }
                            }

                            if (lSubdiv != 0)
                            {
                                if (lSubdivAnt != lSubdiv)
                                {

                                    //imprime los sirh de esa subdivision
                                    for (int lContador = lPosIni; lContador <= lPos - 1; lContador++)
                                    {
                                        vspDatos.Row = lContador;
                                        vspDatos.Col = 3; //sirh
                                        lSirh = Convert.ToInt32(Conversion.Val(vspDatos.Text));

                                        //genera el reporte por sirh
                                        CORVAR.pszgblsql = "Exec spS_Banamex_SIRH " + iFecCorte.ToString() + "," + lSirh.ToString() + "," + iNoUsuario.ToString() + "," + "5" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();

                                        //nombre del reporte
                                        if (iTipo == CORVB.NULL_INTEGER)
                                        { //General
                                            sNomRep = "Bnx_SIR_G.rpt";
                                        }
                                        else
                                        {
                                            sNomRep = "Bnx_SIR_I.rpt";
                                        }

                                        //inserta en la tabla de MTCRPB01
                                        Procesa_Reporte(miNoUsuario, 5, ref CORVAR.pszgblsql);

                                        //si existen registros llena el reporte
                                        if (mbExisteReg)
                                        {
                                            //llama crystal report
                                            Genera_Reporte_Crystal(sNomRep, 5);
                                            Borra_No_Usuario(5);
                                        }
                                    }

                                    lSubdivAnt = lSubdiv;
                                    //genera el reporte por subdiviones
                                    CORVAR.pszgblsql = "Exec spS_Banamex_Subdivision " + iFecCorte.ToString() + "," + lSubdiv.ToString() + "," + iNoUsuario.ToString() + "," + "4" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();

                                    //nombre del reporte
                                    if (iTipo == CORVB.NULL_INTEGER)
                                    { //General
                                        sNomRep = "Bnx_SUB_G.rpt";
                                    }
                                    else
                                    {
                                        sNomRep = "Bnx_SUB_I.rpt";
                                    }

                                    //inserta en la tabla de MTCRPB01
                                    Procesa_Reporte(miNoUsuario, 4, ref CORVAR.pszgblsql);

                                    //si existen registros llena el reporte
                                    if (mbExisteReg)
                                    {
                                        //llama crystal report
                                        Genera_Reporte_Crystal(sNomRep, 4);
                                        Borra_No_Usuario(4);
                                    }
                                    lPosIni = lRenglon;
                                }
                            }
                            else
                            {
                                lPosIni = lRenglon;
                            }
                        }
                    }

                    ////////////////////////////////////////// 

                    break;
                case 3:  //division 
                    CORVAR.pszgblsql = "Exec spS_Banamex_Division " + iFecCorte.ToString() + "," + lNumeroPro.ToString() + "," + iNoUsuario.ToString() + "," + iNoRep.ToString() + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();
                    //nombre del reporte 
                    if (iTipo == CORVB.NULL_INTEGER)
                    { //General
                        sNomRep = "Bnx_DIV_G.rpt";
                    }
                    else
                    {
                        sNomRep = "Bnx_DIV_I.rpt";
                    }

                    //inserta en la tabla de MTCRPB01 
                    Procesa_Reporte(miNoUsuario, iNoRep, ref CORVAR.pszgblsql);

                    //si existen registros llena el reporte 
                    if (mbExisteReg)
                    {

                        //llama crystal report
                        Genera_Reporte_Crystal(sNomRep, iNoRep);
                        Borra_No_Usuario(iNoRep);
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("No hay registros para el reporte", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //vacia la informacion al spread 
                    CORVAR.pszgblsql = "SELECT  bnx_id_subdivision, bnx_id_unicas ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " FROM MTCBNX01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE bnx_id_division = " + lNumeroPro.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " AND bnx_id_unicas <> 0 ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " GROUP BY bnx_id_subdivision, bnx_id_unicas ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " ORDER BY bnx_id_subdivision, bnx_id_unicas ";

                    //llena en el spread 
                    Llena_spread(CORVAR.pszgblsql, iNoRep);

                    // lee las columnas del spread por renglones 
                    lSubdivAnt = CORVB.NULL_INTEGER;
                    lSirhAnt = CORVB.NULL_INTEGER;
                    bBandera = false;
                    for (int lRenglon = 1; lRenglon <= vspDatos.MaxRows; lRenglon++)
                    {

                        //guarda la posicion
                        lPos = lRenglon;

                        vspDatos.Row = lRenglon;

                        vspDatos.Col = 1; //subdivion
                        lSubdiv = Convert.ToInt32(Conversion.Val(vspDatos.Text));
                        vspDatos.Col = 2; //sirh
                        lSirh = Convert.ToInt32(Conversion.Val(vspDatos.Text));

                        if (!bBandera)
                        {
                            //asigna valores por vez primera

                            lSubdivAnt = lSubdiv;
                            lSirhAnt = lSirh;

                            bBandera = true;

                            if (lSubdiv != 0)
                            {
                                //genera el reporte por subdiviones
                                CORVAR.pszgblsql = "Exec spS_Banamex_Subdivision " + iFecCorte.ToString() + "," + lSubdiv.ToString() + "," + iNoUsuario.ToString() + "," + "4" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();

                                //nombre del reporte
                                if (iTipo == CORVB.NULL_INTEGER)
                                { //General
                                    sNomRep = "Bnx_SUB_G.rpt";
                                }
                                else
                                {
                                    sNomRep = "Bnx_SUB_I.rpt";
                                }

                                //inserta en la tabla de MTCRPB01
                                Procesa_Reporte(miNoUsuario, 4, ref CORVAR.pszgblsql);

                                //si existen registros llena el reporte
                                if (mbExisteReg)
                                {
                                    //llama crystal report
                                    Genera_Reporte_Crystal(sNomRep, 4);
                                    Borra_No_Usuario(4);
                                }

                            }
                            lPosIni = lRenglon;

                            if (lSirh != 0)
                            {
                                //genera el reporte por sirh
                                CORVAR.pszgblsql = "Exec spS_Banamex_SIRH " + iFecCorte.ToString() + "," + lSirh.ToString() + "," + iNoUsuario.ToString() + "," + "5" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();

                                //nombre del reporte
                                if (iTipo == CORVB.NULL_INTEGER)
                                { //General
                                    sNomRep = "Bnx_SIR_G.rpt";
                                }
                                else
                                {
                                    sNomRep = "Bnx_SIR_I.rpt";
                                }

                                //inserta en la tabla de MTCRPB01
                                Procesa_Reporte(miNoUsuario, 5, ref CORVAR.pszgblsql);

                                //si existen registros llena el reporte
                                if (mbExisteReg)
                                {
                                    //llama crystal report
                                    Genera_Reporte_Crystal(sNomRep, 5);
                                    Borra_No_Usuario(5);
                                }
                            }

                        }
                        else
                        {
                            //bandera es verdadrea

                            if (lSubdiv != 0)
                            {
                                if (lSubdivAnt != lSubdiv)
                                {

                                    //imprime los sirh de esa subdivision
                                    for (int lContador = lPosIni; lContador <= lPos - 1; lContador++)
                                    {
                                        vspDatos.Row = lContador;
                                        vspDatos.Col = 2; //sirh
                                        lSirh = Convert.ToInt32(Conversion.Val(vspDatos.Text));

                                        //genera el reporte por sirh
                                        CORVAR.pszgblsql = "Exec spS_Banamex_SIRH " + iFecCorte.ToString() + "," + lSirh.ToString() + "," + iNoUsuario.ToString() + "," + "5" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();

                                        //nombre del reporte
                                        if (iTipo == CORVB.NULL_INTEGER)
                                        { //General
                                            sNomRep = "Bnx_SIR_G.rpt";
                                        }
                                        else
                                        {
                                            sNomRep = "Bnx_SIR_I.rpt";
                                        }

                                        //inserta en la tabla de MTCRPB01
                                        Procesa_Reporte(miNoUsuario, 5, ref CORVAR.pszgblsql);

                                        //si existen registros llena el reporte
                                        if (mbExisteReg)
                                        {
                                            //llama crystal report
                                            Genera_Reporte_Crystal(sNomRep, 5);
                                            Borra_No_Usuario(5);
                                        }
                                    }

                                    lSubdivAnt = lSubdiv;
                                    //genera el reporte por subdiviones
                                    CORVAR.pszgblsql = "Exec spS_Banamex_Subdivision " + iFecCorte.ToString() + "," + lSubdiv.ToString() + "," + iNoUsuario.ToString() + "," + "4" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();

                                    //nombre del reporte
                                    if (iTipo == CORVB.NULL_INTEGER)
                                    { //General
                                        sNomRep = "Bnx_SUB_G.rpt";
                                    }
                                    else
                                    {
                                        sNomRep = "Bnx_SUB_I.rpt";
                                    }

                                    //inserta en la tabla de MTCRPB01
                                    Procesa_Reporte(miNoUsuario, 4, ref CORVAR.pszgblsql);

                                    //si existen registros llena el reporte
                                    if (mbExisteReg)
                                    {
                                        //llama crystal report
                                        Genera_Reporte_Crystal(sNomRep, 4);
                                        Borra_No_Usuario(4);
                                    }
                                    lPosIni = lRenglon;
                                }
                            }
                            else
                            {
                                lPosIni = lRenglon;
                            }
                        }
                    }
                    ////////////////////////////////////////// 

                    break;
                case 4:  //subdireccion 
                    CORVAR.pszgblsql = "Exec spS_Banamex_Subdivision " + iFecCorte.ToString() + "," + lNumeroPro.ToString() + "," + iNoUsuario.ToString() + "," + iNoRep.ToString() + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();

                    //nombre del reporte 
                    if (iTipo == CORVB.NULL_INTEGER)
                    { //General
                        sNomRep = "Bnx_SUB_G.rpt";
                    }
                    else
                    {
                        sNomRep = "Bnx_SUB_I.rpt";
                    }

                    //inserta en la tabla de MTCRPB01 
                    Procesa_Reporte(miNoUsuario, iNoRep, ref CORVAR.pszgblsql);

                    //si existen registros llena el reporte 
                    if (mbExisteReg)
                    {

                        //llama crystal report
                        Genera_Reporte_Crystal(sNomRep, iNoRep);
                        Borra_No_Usuario(iNoRep);
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("No hay registros para el reporte", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //vacia la informacion al spread 
                    CORVAR.pszgblsql = "SELECT  bnx_id_unicas ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " FROM MTCBNX01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE bnx_id_subdivision = " + lNumeroPro.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " AND bnx_id_unicas <> 0 ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " GROUP BY  bnx_id_unicas ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " ORDER BY  bnx_id_unicas ";

                    //llena en el spread 
                    Llena_spread(CORVAR.pszgblsql, iNoRep);

                    // lee las columnas del spread por renglones 
                    lSirhAnt = CORVB.NULL_INTEGER;
                    bBandera = false;
                    for (int lRenglon = 1; lRenglon <= vspDatos.MaxRows; lRenglon++)
                    {

                        //guarda la posicion
                        lPos = lRenglon;

                        vspDatos.Row = lRenglon;

                        vspDatos.Col = 1; //sirh
                        lSirh = Convert.ToInt32(Conversion.Val(vspDatos.Text));

                        //genera el reporte por sirh
                        CORVAR.pszgblsql = "Exec spS_Banamex_SIRH " + iFecCorte.ToString() + "," + lSirh.ToString() + "," + iNoUsuario.ToString() + "," + "5" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();

                        //nombre del reporte
                        if (iTipo == CORVB.NULL_INTEGER)
                        { //General
                            sNomRep = "Bnx_SIR_G.rpt";
                        }
                        else
                        {
                            sNomRep = "Bnx_SIR_I.rpt";
                        }

                        //inserta en la tabla de MTCRPB01
                        Procesa_Reporte(miNoUsuario, 5, ref CORVAR.pszgblsql);

                        //si existen registros llena el reporte
                        if (mbExisteReg)
                        {
                            //llama crystal report
                            Genera_Reporte_Crystal(sNomRep, 5);
                            Borra_No_Usuario(5);
                        }

                    }

                    ////////////////////////////////////////// 
                    break;
                case 5:  //sirh 

                    CORVAR.pszgblsql = "Exec spS_Banamex_SIRH " + iFecCorte.ToString() + "," + lNumeroPro.ToString() + "," + iNoUsuario.ToString() + "," + iNoRep.ToString() + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo + "," + lGpoBnx.ToString();

                    //nombre del reporte 
                    if (iTipo == CORVB.NULL_INTEGER)
                    { //General
                        sNomRep = "Bnx_SIR_G.rpt";
                    }
                    else
                    {
                        sNomRep = "Bnx_SIR_I.rpt";
                    }

                    //inserta en la tabla de MTCRPB01 
                    Procesa_Reporte(miNoUsuario, 5, ref CORVAR.pszgblsql);

                    //si existen registros llena el reporte 
                    if (mbExisteReg)
                    {
                        //llama crystal report
                        Genera_Reporte_Crystal(sNomRep, 5);
                        Borra_No_Usuario(5);
                    }

                    break;
            }

            MessageBox.Show("Fin del Proceso", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            this.Cursor = Cursors.Default;

        }




        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Imprime los reportes desde el nivel donde se        **
        //**                   hasta el ultimo nivel
        //**                                                                        **
        //**                                                                        **
        //**       Paso de parámetros: numero de usuario                            **
        //**                           numero de reporte                            **
        //**                           fecha de corte, tipo de reporte              **
        //**       Valor de Regreso:                                                **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 22ene99                                     **
        //**                                                                        **
        //****************************************************************************
        //UPGRADE_NOTE: (7001) The following declaration (Seleccion_General_Original) seems to be dead code
        //private void  Seleccion_General_Original( int iNoUsuario, ref  int iNoRep,  int iFecCorte,  int iTipo)
        //{
        //string sNomRep = String.Empty;
        //int lContador = 0;
        //string sTipo = String.Empty;
        //int lSigValor = 0;
        //
        //this.Cursor = Cursors.WaitCursor;
        //
        //Realiza la segunda Conexion
        //intCont = CORDBLIB.Segunda_ConexionServidor();
        //
        //if (intCont == 0)
        //{
        //this.Cursor = Cursors.Default;
        ////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //CORVAR.igblErr = (int) Interaction.MsgBox("No se pudo realizar la Segunda conexión, vuelva a intentar.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
        //VBSQL.SqlClose(CORVAR.hgblConexion2); //Realiza Desconexión
        //return;
        //}
        //
        //arma la fecha de texto
        //string sFecText = Arma_Fecha_Texto(iFecCorte);
        //
        //int lNumeroPro = CORVB.NULL_INTEGER;
        //
        //verifica que el identificador no esteen ceros
        //if (Double.Parse(txtIdentificador.Text) == CORVB.NULL_INTEGER)
        //{
        //if (iTipo == CORVB.NULL_INTEGER)
        //{ //General
        //sTipo = "General";
        //} else
        //{
        //sTipo = "Individual";
        //}
        //obtiene el numero del proceso
        //lNumeroPro = Convert.ToInt32(Conversion.Val(cboGrupo.Text.Substring(0, Math.Min(cboGrupo.Text.Length, 6))));
        //
        //if (lNumeroPro == CORVB.NULL_INTEGER)
        //{
        //MessageBox.Show("No hay seleccionado ningún registro", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //
        //Realiza Desconexión
        //VBSQL.SqlClose(CORVAR.hgblConexion2);
        //
        //return;
        //}
        //
        //} else
        //{
        //lNumeroPro = Int32.Parse(txtIdentificador.Text);
        //
        //if (iTipo == CORVB.NULL_INTEGER)
        //{ //General
        //sTipo = "General";
        //} else
        //{
        //sTipo = "Individual";
        //}
        //}
        //
        //switch(iNoRep)
        //{
        //case 1 :  //banco 
        //CORVAR.pszgblsql = "Exec spS_Banamex_BCO " + iFecCorte.ToString() + "," + lNumeroPro.ToString() + "," + iNoUsuario.ToString() + "," + iNoRep.ToString() + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo; 
        //nombre del reporte 
        //if (iTipo == CORVB.NULL_INTEGER)
        //{ //General
        //sNomRep = "Bnx_BCO_G.rpt";
        //} else
        //{
        //sNomRep = "Bnx_BCO_I.rpt";
        //} 
        // 
        //inserta en la tabla de MTCRPB01 
        //Procesa_Reporte(miNoUsuario, iNoRep, ref CORVAR.pszgblsql); 
        // 
        //si existen registros llena el reporte 
        //if (mbExisteReg)
        //{
        //llama crystal report
        //Genera_Reporte_Crystal(sNomRep, iNoRep);
        //Borra_No_Usuario(iNoRep);
        //} else
        //{
        //this.Cursor = Cursors.Default;
        //MessageBox.Show("No hay registros para el reporte", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //
        //Realiza Desconexión
        //VBSQL.SqlClose(CORVAR.hgblConexion2);
        //
        //return;
        //} 
        // 
        //********************************************************************************** 
        //************************realiza la consulta del siguinete nivel dga 
        //********************************************************************************** 
        //CORVAR.pszgblSql2 = "SELECT distinct(bnx_id_dga) FROM MTCBNX01"; 
        //CORVAR.pszgblSql2 = CORVAR.pszgblSql2 + " WHERE bnx_id_banco = " + lNumeroPro.ToString(); 
        // 
        //if (CORPROC2.Obtiene_Datos() != 0)
        //{
        //
        //while(VBSQL.SqlNextRow(CORVAR.hgblConexion2) != VBSQL.NOMOREROWS)
        //{
        //lSigValor = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1)));
        //
        //if (lSigValor != CORVB.NULL_INTEGER)
        //{
        //genera el proceso
        //CORVAR.pszgblsql = "Exec spS_Banamex_Area " + iFecCorte.ToString() + "," + lSigValor.ToString() + "," + iNoUsuario.ToString() + "," + "2" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo;
        //nombre del reporte
        //if (iTipo == CORVB.NULL_INTEGER)
        //{ //General
        //sNomRep = "Bnx_DGA_G.rpt";
        //} else
        //{
        //sNomRep = "Bnx_DGA_I.rpt";
        //}
        //
        //inserta en la tabla de MTCRPB01
        //Procesa_Reporte(miNoUsuario, 2, ref CORVAR.pszgblsql);
        //
        //si existen registros llena el reporte
        //if (mbExisteReg)
        //{
        //llama crystal report
        //Genera_Reporte_Crystal(sNomRep, 2);
        //Borra_No_Usuario(2);
        //}
        //}
        //};
        //} else
        //{
        //this.Cursor = Cursors.Default;
        //} 
        //Realiza fin de Query 
        //igblRetorna2 = VBSQL.SqlCancel(CORVAR.hgblConexion2); 
        // 
        //********************************************************************************** 
        //************************ finaliza la consulta del siguinete nivel dga 
        //********************************************************************************** 
        // 
        //********************************************************************************** 
        //************************realiza la consulta del siguinete nivel division 
        //********************************************************************************** 
        //CORVAR.pszgblSql2 = "SELECT distinct(bnx_id_division) FROM MTCBNX01"; 
        //CORVAR.pszgblSql2 = CORVAR.pszgblSql2 + " WHERE bnx_id_banco = " + lNumeroPro.ToString(); 
        // 
        //if (CORPROC2.Obtiene_Datos() != 0)
        //{
        //
        //while(VBSQL.SqlNextRow(CORVAR.hgblConexion2) != VBSQL.NOMOREROWS)
        //{
        //lSigValor = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1)));
        //
        //if (lSigValor != CORVB.NULL_INTEGER)
        //{
        //genera el proceso
        //CORVAR.pszgblsql = "Exec spS_Banamex_Subdivision " + iFecCorte.ToString() + "," + lSigValor.ToString() + "," + iNoUsuario.ToString() + "," + "3" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo;
        //
        //nombre del reporte
        //if (iTipo == CORVB.NULL_INTEGER)
        //{ //General
        //sNomRep = "Bnx_DIV_G.rpt";
        //} else
        //{
        //sNomRep = "Bnx_DIV_I.rpt";
        //}
        //
        //inserta en la tabla de MTCRPB01
        //Procesa_Reporte(miNoUsuario, 3, ref CORVAR.pszgblsql);
        //
        //si existen registros llena el reporte
        //if (mbExisteReg)
        //{
        //llama crystal report
        //Genera_Reporte_Crystal(sNomRep, 3);
        //Borra_No_Usuario(3);
        //}
        //}
        //};
        //} else
        //{
        //this.Cursor = Cursors.Default;
        //} 
        //Realiza fin de Query 
        //igblRetorna2 = VBSQL.SqlCancel(CORVAR.hgblConexion2); 
        // 
        //********************************************************************************** 
        //************************ finaliza la consulta del siguinete nivel division 
        //********************************************************************************** 
        // 
        //********************************************************************************** 
        //************************realiza la consulta del siguinete nivel subdivision 
        //********************************************************************************** 
        //CORVAR.pszgblSql2 = "SELECT distint(bnx_id_subdivision) FROM MTCBNX01"; 
        //CORVAR.pszgblSql2 = CORVAR.pszgblSql2 + " WHERE bnx_id_banco = " + lNumeroPro.ToString(); 
        // 
        //if (CORPROC2.Obtiene_Datos() != 0)
        //{
        //
        //while(VBSQL.SqlNextRow(CORVAR.hgblConexion2) != VBSQL.NOMOREROWS)
        //{
        //lSigValor = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1)));
        //
        //if (lSigValor != CORVB.NULL_INTEGER)
        //{
        //genera el proceso
        //CORVAR.pszgblsql = "Exec spS_Banamex_Subdivision " + iFecCorte.ToString() + "," + lSigValor.ToString() + "," + iNoUsuario.ToString() + "," + "4" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo;
        //
        //nombre del reporte
        //if (iTipo == CORVB.NULL_INTEGER)
        //{ //General
        //sNomRep = "Bnx_SUB_G.rpt";
        //} else
        //{
        //sNomRep = "Bnx_SUB_I.rpt";
        //}
        //
        //inserta en la tabla de MTCRPB01
        //Procesa_Reporte(miNoUsuario, 4, ref CORVAR.pszgblsql);
        //
        //si existen registros llena el reporte
        //if (mbExisteReg)
        //{
        //llama crystal report
        //Genera_Reporte_Crystal(sNomRep, 4);
        //Borra_No_Usuario(4);
        //}
        //}
        //};
        //} else
        //{
        //this.Cursor = Cursors.Default;
        //} 
        //Realiza fin de Query 
        //igblRetorna2 = VBSQL.SqlCancel(CORVAR.hgblConexion2); 
        // 
        //********************************************************************************** 
        //************************ finaliza la consulta del siguinete nivel subdivision 
        //********************************************************************************** 
        // 
        //********************************************************************************** 
        //************************realiza la consulta del siguinete nivel sirh 
        //********************************************************************************** 
        //CORVAR.pszgblSql2 = "SELECT distinct(bnx_id_unicas) FROM MTCBNX01"; 
        //CORVAR.pszgblSql2 = CORVAR.pszgblSql2 + " WHERE bnx_id_banco = " + lNumeroPro.ToString(); 
        // 
        //if (CORPROC2.Obtiene_Datos() != 0)
        //{
        //
        //while(VBSQL.SqlNextRow(CORVAR.hgblConexion2) != VBSQL.NOMOREROWS)
        //{
        //lSigValor = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1)));
        //
        //if (lSigValor != CORVB.NULL_INTEGER)
        //{
        //genera el proceso
        //CORVAR.pszgblsql = "Exec spS_Banamex_SIRH " + iFecCorte.ToString() + "," + lSigValor.ToString() + "," + iNoUsuario.ToString() + "," + "5" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo;
        //
        //nombre del reporte
        //if (iTipo == CORVB.NULL_INTEGER)
        //{ //General
        //sNomRep = "Bnx_SIR_G.rpt";
        //} else
        //{
        //sNomRep = "Bnx_SIR_I.rpt";
        //}
        //
        //inserta en la tabla de MTCRPB01
        //Procesa_Reporte(miNoUsuario, 5, ref CORVAR.pszgblsql);
        //
        //si existen registros llena el reporte
        //if (mbExisteReg)
        //{
        //llama crystal report
        //Genera_Reporte_Crystal(sNomRep, 5);
        //Borra_No_Usuario(5);
        //}
        //}
        //};
        //} else
        //{
        //this.Cursor = Cursors.Default;
        //} 
        //Realiza fin de Query 
        //igblRetorna2 = VBSQL.SqlCancel(CORVAR.hgblConexion2); 
        // 
        //********************************************************************************** 
        //************************ finaliza la consulta del siguinete nivel sirh 
        //********************************************************************************** 
        // 
        ////////////////////////////////////////// 
        // 
        //break;
        //case 2 :  //area 
        //CORVAR.pszgblsql = "Exec spS_Banamex_Area " + iFecCorte.ToString() + "," + lNumeroPro.ToString() + "," + iNoUsuario.ToString() + "," + iNoRep.ToString() + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo; 
        //nombre del reporte 
        //if (iTipo == CORVB.NULL_INTEGER)
        //{ //General
        //sNomRep = "Bnx_DGA_G.rpt";
        //} else
        //{
        //sNomRep = "Bnx_DGA_I.rpt";
        //} 
        // 
        //inserta en la tabla de MTCRPB01 
        //Procesa_Reporte(miNoUsuario, iNoRep, ref CORVAR.pszgblsql); 
        // 
        //si existen registros llena el reporte 
        //if (mbExisteReg)
        //{
        //llama crystal report
        //Genera_Reporte_Crystal(sNomRep, iNoRep);
        //Borra_No_Usuario(iNoRep);
        //} else
        //{
        //this.Cursor = Cursors.Default;
        //MessageBox.Show("No hay registros para el reporte", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //
        //Realiza Desconexión
        //VBSQL.SqlClose(CORVAR.hgblConexion2);
        //
        //return;
        //} 
        // 
        //********************************************************************************** 
        //************************realiza la consulta del siguinete nivel division 
        //********************************************************************************** 
        //CORVAR.pszgblSql2 = "SELECT distinct(bnx_id_division) FROM MTCBNX01"; 
        //CORVAR.pszgblSql2 = CORVAR.pszgblSql2 + " WHERE bnx_id_dga = " + lNumeroPro.ToString(); 
        // 
        //if (CORPROC2.Obtiene_Datos() != 0)
        //{
        //
        //while(VBSQL.SqlNextRow(CORVAR.hgblConexion2) != VBSQL.NOMOREROWS)
        //{
        //lSigValor = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1)));
        //
        //if (lSigValor != CORVB.NULL_INTEGER)
        //{
        //genera el proceso
        //CORVAR.pszgblsql = "Exec spS_Banamex_Division " + iFecCorte.ToString() + "," + lSigValor.ToString() + "," + iNoUsuario.ToString() + "," + "3" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo;
        //
        //if (iTipo == CORVB.NULL_INTEGER)
        //{ //General
        //sNomRep = "Bnx_DIV_G.rpt";
        //} else
        //{
        //sNomRep = "Bnx_DIV_I.rpt";
        //}
        //
        //inserta en la tabla de MTCRPB01
        //Procesa_Reporte(miNoUsuario, 3, ref CORVAR.pszgblsql);
        //
        //si existen registros llena el reporte
        //if (mbExisteReg)
        //{
        //llama crystal report
        //Genera_Reporte_Crystal(sNomRep, 3);
        //Borra_No_Usuario(3);
        //}
        //}
        //};
        //} else
        //{
        //this.Cursor = Cursors.Default;
        //} 
        //Realiza fin de Query 
        //igblRetorna2 = VBSQL.SqlCancel(CORVAR.hgblConexion2); 
        // 
        //********************************************************************************** 
        //************************ finaliza la consulta del siguinete nivel division 
        //********************************************************************************** 
        // 
        //********************************************************************************** 
        //************************realiza la consulta del siguinete nivel subdivision 
        //********************************************************************************** 
        //CORVAR.pszgblSql2 = "SELECT distinct(bnx_id_subdivision) FROM MTCBNX01"; 
        //CORVAR.pszgblSql2 = CORVAR.pszgblSql2 + " WHERE bnx_id_dga = " + lNumeroPro.ToString(); 
        // 
        //if (CORPROC2.Obtiene_Datos() != 0)
        //{
        //
        //while(VBSQL.SqlNextRow(CORVAR.hgblConexion2) != VBSQL.NOMOREROWS)
        //{
        //lSigValor = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1)));
        //
        //if (lSigValor != CORVB.NULL_INTEGER)
        //{
        //genera el proceso
        //CORVAR.pszgblsql = "Exec spS_Banamex_Subdivision " + iFecCorte.ToString() + "," + lSigValor.ToString() + "," + iNoUsuario.ToString() + "," + "4" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo;
        //
        //nombre del reporte
        //if (iTipo == CORVB.NULL_INTEGER)
        //{ //General
        //sNomRep = "Bnx_SUB_G.rpt";
        //} else
        //{
        //sNomRep = "Bnx_SUB_I.rpt";
        //}
        //
        //inserta en la tabla de MTCRPB01
        //Procesa_Reporte(miNoUsuario, 4, ref CORVAR.pszgblsql);
        //
        //si existen registros llena el reporte
        //if (mbExisteReg)
        //{
        //llama crystal report
        //Genera_Reporte_Crystal(sNomRep, 4);
        //Borra_No_Usuario(4);
        //}
        //}
        //};
        //} else
        //{
        //this.Cursor = Cursors.Default;
        //} 
        //Realiza fin de Query 
        //igblRetorna2 = VBSQL.SqlCancel(CORVAR.hgblConexion2); 
        // 
        //********************************************************************************** 
        //************************ finaliza la consulta del siguinete nivel subdivision 
        //********************************************************************************** 
        // 
        //********************************************************************************** 
        //************************realiza la consulta del siguinete nivel sirh 
        //********************************************************************************** 
        //CORVAR.pszgblSql2 = "SELECT distinct(bnx_id_unicas) FROM MTCBNX01"; 
        //CORVAR.pszgblSql2 = CORVAR.pszgblSql2 + " WHERE bnx_id_dga = " + lNumeroPro.ToString(); 
        // 
        //if (CORPROC2.Obtiene_Datos() != 0)
        //{
        //
        //while(VBSQL.SqlNextRow(CORVAR.hgblConexion2) != VBSQL.NOMOREROWS)
        //{
        //lSigValor = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1)));
        //
        //if (lSigValor != CORVB.NULL_INTEGER)
        //{
        //genera el proceso
        //CORVAR.pszgblsql = "Exec spS_Banamex_SIRH " + iFecCorte.ToString() + "," + lSigValor.ToString() + "," + iNoUsuario.ToString() + "," + "5" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo;
        //
        //nombre del reporte
        //if (iTipo == CORVB.NULL_INTEGER)
        //{ //General
        //sNomRep = "Bnx_SIR_G.rpt";
        //} else
        //{
        //sNomRep = "Bnx_SIR_I.rpt";
        //}
        //
        //inserta en la tabla de MTCRPB01
        //Procesa_Reporte(miNoUsuario, 5, ref CORVAR.pszgblsql);
        //
        //si existen registros llena el reporte
        //if (mbExisteReg)
        //{
        //llama crystal report
        //Genera_Reporte_Crystal(sNomRep, 5);
        //Borra_No_Usuario(5);
        //}
        //}
        //};
        //} else
        //{
        //this.Cursor = Cursors.Default;
        //} 
        //Realiza fin de Query 
        //igblRetorna2 = VBSQL.SqlCancel(CORVAR.hgblConexion2); 
        // 
        //********************************************************************************** 
        //************************ finaliza la consulta del siguinete nivel sirh 
        //********************************************************************************** 
        ////////////////////////////////////////// 
        // 
        //break;
        //case 3 :  //division 
        //CORVAR.pszgblsql = "Exec spS_Banamex_Division " + iFecCorte.ToString() + "," + lNumeroPro.ToString() + "," + iNoUsuario.ToString() + "," + iNoRep.ToString() + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo; 
        //nombre del reporte 
        //if (iTipo == CORVB.NULL_INTEGER)
        //{ //General
        //sNomRep = "Bnx_DIV_G.rpt";
        //} else
        //{
        //sNomRep = "Bnx_DIV_I.rpt";
        //} 
        // 
        //inserta en la tabla de MTCRPB01 
        //Procesa_Reporte(miNoUsuario, iNoRep, ref CORVAR.pszgblsql); 
        // 
        //si existen registros llena el reporte 
        //if (mbExisteReg)
        //{
        //
        //llama crystal report
        //Genera_Reporte_Crystal(sNomRep, iNoRep);
        //Borra_No_Usuario(iNoRep);
        //} else
        //{
        //this.Cursor = Cursors.Default;
        //MessageBox.Show("No hay registros para el reporte", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //
        //Realiza Desconexión
        //VBSQL.SqlClose(CORVAR.hgblConexion2);
        //
        //return;
        //} 
        // 
        //********************************************************************************** 
        //************************realiza la consulta del siguinete nivel subdivision 
        //********************************************************************************** 
        //CORVAR.pszgblSql2 = "SELECT distinct(bnx_id_subdivision) FROM MTCBNX01"; 
        //CORVAR.pszgblSql2 = CORVAR.pszgblSql2 + " WHERE bnx_id_division = " + lNumeroPro.ToString(); 
        // 
        //if (CORPROC2.Obtiene_Datos() != 0)
        //{
        //
        //while(VBSQL.SqlNextRow(CORVAR.hgblConexion2) != VBSQL.NOMOREROWS)
        //{
        //lSigValor = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1)));
        //
        //if (lSigValor != CORVB.NULL_INTEGER)
        //{
        //genera el proceso
        //CORVAR.pszgblsql = "Exec spS_Banamex_Subdivision " + iFecCorte.ToString() + "," + lSigValor.ToString() + "," + iNoUsuario.ToString() + "," + "4" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo;
        //
        //nombre del reporte
        //if (iTipo == CORVB.NULL_INTEGER)
        //{ //General
        //sNomRep = "Bnx_SUB_G.rpt";
        //} else
        //{
        //sNomRep = "Bnx_SUB_I.rpt";
        //}
        //
        //inserta en la tabla de MTCRPB01
        //Procesa_Reporte(miNoUsuario, 4, ref CORVAR.pszgblsql);
        //
        //si existen registros llena el reporte
        //if (mbExisteReg)
        //{
        //llama crystal report
        //Genera_Reporte_Crystal(sNomRep, 4);
        //Borra_No_Usuario(4);
        //}
        //}
        //};
        //} else
        //{
        //this.Cursor = Cursors.Default;
        //} 
        //Realiza fin de Query 
        //igblRetorna2 = VBSQL.SqlCancel(CORVAR.hgblConexion2); 
        // 
        //********************************************************************************** 
        //************************ finaliza la consulta del siguinete nivel subdivision 
        //********************************************************************************** 
        // 
        //********************************************************************************** 
        //************************realiza la consulta del siguinete nivel sirh 
        //********************************************************************************** 
        //CORVAR.pszgblSql2 = "SELECT distinct(bnx_id_unicas) FROM MTCBNX01"; 
        //CORVAR.pszgblSql2 = CORVAR.pszgblSql2 + " WHERE bnx_id_division = " + lNumeroPro.ToString(); 
        // 
        //if (CORPROC2.Obtiene_Datos() != 0)
        //{
        //
        //while(VBSQL.SqlNextRow(CORVAR.hgblConexion2) != VBSQL.NOMOREROWS)
        //{
        //lSigValor = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1)));
        //
        //if (lSigValor != CORVB.NULL_INTEGER)
        //{
        //genera el proceso
        //CORVAR.pszgblsql = "Exec spS_Banamex_SIRH " + iFecCorte.ToString() + "," + lSigValor.ToString() + "," + iNoUsuario.ToString() + "," + "5" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo;
        //
        //nombre del reporte
        //if (iTipo == CORVB.NULL_INTEGER)
        //{ //General
        //sNomRep = "Bnx_SIR_G.rpt";
        //} else
        //{
        //sNomRep = "Bnx_SIR_I.rpt";
        //}
        //
        //inserta en la tabla de MTCRPB01
        //Procesa_Reporte(miNoUsuario, 5, ref CORVAR.pszgblsql);
        //
        //si existen registros llena el reporte
        //if (mbExisteReg)
        //{
        //llama crystal report
        //Genera_Reporte_Crystal(sNomRep, 5);
        //Borra_No_Usuario(5);
        //}
        //}
        //};
        //} else
        //{
        //this.Cursor = Cursors.Default;
        //} 
        //Realiza fin de Query 
        //igblRetorna2 = VBSQL.SqlCancel(CORVAR.hgblConexion2); 
        // 
        //********************************************************************************** 
        //************************ finaliza la consulta del siguinete nivel sirh 
        //********************************************************************************** 
        ////////////////////////////////////////// 
        // 
        //break;
        //case 4 :  //subdireccion 
        //CORVAR.pszgblsql = "Exec spS_Banamex_Subdivision " + iFecCorte.ToString() + "," + lNumeroPro.ToString() + "," + iNoUsuario.ToString() + "," + iNoRep.ToString() + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo; 
        // 
        //nombre del reporte 
        //if (iTipo == CORVB.NULL_INTEGER)
        //{ //General
        //sNomRep = "Bnx_SUB_G.rpt";
        //} else
        //{
        //sNomRep = "Bnx_SUB_I.rpt";
        //} 
        // 
        //inserta en la tabla de MTCRPB01 
        //Procesa_Reporte(miNoUsuario, iNoRep, ref CORVAR.pszgblsql); 
        // 
        //si existen registros llena el reporte 
        //if (mbExisteReg)
        //{
        //
        //llama crystal report
        //Genera_Reporte_Crystal(sNomRep, iNoRep);
        //Borra_No_Usuario(iNoRep);
        //} else
        //{
        //this.Cursor = Cursors.Default;
        //MessageBox.Show("No hay registros para el reporte", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //
        //Realiza Desconexión
        //VBSQL.SqlClose(CORVAR.hgblConexion2);
        //
        //return;
        //} 
        // 
        //********************************************************************************** 
        //************************realiza la consulta del siguinete nivel sirh 
        //********************************************************************************** 
        //CORVAR.pszgblSql2 = "SELECT distinct(bnx_id_unicas) FROM MTCBNX01"; 
        //CORVAR.pszgblSql2 = CORVAR.pszgblSql2 + " WHERE bnx_id_subdivision = " + lNumeroPro.ToString(); 
        // 
        //if (CORPROC2.Obtiene_Datos() != 0)
        //{
        //
        //while(VBSQL.SqlNextRow(CORVAR.hgblConexion2) != VBSQL.NOMOREROWS)
        //{
        //lSigValor = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1)));
        //
        //if (lSigValor != CORVB.NULL_INTEGER)
        //{
        //genera el proceso
        //CORVAR.pszgblsql = "Exec spS_Banamex_SIRH " + iFecCorte.ToString() + "," + lSigValor.ToString() + "," + iNoUsuario.ToString() + "," + "5" + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo;
        //
        //nombre del reporte
        //if (iTipo == CORVB.NULL_INTEGER)
        //{ //General
        //sNomRep = "Bnx_SIR_G.rpt";
        //} else
        //{
        //sNomRep = "Bnx_SIR_I.rpt";
        //}
        //
        //inserta en la tabla de MTCRPB01
        //Procesa_Reporte(miNoUsuario, 5, ref CORVAR.pszgblsql);
        //
        //
        //si existen registros llena el reporte
        //if (mbExisteReg)
        //{
        //llama crystal report
        //Genera_Reporte_Crystal(sNomRep, 5);
        //Borra_No_Usuario(5);
        //}
        //}
        //
        //};
        //} else
        //{
        //this.Cursor = Cursors.Default;
        //} 
        //Realiza fin de Query 
        //igblRetorna2 = VBSQL.SqlCancel(CORVAR.hgblConexion2); 
        // 
        //********************************************************************************** 
        //************************ finaliza la consulta del siguinete nivel sirh 
        //********************************************************************************** 
        ////////////////////////////////////////// 
        //break;
        //case 5 :  //sirh 
        // 
        //CORVAR.pszgblSql2 = "SELECT distinct(bnx_id_unicas) FROM MTCBNX01"; 
        // 
        //if (CORPROC2.Obtiene_Datos() != 0)
        //{
        //
        //while(VBSQL.SqlNextRow(CORVAR.hgblConexion2) != VBSQL.NOMOREROWS)
        //{
        //lSigValor = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1)));
        //
        //if (lSigValor != CORVB.NULL_INTEGER)
        //{
        //genera el proceso
        //CORVAR.pszgblsql = "Exec spS_Banamex_SIRH " + iFecCorte.ToString() + "," + lSigValor.ToString() + "," + iNoUsuario.ToString() + "," + iNoRep.ToString() + "," + CORVAR.dgblIva.ToString() + ",'" + sFecText + "'" + "," + sTipo;
        //
        //nombre del reporte
        //if (iTipo == CORVB.NULL_INTEGER)
        //{ //General
        //sNomRep = "Bnx_SIR_G.rpt";
        //} else
        //{
        //sNomRep = "Bnx_SIR_I.rpt";
        //}
        //
        //inserta en la tabla de MTCRPB01
        //Procesa_Reporte(miNoUsuario, 5, ref CORVAR.pszgblsql);
        //
        //si existen registros llena el reporte
        //if (mbExisteReg)
        //{
        //
        //llama crystal report
        //Genera_Reporte_Crystal(sNomRep, 5);
        //Borra_No_Usuario(5);
        //}
        //}
        //};
        //} 
        // 
        //Realiza fin de Query 
        //igblRetorna2 = VBSQL.SqlCancel(CORVAR.hgblConexion2); 
        // 
        //break;
        //}
        //
        //Realiza Desconexión
        //VBSQL.SqlClose(CORVAR.hgblConexion2);
        //
        //
        //MessageBox.Show("Fin del Proceso", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //
        //this.Cursor = Cursors.Default;
        //
        //}





        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Selecciona el numero de usuario de la tabla de MTCRPB**
        //**                                                                        **
        //**                                                                        **
        //**       Paso de parámetros: Numero de reporte                            **
        //**                                                                        **
        //**       Valor de Regreso: Numero de usuario                              **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 22ene99                                     **
        //**                                                                        **
        //****************************************************************************

        private int Asigna_Usuario(int iNoRep)
        {
            int iUsuario = 0;

            //el segundo valor es cero debido a hay se regresa el valor
            CORVAR.pszgblsql = "Exec spS_Asigna_No_Usuario " + iNoRep.ToString() + ", 0";

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    iUsuario = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                }
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            return iUsuario;

        }

        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Genera el reporte de crystal reporet                **
        //**                                                                        **
        //**                                                                        **
        //**       Paso de parámetros: Ninguno                                      **
        //**                                                                        **
        //**       Valor de Regreso: Ninguno                                        **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 21ene99                                     **
        //**                                                                        **
        //****************************************************************************
        public void Genera_Reporte_Crystal(string sReporte, int iNumReporte)
        {
            string sDirectorio = String.Empty;
            string sRespuesta = String.Empty;
            string sMsg = String.Empty;
            int hwndPreviewWindow = 0;
            string sQueryPaso = String.Empty;
            try
            {

                //obtiene la ruta del directorio de crystal
                sDirectorio = CORVAR.pszgblPathRepCrystal;

                //busca el archivo en el directorio
                if (FileSystem.Dir(sDirectorio + sReporte, FileAttribute.Normal) == CORVB.NULL_STRING)
                {
                    this.Cursor = Cursors.Default;
                    sMsg = "No existe el archivo:" + sDirectorio + sReporte + "¿Desea continuar? "; // Define el mensaje.
                    // Muestra el mensaje.
                    sRespuesta = ((int)MessageBox.Show(sMsg, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error)).ToString();
                    if (sRespuesta == ((int)System.Windows.Forms.DialogResult.Yes).ToString())
                    {
                        if (FileSystem.Dir(sDirectorio + sReporte, FileAttribute.Normal) == CORVB.NULL_STRING)
                        {
                            MessageBox.Show("No existe el archivo:" + sDirectorio + sReporte + "No se puede continuar", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    sQueryPaso = "SELECT MTCRPB01.rpb_centro_c , MTCRPB01.rpb_descrip, ";
                    sQueryPaso = sQueryPaso + " MTCRPB01.rpb_periodo, MTCRPB01.rpb_titulo, MTCRPB01.rpb_nombre,";
                    sQueryPaso = sQueryPaso + " MTCRPB01.rpb_calle, MTCRPB01.rpb_col, MTCRPB01.rpb_edo, ";
                    sQueryPaso = sQueryPaso + " MTCRPB01.rpb_aereas, MTCRPB01.rpb_hoteles, MTCRPB01.rpb_restaurant, MTCRPB01.rpb_rent_auto, MTCRPB01.rpb_otros,";
                    sQueryPaso = sQueryPaso + " MTCRPB01.rpb_atr_saldo, MTCRPB01.rpb_anterior, ";
                    sQueryPaso = sQueryPaso + " MTCRPB01.rpb_consumos, MTCRPB01.rpb_dip_efec, MTCRPB01.rpb_pagos,";
                    sQueryPaso = sQueryPaso + " MTCRPB01.rpb_comisiones, MTCRPB01.rpb_iva, MTCRPB01.rpb_gtos_cobran, ";
                    sQueryPaso = sQueryPaso + " MTCRPB01.rpb_sdo_nuevo";
                    //***** INICIO CODIGO ANTERIOR FSWBMX *****
                    //sQueryPaso = sQueryPaso & " FROM  M111.dbo.MTCRPB01 MTCRPB01"
                    //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                    sQueryPaso = sQueryPaso + " FROM  MTCRPB01"; //FSWBMX
                    sQueryPaso = sQueryPaso + " WHERE MTCRPB01.rpb_no_usuario = ";
                    sQueryPaso = sQueryPaso + miNoUsuario.ToString();
                    sQueryPaso = sQueryPaso + " AND  MTCRPB01.rpb_no_rep = ";
                    sQueryPaso = sQueryPaso + iNumReporte.ToString();
                    sQueryPaso = sQueryPaso + " AND  MTCRPB01.rpb_corte_amd <> 0 ";
                    crReporBnx.SQLQuery = sQueryPaso;
                }
                this.Cursor = Cursors.WaitCursor;
                //***** INICIO CODIGO NUEVO FSWBMX *****
                crReporBnx.Connect = "DSN=" + CORDBLIB.gsServidor + ";UID=" + CORDBLIB.gsUsuario + ";PWD=" + CORDBLIB.gsPassword + ";DSQ=" + CORDBLIB.gsBaseDatos + ";keeporgmultibyte=1";
                crReporBnx.set_ParameterFields(0, "0prefijo" + ";" + CORVAR.igblPref.ToString());
                crReporBnx.set_ParameterFields(1, "1banco" + ";" + CORVAR.igblBanco.ToString());
                //***** FIN DE CODIGO NUEVO FSWBMX *****
                crReporBnx.ReportFileName = sDirectorio + sReporte; //Nombre del reporte
                if (chkOpcion.CheckState == CheckState.Unchecked)
                {
                    crReporBnx.Destination = Crystal.DestinationConstants.crptToWindow; //windows
                    crReporBnx.Action = 1; //Imprime el reporte
                    //AIS-1182 NGONZALEZ
                    hwndPreviewWindow = API.USER.GetActiveWindow();
                    this.Cursor = Cursors.Default;
                    //AIS-1182 NGONZALEZ
                    while (API.USER.IsWindow(hwndPreviewWindow) != 0)
                    {
                        Application.DoEvents();
                    };
                }
                else
                {
                    crReporBnx.Destination = Crystal.DestinationConstants.crptToPrinter; //windows
                    crReporBnx.Action = 1; //Imprime el reporte

                }
                // Close the report
                crReporBnx.ReportFileName = CORVB.NULL_STRING;
                this.Cursor = Cursors.Default;
            }
            catch
            {
            }

            switch (Information.Err().Number)
            {
                case 0:  // el sistema esta oK 
                    break;
                default: //No hay conexion con Ruth marca cualquier error 
                    MessageBox.Show("Error Núm: " + Information.Err().Number.ToString() + "\r" + "Descrpción: " + Information.Err().Description, Application.ProductName);
                    //UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead. 
                    throw new Exception("Migration Exception: 'Resume Next' not supported");
                    break;
            }
        }

        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Borra el registro identificador del usuario         **
        //**                                                                        **
        //**                                                                        **
        //**       Paso de parámetros: numero de usuario,numero de reporte          **
        //**                                                                        **
        //**       Valor de Regreso: ninguno                                        **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 22ene99                                     **
        //**                                                                        **
        //****************************************************************************
        private void Borra_FrtReg(int iNoUsuario, int iNoRep)
        {

            CORVAR.pszgblsql = "DELETE MTCRPB01 WHERE rpb_no_usuario = " + iNoUsuario.ToString();
            //    pszgblSql = pszgblSql & " AND rpb_no_rep = " & iNoRep
            //    pszgblsql = pszgblsql & " AND rpb_centro_c = ''"
            //    pszgblsql = pszgblsql & " AND rpb_descrip = ''"

            if (CORPROC2.Modifica_Registro() != 0)
            {
            }
            else
            {
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

        }

        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Borra los registros del usurio                      **
        //**                                                                        **
        //**                                                                        **
        //**       Paso de parámetros: numero de reporte ejjecutado                 **
        //**                                                                        **
        //**       Valor de Regreso: ninguno                                         **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 22ene99                                     **
        //**                                                                        **
        //****************************************************************************

        private void Borra_No_Usuario(int iRepAnt)
        {

            this.Cursor = Cursors.WaitCursor;
            //borra el registro con el no de usuario asignado
            CORVAR.pszgblsql = "DELETE MTCRPB01 ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "WHERE rpb_no_usuario = " + miNoUsuario.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " AND rpb_no_rep = " + iRepAnt.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " AND rpb_corte_amd <> 0 ";

            if (CORPROC2.Modifica_Registro() != 0)
            {
                //    miNoUsuario = NULL_INTEGER
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

        }

        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Selecciona los registros dependiendo el nivel       **
        //**                                                                        **
        //**                                                                        **
        //**       Paso de parámetros: indice de la opción                          **
        //**                                                                        **
        //**       Valor de Regreso: ninguno                                        **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 22ene99                                     **
        //**                                                                        **
        //****************************************************************************
        private int Carga_Nivel(int iIndice)
        {
            string sNombre = String.Empty;
            int lNumero = 0;
            int iTempErr = 0;
            int iCont = 0;
            string sBanco = String.Empty;

            this.Cursor = Cursors.WaitCursor;
            iErr = CORCONST.OK;

            switch (iIndice)
            {
                case 1:
                    CORVAR.pszgblsql = "EXEC  spS_NIVEL_DGA ";

                    break;
                case 2:
                    CORVAR.pszgblsql = "EXEC  spS_NIVEL_Division ";
                    break;
                case 3:
                    CORVAR.pszgblsql = "EXEC  spS_NIVEL_SubDiv ";

                    break;
                case 4:
                    CORVAR.pszgblsql = "EXEC  spS_NIVEL_Sirh ";
                    break;
            }

            // si es diferente de banco
            if (iIndice != CORVB.NULL_INTEGER)
            {
                CORPROC2.Libera_Memoria(CORVAR.hgblConexion);

                if (CORPROC2.ObtieneRegistros(ref CORVAR.pszgblsql) != 0)
                {
                    iCont = CORVB.NULL_INTEGER;
                    cboGrupo.Items.Clear();
                    do
                    {
                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                        {

                            lNumero = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                            sNombre = VBSQL.SqlData(CORVAR.hgblConexion, 2);

                            if (lNumero != CORVB.NULL_INTEGER)
                            {
                                cboGrupo.Items.Add(StringsHelper.Format(lNumero, "000000") + "  " + sNombre);
                            }
                            iCont++;
                        }
                    }
                    while (VBSQL.SqlResults(CORVAR.hgblConexion) != 2);

                    //Colocamos a un grupo por default
                    if (cboGrupo.Items.Count != 0)
                    {
                        cboGrupo.SelectedIndex = CORVB.NULL_INTEGER;
                    }
                }
                else
                {
                    cboGrupo.Items.Clear();
                    this.Cursor = Cursors.Default;
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                CORPROC2.Libera_Memoria(CORVAR.hgblConexion);
            }
            else
            {
                cboGrupo.Items.Clear();
                sBanco = Obtiene_Bancos();
                cboGrupo.Items.Add(sBanco);
                if (cboGrupo.Items.Count != 0)
                {
                    cboGrupo.SelectedIndex = CORVB.NULL_INTEGER;
                }
            }
            this.Cursor = Cursors.Default;


            return 0;
        }

        //
        private void Genera_Reporte(ref  int iNoRep, ref  int iFecCorte, ref  int iTipo)
        {

            if (chkOpcion.CheckState == CheckState.Unchecked)
            {
                Asigna_Reporte(miNoUsuario, ref iNoRep, iFecCorte, iTipo);
            }
            else
            {
                //imprime todo desde el nivel que se encuentre hasta el nivel mas bajo
                Seleccion_General(miNoUsuario, ref iNoRep, iFecCorte, iTipo);
            }

        }




        private void Obtiene_Bus_Identi(int lIdentificador)
        {

            string sNombre = String.Empty;
            int lNumero = 0;
            int iTempErr = 0;
            int iCont = 0;
            int iIndice = 0;
            int i = 0;
            string sNivel = String.Empty;
            string sBanco = String.Empty;
            int lbanco = 0;
            int iPos = 0;
            string sCadena = String.Empty;


            this.Cursor = Cursors.WaitCursor;
            iErr = CORCONST.OK;

            //limpia el combo
            cboGrupo.Items.Clear();

            if (((lIdentificador >= 1000) && (lIdentificador <= 3999)) || ((lIdentificador >= 4900) && (lIdentificador <= 4999)))
            { //sirh
                if (optNivel[4].Checked)
                {
                    optNivel[4].Checked = false;
                }
                optNivel[4].Checked = true;
            }
            else if (((lIdentificador >= 7000) && (lIdentificador <= 7999)))
            {  //subdivision
                if (optNivel[3].Checked)
                {
                    optNivel[3].Checked = false;
                }
                optNivel[3].Checked = true;
            }
            else if (((lIdentificador >= 6000) && (lIdentificador <= 6999)))
            {  //division
                if (optNivel[2].Checked)
                {
                    optNivel[2].Checked = false;
                }
                optNivel[2].Checked = true;
            }
            else if (((lIdentificador >= 5500) && (lIdentificador <= 5999)))
            {  //area
                if (optNivel[1].Checked)
                {
                    optNivel[1].Checked = false;
                }
                optNivel[1].Checked = true;
            }
            else
            {
                sBanco = Obtiene_Bancos();
                if (sBanco == CORVB.NULL_STRING)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("No existe ese identificador...", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                i = (sBanco.Trim().IndexOf(' ') + 1);
                if (i != CORVB.NULL_INTEGER)
                {
                    lbanco = StringsHelper.IntValue(Strings.Mid(sBanco, 1, i));

                    if (lbanco != lIdentificador)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("No existe ese identificador...", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (optNivel[0].Checked)
                        {
                            optNivel[0].Checked = false;
                        }
                        optNivel[0].Checked = true;
                    }
                }

            }

            //buscamos en el combo el valor
            for (i = 0; i <= cboGrupo.Items.Count - 1; i++)
            {
                sCadena = VB6.GetItemString(cboGrupo, i);
                iPos = (sCadena.Trim().IndexOf(' ') + 1);
                if (Conversion.Val(Strings.Mid(sCadena.Trim(), 1, iPos)) != CORVB.NULL_INTEGER)
                {
                    lNumero = StringsHelper.IntValue(Strings.Mid(sCadena.Trim(), 1, iPos));
                    if (lNumero == lIdentificador)
                    {
                        cboGrupo.SelectedIndex = i;
                        break;
                    }
                }
            }

            this.Cursor = Cursors.Default;
        }





        private string Obtiene_Bancos()
        {
            //***** INICIO CODIGO NUEVO FSWBMX *****
            string result = String.Empty;
            int lBancoPref = 0;
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            int lBancoCve = 0;
            string pszBancoDes = String.Empty;
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "SELECT con_banco, con_ban_des FROM " + DB_SYB_CON + " ORDER BY con_banco"
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "SELECT con_pref, con_banco, con_ban_des FROM " + CORBD.DB_SYB_CON + " where con_pref = " + CORVAR.igblPref.ToString() + "and con_banco =" + CORVAR.igblBanco.ToString() + " ORDER BY con_banco";
            //***** FIN DE CODIGO NUEVO FSWBMX ****

            if (CORPROC2.Obtiene_Registros() != 0)
            {

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    //***** INICIO CODIGO ANTERIOR FSWBMX *****
                    //      lBancoCve = Val(SqlData(hgblConexion, FIRST_COL))
                    //      pszBancoDes = SqlData(hgblConexion, SECOND_COL)
                    //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                    //***** INICIO CODIGO NUEVO FSWBMX *****
                    lBancoPref = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL)));
                    lBancoCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SECOND_COL)));
                    pszBancoDes = VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.THIRD_COL);
                    //***** FIN DE CODIGO NUEVO FSWBMX *****
                };
                result = Conversion.Str(lBancoPref) + " " + Conversion.Str(lBancoCve) + " " + pszBancoDes;
            }
            else
            {
                result = CORVB.NULL_STRING;
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            return result;
        }


        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Ejecuta los stored
        //**                                                                        **
        //**                                                                        **
        //**       Paso de parámetros: numero de usuario, numero de reporte y sql   **
        //**                                                                        **
        //**       Valor de Regreso: ninguno                                        **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 22ene99                                     **
        //**                                                                        **
        //****************************************************************************
        private void Procesa_Reporte(int iNoUsuario, int iNoRep, ref  string pszgblsql)
        {
            int lValor = 0;
            string sDivision = String.Empty;
            int iSirh = 0;
            double dSalant = 0;
            double dfPag_abon = 0;
            double dComisiones = 0;
            double dInteres = 0;
            int iMes_venc = 0;
            double dCompras = 0;
            double dDispo = 0;
            double dPauseTime = 0;
            double dStart = 0;

            mbExisteReg = false;


            CORPROC2.Libera_Memoria(CORVAR.hgblConexion);

            if (CORPROC2.ObtieneRegistros(ref pszgblsql) != 0)
            {
                do
                {
                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {

                        lValor = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                        //muestra el valor procesando
                        switch (iNoRep)
                        {
                            case 1:
                                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "DGA: " + Conversion.Str(lValor);
                                break;
                            case 2:
                                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "División: " + Conversion.Str(lValor);
                                break;
                            case 3:
                                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Subdiv.: " + Conversion.Str(lValor);
                                break;
                            case 4:
                                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "SIRH: " + Conversion.Str(lValor);
                                break;
                            case 5:
                                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Procesando para : " + Conversion.Str(lValor);
                                break;
                        }
                        Application.DoEvents();

                        //si existen registros para el reporte
                        mbExisteReg = true;

                    }
                }
                while (VBSQL.SqlResults(CORVAR.hgblConexion) != 2);
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            //limpia el text de la mdi
            CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = CORVB.NULL_STRING;

            CORPROC2.Libera_Memoria(CORVAR.hgblConexion);

        }

        private void Valida_Datos()
        {


        }

        private void cboGrupo_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            int lEmpresas = 0;
            int iNivel = 0;


            if (optNivel[0].Checked)
            {
                iNivel = CORVB.NULL_INTEGER;
            }

            if (optNivel[1].Checked)
            {
                iNivel = 1;
            }

            if (optNivel[2].Checked)
            {
                iNivel = 2;
            }

            if (optNivel[3].Checked)
            {
                iNivel = 3;
            }

            if (optNivel[4].Checked)
            {
                iNivel = 4;
            }

            //  lEmpresas = Obten_Subnivel(iNivel)

            this.Cursor = Cursors.Default;

            if (iErr != CORCONST.OK)
            {
                //AIS-1182 NGONZALEZ
                //iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                flag = true;
            }

        }

        public bool flag = false;

        private void cmdAceptar_Click(Object eventSender, EventArgs eventArgs)
        {

            int iNoRep = 0;
            int iFecCorte = 0;
            string sMesCorte = String.Empty;
            int iTipo = 0;
            string sFecCorte = String.Empty;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (lGpoBnx != CORVB.NULL_INTEGER)
                {
                    //obtiene el dia de corte
                    CORVAR.pszgblsql = " SELECT pgs_dia_corte FROM MTCPGS01 ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "WHERE pgs_rep_prefijo =" + CORVAR.igblPref.ToString() + " and pgs_rep_banco =" + CORVAR.igblBanco.ToString();


                    if (CORPROC2.Obtiene_Registros() != 0)
                    {
                        if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                        {
                            CORVAR.iDiaCorte = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo obtener el dia de corte del sistema ", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        return;
                    }
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);


                    //obtiene la fecha de corte
                    sMesCorte = Strings.Mid(cboFecha.Text.Trim(), 1, cboFecha.Text.Trim().IndexOf(' ') + 1);
                    iFecCorte = CORPROC2.Obtiene_Mes_Numerico(sMesCorte);
                    sFecCorte = Conversion.Str(iFecCorte) + Conversion.Str(CORVAR.iDiaCorte);
                    iFecCorte = Convert.ToInt32(Conversion.Val(sFecCorte));
                    mlAñoCorte = Convert.ToInt32(Conversion.Val(Strings.Mid(cboFecha.Text.Trim(), (cboFecha.Text.Trim().IndexOf(' ') + 1) + 1)));


                    //Valida datos
                    Valida_Datos(); //valida datos está vacio FSWBMX

                    //obtiene el numero de reporte
                    if (optNivel[0].Checked)
                    {
                        iNoRep = 1;
                    }
                    else if (optNivel[1].Checked)
                    {
                        iNoRep = 2;
                    }
                    else if (optNivel[2].Checked)
                    {
                        iNoRep = 3;
                    }
                    else if (optNivel[3].Checked)
                    {
                        iNoRep = 4;
                    }
                    else if (optNivel[4].Checked)
                    {
                        iNoRep = 5;
                    }
                    else if (optNivel[5].Checked)
                    {
                        iNoRep = 5;
                    }

                    if (miNoUsuario != CORVB.NULL_INTEGER)
                    {
                        Borra_FrtReg(miNoUsuario, miNoRepAnt);
                        Borra_No_Usuario(miNoRepAnt);
                        miNoUsuario = CORVB.NULL_INTEGER;
                    }

                    //obtiene el tipo de reporte
                    if (optTipo[CORVB.NULL_INTEGER].Checked)
                    { //reporte general
                        iTipo = CORVB.NULL_INTEGER;
                    }
                    else
                    {
                        //reporte individual
                        iTipo = 1;
                    }

                    //asigna un numero de usuario
                    miNoUsuario = Asigna_Usuario(iNoRep);

                    //asigna el numero de reporte
                    miNoRepAnt = iNoRep;


                    //Genera Reporte
                    Genera_Reporte(ref iNoRep, ref iFecCorte, ref iTipo);
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("No existe el grupo del Banco", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(cmdAceptar_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }



        private void cmdAdd_Click(Object eventSender, EventArgs eventArgs)
        {
            //Pasa un Intermediario
            if (ListBoxHelper.GetSelectedIndex(lstEmpresas) >= CORVB.NULL_INTEGER)
            {
                lstSeleccion.Items.Add(VB6.GetItemString(lstEmpresas, ListBoxHelper.GetSelectedIndex(lstEmpresas)));
                lstEmpresas.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(lstEmpresas));
            }
            else
            {
                Interaction.Beep();
            }

        }

        private void cmdAll_Click(Object eventSender, EventArgs eventArgs)
        {
            //Pasa todos los Intermediarios
            while ((lstEmpresas.Items.Count > CORVB.NULL_INTEGER))
            {

                //verifica que no existean en la lista de seleccion

                lstEmpresas.SelectedIndex = CORVB.NULL_INTEGER;
                lstSeleccion.Items.Add(VB6.GetItemString(lstEmpresas, ListBoxHelper.GetSelectedIndex(lstEmpresas)));
                lstEmpresas.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(lstEmpresas));
            }
        }

        private void cmdDel_Click(Object eventSender, EventArgs eventArgs)
        {
            //Regresa un Intermediario
            if (ListBoxHelper.GetSelectedIndex(lstSeleccion) >= CORVB.NULL_INTEGER)
            {
                lstEmpresas.Items.Add(VB6.GetItemString(lstSeleccion, ListBoxHelper.GetSelectedIndex(lstSeleccion)));
                lstSeleccion.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(lstSeleccion));
            }
            else
            {
                Interaction.Beep();
            }

        }

        private void cmdDelAll_Click(Object eventSender, EventArgs eventArgs)
        {
            //Pasa todos los Intermediarios
            while ((lstSeleccion.Items.Count > CORVB.NULL_INTEGER))
            {

                lstSeleccion.SelectedIndex = CORVB.NULL_INTEGER;
                lstEmpresas.Items.Add(VB6.GetItemString(lstSeleccion, ListBoxHelper.GetSelectedIndex(lstSeleccion)));
                lstSeleccion.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(lstSeleccion));
            }

        }

        private void cmdSalir_Click(Object eventSender, EventArgs eventArgs)
        {
            //borra el numero de usuario y repoerte
            if (miNoUsuario != CORVB.NULL_INTEGER)
            {
                //borra el primer registro
                Borra_FrtReg(miNoUsuario, miNoRepAnt);
                Borra_No_Usuario(miNoRepAnt);
                miNoUsuario = CORVB.NULL_INTEGER;
                this.Cursor = Cursors.Default;
            }
            this.Close();
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            int iGrupos = 0;

            this.Cursor = Cursors.WaitCursor;

            iErr = CORCONST.OK;

            iLeft = Convert.ToInt32((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(Width))) / 2);
            iTop = Convert.ToInt32((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(Height))) / 2);

            this.SetBounds(Convert.ToInt32((float)VB6.TwipsToPixelsX(iLeft)), Convert.ToInt32((float)VB6.TwipsToPixelsY(iTop)), 0, 0, BoundsSpecified.X | BoundsSpecified.Y);
            this.Show();
            this.Refresh();

            this.Cursor = Cursors.WaitCursor;


            miNoUsuario = CORVB.NULL_INTEGER;
            txtIdentificador.Text = CORVB.NULL_INTEGER.ToString();

            optTipo_CheckedChanged(optTipo[0], new EventArgs());

            //Llena el combo box con los meses disponibles en El Histórico
            ComboBox tempRefParam = cboFecha;
            CORPROC.Obten_Meses(this, ref tempRefParam);
            cboFecha = tempRefParam;

            //obtiene el banco y area
            do
            {
                iGrupos = Carga_Nivel(CORVB.NULL_INTEGER); //muestra los del banco
                if (iErr == CORCONST.OK)
                {
                    if (cboGrupo.Items.Count == CORVB.NULL_INTEGER)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("No existen Grupos en catálogo ", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Cursor = Cursors.WaitCursor;
                        break;
                    }
                }
                else
                {
                    //AIS-1182 NGONZALEZ
                    //iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                    flag = true;
                    break;
                }
            }
            while ((cboGrupo.Items.Count | ((iErr != CORCONST.OK) ? -1 : 0)) == 0);

            //obtiene el numero de grupo de los ejecutivos banamex
            CORVAR.pszgblsql = "SELECT gpb_gpo_num FROM MTCGPB01 ";
            if (CORPROC2.Obtiene_Registros() != 0)
            {

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    lGpoBnx = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                };
            }
            else
            {
                MessageBox.Show("No existe el grupo del Banco", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);





            this.Cursor = Cursors.Default;
        }




        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Carga las areas  de un determinado banco     -      **
        //**                                                                        **
        //**                                                                        **
        //**       Paso de parámetros: Ninguno                                      **
        //**                                                                        **
        //**       Valor de Regreso:                                                **
        //**           True: Si existieron empresas                                 **
        //**           False: Si no los hubo                                        **
        //**                                                                        **
        //**                                                                        **
        //**                                                                        **
        //****************************************************************************
        //UPGRADE_NOTE: (7001) The following declaration (Obten_Subnivel) seems to be dead code
        //private int Obten_Subnivel( int iSubNivel)
        //{
        //
        //int result = 0;
        //int iTempErr = 0; //Control local
        //string sNombre = String.Empty;
        //int iNumero = 0;
        //int iCont = 0;
        //
        //this.Cursor = Cursors.WaitCursor;
        //iErr = CORCONST.OK;
        //int iNumeroPro = Convert.ToInt32(Conversion.Val(cboGrupo.Text.Substring(0, Math.Min(cboGrupo.Text.Length, 6))));
        //switch(iSubNivel)
        //{
        //case 0 : 
        //CORVAR.pszgblsql = "SELECT  DISTINCT(bnx_id_dga),bde_nombre "; 
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " FROM MTCBNX01, MTCBDE01"; 
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE bnx_id_banco = " + iNumeroPro.ToString(); 
        //break;
        //case 1 : 
        //CORVAR.pszgblsql = "SELECT  DISTINCT(bnx_id_division),bde_nombre "; 
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " FROM MTCBNX01, MTCBDE01"; 
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE bnx_id_dga = " + iNumeroPro.ToString(); 
        //break;
        //case 2 : 
        //CORVAR.pszgblsql = "SELECT  DISTINCT(bnx_id_subdivision),bde_nombre "; 
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " FROM MTCBNX01, MTCBDE01"; 
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE bnx_id_division = " + iNumeroPro.ToString(); 
        //break;
        //case 3 : 
        //CORVAR.pszgblsql = "SELECT  DISTINCT(bnx_id_sirh),bde_nombre "; 
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " FROM MTCBNX01, MTCBDE01"; 
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE bnx_id_subdivision = " + iNumeroPro.ToString(); 
        //break;
        //case 4 : 
        //lstEmpresas.Items.Clear(); 
        //return result;
        //}
        //
        //if (CORPROC2.Obtiene_Registros() != 0)
        //{
        //lstEmpresas.Items.Clear();
        //iCont = CORVB.NULL_INTEGER;
        //
        //while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
        //{
        //iNumero = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
        //sNombre = VBSQL.SqlData(CORVAR.hgblConexion, 2);
        //lstEmpresas.Items.Add(StringsHelper.Format(iNumero, "000000") + "   " + sNombre);
        //iCont++;
        //};
        //
        //if (lstEmpresas.Items.Count != 0)
        //{
        //lstEmpresas.SelectedIndex = CORVB.NULL_INTEGER;
        //result = -1;
        //} else
        //{
        //result = 0;
        //}
        //} else
        //{
        //si no obtiene empresas limpia el control
        //lstEmpresas.Items.Clear();
        //}
        //
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //
        //
        //this.Cursor = Cursors.Default;
        //
        //return result;
        //}


        private void CORCTBNX_Closed(Object eventSender, EventArgs eventArgs)
        {
            //borra el numero de usuario y repoerte
            if (miNoUsuario != CORVB.NULL_INTEGER)
            {

                //borra el primer registro
                Borra_FrtReg(miNoUsuario, miNoRepAnt);

                Borra_No_Usuario(miNoRepAnt);
                miNoUsuario = CORVB.NULL_INTEGER;


            }

            VBSQL.subCanConRec(ref intCont);

            this.Close();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void lstEmpresas_DoubleClick(Object eventSender, EventArgs eventArgs)
        {
            cmdAdd_Click(cmdAdd, new EventArgs());

        }


        private void lstSeleccion_DoubleClick(Object eventSender, EventArgs eventArgs)
        {
            cmdDel_Click(cmdDel, new EventArgs());
        }


        private bool isInitializingComponent;
        private void optNivel_CheckedChanged(Object eventSender, EventArgs eventArgs)
        {
            if (isInitializingComponent)
            {
                return;
            }
            if (((RadioButton)eventSender).Checked)
            {

                txtIdentificador.Text = CORVB.NULL_INTEGER.ToString();

                if (optNivel[CORVB.NULL_INTEGER].Checked)
                {
                    Carga_Nivel(CORVB.NULL_INTEGER);
                }

                if (optNivel[1].Checked)
                {
                    Carga_Nivel(1);
                }

                if (optNivel[2].Checked)
                {
                    Carga_Nivel(2);
                }

                if (optNivel[3].Checked)
                {
                    Carga_Nivel(3);
                }

                if (optNivel[4].Checked)
                {
                    Carga_Nivel(4);
                }

            }
        }


        private void optTipo_CheckedChanged(Object eventSender, EventArgs eventArgs)
        {
            if (isInitializingComponent)
            {
                return;
            }
            if (((RadioButton)eventSender).Checked)
            {

                if (optTipo[0].Checked)
                {
                    lstEmpresas.Enabled = false;
                    cmdAll.Enabled = false;
                    cmdAdd.Enabled = false;
                    cmdDelAll.Enabled = false;
                    cmdDel.Enabled = false;
                    lstSeleccion.Enabled = false;
                }
                else
                {
                    lstEmpresas.Enabled = true;
                    cmdAll.Enabled = true;
                    cmdAdd.Enabled = true;
                    cmdDelAll.Enabled = true;
                    cmdDel.Enabled = true;
                    lstSeleccion.Enabled = true;
                }
            }
        }


        private void txtIdentificador_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;

            if ((KeyAscii < 48 || KeyAscii > 57) && KeyAscii != 8)
            {
                //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
                KeyAscii = CORVB.NULL_INTEGER;
            }

            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void txtIdentificador_Leave(Object eventSender, EventArgs eventArgs)
        {
            if (txtIdentificador.Text == CORVB.NULL_STRING)
            {
                txtIdentificador.Text = CORVB.NULL_INTEGER.ToString();
            }
            if (Double.Parse(txtIdentificador.Text) != CORVB.NULL_INTEGER)
            {
                //REALIZA la busqueda por el identificador que desea
                Obtiene_Bus_Identi(Convert.ToInt32(Conversion.Val(txtIdentificador.Text)));
            }
        }
    }
}