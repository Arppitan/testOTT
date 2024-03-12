using System;
using System.Collections.Generic;
using System.Text;

interface IShowService
{
    List<Show> GetAllShows();
}


class ShowService : IShowService
{
    private static readonly string[] ShowTitleWords =
{
    "The", "Amazing", "Fantastic", "Epic", "Universe", "Mystery", "Adventures", "Journey", "Legends", "Incredible",
    "Beyond", "Chronicles", "Discovery", "Secrets", "Quest", "Quest for", "Lost", "Eternal", "Endless", "Legacy",
    "Last", "Origin", "Rise", "Fall", "Vanishing", "Enigma", "Sacred", "Frozen", "Fire", "Spirit", "Whisper",
    "Ancient", "Echoes", "Silent", "Broken", "Hidden", "Ethereal", "Infinite", "Harmony", "Reflections", "Jungle",
    "Wild", "Whispers", "Serenity", "Celestial", "Eclipse", "Illusion", "Tranquility", "Paradise", "Fantasy", "Wonder",
    "Ghosts", "Phantom", "Pandora's Box", "Emerald", "Sapphire", "Crimson", "Obsidian", "Lost City", "Mirror", "Mirage",
    "Sunset", "Horizon", "Twilight", "Moonlight", "Starlight", "Aurora", "Galaxy", "Cosmic", "Parallel", "Quantum",
    "Abyss", "Symphony", "Velocity", "Timeless", "Nebula", "Whirlwind", "Cascade", "Legacy", "Infinity", "Elemental",
    "Celestial", "Whispering", "Enchanted", "Labyrinth", "Quest", "Fading", "Spectral", "Phenomenon", "Endless", "Oblivion",
    "Evanescent", "Serendipity", "Cynosure", "Ephemeral", "Synchronicity", "Halcyon", "Gossamer", "Vivid", "Mystical", "Cacophony",
    "Vortex", "Nebulous", "Orbit", "Luminous", "Ecliptic", "Paragon", "Vivid", "Zenith", "Velvet", "Sonorous",
    "Abyssal", "Melodic", "Ephemeral", "Ineffable", "Quasar", "Pinnacle", "Ethereal", "Lustrous", "Pulsar", "Utopia",
    // ... add more words as needed
};

    private static readonly Random random = new Random();

    public List<Show> GetAllShows()
    {
        List<Show> shows = GenerateShows();
        return shows;
    }

    private List<Show> GenerateShows()
    {
        List<Show> generatedShows = new List<Show>();

        for (int i = 1; i <= 50; i++)
        {
            string title = GenerateShowTitle(i);
            int publishedYear = 2022 - i;
            string genre = GetRandomGenre();
            double ratings = 4.0 + (i % 2);

            generatedShows.Add(new Show
            {
                Title = title,
                PublishedYear = publishedYear,
                Genre = genre,
                Ratings = ratings
            });
        }

        return generatedShows;
    }

    private string GenerateShowTitle(int index)
    {
        int numberOfWords = random.Next(1, 4); // Randomly choose 1 to 3 words for the title
        StringBuilder titleBuilder = new StringBuilder();

        titleBuilder.Append($"{index}. "); // Add index at the beginning

        for (int i = 0; i < numberOfWords; i++)
        {
            int wordIndex = random.Next(ShowTitleWords.Length);
            string word = ShowTitleWords[wordIndex];

            if (i > 0)
            {
                titleBuilder.Append(" "); // Add space between words
            }

            titleBuilder.Append(word);
        }

        return titleBuilder.ToString();
    }

    private string GetRandomGenre()
    {
        string[] genres = { "Action", "Drama", "Comedy", "Thriller", "Sci-Fi" };
        int index = random.Next(genres.Length);
        return genres[index];
    }
}
