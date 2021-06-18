using HospitalManagementsystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementsystem.Data.EntitiesConfigurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.Firstname).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Lastname).HasMaxLength(50).IsRequired();
            builder.Property(x => x.UserType).IsRequired();
            builder.Property(x => x.LastLoggedIn).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.LastLoggedIn).HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.UpdatedAt).HasColumnType("datetime").IsRequired(false);
        }
    }
}
