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
        // prepare the objects to be used in the layout
        lbs.ExpandableListViewAdapter listAdapter;
        ExpandableListView expListView;
        List<string> listDataHeader;
        Dictionary<string, List<string>> listDataChild;
        int previousListGruop = -1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_listview);

            // Set our objects from the "ListView" layout
            Button backButton = FindViewById<Button>(Resource.Id.button_back);
            Button searchButton = FindViewById<Button>(Resource.Id.button_search);
            expListView = FindViewById<ExpandableListView>(Resource.Id.exlistview_register);

            //  Prepare Events
            GetListData();

            //  Bind Events
            listAdapter = new lbs.ExpandableListViewAdapter(this, listDataHeader, listDataChild);
            expListView.SetAdapter(listAdapter);

            //  Click Events
            FnClickEvents();
            backButton.Click += BackButton_Click;

        }

        /*
         *  GetListData()
         *  
         *  FnClickEvents()     Open and Close the lists
         *  BackButton_Click    Go back to the main layout
         *  searchButton_Click  Searches for a list item writed in the textEditor
         */

        private void FnClickEvents()
        {
            // Listening to the child item selection
            expListView.ChildClick += delegate (object sender, ExpandableListView.ChildClickEventArgs e)
            {
                Toast.MakeText(this,"child clicked",ToastLength.Short).Show();
            };
            
            // closes a group when another group expands
            expListView.ChildClick += delegate (object sender, ExpandableListView.ChildClickEventArgs e)
            {
                if (e.GroupPosition != previousListGruop)
                    expListView.CollapseGroup(previousListGruop);
                previousListGruop = e.GroupPosition;
            };

            //  listening to group collapse
            expListView.GroupCollapse += delegate (object sender, ExpandableListView.GroupCollapseEventArgs e)
            {
                Toast.MakeText(this, "group collapsed", ToastLength.Short).Show();
            };
        }

        private void GetListData()
        {
            listDataHeader = new List<string>();
            listDataChild = new Dictionary<string, List<string>>();

            // Adding child data
            listDataHeader.Add("Sueninha Fofa");
            listDataHeader.Add("Electrocs & comm.");
            listDataHeader.Add("Mechanical");

            // Adding child data
            var lstCS = new List<string>();
            lstCS.Add("Baixinha");
            lstCS.Add("Cabelo Longo");
            lstCS.Add("Gotosa");
            lstCS.Add("Inteligente");
            lstCS.Add("Bonita");
            lstCS.Add("Interessante");

            var lstEC = new List<string>();
            lstEC.Add("Field Theory");
            lstEC.Add("Logic Design");
            lstEC.Add("Analog electronics");
            lstEC.Add("Network analysis");
            lstEC.Add("Micro controller");
            lstEC.Add("Signals and system");

            var lstMech = new List<string>();
            lstMech.Add("Instrumentation technology");
            lstMech.Add("Dynamics of machinnes");
            lstMech.Add("Energy engineering");
            lstMech.Add("Design of machine");
            lstMech.Add("Turbo machine");
            lstMech.Add("Energy conversion");

            // Header, Child data
            listDataChild.Add(listDataHeader[0], lstCS);
            listDataChild.Add(listDataHeader[1], lstEC);
            listDataChild.Add(listDataHeader[2], lstMech);
        }


        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}