using System;
using System.Collections.Generic;

/// <summary>
/// Demonstrates inheritance and polymorphism.
/// </summary>
public class Program
{
    public static void Main()
    {
        List<Building> buildings = new List<Building>
        {
            new Apartment(
                "CAD001",
                "Lenina 5",
                80,
                10_000_000m,
                12)
            {
                Purpose = BuildingPurpose.Residential
            },

            new Office(
                "CAD002",
                "Business Center 10",
                200,
                25_000_000m,
                60)
            {
                Purpose = BuildingPurpose.Office
            },

            new Warehouse(
                "CAD003",
                "Prom 1",
                500,
                12_500_000m,
                12)
            {
                Purpose = BuildingPurpose.Industrial
            }
        };

        foreach (Building building in buildings)
        {
            Console.WriteLine(building);
            building.Describe();

            Console.WriteLine(
                $"Cadastral number: {building.CadastralNumber}");

            if (building is IRentable rentable)
            {
                Console.WriteLine(
                    $"Monthly rent: {rentable.GetMonthlyRent():F0}.");
            }
            else
            {
                Console.WriteLine("Building cannot be rented.");
            }

            if (building is Apartment apartment)
            {
                Console.WriteLine(
                    $"Penthouse: {apartment.IsPenthouse}");
            }
            else if (building is Office office)
            {
                Console.WriteLine(
                    $"Big office: {office.IsBigOffice}");
            }
            else if (building is Warehouse warehouse)
            {
                Console.WriteLine(
                    $"Tall warehouse: {warehouse.IsTall}");
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}