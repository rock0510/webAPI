using DataLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositorio
{
    public interface IEmpleadoRepositorio
    {
        Task<int> InsertarEmpleado(int Opcion, Empleado obj);
        Task<int> EliminarEmpleado(int Opcion, int id);
        Task<int> ActualizarEmpleado(int Opcion, Empleado obj);
        Task<List<Empleado>> ObtenerEmpleados(int Opcion, int Id = 0);
    }
}
