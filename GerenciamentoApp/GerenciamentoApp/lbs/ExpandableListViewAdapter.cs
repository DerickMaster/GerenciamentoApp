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
    class ExpandableListViewAdapter : BaseExpandableListAdapter;
    {

        /*
         *  listContext      refeers to the context of the list
         *  listDataHeader   refeers to the header titles of the list
         *  Dictionaty       refeers to the child of the header to be displayed
        */
        private Activity listContext;
        private List<string> listDataHeader;
        private Dictionary<string, List<string>> listChildData;

        //  Start our class functions bellow

        //  ExpandableListViewAdapter function write the source objects into the class
        public ExpandableListViewAdapter(Activity _listContext, List<string> _listDataHeader, Dictionary<System.String, List<string>> _listChildData)
        {
            listContext = _listContext;
            listDataHeader = _listDataHeader;
            listChildData = _listChildData;
        }

        // GetChild, GetChildID and Get Child View refeers to the child item view of the list
        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            return listChildData[listDataHeader[groupPosition]][childPosition];
        }

        public override long GetChildId(int groupPosition, int childPosition)
        {
            return childPosition;
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            string childText = (string)GetChild(groupPosition, childPosition);
            if (convertView == null){
                convertView = listContext.LayoutInflater.Inflate(Resource.Layout.model_expandableListLayout);
            }

            TextView expListChild = convertView.FindViewById<TextView>(Resource.Id.exTextView_listItem);
            expListChild.Text = childText;
            return convertView

        }




    }
}