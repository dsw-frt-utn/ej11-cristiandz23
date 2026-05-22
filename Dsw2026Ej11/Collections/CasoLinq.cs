using System.Collections;
using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Collections;

/*
 * Para cada punto crear un método que permita:
 * 1. Obtener el primer libro (GetPrimero)
 * 2. Obtener el último libro (GetUltimo)
 * 3. Obtener la suma de precios (GetTotalPrecios)
 * 4. Obtener el promedio de precios (GetPromedioPrecios)
 * 5. Obtener la lista de libros con Id mayor a 15 (GetListById)
 * 6. Obtener una lista de cada libro con su título y precio en formato moneda (GetLibros) (debe retornar una lista de string)
 * 7. Obtener el libro con el precio más alto (GetMayorPrecio)
 * 8. Obtener el libro con el precio más bajo (GetMenorPrecio)
 * 9. Obtener los libros cuyo precio sea mayor al promedio (GetMayorPromedio)
 * 10. Obtener los libros ordenados por título de forma descendente
 * En todos los casos debe aplicarse LINQ
 */
public class CasoLinq
{

    public IEnumerable<Libro> listaLibros = Libro.CrearLista();

    // 1. Obtener el primer libro (GetPrimero)
    public Libro GetPrimero()
    {
        Libro libro = listaLibros.Select(a => new Libro(a.Id, a.Titulo, a.Precio)).First();
        return libro;
    }
     // 2. Obtener el último libro (GetUltimo)
     public Libro GetUltimo()
    {
        Libro libro = listaLibros.Select(a => new Libro(a.Id, a.Titulo, a.Precio)).Last();
        return libro;
    }
     // 3. Obtener la suma de precios (GetTotalPrecios)
     public decimal GetTotalPrecios()
    {
        decimal totalPrecios = (from l in listaLibros
                                select l.Precio).Sum();
        //listaLibros.Select(a => a.Precio).Sum();
        return totalPrecios;
    }
    // 4. Obtener el promedio de precios (GetPromedioPrecios)
    public decimal GetPromedioPrecios()
    {
        decimal totalPrecios = (from l in listaLibros
                                select l.Precio).Average();
        //listaLibros.Select(a => a.Precio).Average();
        return totalPrecios;
    }
    // 5. Obtener la lista de libros con Id mayor a 15 (GetListById)
    public List<Libro> GetListById()
    {
        IEnumerable<Libro> libro = (from a in listaLibros.ToList()
                            where a.Id>15 
                            select new Libro(a.Id, a.Titulo, a.Precio));
        return libro.ToList();
    }
    // 6. Obtener una lista de cada libro con su título y precio en formato moneda (GetLibros) (debe retornar una lista de string)
    public List<string> GetLibros()
    {
        IEnumerable<string> listaPrecios = from lp in listaLibros
                                           select ($"Titulo del libro: {lp.Titulo} - Precio: {lp.Precio:C}");
        return listaPrecios.ToList();
    }
    // 7. Obtener el libro con el precio más alto (GetMayorPrecio)
    public Libro GetMayorPrecio()
    {
        Libro? libro = (from l in listaLibros
                orderby l.Precio descending
                select new Libro(l.Id, l.Titulo, l.Precio)).FirstOrDefault();
        return libro;
    }
    // 8. Obtener el libro con el precio más bajo (GetMenorPrecio)
    public Libro GetMenorPrecio()
    {
        Libro? libro = (from l in listaLibros
                       orderby l.Precio ascending
                       select new Libro(l.Id, l.Titulo, l.Precio)).FirstOrDefault();
        return libro??throw new Exception("Hubo un error buscando el libro con el precio mas bajo");
    }
    // 9. Obtener los libros cuyo precio sea mayor al promedio (GetMayorPromedio)
    public List<Libro> GetMayorPromedio()
    {
        IEnumerable<Libro> libros = (from l in listaLibros
                       where l.Precio > ((from lp in listaLibros
                                        select lp.Precio).Average())
                       select new Libro(l.Id,l.Titulo,l.Precio)                       
                       );
        return libros.ToList();
    }
    // 10. Obtener los libros ordenados por título de forma descendente

    public List<Libro> GetLibrosOrdenados()
    {
        List<Libro> libros = (from l in listaLibros
                                    orderby l.Titulo descending
                                    select new Libro(l.Id, l.Titulo, l.Precio)).ToList();

        return libros;
    }


}
