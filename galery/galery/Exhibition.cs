namespace galery;

/// <summary>
/// Наименование выставки
/// </summary>
public class Exhibition
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }

    public string Info { get; set; }

    public Exhibition() { }

    public Exhibition(int id, string name, DateTime date)
    {
        Id = id;
        Name = name;
        Date = date;
        Info = $"{Name} ({Date:dd.MM.yyyy})";
    }
}
