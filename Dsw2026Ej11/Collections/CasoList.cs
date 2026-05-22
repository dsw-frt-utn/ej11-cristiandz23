using System.Reflection.Metadata.Ecma335;
using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Collections;

//Crear un campo que represente una lista de alumnos (List<>)
//Incluir un método para agregar alumnos a la lista
//Incluir un método para retornar la lista
//Incluir un método para buscar un alumno por nombre
//Incluir un método para eliminar un alumno (debe recibir un alumno)
//Incluir un método para eliminar un alumno en una determinada posición de la lista
public class CasoList
{
    //Crear un campo que represente una lista de alumnos (List<>)
    private List<Alumno> alumnos;

    public CasoList()
    {
        if(alumnos is null)
        {
            alumnos = new List<Alumno>();
        }
    }

    public List<Alumno> GetAlumnos()
    {
        return alumnos;
    }

    public Alumno ObtenerAlumnoAlAzar()
    {
        Random random = new Random();
        return alumnos[random.Next(alumnos.Count())];
    }

    //Incluir un método para agregar alumnos a la lista
    public void AgregarAlumno(Alumno alumno)
    {
        alumnos.Add(alumno);
    }
    public void AgregarAlumno(params Alumno[] alumnos)
    {
        foreach(Alumno al in alumnos)
        {
            this.alumnos.Add(al);
        }
    }

    //Incluir un método para buscar un alumno por nombre
    public Alumno? BuscarAlumno(string nombre) 
    {

        Alumno? alumno = alumnos.Find(alumno => alumno.Nombre.ToLower() == nombre.ToLower());
        if (alumno is not null)
            return alumno;
        return null;
    }

    //Incluir un método para eliminar un alumno (debe recibir un alumno)
    public void EliminarAlumno(Alumno alumno)
    {
        if (!alumnos.Remove(alumno))
        {
            throw new Exception($"No se encontró el alumno {alumno.Nombre}");
        }
    }

    //Incluir un método para eliminar un alumno en una determinada posición de la lista
    public void EliminarAlumnoPorPosicion(int posicion)
    {
        if(posicion< 0 || posicion>alumnos.Count - 1)
        {
            throw new Exception($"La posición {posicion} no es válida. Debe estar entre 0 y {alumnos.Count - 1}");
        }
        alumnos.RemoveAt(posicion);
    }

}
