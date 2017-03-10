using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identikit.DAL.Entities;
using Identikit.Migrations;
using System.Data.Entity.ModelConfiguration;

namespace Identikit.DAL
{
    public class IdentikitContext : DbContext
    {
        public IdentikitContext() : base("name=IdentikitContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<IdentikitContext, Configuration>("IdentikitContext"));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public System.Data.Entity.DbSet<DAL.Entities.User> Users { get; set; }

        //public System.Data.Entity.DbSet<DAL.Entities.PersonIdentity> PersonIdentities { get; set; }

    }
}
