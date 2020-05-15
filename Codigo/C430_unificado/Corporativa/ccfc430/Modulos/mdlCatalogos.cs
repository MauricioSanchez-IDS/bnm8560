using Artinsoft.VB6.Utils; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	class mdlCatalogos
	{
	
		
		static public void  prLlenaCombo( object objpRepositorio,  ComboBox ctrlpControl)
		{
			colCatCorporativos ccrplCorporativos = null;
			colCatEmpresas cemplEmpresas = null;
			colCatUnidades cunilUnidades = null;
			colCatReporte creplReportes = null;
			colcatEstado cedolEstados = null;
			colEjecutivoBanamex cejxlEjecutivoBanamex = null;
			ComboBox cmblCombo = null;
			
			if (objpRepositorio is colCatCorporativos)
            {//AIS-1174 NGONZALEZ
                ccrplCorporativos = (colCatCorporativos)objpRepositorio;
				cmblCombo = ctrlpControl;
				cmblCombo.Items.Clear();
				for (int llCont = 1; llCont <= ccrplCorporativos.Count; llCont++)
				{
					cmblCombo.Items.Add(StringsHelper.Format(ccrplCorporativos[llCont].CorporativoL, mdlParametros.ctesMaskCorporativo) + mdlParametros.ctesSeparador + ccrplCorporativos[llCont].NombreS.Trim());
				}
				cmblCombo.SelectedIndex = 0;
				return;
			}
			
			if (objpRepositorio is colCatEmpresas)
			{
                //AIS-1174 NGONZALEZ
                cemplEmpresas = (colCatEmpresas)objpRepositorio;
				cmblCombo = ctrlpControl;
				cmblCombo.Items.Clear();
				cmblCombo.Items.Insert(0, "Todos");
				for (int llCont = 1; llCont <= cemplEmpresas.Count; llCont++)
				{
					ctrlpControl.Items.Add(StringsHelper.Format(cemplEmpresas[llCont].EmpresaL, mdlParametros.gprdProducto.MascaraEmpresaS) + mdlParametros.ctesSeparador + cemplEmpresas[llCont].NombreS.Trim());
				}
				cmblCombo.SelectedIndex = 0;
				return;
			}
			
			if (objpRepositorio is colCatUnidades)
			{
                //AIS-1174 NGONZALEZ
                cunilUnidades = (colCatUnidades)objpRepositorio;
				cmblCombo = ctrlpControl;
				cmblCombo.Items.Clear();
				cmblCombo.Items.Insert(0, "Todos");
				for (int llCont = 1; llCont <= cunilUnidades.Count; llCont++)
				{
					ctrlpControl.Items.Add(StringsHelper.Format(cunilUnidades[llCont].UnidadS, mdlParametros.ctesUnidades) + mdlParametros.ctesSeparador + cunilUnidades[llCont].NombreS.Trim());
				}
				cmblCombo.SelectedIndex = 0;
				return;
			}
			
			if (objpRepositorio is colCatReporte)
			{
                //AIS-1174 NGONZALEZ
                //AIS-541 NGONZALEZ
                creplReportes = (colCatReporte)objpRepositorio;
				cmblCombo = ctrlpControl;
				cmblCombo.Items.Clear();
				cmblCombo.Items.Insert(0, "Todos");
				for (int llCont = 1; llCont <= creplReportes.Count; llCont++)
				{
					cmblCombo.Items.Add(StringsHelper.Format(creplReportes[llCont].ReporteIdI, mdlParametros.grepReporte.MascaraS + mdlParametros.ctesSeparador + creplReportes[llCont].NombreS.Trim()));
				}
				cmblCombo.SelectedIndex = 0;
				return;
			}
			
			if (objpRepositorio is colcatEstado)
			{
                //AIS-541 NGONZALEZ
                //AIS-1174 NGONZALEZ
                cedolEstados = (colcatEstado)objpRepositorio;
				cmblCombo = ctrlpControl;
				cmblCombo.Items.Clear();
				for (int llCont = 1; llCont <= cedolEstados.Count; llCont++)
				{
					cmblCombo.Items.Add(cedolEstados[llCont].EstadoS);
				}
				cmblCombo.SelectedIndex = -1;
				return;
			}
			
			if (objpRepositorio is colEjecutivoBanamex)
			{
                //AIS-541 NGONZALEZ
                //AIS-1174 NGONZALEZ
                cejxlEjecutivoBanamex = (colEjecutivoBanamex)objpRepositorio;
				cmblCombo = ctrlpControl;
				cmblCombo.Items.Clear();
				for (int llCont = 1; llCont <= cejxlEjecutivoBanamex.Count; llCont++)
				{
					cmblCombo.Items.Add(StringsHelper.Format(cejxlEjecutivoBanamex[llCont].NominaL, "0000000") + new String(' ', 10) + cejxlEjecutivoBanamex[llCont].NombreS.Trim());
				}
				cmblCombo.SelectedIndex = 0;
				return;
			}
		}
	}
}