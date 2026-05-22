using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Collections;

//Crear un diccionario donde la clave sea el legajo y el valor el alumno
//Incluir un método para agregar un alumno al diccionario
//Incluir un método para buscar un alumno utilizando la clave
//Incluir un método para retornar el diccionario
//Incluir un método para eliminar un alumno utilizando la clave
public class CasoDictionary
{

    private Dictionary<Guid, Alumno> alumnoDiccionario;


    public CasoDictionary()
    {
        alumnoDiccionario = new Dictionary<Guid, Alumno>();
    }

    public void AgregarAlumno(Alumno alumno)
    {
        if (alumnoDiccionario is not null)
        {
            alumnoDiccionario.Add(Guid.NewGuid(), alumno);
            return;
        }
        throw new Exception("El diccionario no ha sido inicializado.");
    }

    public void AgregarAlumno(Guid? legajo, Alumno alumno)
    {
        if (alumnoDiccionario is not null && legajo is not null)
        {
            alumnoDiccionario.Add(legajo.Value, alumno);
            return;
        }
        throw new Exception("El diccionario no ha sido inicializado.");
    }
    public Alumno? BuscarAlumno(Guid legajo)
    {
        Alumno? alumno;
        
        if (alumnoDiccionario is not null)
        {
            if (alumnoDiccionario.TryGetValue(legajo, out alumno))
            {
                return alumno;

            }
            return null;
            // throw new Exception("No existe un alumno con ese legajo.");
        }
        throw new Exception("El diccionario no ha sido inicializado.");
    }

    public Dictionary<Guid,Alumno> GetAlumnoDiccionario() 
    {
        return this.alumnoDiccionario;
    }

    public void EliminarAlumno(Guid legajo)
    {

        IDictionary<Guid,Alumno> alumnos = this.alumnoDiccionario ?? throw new Exception("No se inicio el diciconario") ;

        if (!alumnos.Remove(legajo))
        {
            throw new Exception($"No se pudo eliminar el alumno con legajo {legajo}");
        }
    }
}
