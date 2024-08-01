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
    internal class ManejoCitas
    {
        public void GuardarCitas(Citas cita)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    string query = "INSERT INTO Cita (id_cita,Fecha,Hora,id_paciente,id_doctor) " +
                                   "VALUES (@IdCita, @Fecha, @Hora, @PacienteId, @DoctorId)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@IdCita", cita.idCita);
                        cmd.Parameters.AddWithValue("@Fecha", cita.Fecha.ToDateTime(new TimeOnly(0)));
                        cmd.Parameters.AddWithValue("@Hora", cita.Hora.ToTimeSpan());
                        cmd.Parameters.AddWithValue("@PacienteId", cita.PacienteId);
                        cmd.Parameters.AddWithValue("@DoctorId", cita.DoctorId);

                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 0)
                        {
                            throw new Exception("No se insertaron filas.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar cita: {ex.Message}");
            }
        }

        public void ActualizarCita(Guid idCita, DateOnly fecha, TimeOnly hora, Guid pacienteId, Guid doctorId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    string query = "UPDATE Cita SET Fecha = @Fecha, Hora = @Hora, id_paciente = @PacienteId, id_doctor = @DoctorId " +
                                   "WHERE id_cita = @IdCita";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@IdCita", idCita);
                        cmd.Parameters.AddWithValue("@Fecha", fecha.ToDateTime(new TimeOnly(0)));
                        cmd.Parameters.AddWithValue("@Hora", hora.ToTimeSpan());
                        cmd.Parameters.AddWithValue("@PacienteId", pacienteId);
                        cmd.Parameters.AddWithValue("@DoctorId", doctorId);

                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 0)
                        {
                            throw new Exception("No se actualizaron filas.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar cita: {ex.Message}");
            }
        }

        public void EliminarCita(Guid idCita)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    string query = "DELETE FROM Cita WHERE id_cita = @IdCita";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@IdCita", idCita);

                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 0)
                        {
                            throw new Exception("No se eliminaron filas.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar cita: {ex.Message}");
            }
        }

        public List<Citas> ObtenerMedicos()
        {
            List<Citas> citas = new List<Citas>();
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    string query = "SELECT * FROM Cita";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Citas cita = new Citas
                                {
                                    idCita = (Guid)reader["id_cita"],
                                    Fecha = DateOnly.FromDateTime((DateTime)reader["Fecha"]),
                                    Hora = TimeOnly.FromTimeSpan((TimeSpan)reader["Hora"]),
                                    PacienteId = (Guid)reader["id_paciente"],
                                    DoctorId = (Guid)reader["id_doctor"]
                                };
                                citas.Add(cita);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener citas: {ex.Message}");
            }
            return citas;
        }

        public Citas ObtenerCita(Guid idCita)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    string query = "SELECT * FROM Cita WHERE id_cita = @IdCita";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@IdCita", idCita);

                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Citas
                                {
                                    idCita = (Guid)reader["id_cita"],
                                    Fecha = DateOnly.FromDateTime((DateTime)reader["Fecha"]),
                                    Hora = TimeOnly.FromTimeSpan((TimeSpan)reader["Hora"]),
                                    PacienteId = (Guid)reader["id_paciente"],
                                    DoctorId = (Guid)reader["id_doctor"]
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener cita: {ex.Message}");
            }
            return null;
        }
    }
}
