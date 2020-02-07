 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno: Universitario
    {
        private ClasesInstanciables.Universidad.EClases _clasesQueToma;
        private EEstadoCuenta _estadoDeCuenta;

        //public enum Eclases { Programacion, Laboratorio, Legislacion, SPD }
        public enum EEstadoCuenta { AlDia, Deudor, Becado }

        public Alumno() { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,Universidad.EClases clasesQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this._clasesQueToma = clasesQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoDeCuenta)
            :this(id,nombre,apellido,dni,nacionalidad,clasesQueToma)
        {
            this._estadoDeCuenta = estadoDeCuenta;
        }

        protected override string MostrarDatos()
        {
            return string.Format(base.MostrarDatos()+"\nESTADO DE CUENTA: {0}",this._estadoDeCuenta+ParticiparEnClase());
        }
        
        protected override string ParticiparEnClase()
        {
            return string.Format("\nTOMA CLASES DE: {0}", this._clasesQueToma);
        }        

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        public static bool operator==(Alumno a, Universidad.EClases clase)
        {
            bool retValue = false;
            if(a._clasesQueToma==clase && a._estadoDeCuenta != EEstadoCuenta.Deudor)
            {
                retValue = true;
            }
            return retValue;
        }
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (!(a == clase));
        }
    }
}
