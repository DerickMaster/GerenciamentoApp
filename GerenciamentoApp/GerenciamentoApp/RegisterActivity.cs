using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace GerenciamentoApp
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {

        lbs.DatabaseOperations srvDatabase = new lbs.DatabaseOperations();
        lbs.TableItens itensToRegister = new lbs.TableItens();
        string tabbleName = "lista_default";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our layout from "RegisterActivity"
            SetContentView(Resource.Layout.activity_register);

            // Set our Widgets
            Button btn_Register = FindViewById<Button>(Resource.Id.button_register);


            // Set Click Events
            btn_Register.Click += Btn_Register_Click;
        }

        private void Btn_Register_Click(object sender, EventArgs e)
        {
            // Set our editText wdigets
            EditText name = FindViewById<EditText>(Resource.Id.editText_name);
            EditText cpf = FindViewById<EditText>(Resource.Id.editText_cpf);
            EditText cellphone = FindViewById<EditText>(Resource.Id.editText_cellphone);
            EditText birthDate = FindViewById<EditText>(Resource.Id.editText_birthDate);

            // Write our texts into the TableItens
            itensToRegister.name = name.Text;
            itensToRegister.cpf = cpf.Text;
            itensToRegister.cellphone = cellphone.Text;
            itensToRegister.dateAndHour = DateTime.Now;

            bool sucessfulConversion = true;

            try
            {
                itensToRegister.dateOfBirth = srvDatabase.strintToDate(birthDate.Text);
            }
            catch (Exception){
                Toast.MakeText(Application.Context, "ERRO: Data digitada incorretamente", ToastLength.Long).Show();
                sucessfulConversion = false;
            }

            // Checks if the date was writed correctly or if the user is under 18 years
            if(sucessfulConversion == true)
            {
                var today = DateTime.Today;
                var age = today.Year - itensToRegister.dateOfBirth.Year;
                if (itensToRegister.dateOfBirth > today.AddYears(-age)) age--;

                if (age >= 18)
                {
                    srvDatabase.RegisterIntoDatabase(itensToRegister, tabbleName);
                } else {
                    Toast.MakeText(Application.Context, "ERRO: Usuário com menos de 18 anos", ToastLength.Long).Show();
                }

            }

        }
        // Datapicker Functions

    }
}

