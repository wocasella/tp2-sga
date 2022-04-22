using System;
using System.Threading;
using System.Threading.Tasks;
using GestionAcademica.Domain;
using MediatR;
using Xunit;

namespace GestionAcademica.Services.Tests.Integration
{
    public class EliminarEspecialidadCommandHandlerTests : IDisposable
    {
        private SqliteDbContextFactory ContextFactory { get; } = new SqliteDbContextFactory();
        private IRequestHandler<EliminarEspecialidadCommand> Sut { get; }

        public EliminarEspecialidadCommandHandlerTests() => this.Sut = new EliminarEspecialidadCommandHandler(this.ContextFactory);

        public void Dispose() => this.ContextFactory.Dispose();

        [Fact]
        public async Task Puedo_eliminar_una_Especialidad_existente()
        {
            // arrange
            var idEspecialidad = await this.AddEspecialidadAsync("IE");

            var command = new EliminarEspecialidadCommand(idEspecialidad);

            // act
            await this.Sut.Handle(command, CancellationToken.None);

            // assert
            using var context = this.ContextFactory.CreateDbContext();
            var especialidad = await context.Especialidades.FindAsync(idEspecialidad);

            Assert.Null(especialidad);
        }

        [Fact]
        public async Task Cuando_intento_eliminar_una_Especialidad_inexistente_recibo_una_excepcion()
        {
            // arrange
            var command = new EliminarEspecialidadCommand(id: -1);

            // act
            var action = () => this.Sut.Handle(command, CancellationToken.None);

            // assert
            await Assert.ThrowsAsync<InvalidOperationException>(action);
        }

        private async Task<long> AddEspecialidadAsync(string nombre)
        {
            var especialidad = new Especialidad(NombreEspecialidad.Create(nombre).Value);
            await this.ContextFactory.InitializeWith(especialidad);

            return especialidad.Id;
        }
    }
}
