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
    public class AdministradorBL : ICrud<Administrador>
    {
        ResponseExec resp = new ResponseExec();

        public ResponseExec Create(Administrador o)
        {
            try
            {
                resp.error = !o.Data.execData("INSERT  INTO ADMINISTRADOR(rut, nombre, apellido, email) VALUES('" + o.rut + "','" + o.nombre + "','" + o.apellido + "','" + o.email + "')");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;

        }

        public ResponseExec Delete(Administrador o)
        {
            try
            {
                resp.error = !o.Data.execData("DELETE FROM ADMINISTRADOR WHERE RUT='" + o.rut + "'");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public List<Administrador> Get(Administrador o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM ADMINISTRADOR"));

        }

        public Administrador GetById(Administrador o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM ADMINISTRADOR WHERE RUT='" + o.rut + "'")).FirstOrDefault();

        }

        public List<Administrador> GetQuery(Administrador o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM ADMINISTRADOR WHERE NOMBRE='" + o.nombre + "'"));
        }

        public ResponseExec Update(Administrador o)
        {
            try
            {
                resp.error = !o.Data.execData("UPDATE ADMINISTRADOR SET nombre='" + o.nombre + "', apellido='" + o.apellido + "', email='" + o.email + "' WHERE RUT='" + o.rut + "'");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public List<Administrador> convertToList(DataTable dt)
        {
            List<Administrador> listado = new List<Administrador>();

            foreach (DataRow item in dt.Rows)
            {
                Administrador o = new Administrador();
                o.rut = item.ItemArray[0].ToString();
                o.nombre = item.ItemArray[1].ToString();
                o.apellido = item.ItemArray[2].ToString();
                o.email = item.ItemArray[3].ToString();
                listado.Add(o);
            }

            return listado;
        }


    }
}
