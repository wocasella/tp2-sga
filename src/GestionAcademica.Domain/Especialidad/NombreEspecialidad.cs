using CSharpFunctionalExtensions;

namespace GestionAcademica.Domain
{
    public class NombreEspecialidad : SimpleValueObject<string>
    {
        private NombreEspecialidad(string value) : base(value)
        {
        }

        public static Result<NombreEspecialidad> Create(string value) =>
            Result.SuccessIf(!string.IsNullOrWhiteSpace(value), new NombreEspecialidad(value), "Nombre no puede estar vacío");
    }
}
