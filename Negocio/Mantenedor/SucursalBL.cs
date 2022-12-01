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
    public class SucursalBL : ICrud<Sucursal>
    {
        ResponseExec resp = new ResponseExec();

        public ResponseExec Create(Sucursal o)
        {
            try
            {
                resp.error = !o.Data.execData("INSERT  INTO Sucursal (id, nombre, direccion, telefono, rut) VALUES('" + o.id + "','" + o.nombre +  "', '" + o.direccion + "', '" + o.telefono +"','" + o.rut + "')");
                resp.mensaje = "ok";
            }
            catch (Exception e)                                                                                                         
            {                                       
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;

        }

        public ResponseExec Delete(Sucursal o)
        {
            try
            {
                resp.error = !o.Data.execData("DELETE FROM Sucursal WHERE ID='" + o.id + "'");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public List<Sucursal> Get(Sucursal o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM Sucursal"));

        }

        public Sucursal GetById(Sucursal o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM Sucursal WHERE ID='" + o.id + "'")).FirstOrDefault();

        }

        public List<Sucursal> GetQuery(Sucursal o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM Sucursal WHERE NOMBRE='" + o.nombre + "'"));
        }

        public ResponseExec Update(Sucursal o)
        {
            try
            {
                resp.error = !o.Data.execData("UPDATE Sucursal SET nombre='" + o.nombre + "', direccion='" + o.direccion + "', telefono='" + o.telefono + "', rut='" + o.rut + "' WHERE ID='" + o.id + "'");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public List<Sucursal> convertToList(DataTable dt)
        {
            List<Sucursal> listado = new List<Sucursal>();

            foreach (DataRow item in dt.Rows)
            {
                Sucursal o = new Sucursal();
                o.id = int.Parse(item.ItemArray[0].ToString());
                o.nombre = item.ItemArray[1].ToString();
                o.direccion = item.ItemArray[2].ToString();
                o.telefono = item.ItemArray[3].ToString();
                o.rut = item.ItemArray[4].ToString();

                listado.Add(o);
            }

            return listado;
        }


    }
}
