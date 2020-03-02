using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace GerenciamentoApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.Design.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Connection Methods

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Set our buttons from the "main" layout resource
            Button addButton = FindViewById<Button>(Resource.Id.button_addnames);
            Button removeButton = FindViewById<Button>(Resource.Id.button_removenames);
            Button showListButton = FindViewById<Button>(Resource.Id.button_showlist);

            // Set click functions from the buttons
            addButton.Click += AddButton_Click;
            removeButton.Click += RemoveButton_Click;
            showListButton.Click += ShowListButton_Click;

        }

        /*
         *  ShowListButton_Click
         *  RemoveButton_Click
         *  AddButton_Click
         */

        private void ShowListButton_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(ListViewActivity));
        }

        private void RemoveButton_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(RegisterActivity));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}