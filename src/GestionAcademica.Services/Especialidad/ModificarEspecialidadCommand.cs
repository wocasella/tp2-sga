using MediatR;

namespace GestionAcademica.Services
{
    public class ModificarEspecialidadCommand : IRequest
    {
        public long Id { get; }
        public string Nombre { get; }

        public ModificarEspecialidadCommand(long id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }
    }
}
