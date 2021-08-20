using System.ComponentModel.DataAnnotations;

namespace Catalog.InputModel
{
    public class GameInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The game's name must be between 3 and 100 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The publisher's name must be between 3 and 100 characters.")]
        public string Publisher { get; set; }

        [Required]
        [Range(1, 200, ErrorMessage = "The game's price must be between 1 and 200 US$.")]
        public double Price { get; set; }
    }
}
