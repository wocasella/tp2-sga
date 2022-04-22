using MediatR;

namespace GestionAcademica.Services
{
    public class EliminarEspecialidadCommand : IRequest
    {
        public long Id { get; }

        public EliminarEspecialidadCommand(long id) => this.Id = id;
    }
}
