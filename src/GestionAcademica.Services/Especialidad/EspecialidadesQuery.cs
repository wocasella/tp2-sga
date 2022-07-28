using MediatR;

namespace GestionAcademica.Services
{
    public class EspecialidadesQuery : IRequest<IEnumerable<EspecialidadDto>>
    {
    }
}
