namespace Dsw2026Ej11.Domain;

public class Alumno
{
    public int Id { get; }
    public string Nombre { get; }
    public double Promedio { get; }

    public Alumno(int id, string nombre, double promedio)
    {
        Id = id;
        Nombre = nombre.ToLower();
        Promedio = promedio;
    }

    public override string ToString()
    {
        return $"{Id} - {Nombre} - Promedio: {Promedio}";
    }
}
