using Android.App;
using Android.Widget;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GerenciamentoApp.lbs
{
    class DatabaseOperations
    {
        //  Prepare the sqlServer Connection
        ConnectionOperations srvConnection = new ConnectionOperations();
        public MySqlCommand cmdOperation = null;
        

        /*
         *  CreateTable() - Read the rows in a selected Col and returns it in a list
         *  receives : tabbleName
         */
        public void CreateTable(string tableName)
        {
            string sqlServerPath = srvConnection.sqlBuilder.ToString();
            MySqlConnection sqlConnection = new MySqlConnection(sqlServerPath);

            if (tableName == null)
            {
                
                tableName = "lista_padrão";
            }

            // send a "CREATE TABLE" query into the app MySql database
            string sqlCommandLine = ("CREATE TABLE " + tableName + " ( name VARCHAR(40), cpf VARCHAR(15), dateAndHour VARCHAR(20), dateOfBirth VARCHAR(20), cellphone VARCHAR(20) );");

            cmdOperation = new MySqlCommand(sqlCommandLine);
            Toast.MakeText(Application.Context, "Table Created!", ToastLength.Long).Show();
            try
            {
                cmdOperation.Connection = sqlConnection;
                sqlConnection.Open();
                cmdOperation.ExecuteReader();
                cmdOperation.Connection.Close();
                //Toast.MakeText(Application.Context, "pipoca gostosa", ToastLength.Long).Show();
            }
            catch (Exception ex)
            {
                //Toast.MakeText(Application.Context, "lllllkkkkkkkkkkkkkkkkkkkkkkkk:" + ex, ToastLength.Long).Show();
            }
        }

        /*
         *  LoadRowsOfACol() - Read the rows in a selected Col and returns it in a list 
         *  Returns: A List with the col rows itens
         */
        public List<List<string>> LoadRowsOfACol(string sqlColName, string sqlTableName)
        {
            cmdOperation = new MySqlCommand("SELECT" + sqlColName + " FROM " + sqlTableName);

            try
            {
                MySqlDataReader db_reader = null;
                db_reader = cmdOperation.ExecuteReader();
                List<List<string>> colLists = new List<List<string>>();
                int counter = 0;

                while (db_reader.Read())
                {
                    List<string> rowsList = new List<string>();
                    TableItens colItems = new TableItens();

                    colItems.name = db_reader["name"].ToString();
                    colItems.cpf = db_reader["cpf"].ToString();
                    colItems.dateOfBirth = db_reader["dateOfBirth"].ToString();
                    colItems.dateAndHour = db_reader["dateAndHour"].ToString();
                    colItems.cellphone = db_reader["cellphone"].ToString();

                    rowsList.Add(colItems.name);
                    rowsList.Add(colItems.cpf);
                    rowsList.Add(colItems.dateOfBirth);
                    rowsList.Add(colItems.dateAndHour);
                    rowsList.Add(colItems.cellphone);

                    colLists[counter] = rowsList;
                    counter = counter + 1;
                }

                return colLists;

            }
            catch (Exception ex)
            {
                Toast.MakeText(Application.Context, "ERROR:" + ex, ToastLength.Long).Show();
                return null;
            }

        }
    }
}