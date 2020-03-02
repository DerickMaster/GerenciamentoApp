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
         *  CreateTable() - Receives a table name and if it doesn't exist create it in the MySql database
         */
        public void CreateTable(string tableName)
        {
            string sqlServerPath = srvConnection.sqlBuilder.ToString();
            MySqlConnection sqlConnection = new MySqlConnection(sqlServerPath);

            if (tableName == null)
            {
                
                tableName = "lista_default";
            }

            string sqlCommandLine = ("CREATE TABLE " + tableName + " ( name VARCHAR(40), cpf VARCHAR(15), dateAndHour DATETIME, dateOfBirth DATE, cellphone VARCHAR(20) );");

            cmdOperation = new MySqlCommand(sqlCommandLine);
            Toast.MakeText(Application.Context, "Table Created!", ToastLength.Long).Show();
            try
            {
                cmdOperation.Connection = sqlConnection;
                sqlConnection.Open();
                cmdOperation.ExecuteReader();
                cmdOperation.Connection.Close();
            }
            catch (Exception ex)
            {
                Toast.MakeText(Application.Context, "ERROR:" + ex, ToastLength.Long).Show();
            }
        }

        /*
         *  allTableItens receiver a table name and create a portable table matriz
         *  return: a table matriz with all table data
         */
        public List<List<string>> allTableItens(string tableName)
        {
            int numberOfRow;
            int counter = 0;
            string sqlServerPath = srvConnection.sqlBuilder.ToString();
            List<List<string>> colPosition = new List<List<string>>();
            
            MySqlConnection sqlConnection = new MySqlConnection(sqlServerPath);
            cmdOperation = new MySqlCommand("SELECT COUNT(*) FROM " + tableName);
            MySqlDataReader rdr = null;

            numberOfRow = numberOfRows(tableName);


            while (counter < numberOfRow)
            {
                cmdOperation = new MySqlCommand("SELECT name, ID, dateOfBirth, dateAndHour, cpf, cellphone FROM "+ tableName + " LIMIT " + counter + ", 1");
                cmdOperation.Connection = sqlConnection;
                cmdOperation.Connection.Open();
                rdr = cmdOperation.ExecuteReader();
                rdr.Read();
                List<string> rowItens = new List<string>();
                rowItens.Add(rdr["name"].ToString());
                rowItens.Add(rdr["ID"].ToString());
                rowItens.Add(rdr["cpf"].ToString());
                rowItens.Add(rdr["dateOfBirth"].ToString());
                rowItens.Add(rdr["cellphone"].ToString());
                rowItens.Add(rdr["dateAndHour"].ToString());

                colPosition.Add(rowItens);

                counter++;
                cmdOperation.Connection.Close();
            }
            cmdOperation.Connection.Close();
            sqlConnection.Close();
            return colPosition;
        }

        public int numberOfRows(string tableName)
        {

            string sqlServerPath = srvConnection.sqlBuilder.ToString();
            List<List<string>> colPosition = new List<List<string>>();

            cmdOperation = new MySqlCommand("SELECT * FROM " + tableName);
            MySqlDataReader rdr = null;

            using (MySqlConnection sqlConnection = new MySqlConnection(sqlServerPath))
            {
                using( cmdOperation = new MySqlCommand("SELECT COUNT(*) FROM " + tableName, sqlConnection))
                {

                    cmdOperation.Connection = sqlConnection;
                    cmdOperation.Connection.Open();
                    long count = (long)cmdOperation.ExecuteScalar();
                    return (int)count;
                }
            }
        }

        /*
         *  RegisterIntoDatabase() - Read a row of itens and write them in the specified tabbleNAme
         */
        public void RegisterIntoDatabase(TableItens itens, string tableName)
        {
            string sqlServerPath = srvConnection.sqlBuilder.ToString();
            MySqlConnection sqlConnection = new MySqlConnection(sqlServerPath);

           
            string sqlCommandString = ("INSERT INTO " + tableName + " ( name, dateOfBirth, dateAndHour, cpf, cellphone) VALUES ( \""+itens.name+"\", \""+itens.dateOfBirth.ToString("yyyy-MM-dd") + "\", \""+itens.dateAndHour.ToString("yyyy-MM-dd HH:mm:ss") +"\", \""+itens.cpf+ "\",  \""+itens.cellphone+"\" );");
            cmdOperation = new MySqlCommand(sqlCommandString);

            try
            {
                cmdOperation.Connection = sqlConnection;
                sqlConnection.Open();
                cmdOperation.ExecuteReader();
                cmdOperation.Connection.Close();
                Toast.MakeText(Application.Context, "Dados Inseridos com Sucesso", ToastLength.Long).Show();
            }
            catch (Exception ex){
                Toast.MakeText(Application.Context, "ERROR:" + ex, ToastLength.Long).Show();
            }
        }

        /*
         *  stringToDate() - receives a string writed similar to the DateTime local culture
         *  Returns: a DateTime formated in the local culture date
         */
        public DateTime stringToDate(string birthDate)
        {
            DateTime oDate = DateTime.ParseExact(birthDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            return oDate;
        }
    }
}