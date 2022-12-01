using API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.Mantenedor;
using Negocio.Mantenedor;

namespace API.Controller
{

    [ApiController]
    public class adminstradorController : ControllerBase
    {
        Administrador admin = new Administrador();
        AdministradorBL adminBL = new AdministradorBL();
        ErrorResponse error;
        [HttpPost]
        [Route("api/v1/administradores/nuevo")]
        public ActionResult Create(AdministradorDTO o)
        {
            try
            {
                admin.rut = o.rut;
                admin.nombre = o.nombre;
                admin.apellido = o.apellido;
                admin.email = o.email;
                return Ok(adminBL.Create(admin));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpGet]
        [Route("api/v1/administradores/listar")]
        public ActionResult Listar()
        {
            try
            {
                return Ok(convertList(adminBL.Get(admin)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpGet]
        [Route("api/v1/administradores/buscarrut")]
        public ActionResult Buscarrut(string rut)
        {
            try
            {
                admin.rut = rut;
                return Ok(convert(adminBL.GetById(admin)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpGet]
        [Route("api/v1/administradores/buscarnombre")]
        public ActionResult BuscarNombre(string nombre)
        {
            try
            {
                admin.nombre = nombre;
                return Ok(convertList(adminBL.GetQuery(admin)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpDelete]
        [Route("api/v1/administradores/eliminar")]
        public ActionResult Eliminar(AdministradorDTO o)
        {
            try
            {
                admin.rut = o.rut;
                return Ok(adminBL.Delete(admin));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpPut]
        [Route("api/v1/administradores/actualizar")]
        public ActionResult Actualizar(AdministradorDTO o)
        {
            try
            {
                admin.rut = o.rut;
                admin.nombre = o.nombre;
                admin.apellido = o.apellido;
                admin.email = o.email;
                return Ok(adminBL.Update(admin));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        private List<AdministradorDTO> convertList(List<Administrador> lista)
        {
            List<AdministradorDTO> list = new List<AdministradorDTO>();
            foreach (var item in lista)
            {
                AdministradorDTO el = new AdministradorDTO(item.rut, item.nombre, item.apellido, item.email);
                list.Add(el);

            }
            return list;

        }
        private AdministradorDTO convert(Administrador item)
        {
            AdministradorDTO obj = new AdministradorDTO(item.rut, item.nombre, item.apellido, item.email);
            return obj;

        }
    }
}
