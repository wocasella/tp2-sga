using GestionAcademica.Domain;
using MediatR;

namespace GestionAcademica.Services
{
    public class CrearEspecialidadCommandHandler : AsyncRequestHandler<CrearEspecialidadCommand>
    {
        protected override Task Handle(CrearEspecialidadCommand request, CancellationToken cancellationToken)
        {
            var nombreOrFailure = NombreEspecialidad.Create(request.Nombre);

            if (nombreOrFailure.IsFailure)
                throw new InvalidOperationException(nombreOrFailure.Error);

            var especialidad = new Especialidad(nombreOrFailure.Value);

            // TODO: instantiate DbContext and add entity
            return Task.CompletedTask;
        }
    }
}
