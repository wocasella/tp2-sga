using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GestionAcademica.Services.Tests.Integration
{
    public class CrearEspecialidadCommandHandlerTests : IDisposable
    {
        private SqliteDbContextFactory ContextFactory { get; } = new SqliteDbContextFactory();

        public void Dispose() => this.ContextFactory.Dispose();

        [Fact]
        public async Task Puedo_crear_una_Especialidad()
        {
            // arrange
            var command = new CrearEspecialidadCommand("ISI");

            var sut = new CrearEspecialidadCommandHandler(this.ContextFactory);

            // act
            long idEspecialidad = await sut.Handle(command, CancellationToken.None);

            // assert
            Assert.True(idEspecialidad > 0);
        }
    }
}
