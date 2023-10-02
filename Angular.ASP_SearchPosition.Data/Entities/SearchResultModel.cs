using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular.ASP_SearchPosition.Models
{
    public class SearchResultModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [Column]
        public string Keywords { get; set; } = string.Empty;

        [Required]
        [Column]
        public string Url { get; set; } = string.Empty;

        [Required]
        [Column]
        public string Engine { get; set; } = string.Empty;

        [Column]
        public DateTime CreatedAt { get; set; }

        [NotMapped]
        public int[]? Positions { get; set; }

        [JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        [Column]
        public string? PositionsJson
        {
            get => Positions == null ? null : JsonConvert.SerializeObject(Positions);
            set => Positions = value == null ? null : JsonConvert.DeserializeObject<int[]>(value);
        }
    }
}
