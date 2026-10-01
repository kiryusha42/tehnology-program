namespace galery;

/// <summary>
/// Картины
/// </summary>
public class Painting
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public int ExhibitionId { get; set; }
    public int ArtistId { get; set; }
    public int Year { get; set; }
    public int Price { get; set; }
    public bool IsValuable => Price > 1000000;

    public Painting() { }

    public Painting(int id, string title, int exhibitionId, int artistId, int year, int price)
    {
        Id = id;
        Title = title;
        ExhibitionId = exhibitionId;
        ArtistId = artistId;
        Year = year;
        Price = price;
    }
    public string GetInfo()
    {
        return $"{Title} ({Year}, {Price} руб.)";
    }
}
