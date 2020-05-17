using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Net;
using System.IO;
using System.Configuration;
using Microsoft.Win32;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    public class mdlSeguridad
    {

        static public string Stdl_ses_id = String.Empty;
        static public string Stdl_ses_id_MM = String.Empty;
        static public string Stdl_ope_id = String.Empty;
        static public string Stdl_ope_id_MM = String.Empty;

        static public string _SOAID = String.Empty;
        
        /// <summary>
        /// Variable para obtener el SIRH del config
        /// Autor: LMHR & CMET
        /// Fecha de creacion: 18/12/2017
        /// Fecha de ultima modificacion: 18/12/2017-->
        /// </summary>
        static public string _SIRH = string.Empty;

        public static string MFacultades(string slModulo, string _url, string _action)
        {
            string valor = string.Empty;

            XmlDocument soapEnvelop;

            string Response_code_s = string.Empty;
            string Response_desc = string.Empty;
            string Stds_err_txt = string.Empty;
            string Stds_usu_cvemodulo = string.Empty;
            string Stds_usu_valfacultad = string.Empty;

            soapEnvelop = CallWebServiceFacu(slModulo, _url, _action);

            XmlNodeList respuesta = soapEnvelop.GetElementsByTagName("SOAP-ENV:Body");
            XmlNodeList lista = ((XmlElement)respuesta[0]).GetElementsByTagName("ns1:ConOpeFaculResponse0");
            foreach (XmlElement nodo in lista)
            {

                int i = 0;
                XmlNodeList response_code = nodo.GetElementsByTagName("response_code");
                XmlNodeList response_desc = nodo.GetElementsByTagName("response_desc");
                XmlNodeList stds_err_txt = nodo.GetElementsByTagName("stds_err_txt");
                XmlNodeList stds_usu_cvemodulo = nodo.GetElementsByTagName("stds_usu_cvemodulo");
                XmlNodeList stds_usu_valfacultad = nodo.GetElementsByTagName("stds_usu_valfacultad");

                Response_code_s = response_code[i].InnerText;
                Response_desc = response_desc[i].InnerText;
                Stds_err_txt = stds_err_txt[i].InnerText;
                if (Response_code_s == "0011")
                    MessageBox.Show(Stds_err_txt + '\n', "Salir");
                else
                    Stds_usu_valfacultad = stds_usu_valfacultad[i].InnerText;
            }

            if (Response_code_s == "0000")
            {
                if (Stdl_ses_id != "" || Stdl_ses_id != null)
                {
                    valor = Stds_usu_valfacultad;
                }
                else
                {
                    valor = Response_desc + '\n' + "Error: " + Response_code_s + '\n' + Stds_err_txt + "Error seguridad";
                }
            }

            //MessageBox.Show(Stds_err_txt + '\n', "Salir");
            return valor;
        }

        public static XmlDocument CallWebServiceFacu(string sModulo, string _url, string _action)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            XmlDocument soapEnvelopeXml = null;

            soapEnvelopeXml = CreateSoapFacultad(mdlSeguridad.Stdl_ses_id, sModulo);

            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);
            asyncResult.AsyncWaitHandle.WaitOne();

            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
                soapEnvelop.LoadXml(soapResult);
            }
            return soapEnvelop;
        }

        private static XmlDocument CreateSoapFacultad(string Stdl_ses_id, string Stds_usu_cvemodulo)
        {
            XmlDocument soapEnvelop = new XmlDocument();

            string Smodule = string.Empty;

            if (Stds_usu_cvemodulo == "" || Stds_usu_cvemodulo == null)
            {
                Smodule = "0";
            }
            else
            {
                Smodule = Stds_usu_cvemodulo;
            }

            soapEnvelop.LoadXml(@"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/""><SOAP-ENV:Body><ConOpeFacul>" +
                "<txn_time>0</txn_time>" +
                "<trace_number>0</trace_number>" +
                "<stds_encryption>0</stds_encryption>" +
                "<stdl_ses_id>" + Stdl_ses_id + "</stdl_ses_id>" +
                "<stds_usu_cvemodulo>" + Smodule + "</stds_usu_cvemodulo>" +
                "<stds_oprn_cvesss>0</stds_oprn_cvesss>" +
                "</ConOpeFacul></SOAP-ENV:Body></SOAP-ENV:Envelope>");
            return soapEnvelop;
        }

        public static string Desfirma(string StrIp, int FirmaoDesfirma, string _url, string _action)
        {
            string valor = string.Empty;

            XmlDocument soapEnvelop;

            string Response_code_s = string.Empty;
            string Response_desc = string.Empty;
            string Stds_err_txt = string.Empty;
            string Stdi_ope_numofic = string.Empty;
            string Stds_ope_nombre = string.Empty;
            string Stdi_sol_rslt = string.Empty;

            soapEnvelop = CallWebServiceBaja(StrIp, _url, _action);

            XmlNodeList respuesta = soapEnvelop.GetElementsByTagName("SOAP-ENV:Body");
            XmlNodeList lista = ((XmlElement)respuesta[0]).GetElementsByTagName("ns1:BajaSesOpeResponse0");
            foreach (XmlElement nodo in lista)
            {
                int i = 0;
                XmlNodeList response_code = nodo.GetElementsByTagName("response_code");
                XmlNodeList response_desc = nodo.GetElementsByTagName("response_desc");
                XmlNodeList stds_err_txt = nodo.GetElementsByTagName("stds_err_txt");
                XmlNodeList stdi_ope_numofic = nodo.GetElementsByTagName("stdi_ope_numofic");
                XmlNodeList stds_ope_nombre = nodo.GetElementsByTagName("stds_ope_nombre");

                Response_code_s = response_code[i].InnerText;
                Response_desc = response_desc[i].InnerText;
                Stds_err_txt = stds_err_txt[i].InnerText;
            }

            if (Response_code_s == "0000")
            {
                if (Stdl_ses_id != "" || Stdl_ses_id != null)
                {
                    valor = "1";
                }
                else
                {
                    valor = Response_desc + '\n' + "Error: " + Response_code_s + '\n' + Stds_err_txt + '\n' + "Error seguridad";
                }
            }
            return valor;
        }

        public static XmlDocument CallWebServiceBaja(string StrIp, string _url, string _action)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            XmlDocument soapEnvelopeXml = null;

            soapEnvelopeXml = CreateSoapLogOut(StrIp, Stdl_ses_id);

            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);
            asyncResult.AsyncWaitHandle.WaitOne();

            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
                soapEnvelop.LoadXml(soapResult);
            }
            return soapEnvelop;
        }

        private static XmlDocument CreateSoapLogOut(string StrIp, string Stdl_ses_id)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            string session = string.Empty;

            if (Stdl_ses_id == "" || Stdl_ses_id == null)
            {
                session = "1";
            }
            else
            {
                session = Stdl_ses_id;
            }

            soapEnvelop.LoadXml(@"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/""><SOAP-ENV:Body><BajaSesOpe>" +
                "<txn_time>0</txn_time>" +
                "<trace_number>0</trace_number>" +
                "<stds_encryption>0</stds_encryption>" +
                "<stds_disp_numip>" + StrIp + "</stds_disp_numip>" +
                "<stdl_ses_id>" + session + "</stdl_ses_id>" +
                "<stdl_ope_id>" + Stdl_ope_id + "</stdl_ope_id>" +
                "<stdi_disp_numsuc>0</stdi_disp_numsuc>" +
                "<stdi_disp_numcaja>0</stdi_disp_numcaja>" +
                "<stds_ope_soeid></stds_ope_soeid>" +
                "<sssa_tkn_siteminder></sssa_tkn_siteminder>" +
                "</BajaSesOpe></SOAP-ENV:Body></SOAP-ENV:Envelope>");
            return soapEnvelop;
        }

        /// <summary>
        public static string Desfirma_checker(string StrIp, int FirmaoDesfirma, string _url, string _action)
        {
            string valor = string.Empty;

            XmlDocument soapEnvelop;

            string Response_code_s = string.Empty;
            string Response_desc = string.Empty;
            string Stds_err_txt = string.Empty;
            string Stdi_ope_numofic = string.Empty;
            string Stds_ope_nombre = string.Empty;
            string Stdi_sol_rslt = string.Empty;

            soapEnvelop = CallWebServiceBaja_checker(StrIp, _url, _action);

            XmlNodeList respuesta = soapEnvelop.GetElementsByTagName("SOAP-ENV:Body");
            XmlNodeList lista = ((XmlElement)respuesta[0]).GetElementsByTagName("ns1:BajaSesOpeResponse0");
            foreach (XmlElement nodo in lista)
            {
                int i = 0;
                XmlNodeList response_code = nodo.GetElementsByTagName("response_code");
                XmlNodeList response_desc = nodo.GetElementsByTagName("response_desc");
                XmlNodeList stds_err_txt = nodo.GetElementsByTagName("stds_err_txt");
                XmlNodeList stdi_ope_numofic = nodo.GetElementsByTagName("stdi_ope_numofic");
                XmlNodeList stds_ope_nombre = nodo.GetElementsByTagName("stds_ope_nombre");

                Response_code_s = response_code[i].InnerText;
                Response_desc = response_desc[i].InnerText;
                Stds_err_txt = stds_err_txt[i].InnerText;
            }

            //if (Response_code_s == "0000")
            //{
            //    if (Stdl_ses_id_MM != "" || Stdl_ses_id_MM != null)
            //    {
            //        valor = "1";
            //    }
            //    else
            //    {
            //        valor = Response_desc + '\n' + "Error: " + Response_code_s + '\n' + Stds_err_txt + '\n' + "Error seguridad";
            //    }
            //}
            return valor;
        }

        public static XmlDocument CallWebServiceBaja_checker(string StrIp, string _url, string _action)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            XmlDocument soapEnvelopeXml = null;

            soapEnvelopeXml = CreateSoapLogOut_checker(StrIp, Stdl_ses_id);

            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);
            asyncResult.AsyncWaitHandle.WaitOne();

            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
                soapEnvelop.LoadXml(soapResult);
            }
            return soapEnvelop;
        }

        private static XmlDocument CreateSoapLogOut_checker(string StrIp, string Stdl_ses_id_MM)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            string session = string.Empty;

            if (Stdl_ses_id_MM == "" || Stdl_ses_id_MM == null)
            {
                session = "1";
            }
            else
            {
                session = Stdl_ses_id_MM;
            }

            soapEnvelop.LoadXml(@"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/""><SOAP-ENV:Body><BajaSesOpe>" +
                "<txn_time>0</txn_time>" +
                "<trace_number>0</trace_number>" +
                "<stds_encryption>0</stds_encryption>" +
                "<stds_disp_numip>" + StrIp + "</stds_disp_numip>" +
                "<stdl_ses_id>" + Stdl_ses_id_MM + "</stdl_ses_id>" +
                "<stdl_ope_id>" + Stdl_ope_id_MM + "</stdl_ope_id>" +
                "<stdi_disp_numsuc>0</stdi_disp_numsuc>" +
                "<stdi_disp_numcaja>0</stdi_disp_numcaja>" +
                "<stds_ope_soeid></stds_ope_soeid>" +
                "<sssa_tkn_siteminder></sssa_tkn_siteminder>" +
                "</BajaSesOpe></SOAP-ENV:Body></SOAP-ENV:Envelope>");
            return soapEnvelop;
        }
        /// <returns></returns>

        /// 
        public static string Servicios_SSS_MM(string StrOpeSoeid, string StrPassword, string StrIp, string StrToken, string StrSist, int FirmaoDesfirma, string _url, string _action)
        {
            string valor = string.Empty;

            XmlDocument soapEnvelop;
            string Response_code_s_MM = string.Empty;
            string Response_desc_MM = string.Empty;
            string Stds_err_txt_MM = string.Empty;
            string Stdi_ope_numofic_MM = string.Empty;
            string Stds_ope_nombre_MM = string.Empty;
            string Stdi_sol_rslt_MM = string.Empty;
            string Stdl_ses_id_MM = string.Empty;
            string Stdl_ope_id_MM = string.Empty;
            string Stdi_disp_numcsi_MM = string.Empty;

            for (int j = 0; j <= 1; j++)
            {

                soapEnvelop = CallWebService_Checker(StrOpeSoeid, StrPassword, StrIp, StrToken, StrSist, FirmaoDesfirma, _url, _action);

                XmlNodeList respuesta = soapEnvelop.GetElementsByTagName("SOAP-ENV:Body");
                XmlNodeList lista = ((XmlElement)respuesta[0]).GetElementsByTagName("ns1:EAltaSesOpeResponse0");
                foreach (XmlElement nodo in lista)
                {
                    int i = 0;
                    XmlNodeList response_code = nodo.GetElementsByTagName("response_code");
                    XmlNodeList response_desc = nodo.GetElementsByTagName("response_desc");
                    XmlNodeList stds_err_txt = nodo.GetElementsByTagName("stds_err_txt");
                    XmlNodeList stdl_ses_id = nodo.GetElementsByTagName("stdl_ses_id");
                    XmlNodeList stdi_ope_numofic = nodo.GetElementsByTagName("stdi_ope_numofic");
                    XmlNodeList stds_ope_nombre = nodo.GetElementsByTagName("stds_ope_nombre");
                    XmlNodeList stdi_sol_rslt = nodo.GetElementsByTagName("stdi_sol_rslt");
                    XmlNodeList stdl_ope_id = nodo.GetElementsByTagName("stdl_ope_id");
                    XmlNodeList SOAID = nodo.GetElementsByTagName("stds_ope_soeid");
                    XmlNodeList stdi_disp_numcsi = nodo.GetElementsByTagName("stdi_disp_numcsi");

                    Response_code_s_MM = response_code[i].InnerText;
                    Response_desc_MM = response_desc[i].InnerText;
                    Stds_err_txt_MM = stds_err_txt[i].InnerText;
                    Stdl_ses_id_MM = stdl_ses_id[i].InnerText;
                    Stdi_ope_numofic_MM = stdi_ope_numofic[i].InnerText;
                    Stds_ope_nombre_MM = stds_ope_nombre[i].InnerText;
                    Stdi_sol_rslt_MM = stdi_sol_rslt[i].InnerText;
                    Stdl_ope_id_MM = stdl_ope_id[i].InnerText;
                    Stdi_disp_numcsi_MM = stdi_disp_numcsi[i].InnerText;
                }

                if (Response_code_s_MM == "0000")
                {
                    if (Convert.ToInt32(Stdi_sol_rslt_MM.Trim()) >= 0)
                    {
                        valor = "1";
                        break;
                    }
                    else
                    {
                        valor = "Error: Favor de proporcionar las credenciales correctas." + '\n' + "== > SOEID o Contraseña incorrectos." + '\n';
                        valor = valor + "O la combinación de ambos es incorrecta." + '\n' + "Verifiquelos con su Administrador si proporciona valores correctos." + '\n' + '\n';
                        valor = valor + "CSI : " + Stdi_disp_numcsi_MM + '\n' + "Error : " + Stdi_sol_rslt_MM + "  " + Stds_err_txt_MM;
                        break;
                    }
                }
                else if (j >= 1)
                {
                    valor = "Error: Favor de proporcionar las credenciales correctas." + '\n' + "== > SOEID o Contraseña incorrectos." + '\n';
                    valor = valor + "O la combinación de ambos es incorrecta." + '\n' + "Verifiquelos con su Administrador si proporciona valores correctos." + '\n' + '\n';
                    valor = valor + "CSI : " + Stdi_disp_numcsi_MM + '\n' + "Error : " + Stdi_sol_rslt_MM + "  " + Stds_err_txt_MM;
                }
            }

            return valor;
        }

        public static XmlDocument CallWebService_Checker(string StrOpeSoeid, string StrPassword, string StrIp, string StrToken, string StrSist, int fir, string _url, string _action)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            XmlDocument soapEnvelopeXml = null;

            soapEnvelopeXml = CreateSoapLogIn_Checker(StrOpeSoeid, StrPassword, StrIp, StrToken, StrSist);

            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);
            asyncResult.AsyncWaitHandle.WaitOne();

            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
                soapEnvelop.LoadXml(soapResult);
            }
            return soapEnvelop;
        }

        private static XmlDocument CreateSoapLogIn_Checker(string StrOpeSoeid, string StrPassword, string StrIp, string StrToken, string StrSist)
        {
            XmlDocument soapEnvelop = new XmlDocument();

            //string _numsuc = ConfigurationManager.AppSettings["_numsuc"];

            string _numsuc = mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\Parametros", "SSSSirh").Trim();

            //LMHR & CMET: Se obtiene el SIRH de manera global
            _SIRH = _numsuc;

            //if (StrToken != "")
            //{d
            //    StrPasswor = StrPassword + ":" + StrToken;
            //}

            soapEnvelop.LoadXml(@"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">" +
                "<SOAP-ENV:Body>" +
                "<EAltaSesOpe>" +
                "<txn_time></txn_time>" +
                "<trace_number></trace_number>" +
                "<stds_encryption>0</stds_encryption>" +
                "<stds_disp_numip>" + StrIp + "</stds_disp_numip>" +
                "<stdl_ope_id>0</stdl_ope_id>" +
                "<stds_otp>" + StrToken + "</stds_otp>" +
                "<stds_ope_soeid>" + StrOpeSoeid + "</stds_ope_soeid>" +
                "<stds_ope_valpass>" + StrPassword + "</stds_ope_valpass>" +
                "<sssa_tkn_siteminder></sssa_tkn_siteminder>" +
                "<stdl_ses_id>0</stdl_ses_id>" +
                "<stdi_disp_numsuc>" + _numsuc + "</stdi_disp_numsuc>" +
                "<stdi_disp_numcaja>0</stdi_disp_numcaja>" +
                "<stdn_oprn_cvesistorig>C430-001</stdn_oprn_cvesistorig>" +
                "<stdi_disp_numcsi>0</stdi_disp_numcsi>" +
                "<stdi_ofic_num>0</stdi_ofic_num>" +
                "</EAltaSesOpe>" +
                "</SOAP-ENV:Body>" +
                "</SOAP-ENV:Envelope>");
            return soapEnvelop;
        }
        ///

        public static string Servicios_SSS(string StrOpeSoeid, string StrPassword, string StrIp, string StrToken, string StrSist, int FirmaoDesfirma, string _url, string _action)
        {
            string valor = string.Empty;

            XmlDocument soapEnvelop;
            string Response_code_s = string.Empty;
            string Response_desc = string.Empty;
            string Stds_err_txt = string.Empty;
            string Stdi_ope_numofic = string.Empty;
            string Stds_ope_nombre = string.Empty;
            string Stdi_sol_rslt = string.Empty;
            string Stdi_disp_numcsi = string.Empty;

            for (int j = 0; j <= 1; j++)
            {

                soapEnvelop = CallWebService(StrOpeSoeid, StrPassword, StrIp, StrToken, StrSist, FirmaoDesfirma, _url, _action);

                XmlNodeList respuesta = soapEnvelop.GetElementsByTagName("SOAP-ENV:Body");
                XmlNodeList lista = ((XmlElement)respuesta[0]).GetElementsByTagName("ns1:EAltaSesOpeResponse0");
                foreach (XmlElement nodo in lista)
                {
                    int i = 0;
                    XmlNodeList response_code = nodo.GetElementsByTagName("response_code");
                    XmlNodeList response_desc = nodo.GetElementsByTagName("response_desc");
                    XmlNodeList stds_err_txt = nodo.GetElementsByTagName("stds_err_txt");
                    XmlNodeList stdl_ses_id = nodo.GetElementsByTagName("stdl_ses_id");
                    XmlNodeList stdi_ope_numofic = nodo.GetElementsByTagName("stdi_ope_numofic");
                    XmlNodeList stds_ope_nombre = nodo.GetElementsByTagName("stds_ope_nombre");
                    XmlNodeList stdi_sol_rslt = nodo.GetElementsByTagName("stdi_sol_rslt");
                    XmlNodeList stdl_ope_id = nodo.GetElementsByTagName("stdl_ope_id");
                    XmlNodeList SOAID = nodo.GetElementsByTagName("stds_ope_soeid");
                    XmlNodeList stdi_disp_numcsi = nodo.GetElementsByTagName("stdi_disp_numcsi");
                    
                    Response_code_s = response_code[i].InnerText;
                    Response_desc = response_desc[i].InnerText;
                    Stds_err_txt = stds_err_txt[i].InnerText;
                    Stdl_ses_id = stdl_ses_id[i].InnerText;
                    Stdi_ope_numofic = stdi_ope_numofic[i].InnerText;
                    Stds_ope_nombre = stds_ope_nombre[i].InnerText;
                    Stdi_sol_rslt = stdi_sol_rslt[i].InnerText;
                    Stdl_ope_id = stdl_ope_id[i].InnerText;
                    Seguridad.usugUsuario.NominaS = stdl_ope_id[i].InnerText;
                    Seguridad.usugUsuario.NombreS = stds_ope_nombre[i].InnerText;
                    _SOAID = SOAID[i].InnerText;
                    Stdi_disp_numcsi = stdi_disp_numcsi[i].InnerText;
                }

                if (Response_code_s == "0000")
                {
                    if (Convert.ToInt32(Stdi_sol_rslt.Trim()) >= 0)
                    {
                        valor = "1";
                        break;
                    }
                    else
                    {
                        valor = "Error: Favor de proporcionar las credenciales correctas." + '\n' + "== > SOEID o Contraseña incorrectos." + '\n';
                        valor = valor + "O la combinación de ambos es incorrecta." + '\n' + "Verifiquelos con su Administrador si proporciona valores correctos." + '\n' + '\n';
                        valor = valor + "CSI : " + Stdi_disp_numcsi + '\n' + "Error : " + Stdi_sol_rslt + "  " + Stds_err_txt;
                        break;
                    }
                }
                else if (j >= 1)
                {
                    valor = "Error: Favor de proporcionar las credenciales correctas." + '\n' + "== > SOEID o Contraseña incorrectos." + '\n';
                    valor = valor + "O la combinación de ambos es incorrecta." + '\n' + "Verifiquelos con su Administrador si proporciona valores correctos." + '\n' + '\n';
                    valor = valor + "CSI : " + Stdi_disp_numcsi + '\n' + "Error : " + Stdi_sol_rslt + "  " + Stds_err_txt;
                }
            }

            return valor;
        }

        public static XmlDocument CallWebService(string StrOpeSoeid, string StrPassword, string StrIp, string StrToken, string StrSist, int fir, string _url, string _action)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            XmlDocument soapEnvelopeXml = null;

            soapEnvelopeXml = CreateSoapLogIn(StrOpeSoeid, StrPassword, StrIp, StrToken, StrSist);

            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);
            asyncResult.AsyncWaitHandle.WaitOne();

            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
                soapEnvelop.LoadXml(soapResult);
            }
            return soapEnvelop;
        }

        private static XmlDocument CreateSoapLogIn(string StrOpeSoeid, string StrPassword, string StrIp, string StrToken, string StrSist)
        {
            XmlDocument soapEnvelop = new XmlDocument();

            //string _numsuc = ConfigurationManager.AppSettings["_numsuc"];
            
            string _numsuc = mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\Parametros", "SSSSirh").Trim();

            //LMHR & CMET: Se obtiene el SIRH de manera global
            _SIRH = _numsuc;

            //if (StrToken != "")
            //{
            //    StrPassword = StrPassword + ":" + StrToken;
            //}

            soapEnvelop.LoadXml(@"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">" +
                "<SOAP-ENV:Body>" +
                "<EAltaSesOpe>" +
                "<txn_time></txn_time>" +
                "<trace_number></trace_number>" +
                "<stds_encryption>0</stds_encryption>" +
                "<stds_disp_numip>" + StrIp + "</stds_disp_numip>" +
                "<stdl_ope_id>0</stdl_ope_id>" +
                "<stds_otp>" + StrToken + "</stds_otp>" +
                "<stds_ope_soeid>" + StrOpeSoeid + "</stds_ope_soeid>" +
                "<stds_ope_valpass>" + StrPassword + "</stds_ope_valpass>" +
                "<sssa_tkn_siteminder></sssa_tkn_siteminder>" +
                "<stdl_ses_id>0</stdl_ses_id>" +
                "<stdi_disp_numsuc>" + _numsuc + "</stdi_disp_numsuc>" +
                "<stdi_disp_numcaja>0</stdi_disp_numcaja>" +
                "<stdn_oprn_cvesistorig>C430-001</stdn_oprn_cvesistorig>" +
                "<stdi_disp_numcsi>0</stdi_disp_numcsi>" +
                "<stdi_ofic_num>0</stdi_ofic_num>" +
                "</EAltaSesOpe>" +
                "</SOAP-ENV:Body>" +
                "</SOAP-ENV:Envelope>");
            return soapEnvelop;
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }

        public static String GetIP()
        {
            string strHostName = "";
            string localIP = "";

            strHostName = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            foreach (var item in ipEntry.AddressList)
            {
                if (item.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = item.ToString();
                }
            }
            // PARA PRUEBAS FUERA DE PRISMA return "10.131.118.150";
            return localIP;
        }
        //AIS-1182 NGONZALEZ
        //#######SAPUF se incorporan el 18/05/06

        static public COMDRV32.TcpServer objSeguridad = null;
        static public int llNuevoCredito = 0;

        static public string sgDlgSeguridad = String.Empty;
        static public bool bgSeguridadS041 = false;

        static public bool bgChecaUser = false;
        static public int LogHandler = 0;

        public struct TDSeguridad
        {
            public string NominaS;
            public string PasswordS;
            public string VersionI;
            public static TDSeguridad CreateInstance()
            {
                TDSeguridad result = new TDSeguridad();
                result.NominaS = String.Empty;
                result.PasswordS = String.Empty;
                result.VersionI = String.Empty;
                return result;
            }
        }
        static public TDSeguridad tgSeguridad = mdlSeguridad.TDSeguridad.CreateInstance();

        public enum enuTipoDlgSeguridad
        {
            tFirmaConModuloS041 = 1,
            tFirmaSinModuloS041 = 2,
            tDesfirmaS041 = 3
        }

        //UPGRADE_NOTE: (7001) The following declaration (prWait) seems to be dead code
        //private void  prWait( int lpWait)
        //{
        //
        //
        //int llEnd = Environment.TickCount + lpWait;
        //do 
        //{
        //}
        //while(Environment.TickCount < llEnd);
        //
        //}

        //static public bool fncCargaComdriveB()
        //{

        //    bool result = false;
        //    try
        //    {
        //        if (mdlParametros.ES_DEBUG)
        //        {
        //            EnviaLog("Se va a Inicializar Comdrv32");
        //        }
        //        objSeguridad = new COMDRV32.TcpServer();

        //        if (mdlParametros.ES_DEBUG)
        //        {
        //            EnviaLog("Inicializado Comdrv32");
        //        }

        //        objSeguridad.Connect();
        //        if (mdlParametros.ES_DEBUG)
        //        {
        //            EnviaLog("Conectado");
        //        }


        //        return true;
        //    }
        //    catch (COMException excep)
        //    {

        //        if (excep.ErrorCode == 0x80072AFC)
        //        {
        //            MessageBox.Show(Information.Err().Number.ToString() + " direccion ip erronea", Application.ProductName);
        //            //UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
        //            throw new Exception("Migration Exception: 'Resume Next' not supported");
        //        }
        //        else
        //        {
        //            MessageBox.Show(excep.ErrorCode + " " + excep.Message, Application.ProductName);
        //            result = false;
        //        }
        //    }
        //    return result;
        //}

        //static public bool fncDescargaComdriveB()
        //{

        //    bool result = false;
        //    try
        //    {
        //        if (mdlParametros.ES_DEBUG)
        //        {
        //            MdlCambioMasivo.MsgInfo("Decargando Comdvr32");
        //        }
        //        objSeguridad.Disconnect();
        //        objSeguridad = null;

        //        return true;
        //    }
        //    catch (Exception e)
        //    {

        //        CRSGeneral.prObtenError("mdlSeguridad (DescargaComdrive)", e);
        //        result = false;
        //    }
        //    return result;
        //}

        //static public string fncEncripPassS(string spPassword, string spCadena, ref  int ipVersion, int ipOpcion)
        //{

        //    string result = String.Empty;
        //    int ilRes = 0;
        //    string slPass = String.Empty;
        //    string slRespuesta = String.Empty;
        //    string slResp2 = String.Empty;
        //    int ilVersion = 0;

        //    try
        //    {
        //        if (mdlParametros.ES_DEBUG)
        //        {
        //            EnviaLog("Llamando a FncEncripPassS spPassword:" + spPassword +
        //                     " spCadena:" + spCadena + " ipVersion:" + ipVersion.ToString() + " ipOpcion:" + ipOpcion.ToString());
        //        }

        //        switch (ipOpcion)
        //        {
        //            case 1:
        //                if (mdlParametros.ES_DEBUG)
        //                {
        //                    EnviaLog("Inicia_Encripcion(\", 0)");
        //                }
        //                //AIS-1182 NGONZALEZ
        //                ilRes = API.Encryption.Inicia_Encripcion("", 0);
        //                if (mdlParametros.ES_DEBUG)
        //                {
        //                    EnviaLog("ilRes :" + ilRes.ToString());
        //                }

        //                slPass = spPassword.Trim();
        //                slRespuesta = new string((char)255, 8);
        //                if (mdlParametros.ES_DEBUG)
        //                {
        //                    EnviaLog("slRespuesta:" + slRespuesta);
        //                    EnviaLog("E3Des( " + slPass + "," + slRespuesta + "," + ipVersion.ToString() + ")");
        //                }
        //                //AIS-1182 NGONZALEZ
        //                short tmpShort = (short)ipVersion;
        //                ilRes = API.Encryption.E3Des(slPass, ref slRespuesta, ref tmpShort);
        //                if (mdlParametros.ES_DEBUG)
        //                {
        //                    EnviaLog("slRespuesta:" + slRespuesta);
        //                }
        //                result = slRespuesta;

        //                break;
        //            case 2:
        //                if (mdlParametros.ES_DEBUG)
        //                {
        //                    EnviaLog("Inicia_Encripcion(" + spCadena + "," + ipVersion.ToString() + ")");
        //                }
        //                //AIS-1182 NGONZALEZ
        //                ilRes = API.Encryption.Inicia_Encripcion(spCadena, (short)ipVersion);
        //                if (mdlParametros.ES_DEBUG)
        //                {
        //                    EnviaLog("ilRes:" + ilRes.ToString());
        //                }

        //                slPass = spPassword.Trim();
        //                slResp2 = new string((char)255, 8);
        //                ilVersion = ipVersion;
        //                if (mdlParametros.ES_DEBUG)
        //                {
        //                    EnviaLog("slPass:" + slPass + "\r\n" +
        //                             "slResp2:" + slResp2 + "\r\n" +
        //                             "ilVersion:" + ilVersion.ToString() + "\r\n" +
        //                             "ilRes = E3Des(" + slPass + "," + slResp2 + "," + ilVersion.ToString() + ")");

        //                }
        //                //AIS-1182 NGONZALEZ
        //                tmpShort = (short)ipVersion;
        //                ilRes = API.Encryption.E3Des(slPass, ref slResp2, ref tmpShort);
        //                if (mdlParametros.ES_DEBUG)
        //                {
        //                    EnviaLog("fncEncripPassS = " + slResp2);
        //                }
        //                result = slResp2;
        //                break;
        //        }
        //        if (mdlParametros.ES_DEBUG)
        //        {
        //            EnviaLog("Salida Normal de la funcion fncEcripPassS");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        CRSGeneral.prObtenError("mdlSeguridad (EncriptaDato)", e);
        //        if (mdlParametros.ES_DEBUG)
        //        {
        //            EnviaLog("Salida Erronea de la funcion fncEcripPassS");
        //        }
        //        return result;
        //    }
        //    return result;
        //}

        static public string fncGenDlgSegS(string spNomina, string spPassword, string spToken, int ipVersion, enuTipoDlgSeguridad ipTipoDialogo)
        {

            string result = String.Empty;
            string slDialogo = String.Empty;

            try
            {
                EnviaLog("Iniciado generacion de Dialogo de Seguridad ");

                switch (ipTipoDialogo)
                {
                    case enuTipoDlgSeguridad.tFirmaConModuloS041:
                        slDialogo = "D";
                        slDialogo = slDialogo + "004104";  //Destino 
                        slDialogo = slDialogo + new String(' ', 6);  //Origen 
                        //slDialogo = slDialogo + "70025";  //Accion (Firma Con Modulos) 
                        slDialogo = slDialogo + "70027";  //Accion (Firma Con Modulos) //se cambia para el maneo de TOKEN
                        slDialogo = slDialogo + StringsHelper.Format(spNomina, "00000000");  //Nomina 
                        slDialogo = slDialogo + spPassword;  //Password 
                        slDialogo = slDialogo + StringsHelper.Format(ipVersion, "0000");  //Version 
                        if (spToken == "")
                            spToken = "000000";
                        slDialogo = slDialogo + StringsHelper.Format(spToken, "000000"); //se agrega para el manejo de TOKE
                        slDialogo = slDialogo + Strings.Chr(3).ToString();

                        break;
                    case enuTipoDlgSeguridad.tFirmaSinModuloS041:
                        slDialogo = "D";
                        slDialogo = slDialogo + "004104";  //Destino 
                        slDialogo = slDialogo + new String(' ', 6);  //Origen 
                        //slDialogo = slDialogo + "70020";  //Accion (Firma Sin Modulos) 
                        slDialogo = slDialogo + "70022";  //se cambia para el manejo de TOKEN
                        slDialogo = slDialogo + StringsHelper.Format(spNomina, "00000000");  //Nomina 
                        slDialogo = slDialogo + spPassword;  //Password                         
                        slDialogo = slDialogo + StringsHelper.Format(ipVersion, "0000");  //Version 
                        if (spToken == "")
                            spToken = "000000";
                        slDialogo = slDialogo + StringsHelper.Format(spToken, "000000");  //se agrega para el manejo de TOKEN
                        slDialogo = slDialogo + Strings.Chr(3).ToString();

                        break;
                    case enuTipoDlgSeguridad.tDesfirmaS041:
                        slDialogo = "D";
                        slDialogo = slDialogo + "004104";  //Destino 
                        slDialogo = slDialogo + new String(' ', 6);  //Origen 
                        slDialogo = slDialogo + "70030";  //Accion (Desfirma) 
                        slDialogo = slDialogo + Strings.Chr(3).ToString();

                        break;
                }
                result = slDialogo;
                //If ES_DEBUG Then
                EnviaLog("Dialogo de Seguridad Generado:" + "\r\n" +
                         slDialogo);
                // End If
            }
            catch (Exception e)
            {

                CRSGeneral.prObtenError("mdlSeguridad (GenDlgSeg)", e);
                return "";
            }


            return result;
        }

        static public bool fncFirmaS041B(ref  string spNomina, string spPassword, string spToken, enuTipoDlgSeguridad ipTipoFirma)
        {

            bool result = false;
            bool blContinue = false;

            string slPassEncr = String.Empty;
            string slDialogo = String.Empty;
            string slPassEncr2 = String.Empty;
            string slDialogo2 = String.Empty;
            string slRespuesta = String.Empty;
            string slVersion = String.Empty;
            string slCadena = String.Empty;
            string slBloque = String.Empty;
            string slCausaError = String.Empty;

            string cadena = string.Empty;
            int numero = 0;

            int ilVersion = 0;
            int ilPosicionInicial = 0;
            int ilCont = 0;
            int ilLongitudMsg = 0;
            int ilResultado = 0;
            try
            {
                if (mdlParametros.ES_DEBUG)
                {
                    EnviaLog("Iniciando FncFirmaS041B" + "\r\n" + "Vaciando Buffer del TcpServer");
                }

                fncPreparaEnvioB(); //Limpia el buffer del tcp server
                //antes de iniciar el mecanismo de firma

                EnviaLog("Buffer Vaciado");
                switch (ipTipoFirma)
                {
                    case enuTipoDlgSeguridad.tFirmaConModuloS041:  //***** Aqui se va a firmar para obtener los modulos 
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Firmandosé con modulos");
                        }
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Encriptando Password desde FncFirmaS041");
                        }

                        int tempRefParam = 0;
                        //slPassEncr = fncEncripPassS(StringsHelper.Format(spPassword, "00000000"), "", ref tempRefParam, 1);
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Inciando funcion para Generar Dialogo(fnFirmaS041B)");
                        }

                        slDialogo = fncGenDlgSegS(spNomina, slPassEncr, spToken, 0, enuTipoDlgSeguridad.tFirmaConModuloS041);
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Enviando el dialogo");
                        }

                        objSeguridad.SendRequest(StringsHelper.StrConv4(slDialogo, StringsHelper.VbStrConvEnum.vbFromUnicode, 0), (short)slDialogo.Length);

                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Dialogo Enviado" + "\r\n" + "Esperando Respuesta del TCPServer");
                        }

                        blContinue = true;
                        ilCont = 0;
                        slRespuesta = "";
                        ilLongitudMsg = 10000;

                        do
                        {
                            slBloque = "";
                            slBloque = StringsHelper.StrConv4(objSeguridad.ReceiveResponse(mdlParametros.igTimeComDrive), StringsHelper.VbStrConvEnum.vbUnicode, 0);
                            if (mdlParametros.ES_DEBUG)
                            {
                                EnviaLog("Bloque Recibido: " + "\r\n" + slBloque);
                            }
                            //AIS- NGONZALEZ SE CAMBIO 13 POR 12 YA QUE LA CADENA  DEVUELTA NO TIENE EL FIN DE LINEA ENTOCES EL LENGTH ES MENOR EN .NET
                            if (Strings.Mid(slBloque, 1, 1) == "H" && slBloque.Length != 12)
                            {
                                slRespuesta = "";
                                ilLongitudMsg = Convert.ToInt32(Conversion.Val(Strings.Mid(slBloque, 3, 4)));
                                ilCont = 0;
                            }
                            slRespuesta = slRespuesta + slBloque;
                            if (mdlParametros.ES_DEBUG)
                            {
                                EnviaLog("slRespuesta : " + "\r\n" + slRespuesta);
                            }
                            Information.Err().Clear();
                            ilCont++;
                        }
                        while (blContinue && ilLongitudMsg > slRespuesta.Length + 1);
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Respuesta del dialogo: " + "\r\n" + slRespuesta);
                        }

                        while ((slRespuesta.IndexOf("NO ESTA FIRMADA LA TERMINAL.") + 1) > 1)
                        {
                            do
                            {
                                slBloque = "";
                                slBloque = StringsHelper.StrConv4(objSeguridad.ReceiveResponse(mdlParametros.igTimeComDrive), StringsHelper.VbStrConvEnum.vbUnicode, 0);
                                if (mdlParametros.ES_DEBUG)
                                {
                                    EnviaLog("Recibiendo Bloque: " + "\r\n" + slBloque);
                                }

                                if (Strings.Mid(slBloque, 1, 1) == "H" && slBloque.Length != 12)
                                {
                                    slRespuesta = "";
                                    ilLongitudMsg = Convert.ToInt32(Conversion.Val(Strings.Mid(slBloque, 3, 4)));
                                    ilCont = 0;
                                }
                                slRespuesta = slRespuesta + slBloque;
                                if (mdlParametros.ES_DEBUG)
                                {
                                    EnviaLog("slRespuesta : " + "\r\n" + slRespuesta);
                                }

                                if (Information.Err().Number != 0)
                                {
                                    ilResultado = Information.Err().Number;
                                    slCausaError = Information.Err().Description;
                                    blContinue = false;
                                    if (mdlParametros.ES_DEBUG)
                                    {
                                        EnviaLog("slCausaError : " + "\r\n" + slCausaError);
                                    }

                                }
                                Information.Err().Clear();
                                ilCont++;
                            }
                            while (blContinue && ilLongitudMsg > slRespuesta.Length + 1);
                        };
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Respuesta: " + "\r\n" + slRespuesta);
                        }
                        numero = Strings.InStr(32, slRespuesta, "SEG;", CompareMethod.Binary);
                        if (Strings.InStr(32, slRespuesta, "SEG;", CompareMethod.Binary) > 0)
                        {
                            MessageBox.Show(Strings.Mid(slRespuesta, (slRespuesta.IndexOf("SEG;") + 1) + 4, 80).Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sgDlgSeguridad = "";
                            return false;
                        }
                        else if (!(Strings.InStr(32, slRespuesta, "SEG:", CompareMethod.Binary) > 0))
                        {
                            MessageBox.Show(Strings.Mid(slRespuesta, (slRespuesta.IndexOf("SEG;") + 1) + 4, 80).Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sgDlgSeguridad = "";
                            return false;
                        }

                        //Version 
                        ilPosicionInicial = Strings.InStr(32, slRespuesta, "SEG:", CompareMethod.Binary);
                        ilPosicionInicial += 84;
                        if (slRespuesta.Length + 1 < ilPosicionInicial + 4)
                        {
                            MessageBox.Show("Favor de reintentar su firma debido a una falla en la conexión.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sgDlgSeguridad = "";
                            return false;
                        }
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Se confirma la encripcion de la firma y se reintenta");
                        }

                        if (slRespuesta.IndexOf("CONFIRMANDO ENCRIPCION, REINTENTE FIRMA", StringComparison.CurrentCultureIgnoreCase) >= 0)
                        {

                            slVersion = Strings.Mid(slRespuesta, ilPosicionInicial, 4);
                            ilVersion = Int32.Parse(slVersion);
                        }
                        else
                        {
                            string tempRefParam2 = "Tarjeta Corporativa:FnFrimaS041B";
                            MdlCambioMasivo.MsgInfo("Respuesta del S041 Invalida: " + slRespuesta, ref tempRefParam2);

                            return false;
                        }

                        //Cadena 
                        ilPosicionInicial += 4;
                        if (slRespuesta.Length + 1 < ilPosicionInicial + 24)
                        {
                            if (mdlParametros.ES_DEBUG)
                            {
                                EnviaLog("Valida cadena invalida para reintentar la firma");
                            }

                            MessageBox.Show("Favor de reintentar su firma debido a una falla en la conexión.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sgDlgSeguridad = "";
                            return false;
                        }

                        slCadena = Strings.Mid(slRespuesta, ilPosicionInicial, 24);
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("slCadena :" + slCadena + "\r\n" +
                                     "Se inicia proceso de reencripcion de la firma");
                        }

                        //slPassEncr2 = fncEncripPassS(StringsHelper.Format(spPassword, "00000000"), slCadena, ref ilVersion, 2);
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Finaliza Encripcion 2 " + "\r\n" +
                                     "Generando Dialogo");
                        }

                        slDialogo2 = fncGenDlgSegS(spNomina, slPassEncr2, spToken, ilVersion, enuTipoDlgSeguridad.tFirmaConModuloS041); //se agrega el tercer parámetro para el uso de TOKEN
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Enviando Dialogo");
                        }


                        objSeguridad.SendRequest(StringsHelper.StrConv4(slDialogo2, StringsHelper.VbStrConvEnum.vbFromUnicode, 0), (short)slDialogo2.Length);
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Dialogo Enviado");
                        }

                        blContinue = true;
                        ilCont = 0;
                        slRespuesta = "";
                        ilLongitudMsg = 10000;
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Obteniendo respuesta del dialogo");
                        }

                        do
                        {
                            slBloque = "";
                            slBloque = StringsHelper.StrConv4(objSeguridad.ReceiveResponse(mdlParametros.igTimeComDrive), StringsHelper.VbStrConvEnum.vbUnicode, 0);
                            if (mdlParametros.ES_DEBUG)
                            {
                                EnviaLog("SlBloque: " + slBloque);
                            }

                            if (Strings.Mid(slBloque, 1, 1) == "H" && slBloque.Length != 12)
                            {
                                slRespuesta = "";
                                ilLongitudMsg = Convert.ToInt32(Conversion.Val(Strings.Mid(slBloque, 3, 4)));
                                ilCont = 0;
                            }

                            slRespuesta = slRespuesta + slBloque;
                            if (mdlParametros.ES_DEBUG)
                            {
                                EnviaLog("slRespuesta: " + slRespuesta);
                            }
                            Information.Err().Clear();
                            ilCont++;
                        }
                        while (blContinue && ilLongitudMsg > slRespuesta.Length + 1);

                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Repuesta Final del Dialogo:" + slRespuesta);
                        }

                        if (StringsHelper.IntValue(Strings.Mid(slRespuesta, 3, 4)) == 13)
                        {
                            slRespuesta = Strings.Mid(slRespuesta, 14);
                        }

                        if (slRespuesta.IndexOf("Expira su clave", StringComparison.CurrentCultureIgnoreCase) >= 0)
                        {
                            MessageBox.Show("Su clave secreta está a punto de expirar cambiela antes de continuar", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            result = false;
                            slRespuesta = "";
                        }
                        cadena = Strings.Mid(slRespuesta, 33, 4);
                        if (Strings.Mid(slRespuesta, 33, 4) == "SEG:")
                        {
                            CRSParametros.sgUserName = Strings.Mid(slRespuesta, 27, Strings.InStr(27, slRespuesta, ",", CompareMethod.Binary) - 27);
                            EnviaLog("sgUserName:" + CRSParametros.sgUserName);
                            sgDlgSeguridad = slRespuesta;
                            EnviaLog("sgDlgSeguridad :" + sgDlgSeguridad);
                            CRSParametros.sgUserID = spNomina;
                            EnviaLog("sgUserID :" + CRSParametros.sgUserID);
                            result = true;

                        }
                        else if (Strings.Mid(slRespuesta, 33, 4) == "SEG;")
                        {
                            MessageBox.Show(Strings.Mid(slRespuesta, 27, 80).Trim(), "Tajeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sgDlgSeguridad = "";
                            result = false;

                        }
                        EnviaLog("Se va a limpiar el buffer");


                        break;
                    case enuTipoDlgSeguridad.tFirmaSinModuloS041:  //Aqui se va a firmar sin obtener los modulos 
                        EnviaLog("Firmandose sin dialogos" + "\r\n" + "Encriptando Pwd");

                        int tempRefParam3 = 0;
                        //slPassEncr = fncEncripPassS(StringsHelper.Format(spPassword, "00000000"), "", ref tempRefParam3, 1);
                        EnviaLog("Encriptado" + "\r\n" + "Generando Dialogo");
                        slDialogo = fncGenDlgSegS(spNomina, slPassEncr, spToken, 0, enuTipoDlgSeguridad.tFirmaSinModuloS041); //se agrega el tercer parámetro para uso de TOKEN
                        EnviaLog("Dialogo Generado.... Enviando:" + "\r\n" + slDialogo);
                        objSeguridad.SendRequest(StringsHelper.StrConv4(slDialogo, StringsHelper.VbStrConvEnum.vbFromUnicode, 0), (short)slDialogo.Length);
                        EnviaLog("Enviado");
                        blContinue = true;
                        ilCont = 0;
                        slRespuesta = "";
                        ilLongitudMsg = 10000;
                        EnviaLog("Recibiendo Respuesta");
                        do
                        {


                            slBloque = "";
                            slBloque = StringsHelper.StrConv4(objSeguridad.ReceiveResponse(mdlParametros.igTimeComDrive), StringsHelper.VbStrConvEnum.vbUnicode, 0);
                            EnviaLog("slBloque: " + slBloque);


                            if (Strings.Mid(slBloque, 1, 1) == "H" && slBloque.Length != 12)
                            {
                                slRespuesta = "";
                                ilLongitudMsg = Convert.ToInt32(Conversion.Val(Strings.Mid(slBloque, 3, 4)));
                                ilCont = 0;
                            }
                            slRespuesta = slRespuesta + slBloque;
                            EnviaLog("slRespuesta: " + slRespuesta);
                            Information.Err().Clear();
                            ilCont++;
                        }
                        while (blContinue && ilLongitudMsg > slRespuesta.Length + 1);
                        EnviaLog("Respuesta Final del Dialogo: " + slRespuesta);

                        while ((slRespuesta.IndexOf("NO ESTA FIRMADA LA TERMINAL.") + 1) > 1)
                        {
                            do
                            {

                                slBloque = "";
                                slBloque = StringsHelper.StrConv4(objSeguridad.ReceiveResponse(mdlParametros.igTimeComDrive), StringsHelper.VbStrConvEnum.vbUnicode, 0);
                                EnviaLog("slBloque: " + slBloque);

                                if (Strings.Mid(slBloque, 1, 1) == "H" && slBloque.Length != 12)
                                {
                                    slRespuesta = "";
                                    ilLongitudMsg = Convert.ToInt32(Conversion.Val(Strings.Mid(slBloque, 3, 4)));
                                    ilCont = 0;
                                }
                                slRespuesta = slRespuesta + slBloque;
                                EnviaLog("slRespuesta: " + slRespuesta);
                                Information.Err().Clear();
                                ilCont++;
                            }
                            while (blContinue && ilLongitudMsg > slRespuesta.Length + 1);
                        };
                        EnviaLog("Respuesta Final del Dialogo" + slRespuesta);
                        if (Strings.InStr(32, slRespuesta, "SEG;", CompareMethod.Binary) > 0)
                        {
                            MessageBox.Show(Strings.Mid(slRespuesta, (slRespuesta.IndexOf("SEG;") + 1) + 4, 80).Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sgDlgSeguridad = "";
                            return false;
                        }
                        else if (!(Strings.InStr(32, slRespuesta, "SEG:", CompareMethod.Binary) > 0))
                        {
                            MessageBox.Show(Strings.Mid(slRespuesta, (slRespuesta.IndexOf("SEG;") + 1) + 4, 80).Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sgDlgSeguridad = "";

                            return false;
                        }

                        //Version 
                        ilPosicionInicial = Strings.InStr(28, slRespuesta, "SEG:", CompareMethod.Binary);
                        ilPosicionInicial += 84;
                        if (slRespuesta.Length + 1 < ilPosicionInicial + 4)
                        {
                            MessageBox.Show("Favor de reintentar su firma debido a una falla en la conexión.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sgDlgSeguridad = "";
                            return false;
                        }

                        if (slRespuesta.IndexOf("CONFIRMANDO ENCRIPCION, REINTENTE FIRMA", StringComparison.CurrentCultureIgnoreCase) >= 0)
                        {
                            EnviaLog("Reintentando Encripcion");
                            slVersion = Strings.Mid(slRespuesta, ilPosicionInicial, 4);
                            ilVersion = Int32.Parse(slVersion);
                            EnviaLog("version: " + ilVersion.ToString());

                        }
                        else
                        {
                            string tempRefParam4 = "Tarjeta Coporativa:FnFirmaS041B";
                            MdlCambioMasivo.MsgError("Mensaje Invalido: " + "\r\n" + slRespuesta, ref tempRefParam4);
                        }
                        //Cadena 
                        ilPosicionInicial += 4;
                        if (slRespuesta.Length + 1 < ilPosicionInicial + 24)
                        {
                            MessageBox.Show("Favor de reintentar su firma debido a una falla en la conexión.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sgDlgSeguridad = "";
                            return false;
                        }

                        slCadena = Strings.Mid(slRespuesta, ilPosicionInicial, 24);
                        EnviaLog("slCadena;" + slCadena);

                        //slPassEncr = fncEncripPassS(StringsHelper.Format(spPassword, "00000000"), slCadena, ref ilVersion, 2);
                        EnviaLog("slPassEncr ;" + slPassEncr);

                        slDialogo = fncGenDlgSegS(spNomina, slPassEncr, spToken, ilVersion, enuTipoDlgSeguridad.tFirmaSinModuloS041);  //se agrega el tercer parametro para el uso de TOKEN
                        EnviaLog("slDialogo ;" + slDialogo + "\r\n" + "Enviando Dialogo");

                        objSeguridad.SendRequest(StringsHelper.StrConv4(slDialogo, StringsHelper.VbStrConvEnum.vbFromUnicode, 0), (short)slDialogo.Length);
                        EnviaLog("Dialogo Enviado");
                        blContinue = true;
                        ilCont = 0;
                        slRespuesta = "";
                        ilLongitudMsg = 10000;
                        do
                        {
                            slBloque = "";
                            //try
                            //{
                            slBloque = StringsHelper.StrConv4(objSeguridad.ReceiveResponse(mdlParametros.igTimeComDrive), StringsHelper.VbStrConvEnum.vbUnicode, 0);
                            EnviaLog("SlBloque:" + slBloque);

                            if (Strings.Mid(slBloque, 1, 1) == "H" && slBloque.Length != 12)
                            {
                                slRespuesta = "";
                                ilLongitudMsg = Convert.ToInt32(Conversion.Val(Strings.Mid(slBloque, 3, 4)));
                                ilCont = 0;
                            }
                            slRespuesta = slRespuesta + slBloque;

                            //}
                            //catch (COMException e4)
                            //{
                            //    Information.Err().Number = e4.ErrorCode;
                            //    Information.Err().Description = e4.Message;
                            //    if (Information.Err().Number != 0)
                            //    {
                            //        ilResultado = Information.Err().Number;
                            //        slCausaError = Information.Err().Description;
                            //        blContinue = false;
                            //        EnviaLog("slcausaerror: " + slCausaError);
                            //    }
                            //}
                            Information.Err().Clear();
                            ilCont++;
                        }
                        while (blContinue && ilLongitudMsg > slRespuesta.Length + 1);
                        EnviaLog("Respueta Final del Dialogo:" + slRespuesta);

                        if (Strings.Mid(slRespuesta, 32, 4) == "SEG:")
                        {
                            result = true;

                        }
                        else if (Strings.Mid(slRespuesta, 33, 4) == "SEG:")
                        {
                            result = true;

                        }
                        else if (Strings.Mid(slRespuesta, 32, 4) == "SEG;")
                        {
                            MessageBox.Show(Strings.Mid(slRespuesta, 27, 80).Trim(), "Tajeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            result = false;

                        }
                        else if (Strings.Mid(slRespuesta, 33, 4) == "SEG;")
                        {
                            MessageBox.Show(Strings.Mid(slRespuesta, 40, 80).Trim(), "Tajeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            result = false;
                        }




                        break;
                    case enuTipoDlgSeguridad.tDesfirmaS041:  //Aqui se va a desfirmar 

                        EnviaLog("Desfirmandose ");


                        if (objSeguridad == null)
                        {
                            return result;
                        }

                        slDialogo = fncGenDlgSegS(spNomina, slPassEncr, spToken, 0, enuTipoDlgSeguridad.tDesfirmaS041); //se agrega el tercer parámetro para el uso de TOKEN
                        //If ES_DEBUG Then 
                        EnviaLog("Enviando Dialogo: " + slDialogo);
                        //End If 
                        objSeguridad.SendRequest(StringsHelper.StrConv4(slDialogo, StringsHelper.VbStrConvEnum.vbFromUnicode, 0), (short)slDialogo.Length);

                        blContinue = true;
                        ilCont = 0;
                        slRespuesta = "";
                        ilLongitudMsg = 10000;
                        do
                        {

                            slBloque = "";
                            //try
                            //{
                            slBloque = StringsHelper.StrConv4(objSeguridad.ReceiveResponse(mdlParametros.igTimeComDrive), StringsHelper.VbStrConvEnum.vbUnicode, 0);
                            EnviaLog(slBloque);
                            if (Strings.Mid(slBloque, 1, 1) == "H" && slBloque.Length != 12)
                            {
                                slRespuesta = "";
                                ilLongitudMsg = Convert.ToInt32(Conversion.Val(Strings.Mid(slBloque, 3, 4)));
                                ilCont = 0;
                            }
                            slRespuesta = slRespuesta + slBloque;
                            //}
                            //catch (COMException e5)
                            //{
                            //    Information.Err().Number = e5.ErrorCode;
                            //    Information.Err().Description = e5.Message;

                            //    if (Information.Err().Number != 0)
                            //    {
                            //        ilResultado = Information.Err().Number;
                            //        slCausaError = Information.Err().Description;
                            //        blContinue = false;
                            //    }
                            //}
                            Information.Err().Clear();
                            ilCont++;
                        }
                        while (blContinue && ilLongitudMsg > slRespuesta.Length + 1);

                        EnviaLog("Respuesta del Dialogo: " + slRespuesta);


                        if (Strings.InStr(28, slRespuesta, "SEG;", CompareMethod.Binary) > 0)
                        {
                            result = false;
                        }
                        else if (!(Strings.InStr(28, slRespuesta, "SEG:", CompareMethod.Binary) > 0))
                        {
                            result = false;
                        }
                        break;
                }
                EnviaLog("Limpiando el Buffer");
                fncPreparaEnvioB();
                EnviaLog("Buffer Limpiado" + "\r\n" + "Saliendo de la funcion FncFirmaS041B");
            }
            catch (COMException er)
            {
                //Resume
                MdlCambioMasivo.MsgError("Se provoco el siguiente error en la funcion fnFirmaS041B" + "\r\n" +
                                         "Número de Error: " + er.ErrorCode + "\r\n" +
                                         "Decripcion: " + er.Message +
                                         "Fuente del Error: " + er.Source);
                EnviaLog("Salida Erronea de la funcion");


            }
            catch (Exception excep)
            {

                //Resume
                MdlCambioMasivo.MsgError("Se provoco el siguiente error en la funcion fnFirmaS041B" + "\r\n" +
                                         "Número de Error: " + Information.Err().Number.ToString() + "\r\n" +
                                         "Decripcion: " + excep.Message +
                                         "Fuente del Error: " + excep.Source);
                EnviaLog("Salida Erronea de la funcion");
            }

            return result;
        }

        static public bool fncPreparaEnvioB()
        {

            bool result = false;
            int ilResultado = 0;
            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                int ilCont = 0;
                bool blContinue = true;


                while (blContinue)
                {
                    Information.Err().Clear();
                    try
                    {
                        objSeguridad.ReceiveResponse(500);
                    }
                    catch (COMException e)
                    {
                        Information.Err().Number = e.ErrorCode;

                        if (Information.Err().Number == -2147014836)
                        {
                            blContinue = false;
                        }
                        else if (Information.Err().Number == -2147014839 && ilCont == 0)
                        {
                            Information.Err().Clear();
                            objSeguridad.Connect();
                            if (Information.Err().Number != 0)
                            {
                                ilResultado = Information.Err().Number;
                                blContinue = false;
                            }
                            else
                            {
                                blContinue = true;
                            }
                        }
                        else if (Information.Err().Number != 0)
                        {
                            ilResultado = Information.Err().Number;
                            blContinue = false;
                        }
                    }

                    Information.Err().Clear();
                    ilCont++;
                };

                result = true;
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

            return result;
        }
        static public bool InicializarLog()
        {
            bool result = false;
            try
            {
                string lsFile = String.Empty;
                LogHandler = FileSystem.FreeFile();
                //lsFile = Interaction.Environ("temp");
                lsFile = CORVAR.pszgblPathCorpo;
                if (!lsFile.EndsWith("\\"))
                {
                    lsFile = lsFile + "\\";
                }
                lsFile = lsFile + "c430.log";
                FileSystem.FileOpen(LogHandler, lsFile, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
                return true;
            }
            catch
            {

                result = false;
                if (MdlCambioMasivo.fnGetError())
                {
                    //UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }
                else
                {
                    FileSystem.FileClose(LogHandler);
                }
            }

            return result;
        }
        static public bool EnviaLog(string strMensaje)
        {
            if (mdlParametros.ES_DEBUG)
            {
                FileSystem.PrintLine(LogHandler, strMensaje);
            }
            return false;
        }
        static public void CerrarLog()
        {
            FileSystem.FileClose(LogHandler);
        }

        //internal static bool Firmasprincipal()
        //{
        //    throw new System.NotImplementedException();
        //}

        //internal static bool Firmasprincipal(ref string tempRefParam2, string p1, string p2, enuTipoDlgSeguridad enuTipoDlgSeguridad)
        //{
        //    throw new System.NotImplementedException();
        //}



    }
}