
using double_v_partners.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace double_v_partners.Data
{
    public class TicketMap
    {
        public TicketMap(EntityTypeBuilder<Ticket> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(itemDb => itemDb.Id);
            entityTypeBuilder.ToTable("tickets");

            entityTypeBuilder.Property(itemDb => itemDb.Id).HasColumnName("id");
            entityTypeBuilder.Property(itemDb => itemDb.UserId).HasColumnName("user_id");
            entityTypeBuilder.Property(itemDb => itemDb.StatusId).HasColumnName("status_id");
            entityTypeBuilder.Property(itemDb => itemDb.CreatedAt).HasColumnName("created_at");
            entityTypeBuilder.Property(itemDb => itemDb.UpdatedAt).HasColumnName("updated_at");
        }
    }
}
