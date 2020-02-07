using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException:Exception
    {
        private string mensajeBase;
        public DniInvalidoException()
            :base()
        { }
        public DniInvalidoException(Exception e):base()
        { }
        public DniInvalidoException(string msj)
            :base(msj)
        { }
        public DniInvalidoException(string message,Exception e)
            :base(message,e)
        { }
    }
}
