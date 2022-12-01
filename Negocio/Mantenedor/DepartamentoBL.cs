
using Modelos;
using Modelos.Mantenedor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Mantenedor
{
    public class DepartamentoBL : ICrud<Departamento>
    {
        ResponseExec resp = new ResponseExec();

        public ResponseExec Create(Departamento o)
        {
            try
            {
                resp.error = !o.Data.execData("INSERT  INTO Departamento (id, nombre, id_sucursal) VALUES('" + o.id + "','" + o.nombre + "','" + o.id_sucursal + "')");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;

        }

        public ResponseExec Delete(Departamento o)
        {
            try
            {
                resp.error = !o.Data.execData("DELETE FROM Departamento WHERE ID='" + o.id + "'");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public List<Departamento> Get(Departamento o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM Departamento"));

        }

        public Departamento GetById(Departamento o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM Departamento WHERE ID='" + o.id + "'")).FirstOrDefault();

        }

        public List<Departamento> GetQuery(Departamento o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM Departamento WHERE NOMBRE='" + o.nombre + "'"));
        }

        public ResponseExec Update(Departamento o)
        {
            try
            {
                resp.error = !o.Data.execData("UPDATE Departamento SET nombre='" + o.nombre + "', id_sucursal='" + o.id_sucursal + "' WHERE ID='" + o.id + "'");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public List<Departamento> convertToList(DataTable dt)
        {
            List<Departamento> listado = new List<Departamento>();

            foreach (DataRow item in dt.Rows)
            {
                Departamento o = new Departamento();
                o.id = int.Parse(item.ItemArray[0].ToString());
                o.nombre = item.ItemArray[1].ToString();
                o.id_sucursal = int.Parse(item.ItemArray[2].ToString());

                listado.Add(o);
            }

            return listado;
        }


    }
}