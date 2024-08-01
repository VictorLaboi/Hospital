using Hospital.Entidades;
using Hospital.Servicios;

public class Program()
{
    static void Main()
    {
        //////////////////////////////TODA ESTA SECCION ES PARA MANEJAR EL SERVICIO DE PACIENTES

        ////INGRESAR PACIENTES
        //Paciente j = new Paciente();
        //ManejoPacientes ingr = new ManejoPacientes();
        //j.IdPaciente = Guid.NewGuid();
        //j.NombrePaciente = "Julian2";
        //Console.WriteLine("Ingrese la fecha de nacimiento (Formato: yyyy-MM-dd):");
        //string fechaNacimientoInput2 = Console.ReadLine();

        //DateOnly fechaNacimiento2;
        //try
        //{
        //    fechaNacimiento2 = DateOnly.ParseExact(fechaNacimientoInput2, "yyyy-MM-dd");
        //}
        //catch (Exception ex) { throw (ex); }
        //j.FechaNacimiento = fechaNacimiento2;

        //ingr.GuardarPaciente(j);

        ////OBTENER TODOS PACIENTES
        //ManejoPacientes gestor = new ManejoPacientes();
        //List<Paciente> pacientes = gestor.ObtenerPacientes();

        //foreach (var i in pacientes)
        //{
        //    Console.WriteLine($"{i.IdPaciente}, {i.NombrePaciente}, {i.FechaNacimiento}");
        //}

        ////OBTENER UN PACIENTE.
        //ManejoPacientes manejo = new ManejoPacientes();
        //Console.WriteLine("Ingresa ID Del paciente\n");
        //string id = Console.ReadLine();

        //List<Paciente> pac = gestor.ObtenerPaciente(Guid.Parse(id));
        //foreach (var i in pac)
        //{
        //    Console.WriteLine($"{i.IdPaciente}, {i.NombrePaciente}, {i.FechaNacimiento}");
        //}

        ////ACTUALIZAR
        //Console.WriteLine("Ingrese el ID");
        //string ids = Console.ReadLine();

        //Console.WriteLine("Ingrese el nombre del paciente:");
        //string nombre = Console.ReadLine();

        //Console.WriteLine("Ingrese la fecha de nacimiento (Formato: yyyy-MM-dd):");
        //string fechaNacimientoInput = Console.ReadLine();

        //DateOnly fechaNacimiento;
        //try
        //{
        //    fechaNacimiento = DateOnly.ParseExact(fechaNacimientoInput, "yyyy-MM-dd");
        //}
        //catch (FormatException)
        //{
        //    Console.WriteLine("Fecha de nacimiento no válida. Asegúrese de usar el formato correcto (yyyy-MM-dd).");
        //    return;
        //}
        //gestor.ActualizarPaciente(Guid.Parse(ids), nombre, fechaNacimiento);

        ////ELIMINAR
        //ManejoPacientes el = new ManejoPacientes();
        //el.Eliminar(Guid.Parse("99ADE314-52F4-4177-BBBB-8F19AE4431DC"));

        //DEPARTAMENTOS

        ////DAR DE ALTA
        //Console.WriteLine("Ingrese el nombre del departamento:");
        //string nombre = Console.ReadLine();

        //Console.WriteLine("Ingrese la descripción del departamento:");
        //string descripcion = Console.ReadLine();

        //Departamento departamento = new Departamento
        //{
        //    IdDepartamento = Guid.NewGuid(),
        //    Nombre = nombre,
        //    Descripcion = descripcion
        //};

        //var manejoDepartamentos = new ManejoDepartamento();
        //manejoDepartamentos.GuardarDepa(departamento);
        //Console.WriteLine("Departamento agregado exitosamente.");

        ////ACTUALIZAR
        //Console.WriteLine("Ingrese el ID del departamento (GUID) a modificar:");
        //string idDepartamento = Console.ReadLine();

        //if (Guid.TryParse(idDepartamento, out Guid guidDepartamento))
        //{
        //    Console.WriteLine("Ingrese el nuevo nombre del departamento:");
        //    string nombre2 = Console.ReadLine();

        //    Console.WriteLine("Ingrese la nueva descripción del departamento:");
        //    string descripcion2 = Console.ReadLine();

        //    var manejoDepartamento = new ManejoDepartamento();
        //    manejoDepartamento.ActualizarDepa(guidDepartamento, nombre2, descripcion2);
        //    Console.WriteLine("Departamento modificado exitosamente.");
        //}
        //else
        //{
        //    Console.WriteLine("Formato de GUID inválido.");
        //}

        //COSULTAR

        //var manejoDepartamentos = new ManejoDepartamento();
        //List<Departamento> departamentos = manejoDepartamentos.ObtenerDepas();

        //if (departamentos.Count > 0)
        //{
        //    foreach (var departamento in departamentos)
        //    {
        //        Console.WriteLine($"ID: {departamento.IdDepartamento}, Nombre: {departamento.Nombre}, Descripción: {departamento.Descripcion}");
        //    }
        //}
        //else
        //{
        //    Console.WriteLine("No se encontraron departamentos.");
        //}

        ////CONSULTAR UNO
        //Console.WriteLine("Ingrese el ID del departamento (GUID) a consultar:");
        //string idDepartamento = Console.ReadLine();

        //if (Guid.TryParse(idDepartamento, out Guid guidDepartamento))
        //{
        //    var manejoDepartamento = new ManejoDepartamento();
        //    List<Departamento> departamentos2 = manejoDepartamento.ObtenerDepa(guidDepartamento);

        //    if (departamentos2.Count > 0)
        //    {
        //        foreach (var departamento in departamentos2)
        //        {
        //            Console.WriteLine($"ID: {departamento.IdDepartamento}, Nombre: {departamento.Nombre}, Descripción: {departamento.Descripcion}");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("No se encontró el departamento.");
        //    }
        //}
        //else
        //{
        //    Console.WriteLine("Formato de GUID inválido.");
        //}

        ////ELIMINAR

        //Console.WriteLine("Ingrese el ID del departamento (GUID) a eliminar:");
        //string idDepartamento = Console.ReadLine();

        //if (Guid.TryParse(idDepartamento, out Guid guidDepartamento))
        //{
        //    var manejoDepartamentos = new ManejoDepartamento();
        //    manejoDepartamentos.Eliminar(guidDepartamento);
        //    Console.WriteLine("Departamento eliminado exitosamente.");
        //}
        //else
        //{
        //    Console.WriteLine("Formato de GUID inválido.");
        //}
        //    ManejoMedico manejoMedicos = new ManejoMedico();

        //    while (true)
        //    {
        //        Console.WriteLine("Seleccione una opción para gestionar médicos:");
        //        Console.WriteLine("1. Agregar médico");
        //        Console.WriteLine("2. Modificar médico");
        //        Console.WriteLine("3. Eliminar médico");
        //        Console.WriteLine("4. Consultar médicos");
        //        Console.WriteLine("5. Consultar un solo médico");
        //        Console.WriteLine("6. Salir");

        //        string opcion = Console.ReadLine();
        //        switch (opcion)
        //        {
        //            case "1":
        //                AgregarMedico(manejoMedicos);
        //                break;
        //            case "2":
        //                ModificarMedico(manejoMedicos);
        //                break;
        //            case "3":
        //                EliminarMedico(manejoMedicos);
        //                break;
        //            case "4":
        //                ConsultarMedicos(manejoMedicos);
        //                break;
        //            case "5":
        //                ConsultarUnMedico(manejoMedicos);
        //                break;
        //            case "6":
        //                return;
        //            default:
        //                Console.WriteLine("Opción no válida. Intente de nuevo.");
        //                break;
        //        }
        //    }
        //}

        //static void AgregarMedico(ManejoMedico manejoMedicos)
        //{
        //    Console.WriteLine("Ingrese el nombre del médico:");
        //    string nombre = Console.ReadLine();

        //    Console.WriteLine("Ingrese la especialidad del médico:");
        //    string especialidad = Console.ReadLine();

        //    Console.WriteLine("Ingrese el ID del departamento (GUID):");
        //    string idDepartamento = Console.ReadLine();

        //    if (Guid.TryParse(idDepartamento, out Guid guidDepartamento))
        //    {
        //        Medico medico = new Medico
        //        {
        //            DoctorId = Guid.NewGuid(),
        //            Nombre = nombre,
        //            Especialidad = especialidad,
        //            IdDepartamento = guidDepartamento
        //        };

        //        manejoMedicos.GuardarMedico(medico);
        //        Console.WriteLine("Médico agregado exitosamente.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Formato de GUID inválido.");
        //    }
        //}

        //static void ModificarMedico(ManejoMedico manejoMedicos)
        //{
        //    Console.WriteLine("Ingrese el ID del médico (GUID) a modificar:");
        //    string doctorId = Console.ReadLine();

        //    if (Guid.TryParse(doctorId, out Guid guidDoctorId))
        //    {
        //        Console.WriteLine("Ingrese el nuevo nombre del médico:");
        //        string nombre = Console.ReadLine();

        //        Console.WriteLine("Ingrese la nueva especialidad del médico:");
        //        string especialidad = Console.ReadLine();

        //        Console.WriteLine("Ingrese el nuevo ID del departamento (GUID):");
        //        string idDepartamento = Console.ReadLine();

        //        if (Guid.TryParse(idDepartamento, out Guid guidDepartamento))
        //        {
        //            manejoMedicos.ActualizarMedico(guidDoctorId, nombre, especialidad, guidDepartamento);
        //            Console.WriteLine("Médico modificado exitosamente.");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Formato de GUID del departamento inválido.");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Formato de GUID del médico inválido.");
        //    }
        //}

        //static void EliminarMedico(ManejoMedico manejoMedicos)
        //{
        //    Console.WriteLine("Ingrese el ID del médico (GUID) a eliminar:");
        //    string doctorId = Console.ReadLine();

        //    if (Guid.TryParse(doctorId, out Guid guidDoctorId))
        //    {
        //        manejoMedicos.EliminarMedico(guidDoctorId);
        //        Console.WriteLine("Médico eliminado exitosamente.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Formato de GUID inválido.");
        //    }
        //}

        //static void ConsultarMedicos(ManejoMedico manejoMedicos)
        //{
        //    List<Medico> medicos = manejoMedicos.ObtenerMedicos();

        //    if (medicos.Count > 0)
        //    {
        //        foreach (var medico in medicos)
        //        {
        //            Console.WriteLine($"ID: {medico.DoctorId}, Nombre: {medico.Nombre}, Especialidad: {medico.Especialidad}, ID Departamento: {medico.IdDepartamento}");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("No se encontraron médicos.");
        //    }
        //}

        //static void ConsultarUnMedico(ManejoMedico manejoMedicos)
        //{
        //    Console.WriteLine("Ingrese el ID del médico (GUID) a consultar:");
        //    string doctorId = Console.ReadLine();

        //    if (Guid.TryParse(doctorId, out Guid guidDoctorId))
        //    {
        //        Medico medico = manejoMedicos.ObtenerMedico(guidDoctorId);
        //        if (medico != null)
        //        {
        //            Console.WriteLine($"ID: {medico.DoctorId}, Nombre: {medico.Nombre}, Especialidad: {medico.Especialidad}, ID Departamento: {medico.IdDepartamento}");
        //        }
        //        else
        //        {
        //            Console.WriteLine("No se encontró el médico.");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Formato de GUID inválido.");
        //    }

        //}
        ManejoCitas manejoCitas = new ManejoCitas();

        while (true)
        {
            Console.WriteLine("Seleccione una opción para gestionar citas:");
            Console.WriteLine("1. Agregar cita");
            Console.WriteLine("2. Modificar cita");
            Console.WriteLine("3. Eliminar cita");
            Console.WriteLine("4. Consultar citas");
            Console.WriteLine("5. Consultar una sola cita");
            Console.WriteLine("6. Salir");

            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    AgregarCita(manejoCitas);
                    break;
                case "2":
                    ModificarCita(manejoCitas);
                    break;
                case "3":
                    EliminarCita(manejoCitas);
                    break;
                case "4":
                    ConsultarCitas(manejoCitas);
                    break;
                case "5":
                    ConsultarUnaCita(manejoCitas);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void AgregarCita(ManejoCitas manejoCitas)
    {
        Console.WriteLine("Ingrese la fecha de la cita (AAAA-MM-DD):");
        string fechaInput = Console.ReadLine();
        DateOnly fecha = DateOnly.Parse(fechaInput);

        Console.WriteLine("Ingrese la hora de la cita (HH:MM):");
        string horaInput = Console.ReadLine();
        TimeOnly hora = TimeOnly.Parse(horaInput);

        Console.WriteLine("Ingrese el ID del paciente (GUID):");
        string pacienteId = Console.ReadLine();

        Console.WriteLine("Ingrese el ID del doctor (GUID):");
        string doctorId = Console.ReadLine();

        if (Guid.TryParse(pacienteId, out Guid guidPacienteId) && Guid.TryParse(doctorId, out Guid guidDoctorId))
        {
            Citas cita = new Citas
            {
                idCita = Guid.NewGuid(),
                Fecha = fecha,
                Hora = hora,
                PacienteId = guidPacienteId,
                DoctorId = guidDoctorId
            };

            manejoCitas.GuardarCitas(cita);
            Console.WriteLine("Cita agregada exitosamente.");
        }
        else
        {
            Console.WriteLine("Formato de GUID inválido.");
        }
    }

    static void ModificarCita(ManejoCitas manejoCitas)
    {
        Console.WriteLine("Ingrese el ID de la cita (GUID) a modificar:");
        string citaId = Console.ReadLine();

        if (Guid.TryParse(citaId, out Guid guidCitaId))
        {
            Console.WriteLine("Ingrese la nueva fecha de la cita (AAAA-MM-DD):");
            string fechaInput = Console.ReadLine();
            DateOnly fecha = DateOnly.Parse(fechaInput);

            Console.WriteLine("Ingrese la nueva hora de la cita (HH:MM):");
            string horaInput = Console.ReadLine();
            TimeOnly hora = TimeOnly.Parse(horaInput);

            Console.WriteLine("Ingrese el nuevo ID del paciente (GUID):");
            string pacienteId = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo ID del doctor (GUID):");
            string doctorId = Console.ReadLine();

            if (Guid.TryParse(pacienteId, out Guid guidPacienteId) && Guid.TryParse(doctorId, out Guid guidDoctorId))
            {
                manejoCitas.ActualizarCita(guidCitaId, fecha, hora, guidPacienteId, guidDoctorId);
                Console.WriteLine("Cita modificada exitosamente.");
            }
            else
            {
                Console.WriteLine("Formato de GUID del paciente o del doctor inválido.");
            }
        }
        else
        {
            Console.WriteLine("Formato de GUID de la cita inválido.");
        }
    }

    static void EliminarCita(ManejoCitas manejoCitas)
    {
        Console.WriteLine("Ingrese el ID de la cita (GUID) a eliminar:");
        string citaId = Console.ReadLine();

        if (Guid.TryParse(citaId, out Guid guidCitaId))
        {
            manejoCitas.EliminarCita(guidCitaId);
            Console.WriteLine("Cita eliminada exitosamente.");
        }
        else
        {
            Console.WriteLine("Formato de GUID inválido.");
        }
    }

    static void ConsultarCitas(ManejoCitas manejoCitas)
    {
        List<Citas> citas = manejoCitas.ObtenerMedicos();

        if (citas.Count > 0)
        {
            foreach (var cita in citas)
            {
                Console.WriteLine($"ID: {cita.idCita}, Fecha: {cita.Fecha}, Hora: {cita.Hora}, ID Paciente: {cita.PacienteId}, ID Doctor: {cita.DoctorId}");
            }
        }
        else
        {
            Console.WriteLine("No se encontraron citas.");
        }
    }

    static void ConsultarUnaCita(ManejoCitas manejoCitas)
    {
        Console.WriteLine("Ingrese el ID de la cita (GUID) a consultar:");
        string citaId = Console.ReadLine();

        if (Guid.TryParse(citaId, out Guid guidCitaId))
        {
            Citas cita = manejoCitas.ObtenerCita(guidCitaId);
            if (cita != null)
            {
                Console.WriteLine($"ID: {cita.idCita}, Fecha: {cita.Fecha}, Hora: {cita.Hora}, ID Paciente: {cita.PacienteId}, ID Doctor: {cita.DoctorId}");
            }
            else
            {
                Console.WriteLine("No se encontró la cita.");
            }
        }
        else
        {
            Console.WriteLine("Formato de GUID inválido.");
        }
    }

}

    
