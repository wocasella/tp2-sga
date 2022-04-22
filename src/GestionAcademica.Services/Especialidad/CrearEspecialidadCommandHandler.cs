using GestionAcademica.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.Services
{
    public class CrearEspecialidadCommandHandler : IRequestHandler<CrearEspecialidadCommand, long>
    {
        private readonly IDbContextFactory<GestionAcademicaContext> contextFactory;

        public CrearEspecialidadCommandHandler(IDbContextFactory<GestionAcademicaContext> contextFactory) => this.contextFactory = contextFactory;

        public async Task<long> Handle(CrearEspecialidadCommand request, CancellationToken cancellationToken)
        {
            var nombreOrFailure = NombreEspecialidad.Create(request.Nombre);

            if (nombreOrFailure.IsFailure)
                throw new InvalidOperationException(nombreOrFailure.Error);

            using (var context = this.contextFactory.CreateDbContext())
            {
                var especialidad = new Especialidad(nombreOrFailure.Value);

                context.Add(especialidad);
                await context.SaveChangesAsync(cancellationToken);

                return especialidad.Id;
            }
        }
    }
}