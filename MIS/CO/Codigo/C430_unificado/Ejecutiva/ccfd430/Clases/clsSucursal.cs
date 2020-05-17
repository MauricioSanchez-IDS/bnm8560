using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

namespace TCd430
{
    class clsSucursal
    {
        private int intSucursalId;
        private string strDescripcion;
        private string strEstatus;

        public int IdSucursal
        {
            get
            {
                return intSucursalId;
            }
            set
            {
                const int mLngMax = 9999;
                const int mLngMin = 0;
                
                if ((value < mLngMin) || (mLngMax > 9999))
                {
                    Information.Err().Raise(-1, this.GetType().Name, "Identificador Fuera de Rango" + "\r\n" +
                                "Rango Valido: " + mLngMin + " - " + mLngMin,null,null);

                }    
                else
                {
                    intSucursalId = value;
                }
            }
        }

        public string Descripcion
        {
            get
            {
                return strDescripcion;
            }
            set
            {
                strDescripcion = value;
            }
        }

        public string Status
        {
            get
            {
                if (strEstatus != "S")
                {
                    return "N";
                }
                else
                {
                    return strEstatus;
                }
            }
            set
            {
                strEstatus = "N";
                value = value.ToUpper();
                if ((value != "S") && (value != "N"))
                {
                    Information.Err().Raise(-1, this.GetType().Name, "Estado Invalido",null,null);
                }
                else
                {
                    strEstatus = value;
                }
            }
        }
    }
}
