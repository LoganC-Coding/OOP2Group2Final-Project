using Microsoft.Extensions.Configuration;
using MauiApp1.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace MauiApp1.Services
{
    public class TableService
    {
        private readonly IConfiguration _configuration;

        public TableService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<TableModel>> GetMainFloorTablesAsync()
        {
            var tables = new List<TableModel>();
            string sql = "SELECT table_id, seats, is_reserved FROM `Table` WHERE table_id BETWEEN 1 AND 11 ORDER BY table_id;";

            // --- SOLUTION for CS8600 implication ---
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                Debug.WriteLine("Error: Connection string 'DefaultConnection' not found or is empty in configuration.");
                // Throw an exception or return empty list to signal configuration error
                // throw new InvalidOperationException("Database connection string is not configured.");
                return new List<TableModel>(); // Return empty for simplicity
            }
            // --- End Null Check ---

            try
            {
                await using var connection = new MySqlConnection(connectionString);
                await connection.OpenAsync();

                await using var command = new MySqlCommand(sql, connection);
                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    tables.Add(new TableModel
                    {
                        // Using Convert with indexer based on previous correction
                        TableId = Convert.ToInt32(reader["table_id"]),
                        Seats = Convert.ToInt32(reader["seats"]),
                        IsReserved = Convert.ToBoolean(reader["is_reserved"])
                    });
                }
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine($"MySQL Error fetching tables: {ex.Message}");
                return new List<TableModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Generic Error fetching tables: {ex.Message}");
                return new List<TableModel>();
            }

            return tables;
        }
    }
}