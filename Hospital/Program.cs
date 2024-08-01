using Hospital.Entidades;
using Hospital.Servicios;
using Microsoft.Win32;

public class Program()
{
    static async Task Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Bienvenido al sistema de gestión hospitalaria");
            Console.WriteLine("Seleccione su rol:");
            Console.WriteLine("1. Paciente");
            Console.WriteLine("2. Doctor");
            Console.WriteLine("3. Admin");
            Console.WriteLine("4. Salir");

            string roleInput = Console.ReadLine();
            int role;
            if (!int.TryParse(roleInput, out role) || role < 1 || role > 4)
            {
                Console.WriteLine("Rol no válido. Intente de nuevo.");
                continue;
            }

            if (role == 4)
            {
                Console.WriteLine("Saliendo...");
                break;
            }

            switch (role)
            {
                case 1:
                    await PacienteMenu();
                    break;
                case 2:
                    await DoctorMenu();
                    break;
                case 3:
                    await AdminMenu();
                    break;
            }
        }
    }

    static async Task PacienteMenu()
    {
        var manejoPaciente = new ManejoPacientes();

        while (true)
        {
            Console.WriteLine("Menu Paciente:");
            Console.WriteLine("1. Crear Registro");
            Console.WriteLine("2. Salir al menú principal");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.WriteLine("Ingrese su nombre:");
                    string nombrePaciente = Console.ReadLine();
                    Console.WriteLine("Ingrese la fecha (yyyy-MM-dd):");
                    DateOnly fecha = DateOnly.Parse(Console.ReadLine());

                    var nuevoRegistro = new Paciente
                    {
                        IdPaciente = Guid.NewGuid(),
                        NombrePaciente = nombrePaciente,
                        FechaNacimiento = fecha
                    };

                    manejoPaciente.GuardarPaciente(nuevoRegistro);
                    Console.WriteLine("Registro guardado exitosamente.");
                    break;

                case "2":
                    return;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static async Task DoctorMenu()
    {
        var manejoCitas = new ManejoCitas();
        var manejoRegistros = new ManejoRegistros();

        while (true)
        {
            Console.WriteLine("Menu Doctor:");
            Console.WriteLine("1. Crear Cita");
            Console.WriteLine("2. Actualizar Cita");
            Console.WriteLine("3. Eliminar Cita");
            Console.WriteLine("4. Ver Citas");
            Console.WriteLine("5. Crear Registro");
            Console.WriteLine("6. Actualizar Registro");
            Console.WriteLine("7. Eliminar Registro");
            Console.WriteLine("8. Ver Registros");
            Console.WriteLine("9. Salir al menú principal");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    await CrearCita(manejoCitas);
                    break;
                case "2":
                    await ActualizarCita(manejoCitas);
                    break;
                case "3":
                    await EliminarCita(manejoCitas);
                    break;
                case "4":
                    await VerCitas(manejoCitas);
                    break;
                case "5":
                    await CrearRegistro(manejoRegistros);
                    break;
                case "6":
                    await ActualizarRegistro(manejoRegistros);
                    break;
                case "7":
                    await EliminarRegistro(manejoRegistros);
                    break;
                case "8":
                    await VerRegistros(manejoRegistros);
                    break;
                case "9":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static async Task AdminMenu()
    {
        // Puedes agregar opciones de administración aquí
        while (true)
        {
            Console.WriteLine("Menu Admin:");
            Console.WriteLine("1. Realizar tareas de administración");
            Console.WriteLine("2. Salir al menú principal");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    // Implementa las tareas de administración
                    Console.WriteLine("Tareas de administración aún no implementadas.");
                    break;

                case "2":
                    return;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static async Task CrearCita(ManejoCitas manejoCitas)
    {
        Console.WriteLine("Ingrese la fecha (yyyy-MM-dd):");
        DateOnly fecha = DateOnly.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese la hora (hh:mm):");
        TimeOnly hora = TimeOnly.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el ID del paciente:");
        Guid pacienteId = Guid.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el ID del doctor:");
        Guid doctorId = Guid.Parse(Console.ReadLine());

        var nuevaCita = new Citas
        {
            idCita = Guid.NewGuid(),
            Fecha = fecha,
            Hora = hora,
            PacienteId = pacienteId,
            DoctorId = doctorId
        };

        manejoCitas.GuardarCitas(nuevaCita);
        Console.WriteLine("Cita guardada exitosamente.");
    }

    static async Task ActualizarCita(ManejoCitas manejoCitas)
    {
        Console.WriteLine("Ingrese el ID de la cita a actualizar:");
        Guid idCita = Guid.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese la nueva fecha (yyyy-MM-dd):");
        DateOnly fecha = DateOnly.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese la nueva hora (hh:mm):");
        TimeOnly hora = TimeOnly.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el nuevo ID del paciente:");
        Guid pacienteId = Guid.Parse(Console.ReadLine());

        manejoCitas.ActualizarCita(idCita, fecha, hora, pacienteId);
        Console.WriteLine("Cita actualizada exitosamente.");
    }

    static async Task EliminarCita(ManejoCitas manejoCitas)
    {
        Console.WriteLine("Ingrese el ID de la cita a eliminar:");
        Guid idCita = Guid.Parse(Console.ReadLine());

        manejoCitas.EliminarCita(idCita);
        Console.WriteLine("Cita eliminada exitosamente.");
    }

    static async Task VerCitas(ManejoCitas manejoCitas)
    {
        var citas = manejoCitas.ObtenerMedicos();
        foreach (var cita in citas)
        {
            Console.WriteLine($"ID: {cita.idCita}, Fecha: {cita.Fecha}, Hora: {cita.Hora}, Paciente: {cita.PacienteId}, Doctor: {cita.DoctorId}");
        }
    }

    static async Task CrearRegistro(ManejoRegistros manejoRegistros)
    {
        Console.WriteLine("Ingrese el ID del paciente:");
        Guid pacienteId = Guid.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el ID del doctor:");
        Guid doctorId = Guid.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el diagnóstico:");
        string diagnostico = Console.ReadLine();

        Console.WriteLine("Ingrese el tratamiento:");
        string tratamiento = Console.ReadLine();

        var nuevoRegistro = new Registro
        {
            Id = Guid.NewGuid(),
            fecha = DateOnly.FromDateTime(DateTime.Now),
            Diagnostico = diagnostico,
            Tratamiento = tratamiento,
            Id_Paciente = pacienteId,
            Id_Doctor = doctorId
        };

        manejoRegistros.GuardarRegistro(nuevoRegistro);
        Console.WriteLine("Registro guardado exitosamente.");
    }

    static async Task ActualizarRegistro(ManejoRegistros manejoRegistros)
    {
        Console.WriteLine("Ingrese el ID del registro a actualizar:");
        Guid id = Guid.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese la nueva fecha (yyyy-MM-dd):");
        DateOnly fecha = DateOnly.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el nuevo diagnóstico:");
        string diagnostico = Console.ReadLine();

        Console.WriteLine("Ingrese el nuevo tratamiento:");
        string tratamiento = Console.ReadLine();

        Console.WriteLine("Ingrese el nuevo ID del paciente:");
        Guid idPaciente = Guid.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el nuevo ID del doctor:");
        Guid idDoctor = Guid.Parse(Console.ReadLine());

        manejoRegistros.ActualizarRegistro(id, fecha, diagnostico, tratamiento, idPaciente, idDoctor);
        Console.WriteLine("Registro actualizado exitosamente.");
    }

    static async Task EliminarRegistro(ManejoRegistros manejoRegistros)
    {
        Console.WriteLine("Ingrese el ID del registro a eliminar:");
        Guid id = Guid.Parse(Console.ReadLine());

        manejoRegistros.EliminarRegistro(id);
        Console.WriteLine("Registro eliminado exitosamente.");
    }

    static async Task VerRegistros(ManejoRegistros manejoRegistros)
    {
        var registros = manejoRegistros.ObtenerRegistros();
        foreach (var registro in registros)
        {
            Console.WriteLine($"ID: {registro.Id}, Fecha: {registro.fecha}, Diagnóstico: {registro.Diagnostico}, Tratamiento: {registro.Tratamiento}, Paciente: {registro.Id_Paciente}, Doctor: {registro.Id_Doctor}");
        }
      }
    }





    
