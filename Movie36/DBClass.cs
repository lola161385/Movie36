﻿using Oracle.DataAccess.Client;
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

        // 영화 목록에서 포스터 클릭시 ChangeMovie 폼으로 id를 넘겨받아 db에서 정보를 가져오는 함수
        public Movie GetMovieById(int movieId)
        {
            Movie movie = null;
            string connectionString = GetConnectionString();

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MOVIE_ID, MOVIE_NAME, MOVIE_TYPE, MOVIE_PRODUCER, MOVIE_PERFORMER, " +
                               "MOVIE_RATING, MOVIE_RELEASEDATE, MOVIE_OVERVIEW, MOVIE_POSTER FROM MOVIE WHERE MOVIE_ID = :movieId";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(":movieId", OracleDbType.Int32).Value = movieId;

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            movie = new Movie
                            {
                                MovieId = Convert.ToInt32(reader["MOVIE_ID"]),
                                MovieName = reader["MOVIE_NAME"].ToString(),
                                MovieType = reader["MOVIE_TYPE"].ToString(),
                                MovieProducer = reader["MOVIE_PRODUCER"].ToString(),
                                MoviePerformer = reader["MOVIE_PERFORMER"].ToString(),
                                MovieRating = reader["MOVIE_RATING"].ToString(),
                                ReleaseDate = Convert.ToDateTime(reader["MOVIE_RELEASEDATE"]),
                                MovieOverview = reader["MOVIE_OVERVIEW"].ToString(),
                                MoviePoster = reader["MOVIE_POSTER"].ToString()
                            };
                        }
                    }
                }
            }
            return movie;
        }

        // 영화목록을 받아오는 함수 id, 이름 , 포스터 만 받아옴
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

        // 영화 포스터 클릭 후 수정 버튼 클릭시 수정 하는 함수
        public bool UpdateMovie(Movie movie)
        {
            try
            {
                string connectionString = GetConnectionString();
                string query = @"UPDATE MOVIE SET 
                            MOVIE_NAME = :name,
                            MOVIE_TYPE = :type,
                            MOVIE_PRODUCER = :producer,
                            MOVIE_PERFORMER = :performer,
                            MOVIE_RATING = :rating,
                            MOVIE_RELEASEDATE = :releaseDate,
                            MOVIE_OVERVIEW = :overview,
                            MOVIE_POSTER = :poster
                         WHERE MOVIE_ID = :id";

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        // 매개변수 바인딩
                        command.Parameters.Add(":name", OracleDbType.Varchar2).Value = movie.MovieName ?? (object)DBNull.Value;
                        command.Parameters.Add(":type", OracleDbType.Varchar2).Value = movie.MovieType ?? (object)DBNull.Value;
                        command.Parameters.Add(":producer", OracleDbType.Varchar2).Value = movie.MovieProducer ?? (object)DBNull.Value;
                        command.Parameters.Add(":performer", OracleDbType.Varchar2).Value = movie.MoviePerformer ?? (object)DBNull.Value;
                        command.Parameters.Add(":rating", OracleDbType.Varchar2).Value = movie.MovieRating ?? (object)DBNull.Value;
                        command.Parameters.Add(":releaseDate", OracleDbType.Date).Value = movie.ReleaseDate;
                        command.Parameters.Add(":overview", OracleDbType.Varchar2).Value = movie.MovieOverview ?? (object)DBNull.Value;
                        command.Parameters.Add(":poster", OracleDbType.Varchar2).Value = movie.MoviePoster ?? (object)DBNull.Value;
                        command.Parameters.Add(":id", OracleDbType.Int32).Value = movie.MovieId;

                        // 쿼리 실행
                        int rowsUpdated = command.ExecuteNonQuery();
                        return rowsUpdated > 0; // 수정 성공 여부 반환
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating movie: {ex.Message}");
                return false;
            }
        }
        
        // 영화등록 함수
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
        public int MovieId { get; set; } // 영화 ID
        public string MovieName { get; set; } // 영화 제목
        public string MovieType { get; set; } // 영화 장르
        public string MoviePoster { get; set; } // 영화 포스터
        public string MoviePerformer { get; set; } // 배우
        public string MovieRating { get; set; } // 영화 등급
        public DateTime ReleaseDate { get; set; } // 개봉일
        public string MovieOverview { get; set; } // 줄거리
        public string MovieProducer { get; set; } // 감독
    }
}
