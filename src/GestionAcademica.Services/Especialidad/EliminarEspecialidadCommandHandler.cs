using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.Services
{
    public class EliminarEspecialidadCommandHandler : AsyncRequestHandler<EliminarEspecialidadCommand>
    {
        private readonly IDbContextFactory<GestionAcademicaContext> contextFactory;

        public EliminarEspecialidadCommandHandler(IDbContextFactory<GestionAcademicaContext> contextFactory) => this.contextFactory = contextFactory;

        protected override async Task Handle(EliminarEspecialidadCommand request, CancellationToken cancellationToken)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                var especialidad = await context.Especialidades.FindAsync(new object[] { request.Id }, cancellationToken);

                if (especialidad == null)
                    throw new InvalidOperationException($"No se encontró Especialidad con Id '{request.Id}'");

                context.Remove(especialidad);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
