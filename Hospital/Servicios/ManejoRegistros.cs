using Hospital.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using SinTransaction.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Servicios;
internal class ManejoRegistros
{
    public void GuardarRegistro(Registro registro)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
            {
                string query = "INSERT INTO Registros (id_registro, fecha, diagnostico, tratamiento, id_paciente, id_doctor) " +
                               "VALUES (@Id, @Fecha, @Diagnostico, @Tratamiento, @IdPaciente, @IdDoctor)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id", registro.Id);
                    cmd.Parameters.AddWithValue("@Fecha", registro.fecha.ToDateTime(new TimeOnly(0)));
                    cmd.Parameters.AddWithValue("@Diagnostico", registro.Diagnostico);
                    cmd.Parameters.AddWithValue("@Tratamiento", registro.Tratamiento);
                    cmd.Parameters.AddWithValue("@IdPaciente", registro.Id_Paciente);
                    cmd.Parameters.AddWithValue("@IdDoctor", registro.Id_Doctor);

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
            throw new Exception($"Error al guardar registro: {ex.Message}");
        }
    }

    public void ActualizarRegistro(Guid id, DateOnly fecha, string diagnostico, string tratamiento, Guid idPaciente, Guid idDoctor)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
            {
                string query = "UPDATE Registros SET fecha = @Fecha, diagnostico = @Diagnostico, tratamiento = @Tratamiento, " +
                               "id_paciente = @IdPaciente, id_doctor = @IdDoctor WHERE id_registro = @Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Fecha", fecha.ToDateTime(new TimeOnly(0)));
                    cmd.Parameters.AddWithValue("@Diagnostico", diagnostico);
                    cmd.Parameters.AddWithValue("@Tratamiento", tratamiento);
                    cmd.Parameters.AddWithValue("@IdPaciente", idPaciente);
                    cmd.Parameters.AddWithValue("@IdDoctor", idDoctor);

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
            throw new Exception($"Error al actualizar registro: {ex.Message}");
        }
    }

    public void EliminarRegistro(Guid id)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
            {
                string query = "DELETE FROM Registros WHERE id_registro = @Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

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
            throw new Exception($"Error al eliminar registro: {ex.Message}");
        }
    }

    public List<Registro> ObtenerRegistros()
    {
        List<Registro> registros = new List<Registro>();
        try
        {
            using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
            {
                string query = "SELECT * FROM Registros";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Registro registro = new Registro
                            {
                                Id = (Guid)reader["id_registro"],
                                fecha = DateOnly.FromDateTime((DateTime)reader["fecha"]),
                                Diagnostico = reader["diagnostico"].ToString(),
                                Tratamiento = reader["tratamiento"].ToString(),
                                Id_Paciente = (Guid)reader["id_paciente"],
                                Id_Doctor = (Guid)reader["id_doctor"]
                            };
                            registros.Add(registro);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener registros: {ex.Message}");
        }
        return registros;
    }

    public Registro ObtenerRegistro(Guid id)
    {
        Registro registro = null;
        try
        {
            using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
            {
                string query = "SELECT * FROM Registros WHERE id_registro = @Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            registro = new Registro
                            {
                                Id = (Guid)reader["id_registro"],
                                fecha = DateOnly.FromDateTime((DateTime)reader["fecha"]),
                                Diagnostico = reader["diagnostico"].ToString(),
                                Tratamiento = reader["tratamiento"].ToString(),
                                Id_Paciente = (Guid)reader["id_paciente"],
                                Id_Doctor = (Guid)reader["id_doctor"]
                            };
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener registro: {ex.Message}");
        }
        return registro;
    }
}

