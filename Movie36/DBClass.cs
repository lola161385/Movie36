using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace Movie36
{
    public class DBClass
    {
        private DataTable movieTable;
        public DataTable MovieTable
        {
            get { return movieTable; }
            set { movieTable = value; }
        }

        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["OracleDBConnection"].ConnectionString;
        }

        public List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();
            string connectionString = GetConnectionString();

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MOVIE_ID, MOVIE_NAME, MOVIE_POSTER FROM MOVIE";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            movies.Add(new Movie
                            {
                                // MOVIE_ID: NUMBER -> Int32로 변환
                                MovieId = reader.IsDBNull(0) ? 0 : Convert.ToInt32(reader.GetDecimal(0)),

                                // MOVIE_NAME: VARCHAR2 -> 문자열로 읽음
                                MovieName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),

                                // MOVIE_POSTER: VARCHAR2 -> 문자열로 읽음
                                MoviePoster = reader.IsDBNull(2) ? string.Empty : reader.GetString(2)
                            });
                        }
                    }
                }
            }
            return movies;
        }


        public bool InsertMovie(int movieId, string movieName, string movieRating, string movieType,
                        string movieProducer, string moviePerformer, DateTime movieReleaseDate,
                        string movieOverview, string moviePoster, string movieStatus)
        {
            try
            {
                string connectionString = GetConnectionString();
                string insertQuery = @"INSERT INTO MOVIE (
                                  MOVIE_ID, MOVIE_NAME, MOVIE_RATING, MOVIE_TYPE,
                                  MOVIE_PRODUCER, MOVIE_PERFORMER, MOVIE_RELEASEDATE,
                                  MOVIE_OVERVIEW, MOVIE_POSTER, MOVIE_STATUS
                              ) VALUES (
                                  :movie_id, :movie_name, :movie_rating, :movie_type,
                                  :movie_producer, :movie_performer, :movie_releaseDate,
                                  :movie_overview, :movie_poster, :movie_status
                              )";

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand(insertQuery, connection))
                    {
                        // NUMBER 타입 파라미터
                        command.Parameters.Add(":movie_id", OracleDbType.Int32).Value = movieId;

                        // VARCHAR2 타입 파라미터
                        command.Parameters.Add(":movie_name", OracleDbType.Varchar2).Value = movieName ?? (object)DBNull.Value;
                        command.Parameters.Add(":movie_rating", OracleDbType.Varchar2).Value = movieRating ?? (object)DBNull.Value;
                        command.Parameters.Add(":movie_type", OracleDbType.Varchar2).Value = movieType ?? (object)DBNull.Value;
                        command.Parameters.Add(":movie_producer", OracleDbType.Varchar2).Value = movieProducer ?? (object)DBNull.Value;
                        command.Parameters.Add(":movie_performer", OracleDbType.Varchar2).Value = moviePerformer ?? (object)DBNull.Value;

                        // DATE 타입 파라미터
                        command.Parameters.Add(":movie_releaseDate", OracleDbType.Date).Value = movieReleaseDate;

                        // VARCHAR2 (긴 텍스트)
                        command.Parameters.Add(":movie_overview", OracleDbType.Varchar2).Value = movieOverview ?? (object)DBNull.Value;
                        command.Parameters.Add(":movie_poster", OracleDbType.Varchar2).Value = moviePoster ?? (object)DBNull.Value;
                        command.Parameters.Add(":movie_status", OracleDbType.Varchar2).Value = movieStatus ?? (object)DBNull.Value;

                        // INSERT 실행
                        command.ExecuteNonQuery();
                        MessageBox.Show("Movie data has been inserted successfully.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting data: " + ex.Message);
                return false;
            }
        }
    }


        public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MoviePoster { get; set; }
    }
}
