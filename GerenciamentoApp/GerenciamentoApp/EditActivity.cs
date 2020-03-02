using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace GerenciamentoApp
{
    [Activity(Label = "EditActivity")]
    public class EditActivity : Activity
    {

        lbs.DatabaseOperations srvDatabase = new lbs.DatabaseOperations();
        lbs.TableItens itensToEdit = new lbs.TableItens();
        string tabbleName = "lista_default";


        protected override void OnCreate(Bundle savedInstanceState)
        {
            EditText name = FindViewById<EditText>(Resource.Id.editText2_name);
            EditText cpf = FindViewById<EditText>(Resource.Id.editText2_cpf);
            EditText cellphone = FindViewById<EditText>(Resource.Id.editText2_cellphone);
            EditText birthDate = FindViewById<EditText>(Resource.Id.editText2_birthDate);


            //List<string> cpfFinderRow = new List<string>();
            //cpfFinderRow = ListViewActivity.CpfFinderTable(int );
            //int ifunction = Intent.GetIntExtra("i", i);

            //name.Hint = cpfFinderTable;
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_edit);

            // Set our Widgets
            Button btn_edit = FindViewById<Button>(Resource.Id.button_edit);


            // Set Click Events
            btn_edit.Click += Btn_edit_Click;
        }

        private void Btn_edit_Click(object sender, EventArgs e)
        {
            // Set our editText wdigets
            EditText name = FindViewById<EditText>(Resource.Id.editText2_name);
            EditText cpf = FindViewById<EditText>(Resource.Id.editText2_cpf);
            EditText cellphone = FindViewById<EditText>(Resource.Id.editText2_cellphone);
            EditText birthDate = FindViewById<EditText>(Resource.Id.editText2_birthDate);

            // Write our texts into the TableItens
            itensToEdit.name = name.Text;
            itensToEdit.cpf = cpf.Text;
            itensToEdit.cellphone = cellphone.Text;
            itensToEdit.dateAndHour = DateTime.Now;

            bool sucessfulConversion = true;

            try
            {
                itensToEdit.dateOfBirth = srvDatabase.stringToDate(birthDate.Text);
            }
            catch (Exception)
            {
                Toast.MakeText(Application.Context, "ERRO: Data digitada incorretamente", ToastLength.Long).Show();
                sucessfulConversion = false;
            }

            // Checks if the date was writed correctly or if the user is under 18 years
            if (sucessfulConversion == true)
            {
                var today = DateTime.Today;
                var age = today.Year - itensToEdit.dateOfBirth.Year;
                if (itensToEdit.dateOfBirth > today.AddYears(-age)) age--;

                if (age >= 18)
                {
                    srvDatabase.RegisterIntoDatabase(itensToEdit, tabbleName);
                }
                else
                {
                    Toast.MakeText(Application.Context, "ERRO: Usuário com menos de 18 anos", ToastLength.Long).Show();
                }

            }

        }
    }
}