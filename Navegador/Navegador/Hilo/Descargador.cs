using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        public string html;
        private Uri direccion;

        public delegate void ProgresoDescargaCallback(int progreso);
        public event ProgresoDescargaCallback Progresodescarga;
        public delegate void FinDescargaCallback(string html);
        public event FinDescargaCallback FinDescarga;
        public Descargador(string direccion)
        {
            if (direccion.ToLower().StartsWith("http://"))
            {
                this.html = direccion;
            }
            else
            {
                this.html = "http://" + direccion;
            }
            this.direccion = new Uri(html);
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged ;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted ;

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Progresodescarga(e.ProgressPercentage);
        }
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this.FinDescarga(e.Result);
            }
            catch(Exception exc)
            {
                this.FinDescarga(exc.InnerException.Message);
            }
            //e.Result
        }
    }
}
