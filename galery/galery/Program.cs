using System;
using System.Collections.Generic;
using System.IO;

namespace galery;

/// <summary>
/// Главная программа: выбор источника данных и вызов аналитических методов
/// </summary>
/// 
class Program
{
    static void Main()
    {



        Console.WriteLine("Выберите источник данных:");
        Console.WriteLine("1 — InMemoryRepository");
        Console.WriteLine("2 — CsvRepository");
        Console.Write("Ваш выбор: ");

        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
        {
            Console.WriteLine("Неверный ввод. Завершение работы. ");
            return;
        }

        List<Exhibition> exhibitions;
        List<Artist> artists;
        List<Painting> paintings;

        try
        {
            switch (choice)
            {
                case 1:
                    InMemoryRepository memRepo = new InMemoryRepository();
                    exhibitions = memRepo.GetExhibitions();
                    artists = memRepo.GetArtists();
                    paintings = memRepo.GetPaintings();
                    break;

                case 2:
                    string csvPath = Path.Combine(AppContext.BaseDirectory, "data");

                    if (!Directory.Exists(csvPath))
                    {
                        Console.WriteLine($"Ошибка: Папка '{csvPath}' не найдена.");
                        Console.WriteLine("Создайте папку 'data' рядом с exe-файлом и добавьте туда CSV-файлы.");
                        return;
                    }

                    CsvRepository csvRepo = new CsvRepository(csvPath);
                    exhibitions = csvRepo.GetExhibitions();
                    artists = csvRepo.GetArtists();
                    paintings = csvRepo.GetPaintings();
                    break;

                default:
                    Console.WriteLine("Неверный выбор");
                    return;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка при чтении данных: {ex.Message}");
            return;
        }

        Console.WriteLine("\n--- Результаты работы программы ---\n");

        string targetPaintingTitle = "Подсолнухи";
        Console.WriteLine($"1. FindArtist(\"Подсолнухи\") \"{targetPaintingTitle}\":");
        Artist artistOfPainting = FindArtistByPaintingTitle(targetPaintingTitle, paintings, artists);
        if (artistOfPainting != null)
            Console.WriteLine("   " + artistOfPainting.GetInfo());
        else
            Console.WriteLine("   null");

        Console.WriteLine($"\n2. FindExhibition(painting \"Подсолнухи\") \"{targetPaintingTitle}\":");
        Exhibition exhibitionOfPainting = FindExhibitionByPaintingTitle(targetPaintingTitle, paintings, exhibitions);
        if (exhibitionOfPainting != null)
            Console.WriteLine("   " + exhibitionOfPainting.Info);
        else
            Console.WriteLine("   null");

        Console.WriteLine("\n3. GetTotalPrice:");
        int totalValue = GetTotalPaintingsValue(paintings);
        Console.WriteLine("   " + totalValue + " руб.");

        Console.WriteLine("\n4. GetArtistWithMostPaintings:");
        (Artist artist, int count) = GetArtistWithMaxPaintings(paintings, artists);
        if (artist != null)
            Console.WriteLine($"   {artist.FullName} ({count})"); 
        else
            Console.WriteLine("   null");

        Console.WriteLine("\n5. PrintAllPaintings:");
        PrintAllPaintings(paintings, artists, exhibitions);



        Artist aArtist = FindArtistByPaintingTitle(targetPaintingTitle, paintings, artists); 
        if (aArtist == null)
        { 
            Console.WriteLine($" FindArtist(\"{targetPaintingTitle}\") → null");
        }
        else 
        { 
            Console.WriteLine("Не найдено: FindArtist(\"Неизвестная картина\") => null"); 
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();

       
    }

    static Artist FindArtistByPaintingTitle(string title, List<Painting> paintings, List<Artist> artists)
    {
        Painting p = paintings.FirstOrDefault(x => x.Title == title);
        if (p == null) return null;

        return artists.FirstOrDefault(x => x.Id == p.ArtistId);
    }

    static Exhibition FindExhibitionByPaintingTitle(string title, List<Painting> paintings, List<Exhibition> exhibitions)
    {
        Painting p = paintings.FirstOrDefault(x => x.Title == title);
        if (p == null) return null;

        return exhibitions.FirstOrDefault(x => x.Id == p.ExhibitionId);
    }


    static int GetTotalPaintingsValue(List<Painting> paintings)
    {
        if (paintings == null || paintings.Count == 0) return 0;

        int sum = 0;
        foreach (var p in paintings)
        {
            sum += p.Price;
        }
        return sum;
    }


    public static (Artist Artist, int Count) GetArtistWithMaxPaintings( List<Painting> paintings, List<Artist> artists)
    {
        if (paintings == null || paintings.Count == 0 || artists == null)
            return (null, 0);

        var counts = new Dictionary<int, int>();

        foreach (var p in paintings)
        {
            counts.TryAdd(p.ArtistId, 0);
            counts[p.ArtistId]++;
        }

        if (counts.Count == 0)
            return (null, 0);

        int maxCount = 0;
        int bestArtistId = -1; 

        foreach (var kvp in counts)
        {
            if (kvp.Value > maxCount)
            {
                maxCount = kvp.Value;
                bestArtistId = kvp.Key;
            }
        }

        Artist mostProductiveArtist = null;
        for (int i = 0; i < artists.Count; i++)
        {
            if (artists[i].Id == bestArtistId)
            {
                mostProductiveArtist = artists[i];
                break;
            }
        }

        return (mostProductiveArtist, maxCount);
    }


    static void PrintAllPaintings(List<Painting> paintings, List<Artist> artists, List<Exhibition> exhibitions)
    {
        foreach (var p in paintings)
        {
            string artistName = "—";
            var artist = artists.FirstOrDefault(x => x.Id == p.ArtistId);
            if (artist != null) artistName = artist.FullName;

            string exhibitionName = "—";
            var exhibition = exhibitions.FirstOrDefault(x => x.Id == p.ExhibitionId);
            if (exhibition != null) exhibitionName = exhibition.Name;

            Console.WriteLine($"   \"{p.GetInfo()}\" — художник {artistName}, выставка \"{exhibitionName}\"");
        }
    }
}
