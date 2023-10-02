using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.ASP_SearchPosition.Data.Entities
{
    public class RequestModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [Column]
        public string Route {  get; set; } = string.Empty;

        [Required]
        [Column]
        public long ExecTime { get; set; } = long.MaxValue;

        [Required]
        [Column]
        public DateTime CreatedAt { get; set; }

        [Column]
        public string? Exception { get; set; }

    }
}
