
using Microsoft.VisualBasic;
using System;
using System.Collections;
//using VB6 = Artinsoft.Silverlight.Client.Utils.Support;

namespace N_TransS111
{
    //using Artinsoft.Silverlight.Client.Form;
    //using Artinsoft.Silverlight.Client.UI;
	public class clsModulosCMDL
	 : System.Collections.IEnumerable
	{

		const string cteSeparador = ",";
		private Collection mCol = null;
		private int miTotalModulos = 0;
		private string msFiltro = String.Empty;

		string[] asmModulos = null;


        //public string FiltroS
        //{
        //    get
        //    {
        //        return msFiltro;
        //    }
        //    set
        //    {
        //        msFiltro = value;
        //        DesglosaFiltro(cteSeparador);
        //    }
        //}


		public int TotalModulosI
		{
			get
			{
				return miTotalModulos;
			}
			set
			{
				miTotalModulos = value;
			}
		}


		public clsModulo this[object vntIndexKey]
		{
			get
			{
				return (clsModulo) mCol[vntIndexKey];
			}
		}

		public int Count
		{
			get
			{
				return mCol.Count;
			}
		}


		//UPGRADE_ISSUE: (2068) IUnknown object was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2068.aspx

		public IEnumerator GetEnumerator()
		{
			//UPGRADE_ISSUE: (2068) IUnknown object was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2068.aspx
			return mCol.GetEnumerator();
		}

		public clsModulo Add(string ModulosS, string DescripcionS, int NivelI, int NivelMinimoI, int NivelMaximoI, bool bpActivarFiltro)
		{
			clsModulo result = null;
			clsModulo objNewMember = new clsModulo();

			//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx
			if (bpActivarFiltro && !String.IsNullOrEmpty(msFiltro))
			{
				if (BuscaEnFiltroB(ModulosS))
				{
					objNewMember.ModulosS = ModulosS;
					objNewMember.DescripcionS = DescripcionS;
					objNewMember.NivelI = NivelI;
					objNewMember.KeyS = ModulosS;
					objNewMember.NivelMinimoI = NivelMinimoI;
					objNewMember.NivelMaximoI = NivelMaximoI;

					if (Strings.Len(objNewMember.KeyS) == 0)
					{
						mCol.Add(objNewMember, null, null, null);
					}
					else
					{
						mCol.Add(objNewMember, objNewMember.KeyS, null, null);
					}

					result = objNewMember;
					objNewMember = null;
				}
			}
			else
			{

				objNewMember.ModulosS = ModulosS;
				objNewMember.DescripcionS = DescripcionS;
				objNewMember.NivelI = NivelI;
				objNewMember.KeyS = ModulosS;
				objNewMember.NivelMinimoI = NivelMinimoI;
				objNewMember.NivelMaximoI = NivelMaximoI;

				if (Strings.Len(objNewMember.KeyS) == 0)
				{
					mCol.Add(objNewMember, null, null, null);
				}
				else
				{
					mCol.Add(objNewMember, objNewMember.KeyS, null, null);
				}

				result = objNewMember;
				objNewMember = null;
			}
			return result;
		}

		public clsModulo Add(string ModulosS, string DescripcionS, int NivelI, int NivelMinimoI, int NivelMaximoI)
		{
			return Add(ModulosS, DescripcionS, NivelI, NivelMinimoI, NivelMaximoI, false);
		}

		public void Remove(int vntIndexKey)
		{
            mCol.Remove(vntIndexKey);
		}

		public clsModulosCMDL()
		{
			mCol = new Collection();
		}

		~clsModulosCMDL()
		{
			mCol = null;
		}

		public clsModulo BuscarModulo(string vpId)
		{
			clsModulo result = null;
			int i = 0;

			foreach (clsModulo mdllBuff in this)
			{
				if (mdllBuff.ModulosS == vpId)
				{
					result = mdllBuff;
					break;
				}
			}
			return result;
		}

		public void Clear()
		{
			for (int i = 1; mCol.Count > 0; i++)
			{
				this.Remove(1);
			}
			miTotalModulos = this.Count;
		}

        //private void DesglosaFiltro(string spSeparador)
        //{
        //    int ilModulosFiltro = 0;
        //    asmModulos = new string[]{String.Empty};
        //    //UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx
        //    if (!String.IsNullOrEmpty(msFiltro.Trim()))
        //    {
        //        ilModulosFiltro = CuentaElementosI(msFiltro, ref spSeparador) + 1;
        //        if (ilModulosFiltro > 0)
        //        {
        //            for (int ilCounter = 1; ilCounter <= ilModulosFiltro; ilCounter++)
        //            {
        //                asmModulos = Artinsoft.Silverlight.Client.Utils.ArraysHelper.RedimPreserve(asmModulos, new int[]{ilCounter + 1});
        //                asmModulos[ilCounter] = ObtenerElementoS(msFiltro, ilCounter, spSeparador);
        //            }
        //        }
        //    }
        //}
        //private void DesglosaFiltro()
        //{
        //    DesglosaFiltro(String.Empty);
        //}
		private string ObtenerElementoS(string spCadena, int ipElemento, string spSeparador)
		{
			//**********************************************************************************************
			//*  Descripción     :   Obtiene el elemento ipElemento, de la cadena spCadena, basado
			//*  Autor           :   Héctor Vázquez Vázquez
			//*  Fecha           :   05 de Enero de 2002
			//**********************************************************************************************
			string slParametro = String.Empty;
			string slCadenaAux = String.Empty;


			//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx
			if (String.IsNullOrEmpty(spSeparador) || false)
			{
				spSeparador = ",";
			}
			int ilPosicionInicial = 0;
			int ilPosicionFinal = Strings.InStr(ilPosicionInicial + 1, spCadena, spSeparador, CompareMethod.Binary);
			if (ipElemento > 1 && ilPosicionFinal == 0)
			{
				slParametro = "";
			}
			else
			{
				if (ipElemento < 0)
				{
					return System.String.Empty;
				}
				else if (ipElemento == 1)
				{
					if (ilPosicionFinal == 0)
					{
						slParametro = spCadena;
					}
					else
					{
						slParametro = Strings.Left(spCadena, ilPosicionFinal - 1);
					}
				}
				else if (ipElemento > 1)
				{
					if (ilPosicionFinal == 0)
					{
						slParametro = Strings.Right(spCadena, spCadena.Length - ilPosicionInicial);
						ipElemento = 1;
					}
					else
					{
						ipElemento--;
						slCadenaAux = Strings.Right(spCadena, spCadena.Length - ilPosicionFinal);
						slParametro = ObtenerElementoS(slCadenaAux, ipElemento, spSeparador);
					}
				}
			}
			return slParametro;
		}
		private string ObtenerElementoS(string spCadena, int ipElemento)
		{
			return ObtenerElementoS(spCadena, ipElemento, String.Empty);
		}
		private int CuentaElementosI(string spCadena, ref string spCadenaABuscar)
		{

			int ilCounter = 0;
			int ilPosicionFinal = 1;
			int ilPosicionInicial = 1;
			while (ilPosicionFinal > 0)
			{
				ilPosicionInicial = Strings.InStr(ilPosicionInicial + 1, spCadena, spCadenaABuscar, CompareMethod.Binary);
				ilPosicionFinal = Strings.InStr(ilPosicionInicial + 1, spCadena, spCadenaABuscar, CompareMethod.Binary);
				ilCounter++;
			}
			return ilCounter;

		}
		private bool BuscaEnFiltroB(string spModulo)
		{

			for (int ilCounter = 1; ilCounter <= asmModulos.GetUpperBound(0); ilCounter++)
			{
				if (asmModulos[ilCounter].Trim() == spModulo.Trim())
				{
					return true;
				}
			}

			return false;
		}
	}
}