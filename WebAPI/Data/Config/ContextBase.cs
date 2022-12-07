using Microsoft.EntityFrameworkCore;
using Model.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Config
{
    public class ContextBase : DbContext
    {

        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(GetStringConectionConfig(), new MySqlServerVersion(new Version(8, 0, 29)));
                base.OnConfiguring(optionsBuilder);
            }
        }

        public DbSet<ProdutoViewModel> ProdutoViewModel { get; set; }

        private string GetStringConectionConfig()
        {
            string strCon = "server=localhost;port=3320;database=api3camadas;user=user;password=pass";
            return strCon;
        }



    }
}
