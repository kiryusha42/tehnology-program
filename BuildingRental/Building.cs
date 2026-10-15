/// <summary>
/// Represents a base building.
/// </summary>
public abstract class Building
{
    private string _cadastralNumber;

    public string Address { get; set; }
    public double Area { get; set; }
    public decimal Price { get; set; }

    public BuildingPurpose Purpose { get; set; }
        = BuildingPurpose.Residential;

    public string CadastralNumber => _cadastralNumber;

    public double PricePerSqm =>
        Area > 0 ? (double)(Price / (decimal)Area) : 0;
    /// <summary>
    /// Creates a building with all parameters.
    /// </summary>
    public Building(
        string cadastral,
        string address,
        double area,
        decimal price)
    {
        _cadastralNumber = cadastral;
        Address = address;
        Area = area;
        Price = price;
    }

    /// <summary>
    /// Creates a building with an address.
    /// </summary>
    public Building(string address)
        : this("N/A", address, 0, 0)
    {
    }

    /// <summary>
    /// Describes the building.
    /// </summary>
    public abstract void Describe();
}