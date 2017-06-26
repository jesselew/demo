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
using epos.Droid.ViewModels;
using Java.Lang;

namespace epos.Droid.Adapters
{
    public class MemberListAdapter : BaseAdapter<MemberListItem>
    {
        private Context _context;
        private List<MemberListItem> _items;
        public MemberListAdapter(Context context, List<MemberListItem> items)
        {
            _context = context;
            _items = items;
        }

        public override int Count => _items.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override MemberListItem this[int position] => _items[position];

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(_context).Inflate(Resource.Layout.MemberListItem, null, false);
            }

            var txtPhone = row.FindViewById<TextView>(Resource.Id.txtPhone);
            var txtName = row.FindViewById<TextView>(Resource.Id.txtName);

            txtPhone.Text = _items[position].Phone;
            txtName.Text = _items[position].Name;

            return row;
        }
    }

}