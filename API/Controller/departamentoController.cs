using API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.Mantenedor;
using Negocio.Mantenedor;


namespace API.Controller
{

    [ApiController]
    public class departamentoController : ControllerBase
    {
        Departamento depto = new Departamento();
        DepartamentoBL deptoBL = new DepartamentoBL();
        ErrorResponse error;
        [HttpPost]
        [Route("api/v1/departamentos/nuevo")]
        public ActionResult Create(DepartamentoDTO o)
        {
            try
            {
                depto.id = o.id;
                depto.nombre = o.nombre;
                depto.id_sucursal = o.id_sucursal;
            
                return Ok(deptoBL.Create(depto));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpGet]
        [Route("api/v1/departamentos/listar")]
        public ActionResult Listar()
        {
            try
            {
                return Ok(convertList(deptoBL.Get(depto)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpGet]
        [Route("api/v1/departamentos/buscar_id")]
        public ActionResult BuscarId(int id)
        {
            try
            {
               depto.id = id;
                return Ok(convert(deptoBL.GetById(depto)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpGet]
        [Route("api/v1/departamentos/buscar_nombre")]
        public ActionResult BuscarNombre(string nombre)
        {
            try
            {
                depto.nombre = nombre;
                return Ok(convertList(deptoBL.GetQuery(depto)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpDelete]
        [Route("api/v1/departamentos/eliminar")]
        public ActionResult Eliminar(DepartamentoDTO o)
        {
            try
            {
                depto.id = o.id;
                return Ok(deptoBL.Delete(depto));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpPut]
        [Route("api/v1/departamentos/actualizar")]
        public ActionResult Actualizar(DepartamentoDTO o)
        {
            try
            {
                depto.id = o.id;
                depto.nombre = o.nombre;
                depto.id_sucursal = o.id_sucursal;
               
                return Ok(deptoBL.Update(depto));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        private List<DepartamentoDTO> convertList(List<Departamento> lista)
        {
            List<DepartamentoDTO> list = new List<DepartamentoDTO>();
            foreach (var item in lista)
            {
                DepartamentoDTO el = new DepartamentoDTO(item.id, item.nombre, item.id_sucursal);
                list.Add(el);

            }
            return list;

        }
        private DepartamentoDTO convert(Departamento item)
        {
            DepartamentoDTO obj = new DepartamentoDTO(item.id, item.nombre, item.id_sucursal);
            return obj;

        }
    }
}
