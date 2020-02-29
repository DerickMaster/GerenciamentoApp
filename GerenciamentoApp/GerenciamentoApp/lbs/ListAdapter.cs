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
    class ListAdapter : BaseAdapter<string>
    {
        /*  
         *  appList refeers to [insert]
         *  appListContext refeers to [insert]  
        */
        private List<string> appList;
        private Context appListContext;

        public ListAdapter(Context listContext, List<string> listItens)
        {
            appList = listItens;
            appListContext = listContext;
        }

        //  Function that returns the app.List itens count
        public override int Count
        {
            get { return appList.Count; }
        }

        //  Function that returns a itemID position
        public override long GetItemId(int position)
        {
            return position;
        }

        //  Function that returns a item in the position;
        public override string this[int position]
        {
            get { return appList[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View listLine = convertView;

            if (listLine == null)
            {
                listLine = LayoutInflater.From(appListContext).Inflate(Resource.Layout.model_expandableListItemLayout, null, false);
            }

            TextView itemTextName = listLine.FindViewById<TextView>(Resource.Id.text_personName);
            itemTextName.Text = appList[position];

            return listLine;
        }

        

    }
}