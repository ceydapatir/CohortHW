using CohortHomework2;

internal class Program
{
    private static void Main(string[] args)
    {
        Music music1 = new Music("Kara Sevda", "Turkish Rock", "Cem Karaca", 1998);
        music1.GetMusicInfo();
        Music music2 = new Music("Skyfall", "Pop Soul", "Adele", 2014);
        music2.GetMusicInfo();

        Music music3 = new Music();
        music3.Name = "Yeter ki";
        music3.Owner = "Barış Akarsu";
        music3.Genre = "Turkish Rock";
        music3.Year = 1970;
        music3.GetMusicInfo();
        music3.ChangeName("Kimdir O?");
        music3.GetMusicInfo();
    }
}