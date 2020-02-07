using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;
using System.Xml.Serialization;

namespace EntidadesAbstractas
{
    [XmlInclude(typeof(Universitario))]
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;


        public enum ENacionalidad { Argentino, Extranjero }

        public Persona() { }
        public Persona(string nombre, string apellido,ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.dni = ValidarDni(nacionalidad,dni);
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad): this(nombre,apellido,nacionalidad)
        {
            this.dni = ValidarDni(nacionalidad, dni);
        }
        
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {               
                this.dni = ValidarDni(this.nacionalidad,value);
            }
        }
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        public override string ToString()
        {
            return string.Format("NOMBRE COMPLETO: {0}, {1}\nNacionalidad: {2}\n",apellido ,nombre , nacionalidad);
        }

        protected int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int dniValidado = 0;

            if ((nacionalidad == ENacionalidad.Argentino) && (dato > 0) && (dato <= 89999999))
            {
                dniValidado = dato;
            }
            else if ((nacionalidad == ENacionalidad.Extranjero) && (dato > 89999999) && (dato < 99999999))
            {
                dniValidado = dato;
            }
            
            else if (dato < 1 || dato > 99999999)
            {
                throw new DniInvalidoException("DNI invalido");
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
            
            if (dniValidado == 0)
            {
                throw new DniInvalidoException();
            }
            return dniValidado;
        }

        protected int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int valor;
            try
            {                
                valor = Int32.Parse(dato);
            }
            catch (Exception e)
            {
                throw new DniInvalidoException(dato.ToString(), e);
            }
            
            return this.ValidarDni(nacionalidad, valor);
        }

        protected string ValidarNombreApellido(string dato)
        {
            Regex regex= new Regex("^[A-Za-z]+$");
            if( regex.IsMatch(dato))
            {
                return dato;
            }
            return "";
            //seguramente lanzar exepcion
        }

    }
}
