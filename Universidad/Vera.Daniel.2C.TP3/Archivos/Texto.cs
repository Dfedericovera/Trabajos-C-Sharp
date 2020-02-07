using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto: IArchivos<String>
    {

        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(archivo))
                {
                    datos = file.ReadToEnd();
                }

                return true;
            }
            catch (Exception e)
            {
                datos = "";
                throw new ArchivosException("Error al leer archivo",e.InnerException);
                return false;
            }
        }

        public bool Guardar(string archivo, String datos)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(archivo,true))
                {
                    file.WriteLine(datos);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
