using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CohortHomework1
{
    public class Music
    {
        public string name;
        public string genre;
        public string owner;
        public int year;

        public Music(string name, string genre, string owner, int year){
            this.name = name;
            this.genre = genre;
            this.owner = owner;
            this.year = year;
        }

        public void GetMusicInfo(){
            Console.WriteLine("Owner: " + owner);
            Console.WriteLine("Music Name: " + name);
            Console.WriteLine("Music Genre: " + genre);
            Console.WriteLine("Year of Publication: " + year);
            Console.WriteLine("*******************************");
        }
    }
}