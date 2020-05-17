using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class frmAcceso
        : System.Windows.Forms.Form
    {

        private void frmAcceso_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }

        const string STR_SEG_CON_GRU = "El grupo que se desea borrar, está asignado a usuarios. Favor de asignar un nuevo grupo a dichos usuarios antes de borrar el grupo seleccionado.";
        const string STR_SEG_GRU_BOR = "Realmente desea dar de baja el grupo ";
        const string STR_SEG_NCVE_GRU = "La clave del grupo no ha sido capturada. Favor de asignar una clave.";
        const string STR_SEG_NDES_GRU = "La descripción del grupo no ha sido capturada. Favor de asignarle la descripción.";
        const string STR_SEG_REP_CVE = "La clave del grupo e encuentra repetida. Favor de asignarle una nueva clave.";
        const string STR_SEG_SIN_NIV = "No se puede crear el grupo ya que no se han seleccionado niveles de acceso.";

        const int iNumCatalogos = 9;

        string msProceso = String.Empty;
        bool bAccesoArchivos = false;
        bool bAccesoEstructuras = false;
        bool bAccesoCoroprativos = false;
        bool bAccesoEmpresas = false;
        bool bAccesoUnidades = false;
        bool bAccesoTarjetahabientes = false;
        bool bAccesoEjecutivos = false;
        bool bAccesoDivisiones = false;
        bool bAccesoRegiones = false;



        //el 6 representa el numero de catalogos que existen en el menu de archivos
        //este valor se debe cambiar al agregar o quitar un catalogo más
        //UPGRADE_WARNING: (1042) Array arrayAcceso may need to have individual elements initialized.
        CORVAR.AccesoNivel[] arrayAcceso = ArraysHelper.InitializeArray<CORVAR.AccesoNivel[]>(new int[] { iNumCatalogos + 1 });
        //el iNumCatlogos = 0 es para corporativos
        //el iNumCatlogos = 1 es para empresas y así en el orden que estan

        private void Arma_Insert()
        {

            //*****************************************Menu de Configurar**********************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkConfigurar.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_ESP',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Configurar", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Configurar/Parametros*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkParametros.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_PAR',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Configurar/Parámetros", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Configurar/Estus de Integración*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkIntegracion.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_INTD',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Configurar/estatus de la Integración", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Configurar/Cambios Masivos*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkCamMasivos.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_CAMM',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Configurar/Cambios Masivos", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Configurar/Estatus de CDF*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chk_estatus_cdf.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_CDF',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el registro en la opción de Configurar/estatus del CDF", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Configurar/Limite de Credito*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkLimCred.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_LIM',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Configurar/Límite de Crédito", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }


            //*****************************************Menu de Configurar/Seguridad*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkSeguridad.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_SEG',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Configurar/Seguridad", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }


            //*****************************************Menu de Configurar/Seguridad/Usuario*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkUsuario.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_USU',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Configurar/Seguridad/Usuario", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }


            //*****************************************Menu de Configurar/Seguridad/Grupo*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkGrupo.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_GRU',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Configurar/Seguridad/Grupo", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }


            //*****************************************Menu de Configurar/Banco de Operacion*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkBanco.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_BCO',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Configurar/Banco de Operación", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }


            //*****************************************Menu de Interfaces*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkInterfaces.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_OPE',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Interfaces", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }


            //*****************************************Menu de Interfaces/Transmision de Reportes*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkTransmision.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_TRR',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Interfaces/Transmisión de reportes", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Archivos*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkArchivos.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_CAT',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Archivos", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Archivos/Estructuras de Gastos*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chk_Estruct_Gastos.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'Estructuras_Gastos',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Archivos/Corporativos", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                Inserta_Opciones_Menu("0");
            }

            //*****************************************Menu de Archivos/Corporativos*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkCorporativos.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_COR',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Archivos/Corporativos", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                Inserta_Opciones_Menu("1");
            }

            //*****************************************Menu de Archivos/Empresas*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkEmpresas.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_EMP',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Archivos/Empresas", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                Inserta_Opciones_Menu("2");
            }

            //*****************************************Menu de Archivos/Unidades*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chk_unidades.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'mnu_unidades',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Archivos/Corporativos", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                Inserta_Opciones_Menu("3");
            }

            //*****************************************Menu de Archivos/Reportes*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chk_unidades.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'mnu_reportes',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Archivos/Corporativos", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                Inserta_Opciones_Menu("8");
            }

            //*****************************************Menu de Archivos/Categorias*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chk_unidades.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'mnu_categorias',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Archivos/Corporativos", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                Inserta_Opciones_Menu("9");
            }

            //*****************************************Menu de Archivos/Tarjetahabientes*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkTarjetahabientes.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_EJE',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Archivos/Trajetahabientes Banamex", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                Inserta_Opciones_Menu("4");
            }


            //*****************************************Menu de Archivos/Ejecutivos Banamex*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkEjecutivos.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_BAN',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Archivos/Ejecutivos Banamex", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                Inserta_Opciones_Menu("5");
            }

            //*****************************************Menu de Archivos/Activar Reportes CCI*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkCCI.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_CCI',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Activar Reportes en CCI", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Archivos/Divisiones*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkDivisiones.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_DIV',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Archivos/Divisiones", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                Inserta_Opciones_Menu("6");
            }

            //*****************************************Menu de Archivos/Regiones*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkRegiones.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_REG',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Archivos/Regiones", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                Inserta_Opciones_Menu("7");
            }

            //*****************************************Menu de Archivos/Altas Masivas*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chk_unidades.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_ALTAS_MASIVAS',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Archivos/Corporativos", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Archivos/Envio Limite de Credito*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkEnvioLimCred.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'mnuEnvioLimCred',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Archivos/Corporativos", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkConsultas.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_CTA',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Consultas", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Concentrado*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkConcentrado.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_CON',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Consultas/Concentrado", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Consentrado/Empresa-Ejecutivos*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkEmpEje.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_CEJ',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Consultas/Concentrado/Empresa-Ejecutivos", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Consentrado/Grupo-Empresa*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkGpoEmp.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_CEM',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Consultas/Concentrado/Grupo-Empresas", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Concentrado/Consumos por Giro*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkConsumos.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_ANA',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Consultas/Concentrado/Consumos por Giro", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Detalle*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkDetalle.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_DET',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Consultas/Detalle", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Detalle/Atrasos*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkAtrasos.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_ATR',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Consultas/Detalle/Atrasos", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }


            //*****************************************Menu de Consultas/Detalle/Ejecutivos*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkEjeBanamex.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_DEJ',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Consultas/Detalle/Ejecutivos", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Detalle/Empresas Afiliadas*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkAfiliadas.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_AFI',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Consultas/Detalle/Empresas", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Crystal Report*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkCrystal.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_GER',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Consultas/Crystal", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Estatus Envio Reportes*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkEnvioRep.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_EER',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Consultas/Estatus Envio Reportes", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Envio SBF*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkSBF.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'mnu_envio_sbf',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Consultas/Envio SBF", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Rentabilidad*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkRentabilidad.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_REN',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Consultas/Rentabilidad", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }


            //*****************************************Menu de Consultas/Ejecutivos Banamex*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkEjeBnx.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_BNX',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Consultas/Ejecutivos Banamex", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Graficas*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkGraficas.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_GRA',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Gráficas", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Graficas/Bitacora*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkBitacora.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_GBIT',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Gráficas/Bitácora", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Graficas/Corporativos*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkCorporo.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_GCOR',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Gráficas/Corporativos", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Graficas/Empresas*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkEmp.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_GEMP',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Gráficas/Empresas", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Graficas/Aclaraciones*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkAclaraciones.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_GACL',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Gráficas/Aclaraciones", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Graficas/Situacion de la Cuenta*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkSituacion.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_GSIT',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Gráficas/Situación de la Cuenta", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Graficas/Creditos*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkCreditos.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_GCRE',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Gráficas/Créditos", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Graficas/Antiguedad*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkAntiguedad.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_GANT',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Gráficas/Antiguedad", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Graficas/Vencidos*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkVencidos.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_GVEN',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Gráficas/Vencidos", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Graficas/Comparativos*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkComparativos.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_GCOM',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Gráficas/Comparativos", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Opciones*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkOpciones.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_OPC',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Opciones", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //*****************************************Menu de Consultas/Aclaraciones*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkAclara.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_ACL',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Aclaraciones", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }


            //*****************************************Menu de Consultas/Aclaraciones/Emulador*****************************************
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            if (chkEmulador.Value)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'IDM_CAP',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'true',";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    MessageBox.Show("No se actualizo el resgistro en la opción de Aclaraciones/Emulador", Application.ProductName);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

        }

        private void Asigna_Valor(string sMenu, ref  string sValor)
        {

            sValor = sValor.Trim();

            switch (sMenu.Trim())
            {
                case "IDM_PAR":  //parametros 
                    chkParametros.Value = Boolean.Parse(sValor);
                    chkParametros_ClickEvent(chkParametros, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_INTD":  //integración 
                    chkIntegracion.Value = Boolean.Parse(sValor);
                    chkIntegracion_ClickEvent(chkIntegracion, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_CAMM":  //cambios masivos 
                    chkCamMasivos.Value = Boolean.Parse(sValor);
                    chkCamMasivos_ClickEvent(chkCamMasivos, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_LIM":  //limites de crédito 
                    chkLimCred.Value = Boolean.Parse(sValor);
                    chkLimCred_ClickEvent(chkLimCred, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_SEG":  //seguridad 
                    chkSeguridad.Value = Boolean.Parse(sValor);
                    chkSeguridad_ClickEvent(chkSeguridad, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_USU":  //seguridad/usuarios 
                    chkUsuario.Value = Boolean.Parse(sValor);
                    chkUsuario_ClickEvent(chkUsuario, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_GRU":  //seguridad/grupos 
                    chkGrupo.Value = Boolean.Parse(sValor);
                    chkGrupo_ClickEvent(chkGrupo, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_BCO":  //banco de operación 
                    chkBanco.Value = Boolean.Parse(sValor);
                    chkBanco_ClickEvent(chkBanco, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_OPE":  //interfaces 
                    chkInterfaces.Value = Boolean.Parse(sValor);
                    chkInterfaces_ClickEvent(chkInterfaces, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_TRR":  //intserfaces/transmisión de repórtes 
                    chkTransmision.Value = Boolean.Parse(sValor);
                    chkTransmision_ClickEvent(chkTransmision, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_DEP":  //interfaces/depuración 
                    chkDepuracion.Value = Boolean.Parse(sValor);
                    chkDepuracion_ClickEvent(chkDepuracion, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_CAT":  //archivo 
                    chkArchivos.Value = Boolean.Parse(sValor);
                    chkArchivos_ClickEvent(chkArchivos, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "Estructuras_Gastos":  //archivo/Estructura de Gastos 
                    chk_Estruct_Gastos.Value = Boolean.Parse(sValor);
                    chk_Estruct_Gastos_ClickEvent(chk_Estruct_Gastos, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_COR":  //archivo/corportaivos 
                    chkCorporativos.Value = Boolean.Parse(sValor);
                    chkCorporativos_ClickEvent(chkCorporativos, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_EMP":  //archivos/empresas 
                    chkEmpresas.Value = Boolean.Parse(sValor);
                    chkEmpresas_ClickEvent(chkEmpresas, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "Unidades":  //archivos/unidades 
                    chk_unidades.Value = Boolean.Parse(sValor);
                    chk_unidades_ClickEvent(chk_unidades, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_EJE":  //archivos/tarjetahabientes 
                    chkTarjetahabientes.Value = Boolean.Parse(sValor);
                    chkTarjetahabientes_ClickEvent(chkTarjetahabientes, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_BAN":  //archivos/jejcutivos banaex 
                    chkEjecutivos.Value = Boolean.Parse(sValor);
                    chkEjecutivos_ClickEvent(chkEjecutivos, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_CCI":  //archivos/Activar reportes en CCI 
                    chkCCI.Value = Boolean.Parse(sValor);
                    chkCCI_ClickEvent(chkCCI, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_DIV":  //archivos/divisiones 
                    chkDivisiones.Value = Boolean.Parse(sValor);
                    chkDivisiones_ClickEvent(chkDivisiones, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_REG":  //archivos/regiones 
                    chkRegiones.Value = Boolean.Parse(sValor);
                    chkRegiones_ClickEvent(chkRegiones, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_CTA":  //consultas 
                    chkConsultas.Value = Boolean.Parse(sValor);
                    chkConsultas_ClickEvent(chkConsultas, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_CON":  //consultas/concentrado 
                    chkConcentrado.Value = Boolean.Parse(sValor);
                    chkConcentrado_ClickEvent(chkConcentrado, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_CEJ":  //empresas/ejecutivos 
                    chkEmpEje.Value = Boolean.Parse(sValor);
                    chkEmpEje_ClickEvent(chkEmpEje, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_CEM":  //grupo/empresas 
                    chkGpoEmp.Value = Boolean.Parse(sValor);
                    chkGpoEmp_ClickEvent(chkGpoEmp, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_ANA":  //consumos por giro 
                    chkConsumos.Value = Boolean.Parse(sValor);
                    chkConsumos_ClickEvent(chkConsumos, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_DET":  //detalle 
                    chkDetalle.Value = Boolean.Parse(sValor);
                    chkDetalle_ClickEvent(chkDetalle, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_ATR":  //atrasos por ejecutivo 
                    chkAtrasos.Value = Boolean.Parse(sValor);
                    chkAtrasos_ClickEvent(chkAtrasos, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_DEJ":  //ejecutivos banamex 
                    chkEjeBanamex.Value = Boolean.Parse(sValor);
                    chkEjeBanamex_ClickEvent(chkEjeBanamex, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_AFI":  //empresa afiliadas 
                    chkAfiliadas.Value = Boolean.Parse(sValor);
                    chkAfiliadas_ClickEvent(chkAfiliadas, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_GER":  //crystal report 
                    chkCrystal.Value = Boolean.Parse(sValor);
                    chkCrystal_ClickEvent(chkCrystal, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_EER":  //estatus envio reportes 
                    chkEnvioRep.Value = Boolean.Parse(sValor);
                    chkEnvioRep_ClickEvent(chkEnvioRep, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "mnu_envio_sbf":  //envio sbf 
                    chkSBF.Value = Boolean.Parse(sValor);
                    chkSBF_ClickEvent(chkSBF, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_REN":  //rentabilidad 
                    chkRentabilidad.Value = Boolean.Parse(sValor);
                    chkRentabilidad_ClickEvent(chkRentabilidad, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_BNX":  //ejecutivos banamex 
                    chkEjeBnx.Value = Boolean.Parse(sValor);
                    chkEjeBnx_ClickEvent(chkEjeBnx, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_GRA":  //graficas 
                    chkGraficas.Value = Boolean.Parse(sValor);
                    chkGraficas_ClickEvent(chkGraficas, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_GBIT":  //bitacoras 
                    chkBitacora.Value = Boolean.Parse(sValor);
                    chkBitacora_ClickEvent(chkBitacora, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_GCOR":  //corporativos 
                    chkCorporo.Value = Boolean.Parse(sValor);
                    chkCorporo_ClickEvent(chkCorporo, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_GEMP":  //empresas 
                    chkEmp.Value = Boolean.Parse(sValor);
                    chkEmp_ClickEvent(chkEmp, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_GACL":  //aclaraciones 
                    chkAclaraciones.Value = Boolean.Parse(sValor);
                    chkAclaraciones_ClickEvent(chkAclaraciones, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_GSIT":  //situación de la cta 
                    chkSituacion.Value = Boolean.Parse(sValor);
                    chkSituacion_ClickEvent(chkSituacion, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_GCRE":  //creditos 
                    chkCreditos.Value = Boolean.Parse(sValor);
                    chkCreditos_ClickEvent(chkCreditos, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_GANT":  //antiguedad de la cta 
                    chkAntiguedad.Value = Boolean.Parse(sValor);
                    chkAntiguedad_ClickEvent(chkAntiguedad, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_GVEN":  //vencidos 
                    chkVencidos.Value = Boolean.Parse(sValor);
                    chkVencidos_ClickEvent(chkVencidos, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_GCOM":  //comparativos 
                    chkComparativos.Value = Boolean.Parse(sValor);
                    chkComparativos_ClickEvent(chkComparativos, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_OPC":  //opciones 
                    chkOpciones.Value = Boolean.Parse(sValor);
                    chkOpciones_ClickEvent(chkOpciones, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_ACL":  //aclaraciones 
                    chkAclara.Value = Boolean.Parse(sValor);
                    chkAclara_ClickEvent(chkAclara, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
                case "IDM_CAP":  //emulador 
                    chkEmulador.Value = Boolean.Parse(sValor);
                    chkEmulador_ClickEvent(chkEmulador, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
                    break;
            }
        }

        private void Carga_Acceso(string sClave)
        {

            string sMenu = String.Empty;
            string sValor = String.Empty;

            CORVAR.pszgblsql = "select";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where men_gpo_clave = " + sClave;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and men_tipo_prod = '" + mdlParametros.gprdProducto.TipoProductoS + "'";

            if (CORPROC2.Obtiene_Registros() != 0)
            {

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    sMenu = CORVB.NULL_STRING;
                    sValor = CORVB.NULL_STRING;
                    sMenu = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                    sValor = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    Asigna_Valor(sMenu, ref sValor);
                };
            }

        }

        private void Inserta_Opciones_Menu(string iNumProceso)
        {

            //Lee el arreglo
            string sProcesoM = arrayAcceso[Int32.Parse(iNumProceso)].sProceso;
            string sProcesoAltas = arrayAcceso[Int32.Parse(iNumProceso)].bAltas.ToString();
            string sProcesoBajas = arrayAcceso[Int32.Parse(iNumProceso)].bBajas.ToString();
            string sProcesoConsultas = arrayAcceso[Int32.Parse(iNumProceso)].bConsultas.ToString();
            string sProcesoCambios = arrayAcceso[Int32.Parse(iNumProceso)].bCambios.ToString();

            //**********Altas**********
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + sProcesoM + "Altas" + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + sProcesoAltas + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";
            if (CORPROC2.Modifica_Registro() != 0)
            {
            }
            else
            {
                MessageBox.Show("No se actualizo el resgistro en la opción de " + sProcesoM + "/Altas", Application.ProductName);
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            //**********Bajas**********
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + sProcesoM + "Bajas" + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + sProcesoBajas + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";
            if (CORPROC2.Modifica_Registro() != 0)
            {
            }
            else
            {
                MessageBox.Show("No se actualizo el resgistro en la opción de " + sProcesoM + "/Bajas", Application.ProductName);
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            //**********Consultas**********
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + sProcesoM + "Consultas" + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + sProcesoConsultas + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";
            if (CORPROC2.Modifica_Registro() != 0)
            {
            }
            else
            {
                MessageBox.Show("No se actualizo el resgistro en la opción de " + sProcesoM + "/Consultas", Application.ProductName);
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            //Cambios
            CORVAR.pszgblsql = "insert into MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_tipo_prod)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + Conversion.Val(txtClave.Text).ToString() + ",";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtDescripcion.Text + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + sProcesoM + "Cambios" + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + sProcesoCambios + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + mdlParametros.gprdProducto.TipoProductoS + "')";
            if (CORPROC2.Modifica_Registro() != 0)
            {
            }
            else
            {
                MessageBox.Show("No se actualizo el resgistro en la opción de " + sProcesoM + "/Cambios", Application.ProductName);
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);


        }


        private void chk_altas_masivas_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {
            if (chk_altas_masivas.Value)
            {
                chkArchivos.Value = true;
            }
        }

        private void chk_categorias_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {
            msProceso = CORVB.NULL_STRING;

            if (chk_categorias.Value)
            {
                chkArchivos.Value = true;

                //habilita el panel de acceso
                pnlAcceso.Enabled = true;

                msProceso = "Categorias";

                if (!bAccesoUnidades)
                {
                    bAccesoUnidades = true;
                    //limpia el acceso de control a los niveles
                    chkAccesoNivel[0].Value = false;
                    chkAccesoNivel[1].Value = false;
                    chkAccesoNivel[2].Value = false;
                    chkAccesoNivel[3].Value = false;
                }


                chkAccesoNivel[0].Value = arrayAcceso[0].bAltas;
                chkAccesoNivel[1].Value = arrayAcceso[0].bBajas;
                chkAccesoNivel[2].Value = arrayAcceso[0].bCambios;
                chkAccesoNivel[3].Value = arrayAcceso[0].bConsultas;

                if (CORSGGRU.DefInstance.Tag.ToString() == "Altas")
                {
                    chkAccesoNivel[0].Focus();
                }

            }
            else
            {
                chkAccesoNivel[0].Value = false;
                chkAccesoNivel[1].Value = false;
                chkAccesoNivel[2].Value = false;
                chkAccesoNivel[3].Value = false;
            }

        }

        private void chk_estatus_cdf_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {
            if (chk_estatus_cdf.Value)
            {
                chkConfigurar.Value = true;
            }
        }

        private void chk_Estruct_Gastos_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {
            msProceso = CORVB.NULL_STRING;

            if (chk_Estruct_Gastos.Value)
            {
                chkArchivos.Value = true;

                //habilita el panel de acceso
                pnlAcceso.Enabled = true;

                msProceso = "Estructuras";

                if (!bAccesoEstructuras)
                {
                    bAccesoEstructuras = true;
                    //limpia el acceso de control a los niveles
                    chkAccesoNivel[0].Value = false;
                    chkAccesoNivel[1].Value = false;
                    chkAccesoNivel[2].Value = false;
                    chkAccesoNivel[3].Value = false;
                }


                chkAccesoNivel[0].Value = arrayAcceso[0].bAltas;
                chkAccesoNivel[1].Value = arrayAcceso[0].bBajas;
                chkAccesoNivel[2].Value = arrayAcceso[0].bCambios;
                chkAccesoNivel[3].Value = arrayAcceso[0].bConsultas;

                if (CORSGGRU.DefInstance.Tag.ToString() == "Altas")
                {
                    chkAccesoNivel[0].Focus();
                }

            }
            else
            {
                chkAccesoNivel[0].Value = false;
                chkAccesoNivel[1].Value = false;
                chkAccesoNivel[2].Value = false;
                chkAccesoNivel[3].Value = false;
            }

        }

        private void chk_Reportes_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {
            msProceso = CORVB.NULL_STRING;

            if (chk_Reportes.Value)
            {
                chkArchivos.Value = true;

                //habilita el panel de acceso
                pnlAcceso.Enabled = true;

                msProceso = "Reportes";

                if (!bAccesoUnidades)
                {
                    bAccesoUnidades = true;
                    //limpia el acceso de control a los niveles
                    chkAccesoNivel[0].Value = false;
                    chkAccesoNivel[1].Value = false;
                    chkAccesoNivel[2].Value = false;
                    chkAccesoNivel[3].Value = false;
                }


                chkAccesoNivel[0].Value = arrayAcceso[0].bAltas;
                chkAccesoNivel[1].Value = arrayAcceso[0].bBajas;
                chkAccesoNivel[2].Value = arrayAcceso[0].bCambios;
                chkAccesoNivel[3].Value = arrayAcceso[0].bConsultas;

                if (CORSGGRU.DefInstance.Tag.ToString() == "Altas")
                {
                    chkAccesoNivel[0].Focus();
                }

            }
            else
            {
                chkAccesoNivel[0].Value = false;
                chkAccesoNivel[1].Value = false;
                chkAccesoNivel[2].Value = false;
                chkAccesoNivel[3].Value = false;
            }

        }

        private void chk_unidades_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {
            msProceso = CORVB.NULL_STRING;

            if (chk_unidades.Value)
            {
                chkArchivos.Value = true;

                //habilita el panel de acceso
                pnlAcceso.Enabled = true;

                msProceso = "Unidades";

                if (!bAccesoUnidades)
                {
                    bAccesoUnidades = true;
                    //limpia el acceso de control a los niveles
                    chkAccesoNivel[0].Value = false;
                    chkAccesoNivel[1].Value = false;
                    chkAccesoNivel[2].Value = false;
                    chkAccesoNivel[3].Value = false;
                }


                chkAccesoNivel[0].Value = arrayAcceso[0].bAltas;
                chkAccesoNivel[1].Value = arrayAcceso[0].bBajas;
                chkAccesoNivel[2].Value = arrayAcceso[0].bCambios;
                chkAccesoNivel[3].Value = arrayAcceso[0].bConsultas;

                if (CORSGGRU.DefInstance.Tag.ToString() == "Altas")
                {
                    chkAccesoNivel[0].Focus();
                }

            }
            else
            {
                chkAccesoNivel[0].Value = false;
                chkAccesoNivel[1].Value = false;
                chkAccesoNivel[2].Value = false;
                chkAccesoNivel[3].Value = false;
            }

        }

        private void chkAccesoNivel_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {
            int Index = Array.IndexOf(chkAccesoNivel, eventSender);
            int iIndice = 0;

            if (msProceso != CORVB.NULL_STRING)
            {

                switch (msProceso)
                {
                    case "Estructuras":
                        iIndice = 0;
                        arrayAcceso[iIndice].sProceso = msProceso;
                        break;
                    case "Corporativo":
                        iIndice = 1;
                        arrayAcceso[iIndice].sProceso = msProceso;
                        break;
                    case "Empresas":
                        iIndice = 2;
                        arrayAcceso[iIndice].sProceso = msProceso;
                        break;
                    case "Unidades":
                        iIndice = 3;
                        arrayAcceso[iIndice].sProceso = msProceso;
                        break;
                    case "Tarjetahabientes":
                        iIndice = 4;
                        arrayAcceso[iIndice].sProceso = msProceso;
                        break;
                    case "Ejecutivos":
                        iIndice = 5;
                        arrayAcceso[iIndice].sProceso = msProceso;
                        break;
                    case "Divisiones":
                        iIndice = 6;
                        arrayAcceso[iIndice].sProceso = msProceso;
                        break;
                    case "Regiones":
                        iIndice = 7;
                        arrayAcceso[iIndice].sProceso = msProceso;
                        break;
                    case "Reportes":
                        iIndice = 8;
                        arrayAcceso[iIndice].sProceso = msProceso;
                        break;
                    case "Categorias":
                        iIndice = 9;
                        arrayAcceso[iIndice].sProceso = msProceso;
                        break;
                }

                switch (Index)
                {
                    case 0:
                        //AIS-1095 NGONZALEZ
                        arrayAcceso[iIndice].bAltas = eventArgs.value != 0;
                        break;
                    case 1:
                        //AIS-1095 NGONZALEZ
                        arrayAcceso[iIndice].bBajas = eventArgs.value != 0;
                        break;
                    case 2:
                        //AIS-1095 NGONZALEZ
                        arrayAcceso[iIndice].bCambios = eventArgs.value != 0;
                        break;
                    case 3:
                        //AIS-1095 NGONZALEZ
                        arrayAcceso[iIndice].bConsultas = eventArgs.value != 0;
                        break;
                }
            }

        }

        private void chkAclara_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            chkEmulador.Value = chkAclara.Value;
        }

        private void chkAclaraciones_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkAclaraciones.Value)
            {
                chkGraficas.Value = true;
                chkGraficas_ClickEvent(chkGraficas, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
            }
        }

        private void chkAfiliadas_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkAfiliadas.Value)
            {
                chkDetalle.Value = true;
                chkDetalle_ClickEvent(chkDetalle, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
            }
        }

        private void chkAntiguedad_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkAntiguedad.Value)
            {
                chkGraficas.Value = true;
                chkGraficas_ClickEvent(chkGraficas, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
            }
        }

        private void chkArchivos_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {


            if (!chkArchivos.Value)
            {
                chkCorporativos.Value = false;
                chkEmpresas.Value = false;
                chkTarjetahabientes.Value = false;
                chkEjecutivos.Value = false;
                chkDivisiones.Value = false;
                chkRegiones.Value = false;
                chk_unidades.Value = false;
                chk_Reportes.Value = false;
                chk_categorias.Value = false;
                chk_altas_masivas.Value = false;
                bAccesoArchivos = false;
                chkAccesoNivel[0].Value = false;
                chkAccesoNivel[1].Value = false;
                chkAccesoNivel[2].Value = false;
                chkAccesoNivel[3].Value = false;
                chkEnvioLimCred.Value = false;
                pnlAcceso.Enabled = false;
            }
            else
            {
                bAccesoArchivos = true;
            }
        }

        private void chkAtrasos_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkAtrasos.Value)
            {
                chkDetalle.Value = true;
                chkDetalle_ClickEvent(chkDetalle, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
            }
        }

        private void chkBanco_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkBanco.Value)
            {
                chkConfigurar.Value = true;
            }
        }

        private void chkBitacora_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkBitacora.Value)
            {
                chkGraficas.Value = true;
                chkGraficas_ClickEvent(chkGraficas, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
            }
        }

        private void chkCamMasivos_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkCamMasivos.Value)
            {
                chkConfigurar.Value = true;
            }
        }

        private void chkCCI_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkCCI.Value)
            {
                chkArchivos.Value = true;
            }
        }

        private void chkComparativos_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkComparativos.Value)
            {
                chkGraficas.Value = true;
                chkGraficas_ClickEvent(chkGraficas, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
            }
        }

        private void chkConcentrado_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (!chkConcentrado.Value)
            {
                chkEmpEje.Value = false;
                chkGpoEmp.Value = false;
            }
            else
            {
                chkConsultas.Value = true;
            }
        }

        private void chkConfigurar_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            //limpia el acceso de control a los niveles
            msProceso = CORVB.NULL_STRING;
            chkAccesoNivel[0].Value = false;
            chkAccesoNivel[1].Value = false;
            chkAccesoNivel[2].Value = false;
            chkAccesoNivel[3].Value = false;

            //inhabilita el panel de acceso
            pnlAcceso.Enabled = false;

            if (!chkConfigurar.Value)
            {
                chkParametros.Value = false;
                chkIntegracion.Value = false;
                chkCamMasivos.Value = false;
                chk_estatus_cdf.Value = false;
                chkLimCred.Value = false;
                chkSeguridad.Value = false;
                chkBanco.Value = false;
            }

        }

        private void chkConsultas_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            //limpia el acceso de control a los niveles
            msProceso = CORVB.NULL_STRING;
            chkAccesoNivel[0].Value = false;
            chkAccesoNivel[1].Value = false;
            chkAccesoNivel[2].Value = false;
            chkAccesoNivel[3].Value = false;

            //inhabilita el panel de acceso
            pnlAcceso.Enabled = false;

            if (!chkConsultas.Value)
            {
                chkConcentrado.Value = false;
                chkConsumos.Value = false;
                chkDetalle.Value = false;
                chkCrystal.Value = false;
                chkRentabilidad.Value = false;
                chkEjeBnx.Value = false;
                chkGraficas.Value = false;
                chkOpciones.Value = false;
                chkAclara.Value = false;
            }


        }

        private void chkConsumos_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkConsumos.Value)
            {
                chkConsultas.Value = true;
            }
        }

        private void chkCorporativos_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            msProceso = CORVB.NULL_STRING;

            if (chkCorporativos.Value)
            {
                chkArchivos.Value = true;

                //habilita el panel de acceso
                pnlAcceso.Enabled = true;

                msProceso = "Corporativo";

                if (!bAccesoCoroprativos)
                {
                    bAccesoCoroprativos = true;
                    //limpia el acceso de control a los niveles
                    chkAccesoNivel[0].Value = false;
                    chkAccesoNivel[1].Value = false;
                    chkAccesoNivel[2].Value = false;
                    chkAccesoNivel[3].Value = false;
                }


                chkAccesoNivel[0].Value = arrayAcceso[0].bAltas;
                chkAccesoNivel[1].Value = arrayAcceso[0].bBajas;
                chkAccesoNivel[2].Value = arrayAcceso[0].bCambios;
                chkAccesoNivel[3].Value = arrayAcceso[0].bConsultas;

                if (CORSGGRU.DefInstance.Tag.ToString() == "Altas")
                {
                    chkAccesoNivel[0].Focus();
                }

            }
            else
            {
                chkAccesoNivel[0].Value = false;
                chkAccesoNivel[1].Value = false;
                chkAccesoNivel[2].Value = false;
                chkAccesoNivel[3].Value = false;
            }

        }

        private void chkCorporo_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkCorporo.Value)
            {
                chkGraficas.Value = true;
                chkGraficas_ClickEvent(chkGraficas, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
            }
        }

        private void chkCreditos_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkCreditos.Value)
            {
                chkGraficas.Value = true;
                chkGraficas_ClickEvent(chkGraficas, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
            }
        }

        private void chkCrystal_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkCrystal.Value)
            {
                chkConsultas.Value = true;
            }
        }

        private void chkDepuracion_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkDepuracion.Value)
            {
                chkInterfaces.Value = true;
            }
        }

        private void chkDetalle_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (!chkDetalle.Value)
            {
                chkAtrasos.Value = false;
                chkEjeBanamex.Value = false;
                chkAfiliadas.Value = false;
            }
            else
            {
                chkConsultas.Value = true;
            }
        }

        private void chkDivisiones_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            msProceso = CORVB.NULL_STRING;

            if (chkDivisiones.Value)
            {
                chkArchivos.Value = true;


                //habilita el panel de acceso
                pnlAcceso.Enabled = true;

                msProceso = "Divisiones";

                if (!bAccesoDivisiones)
                {
                    bAccesoDivisiones = true;
                    //limpia el acceso de control a los niveles
                    chkAccesoNivel[0].Value = false;
                    chkAccesoNivel[1].Value = false;
                    chkAccesoNivel[2].Value = false;
                    chkAccesoNivel[3].Value = false;
                }

                chkAccesoNivel[0].Value = arrayAcceso[4].bAltas;
                chkAccesoNivel[1].Value = arrayAcceso[4].bBajas;
                chkAccesoNivel[2].Value = arrayAcceso[4].bCambios;
                chkAccesoNivel[3].Value = arrayAcceso[4].bConsultas;


                if (CORSGGRU.DefInstance.Tag.ToString() == "Altas")
                {
                    chkAccesoNivel[0].Focus();
                }

            }
            else
            {
                chkAccesoNivel[0].Value = false;
                chkAccesoNivel[1].Value = false;
                chkAccesoNivel[2].Value = false;
                chkAccesoNivel[3].Value = false;

            }
        }

        private void chkEjeBanamex_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkEjeBanamex.Value)
            {
                chkDetalle.Value = true;
                chkDetalle_ClickEvent(chkDetalle, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
            }
        }

        private void chkEjeBnx_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkEjeBnx.Value)
            {
                chkEjeBnx.Value = true;
            }
        }

        private void chkEjecutivos_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            msProceso = CORVB.NULL_STRING;

            if (chkEjecutivos.Value)
            {
                chkArchivos.Value = true;


                //habilita el panel de acceso
                pnlAcceso.Enabled = true;

                msProceso = "Ejecutivos";

                if (!bAccesoEjecutivos)
                {
                    bAccesoEjecutivos = true;
                    //limpia el acceso de control a los niveles
                    chkAccesoNivel[0].Value = false;
                    chkAccesoNivel[1].Value = false;
                    chkAccesoNivel[2].Value = false;
                    chkAccesoNivel[3].Value = false;
                }

                chkAccesoNivel[0].Value = arrayAcceso[3].bAltas;
                chkAccesoNivel[1].Value = arrayAcceso[3].bBajas;
                chkAccesoNivel[2].Value = arrayAcceso[3].bCambios;
                chkAccesoNivel[3].Value = arrayAcceso[3].bConsultas;

                if (CORSGGRU.DefInstance.Tag.ToString() == "Altas")
                {
                    chkAccesoNivel[0].Focus();
                }

            }
            else
            {
                chkAccesoNivel[0].Value = false;
                chkAccesoNivel[1].Value = false;
                chkAccesoNivel[2].Value = false;
                chkAccesoNivel[3].Value = false;
            }

        }

        private void chkEmp_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkEmp.Value)
            {
                chkGraficas.Value = true;
                chkGraficas_ClickEvent(chkGraficas, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
            }
        }

        private void chkEmpEje_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkEmpEje.Value)
            {
                chkConcentrado.Value = true;
                chkConcentrado_ClickEvent(chkConcentrado, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
            }
        }

        private void chkEmpresas_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            msProceso = CORVB.NULL_STRING;

            if (chkEmpresas.Value)
            {
                chkArchivos.Value = true;


                //habilita el panel de acceso
                pnlAcceso.Enabled = true;

                msProceso = "Empresas";
                if (!bAccesoEmpresas)
                {
                    bAccesoEmpresas = true;
                    //limpia el acceso de control a los niveles
                    chkAccesoNivel[0].Value = false;
                    chkAccesoNivel[1].Value = false;
                    chkAccesoNivel[2].Value = false;
                    chkAccesoNivel[3].Value = false;
                }

                chkAccesoNivel[0].Value = arrayAcceso[1].bAltas;
                chkAccesoNivel[1].Value = arrayAcceso[1].bBajas;
                chkAccesoNivel[2].Value = arrayAcceso[1].bCambios;
                chkAccesoNivel[3].Value = arrayAcceso[1].bConsultas;

                if (CORSGGRU.DefInstance.Tag.ToString() == "Altas")
                {
                    chkAccesoNivel[0].Focus();
                }
            }
            else
            {

                chkAccesoNivel[0].Value = false;
                chkAccesoNivel[1].Value = false;
                chkAccesoNivel[2].Value = false;
                chkAccesoNivel[3].Value = false;
            }
        }

        private void chkEmulador_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkEmulador.Value)
            {
                chkAclara.Value = true;
                chkAclara_ClickEvent(chkAclara, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
            }
        }

        private void chkEnvioLimCred_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {
            if (chkEnvioLimCred.Value)
            {
                chkArchivos.Value = true;
            }
        }

        private void chkEnvioRep_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkEnvioRep.Value)
            {
                chkConsultas.Value = true;
            }

        }

        private void chkGpoEmp_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkGpoEmp.Value)
            {
                chkConcentrado.Value = true;
                chkConcentrado_ClickEvent(chkConcentrado, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
            }
        }

        private void chkGraficas_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (!chkGraficas.Value)
            {
                chkBitacora.Value = false;
                chkCorporo.Value = false;
                chkEmp.Value = false;
                chkAclaraciones.Value = false;
                chkSituacion.Value = false;
                chkCreditos.Value = false;
                chkAntiguedad.Value = false;
                chkVencidos.Value = false;
                chkComparativos.Value = false;
            }
            else
            {
                chkConsultas.Value = true;
            }
        }

        private void chkGrupo_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkGrupo.Value)
            {
                chkSeguridad.Value = true;
                chkSeguridad_ClickEvent(chkSeguridad, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
            }
        }

        private void chkIntegracion_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkIntegracion.Value)
            {
                chkConfigurar.Value = true;
            }
        }

        private void chkInterfaces_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            //limpia el acceso de control a los niveles
            msProceso = CORVB.NULL_STRING;
            chkAccesoNivel[0].Value = false;
            chkAccesoNivel[1].Value = false;
            chkAccesoNivel[2].Value = false;
            chkAccesoNivel[3].Value = false;


            //inhabilita el panel de acceso
            pnlAcceso.Enabled = false;

            if (!chkInterfaces.Value)
            {
                chkTransmision.Value = false;
                chkDepuracion.Value = false;
            }
        }

        private void chkLimCred_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkLimCred.Value)
            {
                chkConfigurar.Value = true;
            }
        }

        private void chkOpciones_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkOpciones.Value)
            {
                chkConsultas.Value = true;
            }
        }

        private void chkParametros_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkParametros.Value)
            {
                chkConfigurar.Value = true;
            }
        }


        private void chkRegiones_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            msProceso = CORVB.NULL_STRING;

            if (chkRegiones.Value)
            {
                chkArchivos.Value = true;


                //habilita el panel de acceso
                pnlAcceso.Enabled = true;

                msProceso = "Regiones";

                if (!bAccesoRegiones)
                {
                    bAccesoRegiones = true;
                    //limpia el acceso de control a los niveles
                    chkAccesoNivel[0].Value = false;
                    chkAccesoNivel[1].Value = false;
                    chkAccesoNivel[2].Value = false;
                    chkAccesoNivel[3].Value = false;
                }

                chkAccesoNivel[0].Value = arrayAcceso[5].bAltas;
                chkAccesoNivel[1].Value = arrayAcceso[5].bBajas;
                chkAccesoNivel[2].Value = arrayAcceso[5].bCambios;
                chkAccesoNivel[3].Value = arrayAcceso[5].bConsultas;


                if (CORSGGRU.DefInstance.Tag.ToString() == "Altas")
                {
                    chkAccesoNivel[0].Focus();
                }

            }
            else
            {
                chkAccesoNivel[0].Value = false;
                chkAccesoNivel[1].Value = false;
                chkAccesoNivel[2].Value = false;
                chkAccesoNivel[3].Value = false;

            }
        }

        private void chkRentabilidad_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkRentabilidad.Value)
            {
                chkConsultas.Value = true;
            }
        }

        private void chkSBF_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkSBF.Value)
            {
                chkConsultas.Value = true;
            }

        }

        private void chkSeguridad_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkSeguridad.Value)
            {
                chkConfigurar.Value = true;
            }
            else
            {
                chkGrupo.Value = false;
                chkUsuario.Value = false;
            }
        }

        private void chkSituacion_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkSituacion.Value)
            {
                chkGraficas.Value = true;
                chkGraficas_ClickEvent(chkGraficas, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
            }
        }

        private void chkTarjetahabientes_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            msProceso = CORVB.NULL_STRING;

            if (chkTarjetahabientes.Value)
            {
                chkArchivos.Value = true;


                //habilita el panel de acceso
                pnlAcceso.Enabled = true;

                msProceso = "Tarjetahabientes";

                if (!bAccesoTarjetahabientes)
                {
                    //limpia el acceso de control a los niveles
                    chkAccesoNivel[0].Value = false;
                    chkAccesoNivel[1].Value = false;
                    chkAccesoNivel[2].Value = false;
                    chkAccesoNivel[3].Value = false;
                    bAccesoTarjetahabientes = true;
                }

                chkAccesoNivel[0].Value = arrayAcceso[2].bAltas;
                chkAccesoNivel[1].Value = arrayAcceso[2].bBajas;
                chkAccesoNivel[2].Value = arrayAcceso[2].bCambios;
                chkAccesoNivel[3].Value = arrayAcceso[2].bConsultas;

                if (CORSGGRU.DefInstance.Tag.ToString() == "Altas")
                {
                    chkAccesoNivel[0].Focus();
                }

            }
            else
            {
                chkAccesoNivel[0].Value = false;
                chkAccesoNivel[1].Value = false;
                chkAccesoNivel[2].Value = false;
                chkAccesoNivel[3].Value = false;
            }
        }

        private void chkTransmision_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkTransmision.Value)
            {
                chkInterfaces.Value = true;
            }
        }

        private void chkUsuario_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkUsuario.Value)
            {
                chkSeguridad.Value = true;
                chkSeguridad_ClickEvent(chkSeguridad, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
            }
        }

        private void chkVencidos_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            if (chkVencidos.Value)
            {
                chkGraficas.Value = true;
                chkGraficas_ClickEvent(chkGraficas, new AxThreed.ISSCBCtrlEvents_ClickEvent(-1));
            }
        }



        private void cmbCancelar_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        private void cmdAceptar_Click(Object eventSender, EventArgs eventArgs)
        {

            //Verifica que no esten en blanco la clave y descripción
            if (txtClave.Text == CORVB.NULL_STRING)
            {
                MessageBox.Show(" Se requiere capturar la clave", Application.ProductName);
                return;
            }

            if (txtDescripcion.Text == CORVB.NULL_STRING)
            {
                MessageBox.Show(" Se requiere capturar la Descripción", Application.ProductName);
                return;
            }
            try
            {
                //Cambios
                if (CORSGGRU.DefInstance.Tag.ToString() == "Cambio")
                {
                    this.Cursor = Cursors.WaitCursor;

                    CORVAR.pszgblsql = "delete from MTCMEN01 ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where men_gpo_clave =  " + txtClave.Text;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and men_tipo_prod = '" + mdlParametros.gprdProducto.TipoProductoS + "'";

                    if (CORPROC2.Modifica_Registro() != 0)
                    {
                        CORSGGRU.DefInstance.Tag = "Altas";
                        Arma_Insert();
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("No se pudo realizar la operación.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        return;
                    }
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                }

                //Altas
                if (CORSGGRU.DefInstance.Tag.ToString() == "Alta")
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (Checa_Repetido(txtClave.Text.Trim()) != 0)
                    {
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox(STR_SEG_REP_CVE, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                        txtClave.Focus();
                        return;
                    }
                    Arma_Insert();
                }

                //Consultas
                if (CORSGGRU.DefInstance.Tag.ToString() == "Consultas")
                {
                    this.Close();
                    return;
                }

                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("Se realizó con éxito la operación.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                this.Close();
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(cmdAceptar_Click)", e);
            }

        }

        private int Checa_Repetido(string pszGrupo)
        {

            int hStmt = 0;
            int hGrupo = 0;

            int bBandera = 0;

            CORVAR.pszgblsql = "select";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_clave";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where men_gpo_clave = " + pszGrupo;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and men_tipo_prod = '" + mdlParametros.gprdProducto.TipoProductoS + "'";

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                bBandera = -1;
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            return bBandera;

        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {


            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);

            string szCveGrupo = Strings.Mid(VB6.GetItemString(CORSGGRU.DefInstance.ID_GRU_GRU_LB, ListBoxHelper.GetSelectedIndex(CORSGGRU.DefInstance.ID_GRU_GRU_LB)), 1, CORBD.LEN_GRU_CVE).Trim();
            string szDescGrupo = Strings.Mid(VB6.GetItemString(CORSGGRU.DefInstance.ID_GRU_GRU_LB, ListBoxHelper.GetSelectedIndex(CORSGGRU.DefInstance.ID_GRU_GRU_LB)), CORBD.LEN_GRU_CVE + 1).Trim();

            //Inhabilita el panel de acceso
            pnlAcceso.Enabled = false;

            bAccesoEstructuras = false;
            bAccesoCoroprativos = false;
            bAccesoEmpresas = false;
            bAccesoUnidades = false;
            bAccesoTarjetahabientes = false;
            bAccesoEjecutivos = false;
            bAccesoDivisiones = false;
            bAccesoRegiones = false;

            switch (CORSGGRU.DefInstance.Tag.ToString())
            {
                case "Alta":
                    txtClave.Text = CORVB.NULL_STRING;
                    txtDescripcion.Text = CORVB.NULL_STRING;
                    txtClave.Enabled = true;
                    txtDescripcion.Enabled = true;
                    cmdAceptar.Enabled = true;
                    cmbCancelar.Enabled = true;

                    break;
                case "Cambio":
                    Carga_Acceso(szCveGrupo);
                    txtClave.Text = szCveGrupo;
                    txtDescripcion.Text = szDescGrupo;
                    txtClave.Enabled = false;
                    txtDescripcion.Enabled = true;
                    cmdAceptar.Enabled = true;
                    cmbCancelar.Enabled = true;

                    break;
                case "Consultas":
                    Carga_Acceso(szCveGrupo);
                    txtClave.Text = szCveGrupo;
                    txtDescripcion.Text = szDescGrupo;
                    txtClave.Enabled = false;
                    txtDescripcion.Enabled = false;
                    cmdAceptar.Enabled = false;
                    cmbCancelar.Enabled = true;

                    pnlGrupo.Enabled = false;
                    pnlArchivos.Enabled = false;
                    pnlInterfaces.Enabled = false;
                    pnlConsultas.Enabled = false;
                    pnlAcceso.Enabled = false;

                    break;
            }

        }
        private void frmAcceso_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}