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

namespace GerenciamentoApp
{
    [Activity(Label = "AddNameActivity")]
    public class AddNameActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our layout from "AddName"
            SetContentView(Resource.Layout.activity_register);
        }
    }
}