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
        public string connectionData = "SERVER=mysql873.umbler.com; DATABASE=register_app_db; UID=derickmaster; PWD=senhasenha123; PORT=41890";
        public MySqlConnection sqlConnection = null;
        public MySqlCommand cmdOperation = null;

        public string sqlTableName;
        public string sqlColName;
        public List<string> sqlColsNames;

        /*
         *  CreateTable() - Read the rows in a selected Col and returns it in a list
         *  receives : tabbleName
         */
        public void CreateTable(string tabbleName)
        {
            if (tabbleName == null)
            {
                tabbleName = "appTable_01";
            }

            cmdOperation = new MySqlCommand("CREATE TABBLE " + tabbleName + " ( name VARCHAR[40] NOT NULL, cpf VARCHAR[15] NOT NULL, dateAndHour VARCHAR[20] NOT NULL, dateOfBirth VARCHAR[20] NOT NULL, cellphone VARCHAR[20] NOT NULL");

            try
            {
                cmdOperation.ExecuteReader();
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
        public List<List<string>> LoadRowsOfACol()
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