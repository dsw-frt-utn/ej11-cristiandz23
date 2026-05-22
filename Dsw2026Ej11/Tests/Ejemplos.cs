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

    }

    //Agregar 3 alumnos al diccionario
    //Listar por consola los alumnos
    //Buscar un alumno por clave y mostrar por consola
    //Buscar un alumno por clave, pero que no exista, y mostrar por consola el texto "No existe"
    //Eliminar un alumno por clave y listar por consola los alumnos
    public static void EjemploDictionary()
    {

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
        Console.WriteLine($"Libro con precio mas alto: {casosLinq.GetMayorPrecio().ToString()}");

        Console.WriteLine("\n\n Obtener el libro con el precio más bajo");
        Console.WriteLine($"Libro precio mas bajo: {casosLinq.GetMenorPrecio().ToString()}");

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
