using CSharpFunctionalExtensions;

namespace GestionAcademica.Domain
{
    public class Especialidad : Entity
    {
        public NombreEspecialidad Nombre { get; }

        public Especialidad(NombreEspecialidad nombre) => this.Nombre = nombre;
    }
}