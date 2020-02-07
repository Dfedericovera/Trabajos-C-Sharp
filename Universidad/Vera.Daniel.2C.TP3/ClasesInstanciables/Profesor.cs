using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor:Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;


        public Profesor():base()
        {
        }

        static Profesor()
        {
            _random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();            
        }        

        protected override string ParticiparEnClase()
        {
            return string.Format("\nCLASES DEL DÍA:\n{0}\n{1}",_clasesDelDia.ElementAt(0),_clasesDelDia.ElementAt(1) );            
        }

        private void _randomClases()
        {
            int i = 0;
            while (i < 2)
            {
                this._clasesDelDia.Enqueue((Universidad.EClases)_random.Next(0, 4));
                i++;
            }            
        }

        protected override string MostrarDatos()
        {
            return string.Format(base.MostrarDatos() + ParticiparEnClase());
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retValue = false;
            foreach (Universidad.EClases aux in i._clasesDelDia)
            {
                if(aux==clase)
                {
                    retValue = true;
                }
            }
            return retValue;
        }
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
