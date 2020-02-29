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
    class ExpandableListViewAdapter : BaseExpandableListAdapter
    {

        /*
         *  listContext      refeers to the context of the list
         *  listDataHeader   refeers to the header titles of the list
         *  Dictionaty       refeers to the child of the header to be displayed
        */
        private Activity listContext;
        private List<string> listDataHeader;
        private Dictionary<string, List<string>> listChildData;


        //  ExpandableListViewAdapter function write the source objects into the class
        public ExpandableListViewAdapter(Activity _listContext, List<string> _listDataHeader, Dictionary<System.String, List<string>> _listChildData)
        {
            listContext = _listContext;
            listDataHeader = _listDataHeader;
            listChildData = _listChildData;
        }

        // For refeers to the child itens of the list
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
                convertView = listContext.LayoutInflater.Inflate(Resource.Layout.model_expandableList);
            }

            TextView expListChild = convertView.FindViewById<TextView>(Resource.Id.exTextView_listItem);
            expListChild.Text = childText;
            return convertView;
        }
       
        public override int GetChildrenCount(int groupPosition)
        {
            return listChildData[listDataHeader[groupPosition]].Count;
        }

        /*
        *
        */

        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            return listDataHeader[groupPosition];
        }

        public override int GroupCount
        {
            get { return listDataHeader.Count; }
        }

        public override long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }

        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            string listHeaderTitle = (string)GetGroup(groupPosition);

            convertView = convertView ?? listContext.LayoutInflater.Inflate(Resource.Layout.model_expandibleListHeader, null);
            var expListHeader = convertView.FindViewById<TextView>(Resource.Id.exTextView_listHeader);
            expListHeader.Text = listHeaderTitle;

            return convertView;
        }

        public override bool HasStableIds
        {
            get { return false; }
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }

        class ViewholderItem : Java.Lang.Object{}
    }
}