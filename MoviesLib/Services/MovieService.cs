using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesLib.Entities;
using TextFiles;
using System.Data.OleDb;


namespace MoviesLib.Services
{
    public class MovieService
    {

        public static List<Movie> filmLijst;
        string bestandsPad = AppDomain.CurrentDomain.BaseDirectory + "MovieDB01.accdb";
        OleDbConnection dbConn;
        OleDbCommand sqlCommand;


        public MovieService()
        {
            dbConn = new OleDbConnection();
            dbConn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + bestandsPad;
        }

        public bool ImporteerSorteerFilms(string syntaxSQL)
        {
            bool gelukt = false;
            OleDbDataReader dbRead = null;
            string sqlOpdracht = syntaxSQL;
            try
            {
                dbConn.Open();
                sqlCommand = new OleDbCommand(sqlOpdracht, dbConn);
                dbRead = sqlCommand.ExecuteReader();
                while (dbRead.Read())
                {
                    int _id = dbRead.GetInt16(0);
                    string _title = dbRead.GetString(1).ToString();
                    int _year = dbRead.GetInt16(2);
                    int _runTime = dbRead.GetInt16(3);
                    string _genre = dbRead.GetString(4).ToString();
                    string _director = dbRead.GetString(5).ToString();
                    string _actor = dbRead.GetString(6).ToString();
                    string _description = dbRead.GetString(7).ToString();
                    string _awards = dbRead.GetString(8).ToString();
                    string _coverURL = dbRead.GetString(9).ToString();
                    int _metaScore = dbRead.GetInt16(10);
                    double _imdbRating = dbRead.GetDouble(11);
                    string _imdbID = dbRead.GetString(12).ToString();
                    string _url = dbRead.GetString(13).ToString();
                    bool _watched = dbRead.GetBoolean(14);
                    bool _favorite = dbRead.GetBoolean(15);


                    Movie film = new Movie
                    {
                        id = (int)_id,
                        title = _title,
                        year = _year,
                        runTime = _runTime,
                        genre = _genre,
                        director = _director,
                        actor = _actor,
                        description = _description,
                        awards = _awards,
                        coverURL = _coverURL,
                        metaScore = _metaScore,
                        imdbRating = (float)_imdbRating,
                        imdbId = _imdbID,
                        url = _url,
                        watched = _watched,
                        favorite = _favorite

                    };

                    filmLijst.Add(film);

                }
                gelukt = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                if (dbRead != null)
                {
                    dbRead.Close();
                }
                if (dbConn != null)
                {
                    dbConn.Close();
                }
            }
            return gelukt;
        }

        public static int VolgendID()
        {
            int newID = 0;
            if (filmLijst == null)
            {
                filmLijst = new List<Movie>();
            }
            else
            {
                foreach (Movie _film in filmLijst)
                {
                    int huidigId = _film.id;
                    if (huidigId > newID)
                    {
                        newID = huidigId;
                    }
                }
                newID++;
            }
            return newID;
        }




        //public void ImporteerItems()
        //{
        //    List<Movie> films = new List<Movie>();

        //    ReadService readService = new ReadService();
        //    string bestandsPad = AppDomain.CurrentDomain.BaseDirectory + "Movies.csv";
        //    //string bestandsPad = readService.OpenBestand("Comma seperated values (.csv)|*.csv|Text documents (.txt)|*.txt");
        //    List<string[]> _movieArray = readService.ToStringArray_List(bestandsPad, ';');

        //    foreach (string[] _movieInfo in _movieArray)
        //    {
        //        Movie film = new Movie();

        //        film.id = int.Parse(_movieInfo[0]);
        //        film.title = _movieInfo[1];
        //        film.year = int.Parse(_movieInfo[2]);
        //        film.runTime = int.Parse(_movieInfo[3]);
        //        film.genre = _movieInfo[4];
        //        film.director = _movieInfo[5];
        //        film.actor = _movieInfo[6];
        //        film.description = _movieInfo[7];
        //        film.awards = _movieInfo[8];
        //        film.coverURL = _movieInfo[9];
        //        film.metaScore = int.Parse(_movieInfo[10]);
        //        film.imdbRating = float.Parse(_movieInfo[11]);
        //        film.imdbId = _movieInfo[12];
        //        film.url = _movieInfo[13];




        //        films.Add(film);


        //    }

        //    filmLijst = films;
        //} 


    }
}
