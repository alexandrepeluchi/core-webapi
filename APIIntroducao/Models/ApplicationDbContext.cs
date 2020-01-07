using Microsoft.EntityFrameworkCore;

namespace APIIntroducao.Models
{
    public class ApplicationDbContext : DbContext
    {
        /*
            A classe ApplicationDbContext, deve receber o nome de todos os modelos criados,
            o DbSet recebe o nome do modelo, você passa o nome que quer dar para a tabela
            e os métodos que você quer passar para ela.
        */
        public DbSet<Categories> Categories { get; set; }
    }
}