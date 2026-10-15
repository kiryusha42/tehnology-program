/// <summary>
/// Represents an industrial warehouse.
/// </summary>
public class Warehouse : Building
{
    private readonly string _typeName = "Warehouse";

    public double CeilingHeight { get; set; }

    public bool IsTall => CeilingHeight >= 10;

    public Warehouse(
        string cadastral,
        string address,
        double area,
        decimal price,
        double ceilingHeight)
        : base(cadastral, address, area, price)
    {
        CeilingHeight = ceilingHeight;
    }

    public override void Describe()
    {
        Console.WriteLine(
            $"[{_typeName}] {Address}, height={CeilingHeight}, " +
            $"purpose: {Purpose}");

        Console.WriteLine(
            $"  price per sqm: {PricePerSqm:F0}");

        Console.WriteLine("Warehouse described.");
    }

    public override string ToString()
    {
        return $"[{_typeName}] {Address}, " +
               $"height={CeilingHeight}, price={Price}";
    }
}