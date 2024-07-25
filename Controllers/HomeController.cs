using Microsoft.AspNetCore.Mvc;
using DataLayer.Repositorio;
using DataLayer.Entidades;

namespace webAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmpleadoRepositorio _repository;
        public HomeController(IEmpleadoRepositorio repository)
        {
            this._repository = repository;
        }

        [HttpPost]
        [Route("setEmpleado")]
        public int SetEmpleado(Empleado objEmpleado)
        {
            return _repository.InsertarEmpleado(1, objEmpleado).Result;
        }

        [HttpGet]
        [Route("delEmpleado")]
        public int DelEmpleado(int Id)
        {
            return _repository.EliminarEmpleado(2, Id).Result;
        }

        [HttpPost]
        [Route("updEmpleado")]
        public int UpdEmpleado(Empleado obj)
        {
            return _repository.ActualizarEmpleado(3, obj).Result;
        }

        [HttpGet]
        [Route("getEmpleados")]
        public Task<List<Empleado>> GetEmpleados(int Id = 0)
        {
            return _repository.ObtenerEmpleados(4, Id);
        }
    }
}
