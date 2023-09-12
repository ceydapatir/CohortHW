using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CohortHomework2
{
    public class Music
    {
        private string? name;
        private string? genre;
        private string? owner;
        private int? year;

        public string? Name { get => name; set => name = value; }
        public string? Genre { get => genre; set => genre = value; }
        public string? Owner { get => owner; set => owner = value; }
        public int? Year { get => year; 
            set {
                if(1500 > value){
                    Console.WriteLine("Geçerli bir tarih giriniz...");
                    year = 1500;
                }else{
                    year = value; 
                }
            }
        }
        
        public Music(){}
        public Music(string name, string genre, string owner, int year){
            this.Name = name;
            this.Genre = genre;
            this.Owner = owner;
            this.Year = year;
        }

        public void GetMusics(){
            
        }
        public void GetMusicInfo(){
            Console.WriteLine("Owner: " + Owner);
            Console.WriteLine("Music Name: " + Name);
            Console.WriteLine("Music Genre: " + Genre);
            Console.WriteLine("Year of Publication: " + Year);
            Console.WriteLine("*******************************");
        }

        public void ChangeName(string name){
            this.Name = name;
        }
    }
}