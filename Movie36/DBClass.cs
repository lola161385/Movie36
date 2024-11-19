using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace Movie36
{
    public class DBClass
    {
        private int selectedRowIndex;
        private int selectedKeyValue;
        OracleDataAdapter dBAdapter;
        DataSet dS;
        OracleCommandBuilder myCommandBuilder;
        DataTable movieTable;
        public int SelectedRowIndex { get { return selectedRowIndex; } set { selectedRowIndex = value; } }
        public int SelectedKeyValue { get { return selectedKeyValue; } set { selectedKeyValue = value; } }
        public OracleDataAdapter DBAdapter { get { return dBAdapter; } set { dBAdapter = value; } }
        public DataSet DS { get { return dS; } set { dS = value; } }
        public OracleCommandBuilder MyCommandBuilder { get { return myCommandBuilder; } set { myCommandBuilder = value; } }
        public DataTable MovieTable { get { return MovieTable; } set { MovieTable = value; } }

        public void DB_Open()
        {
            try
            {
                string connectionString = "User Id=park1; Password=1234; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1522)) (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                string commandString = "select * from MOVIE";
                DBAdapter = new OracleDataAdapter(commandString, connectionString);
                MyCommandBuilder = new OracleCommandBuilder(DBAdapter);
                DS = new DataSet();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }
        public void DB_ObjCreate()
        {
            MovieTable = new DataTable();
        }

        public bool InsertMovie(int movieId, string movieName, string movieRating, string movieType,
                        string movieProducer, string moviePerformer, DateTime movieReleaseDate,
                        string movieOverview, string moviePoster, string movieStatus)
        {
            try
            {
                // DB 연결 문자열 db
                string connectionString = "User Id=park1; Password=1234; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1522)) (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) );";

                // INSERT SQL 문
                string insertQuery = @"INSERT INTO MOVIE (movie_id, movie_name, movie_rating, movie_type, movie_producer, 
                                      movie_performer, movie_releaseDate, movie_overview, movie_poster, movie_status)
                                      VALUES (:movie_id, :movie_name, :movie_rating, :movie_type, :movie_producer, 
                                      :movie_performer, :movie_releaseDate, :movie_overview, :movie_poster, :movie_status)";

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand(insertQuery, connection))
                    {
                        // 파라미터 설정
                        command.Parameters.Add(":movie_id", OracleDbType.Int32).Value = movieId;
                        command.Parameters.Add(":movie_name", OracleDbType.Varchar2).Value = movieName;
                        command.Parameters.Add(":movie_rating", OracleDbType.Varchar2).Value = movieRating;
                        command.Parameters.Add(":movie_type", OracleDbType.Varchar2).Value = movieType;
                        command.Parameters.Add(":movie_producer", OracleDbType.Varchar2).Value = movieProducer;
                        command.Parameters.Add(":movie_performer", OracleDbType.Varchar2).Value = moviePerformer;
                        command.Parameters.Add(":movie_releaseDate", OracleDbType.Date).Value = movieReleaseDate;
                        command.Parameters.Add(":movie_overview", OracleDbType.Varchar2).Value = movieOverview;
                        command.Parameters.Add(":movie_poster", OracleDbType.Varchar2).Value = moviePoster;
                        command.Parameters.Add(":movie_status", OracleDbType.Varchar2).Value = movieStatus;

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
}
