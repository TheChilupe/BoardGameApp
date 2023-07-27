using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameApp.Models
{
    public class BoardGameModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string ImageURL { get; set; }

        [ForeignKey("PublisherId")]
        public int PublisherId { get; set; }

        public virtual PublisherModel? Publisher { get; set; }

        [NotMapped]
        public string? NewPublisher { get; set; }

    }
}
