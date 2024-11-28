using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;    // to connect with database in this project (in resourses folder) __NOT RECOMMENDED__
// because it not security, i test and will change it after
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

namespace AuctionWeb.Pages;

public class ConnectModel : PageModel
{
    public List<string>? statusUserList { get; set; }
    public List<string>? infoUserList { get; set; }
    public List<string>? productList { get; set; } // create list to test data in database
    public List<string>? transactionList { get; set; }
    public List<string>? tempRowList { get; set; }
    public List<List<string>>? resultList { get; set; }

    private readonly ILogger<IndexModel> _logger;

    public ConnectModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    private List<List<string>> getAllDataTable(User user, string keyWord)
    {
        resultList = new List<List<string>>();
        tempRowList = new List<string>();

        try
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "../resources/database/auctionWebData.db";

            var connectionString = connectionStringBuilder.ConnectionString;

            using ( var connection = new SqliteConnection(connectionString))    // connect database in dicrect
            {
                connection.Open();   // establish connection

                var command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM {keyWord}";  // take data in table product

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int fieldCount = reader.FieldCount; // take column in table

                        for (int i = 0; i < fieldCount; i++)
                        {
                            tempRowList.Add(reader.GetString(i));
                        }
                        resultList.Add(tempRowList);  // get data each row into column 
                    }
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,"An error occurred while querying the database.");
        }
        return resultList;
    }
}
