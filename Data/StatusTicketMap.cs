
using double_v_partners.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace double_v_partners.Data
{
    public class StatusTicketMap
    {
        
        public StatusTicketMap(EntityTypeBuilder<StatusTicket> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(itemDb => itemDb.Id);
            entityTypeBuilder.ToTable("ticket_status");

            entityTypeBuilder.Property(itemDb => itemDb.Id).HasColumnName("id");
            entityTypeBuilder.Property(itemDb => itemDb.Description).HasColumnName("description");
        }
    }
}
