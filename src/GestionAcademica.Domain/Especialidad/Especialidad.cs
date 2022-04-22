using CSharpFunctionalExtensions;

namespace GestionAcademica.Domain
{
    public class Especialidad : Entity
    {
        public NombreEspecialidad Nombre { get; private set; }

        public Especialidad(NombreEspecialidad nombre) => this.Nombre = nombre;

        // Requerido por EF Core
        private Especialidad() => this.Nombre = null!;

        public void CambiarNombre(NombreEspecialidad nombre) => this.Nombre = nombre;
    }
}