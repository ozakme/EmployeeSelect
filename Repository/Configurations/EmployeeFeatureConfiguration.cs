using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Repository.Configurations
{
    public interface EmployeeFeatureConfiguration : IEntityTypeConfiguration<EmployeeFeature>
    {
        public void Configure(EntityTypeBuilder<EmployeeFeature> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.Employee).WithOne(x => x.EmployeeFeature).HasForeignKey<EmployeeFeature>(x => x.EmployeeId);
        }
    }
}
