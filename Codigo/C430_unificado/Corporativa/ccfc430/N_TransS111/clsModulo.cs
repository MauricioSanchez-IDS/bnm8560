using System;
//using VB6 = Artinsoft.Silverlight.Client.Utils.Support;

namespace N_TransS111
{
    //using Artinsoft.Silverlight.Client.Form;
    //using Artinsoft.Silverlight.Client.UI;
	public class clsModulo
	{


		private string msModulos = String.Empty;
		private string msDescripcion = String.Empty;
		private int miNivel = 0;
		private string msKey = String.Empty;
		private int miNivelMinimo = 0;
		private int miNivelMaximo = 0;

		public int NivelMaximoI
		{
			get
			{
				return miNivelMaximo;
			}
			set
			{
				miNivelMaximo = value;
			}
		}


		public int NivelMinimoI
		{
			get
			{
				return miNivelMinimo;
			}
			set
			{
				miNivelMinimo = value;
			}
		}


		public string KeyS
		{
			get
			{
				return msKey;
			}
			set
			{
				msKey = value;
			}
		}


		public int NivelI
		{
			get
			{
				return miNivel;
			}
			set
			{
				miNivel = value;
			}
		}


		public string DescripcionS
		{
			get
			{
				return msDescripcion;
			}
			set
			{
				msDescripcion = value;
			}
		}


		public string ModulosS
		{
			get
			{
				return msModulos;
			}
			set
			{
				msModulos = value;
			}
		}

	}
}