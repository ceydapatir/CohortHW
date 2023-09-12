using CohortHomework1;

internal class Program
{
    private static void Main(string[] args)
    {
        Music music1 = new Music("Kara Sevda", "Turkish Rock", "Cem Karaca", 1998);
        music1.GetMusicInfo();
        Music music2 = new Music("Skyfall", "Pop Soul", "Adele", 2014);
        music2.GetMusicInfo();
    }
}