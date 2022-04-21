using MediatR;

namespace GestionAcademica.Services
{
    public class CrearEspecialidadCommand : IRequest
    {
        public string Nombre { get; }

        public CrearEspecialidadCommand(string nombre) => this.Nombre = nombre;
    }
}