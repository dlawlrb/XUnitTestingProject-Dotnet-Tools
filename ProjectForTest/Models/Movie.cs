using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectForTest.Models
{
    public class Movie
    {
        public string Title { get; }
        public string Release { get; }
        public string[] Genres { get; }
        public string Duration { get; }

        public Movie(string title, string release, string[] genres, string duration)
        {
            Title = title;
            Release = release;
            Genres = genres;
            Duration = duration;
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Movie target)
            {
                return this.Title == target.Title;
            }

            return false;
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
