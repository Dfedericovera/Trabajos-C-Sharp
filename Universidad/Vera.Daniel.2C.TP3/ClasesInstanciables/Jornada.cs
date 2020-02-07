using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor instructor;

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this._clase = clase;
            this.instructor = instructor;
        }

        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumnos;
            }
            set
            {
                this._alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this._clase;
            }
            set
            {
                this._clase = value;
            }
        }
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        public static string Leer()
        {
            string retValue="";
            Texto texto = new Texto();
            if(texto.Leer(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", out retValue))
            {
                return retValue;
            }
            return retValue;            
        }
        public static bool Guardar(Jornada jornada)
        {
            bool retValue = false;
            string rutaArchivoTexto = (AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt");
            Texto texto = new Texto();
            if (texto.Guardar(rutaArchivoTexto, jornada.ToString()))
                retValue = true;
            return retValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("JORNADA:\nCLASE DE: {0} por {1}\n\n", this._clase, instructor.ToString());
            sb.AppendLine("AUMNOS:");
            foreach(Alumno aux in this.Alumnos)
            {
                sb.AppendLine(aux.ToString());
            }
            sb.AppendLine("<--------------------------------------------------->");
            return sb.ToString();
        }
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retValue = false;
            foreach (Alumno aux in j._alumnos)
            {
                if (aux.DNI == a.DNI)
                {
                    retValue = true;
                }
            }
            return retValue;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j._alumnos.Add(a);
            }
            return j;
        }

    }
}
