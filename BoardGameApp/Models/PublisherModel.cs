using System.ComponentModel.DataAnnotations;

namespace BoardGameApp.Models
{
    public class PublisherModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        //stores all the Board games associated with the Id property.
        public virtual IEnumerable<BoardGameModel>? BoardGame { get; set; }
    }
}
