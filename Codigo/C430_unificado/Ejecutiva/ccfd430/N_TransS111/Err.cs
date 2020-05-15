using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

namespace N_TransS111
{
    public class Err
    {
        /// <summary>
        /// Loads the values stored in the exception into the class Microsoft.VisualBasic.Information.Err
        /// </summary>
        /// <param name="e">The current exception</param>
        public static void LoadError(Exception e)
        {
            Information.Err().Clear();

            if (e != null)
            {
                System.Runtime.InteropServices.COMException comEx = e as System.Runtime.InteropServices.COMException;
                if (comEx != null)
                {
                    Information.Err().Number = (short)comEx.ErrorCode;
                    Information.Err().Description = comEx.Message;
                    //Information.Err().Source = comEx.Source;
                    //Information.Err().HelpFile = comEx.HelpLink;
                }
                else
                {
                    try
                    {
                        // BanamexSpecific
                        if (e.Message == "-2147014836")
                            Information.Err().Description = "Se produjo un error durante el intento de conexión ya que la parte conectada no respondió adecuadamente tras un período de tiempo, o bien se produjo un error en la conexión establecida ya que el host conectado no ha podido responder.";
                        else if (e.Message == "-2147024793")
                            Information.Err().Description = "COMDRV32 Input request block has an invalid lenght";
                        Information.Err().Number = Int32.Parse(e.Message);
                    }
                    catch
                    {

                        //For some known types of exceptions there is a number that used to be used in VB6
                        if (e is IndexOutOfRangeException)
                            Information.Err().Number = 9;
                        else
                            Information.Err().Number = -1;

                        Information.Err().Description = e.Message;
                        //Information.Err().Source = e.Source;
                    }
                }
            }
        }
    }
}
