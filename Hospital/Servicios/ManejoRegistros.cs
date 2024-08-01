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
    internal class ManejoRegistros
    {
        public void GuardarPaciente(Paciente paciente)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    string query = "insert into Pacientes" +
                        "(id_paciente,nombre,fecha_nacimiento) " +
                        "values" +
                        "(@Guid,@Nombre,@FechaNacimiento)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@Guid", paciente.IdPaciente);
                        cmd.Parameters.AddWithValue("@Nombre", paciente.NombrePaciente);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", paciente.FechaNacimiento);

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

        public void ActualizarPaciente(Guid id, string nombre, DateOnly fechaNacimiento)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    string query = "UPDATE Pacientes SET nombre = @NombrePaciente, fecha_nacimiento = @FechaNacimiento WHERE id_paciente = @Id";
                    using (SqlCommand com = new SqlCommand(query, con))
                    {
                        com.Parameters.AddWithValue("@Id", id);
                        com.Parameters.AddWithValue("@NombrePaciente", nombre);
                        com.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
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
                    string query = "Delete From Pacientes WHERE ID_Paciente = @Id";
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

        public List<Paciente> ObtenerPacientes()
        {
            List<Paciente> pacientes = new List<Paciente>();
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    string query = "SELECT * FROM Pacientes";
                    using (SqlCommand com = new SqlCommand(query, con))
                    {
                        con.Open();
                        using (SqlDataReader read = com.ExecuteReader())
                        {
                            while (read.Read())
                            {
                                Paciente pacient = new Paciente
                                {
                                    IdPaciente = (Guid)read["id_paciente"],
                                    NombrePaciente = read["nombre"].ToString(),
                                    FechaNacimiento = DateOnly.FromDateTime((DateTime)read["fecha_nacimiento"])
                                };
                                pacientes.Add(pacient);

                            }
                        }

                        return pacientes;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        public List<Paciente> ObtenerPaciente(Guid id)
        {
            List<Paciente> pacientes = new List<Paciente>();
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuracion.ConnectionString))
                {
                    string query = "SELECT * FROM Pacientes WHERE id_paciente = @Id";
                    using (SqlCommand com = new SqlCommand(query, conn))
                    {
                        com.Parameters.AddWithValue("@Id", id);
                        conn.Open();

                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Paciente paciente = new Paciente
                                {
                                    IdPaciente = (Guid)reader["id_paciente"],
                                    NombrePaciente = reader["nombre"].ToString(),
                                    FechaNacimiento = DateOnly.FromDateTime((DateTime)reader["fecha_nacimiento"])
                                };

                                pacientes.Add(paciente);
                            }
                        }
                        return pacientes;
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
    }
}
