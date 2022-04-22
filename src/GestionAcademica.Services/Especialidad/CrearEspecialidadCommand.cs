using MediatR;

namespace GestionAcademica.Services
{
    public class CrearEspecialidadCommand : IRequest<long>
    {
        public string Nombre { get; }

        public CrearEspecialidadCommand(string nombre) => this.Nombre = nombre;
    }
}