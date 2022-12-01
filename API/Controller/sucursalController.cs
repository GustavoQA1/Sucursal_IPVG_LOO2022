using API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.Mantenedor;
using Negocio.Mantenedor;

namespace API.Controller
{

    [ApiController]
    public class SucursalController : ControllerBase
    {
        Sucursal suc = new Sucursal();
        SucursalBL sucBL = new SucursalBL();
        ErrorResponse error;
        [HttpPost]
        [Route("api/v1/sucursales/nuevo")]
        public ActionResult Create(SucursalDTO o)
        {
            try
            {
                suc.id = o.id;
                suc.nombre = o.nombre;
                suc.direccion = o.direccion;
                suc.telefono = o.telefono;
                suc.rut = o.rut;

                return Ok(sucBL.Create(suc));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpGet]
        [Route("api/v1/sucursales/listar")]
        public ActionResult Listar()
        {
            try
            {
                return Ok(convertList(sucBL.Get(suc)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpGet]
        [Route("api/v1/sucursales/buscar_id")]
        public ActionResult BuscarId(int id)
        {
            try
            {
                suc.id = id;
                return Ok(convert(sucBL.GetById(suc)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpGet]
        [Route("api/v1/sucursales/buscar_nombre")]
        public ActionResult BuscarNombre(string nombre)
        {
            try
            {
                suc.nombre = nombre;
                return Ok(convertList(sucBL.GetQuery(suc)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpDelete]
        [Route("api/v1/sucursales/eliminar")]
        public ActionResult Eliminar(SucursalDTO o)
        {
            try
            {
                suc.id = o.id;
                return Ok(sucBL.Delete(suc));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpPut]
        [Route("api/v1/sucursales/actualizar")]
        public ActionResult Actualizar(SucursalDTO o)
        {
            try
            {
                suc.id = o.id;
                suc.nombre = o.nombre;
                suc.direccion =o.direccion;
                suc.telefono = o.telefono;
                suc.rut= o.rut;

                return Ok(sucBL.Update(suc));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        private List<SucursalDTO> convertList(List<Sucursal> lista)
        {
            List<SucursalDTO> list = new List<SucursalDTO>();
            foreach (var item in lista)
            {
                SucursalDTO el = new SucursalDTO(item.id, item.nombre, item.direccion, item.telefono, item.rut);
                list.Add(el);

            }
            return list;

        }
        private SucursalDTO convert(Sucursal item)
        {
            SucursalDTO obj = new SucursalDTO(item.id, item.nombre, item.direccion, item.telefono, item.rut);
            return obj;

        }
    }
}
