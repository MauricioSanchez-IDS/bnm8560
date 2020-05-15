using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Globalization; 
using System.Windows.Forms;
using System.Configuration;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;
namespace TCc430
{
	internal class clsPerfil
	{
	
		private struct TPantalla
		{
			public string sForma;
			public string sControl;
			public static TPantalla CreateInstance()
			{
					TPantalla result = new TPantalla();
					result.sForma = String.Empty;
					result.sControl = String.Empty;
					return result;
			}
		}
		private struct TNivelMaximo
		{
			public string sModulo;
			public string sNivel;
			public static TNivelMaximo CreateInstance()
			{
					TNivelMaximo result = new TNivelMaximo();
					result.sModulo = String.Empty;
					result.sNivel = String.Empty;
					return result;
			}
		}
		
		private struct TModulos
		{
			public string sModulo;
			public string sNivel;
			public string sForma;
			public string sControl;
			public static TModulos CreateInstance()
			{
					TModulos result = new TModulos();
					result.sModulo = String.Empty;
					result.sNivel = String.Empty;
					result.sForma = String.Empty;
					result.sControl = String.Empty;
					return result;
			}
		}
		//AIS-1178 NGONZALEZ
		private TNivelMaximo[] typmGrupoModulos;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});;
		//AIS-1178 NGONZALEZ
		private TPantalla[] typmPantalla;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});;
		//AIS-1178 NGONZALEZ
		private TPantalla[] typmPantallaInh;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});;
		//AIS-1178 NGONZALEZ
		private TModulos[] typmModulosFormas;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});;
		private string[] smModulosAusentes = null;
		private int ilDigitosNombre = 4;
		private int ilDigitosNumero = 4;
		private int ilDigitosModulo = 5;
		private int ilDigitosNivel = 2;
		private int ilDigitosPrefijo = 80;
		private string encripcion = String.Empty;
        // Dialogos a ser llamados en S041
		//const string firmaEncripcion3Des = "70020";
        const string firmaEncripcion3Des = "70022";
		//const string firmaEncripcion3DesModulos = "70025";
        const string firmaEncripcion3DesModulos = "70027";
		const string desfirma = "70030";

		public string NominaPasswordS
		{
			set
			{
				string slPerfil = String.Empty;
				//string mvarNominaPasswordS = value.Trim();
                //if (fncFirma(mvarNominaPasswordS, ref slPerfil))
                //{
                    prModulosFormas();
                    prGruposModulos_SSS();	
                    prIniciaizaPantalla();
					prEliminaPrefijo(ref slPerfil);
					prEstablecePerfil(slPerfil);
                //}
			}
		}
		
		public string ModulosPermisosS
		{
			set
			{
				string slPerfil = value.Trim();
				prModulosFormas();
				prGruposModulos_SSS();
				prIniciaizaPantalla();
				prEliminaPrefijo(ref slPerfil);
				prEstablecePerfil(slPerfil);
			}
		}
		
		private void  prIniciaizaPantalla()
		{
			//UPGRADE_WARNING: (1042) Array typmPantalla may need to have individual elements initialized.
			typmPantalla = new TPantalla[1];
			//UPGRADE_WARNING: (1042) Array typmPantallaInh may need to have individual elements initialized.
			typmPantallaInh = new TPantalla[1];
		}
		private void  prEliminaPrefijo(ref  string slPerfil)
		{
			//Elimina todo lo que viene antes del puesto incluyendo "seg:" y
			//los ochenta caracteres para mensajes
			int ilPosicionInicial = (slPerfil.IndexOf("SEG:") + 1);
			if (ilPosicionInicial < 1)
			{
				return;
			}
			ilPosicionInicial += 84;
			if (ilPosicionInicial >= slPerfil.Length)
			{
				return;
			}
			slPerfil = slPerfil.Substring(slPerfil.Length - Math.Min(slPerfil.Length, slPerfil.Length - (ilPosicionInicial - 1)));
			int ilUltimoDigito = slPerfil.Length;
			double dbNumericTemp = 0;
			while (! (Double.TryParse(Strings.Mid(slPerfil, ilUltimoDigito, 1), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp)))
				{
				
					ilUltimoDigito--;
				}
			if (ilUltimoDigito < slPerfil.Length)
			{
				slPerfil = slPerfil.Substring(0, Math.Min(slPerfil.Length, ilUltimoDigito));
			}
		}
		private void  prEstablecePerfil( string slPerfil)
		{
			string slModulo = String.Empty;
			string slNivel = String.Empty;
			int ilInicio = 0;
			if (ilDigitosNombre < 1)
			{
				MessageBox.Show("Error en el numero de digitos del nombre", Application.ProductName);
				return;
			}
			if (ilDigitosNumero < 1)
			{
				MessageBox.Show("Error en el número de digitos de parametros", Application.ProductName);
				return;
			}
			if (ilDigitosModulo < 1)
			{
				MessageBox.Show("Error en el número de digitos de modulos ", Application.ProductName);
				return;
			}
			if (ilDigitosNivel < 1)
			{
				MessageBox.Show("Error en el número de digitos de niveles", Application.ProductName);
				return;
			}
			if (slPerfil.Length < (ilDigitosNombre + ilDigitosNumero))
			{
				//MessageBox.Show("Error en el numero de parametros", Application.ProductName);
				return;
			}
			string slTemporal = Strings.Mid(slPerfil, ilDigitosNombre + 1, ilDigitosNumero);
			int ilNumeroControles = Int32.Parse(slTemporal);
			int ilNumeroDigitos = ilNumeroControles * (ilDigitosModulo + ilDigitosNivel);
			if (ilNumeroDigitos != (slPerfil.Length - ilDigitosNombre - ilDigitosNumero))
			{
				MessageBox.Show("Error en el Perfil de entrada", Application.ProductName);
				return;
			}
			int ilIntervalo = ilDigitosModulo + ilDigitosNivel;
			string slModulosNiveles = slPerfil.Substring(slPerfil.Length - Math.Min(slPerfil.Length, slPerfil.Length - ilDigitosNombre - ilDigitosNumero));
			for (int ilContador = 1; ilContador <= ilNumeroControles; ilContador++)
			{
				ilInicio = ((ilContador - 1) * (ilIntervalo)) + 1;
				slModulo = Strings.Mid(slModulosNiveles, ilInicio, ilDigitosModulo);
				slNivel = Strings.Mid(slModulosNiveles, ilInicio + ilDigitosModulo, ilDigitosNivel);
				//Debug.Print slModulo
				prRegistraModuloNivelGrupo(slModulo, slNivel);
				
			}
			prLlenaInhabilitados();
		}
		private void  prRegistraModuloNivelGrupo( string slModulo,  string slNivel)
		{
			//prRegistraModuloNivel slModulo, slNivel
			string slModuloTemp = String.Empty;
			string slNivelTemp = String.Empty;
			int ilNumRenglones = typmGrupoModulos.GetUpperBound(0);
			for (int ilContador = 1; ilContador <= ilNumRenglones; ilContador++)
			{
				if (typmGrupoModulos[ilContador].sModulo == slModulo)
				{
					slModuloTemp = typmGrupoModulos[ilContador].sModulo;
					slNivelTemp = typmGrupoModulos[ilContador].sNivel;
					prRegistraModuloNivel(ref slModuloTemp, ref slNivelTemp);
					if (typmGrupoModulos[ilContador].sNivel == slNivel)
					{
						return;
					}
				}
			}
		}
		private bool fncEnHabilitados( string sForma,  string sControl,  TPantalla[] typmPantalla)
		{
			int ilNumRows = typmPantalla.GetUpperBound(0);
			for (int ilContador = 1; ilContador <= ilNumRows; ilContador++)
			{
				if (typmPantalla[ilContador].sForma == sForma && typmPantalla[ilContador].sControl == sControl)
				{
					return true;
				}
			}
			return false;
		}
		
		
		private object prLlenaInhabilitados()
		{
			int ilContador2 = 0;
			int ilNumRowsInHabilitados = 0;
			int ilNumRows = typmModulosFormas.GetUpperBound(0);
			//FSWB NR TESTER (Si se comentariza el for completo Deshabilita módulos de acuerdo al perfil)
			for (int ilContador1 = 1; ilContador1 <= ilNumRows; ilContador1++)
			{
				if (! fncEnHabilitados(typmModulosFormas[ilContador1].sForma, typmModulosFormas[ilContador1].sControl, typmPantalla))
				{
					ilNumRowsInHabilitados = typmPantallaInh.GetUpperBound(0);
					ilNumRowsInHabilitados++;
					//UPGRADE_WARNING: (1042) Array typmPantallaInh may need to have individual elements initialized.
					typmPantallaInh = ArraysHelper.RedimPreserve<TPantalla[]>(typmPantallaInh, new int[]{ilNumRowsInHabilitados + 1});
					typmPantallaInh[ilNumRowsInHabilitados].sForma = typmModulosFormas[ilContador1].sForma;
					typmPantallaInh[ilNumRowsInHabilitados].sControl = typmModulosFormas[ilContador1].sControl;
				}
			}
			return null;
		}
		private bool fncConsiderado( string slModulo,  string slNivel,  TModulos[] typmModulosForm)
		{
			//La función devuelve verdadero en caso de que el modulo-nivel ya se encuentre registrado
			//en typmModulosFormas, en cualquer otro caso devuelve falso.
			int ilNumeroElementos = typmModulosForm.GetUpperBound(0);
			for (int ilContador = 1; ilContador <= ilNumeroElementos; ilContador++)
			{
				if (typmModulosForm[ilContador].sModulo == slModulo && typmModulosForm[ilContador].sNivel == slNivel)
				{
					return true;
				}
			}
			return false;
		}
		private bool fncNoSeEncuentraB( string slForma,  string slControl,  TPantalla[] typmPant)
		{
			//El Desarrollo de los elementos
			int ilNumRegistros = typmPant.GetUpperBound(0);
			for (int ilContador = 1; ilContador <= ilNumRegistros; ilContador++)
			{
				if (typmPant[ilContador].sForma == slForma && typmPant[ilContador].sControl == slControl)
				{
					return false;
				}
			}
			return true;
		}
		
		private void  prRegistraModulos( string slModulo,  string slNivel,  TModulos[] typmModulosForm, ref  TPantalla[] typmPant)
		{
			//El procedimiento prRegistraModulos introduce slModulo y slNivel dentro del arreglo typmPant
			int ilNumRegistros = 0;
			string slForma = String.Empty;
			string slControl = String.Empty;
			int ilNumModulos = typmModulosForm.GetUpperBound(0);
			for (int ilContador = 1; ilContador <= ilNumModulos; ilContador++)
			{
				if (typmModulosForm[ilContador].sModulo == slModulo && typmModulosForm[ilContador].sNivel == slNivel)
				{
					slForma = typmModulosForm[ilContador].sForma;
					slControl = typmModulosForm[ilContador].sControl;
					if (fncNoSeEncuentraB(slForma, slControl, typmPant))
					{
						ilNumRegistros = typmPant.GetUpperBound(0);
						ilNumRegistros++;
						//UPGRADE_WARNING: (1042) Array typmPant may need to have individual elements initialized.
						typmPant = ArraysHelper.RedimPreserve<TPantalla[]>(typmPant, new int[]{ilNumRegistros + 1});
						typmPant[ilNumRegistros].sForma = slForma;
						typmPant[ilNumRegistros].sControl = slControl;
					}
				}
			}
			
			
		}
		private void  prRegistraModuloNivel(ref  string slModulo, ref  string slNivel)
		{
			if (fncConsiderado(slModulo, slNivel, typmModulosFormas))
			{
				TPantalla[] tempRefParam = typmPantalla;
				prRegistraModulos(slModulo, slNivel, typmModulosFormas, ref tempRefParam);
				typmPantalla = tempRefParam;
				
			} else
			{
				//prRegistraModulos slModulo, slNivel, typmModulosFormas, typmPantallaInh
			}
			
			//Debug.Print "*********************"
			//Debug.Print slModulo
			//Debug.Print slNivel
		}
		//Private Sub ps_imprime_pantalla(typmPant() As TPantalla)
		//Dim i As Integer
		//For i = 1 To UBound(typmPant)
		//    Debug.Print "*********************************************************************************"
		//    Debug.Print typmPant(i).sForma
		//    Debug.Print typmPant(i).sControl
		//Next
		//End Sub
		private void  prModulosFormasDet( string sForma,  string sControl,  string sModulo,  string sNivel, ref  TModulos[] typmModulosFormasDet)
		{
			int ilNumeroElementos = typmModulosFormasDet.GetUpperBound(0);
			ilNumeroElementos++;
			//UPGRADE_WARNING: (1042) Array typmModulosFormasDet may need to have individual elements initialized.
			typmModulosFormasDet = ArraysHelper.RedimPreserve<TModulos[]>(typmModulosFormasDet, new int[]{ilNumeroElementos + 1});
			typmModulosFormasDet[ilNumeroElementos].sForma = sForma;
			typmModulosFormasDet[ilNumeroElementos].sControl = sControl;
			typmModulosFormasDet[ilNumeroElementos].sModulo = sModulo;
			typmModulosFormasDet[ilNumeroElementos].sNivel = sNivel;
		}
		private void  prModulosFormas()
		{
            //Hace una relacion de que modulos se encuentran relacionados con que formas
            //y que niveles con que controles
            typmModulosFormas = new TModulos[1];

            //string slNivel = "10";
            string slNivel = string.Empty;
            string _slNivel = string.Empty;
            string sFacultad = string.Empty;
            string sLiminf = string.Empty;
            string sLimsup = string.Empty;
            string slModulo = string.Empty;

            //1 Consulta de reporte accion cycle
            slModulo = "40021";

            sFacultad = CargaModulos(slModulo);

            if (sFacultad != "")
            {
                _slNivel = sFacultad.Substring(5, 2);
                sLiminf = sFacultad.Substring(7, 6);
                sLimsup = sFacultad.Substring(13, 6);
                slNivel = "10";
                if (Convert.ToInt32(_slNivel) == Convert.ToInt32(slNivel)) // NIVEL 10
                {
                    prModulosFormasDet("CORMDIBN", "mnu_account_cycle", slModulo, slNivel, ref typmModulosFormas);
                    //'HABILITA CONSULTA
                    //prModulosFormasDet "CORMDIBN", "IDM_CTA", slModulo, slNivel, typmModulosFormas
                    prModulosFormasDet("CORMDIBN", "IDM_CON", slModulo, slNivel, ref typmModulosFormas); // 1 concentrado
                    prModulosFormasDet("CORMDIBN", "IDM_CEM", slModulo, slNivel, ref typmModulosFormas); // 2 Consulta de reporte grupo empresa
                    prModulosFormasDet("CORMDIBN", "IDM_CEJ", slModulo, slNivel, ref typmModulosFormas); // 3 consulta de reporte empresa ejecutivo
                    prModulosFormasDet("CORMDIBN", "IDM_DET", slModulo, slNivel, ref typmModulosFormas); // Detalle
                    prModulosFormasDet("CORMDIBN", "IDM_ATR", slModulo, slNivel, ref typmModulosFormas); // 4 reporte de atrasos por ejecutivo
                    prModulosFormasDet("CORMDIBN", "IDM_DEJ", slModulo, slNivel, ref typmModulosFormas); // 5 reporte de detalle de ejecutivos bnx
                    prModulosFormasDet("CORMDIBN", "IDM_AFI", slModulo, slNivel, ref typmModulosFormas); // 6 reporte de empresas afilidadas
                    prModulosFormasDet("CORMDIBN", "IDM_OPC", slModulo, slNivel, ref typmModulosFormas); // Opciones
                    prModulosFormasDet("CORMDIBN", "IDM_EXC", slModulo, slNivel, ref typmModulosFormas); // 7 exportar report7es a excel
                    prModulosFormasDet("CORMDIBN", "IDM_FMT", slModulo, slNivel, ref typmModulosFormas); // 8 Exportar reportes a formato fijo
                    prModulosFormasDet("CORMDIBN", "IDM_TXT", slModulo, slNivel, ref typmModulosFormas); // 9 exportar reportes a texto
                    prModulosFormasDet("CORMDIBN", "IDM_CFG", slModulo, slNivel, ref typmModulosFormas); //10 configurar impresora
                    prModulosFormasDet("CORMDIBN", "IDM_EER", slModulo, slNivel, ref typmModulosFormas); //11 consulta de enio e reportes por intelar
                    prModulosFormasDet("CORMDIBN", "IDM_REN", slModulo, slNivel, ref typmModulosFormas); //12 consulta de reporte de rentalbilidad
                    prModulosFormasDet("CORMDIBN", "IDM_ANA", slModulo, slNivel, ref typmModulosFormas); //13 reporte por consumos por giro
                    prModulosFormasDet("CORMDIBN", "mnu_account_cycle", slModulo, slNivel, ref typmModulosFormas);
                }
            }

            slModulo = "40022";

            sFacultad = CargaModulos(slModulo);
            if (sFacultad != "")
            {
                _slNivel = sFacultad.Substring(5, 2);
                sLiminf = sFacultad.Substring(7, 6);
                sLimsup = sFacultad.Substring(13, 6);
                slNivel = "15";
                if (Convert.ToInt32(_slNivel) == Convert.ToInt32(slNivel)) // NIVEL 15
                {
                    prModulosFormasDet("frmSBFEmpresa", "cmdSBFvobo", slModulo, slNivel, ref typmModulosFormas); //14 registrar la validacion del archivo diario sb
                    prModulosFormasDet("frmSBFEmpresa", "cmdSBFerror", slModulo, slNivel, ref typmModulosFormas); //15 registrar rechazo de archivo diario sbf
                    prModulosFormasDet("CORMDIBN", "mnu_envio_sbf", slModulo, slNivel, ref typmModulosFormas); //ENVIO SBF
                    prModulosFormasDet("CORMDIBN", "mnu_diario_sbf", slModulo, slNivel, ref typmModulosFormas); //16 registrar validacion de archivo diario por corte
                    prModulosFormasDet("CORMDIBN", "mnu_corte_sbf", slModulo, slNivel, ref typmModulosFormas); //17 registrar rech2azo de archivo por corte sbf
                }
            }

            slModulo = "40023";

            sFacultad = CargaModulos(slModulo);
            if (sFacultad != "")
            {
                _slNivel = sFacultad.Substring(5, 2);
                sLiminf = sFacultad.Substring(7, 6);
                sLimsup = sFacultad.Substring(13, 6);
                slNivel = "10";
                if (Convert.ToInt32(_slNivel) == Convert.ToInt32(slNivel)) // NIVEL 10 
                {
                    prModulosFormasDet("frm_men_rep", "ID_CEE_CON_PB", slModulo, slNivel, ref typmModulosFormas); // consulta de reportes
                    prModulosFormasDet("CORCTGRU", "ID_CGR_CON_PB", slModulo, slNivel, ref typmModulosFormas);//18 cosulta de cororativos
                    prModulosFormasDet("CORCTEMP", "ID_CEM_CON_PB", slModulo, slNivel, ref typmModulosFormas); //19 consulta de empresas
                    prModulosFormasDet("CORCTESTRUCT2", "ID_EST_CON_PB", slModulo, slNivel, ref typmModulosFormas); //20 consulta de estructuras jerarquicas
                    prModulosFormasDet("CORCTESTRUCT2", "ID_EST_EMPA_PB", slModulo, slNivel, ref typmModulosFormas); //21 consultar empresas asigadas a estructuras
                    prModulosFormasDet("CORMNPAR", "ID_PAR_CAN_PB", slModulo, slNivel, ref typmModulosFormas); //descomenta yuria 12/10/06 //'22 consulta de productos
                    //prModulosFormasDet "CORMNPAR", "ID_PAR_ACE_PB", slModulo, slNivel, typmModulosFormas comenta yuria 12/10/06 //22i consulta de productos
                    prModulosFormasDet("CORCTEJE", "ID_CEE_CON_PB", slModulo, slNivel, ref typmModulosFormas); //23
                    prModulosFormasDet("CORCTEJE", "ID_CEE_CONS111_PB", slModulo, slNivel, ref typmModulosFormas); //24 consulta de tarjetahabiente al s211
                    prModulosFormasDet("CORCTUNI", "ID_CEE_CON_PB", slModulo, slNivel, ref typmModulosFormas); //25 consulta de unidades
                    prModulosFormasDet("CORCTUNI", "ID_CEE_CON_TARJ", slModulo, slNivel, ref typmModulosFormas); //26 consulta de ctas a sig a unidad
                }

                slNivel = "15";
                if (Convert.ToInt32(_slNivel) == Convert.ToInt32(slNivel))   // NIVEL 15
                {
                    prModulosFormasDet("CORCTEJB", "ID_CEB_CON_PB", slModulo, slNivel, ref typmModulosFormas); //27 consulta de ejecutivos bnx
                }

                slNivel = "20";
                if (Convert.ToInt32(_slNivel) == Convert.ToInt32(slNivel))  // NIVEL 20
                {
                    //prModulosFormasDet "CORMDIBN", "IDM_CAT", slModulo, slNivel, typmModulosFormas//'menu archivo
                    prModulosFormasDet("frm_men_rep", "ID_CEE_CAM_PB", slModulo, slNivel, ref typmModulosFormas); //Asignación de reportes ID_CEE_CAM_PB
                    prModulosFormasDet("CORMDIBN", "IDM_CCI", slModulo, slNivel, ref typmModulosFormas); //28o  activar reportes cci
                    prModulosFormasDet("MTCBRCCI", "cmdAceptar", slModulo, slNivel, ref typmModulosFormas); //28 activar reportes cci
                    prModulosFormasDet("MTCBRCCI", "cmdNoGen", slModulo, slNivel, ref typmModulosFormas); //29 desactivar reportes cci
                    prModulosFormasDet("CORCTGRU", "ID_CGR_ALT_PB", slModulo, slNivel, ref typmModulosFormas); //30 alta de corporativos
                    prModulosFormasDet("CORCTGRU", "ID_CGR_BAJ_PB", slModulo, slNivel, ref typmModulosFormas); //31 baja de corporativos
                    prModulosFormasDet("CORCTGRU", "ID_CGR_CAM_PB", slModulo, slNivel, ref typmModulosFormas); //32 modificacion de corporativos
                    //'33 envio de cambios pendientes
                    //prModulosFormasDet "frmEnvioLimCred", "cmdEnviaCred", slModulo, slNivel, typmModulosFormas
                    prModulosFormasDet("CORCTEJB", "ID_CEB_ALT_PB", slModulo, slNivel, ref typmModulosFormas); //34 alta de ejecutivos banamex
                    prModulosFormasDet("CORCTEJB", "ID_CEB_BAJ_PB", slModulo, slNivel, ref typmModulosFormas); //35 baja de ejecutivos banamex
                    prModulosFormasDet("CORCTEJB", "ID_CEB_CAM_PB", slModulo, slNivel, ref typmModulosFormas); //36 modificacion de ejecutivos banamex
                    prModulosFormasDet("CORCTESTRUCT2", "ID_EST_ALT_PB", slModulo, slNivel, ref typmModulosFormas); //37 alta de estructuras jerarquicas
                    prModulosFormasDet("CORCTESTRUCT2", "ID_EST_BAJ_PB", slModulo, slNivel, ref typmModulosFormas); //38 baja de estructuras jerarquicas
                    prModulosFormasDet("CORCTESTRUCT2", "ID_EST_CAM_PB", slModulo, slNivel, ref typmModulosFormas); //39 modificacion de estructuras jerarquicas
                    prModulosFormasDet("CORCTESTRUCT2", "ID_EST_CAT_PB", slModulo, slNivel, ref typmModulosFormas); //40 asignar categorias a estructuras jerarquicas
                    prModulosFormasDet("CORMNPAR", "FSW_Bco_Alta", slModulo, slNivel, ref typmModulosFormas); //41 alta producto
                    prModulosFormasDet("CORMNPAR", "Fsw_Bco_Baja", slModulo, slNivel, ref typmModulosFormas); //42 baja producto
                    prModulosFormasDet("CORMNPAR", "ID_PAR_ACE_PB", slModulo, slNivel, ref typmModulosFormas); // agrega yuria 12/10/06 //'43 modifica producto no tiene boton de bajas
                    //prModulosFormasDet "CORMNPAR", "", slModulo, slNivel, typmModulosFormas
                    prModulosFormasDet("CORCTUNI", "ID_CEE_ALT_PB", slModulo, slNivel, ref typmModulosFormas); //44 alta de unidades
                    prModulosFormasDet("CORCTUNI", "ID_CEE_BAJ_PB", slModulo, slNivel, ref typmModulosFormas); //45 baja de unidades
                    prModulosFormasDet("CORCTUNI", "ID_CEE_CAM_PB", slModulo, slNivel, ref typmModulosFormas); //46 modificacion de unidades
                }
            }
            slModulo = "40024";

            sFacultad = CargaModulos(slModulo);
            if (sFacultad != "")
            {
                _slNivel = sFacultad.Substring(5, 2);
                sLiminf = sFacultad.Substring(7, 6);
                sLimsup = sFacultad.Substring(13, 6);
                slNivel = "10";
                if (Convert.ToInt32(_slNivel) == Convert.ToInt32(slNivel))  // NIVEL 10
                {
                    //prModulosFormasDet "frmEnvioLimCred", "cmdEnviaCred", slModulo, slNivel, typmModulosFormas //'47o envio limite de credito
                    prModulosFormasDet("CORCTEMP", "ID_CEM_CAM_PB", slModulo, slNivel, ref typmModulosFormas); //47 cambio de empresas
                    prModulosFormasDet("CORCTEMP", "ID_CEM_CMAS_PB", slModulo, slNivel, ref typmModulosFormas); //48 cambio masivo de empresas
                    prModulosFormasDet("CORCTEJE", "ID_CEE_ALT_PB", slModulo, slNivel, ref typmModulosFormas); //49 alta de tarjetahabientes
                    prModulosFormasDet("CORCTEJE", "ID_CEE_CAM_PB", slModulo, slNivel, ref typmModulosFormas); //50 modificar tarjetahabientes
                    prModulosFormasDet("CORCTEJE", "cmdAltasMasivas", slModulo, slNivel, ref typmModulosFormas); //51 alta masivas de tarjetahabientes
                    prModulosFormasDet("CORCTEJE", "cmdConsMasivas", slModulo, slNivel, ref typmModulosFormas); //52
                    prModulosFormasDet("CORCTEJE", "cmdReenvios", slModulo, slNivel, ref typmModulosFormas); //53 reenvios de altas pendientes
                    prModulosFormasDet("frmEnvioLimCred", "cmdEliminar", slModulo, slNivel, ref typmModulosFormas); //47o envio limite de credito
                }
                slNivel = "15";
                if (Convert.ToInt32(_slNivel) == Convert.ToInt32(slNivel))  // NIVEL 10  // NIVEL 15
                {
                    prModulosFormasDet("CORCTEMP", "ID_CEM_ALT_PB", slModulo, slNivel, ref typmModulosFormas); //54 alta de empresas
                }
            }
		}

        private string CargaModulos(string slModulo)
        {
            string valor = String.Empty;
            
            string _url = ConfigurationManager.AppSettings["_url"];
            string _action = ConfigurationManager.AppSettings["_action_f"];

            valor = mdlSeguridad.MFacultades(slModulo, _url, _action);

            return valor;       
        }

        //private void  prGruposModulos()
        //{
        //    //Se almacenan todos los modulos y los niveles dentro del arreglo typmGrupoModulos
        //    //grupados por modulo y ordenados por nivel
        //    //UPGRADE_WARNING: (1042) Array typmGrupoModulos may need to have individual elements initialized.
        //    typmGrupoModulos = new TNivelMaximo[15];
			
        //    typmGrupoModulos[1].sModulo = "40021";
        //    typmGrupoModulos[1].sNivel = "10";
        //    typmGrupoModulos[2].sModulo = "40022";
        //    typmGrupoModulos[2].sNivel = "15";
        //    typmGrupoModulos[3].sModulo = "40023";
        //    typmGrupoModulos[3].sNivel = "10";
        //    typmGrupoModulos[4].sModulo = "40023";
        //    typmGrupoModulos[4].sNivel = "15";
        //    typmGrupoModulos[5].sModulo = "40023";
        //    typmGrupoModulos[5].sNivel = "20";
        //    typmGrupoModulos[6].sModulo = "40024";
        //    typmGrupoModulos[6].sNivel = "10";
        //    typmGrupoModulos[7].sModulo = "40024";
        //    typmGrupoModulos[7].sNivel = "15";
			
        //}

        private void prGruposModulos_SSS()
        {
            //Se almacenan todos los modulos y los niveles dentro del arreglo typmGrupoModulos
            //grupados por modulo y ordenados por nivel
            //UPGRADE_WARNING: (1042) Array typmGrupoModulos may need to have individual elements initialized.
            typmGrupoModulos = new TNivelMaximo[15];

            typmGrupoModulos[1].sModulo = "40021";            
            typmGrupoModulos[1].sNivel = "10";

            typmGrupoModulos[2].sModulo = "40022";
            typmGrupoModulos[2].sNivel = "15";

            typmGrupoModulos[3].sModulo = "40023";
            typmGrupoModulos[3].sNivel = "10";

            typmGrupoModulos[4].sModulo = "40023";
            typmGrupoModulos[4].sNivel = "15";

            typmGrupoModulos[5].sModulo = "40023";
            typmGrupoModulos[5].sNivel = "20";

            typmGrupoModulos[6].sModulo = "40024";
            typmGrupoModulos[6].sNivel = "10";

            typmGrupoModulos[7].sModulo = "40024";
            typmGrupoModulos[7].sNivel = "15";

        }

		private bool fncFirma( string mvarNominaPasswordS, ref  string slPerfil)
		{
			string slModulos = String.Empty;
			string slNomina = "";
			string slPassword = "";
			string ilLugarComa = (mvarNominaPasswordS.IndexOf(',') + 1).ToString();
			if (Double.Parse(ilLugarComa) > 1)
			{
				slNomina = mvarNominaPasswordS.Substring(0, Math.Min(mvarNominaPasswordS.Length, Convert.ToInt32(Double.Parse(ilLugarComa) - 1)));
				if (Double.Parse(ilLugarComa) < mvarNominaPasswordS.Length)
				{
					slPassword = mvarNominaPasswordS.Substring(mvarNominaPasswordS.Length - Math.Min(mvarNominaPasswordS.Length, Convert.ToInt32(mvarNominaPasswordS.Length - Double.Parse(ilLugarComa))));
					if (fncVerificarFirmaB(slNomina, slPassword, ref slModulos))
					{
						slPerfil = slModulos;
						return true;
						
					} else
					{
						return false;
						
					}
				}
			}
			return false;
			
			//slPerfil = "590910006010100101010030101004010120101012020101203"
			//slPerfil = "590910011,01010,01,01010,02,01010,03,01010,04,01011,01,010110201011030101104010120101012020101203"
			//prFirma "1622528", "yuria190", slModulos
		}
		public void  prHabilitaAcciones( Form forma)
		{
			//UPGRADE_WARNING: (2065) Form property forma.Controls has a new behavior.
			foreach (Control clControl in ContainerHelper.Controls(forma))
			{
				if (clControl is Button)
				{
					prHabilitaControl((Button) clControl, forma.Name, typmPantalla);
					prInHabilitaControl((Button) clControl, forma.Name, typmPantallaInh);
				}
                //AIS-859 NGONZALEZ
				if (clControl is Artinsoft.VB6.Gui.ContainerHelper.MenuItemControl)
				{
                    try
                    {
                        //AIS-859 NGONZALEZ
                        ToolStripMenuItem MenuStrip = (ToolStripMenuItem)((Artinsoft.VB6.Gui.ContainerHelper.MenuItemControl)clControl).ToolStripItemInstance;
                        //AIS-859 NGONZALEZ
                        prHabilitaControlMenu(MenuStrip, forma.Name, typmPantalla);
                        //AIS-859 NGONZALEZ
                        prInHabilitaControlMenu(MenuStrip, forma.Name, typmPantallaInh);
                    }
                    catch (Exception r) { }
				}
			}

		}
		private void  prHabilitaControl( Button boton,  string slForma,  TPantalla[] typmPant)
		{
			int ilNumRegistros = typmPant.GetUpperBound(0);
			for (int ilContador = 1; ilContador <= ilNumRegistros; ilContador++)
			{
				if (typmPant[ilContador].sForma == slForma && typmPant[ilContador].sControl == boton.Name)
				{
					boton.Enabled = true;
				}
			}
			
		}
		
		private void  prInHabilitaControl( Button boton,  string slForma,  TPantalla[] typmPant)
		{
			int ilNumRegistros = typmPant.GetUpperBound(0);
			for (int ilContador = 1; ilContador <= ilNumRegistros; ilContador++)
			{
				if (typmPant[ilContador].sForma == slForma && typmPant[ilContador].sControl == boton.Name)
				{
					boton.Enabled = false;
				}
			}    //alberto mejia   01800 0511000
			
		}
		private void  prHabilitaControlMenu( ToolStripMenuItem boton,  string slForma,  TPantalla[] typmPant)
		{
			boton.Enabled = true;
			//Dim ilContador As Integer
			//Dim ilNumRegistros As Integer
			//ilNumRegistros = UBound(typmPant)
			//For ilContador = 1 To ilNumRegistros
			//    If typmPant(ilContador).sForma = slForma And typmPant(ilContador).sControl = boton.Name Then
			//        boton.Enabled = True
			//    End If
			//Next
			
		}
		
		private void  prInHabilitaControlMenu( ToolStripMenuItem boton,  string slForma,  TPantalla[] typmPant)
		{
			int ilNumRegistros = typmPant.GetUpperBound(0);
			for (int ilContador = 1; ilContador <= ilNumRegistros; ilContador++)
			{
				if (typmPant[ilContador].sForma == slForma && typmPant[ilContador].sControl == boton.Name)
				{
					boton.Enabled = false;
					
				}
			}
			
		}
		
		private bool fncDialogo( string slMensaje, ref  string slRespuesta)
		{
			bool result = false;
			COMDRV32.TcpServer objProxy = null;
			string slArgumento = String.Empty;
			bool blSalir = false;
			string slContestacion = String.Empty;
			try
			{
					if (pfCargaTcpServerB(ref objProxy))
					{
						slArgumento = "";
						//Captura el mensaje enviado por el TCPSERVER
						slArgumento = "D" + slMensaje.Trim() + Strings.Chr(3).ToString();
						objProxy.SendRequest(StringsHelper.StrConv(slArgumento, StringsHelper.VbStrConvEnum.vbFromUnicode, 0), (short) slArgumento.Length);
						blSalir = false;
						while (! blSalir)
							{
							
								slContestacion = StringsHelper.StrConv(objProxy.ReceiveResponse(3000), StringsHelper.VbStrConvEnum.vbUnicode, 0);
							}
						slRespuesta = slContestacion;
						prDescargaTcpServer(ref objProxy);
						result = true;
					} else
					{
						MessageBox.Show("Error al cargar al objeto", Application.ProductName);
					}
				}
			catch (Exception excep)
			{
				
				if (Information.Err().Number == -2147014836)
				{
					blSalir = true;
					//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
					throw new Exception("Migration Exception: 'Resume Next' not supported");
				} else
				{
					MessageBox.Show(excep.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				result = true;
			}
			return result;
		}
		private bool fncVerificarFirmaB( string slNominaF,  string slPasswordF, ref  string slModulos)
		{
			//Recibe la nomina(usuario) y  el password de quien está ejecutando la aplicacion
			//regresa los modulos y botones a los cuales tiene derecho de accesar.
			string slPasswordEncriptado = String.Empty;
			string slRespuesta = String.Empty;
			string slNominaFirma = fncRellenaCeros(slNominaF, 8);
			string slPasswordFirma = fncRellenaCeros(slPasswordF, 8);
			string slEMU_DESTINO = "004104";
			string slEMU_ORIGEN = new String(' ', 6);
			string slEMU_ACCION = firmaEncripcion3DesModulos;
			string slNomina = slNominaFirma.Trim();
			string slVersion = "0";
			int ilVersion = Int32.Parse(slVersion);
			string slCadena = "";
			if (! fncEncriptaDatoB(slPasswordFirma.Trim(), ref slPasswordEncriptado, ref ilVersion, slCadena, 1))
			{
				MessageBox.Show("No fué posible encriptar al password", Application.ProductName);
				return false;
			}
			string slMensaje = "" + slEMU_DESTINO + slEMU_ORIGEN + slEMU_ACCION + slNomina + slPasswordEncriptado + fncRellenaCeros(slVersion, 4);
			
			if (! fncDialogo(slMensaje, ref slRespuesta))
			{
				MessageBox.Show("No fué posible enviar el diálogo", Application.ProductName);
				return false;
			}
			if (Strings.InStr(22, slRespuesta, "SEG;", CompareMethod.Binary) > 0)
			{
				MessageBox.Show("Firma Rechazada", Application.ProductName);
				return false;
			}
			if (! (Strings.InStr(22, slRespuesta, "SEG:", CompareMethod.Binary) > 0))
			{
				MessageBox.Show("Firma Rechazada", Application.ProductName);
				return false;
			}
			string ilPosicionInicial = Strings.InStr(22, slRespuesta, "SEG:", CompareMethod.Binary).ToString();
			ilPosicionInicial = (Double.Parse(ilPosicionInicial) + 84).ToString();
			
			if (slRespuesta.Length < Double.Parse(ilPosicionInicial) + 4)
			{
				MessageBox.Show("Firma Rechazada", Application.ProductName);
				return false;
			}
			string slVersion2 = Strings.Mid(slRespuesta, Int32.Parse(ilPosicionInicial), 4);
			string slVersion3 = slVersion2;
			ilPosicionInicial = (Double.Parse(ilPosicionInicial) + 4).ToString();
			if (slRespuesta.Length < Double.Parse(ilPosicionInicial) + 24)
			{
				MessageBox.Show("Firma Rechazada", Application.ProductName);
				return false;
			}
			slCadena = Strings.Mid(slRespuesta, Int32.Parse(ilPosicionInicial), 24);
			string slCadena1 = slCadena;
			double dbNumericTemp = 0;
			if (Double.TryParse(slVersion2, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
			{
				ilVersion = Int32.Parse(slVersion2);
			} else
			{
				ilVersion = 0;
			}
			if (! fncEncriptaDatoB(slPasswordFirma.Trim(), ref slPasswordEncriptado, ref ilVersion, slCadena, 2))
			{
				MessageBox.Show("No fué posible encriptar al password", Application.ProductName);
				return false;
			}
			slMensaje = "" + slEMU_DESTINO + slEMU_ORIGEN + slEMU_ACCION + slNomina + slPasswordEncriptado + fncRellenaCeros(slVersion2, 4);
			if (! fncDialogo(slMensaje, ref slRespuesta))
			{
				MessageBox.Show("No fué posible enviar el diálogo", Application.ProductName);
				return false;
			}
			slModulos = slRespuesta;
			slEMU_ACCION = desfirma;
			slMensaje = "" + slEMU_DESTINO + slEMU_ORIGEN + slEMU_ACCION;
			slModulos = "";
			slRespuesta = "";
			if (! fncDialogo(slMensaje, ref slRespuesta))
			{
				MessageBox.Show("No fué posible enviar el diálogo de desfirma", Application.ProductName);
				return false;
			}
			return true;
		}
		private string fncRellenaCeros( string slVersion,  int ilNumCeros)
		{
			if (slVersion.Length == ilNumCeros)
			{
				return slVersion;
			}
			if (slVersion.Length > ilNumCeros)
			{
				return slVersion.Substring(slVersion.Length - Math.Min(slVersion.Length, 4));
			} else
			{
				return new string('0', ilNumCeros - slVersion.Length) + slVersion;
			}
		}
		private bool pfCargaTcpServerB(ref  COMDRV32.TcpServer objProxy)
		{
			try
			{
					objProxy = new COMDRV32.TcpServer();
					objProxy.Connect();
					return true;
				}
			catch (Exception excep)
			{
				
				if (Information.Err().Number == 0x80072AFC)
				{
					MessageBox.Show(Information.Err().Number.ToString() + " direccion ip erronea", Application.ProductName);
					//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
					throw new Exception("Migration Exception: 'Resume Next' not supported");
				} else
				{
					MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, Application.ProductName);
				}
				return false;
			}
		}
		private void  prDescargaTcpServer(ref  COMDRV32.TcpServer objProxy)
		{
			//Desconecta al cobjeto comdvr y lo destruye
			objProxy.Disconnect();
		}
		
		//Private Sub cb_firma_Click()
		//Dim slModulos As String
		//prFirma "1622528", "yuria190", slModulos
		//'prFirma "0", "i1234567", slModulos
		//Debug.Print slModulos
		//End Sub
		
		///////////////////////////////////////////////////////////////////////////////////////
		//                                 RUTINAS DE ENCRIPCION
		///////////////////////////////////////////////////////////////////////////////////////
		
		public bool fncEncriptaDatoB( string slDato, ref  string slRespuesta, ref  int ilVersion,  string Cadena,  int accion)
		{
			int res = 0;
			string slEncriptable = String.Empty;
			try
			{
					if (accion == 1)
					{
                        //AIS-1182 NGONZALEZ
						res = API.Encryption.Inicia_Encripcion("", 0);
						slEncriptable = slDato.Trim();
						slRespuesta = new string((char) 255, 8);
                        //AIS-1182 NGONZALEZ
                        short tmpShort = (short)ilVersion;
                        res = API.Encryption.E3Des(slEncriptable, ref slRespuesta, ref tmpShort);
					} else
					{
                        //AIS-1182 NGONZALEZ
						res = API.Encryption.Inicia_Encripcion(Cadena, (short) ilVersion);
						slEncriptable = slDato.Trim();
						slRespuesta = new string((char) 255, 8);
                        //AIS-1182 NGONZALEZ
                        short tmpShort = (short)ilVersion;
                        res = API.Encryption.E3Des(slEncriptable, ref slRespuesta, ref tmpShort);
					}
					return true;
				}
			catch 
			{
				
				return false;
			}
		}
		public object fncDesEncriptaDatoB( string slDato, ref  string slRespuesta)
		{
			string slEncripcion = slDato.Trim();
			slRespuesta = new string((char) 255, 8);
            //AIS-1182 NGONZALEZ
			int res = API.Encryption.D3Des(slEncripcion, slRespuesta);
			return null;
		}
	}
}