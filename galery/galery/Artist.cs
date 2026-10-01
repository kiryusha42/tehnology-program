namespace galery;

/// <summary>
/// Художник
/// </summary>
public class Artist
{
    public int Id { get; set; }
    public string FullName { get; set; } = "";
    public string Country { get; set; } = "";
    public string Style { get; set; } = "";

    public bool IsForeign => Country != "Россия";

    public Artist() { }

    public Artist(int id, string fullName, string country, string style)
    {
        Id = id;
        FullName = fullName;
        Country = country;
        Style = style;
    }
    public string GetInfo()
    {
        return $"{FullName} ({Country}, {Style})";
    }
}
