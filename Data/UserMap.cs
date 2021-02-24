
using double_v_partners.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace double_v_partners.Data
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(itemDb => itemDb.Id);
            entityTypeBuilder.ToTable("users");

            entityTypeBuilder.Property(itemDb => itemDb.Id).HasColumnName("id");
            entityTypeBuilder.Property(itemDb => itemDb.Name).HasColumnName("name");
            entityTypeBuilder.Property(itemDb => itemDb.Username).HasColumnName("username");
            entityTypeBuilder.Property(itemDb => itemDb.Email).HasColumnName("email");
        }
    }
}
