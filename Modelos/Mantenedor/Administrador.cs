using DataCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Mantenedor
{
    public class Administrador : IDataEntity
    {
        public string rut { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public data Data { get; set; }
        public List<Parametros> parametros { get; set; }

        public Administrador()
        {
            Data = new data();
            parametros = new List<Parametros>();
        }
    }
}
