using System;
using System.ComponentModel.DataAnnotations;

namespace double_v_partners.Models
{
    public class StatusTicket
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
