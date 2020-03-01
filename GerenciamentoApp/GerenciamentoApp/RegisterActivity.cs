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
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {

        List<string> test = new List<string>
        {
            "teste", "teste", "teste", "teste"
        };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_register);

            ListView registerListView = FindViewById<ListView>(Resource.Id.listView_register);

            lbs.ListAdapter registerListAdapter = new lbs.ListAdapter(this, test);

            registerListView.Adapter = registerListAdapter;
            // Create your application here
        }
    }
}