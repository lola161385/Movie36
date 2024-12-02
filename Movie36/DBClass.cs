using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        public string GenerateMovieId()
        {
            string connectionString = GetConnectionString();
            string maxId = "M0"; // 기본값: 영화 ID가 없을 경우 M0

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MAX(MOVIE_ID) FROM MOVIE";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        maxId = result.ToString(); // 최대 ID 가져오기
                    }
                }
            }

            // 최대 ID에서 숫자 부분 추출 후 1 증가
            int nextIdNumber = int.Parse(maxId.Substring(1)) + 1;
            return $"M{nextIdNumber}";
        }

        // 영화 목록에서 포스터 클릭시 ChangeMovie 폼으로 id를 넘겨받아 db에서 정보를 가져오는 함수
        public Movie GetMovieById(string movieId)
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
                    cmd.Parameters.Add(":movieId", OracleDbType.Varchar2).Value = movieId;

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            movie = new Movie
                            {
                                MovieId = reader["MOVIE_ID"].ToString(),
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
        // 지정된 SCHEDULE_ID에 대해 예약된 좌석 수를 반환하는 함수
        public int GetBookedSeatsCount(string scheduleId)
        {
            string connectionString = GetConnectionString();
            int bookedSeatsCount = 0;

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT SUM(CUSTOMER_COUNT) FROM TICKET WHERE SCHEDULE_ID = :scheduleId";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(":scheduleId", OracleDbType.Varchar2).Value = scheduleId;
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        bookedSeatsCount = Convert.ToInt32(result);
                    }
                }
            }

            return bookedSeatsCount;
        }
        //티켓 날짜별 영화 검색 함수
        public List<Movie> GetMoviesByDate(DateTime selectedDate)
        {
            List<Movie> movies = new List<Movie>();
            string connectionString = GetConnectionString();

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT M.MOVIE_ID, M.MOVIE_NAME, M.MOVIE_POSTER, S.SHOW_TIME, S.SCHEDULE_ID
                    FROM MOVIE M
                    JOIN SCHEDULE S ON M.MOVIE_ID = S.MOVIE_ID
                    WHERE S.SCHEDULE_DATE = :selectedDate
                    ORDER BY S.SHOW_TIME";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(":selectedDate", OracleDbType.Date).Value = selectedDate;

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            movies.Add(new Movie
                            {
                                MovieId = reader["MOVIE_ID"].ToString(),
                                MovieName = reader["MOVIE_NAME"].ToString(),
                                MoviePoster = reader["MOVIE_POSTER"].ToString(),
                                ShowTime = reader["SHOW_TIME"].ToString(),
                                ScheduleId = reader["SCHEDULE_ID"].ToString()  // ScheduleId 추가
                            });
                        }
                    }
                }
            }
            return movies;
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
                                MovieId = reader["MOVIE_ID"].ToString(),
                                MovieName = reader["MOVIE_NAME"].ToString(),
                                MoviePoster = reader["MOVIE_POSTER"].ToString()
                            });
                        }
                    }
                }
            }
            return movies;
        }

        public List<Food> GetFoods() 
        {
            List<Food> foods = new List<Food>();
            string connectionString = GetConnectionString();

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT FOOD_ID, FOOD_NAME, FOOD_IMAGE, FOOD_PRICE, FOOD_TYPE FROM FOOD";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            foods.Add(new Food
                            {
                                foodID = reader["FOOD_ID"].ToString(),
                                foodName = reader["FOOD_NAME"].ToString(),
                                foodImage = reader["FOOD_IMAGE"].ToString(),
                                foodPrice = reader["FOOD_PRICE"].ToString(),
                                foodCategory = reader["FOOD_TYPE"].ToString()
                            });
                        }
                    }
                }
            }
            return foods;
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
                        command.Parameters.Add(":name", OracleDbType.Varchar2).Value = movie.MovieName ?? (object)DBNull.Value;
                        command.Parameters.Add(":type", OracleDbType.Varchar2).Value = movie.MovieType ?? (object)DBNull.Value;
                        command.Parameters.Add(":producer", OracleDbType.Varchar2).Value = movie.MovieProducer ?? (object)DBNull.Value;
                        command.Parameters.Add(":performer", OracleDbType.Varchar2).Value = movie.MoviePerformer ?? (object)DBNull.Value;
                        command.Parameters.Add(":rating", OracleDbType.Varchar2).Value = movie.MovieRating ?? (object)DBNull.Value;
                        command.Parameters.Add(":releaseDate", OracleDbType.Date).Value = movie.ReleaseDate;
                        command.Parameters.Add(":overview", OracleDbType.Varchar2).Value = movie.MovieOverview ?? (object)DBNull.Value;
                        command.Parameters.Add(":poster", OracleDbType.Varchar2).Value = movie.MoviePoster ?? (object)DBNull.Value;
                        command.Parameters.Add(":id", OracleDbType.Varchar2).Value = movie.MovieId;

                        int rowsUpdated = command.ExecuteNonQuery();
                        return rowsUpdated > 0;
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
        public bool InsertMovie(string movieName, string movieRating, string movieType,
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

                string movieId = GenerateMovieId(); // 새로운 영화 ID 생성

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand(insertQuery, connection))
                    {
                        command.Parameters.Add(":movie_id", OracleDbType.Varchar2).Value = movieId;
                        command.Parameters.Add(":movie_name", OracleDbType.Varchar2).Value = movieName ?? (object)DBNull.Value;
                        command.Parameters.Add(":movie_rating", OracleDbType.Varchar2).Value = movieRating ?? (object)DBNull.Value;
                        command.Parameters.Add(":movie_type", OracleDbType.Varchar2).Value = movieType ?? (object)DBNull.Value;
                        command.Parameters.Add(":movie_producer", OracleDbType.Varchar2).Value = movieProducer ?? (object)DBNull.Value;
                        command.Parameters.Add(":movie_performer", OracleDbType.Varchar2).Value = moviePerformer ?? (object)DBNull.Value;
                        command.Parameters.Add(":movie_releaseDate", OracleDbType.Date).Value = movieReleaseDate;
                        command.Parameters.Add(":movie_overview", OracleDbType.Varchar2).Value = movieOverview ?? (object)DBNull.Value;
                        command.Parameters.Add(":movie_poster", OracleDbType.Varchar2).Value = moviePoster ?? (object)DBNull.Value;
                        command.Parameters.Add(":movie_status", OracleDbType.Varchar2).Value = movieStatus ?? (object)DBNull.Value;

                        command.ExecuteNonQuery();
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

        //스캐쥴 등록시 영화이름 콤보박스 아이템 함수
        public DataTable GetMovieDataTableForComboBox()
        {
            string connectionString = GetConnectionString();
            DataTable movieTable = new DataTable();

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MOVIE_ID, MOVIE_NAME FROM MOVIE WHERE MOVIE_STATUS = 'Active'";

                using (OracleDataAdapter adapter = new OracleDataAdapter(query, conn))
                {
                    adapter.Fill(movieTable); // DataTable에 결과 저장
                }
            }

            return movieTable; // ComboBox에 바인딩할 DataTable 반환
        }
        //스캐쥴 등록시 상영관이름 콤보박스 아이템 함수
        public DataTable GetScreenDataTableForComboBox()
        {
            string connectionString = GetConnectionString();
            DataTable screenTable = new DataTable();

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT SCREEN_ID, SCREEN_NAME FROM SCREEN";

                using(OracleDataAdapter adapter = new OracleDataAdapter(query, conn))
                {
                    adapter.Fill(screenTable);
                }
            }
            return screenTable;
        }

        // 스캐쥴 등록시 중복 검사 시행 함수
        public bool IsScheduleExists(string scheduleDate, string showTime, string screenId)
        {
            string connectionString = GetConnectionString();
            bool exists = false;

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT COUNT(*) FROM SCHEDULE 
                         WHERE SCHEDULE_DATE = :scheduleDate 
                         AND SHOW_TIME = :showTime 
                         AND SCREEN_ID = :screenId";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(":scheduleDate", OracleDbType.Date).Value = DateTime.Parse(scheduleDate);
                    cmd.Parameters.Add(":showTime", OracleDbType.Varchar2).Value = showTime;
                    cmd.Parameters.Add(":screenId", OracleDbType.Varchar2).Value = screenId;

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    exists = count > 0; // 중복이 있다면 exists가 true로 설정
                }
            }

            return exists;
        }

        // 스캐쥴 sql 삽입 함수
        public bool InsertSchedule(string scheduleId, string scheduleDate, string showTime, string movieId, string screenId)
        {
            try
            {
                string connectionString = GetConnectionString();
                string insertQuery = @"INSERT INTO SCHEDULE (
                                  SCHEDULE_ID, SCHEDULE_DATE, SHOW_TIME, MOVIE_ID, SCREEN_ID
                              ) VALUES (
                                  :schedule_id, :schedule_date, :show_time, :movie_id, :screen_id
                              )";

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand(insertQuery, connection))
                    {
                        command.Parameters.Add(":schedule_id", OracleDbType.Varchar2).Value = scheduleId;
                        command.Parameters.Add(":schedule_date", OracleDbType.Date).Value = DateTime.Parse(scheduleDate);
                        command.Parameters.Add(":show_time", OracleDbType.Varchar2).Value = showTime;
                        command.Parameters.Add(":movie_id", OracleDbType.Varchar2).Value = movieId;
                        command.Parameters.Add(":screen_id", OracleDbType.Varchar2).Value = screenId;

                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting schedule: " + ex.Message);
                return false;
            }
        }

        // 등록된 스케줄을 가져오는 함수
        public DataTable GetSchedules()
        {
            string connectionString = GetConnectionString();
            DataTable scheduleTable = new DataTable();

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string query = @"
                SELECT SCHEDULE_ID, SCHEDULE_DATE, SHOW_TIME, MOVIE_ID, SCREEN_ID 
                FROM SCHEDULE
                ORDER BY SCHEDULE_DATE, SHOW_TIME, SCREEN_ID";

                using (OracleDataAdapter adapter = new OracleDataAdapter(query, conn))
                {
                    adapter.Fill(scheduleTable); // DataTable에 결과 저장
                }
            }

            return scheduleTable; // DataGridView에 바인딩할 DataTable 반환
        }

        // 스케줄 삭제 함수
        public bool DeleteSchedule(string scheduleId)
        {
            try
            {
                string connectionString = GetConnectionString();
                string deleteQuery = @"DELETE FROM SCHEDULE WHERE SCHEDULE_ID = :schedule_id";

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand(deleteQuery, connection))
                    {
                        command.Parameters.Add(":schedule_id", OracleDbType.Varchar2).Value = scheduleId;

                        int rowsDeleted = command.ExecuteNonQuery();
                        return rowsDeleted > 0; // 삭제된 행이 있으면 true 반환
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting schedule: " + ex.Message);
                return false;
            }
        }
        // DBClass 클래스 내에 추가할 메서드
        public string GetScreenNameByScheduleId(string scheduleId)
        {
            string screenName = "";
            string query = @"
                SELECT s.SCREEN_NAME
                FROM SCHEDULE sc
                JOIN SCREEN s ON sc.SCREEN_ID = s.SCREEN_ID
                WHERE sc.SCHEDULE_ID = :scheduleId";

            using (OracleConnection conn = new OracleConnection(GetConnectionString()))
            {
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(":scheduleId", OracleDbType.Varchar2).Value = scheduleId; // 파라미터 설정
                conn.Open();

                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    screenName = result.ToString();
                }
            }

            return screenName;
        }
        public List<string> GetReservedSeats(string scheduleId)
        {
            List<string> reservedSeats = new List<string>();
            string connectionString = GetConnectionString();

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT SELECT_SEATS FROM TICKET WHERE SCHEDULE_ID = :scheduleId";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(":scheduleId", OracleDbType.Varchar2).Value = scheduleId;

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string seats = reader["SELECT_SEATS"].ToString();
                            if (!string.IsNullOrEmpty(seats))
                            {
                                // 좌석 문자열을 ','로 분리하여 리스트에 추가
                                reservedSeats.AddRange(seats.Split(','));
                            }
                        }
                    }
                }
            }
            return reservedSeats;
        }

        public bool SaveTicket(string scheduleId, string customerName, string customerPhone, int customerCount, List<Button> selectedSeats)
        {
            string connectionString = GetConnectionString();
            string ticketId = "T" + DateTime.Now.ToString("yyyyMMddHHmmss");
            string selectSeats = string.Join(",", selectedSeats.Select(seat => seat.Name));

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                INSERT INTO TICKET (TICKET_ID, SCHEDULE_ID, CUSTOMER_NAME, CUSTOMER_PHONE, CUSTOMER_COUNT, SELECT_SEATS, PAYMENT)
                VALUES (:ticketId, :scheduleId, :customerName, :customerPhone, :customerCount, :selectSeats, :payment)";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(":ticketId", OracleDbType.Varchar2).Value = ticketId;
                        cmd.Parameters.Add(":scheduleId", OracleDbType.Varchar2).Value = scheduleId;
                        cmd.Parameters.Add(":customerName", OracleDbType.Varchar2).Value = customerName;
                        cmd.Parameters.Add(":customerPhone", OracleDbType.Varchar2).Value = customerPhone;
                        cmd.Parameters.Add(":customerCount", OracleDbType.Int32).Value = customerCount;
                        cmd.Parameters.Add(":selectSeats", OracleDbType.Varchar2).Value = selectSeats;
                        cmd.Parameters.Add(":payment", OracleDbType.Varchar2).Value = "카드";  // 기본 결제 방법은 카드

                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("티켓 저장 오류: " + ex.Message);
                    return false;
                }
            }
        }

        //음식 ID생성
        public string GenerateFoodId()
        {
            string connectionString = GetConnectionString();
            string maxId = "F0"; // 기본값: 영화 ID가 없을 경우 M0

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MAX(FOOD_ID) FROM FOOD";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        maxId = result.ToString(); // 최대 ID 가져오기
                    }
                }
            }

            // 최대 ID에서 숫자 부분 추출 후 1 증가
            int nextIdNumber = int.Parse(maxId.Substring(1)) + 1;
            return $"F{nextIdNumber}";
        }
        // 음식 추가 함수
        public bool InsertFood(string foodName, string foodCategory, string foodPrice, string foodQuantity, string foodImage, string foodDesc)
        {
            try
            {
                string connectionString = GetConnectionString();
                string insertQuery = @"INSERT INTO FOOD (
                                  FOOD_ID, FOOD_NAME, FOOD_TYPE, FOOD_PRICE,
                                  FOOD_AMOUNT, FOOD_IMAGE, FOOD_DESC
                              ) VALUES (
                                  :food_id, :food_name, :food_type, :food_price,
                                  :food_quantity, :food_image, :food_desc
                              )";

                string foodId = GenerateFoodId(); // 새로운 음식 ID 생성

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand(insertQuery, connection))
                    {
                        command.Parameters.Add(":food_id", OracleDbType.Varchar2).Value = foodId;
                        command.Parameters.Add(":food_name", OracleDbType.Varchar2).Value = foodName ?? (object)DBNull.Value;
                        command.Parameters.Add(":food_type", OracleDbType.Varchar2).Value = foodCategory ?? (object)DBNull.Value;
                        command.Parameters.Add(":food_price", OracleDbType.Varchar2).Value = foodPrice ?? (object)DBNull.Value;
                        command.Parameters.Add(":food_quantity", OracleDbType.Varchar2).Value = foodQuantity ?? (object)DBNull.Value;
                        command.Parameters.Add(":food_image", OracleDbType.Varchar2).Value = foodImage ?? (object)DBNull.Value;
                        command.Parameters.Add(":food_desc", OracleDbType.Varchar2).Value = foodDesc ?? (object)DBNull.Value; ;

                        command.ExecuteNonQuery();
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
        public void SaveOrder(string paymentMethod, Dictionary<string, (int quantity, int price)> cartItems)
        {
            string connectionString = GetConnectionString();
            string orderId = GenerateOrderId(); // 새로운 주문 ID 생성
            int totalAmount = cartItems.Sum(item => item.Value.quantity * item.Value.price); // 총 금액 계산
            DateTime orderDate = DateTime.Now;

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleTransaction transaction = conn.BeginTransaction()) // 트랜잭션 시작
                {
                    try
                    {
                        // 1. 주문(ORDERS) 테이블에 저장
                        string insertOrderQuery = @"
                    INSERT INTO ORDERS (ORDER_ID, ORDER_DATE, ORDER_TOTAL_AMOUNT, ORDER_PAYMENT, ORDER_NO)
                    VALUES (:orderId, :orderDate, :totalAmount, :paymentMethod, :orderNo)";

                        using (OracleCommand cmd = new OracleCommand(insertOrderQuery, conn))
                        {
                            cmd.Parameters.Add(":orderId", OracleDbType.Varchar2).Value = orderId;
                            cmd.Parameters.Add(":orderDate", OracleDbType.Date).Value = orderDate;
                            cmd.Parameters.Add(":totalAmount", OracleDbType.Int32).Value = totalAmount;
                            cmd.Parameters.Add(":paymentMethod", OracleDbType.Varchar2).Value = paymentMethod;
                            cmd.Parameters.Add(":orderNo", OracleDbType.Varchar2).Value = GenerateOrderNo(orderDate); // 주문 번호 생성
                            cmd.ExecuteNonQuery();
                        }

                        // 2. 주문 상세(ORDER_DETAIL) 테이블에 저장
                        foreach (var item in cartItems)
                        {
                            string foodName = item.Key;
                            int quantity = item.Value.quantity;
                            int price = item.Value.price;

                            // food_id 가져오기
                            string foodId = GetFoodIdByName(foodName, conn);

                            if (!string.IsNullOrEmpty(foodId))
                            {
                                string insertOrderDetailQuery = @"
                            INSERT INTO ORDER_DETAIL (ITEM_ID, ORDER_ID, FOOD_ID, ITEM_QUANTITY, PRICE)
                            VALUES (ORDER_DETAIL_SEQ.NEXTVAL, :orderId, :foodId, :quantity, :price)";

                                using (OracleCommand cmd = new OracleCommand(insertOrderDetailQuery, conn))
                                {
                                    cmd.Parameters.Add(":orderId", OracleDbType.Varchar2).Value = orderId;
                                    cmd.Parameters.Add(":foodId", OracleDbType.Varchar2).Value = foodId;
                                    cmd.Parameters.Add(":quantity", OracleDbType.Int32).Value = quantity;
                                    cmd.Parameters.Add(":price", OracleDbType.Int32).Value = price;
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit(); // 모든 작업이 성공하면 커밋
                    }
                    catch
                    {
                        transaction.Rollback(); // 에러 발생 시 롤백
                        throw;
                    }
                }
            }
        }

        private string GetFoodIdByName(string foodName, OracleConnection conn)
        {
            string query = "SELECT FOOD_ID FROM FOOD WHERE FOOD_NAME = :foodName";
            using (OracleCommand cmd = new OracleCommand(query, conn))
            {
                cmd.Parameters.Add(":foodName", OracleDbType.Varchar2).Value = foodName;
                object result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }

        private string GenerateOrderId()
        {
            return "O" + DateTime.Now.ToString("yyyyMMddHHmmss"); // 예: O20241130124500
        }

        private string GenerateOrderNo(DateTime orderDate)
        {
            return "ON" + orderDate.ToString("yyyyMMdd") + new Random().Next(1000, 9999); // 예: ON202411301234
        }

        // 주문 목록을 불러오는 함수
        public DataTable LoadOrders()
        {
            string connectionString = GetConnectionString();
            string query = @"
        SELECT ORDER_ID, ORDER_DATE, ORDER_TOTAL_AMOUNT, ORDER_PAYMENT, ORDER_NO
        FROM ORDERS";  // ORDERS 테이블에서 데이터를 가져옵니다.

            DataTable dt = new DataTable();
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                OracleDataAdapter da = new OracleDataAdapter(query, conn);
                da.Fill(dt); // DataTable에 데이터 채우기
            }
            return dt;
        }

        // 주문 상세 정보를 불러오는 함수
        public DataTable LoadOrderDetails(string orderId)
        {
            string connectionString = GetConnectionString();
            string query = @"
        SELECT F.FOOD_NAME, OD.ITEM_QUANTITY, OD.PRICE
        FROM ORDER_DETAIL OD
        JOIN FOOD F ON F.FOOD_ID = OD.FOOD_ID
        WHERE OD.ORDER_ID = :orderId";  // 주문 ID에 맞는 상세 정보를 가져옵니다.

            DataTable dt = new DataTable();
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                OracleDataAdapter da = new OracleDataAdapter(query, conn);
                da.SelectCommand.Parameters.Add(":orderId", OracleDbType.Varchar2).Value = orderId;
                da.Fill(dt); // DataTable에 데이터 채우기
            }
            return dt;
        }

        public DataTable GetTickets()
        {
            DataTable ticketTable = new DataTable();
            string connectionString = GetConnectionString();

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT T.TICKET_ID, T.CUSTOMER_NAME, T.CUSTOMER_PHONE, T.CUSTOMER_COUNT, T.SELECT_SEATS, 
                               S.SCHEDULE_DATE, S.SHOW_TIME, 
                               M.MOVIE_NAME, M.MOVIE_POSTER, 
                               SC.SCREEN_NAME, SC.SCREEN_TYPE
                        FROM TICKET T
                        JOIN SCHEDULE S ON T.SCHEDULE_ID = S.SCHEDULE_ID
                        JOIN MOVIE M ON S.MOVIE_ID = M.MOVIE_ID
                        JOIN SCREEN SC ON S.SCREEN_ID = SC.SCREEN_ID
                        WHERE T.SCHEDULE_ID = S.SCHEDULE_ID
                        ORDER BY S.SCHEDULE_DATE, S.SHOW_TIME";

                    using (OracleDataAdapter adapter = new OracleDataAdapter(query, conn))
                    {
                        adapter.Fill(ticketTable);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("티켓 데이터를 가져오는 중 오류 발생: " + ex.Message);
                }
            }

            return ticketTable;
        }


        public DataRow GetTicketDetails(string ticketId)
        {
            DataTable ticketDetailsTable = new DataTable();
            string connectionString = GetConnectionString();

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT T.TICKET_ID, T.CUSTOMER_NAME, T.CUSTOMER_PHONE, T.CUSTOMER_COUNT, T.SELECT_SEATS, 
                               S.SCHEDULE_DATE, S.SHOW_TIME, 
                               M.MOVIE_NAME, M.MOVIE_POSTER, 
                               SC.SCREEN_NAME, SC.SCREEN_TYPE
                        FROM TICKET T
                        JOIN SCHEDULE S ON T.SCHEDULE_ID = S.SCHEDULE_ID
                        JOIN MOVIE M ON S.MOVIE_ID = M.MOVIE_ID
                        JOIN SCREEN SC ON S.SCREEN_ID = SC.SCREEN_ID
                        WHERE T.TICKET_ID = :ticketId";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(":ticketId", OracleDbType.Varchar2).Value = ticketId;

                        using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                        {
                            adapter.Fill(ticketDetailsTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("티켓 상세 정보를 가져오는 중 오류 발생: " + ex.Message);
                }
            }

            if (ticketDetailsTable.Rows.Count > 0)
                return ticketDetailsTable.Rows[0];
            else
                throw new Exception("티켓 ID에 해당하는 데이터를 찾을 수 없습니다.");
        }

    }

    public class Movie
    {
        public string MovieId { get; set; } // 영화 ID
        public string MovieName { get; set; } // 영화 제목
        public string MovieType { get; set; } // 영화 장르
        public string MoviePoster { get; set; } // 영화 포스터
        public string MoviePerformer { get; set; } // 배우
        public string MovieRating { get; set; } // 영화 등급
        public DateTime ReleaseDate { get; set; } // 개봉일
        public string MovieOverview { get; set; } // 줄거리
        public string MovieProducer { get; set; } // 감독
        public string ShowTime { get; set; }
        public string ScreenID {  get; set; }
        public string ScheduleId {  get; set; }
    }

    public class Screen
    {
        public string ScreenId { get; set; }
        public string ScreenName { get; set; }
        public string ScreenType { get; set; }
        public int ScreenTotalSeats { get; set; }
    }

    public class Schedule
    {
        public string ScheduleId { get; set; }
        public DateTime DateTime { get; set; }
        public string ShowTime { get; set; }
        public string MovieId { get; set; }
        public string ScreenId { get; set; }
    }
    public class Food
    {
        public string foodID { get; set; }
        public string foodName { get; set; }
        public string foodCategory { get; set; }
        public string foodQuantity { get; set; }
        public string foodPrice { get; set; }
        public string foodImage { get; set; }
        public string foodDesc { get; set; }
    }
}
