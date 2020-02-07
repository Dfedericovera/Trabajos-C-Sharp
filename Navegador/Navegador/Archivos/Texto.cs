using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public string archivo;
        public Texto(string archivo)
        {
            this.archivo =AppDomain.CurrentDomain.BaseDirectory + archivo;
        }

        public bool Guardar(string datos)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(archivo, true))
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
        //public bool leer(out List<string> datos)
        public bool Leer(out List<string> datos)
        {
            datos = new List<string>();
            System.IO.StreamReader file = new System.IO.StreamReader(archivo);
            try
            {
                do
                {
                    datos.Add(file.ReadLine());
                }while (!file.EndOfStream);
                file.Close();
                return true;
            }
            catch (Exception)
            {                
                return false;
            }
        }
    }
}
