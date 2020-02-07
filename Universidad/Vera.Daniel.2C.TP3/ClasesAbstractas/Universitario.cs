using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace EntidadesAbstractas
{    
    abstract public class Universitario:Persona
    {
        private int legajo;

        public Universitario() { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        protected virtual string MostrarDatos()
        {
            return string.Format(base.ToString() + "\nLEGAJO NÚMERO: {0}\n", legajo);
        }

        protected abstract string ParticiparEnClase();

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retValue=false;
            if(pg1 is Universitario && pg2 is Universitario)
            {
                if(pg1.legajo==pg2.legajo || pg1.DNI==pg2.DNI)
                {
                    retValue=true;
                }
            }
            return retValue;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1==pg2);
        }

    }
}
