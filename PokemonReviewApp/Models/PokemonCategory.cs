namespace PokemonReviewApp.Models;
public class PokemonCategory
{
    // Middle table between Pokemon and Category
    public int PokemonId { get; set; }
    public int CategoryId { get; set; }
    public Pokemon Pokemon { get; set; }
    public Category Category { get; set; }
}