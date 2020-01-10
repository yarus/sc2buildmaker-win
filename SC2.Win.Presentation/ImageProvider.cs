namespace SC2.Win.Presentation
{
    public static class ImageProvider
    {
        private const string ImagesFolder = "Images//";

        public static string GetMatchupBackgroundImagePath()
        {
            return ImagesFolder + "MatchupIconBackground.png";
        }
    }
}