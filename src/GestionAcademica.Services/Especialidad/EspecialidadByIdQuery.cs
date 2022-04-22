using MediatR;

namespace GestionAcademica.Services
{
    public class EspecialidadByIdQuery : IRequest<EspecialidadDto?>
    {
        public long Id { get; }

        public EspecialidadByIdQuery(long id) => this.Id = id;
    }
}
