/// <summary>
/// Represents a residential apartment.
/// </summary>
public class Apartment : Building, IRentable
{
    private readonly string _typeName = "Apartment";

    public int Floor { get; set; }

    public bool IsPenthouse => Floor >= 10;

    public Apartment(
        string cadastral,
        string address,
        double area,
        decimal price,
        int floor)
        : base(cadastral, address, area, price)
    {
        Floor = floor;
    }

    public decimal GetMonthlyRent()
    {
        return Price * 0.003m;
    }

    public override void Describe()
    {
        Console.WriteLine(
            $"[{_typeName}] {Address}, area={Area}, " +
            $"purpose: {Purpose}");

        Console.WriteLine(
            $"  price per sqm: {PricePerSqm:F0}");

        Console.WriteLine("Apartment described.");
    }

    public override string ToString()
    {
        return $"[{_typeName}] {Address}, area={Area}, " +
               $"floor={Floor}, price={Price}";
    }
}