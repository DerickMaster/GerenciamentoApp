using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GerenciamentoApp.lbs
{
    class TableItens
    {
        public string name { get; set; }
        public string cpf { get; set; }
        public DateTime dateOfBirth { get; set; }
        public DateTime dateAndHour { get; set; }
        public string cellphone { get; set; }

    }
}