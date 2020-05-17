using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mesa_Control
{
    class clsUsuario
    {

        private static clsUsuario instancia = null;
        private clsUsuario _Cnn = null;

        public static clsUsuario getInstancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new clsUsuario();
                }
                return instancia;
            }
        }


        String strnomina = String.Empty;

        public String Strnomina
        {
            get { return strnomina; }
            set { strnomina = value; }
        }

        String strpassword = String.Empty;

        public String Strpassword
        {
            get { return strpassword; }
            set { strpassword = value; }
        }

        String strSirhOpe = String.Empty;

        public String StrSirhOpe
        {
            get { return strSirhOpe; }
            set { strSirhOpe = value; }
        }

        String strCaja = String.Empty;


        public String StrCaja
        {
            get { return strCaja; }
            set { strCaja = value; }
        }

        String strIp = String.Empty;

        public String StrIp
        {
            get { return strIp; }
            set { strIp = value; }
        }

        String strSoid = String.Empty;

        public String StrSoid
        {
            get { return strSoid; }
            set { strSoid = value; }
        }




        /*Datos de sesion*/
        String response_code = String.Empty;

        public String Response_code
        {
            get { return response_code; }
            set { response_code = value; }
        }


        String response_desc = String.Empty;

        public String Response_desc
        {
            get { return response_desc; }
            set { response_desc = value; }
        }
        String stds_err_txt = String.Empty;

        public String Stds_err_txt
        {
            get { return stds_err_txt; }
            set { stds_err_txt = value; }
        }
        String stdl_ses_id = String.Empty;

        public String Stdl_ses_id
        {
            get { return stdl_ses_id; }
            set { stdl_ses_id = value; }
        }
        String stdi_ope_numofic = String.Empty;

        public String Stdi_ope_numofic
        {
            get { return stdi_ope_numofic; }
            set { stdi_ope_numofic = value; }
        }


        String stds_ope_nombre = String.Empty;

        public String Stds_ope_nombre
        {
            get { return stds_ope_nombre; }
            set { stds_ope_nombre = value; }
        }

        String stdi_sol_rslt = String.Empty;
        public String Stdi_sol_rslt
        {
            get { return stdi_sol_rslt; }
            set { stdi_sol_rslt = value; }
        }

        String stdi_err_rslt = String.Empty;

        public String Stdi_err_rslt
        {
            get { return stdi_err_rslt; }
            set { stdi_err_rslt = value; }
        }
        String strCsi = String.Empty;
        public String StrCsi
        {
            get { return strCsi; }
            set { strCsi = value; }
        }

    }
}
