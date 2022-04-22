using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.Services
{
    public class EspecialidadByIdQueryHandler : IRequestHandler<EspecialidadByIdQuery, EspecialidadDto?>
    {
        private readonly IDbContextFactory<GestionAcademicaContext> contextFactory;

        public EspecialidadByIdQueryHandler(IDbContextFactory<GestionAcademicaContext> contextFactory) => this.contextFactory = contextFactory;

        public async Task<EspecialidadDto?> Handle(EspecialidadByIdQuery request, CancellationToken cancellationToken)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                var especialidad = await context.Especialidades.FindAsync(new object[] { request.Id }, cancellationToken);

                if (especialidad != null)
                {
                    return new EspecialidadDto()
                    {
                        Id = especialidad.Id,
                        Nombre = especialidad.Nombre
                    };
                }

                return null;
            }
        }
    }
}
