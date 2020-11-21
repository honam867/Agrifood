using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace MSSQL
{
    public class MSSQLProvider
    {
        private string _connectionString;
        private SqlConnection _connection;

        public MSSQLProvider(
            string connectionString
            )
        {
            _connectionString = connectionString;
            //_connectionString = GetConnectionStringFromAppSetting(alias);
            _connection = new SqlConnection(_connectionString);
        }
        public int ExecuteSqlCommand(string cmd)
        {
            _connection.Open();
            SqlCommand command = new SqlCommand(cmd, _connection);
            int rowAffected = command.ExecuteNonQuery();
            _connection.Close();
            return rowAffected;
        }

        public object ValueFromQuery(string cmd)
        {
            _connection.Open();
            SqlCommand command = new SqlCommand(cmd, _connection);
            object v = command.ExecuteScalar();
            _connection.Close();
            return v;
        }

        public DataTable FromQuery(string cmd)
        {
            _connection.Open();
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand(cmd, _connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            adapter.Dispose();
            _connection.Close();
            return data;
        }

        public async Task<DataTable> FromQueryAsync(string cmd)
        {
            return await Task.Run(() =>
            {
                _connection.Open();
                DataTable data = new DataTable();
                SqlCommand command = new SqlCommand(cmd, _connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                adapter.Dispose();
                _connection.Close();
                return data;
            });
        }

        public DataRow GetById(string table, int id)
        {
            _connection.Open();
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand(String.Format("SELECT * FROM {0} WHERE Id = {1}", table, id), _connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            DataRow row = data.Rows[0];
            adapter.Dispose();
            _connection.Close();
            return row;
        }

        public DataTable GetByName(string table, string name)
        {
            _connection.Open();
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand(String.Format("SELECT * FROM {0} WHERE Name LIKE '%{1}%'", table, name), _connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            adapter.Dispose();
            _connection.Close();
            return data;
        }

        public DataTable GetByReference(string table, string reference)
        {
            _connection.Open();
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand(String.Format("SELECT * FROM {0} WHERE Reference LIKE '%{1}%'", table, reference), _connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            adapter.Dispose();
            _connection.Close();
            return data;
        }

        public static string GetConnectionStringFromAppSetting(string alias)
        {
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                                    .SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json", optional: true)
                                                    .AddJsonFile($"appsettings.{envName}.json", optional: true)
                                                    .Build();
            return configuration.GetConnectionString(alias);
        }
    }
}
