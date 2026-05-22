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

    public Libro GetPrimero()
    {
        Libro libro = listaLibros.Select(a => new Libro(a.Id, a.Titulo, a.Precio)).First();
        return libro;
    }
     public Libro GetUltimo()
    {
        Libro libro = listaLibros.Select(a => new Libro(a.Id, a.Titulo, a.Precio)).Last();
        return libro;
    }
     public decimal GetTotalPrecios()
    {
        decimal totalPrecios = (from l in listaLibros
                                select l.Precio).Sum();
        return totalPrecios;
    }
    public decimal GetPromedioPrecios()
    {
        decimal totalPrecios = (from l in listaLibros
                                select l.Precio).Average();
        return totalPrecios;
    }
    public List<Libro> GetListById()
    {
        IEnumerable<Libro> libro = (from a in listaLibros.ToList()
                            where a.Id>15 
                            select new Libro(a.Id, a.Titulo, a.Precio));
        return libro.ToList();
    }
    public List<string> GetLibros()
    {
        IEnumerable<string> listaPrecios = from lp in listaLibros
                                           select ($"Titulo del libro: {lp.Titulo} - Precio: {lp.Precio:C}");
        return listaPrecios.ToList();
    }
    public Libro? GetMayorPrecio()
    {
        Libro? libro = (from l in listaLibros
                orderby l.Precio descending
                select new Libro(l.Id, l.Titulo, l.Precio)).FirstOrDefault();
        return libro;
    }
    public Libro GetMenorPrecio()
    {
        Libro? libro = (from l in listaLibros
                       orderby l.Precio ascending
                       select new Libro(l.Id, l.Titulo, l.Precio)).FirstOrDefault();
        return libro??throw new Exception("Hubo un error buscando el libro con el precio mas bajo");
    }
    
    public List<Libro> GetMayorPromedio()
    {
        IEnumerable<Libro> libros = (from l in listaLibros
                       where l.Precio > ((from lp in listaLibros
                                        select lp.Precio).Average())
                       select new Libro(l.Id,l.Titulo,l.Precio)                       
                       );
        return libros.ToList();
    }

    public List<Libro> GetLibrosOrdenados()
    {
        List<Libro> libros = (from l in listaLibros
                                    orderby l.Titulo descending
                                    select new Libro(l.Id, l.Titulo, l.Precio)).ToList();

        return libros;
    }


}
