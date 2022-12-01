using DataCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Mantenedor
{
    public class Departamento : IDataEntity
    {
        public int  id { get; set; }
        public string nombre { get; set; }
        public int id_sucursal{ get; set; }
        public data Data { get; set; }
        public List<Parametros> parametros { get; set; }

        public Departamento()
        {
            Data = new data();
            parametros = new List<Parametros>();
        }
    }
}