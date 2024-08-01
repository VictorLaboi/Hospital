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
    internal class ManejoMedico
    {
        public void GuardarMedico(Medico medico)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    string query = "INSERT INTO Doctores (id_doctor, nombre, especialidad, id_departamento) VALUES (@DoctorId, @Nombre, @Especialidad, @IdDepartamento)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@DoctorId", medico.DoctorId);
                        cmd.Parameters.AddWithValue("@Nombre", medico.Nombre);
                        cmd.Parameters.AddWithValue("@Especialidad", medico.Especialidad);
                        cmd.Parameters.AddWithValue("@IdDepartamento", medico.IdDepartamento);

                        con.Open();
                        var result = cmd.ExecuteNonQuery();
                        if (result == 0)
                        {
                            throw new Exception("No se pudo insertar el médico.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ActualizarMedico(Guid doctorId, string nombre, string especialidad, Guid idDoctor)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    string query = "UPDATE Doctores SET nombre = @Nombre, especialidad = @Especialidad, id_departamento = @IdDepartamento WHERE id_doctor = @DoctorId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@DoctorId", doctorId);
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Especialidad", especialidad);
                        cmd.Parameters.AddWithValue("@IdDepartamento", idDoctor);

                        con.Open();
                        var result = cmd.ExecuteNonQuery();
                        if (result == 0)
                        {
                            throw new Exception("No se pudo actualizar el médico.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EliminarMedico(Guid doctorId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    string query = "DELETE FROM Doctores WHERE id_doctor = @DoctorId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@DoctorId", doctorId);

                        con.Open();
                        var result = cmd.ExecuteNonQuery();
                        if (result == 0)
                        {
                            throw new Exception("No se pudo eliminar el médico.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Medico> ObtenerMedicos()
        {
            List<Medico> medicos = new List<Medico>();
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    string query = "SELECT * FROM Doctores";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Medico medico = new Medico
                                {
                                    DoctorId = (Guid)reader["id_doctor"],
                                    Nombre = reader["nombre"].ToString(),
                                    Especialidad = reader["especialidad"].ToString(),
                                    IdDepartamento = (Guid)reader["id_departamento"]
                                };
                                medicos.Add(medico);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return medicos;
        }

        public Medico ObtenerMedico(Guid doctorId)
        {
            Medico medico = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    string query = "SELECT * FROM Doctores WHERE id_doctor = @DoctorId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@DoctorId", doctorId);

                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                medico = new Medico
                                {
                                    DoctorId = (Guid)reader["id_doctor"],
                                    Nombre = reader["nombre"].ToString(),
                                    Especialidad = reader["especialidad"].ToString(),
                                    IdDepartamento = (Guid)reader["id_departamento"]
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return medico;
        }

    }
}
