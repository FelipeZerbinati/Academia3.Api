using acdm = Academia2.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academia2.Data.Postgres.Configuration
{
    public class AcademiaConfiguration : IEntityTypeConfiguration<acdm.Academia2>
    {
        public void Configure(EntityTypeBuilder<acdm.Academia2> builder)
        {
            builder.ToTable("Academia2");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome);
        }
    }
}
