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
                
                tableName = "lista_default";
            }

            // send a "CREATE TABLE" query into the app MySql database
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
         *  LoadRowsOfACol() - Read the rows in a selected Col and returns it in a list 
         *  Returns: A List with the col rows itens
         */
        public List<List<string>> LoadRowsOfACol(string sqlTableName)
        {
            cmdOperation = new MySqlCommand("SELECT * FROM " + sqlTableName);

                return null;

        }

        // RegisterIntoDatabase receives a Tabble of itens and the name of the 
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

        public DateTime strintToDate(string birthDate)
        {
            DateTime oDate = DateTime.ParseExact(birthDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            return oDate;
        }
    }
}