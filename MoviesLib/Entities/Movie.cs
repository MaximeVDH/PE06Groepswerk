using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesLib.Services;

namespace MoviesLib.Entities
{
    public class Movie
    {
        public int id;
        public string title;
        public int year;
        public int runTime;
        public string genre;
        public string director;
        public string actor;
        public string description;
        public string awards;
        public string coverURL;
        public int metaScore;
        public float imdbRating;
        public string imdbId;
        public string url;
        public bool watched;
        public bool favorite;

        public Movie()
        {
            id = MovieService.VolgendID();
        }

        public Movie(string _movieName): this()
        {
            title = _movieName;
        }

        public override string ToString()
        {
            string shortInfo = "";
            shortInfo = $"{title} ({year})";
            return shortInfo;
        }


    }




}

