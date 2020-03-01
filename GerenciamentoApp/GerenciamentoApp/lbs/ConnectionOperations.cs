using Android.App;
using Android.Widget;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GerenciamentoApp.lbs
{
    class ConnectionOperations
    {

        //  Prepare the sqlServer Connection
        private string connectionData = "SERVER=mysql873.umbler.com; DATABASE=register_app_db; UID=derickmaster; PWD=senhasenha123; PORT=41890";
        private MySqlConnection sqlConnection = null;
      
        /*
         * OpenConnection()     Tries to connect into the MySql server database
         * CloseConnection()    Closes the connection into the MySql server database
         */
        public void OpenConnection()
        {
            try
            {
                sqlConnection = new MySqlConnection(connectionData);
                sqlConnection.Open(); 
            }
            catch (Exception ex)
            {
                Toast.MakeText(Application.Context, "ERROR:" + ex, ToastLength.Long).Show();
            }
        }
        public void CloseConnection()
        {
            try
            {
                sqlConnection = new MySqlConnection(connectionData);
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Toast.MakeText(Application.Context, "ERROR:" + ex, ToastLength.Long).Show();
            }
        }
    }
}