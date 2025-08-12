using System.Text.Json;
using single_rune_web.Shared.Models;

namespace single_rune_web.Shared.Services
{
    public class RuneService
    {
        private readonly List<Rune> _runes;

        public RuneService(IWebHostEnvironment env)
        {
            var jsonPath = Path.Combine(env.WebRootPath, "data", "runes.json");
            if (File.Exists(jsonPath))
            {
                var json = File.ReadAllText(jsonPath);
                _runes = JsonSerializer.Deserialize<List<Rune>>(json) ?? new List<Rune>();
            }
            else
            {
                _runes = new List<Rune>();
            }
        }

        public Rune? GetRandomRune(bool includeInverted = true)
        {
            var filtered = includeInverted ? _runes : _runes.Where(r => r.HasInverted).ToList();
            if (filtered.Count == 0) return null;
            return filtered[new Random().Next(filtered.Count)];
        }

        public List<Rune> GetAllRunes() => _runes;
    }
}
