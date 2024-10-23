using ExpeditionsProject.Project.Databases;
using ExpeditionsProject.Project.Model;
using ExpeditionsProject.Project.Model.AdminModel.AdminTabe;
using ExpeditionsProject.Project.Model.AdminModel.DopExpeditionModel;
using ExpeditionsProject.Project.Model.AdminModel.Expedition;
using ExpeditionsProject.Project.Model.AdminModel.Itinerary;
using ExpeditionsProject.Project.Model.AdminModel.PointModel;
using ExpeditionsProject.Project.Model.ClientModel.ClientNew;
using ExpeditionsProject.Project.Model.ClientModel.ClientToExpedition;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace ExpeditionsProject.Project
{
    public class DataWork
    {
        private readonly string _connectionString = "Data Source=LAPTOP-6AHT87V0;Initial Catalog=Тур-агенства;User ID=sa;Password=cndjvbhdt6r3t;Integrated Security=False;TrustServerCertificate=True";

        private readonly SqlConnection _connection;
        private SqlCommand _cmd;
        private string _sql;

       

        public DataWork(string newConnectionString)
        {
            _connectionString = newConnectionString;
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

       

        public void CloseConnection()
        {
            _connection.Close();
        }

        public void AddClientToExpedition(int clientID, int expeditionID)
        {
            _sql = "INSERT INTO Состав_группы_клиенты (FK_Клиент, FK_Экспидиция) VALUES (@ClientID, @ExpeditionID)";

           
            _cmd = new SqlCommand(_sql, _connection);
            _cmd.Parameters.AddWithValue("@ClientID", clientID);
            _cmd.Parameters.AddWithValue("@ExpeditionID", expeditionID);

            int rowsAffected = _cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Клиент успешно добавлен в экспедицию.");
            }
            else
            {
                MessageBox.Show("Ошибка при добавлении клиента в экспедицию.");
            }
        }

        public List<ClientInfoExpeditionModel> GetInfoExpedition(int IdExpedition)
        {
            List<ClientInfoExpeditionModel> expeditions = new List<ClientInfoExpeditionModel>();

            // Проверяем, открыто ли соединение
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            // Запрос для получения экспедиций клиента
            _sql = @"
            SELECT Экспедиция.ID_Экспидиции, Экспедиция.Колличество_порций, Экспедиция.Колличество_снаряжения, Экспедиция.Дата_начала, Экспедиция.Дата_окончания, Меню.ID_Меню, Меню.Названия_меню, Трансфер.ID_Трансфера, Трансфер.Дата, Снаряжение.ID_Снаряжения, Снаряжение.Название_снаряжения, Снаряжение.Требования_к_уменим, Снаряжение.Колличество_на_человека_группу " +
           "FROM Экспедиция " +
           "INNER JOIN Меню ON Экспедиция.FK_Меню = Меню.ID_Меню " +
           "INNER JOIN Трансфер ON Экспедиция.FK_Трансфера = Трансфер.ID_Трансфера " +
           "INNER JOIN Снаряжение ON Экспедиция.FK_Снаряжение = Снаряжение.ID_Снаряжения " +
           "WHERE Экспедиция.ID_Экспидиции = @idExpedition";

            _cmd = new SqlCommand(_sql, _connection);
            _cmd.Parameters.AddWithValue("@idExpedition", IdExpedition);

            using (SqlDataReader reader = _cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    expeditions.Add(new ClientInfoExpeditionModel()
                    {
                        ID_Expedition = reader.GetInt32(reader.GetOrdinal("ID_Экспидиции")),
                        CountPortion = reader.GetInt32(reader.GetOrdinal("Колличество_порций")),
                        CountEquipment = reader.GetInt32(reader.GetOrdinal("Колличество_снаряжения")),
                     
                     
                        NameMenu = reader.GetString(reader.GetOrdinal("Названия_меню")),
                        Id_Transfer = reader.GetInt32(reader.GetOrdinal("ID_Трансфера")),
                        Date = reader.GetDateTime(reader.GetOrdinal("Дата")),
                     
                        NameEquipment = reader.GetString(reader.GetOrdinal("Название_снаряжения")),
                        SkillRequirements = reader.GetString(reader.GetOrdinal("Требования_к_уменим")),
                        CountInPerson = reader.GetInt32(reader.GetOrdinal("Колличество_на_человека_группу")),

                    });
                }
            }

            return expeditions;
        }
        public List<InstructorTableModel> GetCientInfoInstructor(int IdExpedition)
        {
            List<InstructorTableModel> expeditions = new List<InstructorTableModel>();

            // Проверяем, открыто ли соединение
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            // Запрос для получения экспедиций клиента
            _sql = @"
            SELECT Инструктор.ID_Инструктора, Имя, Отчество, Фамилия, Номер_телефона, Уровень_здоровья,Занятия_спортом,Уровен_професионлизма " +
           "FROM Инструктор " +
           "JOIN Состав_группы_инструкторов ON Инструктор.ID_Инструктора = Состав_группы_инструкторов.FK_Инструктора " +
           "JOIN Экспедиция ON Состав_группы_инструкторов.FK_Экспидиция = Экспедиция.ID_Экспидиции " +
           "WHERE Экспедиция.ID_Экспидиции = @ExpeditionId";

            _cmd = new SqlCommand(_sql, _connection);
            _cmd.Parameters.AddWithValue("@ExpeditionId", IdExpedition);

            using (SqlDataReader reader = _cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    expeditions.Add(new InstructorTableModel()
                    {
                        ID_Instructor = reader.GetInt32(reader.GetOrdinal("ID_Инструктора")),
                        ForeName = reader.GetString(reader.GetOrdinal("Имя")),
                        Patronymic = reader.GetString(reader.GetOrdinal("Отчество")),
                        Surname = reader.GetString(reader.GetOrdinal("Фамилия")),
                        NumberTelefon = reader.GetString(reader.GetOrdinal("Номер_телефона")),
                        Sport = reader.GetString(reader.GetOrdinal("Занятия_спортом")),
                        LevelHealth = reader.GetString(reader.GetOrdinal("Уровень_здоровья")),
                        LevelProfisionsl = reader.GetString(reader.GetOrdinal("Уровен_професионлизма"))


                    });
                }
            }

            return expeditions;
        }

        public List<ClientTableModel> GetInfoClient(int IdExpedition)
        {
            List<ClientTableModel> expeditions = new List<ClientTableModel>();

            // Проверяем, открыто ли соединение
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            // Запрос для получения экспедиций клиента
            _sql = @"
            SELECT Клиент.ID_Клиента, Имя, Отчество, Фамилия, Номер_телефона, Уровень_здоровья " +
           "FROM Клиент " +
           "JOIN Состав_группы_клиенты ON Клиент.ID_Клиента = Состав_группы_клиенты.FK_Клиент " +
           "JOIN Экспедиция ON Состав_группы_клиенты.FK_Экспидиция = Экспедиция.ID_Экспидиции " +
           "WHERE Экспедиция.ID_Экспидиции = @ExpeditionId";

            _cmd = new SqlCommand(_sql, _connection);
            _cmd.Parameters.AddWithValue("@ExpeditionId", IdExpedition);

            using (SqlDataReader reader = _cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    expeditions.Add(new ClientTableModel()
                    {
                        ID_Client = reader.GetInt32(reader.GetOrdinal("ID_Клиента")),
                        ForeName = reader.GetString(reader.GetOrdinal("Имя")),
                        Patronymic = reader.GetString(reader.GetOrdinal("Отчество")),
                        Surname = reader.GetString(reader.GetOrdinal("Фамилия")),
                        NumberTelefon = reader.GetString(reader.GetOrdinal("Номер_телефона")),
                        LevelHealth = reader.GetString(reader.GetOrdinal("Уровень_здоровья"))


                    });
                }
            }

            return expeditions;
        }


        public List<ClientNewInfoItineraryModel> GetInfoItinerary(int clientId)
        {
            List<ClientNewInfoItineraryModel> expeditions = new List<ClientNewInfoItineraryModel>();

            // Проверяем, открыто ли соединение
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            // Запрос для получения экспедиций клиента
            _sql = @"
            SELECT Маршрут.ID_Маршрута, Маршрут.Название_маршрута, Маршрут.Колличество_дней, Маршрут.Киллометраж, " +
"Сложность_маршрута.Уровень_сложности_маршрута, Регионы.Название_регина " +
"FROM Экспедиция " +
"INNER JOIN Маршрут ON Экспедиция.FK_Маршрута = Маршрут.ID_Маршрута " +
"INNER JOIN Сложность_маршрута ON Маршрут.FK_СпМ = Сложность_маршрута.ID_СМ " +
"INNER JOIN Маршруты_по_регионам ON Маршрут.ID_Маршрута = Маршруты_по_регионам.FK_Маршрута " +
"INNER JOIN Регионы ON Маршруты_по_регионам.FK_Региона = Регионы.ID_Региона " +
"WHERE Экспедиция.ID_Экспидиции = @expeditionId";

            _cmd = new SqlCommand(_sql, _connection);
            _cmd.Parameters.AddWithValue("@expeditionId", clientId);

            using (SqlDataReader reader = _cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    expeditions.Add(new ClientNewInfoItineraryModel()
                    {
                        ID_Itinerary = reader.GetInt32(reader.GetOrdinal("ID_Маршрута")),
                        NameItinerary = reader.GetString(reader.GetOrdinal("Название_маршрута")),
                        NameRegion = reader.GetString(reader.GetOrdinal("Название_регина")),
                        CountDay = reader.GetInt32(reader.GetOrdinal("Колличество_дней")),
                        CountKM = (float)reader.GetDouble(reader.GetOrdinal("Киллометраж")),
                        LevelItinerary = reader.GetString(reader.GetOrdinal("Уровень_сложности_маршрута"))
                       

                    });
                }
            }

            return expeditions;
        }
        public List<ListExpeditionToClientModel> GetListExpeditionToInstructor(int clientId)
        {
            List<ListExpeditionToClientModel> expeditions = new List<ListExpeditionToClientModel>();

            // Проверяем, открыто ли соединение
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            // Запрос для получения экспедиций клиента
            _sql = @"
            SELECT e.ID_Экспидиции, m.ID_Маршрута, m.Название_маршрута, e.Дата_начала, e.Дата_окончания 
            FROM Экспедиция e
            INNER JOIN Состав_группы_инструкторов sgk ON e.ID_Экспидиции = sgk.FK_Экспидиция
            INNER JOIN Маршрут m ON e.FK_Маршрута = m.ID_Маршрута
            WHERE sgk.FK_Инструктора = @ClientId";

            _cmd = new SqlCommand(_sql, _connection);
            _cmd.Parameters.AddWithValue("@ClientId", clientId);

            using (SqlDataReader reader = _cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    expeditions.Add(new ListExpeditionToClientModel()
                    {
                        ID_Expedition = reader.GetInt32(reader.GetOrdinal("ID_Экспидиции")),
                        ID_Itinerary = reader.GetInt32(reader.GetOrdinal("ID_Маршрута")),
                        NameItinerary = reader.GetString(reader.GetOrdinal("Название_маршрута")),
                        DateStart = reader.GetDateTime(reader.GetOrdinal("Дата_начала")),
                        DateFinish = reader.GetDateTime(reader.GetOrdinal("Дата_окончания"))
                    });
                }
            }

            return expeditions;
        }
        public List<ListExpeditionToClientModel> GetListExpeditionToClient(int clientId)
        {
            List<ListExpeditionToClientModel> expeditions = new List<ListExpeditionToClientModel>();

            // Проверяем, открыто ли соединение
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            // Запрос для получения экспедиций клиента
            _sql = @"
            SELECT e.ID_Экспидиции, m.ID_Маршрута, m.Название_маршрута, e.Дата_начала, e.Дата_окончания 
            FROM Экспедиция e
            INNER JOIN Состав_группы_клиенты sgk ON e.ID_Экспидиции = sgk.FK_Экспидиция
            INNER JOIN Маршрут m ON e.FK_Маршрута = m.ID_Маршрута
            WHERE sgk.FK_Клиент = @ClientId";

            _cmd = new SqlCommand(_sql, _connection);
            _cmd.Parameters.AddWithValue("@ClientId", clientId);

            using (SqlDataReader reader = _cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    expeditions.Add(new ListExpeditionToClientModel()
                    {
                        ID_Expedition = reader.GetInt32(reader.GetOrdinal("ID_Экспидиции")),
                        ID_Itinerary = reader.GetInt32(reader.GetOrdinal("ID_Маршрута")),
                        NameItinerary = reader.GetString(reader.GetOrdinal("Название_маршрута")),
                        DateStart = reader.GetDateTime(reader.GetOrdinal("Дата_начала")),
                        DateFinish = reader.GetDateTime(reader.GetOrdinal("Дата_окончания"))
                    });
                }
            }

            return expeditions;
        }

        public List<ClientNewExpeditionModel> GetExpeditionsInNewExpedition(int routeId)
        {
            List<ClientNewExpeditionModel> expeditions = new List<ClientNewExpeditionModel>();

            // Проверяем, открыто ли соединение
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            _sql = "SELECT ID_Экспидиции, Дата_начала, Дата_окончания FROM Экспедиция WHERE FK_Маршрута = @RouteId";
            _cmd = new SqlCommand(_sql, _connection);
            _cmd.Parameters.AddWithValue("@RouteId", routeId);


            

            using (SqlDataReader reader = _cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    expeditions.Add(new ClientNewExpeditionModel()
                    {
                        ID_Expedition = reader.GetInt32(reader.GetOrdinal("ID_Экспидиции")),
                        DateStart = reader.GetDateTime(reader.GetOrdinal("Дата_начала")),
                        DateFinish = reader.GetDateTime(reader.GetOrdinal("Дата_окончания"))
                    });
                }
            }
            return expeditions;
        }


            public List<PointAdminTableModel> GetPointsByExpedition(int expeditionId)
        {
            List<PointAdminTableModel> points = new List<PointAdminTableModel>();
            try
            {
                _sql = @"
            SELECT T.ID_Точки, T.Название_точки, TT.Название_типа, TNM.Дата_прибытия_в_точку, TNM.День_прибытия_в_точку
            FROM Точки_на_маршруте TNM
            INNER JOIN Точка T ON TNM.FK_Точки = T.ID_Точки
            INNER JOIN Типы_точек TT ON TNM.FK_Тип_точки = TT.ID_Типов_точек
            WHERE TNM.FK_Маршрута = (
                SELECT FK_Маршрута FROM Экспедиция WHERE ID_Экспидиции = @ExpeditionId
            )";

                _cmd = new SqlCommand(_sql, _connection);
                _cmd.Parameters.AddWithValue("@ExpeditionId", expeditionId);
                SqlDataReader reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    points.Add(new PointAdminTableModel
                    {
                        ID_Point = reader.GetInt32(reader.GetOrdinal("ID_Точки")),
                        NamePoint = reader.GetString(reader.GetOrdinal("Название_точки")),
                        NameTypePoint = reader.GetString(reader.GetOrdinal("Название_типа")),
                        DateToPoint = reader.GetDateTime(reader.GetOrdinal("Дата_прибытия_в_точку")),
                        DayToPoint = reader.GetInt32(reader.GetOrdinal("День_прибытия_в_точку"))
                    });
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return points;
        }
    

    public List<ExpeditionTibleModel> GetExpeditionData()
        {
            List<ExpeditionTibleModel> expeditions = new List<ExpeditionTibleModel>();
            try
            {
                _sql = @"
                    SELECT E.FK_Маршрута, M.Название_маршрута, E.ID_Экспидиции, E.Дата_начала, E.Дата_окончания
                    FROM Экспедиция E
                    INNER JOIN Маршрут M ON E.FK_Маршрута = M.ID_Маршрута";

                _cmd = new SqlCommand(_sql, _connection);
                SqlDataReader reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    expeditions.Add(new ExpeditionTibleModel
                    {
                        ID_Itinerary = reader.GetInt32(reader.GetOrdinal("FK_Маршрута")),
                        NameItinerary = reader.GetString(reader.GetOrdinal("Название_маршрута")),
                        ID_Expedition = reader.GetInt32(reader.GetOrdinal("ID_Экспидиции")),
                        DateStart = reader.GetDateTime(reader.GetOrdinal("Дата_начала")),
                        DateFinish = reader.GetDateTime(reader.GetOrdinal("Дата_окончания"))
                    });
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return expeditions;
        }
        public List<ClientTableModel> ClientTable()
        {
            List<ClientTableModel> client = new List<ClientTableModel>();
            try
            {
                _sql = @"
                SELECT I.ID_Клиента, I.Имя, I.Отчество, I.Фамилия, I.Номер_телефона, E.ID_Экспидиции
                FROM Клиент I
                LEFT JOIN Состав_группы_клиенты CGI ON I.ID_Клиента = CGI.FK_Клиент
                LEFT JOIN Экспедиция E ON CGI.FK_Экспидиция = E.ID_Экспидиции";

                _cmd = new SqlCommand(_sql, _connection);
                SqlDataReader reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    client.Add(new ClientTableModel
                    {
                        ID_Client = reader.GetInt32(reader.GetOrdinal("ID_Клиента")),
                        ForeName = reader.GetString(reader.GetOrdinal("Имя")),
                        Patronymic = reader.GetString(reader.GetOrdinal("Отчество")),
                        Surname = reader.GetString(reader.GetOrdinal("Фамилия")),
                        NumberTelefon = reader.GetString(reader.GetOrdinal("Номер_телефона")),
                        ID_Expedition = reader.GetInt32(reader.GetOrdinal("ID_Экспидиции"))
                    });
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return client;
        }
        public List<InstructorTableModel> InstructorsTable()
        {
            List<InstructorTableModel> instructors = new List<InstructorTableModel>();
            try
            {
                _sql = @"
                SELECT I.ID_Инструктора, I.Имя, I.Отчество, I.Фамилия, I.Номер_телефона, I.Занятия_спортом, E.ID_Экспидиции
                FROM Инструктор I
                LEFT JOIN Состав_группы_инструкторов CGI ON I.ID_Инструктора = CGI.FK_Инструктора
                LEFT JOIN Экспедиция E ON CGI.FK_Экспидиция = E.ID_Экспидиции";

                _cmd = new SqlCommand(_sql, _connection);
                SqlDataReader reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    instructors.Add(new InstructorTableModel
                    {
                        ID_Instructor = reader.GetInt32(reader.GetOrdinal("ID_Инструктора")),
                        ForeName = reader.GetString(reader.GetOrdinal("Имя")),
                        Patronymic = reader.GetString(reader.GetOrdinal("Отчество")),
                        Surname = reader.GetString(reader.GetOrdinal("Фамилия")),
                        NumberTelefon = reader.GetString(reader.GetOrdinal("Номер_телефона")),
                        Sport = reader.GetString(reader.GetOrdinal("Занятия_спортом")),
                        ID_Expedition = reader.GetInt32(reader.GetOrdinal("ID_Экспидиции"))
                    });
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return instructors;
        }
    

    public List<ClientNewExpeditionModel> GetExpeditionsByRouteId(int routeId)
        {
            List<ClientNewExpeditionModel> expeditions = new List<ClientNewExpeditionModel>();
            _sql = "SELECT E.ID_Экспидиции, E.Колличество_порций, E.Колличество_снаряжения, E.Название_маршрута, " +
                   "S.Название_снаряжения, E.Дата_начала, E.Дата_окончания " +
                   "FROM Экспедиция E " +
                   "JOIN Снаряжение S ON E.FK_Снаряжение = S.ID_Снаряжения " +
                   "WHERE E.FK_Маршрута = @RouteId";

            _cmd = new SqlCommand(_sql, _connection);
            _cmd.Parameters.AddWithValue("@RouteId", routeId);

            using (SqlDataReader reader = _cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ClientNewExpeditionModel expedition = new ClientNewExpeditionModel
                    {
                        ID_Expedition = (int)reader["ID_Экспидиции"],
                        CounMenu = (int)reader["Колличество_порций"],
                        CountEquipment = (int)reader["Колличество_снаряжения"],
                        NameItinerary= (string)reader["Название_маршрута"],
                        NameEquipment = (string)reader["Название_снаряжения"],
                        DateStart = (DateTime)reader["Дата_начала"],
                        DateFinish = (DateTime)reader["Дата_окончания"]
                    };
                    expeditions.Add(expedition);
                }
            }
            return expeditions;
        }
        public List<ClientNewInfoItineraryModel> GetRouteInfoByRegion(string regionName)
        {
            List<ClientNewInfoItineraryModel> routeInfos = new List<ClientNewInfoItineraryModel>();
            string sql = @"
        SELECT 
            M.ID_Маршрута,
            M.Название_маршрута,
            M.Колличество_дней,
            M.Киллометраж,
            СМ.Уровень_сложности_маршрута,
            R.Название_региона
        FROM 
            Маршрут M
        JOIN 
            Сложность_маршрута СМ ON M.FK_СпМ = СМ.ID_СМ
        JOIN 
            Маршруты_по_регионам МпР ON M.ID_Маршрута = МпР.FK_Маршрута
        JOIN 
            Регионы R ON МпР.FK_Региона = R.ID_Региона
        WHERE 
            R.Название_региона = @RegionName
        ORDER BY 
            M.ID_Маршрута";

            using (SqlCommand cmd = new SqlCommand(sql, _connection))
            {
                cmd.Parameters.AddWithValue("@RegionName", regionName);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ClientNewInfoItineraryModel routeInfo = new ClientNewInfoItineraryModel
                        {
                            ID_Itinerary = reader.GetInt32(reader.GetOrdinal("ID_Маршрута")),
                            NameItinerary = reader.GetString(reader.GetOrdinal("Название_маршрута")),
                            CountDay = reader.GetInt32(reader.GetOrdinal("Колличество_дней")),
                            CountKM = (float)reader.GetDouble(reader.GetOrdinal("Киллометраж")),
                            LevelItinerary = reader.GetString(reader.GetOrdinal("Уровень_сложности_маршрута")),
                            NameRegion = reader.GetString(reader.GetOrdinal("Название_региона"))
                        };
                        routeInfos.Add(routeInfo);
                    }
                }
            }
            return routeInfos;
        }

        public List<ClientNewInfoItineraryModel> GetRouteInfoByComplexity(string complexityLevel)
        {
            List<ClientNewInfoItineraryModel> routeInfos = new List<ClientNewInfoItineraryModel>();
            string sql = @"
        SELECT
            M.ID_Маршрута,
            M.Название_маршрута,
            M.Колличество_дней,
            M.Киллометраж,
            СМ.Уровень_сложности_маршрута,
            R.Название_региона
        FROM 
            Маршрут M
        JOIN 
            Сложность_маршрута СМ ON M.FK_СпМ = СМ.ID_СМ
        JOIN 
            Маршруты_по_регионам МпР ON M.ID_Маршрута = МпР.FK_Маршрута
        JOIN 
            Регионы R ON МпР.FK_Региона = R.ID_Региона
        WHERE 
            СМ.Уровень_сложности_маршрута = @ComplexityLevel
        ORDER BY 
            M.ID_Маршрута";

            using (SqlCommand cmd = new SqlCommand(sql, _connection))
            {
                cmd.Parameters.AddWithValue("@ComplexityLevel", complexityLevel);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ClientNewInfoItineraryModel routeInfo = new ClientNewInfoItineraryModel
                        {
                            ID_Itinerary = reader.GetInt32(reader.GetOrdinal("ID_Маршрута")),
                            NameItinerary = reader.GetString(reader.GetOrdinal("Название_маршрута")),
                            CountDay = reader.GetInt32(reader.GetOrdinal("Колличество_дней")),
                            CountKM = (float)reader.GetDouble(reader.GetOrdinal("Киллометраж")),
                            LevelItinerary = reader.GetString(reader.GetOrdinal("Уровень_сложности_маршрута")),
                            NameRegion = reader.GetString(reader.GetOrdinal("Название_региона"))
                        };
                        routeInfos.Add(routeInfo);
                    }
                }
            }
            return routeInfos;
        }
        public List<ClientNewInfoItineraryModel> GetRouteInfo()
        {
            List<ClientNewInfoItineraryModel> routeInfos = new List<ClientNewInfoItineraryModel>();
            string sql = @"
            SELECT 
                M.ID_Маршрута,
                M.Название_маршрута,
                M.Колличество_дней,
                M.Киллометраж,
                СМ.Уровень_сложности_маршрута,
                R.Название_регина
            FROM 
                Маршрут M
            JOIN 
                Сложность_маршрута СМ ON M.FK_СпМ = СМ.ID_СМ
            JOIN 
                Маршруты_по_регионам МпР ON M.ID_Маршрута = МпР.FK_Маршрута
            JOIN 
                Регионы R ON МпР.FK_Региона = R.ID_Региона
            ORDER BY 
                M.ID_Маршрута";

            using (SqlCommand cmd = new SqlCommand(sql, _connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ClientNewInfoItineraryModel routeInfo = new ClientNewInfoItineraryModel
                        {
                            ID_Itinerary = reader.GetInt32(reader.GetOrdinal("ID_Маршрута")),
                            NameItinerary = reader.GetString(reader.GetOrdinal("Название_маршрута")),
                            CountDay = reader.GetInt32(reader.GetOrdinal("Колличество_дней")),
                            CountKM = (float)reader.GetDouble(reader.GetOrdinal("Киллометраж")),
                        LevelItinerary = reader.GetString(reader.GetOrdinal("Уровень_сложности_маршрута")),
                            NameRegion = reader.GetString(reader.GetOrdinal("Название_регина"))
                        };
                        routeInfos.Add(routeInfo);
                    }
                }
            }

            return routeInfos;
        }

        


        public void RegistrationClient(ClientRegistrationModel clientRegistrationModel)
        {
            _sql = "INSERT INTO [Тур-агенства].[dbo].[Клиент] (Имя, Отчество, Фамилия, Номер_телефона, Страна_проживания, Город_проживания, Улица_проживания, Квартира_Дом_проживания,Уровень_здоровья, Почта, Пароль) VALUES (@ForeName, @Patronymic, @Surname, @NumberTelefon, @Country, @City, @Street,@NumberHome,@NumberHome, @Password, @Email)";
            _cmd = new SqlCommand(_sql, _connection);

            _cmd.Parameters.AddWithValue("@ForeName", clientRegistrationModel.ForeName);
            _cmd.Parameters.AddWithValue("@Patronymic", clientRegistrationModel.Patronymic);
            _cmd.Parameters.AddWithValue("@Surname", clientRegistrationModel.Surname);
            _cmd.Parameters.AddWithValue("@NumberTelefon", clientRegistrationModel.NumberTelefon);
            _cmd.Parameters.AddWithValue("@Country", clientRegistrationModel.Country);
            _cmd.Parameters.AddWithValue("@City", clientRegistrationModel.City);
            _cmd.Parameters.AddWithValue("@Street", clientRegistrationModel.Street);
            _cmd.Parameters.AddWithValue("@NumberHome", clientRegistrationModel.NumberHome);
            _cmd.Parameters.AddWithValue("@Password", clientRegistrationModel.Password);
            _cmd.Parameters.AddWithValue("@Email", clientRegistrationModel.Email);

            _cmd.ExecuteNonQuery();
        }

        public void RegistrationInstructor(InstructorRegistrationModel instructor)
        {
            _sql = "INSERT INTO [Тур-агенства].[dbo].[Инструктор] (Имя, Отчество, Фамилия, Номер_телефона, Уровен_професионлизма, Занятия_спортом, Уровень_здоровья, Пароль, Почта) VALUES (@ForeName, @Patronymic, @Surname, @NumberTelefon, @LevelProfisionsl, @Sport, @LevelHealth, @Password, @Email)";
            _cmd = new SqlCommand(_sql, _connection);

            _cmd.Parameters.AddWithValue("@Email", instructor.Email);
            _cmd.Parameters.AddWithValue("@Password", instructor.Password);
            _cmd.Parameters.AddWithValue("@ForeName", instructor.ForeName);         
            _cmd.Parameters.AddWithValue("@Patronymic", instructor.Patronymic);
            _cmd.Parameters.AddWithValue("@Surname", instructor.Surname);
            _cmd.Parameters.AddWithValue("@NumberTelefon", instructor.NumberTelefon);
            _cmd.Parameters.AddWithValue("@LevelProfisionsl", instructor.LevelProfisionsl);
            _cmd.Parameters.AddWithValue("@Sport", instructor.Sport);
            _cmd.Parameters.AddWithValue("@LevelHealth", instructor.LevelHealth);

            _cmd.ExecuteNonQuery();
        }

        public int? LoginClient(string email, string password)
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                // Убедитесь, что соединение открыто
                // Вы можете добавить код для открытия соединения здесь, если это необходимо
                return null;
            }

            string _sql = "SELECT ID_Клиента FROM [Тур-агенства].[dbo].[Клиент] WHERE Почта = @Email AND Пароль = @Password";
            SqlCommand _cmd = new SqlCommand(_sql, _connection);

            _cmd.Parameters.AddWithValue("@Email", email);
            _cmd.Parameters.AddWithValue("@Password", password);

            object result = _cmd.ExecuteScalar();

            if (result == null || result == DBNull.Value)
            {
                return null; // Возвращаем null, если результат не найден
            }

            return (int)result; // Возвращаем ID клиента
        }
        public int? LoginInstructor(string email, string password)
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                // Убедитесь, что соединение открыто
                // Вы можете добавить код для открытия соединения здесь, если это необходимо
                return null;
            }

            string _sql = "SELECT ID_Инструктора FROM [Тур-агенства].[dbo].[Инструктор] WHERE Почта = @Email AND Пароль = @Password";
            SqlCommand _cmd = new SqlCommand(_sql, _connection);

            _cmd.Parameters.AddWithValue("@Email", email);
            _cmd.Parameters.AddWithValue("@Password", password);

            object result = _cmd.ExecuteScalar();

            if (result == null || result == DBNull.Value)
            {
                return null; // Возвращаем null, если результат не найден
            }

            return (int)result; // Возвращаем ID клиента
        }


        
        public bool LoginAdmin(string email, string password)
        {
            _sql = "SELECT COUNT(*) FROM [Тур-агенства].[dbo].[Админестратор] WHERE Почта = @Email AND Пароль = @Password";
            _cmd = new SqlCommand(_sql, _connection);

            _cmd.Parameters.AddWithValue("@Email", email);
            _cmd.Parameters.AddWithValue("@Password", password);

            int count = (int)_cmd.ExecuteScalar();

            return count > 0;
        }
        public void CompletionRegion(CompletionItineraryRegionModel regionModel)
        {
            _sql = "INSERT INTO [Тур-агенства].[dbo].[Регионы] (Название_регина, Названия_страны, Близлежащий_город, Описание_региона) VALUES (@NameRegion, @NameCountry, @NearestCity, @DescriptionRegion)";
            _cmd = new SqlCommand(_sql, _connection);

            _cmd.Parameters.AddWithValue("@NameRegion", regionModel.NameRegion);
            _cmd.Parameters.AddWithValue("@NameCountry", regionModel.NameCountry);
            _cmd.Parameters.AddWithValue("@NearestCity", regionModel.NearestCity);
            _cmd.Parameters.AddWithValue("@DescriptionRegion", regionModel.DescriptionRegion);
            

            _cmd.ExecuteNonQuery();
        }
        public void CompletionLevelItinerary(CompletionItineraryLevelItineraryModel itineraryModel)
        {
            _sql = "INSERT INTO [Тур-агенства].[dbo].[Сложность_маршрута] (Уровень_сложности_маршрута, Описание) VALUES (@NameLevelItinerary,@DescriptionLevelItinerary)";
            _cmd = new SqlCommand(_sql, _connection);

            _cmd.Parameters.AddWithValue("@NameLevelItinerary", itineraryModel.NameLevelItinerary);
            _cmd.Parameters.AddWithValue("@DescriptionLevelItinerary", itineraryModel.DescriptionLevelItinerary);
           

            _cmd.ExecuteNonQuery();
        }

        public void CompletionItinerary(CompletionItineraryItineraryModel itineraryModel)
        {
            _sql = "INSERT INTO [Тур-агенства].[dbo].[Маршрут] (FK_СпМ, Название_маршрута, Колличество_дней, Киллометраж) VALUES (@FK_LevelItinerary,@NameItinerary,@CountDay,@CountKM)";
            _cmd = new SqlCommand(_sql, _connection);

            _cmd.Parameters.AddWithValue("@FK_LevelItinerary", itineraryModel.FK_LevelItinerary);
            _cmd.Parameters.AddWithValue("@NameItinerary", itineraryModel.NameItinerary);
            _cmd.Parameters.AddWithValue("@CountDay", itineraryModel.CountDay);
            _cmd.Parameters.AddWithValue("@CountKM", itineraryModel.CountKM);
           
            _cmd.ExecuteNonQuery();

            _sql = "INSERT INTO [Тур-агенства].[dbo].[Маршруты_по_регионам] (FK_Маршрута, FK_Региона) VALUES (@FK_Itinerary, @FK_Regiona)";
            _cmd = new SqlCommand(_sql, _connection);

            _cmd.Parameters.AddWithValue("@FK_Itinerary", itineraryModel.FK_Itinerary);
            _cmd.Parameters.AddWithValue("@FK_Regiona", itineraryModel.FK_Regiona);
            

            _cmd.ExecuteNonQuery();
        }

        public void CompletionPoint(CompletionPointPointModel itineraryModel)
        {
            _sql = "INSERT INTO [Тур-агенства].[dbo].[Точка] (Название_точки, Описание_точки) VALUES (@NamePoint,@DescriptionPoint)";
            _cmd = new SqlCommand(_sql, _connection);

            _cmd.Parameters.AddWithValue("@NamePoint", itineraryModel.NamePoint);
            _cmd.Parameters.AddWithValue("@DescriptionPoint", itineraryModel.DescriptionPoint);


            _cmd.ExecuteNonQuery();
        }

        public void CompletionTypePoint(CompletionPointTypePointModel itineraryModel)
        {
            _sql = "INSERT INTO [Тур-агенства].[dbo].[Типы_точек] (Название_типа, Описание_типа) VALUES (@NameTypePoint,@DescriptionTypePoint)";
            _cmd = new SqlCommand(_sql, _connection);

            _cmd.Parameters.AddWithValue("@NameTypePoint", itineraryModel.NameTypePoint);
            _cmd.Parameters.AddWithValue("@DescriptionTypePoint", itineraryModel.DescriptionTypePoint);


            _cmd.ExecuteNonQuery();
        }

        public void CompletionPointToItinerary(CompletionPointPointToItineraryModel itineraryModel)
        {
            _sql = "INSERT INTO [Тур-агенства].[dbo].[Точки_на_маршруте] (FK_Маршрута, FK_Точки, FK_Тип_точки, Дата_прибытия_в_точку, Время_прибытия_в_точку, День_прибытия_в_точку) VALUES (@FK_Itinerary, @FK_Point, @FK_TypePoint, @DateToPoint, @TimeToPoint, @DayToPoint)";
            _cmd = new SqlCommand(_sql, _connection);

            _cmd.Parameters.AddWithValue("@FK_Itinerary", itineraryModel.FK_Itinerary);
            _cmd.Parameters.AddWithValue("@FK_Point", itineraryModel.FK_Point);
            _cmd.Parameters.AddWithValue("@FK_TypePoint", itineraryModel.FK_TypePoint);
            _cmd.Parameters.AddWithValue("@DateToPoint", itineraryModel.DateToPoint);
            _cmd.Parameters.AddWithValue("@TimeToPoint", itineraryModel.TimeToPoint);
            _cmd.Parameters.AddWithValue("@DayToPoint", itineraryModel.DayToPoint);


            _cmd.ExecuteNonQuery();
        }

        public void CompletionEquipment(EquipmentModel itineraryModel)
        {
            _sql = "INSERT INTO [Тур-агенства].[dbo].[Снаряжение] (Название_снаряжения, Требования_к_уменим, Колличество_на_человека_группу) VALUES (@NameEquipment, @SkillsEquipment,@CountEquipment)";
            _cmd = new SqlCommand(_sql, _connection);

            _cmd.Parameters.AddWithValue("@NameEquipment", itineraryModel.NameEquipment);
            _cmd.Parameters.AddWithValue("@SkillsEquipment", itineraryModel.SkillsEquipment);
            _cmd.Parameters.AddWithValue("@CountEquipment", itineraryModel.CountEquipment);
          


            _cmd.ExecuteNonQuery();
        }

        public void CompletionEquipmentItinerary(EquipmentItineraryModel itineraryModel)
        {
            _sql = "INSERT INTO [Тур-агенства].[dbo].[Снаряжение_по_маршрутам] (FK_Маршрута, FK_Снаряжение) VALUES (@FK_Itinerary, @FK_Equipment)";
            _cmd = new SqlCommand(_sql, _connection);

            _cmd.Parameters.AddWithValue("@FK_Itinerary", itineraryModel.FK_Itinerary);
            _cmd.Parameters.AddWithValue("@FK_Equipment", itineraryModel.FK_Equipment);
            



            _cmd.ExecuteNonQuery();
        }

        public void CompletionMenu(MenuModel itineraryModel)
        {
            _sql = "INSERT INTO [Тур-агенства].[dbo].[Меню] (Названия_меню) VALUES (@NameMenu)";
            _cmd = new SqlCommand(_sql, _connection);

            _cmd.Parameters.AddWithValue("@NameMenu", itineraryModel.NameMenu);
           




            _cmd.ExecuteNonQuery();
        }

        public void CompletionProduct(ProductModel itineraryModel)
        {
            _sql = "INSERT INTO [Тур-агенства].[dbo].[Продукты] (Название_продукта, Цена) VALUES (@NameProduct, @Count)";
            _cmd = new SqlCommand(_sql, _connection);

            _cmd.Parameters.AddWithValue("@NameProduct", itineraryModel.NameProduct);
            _cmd.Parameters.AddWithValue("@Count)", itineraryModel.Count);




            _cmd.ExecuteNonQuery();
        }

        public void CompletionProductToMenu(ProductToMenuModel itineraryModel)
        {
            _sql = "INSERT INTO [Тур-агенства].[dbo].[Состав_меню] (FK_Продукты, FK_Меню) VALUES (@FK_Product, @FK_Menu)";
            _cmd = new SqlCommand(_sql, _connection);

            _cmd.Parameters.AddWithValue("@FK_Product", itineraryModel.FK_Product);
            _cmd.Parameters.AddWithValue("@FK_Menu)", itineraryModel.FK_Menu);




            _cmd.ExecuteNonQuery();
        }


        public void CompletionTransfer(TransferModel itineraryModel)
        {
            _sql = "INSERT INTO [Тур-агенства].[dbo].[Трансфер] (Дата, Время_начала, Время_окончания,Цена) VALUES (@Date, @TimeStart,@TimeFinish,@Prise)";
            _cmd = new SqlCommand(_sql, _connection);

            _cmd.Parameters.AddWithValue("@Date", itineraryModel.Date);
            _cmd.Parameters.AddWithValue("@TimeStart", itineraryModel.TimeStart);
            _cmd.Parameters.AddWithValue("@TimeFinish", itineraryModel.TimeFinish);
            _cmd.Parameters.AddWithValue("@Prise", itineraryModel.Prise);



            _cmd.ExecuteNonQuery();
        }

        public void CompletionExpedition(ExpeditionModel itineraryModel)
        {
            _sql = "INSERT INTO [Тур-агенства].[dbo].[Экспедиция] (FK_Маршрута, FK_Меню, FK_Снаряжение,FK_Трансфера, Колличество_порций, Колличество_снаряжения, Дата_начала, Дата_окончания) VALUES (@FK_Itinerary, @FK_Menu,@FK_Equipment, @FK_Transfera, @CounMenu, @CountEquipment, @DateStart, @DateFinish)";
            _cmd = new SqlCommand(_sql, _connection);

            _cmd.Parameters.AddWithValue("@FK_Itinerary", itineraryModel.FK_Itinerary);
            _cmd.Parameters.AddWithValue("@FK_Menu", itineraryModel.FK_Menu);
            _cmd.Parameters.AddWithValue("@FK_Equipment", itineraryModel.FK_Equipment);
            _cmd.Parameters.AddWithValue("@FK_Transfera", itineraryModel.FK_Transfera);
            _cmd.Parameters.AddWithValue("@CounMenu", itineraryModel.CounMenu);
            _cmd.Parameters.AddWithValue("@CountEquipment", itineraryModel.CountEquipment);
            _cmd.Parameters.AddWithValue("@DateStart", itineraryModel.DateStart);
            _cmd.Parameters.AddWithValue("@DateFinish", itineraryModel.DateFinish);



            _cmd.ExecuteNonQuery();
        }

        public void CompletionExpeditionToItinerary(ExspeditionToItineraryModel itineraryModel)
        {
            _sql = "INSERT INTO [Тур-агенства].[dbo].[Экспедиция_на_маршруте] (FK_Экспидиция, FK_Точки_на_маршруте, Время, Дата) VALUES (@FK_Expedition, @FK_PointToItinerary, @Time, @Date)";
            _cmd = new SqlCommand(_sql, _connection);

            _cmd.Parameters.AddWithValue("@FK_Expedition", itineraryModel.FK_Expedition);
            _cmd.Parameters.AddWithValue("@FK_PointToItinerary", itineraryModel.FK_PointToItinerary);
            _cmd.Parameters.AddWithValue("@Time", itineraryModel.Time);
            _cmd.Parameters.AddWithValue("@Date", itineraryModel.Date);
            



            _cmd.ExecuteNonQuery();
        }


    }
}
