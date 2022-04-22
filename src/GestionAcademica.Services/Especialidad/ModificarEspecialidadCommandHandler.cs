using GestionAcademica.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.Services
{
    public class ModificarEspecialidadCommandHandler : AsyncRequestHandler<ModificarEspecialidadCommand>
    {
        private readonly IDbContextFactory<GestionAcademicaContext> contextFactory;

        public ModificarEspecialidadCommandHandler(IDbContextFactory<GestionAcademicaContext> contextFactory) => this.contextFactory = contextFactory;

        protected override async Task Handle(ModificarEspecialidadCommand request, CancellationToken cancellationToken)
        {
            var nombreOrFailure = NombreEspecialidad.Create(request.Nombre);

            if (nombreOrFailure.IsFailure)
                throw new InvalidOperationException(nombreOrFailure.Error);

            using (var context = this.contextFactory.CreateDbContext())
            {
                var especialidad = await context.Especialidades.FindAsync(new object[] { request.Id }, cancellationToken);

                if (especialidad == null)
                    throw new InvalidOperationException($"No se encontró Especialidad con Id '{request.Id}'");

                especialidad.CambiarNombre(nombreOrFailure.Value);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
