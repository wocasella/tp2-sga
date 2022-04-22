using System;
using System.Threading;
using System.Threading.Tasks;
using GestionAcademica.Domain;
using MediatR;
using Xunit;

namespace GestionAcademica.Services.Tests.Integration
{
    public class ModificarEspecialidadCommandHandlerTests : IDisposable
    {
        private SqliteDbContextFactory ContextFactory { get; } = new SqliteDbContextFactory();
        private IRequestHandler<ModificarEspecialidadCommand> Sut { get; }

        public ModificarEspecialidadCommandHandlerTests() => this.Sut = new ModificarEspecialidadCommandHandler(this.ContextFactory);

        public void Dispose() => this.ContextFactory.Dispose();

        [Fact]
        public async Task Puedo_modificar_una_Especialidad_existente()
        {
            // arrange
            var idEspecialidad = await this.AddEspecialidadAsync("IQ");

            var command = new ModificarEspecialidadCommand(idEspecialidad, "IM");

            // act
            await this.Sut.Handle(command, CancellationToken.None);

            // assert
            using var context = this.ContextFactory.CreateDbContext();
            var especialidad = await context.Especialidades.FindAsync(idEspecialidad);

            Assert.NotNull(especialidad);
            Assert.Equal("IM", especialidad!.Nombre);
        }

        [Fact]
        public async Task Cuando_intento_modificar_una_Especialidad_inexistente_recibo_una_excepcion()
        {
            // arrange
            var command = new ModificarEspecialidadCommand(id: -1, "IM");

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
