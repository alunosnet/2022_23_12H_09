using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Trabalho_Final_MOD_17E.Data
{
    public class Trabalho_Final_MOD_17EContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Trabalho_Final_MOD_17EContext() : base("name=Trabalho_Final_MOD_17EContext")
        {
        }

        public System.Data.Entity.DbSet<Trabalho_Final_MOD_17E.Models.Carregador> Carregadors { get; set; }
        public System.Data.Entity.DbSet<Trabalho_Final_MOD_17E.Models.Carregamento> Carregamentos { get; set; }
        public System.Data.Entity.DbSet<Trabalho_Final_MOD_17E.Models.User> Users { get; set; }
    }
}
