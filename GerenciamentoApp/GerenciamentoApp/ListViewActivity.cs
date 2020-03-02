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

        //connection aplications
        lbs.ConnectionOperations srvConnection = new lbs.ConnectionOperations();
        lbs.DatabaseOperations srvDatabase = new lbs.DatabaseOperations();

        // prepare the objects to be used in the layout
        lbs.ExpandableListViewAdapter listAdapter;
        ExpandableListView expListView;
        List<string> listDataHeader = new List<string>();
        List<List<string>> tableItens = new List<List<string>>();

        string tableName = "lista_default";

        Dictionary<string, List<string>> listDataChild;
        int previousListGruop = -1;
        private string newTableItem;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // If doesn't exist, creates a default table to be acessed by the listView
            srvDatabase.CreateTable(null);

            SetContentView(Resource.Layout.activity_listview);

            // Set our objects from the "ListView" layout
            // Button backButton = FindViewById<Button>(Resource.Id.button_back);
            Button searchButton = FindViewById<Button>(Resource.Id.button_search);

            expListView = FindViewById<ExpandableListView>(Resource.Id.exlistview_register);

            //  Prepare Events
            GetListData();

            //  Bind Events
            listAdapter = new lbs.ExpandableListViewAdapter(this, listDataHeader, listDataChild);
            expListView.SetAdapter(listAdapter);

            tableItens = srvDatabase.allTableItens(tableName);

            FnClickEvents();



        }

        /*
         *  GetListData()       Pick up the database list itens and put in the expandable ListView
         *  
         *  FnClickEvents()     Open and Close the lists
         *  searchButton_Click  Searches for a "cpf" item writed in the textEditor
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
            listDataChild = new Dictionary<string, List<string>>();
            List<string> childData = new List<string>();
            string insertTable;
            tableItens = srvDatabase.allTableItens(tableName);

            int tableNumberOfRows = srvDatabase.numberOfRows(tableName);
            int counter = 0;

            while (counter < tableNumberOfRows)
            {
                listDataHeader.Add(tableItens[counter][0]);
                counter++;
            }
            
            counter = 0;
            //     Adding child data
            while (counter < tableNumberOfRows-1)
            {
                childData = new List<string>();
                for (int i=0; i < 6; i++)
                {
                    childData.Add(tableItens[counter][i]);
                }
                listDataChild.Add(listDataHeader[counter], childData);
                counter++;
            }
            
            
        }
    }
}