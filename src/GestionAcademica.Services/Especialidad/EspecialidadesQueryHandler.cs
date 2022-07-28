using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.Services
{
    public class EspecialidadesQueryHandler : IRequestHandler<EspecialidadesQuery, IEnumerable<EspecialidadDto>>
    {
        private readonly IDbContextFactory<GestionAcademicaContext> contextFactory;

        public EspecialidadesQueryHandler(IDbContextFactory<GestionAcademicaContext> contextFactory) => this.contextFactory = contextFactory;

        public async Task<IEnumerable<EspecialidadDto>> Handle(EspecialidadesQuery request, CancellationToken cancellationToken)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                return await context.Especialidades.Select(x => new EspecialidadDto()
                {
                    Id = x.Id,
                    Nombre = x.Nombre
                }).ToListAsync();
            }
        }
    }
}
