using Hospital.Entidades;
using Microsoft.Data.SqlClient;
using SinTransaction.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Servicios
{
    internal class ManejoDepartamento
    {
        public void GuardarPaciente(Departamento depa)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    string query = "insert into Departamento" +
                        "(id_departamento,nombre,descripcion) " +
                        "values" +
                        "(@Guid,@Nombre,@Descripcion)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@Guid", depa.IdDepartamento);
                        cmd.Parameters.AddWithValue("@Nombre", depa.Nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", depa.Descripcion);

                        con.Open();
                        var result = cmd.ExecuteNonQuery();
                        bool doesWork = int.TryParse(result.ToString(), out int resultado);
                        if (!doesWork)
                        {
                            throw new Exception("No funcionó");
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ActualizarDepa(Guid id, string nombre, string descripcion)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    string query = "UPDATE Pacientes SET nombre = @Nombre, descripcion = @Descripcion WHERE id_departamento = @Id";
                    using (SqlCommand com = new SqlCommand(query, con))
                    {
                        com.Parameters.AddWithValue("@Id", id);
                        com.Parameters.AddWithValue("@Nombre", nombre);
                        com.Parameters.AddWithValue("@Descripcion", descripcion);
                        con.Open();
                        var result = com.ExecuteNonQuery();
                        if (result == 0)
                        {
                            throw new Exception("No filas afectadas.");
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Eliminar(Guid id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    string query = "Delete From Departamento WHERE id_departamento = @Id";
                    using (SqlCommand com = new SqlCommand(query, con))
                    {
                        com.Parameters.AddWithValue("@Id", id);
                        con.Open();
                        var result = com.ExecuteNonQuery();
                        if (result == 0)
                        {
                            throw new Exception("No filas afectadas.");
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Departamento> ObtenerDepas()
        {
            List<Departamento> depas = new List<Departamento>();
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    string query = "SELECT * FROM Departamento";
                    using (SqlCommand com = new SqlCommand(query, con))
                    {
                        con.Open();
                        using (SqlDataReader read = com.ExecuteReader())
                        {
                            while (read.Read())
                            {
                                Departamento depa = new Departamento
                                {
                                    IdDepartamento = (Guid)read["id_departamento"],
                                    Nombre = read["nombre"].ToString(),
                                    Descripcion = read["descripcion"].ToString()
                                };
                                depas.Add(depa);

                            }
                        }
                        return depas;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        public List<Departamento> ObtenerDepa(Guid id)
        {
            List<Departamento> dep = new List<Departamento>();
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuracion.ConnectionString))
                {
                    string query = "SELECT * FROM Departamento WHERE id_departamento = @Id";
                    using (SqlCommand com = new SqlCommand(query, conn))
                    {
                        com.Parameters.AddWithValue("@Id", id);
                        conn.Open();

                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Departamento depa = new Departamento
                                {
                                    IdDepartamento = (Guid)reader["id_paciente"],
                                    Nombre = reader["nombre"].ToString(),
                                    Descripcion = reader["descripcion"].ToString(),
                                };

                                dep.Add(depa);
                            }
                        }
                        return dep;
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
    }
}
