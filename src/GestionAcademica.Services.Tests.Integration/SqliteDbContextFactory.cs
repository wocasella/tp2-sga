using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.Services.Tests.Integration
{
    public class SqliteDbContextFactory : IDbContextFactory<GestionAcademicaContext>, IDisposable
    {
        private readonly SqliteConnection connection;
        private readonly DbContextOptions<GestionAcademicaContext> contextOptions;

        public SqliteDbContextFactory()
        {
            this.connection = new SqliteConnection("Filename=:memory:");
            this.connection.Open();

            this.contextOptions = new DbContextOptionsBuilder<GestionAcademicaContext>()
                    .UseSqlite(this.connection)
                    .Options;
        }

        public GestionAcademicaContext CreateDbContext()
        {
            var context = new GestionAcademicaContext(this.contextOptions);
            context.Database.EnsureCreated();

            return context;
        }

        public void Dispose() => this.connection.Dispose();

        public async Task InitializeWith<TEntity>(params TEntity[] entities)
            where TEntity : Entity
        {
            using var context = this.CreateDbContext();

            foreach (var entity in entities)
            {
                await context.AddAsync(entity);
            }

            await context.SaveChangesAsync();
        }
    }
}
