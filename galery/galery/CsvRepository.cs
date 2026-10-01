using System;
using System.Collections.Generic;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace galery;

/// <summary>
/// Репозиторий, читающий данные из CSV-файлов
/// </summary>
public class CsvRepository
{
    private string _basePath;

    public CsvRepository(string basePath)
    {
        _basePath = basePath;
    }

    public List<Exhibition> GetExhibitions()
    {
        List<Exhibition> result = new List<Exhibition>();
        string[] lines = File.ReadAllLines(Path.Combine(_basePath, "exhibitions.csv"));

        if (lines.Length < 2) return result;

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            if (parts.Length < 3) continue;

            Exhibition e = new Exhibition();
            e.Id = int.Parse(parts[0]);
            e.Name = parts[1];

            e.Date = DateTime.ParseExact(parts[2], "dd.MM.yyyy", null);

            e.Info = $"{e.Name} ({e.Date:dd.MM.yyyy})";

            result.Add(e);
        }

        return result;
    }

    public List<Artist> GetArtists()
    {
        List<Artist> result = new List<Artist>();
        string[] lines = File.ReadAllLines(Path.Combine(_basePath, "artists.csv"));

        if (lines.Length < 2) return result;

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            if (parts.Length < 4) continue;

            Artist a = new Artist();
            a.Id = int.Parse(parts[0]);
            a.FullName = parts[1];
            a.Country = parts[2];
            a.Style = parts[3];

            result.Add(a);
        }

        return result;
    }

    public List<Painting> GetPaintings()
    {
        List<Painting> result = new List<Painting>();
        string[] lines = File.ReadAllLines(Path.Combine(_basePath, "paintings.csv"));

        if (lines.Length < 2) return result;

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            if (parts.Length < 6) continue;

            Painting p = new Painting();
            p.Id = int.Parse(parts[0]);
            p.Title = parts[1];
            p.ExhibitionId = int.Parse(parts[2]);
            p.ArtistId = int.Parse(parts[3]);
            p.Year = int.Parse(parts[4]);
            p.Price = int.Parse(parts[5]);

            result.Add(p);
        }

        return result;
    }
}
