using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    [Serializable]
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();
        }

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        public List<Jornada>Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        public List<Profesor>Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }
                    
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }

        public static bool Guardar (Universidad gim)
        {
            bool retValue = false;

            Xml<Universidad> archivosXml = new Xml<Universidad>();

            string rutaArchivoXml = (AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml");

            try
            {
                if (archivosXml.Guardar(rutaArchivoXml, gim))
                {
                    retValue = true;
                }
            }
            catch(ArchivosException arch)            
            {
                throw arch;
            }

            return retValue;
        }
        public static Universidad Leer()
        {
            Universidad universidad;
            string rutaArchivoXml = (AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml");
            Xml<Universidad> archivosXml = new Xml<Universidad>();
            archivosXml.Leer(rutaArchivoXml, out universidad);
            return universidad;
        }

        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();
           foreach(Jornada j in gim.jornada)
            {
                sb.AppendLine(j.ToString());
            }
           
            return sb.ToString();
        }
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        public static bool operator ==(Universidad u, Alumno a)
        {
            bool retValue = false;
            foreach( Alumno aux in u.alumnos)
            {
                if(aux==a)
                {
                    retValue = true;
                }
            }
            return retValue;
        }
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }
        public static Profesor operator==(Universidad u, EClases clase)
        {
            foreach (Profesor aux in u.profesores)
            {
                if (aux==clase)
                {
                    return aux;
                }
            }
            throw new SinProfesorException("No hay profesor para la clase");             
        }
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            {
                foreach (Profesor item in u.profesores)
                {
                    if (item != clase)
                    {
                        return item;
                    }
                }
                throw new SinProfesorException("No hay profesor para la clase");
            }
        }
        public static bool operator==(Universidad u, Profesor p)
        {
            bool retValue = false;
            foreach (Profesor aux in u.profesores)
            {
                if (aux == p)
                {
                    retValue = true;
                }
            }
            return retValue;
        }
        public static bool operator !=(Universidad u, Profesor p)
        {
            return !(u == p);
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u!=a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException("Alumno repetido");
            }
            return u;
        }
        public static Universidad operator +(Universidad u, Profesor p)
        {
            if(u != p)
            {
                u.profesores.Add(p);
            }
            return u;
        }
        public static Universidad operator +(Universidad u, EClases clase)
        {            
            Profesor auxInstructor = (u == clase);
                         
            Jornada nuevaJornada = new Jornada(clase, auxInstructor);
                       
            foreach (Alumno item in u.alumnos)
            {
                if (item == clase)
                {
                    
                    nuevaJornada += item;
                }
            }
            
            u.jornada.Add(nuevaJornada);

            return u;
        }


    }
}
