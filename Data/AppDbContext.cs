using ApiCrud.Estudantes;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Estudante> Estudantes { get; set; }
        //para fazer entender que é uma tabela do banco

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Banco.sqlite");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            base.OnConfiguring(optionsBuilder);
        }
        //aqui explico como eu quero que o EF se comunique com o SQL
    }
}
