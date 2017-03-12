using CrudEasy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CrudEasy.infra
{
    public class Contexto : DbContext
    {

        public Contexto() : base("name=con")
        {
            //if (Database.Exists())
            //{


            //    if (!Database.CompatibleWithModel(false))
            //    {
            //        var dbMigration = new DbMigrator(new CrudEasy.Migrations.Configuration());
            //        dbMigration.Update();
            //    }

            //}
            //else
            //{
            //    Database.SetInitializer<Contexto>(new CreateDatabaseIfNotExists<Contexto>());
            //}
        }
        public DbSet<Pessoa> Pessoas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //Database.Log = (query) => Debug.Write(query);

            //modelBuilder.HasDefaultSchema("public");
            //modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new PessoaMap());


            base.OnModelCreating(modelBuilder);
        }

        public class ContextoInicializar : IDatabaseInitializer<Contexto>
        {
            //Método responsavel por inicializar o banco de dados, recebe como parametro um objeto contexto.
            public void InitializeDatabase(Contexto context)
            {
                //Verifica se o banco de dados já existe
                if (context.Database.Exists())
                {
                    //Verifica se o banco de dados é compativel com o modelo.
                    if (!context.Database.CompatibleWithModel(false))
                    {
                        //Atualiza o banco de dados.
                        var dbMigrator = new DbMigrator(new CrudEasy.Migrations.Configuration());
                        dbMigrator.Update();
                    }
                }
                //Se não existir
                else
                {
                    //Cria o Banco de dados com base no contexto.
                    //context.Database.Create();
                    //            Database.SetInitializer<DbContext>(new MigrateDatabaseToLatestVersion<DbContext,  Configuration>());
                    var initializer = new MigrateDatabaseToLatestVersion<Contexto, CrudEasy.Migrations.Configuration>();
                    Database.SetInitializer(initializer);
                    try
                    {
                        context.Database.Initialize(true);
                    }
                    catch (Exception ex)
                    {
                        //Handle Error in some way
                        ex.ToString();
                    }
                }

            }
        }
    }
}
