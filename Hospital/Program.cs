using Hospital.Entidades;
using Hospital.Servicios;

public class Program() {
    static void Main() {
        ////////////////////////////TODA ESTA SECCION ES PARA MANEJAR EL SERVICIO DE PACIENTES

        //INGRESAR PACIENTES
        Paciente j = new Paciente();
        ManejoPacientes ingr = new ManejoPacientes();
        j.IdPaciente = Guid.NewGuid();
        j.NombrePaciente = "Julian2";
        Console.WriteLine("Ingrese la fecha de nacimiento (Formato: yyyy-MM-dd):");
        string fechaNacimientoInput2 = Console.ReadLine();

        DateOnly fechaNacimiento2;
        try
        {
            fechaNacimiento2 = DateOnly.ParseExact(fechaNacimientoInput2, "yyyy-MM-dd");
        }
        catch (Exception ex) { throw (ex); }
        j.FechaNacimiento = fechaNacimiento2;

        ingr.GuardarPaciente(j);

        //OBTENER TODOS PACIENTES
        ManejoPacientes gestor = new ManejoPacientes();
        List<Paciente> pacientes = gestor.ObtenerPacientes();

        foreach (var i in pacientes)
        {
            Console.WriteLine($"{i.IdPaciente}, {i.NombrePaciente}, {i.FechaNacimiento}");
        }

        //OBTENER UN PACIENTE.
        ManejoPacientes manejo = new ManejoPacientes();
        Console.WriteLine("Ingresa ID Del paciente\n");
        string id = Console.ReadLine();

        List<Paciente> pac = gestor.ObtenerPaciente(Guid.Parse(id));
        foreach (var i in pac)
        {
            Console.WriteLine($"{i.IdPaciente}, {i.NombrePaciente}, {i.FechaNacimiento}");
        }

        //ACTUALIZAR
        Console.WriteLine("Ingrese el ID");
        string ids = Console.ReadLine();

        Console.WriteLine("Ingrese el nombre del paciente:");
        string nombre = Console.ReadLine();

        Console.WriteLine("Ingrese la fecha de nacimiento (Formato: yyyy-MM-dd):");
        string fechaNacimientoInput = Console.ReadLine();

        DateOnly fechaNacimiento;
        try
        {
            fechaNacimiento = DateOnly.ParseExact(fechaNacimientoInput, "yyyy-MM-dd");
        }
        catch (FormatException)
        {
            Console.WriteLine("Fecha de nacimiento no válida. Asegúrese de usar el formato correcto (yyyy-MM-dd).");
            return;
        }
        gestor.ActualizarPaciente(Guid.Parse(ids), nombre, fechaNacimiento);

        //ELIMINAR
        ManejoPacientes el = new ManejoPacientes();
        el.Eliminar(Guid.Parse("99ADE314-52F4-4177-BBBB-8F19AE4431DC"));
    }
}