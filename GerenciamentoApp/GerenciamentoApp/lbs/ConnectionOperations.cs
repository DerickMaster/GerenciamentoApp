using Android.App;
using Android.Widget;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GerenciamentoApp.lbs
{
    class ConnectionOperations
    {

        public MySqlConnectionStringBuilder sqlBuilder = new MySqlConnectionStringBuilder();

        public ConnectionOperations()
        {
            sqlBuilder.Server = "mysql873.umbler.com";
            sqlBuilder.Database = "register_app_db";
            sqlBuilder.Port = 41890;
            sqlBuilder.UserID = "derickmaster";
            sqlBuilder.Password = "senhasenha123";
        }

        public void TryConnection()
        {

            try
            {
                MySqlConnection sqlConnection = new MySqlConnection(sqlBuilder.ToString());
                sqlConnection.Open();
                Toast.MakeText(Application.Context, "SUCESS", ToastLength.Long).Show();
                //return true;
            }
            catch (Exception ex)
            {
                Toast.MakeText(Application.Context, "ERROR" + ex, ToastLength.Long).Show();
                //return false;
            }
        }
    }
}