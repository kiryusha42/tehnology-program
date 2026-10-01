using System.Collections.Generic;

namespace galery;

/// <summary>
/// Репозиторий с тестовыми данными в памяти
/// </summary>
public class InMemoryRepository
{
    private List<Exhibition> _exhibitions;
    private List<Artist> _artists;
    private List<Painting> _paintings;

    public InMemoryRepository()
    {
        _exhibitions = new List<Exhibition>
        {
            new Exhibition
            {
                Id = 1,
                Name = "Постимпрессионизм",
                Date = new DateTime(2025, 9, 1),
                Info = "Постимпрессионизм (01.09.2025)" 
            },
            new Exhibition
            {
                Id = 2,
                Name = "Экспрессионизм",
                Date = new DateTime(2025, 10, 15),
                Info = "Экспрессионизм (15.10.2025)"
            }
        };

        _artists = new List<Artist>
        {
            new Artist
            {
                Id = 1,
                FullName = "Ван Гог",
                Country = "Нидерланды",
                Style = "постимпрессионизм"
            },
            new Artist
            {
                Id = 2,
                FullName = "Эдвард Мунк",
                Country = "Норвегия",
                Style = "экспрессионизм"
            },
            new Artist
            {
                Id = 3,
                FullName = "Поль Гоген",
                Country = "Франция",
                Style = "постимпрессионизм"
            }
        };

        _paintings = new List<Painting>
        {
            new Painting
            {
                Id = 1,
                Title = "Подсолнухи",
                ExhibitionId = 1,
                ArtistId = 1,
                Year = 1888,
                Price = 5000000
            },
            new Painting
            {
                Id = 2,
                Title = "Звездная ночь",
                ExhibitionId = 1,
                ArtistId = 1,
                Year = 1889,
                Price = 8000000
            },
            new Painting
            {
                Id = 3,
                Title = "Ирисы",
                ExhibitionId = 1,
                ArtistId = 1,
                Year = 1889,
                Price = 6000000
            },
            
            new Painting
            {
                Id = 4,
                Title = "Крик",
                ExhibitionId = 2,
                ArtistId = 2,
                Year = 1893,
                Price = 12000000
            },
            new Painting
            {
                Id = 5,
                Title = "Мадонна",
                ExhibitionId = 2,
                ArtistId = 2,
                Year = 1894,
                Price = 9000000
            },

            new Painting
            {
                Id = 6,
                Title = "Откуда мы пришли? Кто мы? Куда мы идем?",
                ExhibitionId = 1,
                ArtistId = 3,
                Year = 1898,
                Price = 15000000
            }
        };
    }

    public List<Exhibition> GetExhibitions() { return _exhibitions; }
    public List<Artist> GetArtists() { return _artists; }
    public List<Painting> GetPaintings() { return _paintings; }
}
