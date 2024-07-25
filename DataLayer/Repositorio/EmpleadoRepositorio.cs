using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataLayer.Connection;
using DataLayer.Entidades;
using Microsoft.Extensions.Options;

namespace DataLayer.Repositorio
{
    public class EmpleadoRepositorio : IEmpleadoRepositorio
    {
        private readonly Conexion _conn;

        public EmpleadoRepositorio(IOptions<Conexion> conexion)
        {
            _conn = conexion.Value;
        }

        public async Task<int> InsertarEmpleado(int Opcion, Empleado obj)
        {
            using (SqlConnection sql = new SqlConnection(_conn.connSQL))
            {
                using (SqlCommand cmd = new SqlCommand("spAdminEmpleados", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Opcion", Value = Opcion });

                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Fotografia", Value = obj.Fotografia });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Nombre", Value = obj.Nombre });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Apellido", Value = obj.Apellido });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Puestoid", Value = obj.PuestoId });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@FechaNacimiento", Value = obj.FechaNacimiento });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Direccion", Value = obj.Direccion });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Telefono", Value = obj.Telefono });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@CorreoElectronico", Value = obj.CorreoElectronico });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@EstadoId", Value = obj.EstadoId });

                    await sql.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> EliminarEmpleado(int Opcion, int id)
        {
            using (SqlConnection sql = new SqlConnection(_conn.connSQL))
            {
                using (SqlCommand cmd = new SqlCommand("spAdminEmpleados", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Opcion", Value = Opcion });

                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = id });

                    await sql.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task<int> ActualizarEmpleado(int Opcion, Empleado obj)
        {
            using (SqlConnection sql = new SqlConnection(_conn.connSQL))
            {
                using (SqlCommand cmd = new SqlCommand("spAdminEmpleados", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Opcion", Value = Opcion });

                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = obj.Id });

                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Fotografia", Value = obj.Fotografia });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Nombre", Value = obj.Nombre });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Apellido", Value = obj.Apellido });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Puestoid", Value = obj.PuestoId });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@FechaNacimiento", Value = obj.FechaNacimiento });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Direccion", Value = obj.Direccion });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Telefono", Value = obj.Telefono });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@CorreoElectronico", Value = obj.CorreoElectronico });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@EstadoId", Value = obj.EstadoId });

                    await sql.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Empleado>> ObtenerEmpleados(int Opcion, int Id = 0)
        {
            using (SqlConnection sql = new SqlConnection(_conn.connSQL))
            {
                using (SqlCommand cmd = new SqlCommand("spAdminEmpleados", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Opcion", Value = Opcion });

                    if (Id > 0)
                    {
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = Id });
                    }

                    List<Empleado> lstEmpleados = new List<Empleado>();
                    await sql.OpenAsync();

                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {
                            lstEmpleados.Add(MappingEmpleado(dr));
                        }
                    }

                    return lstEmpleados;
                }
            }
        }
        private Empleado MappingEmpleado(SqlDataReader reader)
        {
            return new Empleado()
            {
                Id = (int)reader["Id"],
                Fotografia = reader["Fotografia"].ToString(),
                Nombre = reader["Nombre"].ToString(),
                Apellido = reader["Apellido"].ToString(),
                PuestoId = (int)reader["PuestoId"],
                FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                Direccion = reader["Direccion"].ToString(),
                Telefono = reader["Telefono"].ToString(),
                CorreoElectronico = reader["CorreoElectronico"].ToString(),
                EstadoId = (int)reader["EstadoId"]
            };
        }

    }
}
