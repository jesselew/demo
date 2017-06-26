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
using epos.Droid.Fragments;

namespace epos.Droid
{
    [Activity(Label = "NewMemberInfoActivity",MainLauncher = true)]
    public class NewMemberInfoActivity : Activity
    {
        TextView txtViewBirth;
        TextView txtViewBirthValue;
        TextView txtViewRemark;
        Models.MemberInfo memberInfo;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.NewMember_Info);

            txtViewBirth = FindViewById<TextView>(Resource.Id.txtViewBirth);
            txtViewBirthValue = FindViewById<TextView>(Resource.Id.txtViewBirthValue);
            txtViewRemark = FindViewById<TextView>(Resource.Id.txtViewRemark);

            txtViewRemark.Click += TxtViewRemark_Click;
            txtViewBirth.Click += TxtViewBirth_Click;
            memberInfo = new Models.MemberInfo();
        }

        private void TxtViewRemark_Click(object sender, EventArgs e)
        {
            var remarkActivity = new Intent(this, typeof(MultiLineContentActivity));
            remarkActivity.PutExtra("maxLength", 200);

            StartActivityForResult(remarkActivity,1001);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 1001)
            {
                memberInfo.Remark = data.GetStringExtra("content");
                txtViewRemark.Text = memberInfo.Remark;
            }
        }

        private void TxtViewBirth_Click(object sender, EventArgs e)
        {
            if (memberInfo.Birth == null)
                memberInfo.Birth = new DateTime(1990, 1, 1);

            var frag = MyDatePickerFragment.NewInstance(memberInfo.Birth, delegate (DateTime time)
            {
                txtViewBirthValue.Text = time.ToString("yyyy年MM月dd日");
                memberInfo.Birth = time;
            });

            frag.Show(FragmentManager, "member_birth");
        }
    }
}