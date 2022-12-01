using DataCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Mantenedor
{
    public class Sucursal : IDataEntity
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public string direccion { get; set; }

        public string telefono { get; set; }
        public string rut { get; set; }
        public data Data { get; set; }
        public List<Parametros> parametros { get; set; }

        public Sucursal ()
        {
            Data = new data();
            parametros = new List<Parametros>();
        }
    }
}