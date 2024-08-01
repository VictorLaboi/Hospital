using Hospital.Entidades;
using Hospital.Servicios;
using Microsoft.Win32;

public class Program()
{
    static async Task Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
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
            Console.Clear();
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
        Console.Clear();
        var manejoCitas = new ManejoCitas();
        var manejoRegistros = new ManejoRegistros();

        while (true)
        {
            Console.WriteLine("Menu Citas Doctor/Admin:");
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
        Console.Clear();
        while (true)
        {
            Console.WriteLine("Ingrese seccion por administrar:\n1:CITAS Y REGISTROS\n2:DEPARTAMENTOS\n3:MEDICOS\n4:PACIENTES\n5:Salir");
            string op = Console.ReadLine();
            switch (op)
            {
                case "1":
                    await DoctorMenu();
                    break;
                case "2":
                    await MenuDepartamentos();
                    break;
                case "3":
                    await MenuMedicos();
                    break;
                case "4":
                    await MenuPacientes();
                    break;
                case "5":
                    return;
                    break;
                default: Console.WriteLine("Error");
                    break;
            }
        }

    }
        static async Task MenuDepartamentos() {
        Console.Clear();
        ManejoDepartamento manejoDepartamento = new ManejoDepartamento();
        Console.WriteLine("Ingrese una opción:\n1:Crear departamento\n2:Consultar departamento\n3:Consultar todo\n4:Eliminar\n5:Actualizar departamento");
        string op = Console.ReadLine();
        switch (op)
        {
            case "1":
                Console.WriteLine("Ingresa Nombre de departamento");
                string name= Console.ReadLine();

                Console.WriteLine("Ingrese descripcion");
                string desc = Console.ReadLine();

                var nuevoDepa = new Departamento
                {
                    IdDepartamento= Guid.NewGuid(),
                    Nombre = name,
                    Descripcion = desc,
                };
                manejoDepartamento.GuardarDepa(nuevoDepa);
                Console.ReadKey();
                break;
            case "2":
                Console.WriteLine("Ingrese ID de departamento");
                Guid depId = Guid.Parse(Console.ReadLine());
                var regis = manejoDepartamento.ObtenerDepa(depId);
                foreach (var reg in regis) {
                    Console.WriteLine($"{reg.Nombre}\n{reg.Descripcion}");
                }
                break;
            case "3":
                var regis2 = manejoDepartamento.ObtenerDepas();
                foreach (var i in regis2) {
                    Console.WriteLine($"{i.IdDepartamento}\n{i.Nombre}\n{i.Descripcion}");
                }
                Console.ReadKey();
                break;
            case "4":
                Console.WriteLine("Ingrese el ID del departamento a eliminar");
                Guid id = Guid.Parse(Console.ReadLine());
                manejoDepartamento.Eliminar(id);
                Console.ReadKey();
                break;
            case "5":
                Console.WriteLine("Ingrese el ID del departamento");
                Guid idDepa = Guid.Parse(Console.ReadLine());

                Console.WriteLine("Ingresa nuevo nombre");
                string n = Console.ReadLine();

                Console.WriteLine("Ingrese nueva descripcion");
                string dec = Console.ReadLine() ;

                manejoDepartamento.ActualizarDepa(idDepa,n,dec);
                Console.WriteLine("Cita actualizada exitosamente.");
                Console.ReadKey();
                break;
            case "6":
                return;
            default:
                Console.WriteLine("Ingrese una opcion válida.");
                break;
        }
    }
    static async Task MenuMedicos()
    {
        Console.Clear();
        ManejoMedico manejoMedico = new ManejoMedico();

        while (true)
        {
            Console.WriteLine("Ingrese una opción:\n1:Crear médico\n2:Consultar médico\n3:Consultar todos\n4:Eliminar\n5:Actualizar médico\n6:Salir");
            string op = Console.ReadLine();

            try
            {
                switch (op)
                {
                    case "1":
                        await CrearMedico(manejoMedico);
                        Console.ReadKey();
                        break;
                    case "2":
                        await ConsultarMedico(manejoMedico);
                        Console.ReadKey();
                        break;
                    case "3":
                        await ConsultarTodosMedicos(manejoMedico);
                        Console.ReadKey();
                        break;
                    case "4":
                        await EliminarMedico(manejoMedico);
                        Console.ReadKey();
                        break;
                    case "5":
                        await ActualizarMedico(manejoMedico);
                        Console.ReadKey();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Ingrese una opción válida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    static async Task MenuPacientes()
    {
        ManejoPacientes manejoPacientes = new ManejoPacientes();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Ingrese una opción:\n1:Crear paciente\n2:Consultar paciente\n3:Consultar todos\n4:Eliminar\n5:Actualizar paciente\n6:Salir");
            string op = Console.ReadLine();

            try
            {
                switch (op)
                {
                    case "1":
                        await CrearPaciente(manejoPacientes);
                        Console.ReadKey();
                        break;
                    case "2":
                        await ConsultarPaciente(manejoPacientes);
                        Console.ReadKey();
                        break;
                    case "3":
                        await ConsultarTodosPacientes(manejoPacientes);
                        Console.ReadKey();
                        break;
                    case "4":
                        await EliminarPaciente(manejoPacientes);
                        Console.ReadKey();
                        break;
                    case "5":
                        await ActualizarPaciente(manejoPacientes);
                        Console.ReadKey();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Ingrese una opción válida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private static async Task CrearPaciente(ManejoPacientes manejoPacientes)
    {
        Console.WriteLine("Ingrese nombre del paciente:");
        string nombre = Console.ReadLine();

        Console.WriteLine("Ingrese fecha de nacimiento (yyyy-MM-dd):");
        if (DateOnly.TryParse(Console.ReadLine(), out DateOnly fechaNacimiento))
        {
            var nuevoPaciente = new Paciente
            {
                IdPaciente = Guid.NewGuid(),
                NombrePaciente = nombre,
                FechaNacimiento = fechaNacimiento
            };

            manejoPacientes.GuardarPaciente(nuevoPaciente);
            Console.WriteLine("Paciente creado exitosamente.");
        }
        else
        {
            Console.WriteLine("Fecha de nacimiento inválida.");
        }
    }

    private static async Task ConsultarPaciente(ManejoPacientes manejoPacientes)
    {
        Console.WriteLine("Ingrese ID del paciente:");
        if (Guid.TryParse(Console.ReadLine(), out Guid idPaciente))
        {
            var paciente = manejoPacientes.ObtenerPaciente(idPaciente);
            if (paciente.Count > 0)
            {
                foreach (var p in paciente)
                {
                    Console.WriteLine($"Nombre: {p.NombrePaciente}\nFecha de Nacimiento: {p.FechaNacimiento}");
                }
            }
            else
            {
                Console.WriteLine("Paciente no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    private static async Task ConsultarTodosPacientes(ManejoPacientes manejoPacientes)
    {
        var pacientes = manejoPacientes.ObtenerPacientes();
        foreach (var paciente in pacientes)
        {
            Console.WriteLine($"ID: {paciente.IdPaciente}\nNombre: {paciente.NombrePaciente}\nFecha de Nacimiento: {paciente.FechaNacimiento}");
        }
    }

    private static async Task EliminarPaciente(ManejoPacientes manejoPacientes)
    {
        Console.WriteLine("Ingrese ID del paciente a eliminar:");
        if (Guid.TryParse(Console.ReadLine(), out Guid idPaciente))
        {
            manejoPacientes.Eliminar(idPaciente);
            Console.WriteLine("Paciente eliminado exitosamente.");
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    private static async Task ActualizarPaciente(ManejoPacientes manejoPacientes)
    {
        Console.WriteLine("Ingrese ID del paciente:");
        if (Guid.TryParse(Console.ReadLine(), out Guid idPaciente))
        {
            Console.WriteLine("Ingrese nuevo nombre:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese nueva fecha de nacimiento (yyyy-MM-dd):");
            if (DateOnly.TryParse(Console.ReadLine(), out DateOnly fechaNacimiento))
            {
                manejoPacientes.ActualizarPaciente(idPaciente, nombre, fechaNacimiento);
                Console.WriteLine("Paciente actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("Fecha de nacimiento inválida.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    private static async Task CrearMedico(ManejoMedico manejoMedico)
    {
        Console.WriteLine("Ingrese nombre del médico:");
        string nombre = Console.ReadLine();

        Console.WriteLine("Ingrese especialidad del médico:");
        string especialidad = Console.ReadLine();

        Console.WriteLine("Ingrese ID del departamento:");
        if (Guid.TryParse(Console.ReadLine(), out Guid idDepartamento))
        {
            var nuevoMedico = new Medico
            {
                DoctorId = Guid.NewGuid(),
                Nombre = nombre,
                Especialidad = especialidad,
                IdDepartamento = idDepartamento
            };

            manejoMedico.GuardarMedico(nuevoMedico);
            Console.WriteLine("Médico creado exitosamente.");
        }
        else
        {
            Console.WriteLine("ID del departamento inválido.");
        }
    }

    private static async Task ConsultarMedico(ManejoMedico manejoMedico)
    {
        Console.WriteLine("Ingrese ID del médico:");
        if (Guid.TryParse(Console.ReadLine(), out Guid doctorId))
        {
            var medico = manejoMedico.ObtenerMedico(doctorId);
            if (medico != null)
            {
                Console.WriteLine($"Nombre: {medico.Nombre}\nEspecialidad: {medico.Especialidad}\nID Departamento: {medico.IdDepartamento}");
            }
            else
            {
                Console.WriteLine("Médico no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    private static async Task ConsultarTodosMedicos(ManejoMedico manejoMedico)
    {
        var medicos = manejoMedico.ObtenerMedicos();
        foreach (var medico in medicos)
        {
            Console.WriteLine($"ID: {medico.DoctorId}\nNombre: {medico.Nombre}\nEspecialidad: {medico.Especialidad}\nID Departamento: {medico.IdDepartamento}");
        }
    }

    private static async Task EliminarMedico(ManejoMedico manejoMedico)
    {
        Console.WriteLine("Ingrese ID del médico a eliminar:");
        if (Guid.TryParse(Console.ReadLine(), out Guid doctorId))
        {
            manejoMedico.EliminarMedico(doctorId);
            Console.WriteLine("Médico eliminado exitosamente.");
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    private static async Task ActualizarMedico(ManejoMedico manejoMedico)
    {
        Console.WriteLine("Ingrese ID del médico:");
        if (Guid.TryParse(Console.ReadLine(), out Guid doctorId))
        {
            Console.WriteLine("Ingrese nuevo nombre:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese nueva especialidad:");
            string especialidad = Console.ReadLine();

            Console.WriteLine("Ingrese nuevo ID del departamento:");
            if (Guid.TryParse(Console.ReadLine(), out Guid idDepartamento))
            {
                manejoMedico.ActualizarMedico(doctorId, nombre, especialidad, idDepartamento);
                Console.WriteLine("Médico actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("ID del departamento inválido.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
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





    
