using GestionAcademica.Services;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.UI.Desktop
{
    internal class SqliteDbContextFactory : IDbContextFactory<GestionAcademicaContext>
    {
        public GestionAcademicaContext CreateDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var dbPath = Path.Join(path, "sga.db");

            var options = new DbContextOptionsBuilder<GestionAcademicaContext>()
                .UseSqlite($"Data Source={dbPath}")
                .Options;

            var context = new GestionAcademicaContext(options);
            string sql = context.Database.GenerateCreateScript();
            System.Diagnostics.Debug.WriteLine(sql);
            context.Database.EnsureCreated();

            return context;
        }
    }
}
