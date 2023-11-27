using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boardgames.Data.Models
{
    public class BoardgameSeller
    {
        [Required]
        public int BoardgameId { get; set; }

        [ForeignKey(nameof(BoardgameId))]
        public Boardgame Boardgame { get; set; } = null!;

        [Required]
        public int SellerId { get; set; }

        [ForeignKey(nameof(SellerId))]
        public Seller Seller { get; set; } = null!;
    }
}
