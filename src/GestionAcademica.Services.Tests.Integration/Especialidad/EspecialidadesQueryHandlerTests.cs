using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GestionAcademica.Domain;
using Xunit;

namespace GestionAcademica.Services.Tests.Integration
{
    public class EspecialidadesQueryHandlerTests : IDisposable
    {
        private SqliteDbContextFactory ContextFactory { get; } = new SqliteDbContextFactory();
        private EspecialidadesQueryHandler Sut { get; }

        public EspecialidadesQueryHandlerTests() => this.Sut = new EspecialidadesQueryHandler(this.ContextFactory);

        public void Dispose() => this.ContextFactory.Dispose();

        [Fact]
        public async Task Puedo_leer_las_Especialidades_existentes()
        {
            // arrange
            await this.AddEspecialidadesAsync("IQ", "ISI", "IC");

            var query = new EspecialidadesQuery();

            // act
            IEnumerable<EspecialidadDto> especialidades = await this.Sut.Handle(query, CancellationToken.None);

            // assert
            Assert.NotNull(especialidades);
            Assert.Collection(especialidades,
                x => Assert.Equal("IQ", x.Nombre),
                x => Assert.Equal("ISI", x.Nombre),
                x => Assert.Equal("IC", x.Nombre));
        }

        [Fact]
        public async Task Recibo_una_lista_vacia_cuando_no_existe_ninguna_Especialidad()
        {
            // arrange
            var query = new EspecialidadesQuery();

            // act
            IEnumerable<EspecialidadDto> especialidades = await this.Sut.Handle(query, CancellationToken.None);

            // assert
            Assert.NotNull(especialidades);
            Assert.Empty(especialidades);
        }

        private async Task AddEspecialidadesAsync(params string[] nombres)
        {
            var especialidades = nombres.Select(x => new Especialidad(NombreEspecialidad.Create(x).Value));
            await this.ContextFactory.InitializeWith(especialidades.ToArray());
        }
    }
}
