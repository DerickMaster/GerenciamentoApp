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
    [Activity(Label = "ListViewActivity")]
    public class ListViewActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);



            // Set our view from the "ListView" layout resource
            SetContentView(Resource.Layout.activity_listview);

            // Set our buttons from the "ListView" layout resource
            Button backButton = FindViewById<Button>(Resource.Id.button_back);
            Button searchButton = FindViewById<Button>(Resource.Id.button_search);

            ExpandableListView appExListView = FindViewById<ExpandableListView>(Resource.Id.exlistview_register);

            // Set our Click
            backButton.Click += BackButton_Click;

           
    

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}