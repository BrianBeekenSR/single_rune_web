namespace single_rune_web.Shared.Models
{
    public class Rune
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string UprightMeaning { get; set; }
        public string? InvertedMeaning { get; set; }
        public bool HasInverted => !string.IsNullOrWhiteSpace(InvertedMeaning);
    }
}
