/// <summary>
/// Represents an office building.
/// </summary>
public class Office : Building, IRentable
{
    private readonly string _typeName = "Office";

    public int Workplaces { get; set; }

    public bool IsBigOffice => Workplaces >= 50;

    public Office(
        string cadastral,
        string address,
        double area,
        decimal price,
        int workplaces)
        : base(cadastral, address, area, price)
    {
        Workplaces = workplaces;
    }

    public decimal GetMonthlyRent()
    {
        return Price * 0.008m;
    }

    public override void Describe()
    {
        Console.WriteLine(
            $"[{_typeName}] {Address}, area={Area}, " +
            $"purpose: {Purpose}");

        Console.WriteLine(
            $"  price per sqm: {PricePerSqm:F0}");

        Console.WriteLine("Office described.");
    }

    public override string ToString()
    {
        return $"[{_typeName}] {Address}, " +
               $"workplaces={Workplaces}, price={Price}";
    }
}