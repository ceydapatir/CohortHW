using CohortHomework3;

internal class Program
{
    private static void Main(string[] args)
    {
        Music music1 = new Music("Kara Sevda", "Turkish Rock", "Cem Karaca");
        music1.GetMusicInfo();
        Music music2 = new Music("Dönence", "Turkish Rock", "Barış Manço");
        music2.GetMusicInfo();
        
    }
}