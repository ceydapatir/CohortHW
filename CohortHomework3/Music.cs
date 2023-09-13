using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CohortHomework3
{
    public class Music
    {
        private static int? num;
        private string? name;
        private string? genre;
        private string? owner;
        private static int? year;

        public string? Name { get => name; set => name = value; }
        public string? Genre { get => genre; set => genre = value; }
        public string? Owner { get => owner; set => owner = value; }
        public static int? Year { get => year; }
        public static int? Num { get => num;}

        static Music(){
            Console.WriteLine("... 90's ...");
            year = 1990;
            num = 0;
        }
        public Music(string name, string genre, string owner){
            this.Name = name;
            this.Genre = genre;
            this.Owner = owner;
            num++;
        }

        public void GetMusics(){
            
        }
        public void GetMusicInfo(){
            Console.WriteLine("Music " + Num);
            Console.WriteLine("Owner: " + Owner);
            Console.WriteLine("Music Name: " + Name);
            Console.WriteLine("Music Genre: " + Genre);
            Console.WriteLine("Period of Publication: " + Year + "'s");
            Console.WriteLine("*******************************");
        }

        public void ChangeName(string name){
            this.Name = name;
        }
    }
}