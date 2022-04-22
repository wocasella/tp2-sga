using System;
using System.Threading;
using System.Threading.Tasks;
using GestionAcademica.Domain;
using Xunit;

namespace GestionAcademica.Services.Tests.Integration
{
    public class EspecialidadByIdQueryHandlerTests : IDisposable
    {
        private SqliteDbContextFactory ContextFactory { get; } = new SqliteDbContextFactory();
        private EspecialidadByIdQueryHandler Sut { get; }

        public EspecialidadByIdQueryHandlerTests() => this.Sut = new EspecialidadByIdQueryHandler(this.ContextFactory);

        public void Dispose() => this.ContextFactory.Dispose();

        [Fact]
        public async Task Puedo_leer_una_Especialidad_existente()
        {
            // arrange
            var idEspecialidad = await this.AddEspecialidadAsync("IQ");

            var query = new EspecialidadByIdQuery(idEspecialidad);

            // act
            EspecialidadDto? especialidad = await this.Sut.Handle(query, CancellationToken.None);

            // assert
            Assert.NotNull(especialidad);
            Assert.Equal(idEspecialidad, especialidad!.Id);
            Assert.Equal("IQ", especialidad.Nombre);
        }

        [Fact]
        public async Task No_puedo_leer_una_Especialidad_inexistente()
        {
            // arrange
            var query = new EspecialidadByIdQuery(id: -1);

            // act
            EspecialidadDto? especialidad = await this.Sut.Handle(query, CancellationToken.None);

            // assert
            Assert.Null(especialidad);
        }

        private async Task<long> AddEspecialidadAsync(string nombre)
        {
            var especialidad = new Especialidad(NombreEspecialidad.Create(nombre).Value);
            await this.ContextFactory.InitializeWith(especialidad);

            return especialidad.Id;
        }
    }
}
