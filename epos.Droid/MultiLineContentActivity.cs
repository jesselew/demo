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

namespace epos.Droid
{
    [Activity(Label = "MultiLineContentActivity")]
    public class MultiLineContentActivity : Activity
    {
        EditText editTxtContent;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MultiText);

            var title = Intent.GetStringExtra("title");
            var maxLength = Intent.GetIntExtra("maxLength",200);
            var content = Intent.GetStringExtra("content");

            var toolbar = FindViewById<Toolbar>(Resource.Id.multiTextToolbar);
            editTxtContent = FindViewById<EditText>(Resource.Id.editTxtMulti);
            editTxtContent.Text = content;

            SetActionBar(toolbar);

            ActionBar.Title = title;
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.saveMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            ReturnBack();
        }

        private void ReturnBack()
        {
            var intent = new Intent(this, CallingActivity.GetType());
            intent.PutExtra("content", editTxtContent.Text);
            SetResult(Result.Ok, intent);
            Finish();

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            if(item.ItemId == Resource.Id.menu_save)
            {
                ReturnBack();
            }

            return base.OnOptionsItemSelected(item);

           
        }
    }
}