using Microsoft.VisualBasic; 
using System; 
using System.Text; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	class Seguridad
	{
	
		static public prySeguridadS041.clsUsuario usugUsuario = null;
		
		static public string DesEncripta( string pszCodigo)
		{
			
			
			pszCodigo = pszCodigo.Trim().ToLower();
			StringBuilder pszCadenaRes = new StringBuilder();
			pszCadenaRes.Append(CORVB.NULL_STRING);
			
			if (pszCodigo.Length > CORVB.NULL_INTEGER)
			{
				for (int iCont = 1; iCont <= pszCodigo.Length; iCont++)
				{
					pszCadenaRes.Append(Strings.Chr(300 - ((int) Strings.Mid(pszCodigo, iCont, 1)[0])).ToString());
				}
			}
			
			return pszCadenaRes.ToString().Trim().ToLower();
			
		}
		
		static public string Encripta( string pszCodigo,  int May_Min)
		{
			
			string result = String.Empty;
			
			pszCodigo = pszCodigo.Trim().ToLower();
			StringBuilder pszCadenaRes = new StringBuilder();
			pszCadenaRes.Append(CORVB.NULL_STRING);
			
			if (pszCodigo.Length > CORVB.NULL_INTEGER)
			{
				for (int iCont = 1; iCont <= pszCodigo.Length; iCont++)
				{
					pszCadenaRes.Append(Strings.Chr(300 - ((int) Strings.Mid(pszCodigo, iCont, 1)[0])).ToString());
				}
			}
			if (May_Min == 1)
			{ //Mayusculas
				result = pszCadenaRes.ToString().Trim().ToUpper();
			} else if (May_Min == 2) {  //Minusculas
				result = pszCadenaRes.ToString().Trim().ToLower();
			}
			return result;
		}
		//
		//Public Sub ObtenerMenu(ByVal Forma As MDIForm, Arbol As TreeView)
		//
		//Dim NodeX As Node
		//Dim Controles As Control
		//Dim Formas As Form
		//Dim iCont As Integer
		//
		//On Error GoTo ErrObtenerMenu
		//  'Organiza Arbol
		//  Arbol.Appearance = cc3D
		//  Arbol.Indentation = 250
		//  Arbol.Style = tvwTreelinesPlusMinusText
		//  Arbol.HideSelection = False
		//  Arbol.FullRowSelect = True
		//  Arbol.LineStyle = tvwRootLines
		//
		//  'Configurar Nodo Padre
		//  Set NodeX = Arbol.Nodes.Add(, tvwFirst, "IDM_C430", "C430")
		//  NodeX.Tag = "IDM_C430"
		//
		//  'Configura Nodos Hijos
		//  For Each Controles In Forma.Controls
		//    If TypeOf Controles Is VB.Menu Then
		//      Controles.Caption = fncsSustituir(Controles.Caption, "&", "")
		//      Controles.Caption = fncsSustituir(Controles.Caption, "/", " ")
		//      If Controles.Caption <> "-" Then
		//        Set NodeX = Arbol.Nodes.Add(Controles.Tag, tvwChild, Controles.Name, Controles.Caption & "  (" & Controles.Name & ")")
		//        NodeX.Sorted = True
		//        NodeX.Tag = Controles.Tag
		//      End If
		//    End If
		//  Next
		//
		//'  For Each Formas In VB.Forms
		//'    If TypeOf Formas Is Form Then
		//'      For Each Controles In Formas.Controls
		//'        If TypeOf Controles Is CommandButton Then
		//'          Controles.Caption = fncsSustituir(Controles.Caption, "&", "")
		//'          Controles.Caption = fncsSustituir(Controles.Caption, "/", " ")
		//'          Set NodeX = Arbol.Nodes.Add(Controles.Tag, tvwChild, Controles.Name, Controles.Caption & "  (" & Controles.Name & ")")
		//'          NodeX.Tag = Controles.Tag
		//'        End If
		//'      Next
		//'    End If
		//'  Next
		//
		//  For iCont = 1 To Arbol.Nodes.Count
		//    Arbol.Nodes.Item(iCont).Expanded = True
		//  Next
		//Exit Sub
		//ErrObtenerMenu:
		//  MsgBox "Error en Obtener Menu", vbInformation + vbOKOnly, "Tarjeta Corporativa"
		//  Resume Next
		//'    prObtenError "ObtenerMenu"
		//End Sub
		
		static public string fncsSustituir( string slCadena,  string slCadenaActual,  string slNuevaCadena)
		{
			
			string slCadena1 = String.Empty;
			string slCadena2 = String.Empty;
			
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
			try
			{
					
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected.
					if (Convert.IsDBNull(slCadena) || slCadena == "")
					{
						return String.Empty;
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected.
					if (Convert.IsDBNull(slCadenaActual) || slCadenaActual == "")
					{
						return String.Empty;
					}
					int ilPosicion = 0;
					int ilTerminacion = 0;
					if (! (((slCadenaActual.IndexOf(slNuevaCadena, StringComparison.CurrentCultureIgnoreCase) + 1) & ((slNuevaCadena != "") ? -1: 0)) != 0))
					{
						
						ilPosicion = (slCadena.IndexOf(slCadenaActual, StringComparison.CurrentCultureIgnoreCase) + 1);
						ilTerminacion = ilPosicion + slCadenaActual.Length;
						if (ilPosicion > 0)
						{
							slCadena1 = slCadena.Substring(0, Math.Min(slCadena.Length, ilPosicion - 1));
							slCadena2 = Strings.Mid(slCadena, ilTerminacion, slCadena.Length);
							slCadena = slCadena1 + slNuevaCadena + slCadena2;
							slCadena = fncsSustituir(slCadena, slCadenaActual, slNuevaCadena);
						}
						
					}
					
					return slCadena;
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
			
			return String.Empty;
		}
		//
		//Public Sub SeleccionarNodo(ByVal ndoNodo As Node)
		//
		//Dim ilCounter As Integer
		//Dim ndoAuxiliar As Node
		//Dim blValorSeleccion As Boolean
		//
		//On Error Resume Next
		//
		//  If ndoNodo.Children > 0 Then
		//    ndoNodo.Child.CHECKED = ndoNodo.CHECKED
		//    SeleccionarNodo ndoNodo.Child
		//    Set ndoAuxiliar = ndoNodo.Child.Next
		//    While Not ndoAuxiliar Is Nothing
		//      ndoAuxiliar.CHECKED = ndoNodo.CHECKED
		//      SeleccionarNodo ndoAuxiliar
		//      Set ndoAuxiliar = ndoAuxiliar.Next
		//    Wend
		//  End If
		//
		//End Sub
		
		static public void  Deshabilita_Menu()
		{
			
			//1er. Menu
			CORMDIBN.DefInstance.IDM_ESP.Enabled = true; //Configurar
			CORMDIBN.DefInstance.IDM_PAR.Enabled = false; //Parametros
			CORMDIBN.DefInstance.IDM_INTD.Enabled = false; //Estatus de Integracion
			CORMDIBN.DefInstance.IDM_CDF.Enabled = false; //Estatus CDF
			CORMDIBN.DefInstance.IDM_ENV.Enabled = false; //Estatus Intelar
			//CORMDIBN.IDM_CAMM.Enabled = False                   'Cambios Masivos
			CORMDIBN.DefInstance.IDM_LIM.Enabled = false; //Limite de Credito
			CORMDIBN.DefInstance.IDM_LIM.Available = false; //Limite de Credito
			CORMDIBN.DefInstance.IDM_SEG.Enabled = false; //Seguridad
			CORMDIBN.DefInstance.IDM_USU.Enabled = false; //Usuario
			CORMDIBN.DefInstance.IDM_GRU.Enabled = false; //Grupo
			CORMDIBN.DefInstance.IDM_BCO.Enabled = false; //Banco de Operacion
			CORMDIBN.DefInstance.IDM_SAL.Enabled = true; //Salir
			
			//2o. Menu
			//CORMDIBN.IDM_OPE.Enabled = True                     'Interfaces
			CORMDIBN.DefInstance.IDM_TRR.Enabled = false; //Transmision de Reportes
			
			//3er. Menu
			CORMDIBN.DefInstance.IDM_CAT.Enabled = true; //Archivos
			CORMDIBN.DefInstance.Estructuras_Gastos.Enabled = false; //Estructura de Gastos
			CORMDIBN.DefInstance.IDM_COR.Enabled = false; //Corporativos
			CORMDIBN.DefInstance.IDM_EMP.Enabled = false; //Empresas
			CORMDIBN.DefInstance.mnu_unidades.Enabled = false; //Unidades
			CORMDIBN.DefInstance.mnu_reportes.Enabled = false; //Reportes
			//CORMDIBN.mnu_categorias.Enabled = False             'Categorias
			CORMDIBN.DefInstance.IDM_EJE.Enabled = false; //TajetaHabientes
			CORMDIBN.DefInstance.IDM_BAN.Enabled = false; //Ejecutivos Banamex
			CORMDIBN.DefInstance.IDM_CCI.Enabled = false; //Activar Reportes en CCI
			//CORMDIBN.IDM_DIV.Enabled = False                    'Divisiones Regionales
			//CORMDIBN.IDM_REG.Enabled = False                    'Regiones
			CORMDIBN.DefInstance.IDM_ALTAS_MASIVAS.Enabled = false; //Altas Masivas
			CORMDIBN.DefInstance.mnuEnvioLimCred.Enabled = false; //Envio de Limite de Credito
			
			//4o. Menu
			CORMDIBN.DefInstance.IDM_CTA.Enabled = false; //Consultas
			CORMDIBN.DefInstance.IDM_CON.Enabled = false; //Concentrado
			CORMDIBN.DefInstance.IDM_CEJ.Enabled = false; //Empresas/Ejecutivos
			CORMDIBN.DefInstance.IDM_CEM.Enabled = false; //Grupo/Empresa
			CORMDIBN.DefInstance.IDM_ANA.Enabled = false; //Consumos por Giro
			CORMDIBN.DefInstance.IDM_DET.Enabled = false; //Detalle
			CORMDIBN.DefInstance.IDM_ATR.Enabled = false; //Atrasos por Ejecutivo
			CORMDIBN.DefInstance.IDM_DEJ.Enabled = false; //Ejecutivos Banamex
			CORMDIBN.DefInstance.IDM_AFI.Enabled = false; //Empresas Afiliadas
			//CORMDIBN.IDM_GER.Enabled = False                    'Crystal Report
			CORMDIBN.DefInstance.IDM_EER.Enabled = false; //Estatus Envio Reportes
			CORMDIBN.DefInstance.mnu_envio_sbf.Enabled = false; //Envio SBF
			CORMDIBN.DefInstance.IDM_REN.Enabled = false; //Rentabilidad
			//CORMDIBN.IDM_BNX.Enabled = False                    'Ejecutivos Banamex
			//CORMDIBN.IDM_GRA.Enabled = False                    'Graficas
			CORMDIBN.DefInstance.IDM_GBIT.Enabled = false; //Bitacora
			CORMDIBN.DefInstance.IDM_GCOR.Enabled = false; //Corporativos
			CORMDIBN.DefInstance.IDM_GEMP.Enabled = false; //Empresas
			CORMDIBN.DefInstance.IDM_GACL.Enabled = false; //Aclaraciones
			CORMDIBN.DefInstance.IDM_GSIT.Enabled = false; //Situacion de la Cuenta
			CORMDIBN.DefInstance.IDM_GCRE.Enabled = false; //Creditos
			CORMDIBN.DefInstance.IDM_GANT.Enabled = false; //Antiguedad de la Cuenta
			CORMDIBN.DefInstance.IDM_GVEN.Enabled = false; //Vencidos
			CORMDIBN.DefInstance.IDM_GCOM.Enabled = false; //Comparativos
			CORMDIBN.DefInstance.IDM_OPC.Enabled = false; //Opciones
			
			//5o. menu
			CORMDIBN.DefInstance.IDM_AYU.Enabled = true;
			CORMDIBN.DefInstance.IDM_ACL.Enabled = false;
			CORMDIBN.DefInstance.IDM_CAP.Enabled = false;
			CORMDIBN.DefInstance.IDM_HIS.Enabled = false;
			CORMDIBN.DefInstance.IDM_AVE.Enabled = false;
			
			//Botones
			CORMDIBN.DefInstance.IDT_GPB[0].Enabled = false; //Empresa
			CORMDIBN.DefInstance.IDT_GPB[1].Enabled = false; //TarjetaHabientes
			CORMDIBN.DefInstance.IDT_GPB[2].Enabled = false; //Corporativos
			
		}
	}
}