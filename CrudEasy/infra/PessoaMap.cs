using CrudEasy.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudEasy.infra
{
    public class PessoaMap : EntityTypeConfiguration<Pessoa>
    {
        public PessoaMap()
        {
            ToTable("pessoa");
            HasKey(p => p.PessoaId);
            Property(p => p.Nome).HasMaxLength(20).IsRequired();
            Property(p => p.Endereco).IsRequired().HasMaxLength(30);
            Property(p => p.Email).HasMaxLength(25);
            Property(p => p.Idade).IsRequired();

            
        }
    }
}