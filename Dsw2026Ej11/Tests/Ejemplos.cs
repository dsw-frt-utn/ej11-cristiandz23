using System.Timers;
using Dsw2026Ej11.Collections;
using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Tests;


internal class Ejemplos
{
    //Agregar 3 alumnos a la lista
    //Listar por consola los alumnos
    //Buscar por nombre un alumno que exista y mostrar por consola
    //Buscar por nombre un alumno que no exista y mostrar por consola el texto "No existe"
    //Eliminar un alumno y listar por consola los alumnos
    //Eliminar el primer elemento de la lista y listar por consola los alumnos
    public static void EjemploList()
    {
        CasoList list = new CasoList();
        Alumno? alumno;

        list.AgregarAlumno(new Alumno(1, "yulian", 5.4), new Alumno(2, "Marcelo", 5.4),
            new Alumno(3, "Gonzalo", 4.9), new Alumno(4, "Jose", 2.4), 
            new Alumno(5, "Facundo", 9.3), new Alumno(6, "Nicolas", 5.9));


        Console.WriteLine($"\n\n Lista de alumnos");
        foreach(Alumno al in list.GetAlumnos())
        {
            Console.WriteLine( al.ToString() );
        }


        Console.WriteLine($"\n\n Buscar el alumno Marcelo");
        alumno = list.BuscarAlumno("marcelo");
        Console.WriteLine(alumno?.ToString());


        Console.WriteLine($"\n\n Eliminar el alumno no agregado leonel ");
        alumno = list.BuscarAlumno("leonel");
        if (alumno is null)
            Console.WriteLine("No existe");

        alumno = list.ObtenerAlumnoAlAzar();
        Console.WriteLine($"\n\n Eliminar el alumno: {alumno.Nombre} ");
        list.EliminarAlumno(alumno);
        Console.WriteLine($"\n Lista de alumnos");
        foreach (Alumno al in list.GetAlumnos())
        {
            Console.WriteLine(al.ToString());
        }


        Console.WriteLine($"\n\n Eliminar el primer alumno: ");
        list.EliminarAlumnoPorPosicion(0);

        Console.WriteLine($"\n\n Lista de alumnos");
        foreach (Alumno al in list.GetAlumnos())
        {
            Console.WriteLine(al.ToString());
        }






    }

    //Agregar 3 alumnos al diccionario
    //Listar por consola los alumnos
    //Buscar un alumno por clave y mostrar por consola
    //Buscar un alumno por clave, pero que no exista, y mostrar por consola el texto "No existe"
    //Eliminar un alumno por clave y listar por consola los alumnos
    public static void EjemploDictionary()
    {
        CasoDictionary casoDictionary = new CasoDictionary();

        casoDictionary.AgregarAlumno(new Guid("40CD2C15-51F2-4DA5-8093-73970D1332DC"),new Alumno( 1, "Ricardo", 8.4 ));
        casoDictionary.AgregarAlumno(new Alumno( 2, "Marcelo", 5.4 ));
        casoDictionary.AgregarAlumno(new Alumno (3, "Gonzalo", 4.9));
        casoDictionary.AgregarAlumno(new Alumno ( 4, "Jose", 2.4 ));
        casoDictionary.AgregarAlumno(new Alumno (5, "Facundo", 9.3));
        casoDictionary.AgregarAlumno(new Alumno (6, "Nicolas", 5.9));
        
        Console.WriteLine("\n\n Lista de alumnos: ");
        foreach(var al in casoDictionary.GetAlumnoDiccionario())
        {
            Console.WriteLine($"legajo: {al.Key} alumno: {al.Value.ToString()}");
        }
        
        Console.WriteLine("\n\n Buscar alumno con clave 40CD2C15 - 51F2 - 4DA5 - 8093 - 73970D1332DC: ");
        Alumno? alumno = casoDictionary.BuscarAlumno(new Guid("40CD2C15-51F2-4DA5-8093-73970D1332DC"));
        Console.WriteLine($"{alumno?.ToString()}");
        //alumno ?? new Alumno(12, "asd", 222);


        Console.WriteLine("\n\n Buscar alumno por clave al azar: ");
        alumno = casoDictionary.BuscarAlumno(Guid.NewGuid());
        if(alumno is null)
            Console.WriteLine("No existe");

        Console.WriteLine("\n\n Eliminar el alumno con la clave  40CD2C15 - 51F2 - 4DA5 - 8093 - 73970D1332DC: ");
        casoDictionary.EliminarAlumno(new Guid("40CD2C15-51F2-4DA5-8093-73970D1332DC"));

        Console.WriteLine("\n\n Lista de alumnos con el alumno eliminado: ");
        foreach (var al in casoDictionary.GetAlumnoDiccionario())
        {
            Console.WriteLine($"legajo: {al.Key} alumno: {al.Value.ToString()}");
        }

    }

    //Realizar una llamada a cada método definido en CasoLinq y mostar por consola según corresponda
    public static void EjemploLinq()
    {
        CasoLinq casosLinq = new CasoLinq();

        Console.WriteLine("\n \n Obtener el primer libro");
        Console.WriteLine($"Primero libro: {casosLinq.GetPrimero().ToString()}");

        Console.WriteLine("\n\n Obtener el último libro");
        Console.WriteLine($"Ultimo libro: {casosLinq.GetUltimo().ToString()}");


        Console.WriteLine("\n\n Obtener la suma de precios");
        Console.WriteLine($"Suma total de los precios: {casosLinq.GetTotalPrecios().ToString()}");


        Console.WriteLine("\n\n Obtener el promedio de precios");
        Console.WriteLine($"Suma promedio de los precios: {casosLinq.GetPromedioPrecios().ToString()}");

        Console.WriteLine("\n\n Obtener la lista de libros con Id mayor a 15");
        foreach(var l in casosLinq.GetListById())
        {
            Console.WriteLine(l.ToString());
        }


        Console.WriteLine("\n\n Obtener una lista de cada libro con su título y precio en formato moneda");
        foreach (var l in casosLinq.GetLibros())
        {
            Console.WriteLine(l);
        }


        Console.WriteLine("\n\n Obtener el libro con el precio más alto");
        Console.WriteLine($"Libro con precio mas alto: {casosLinq.GetMayorPrecio()?.ToString()}");

        Console.WriteLine("\n\n Obtener el libro con el precio más bajo");
        Console.WriteLine($"Libro precio mas bajo: {casosLinq?.GetMenorPrecio().ToString()}");

        Console.WriteLine("\n\n Obtener los libros cuyo precio sea mayor al promedio");
        foreach (var l in casosLinq.GetMayorPromedio())
        {
            Console.WriteLine(l.ToString());
        }

        Console.WriteLine("\n Obtener los libros ordenados por título de forma descendente");
        foreach (var l in casosLinq.GetLibrosOrdenados())
        {
            Console.WriteLine(l.ToString());
        }

    }
}
