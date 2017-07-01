using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace epos.Droid.Fragments
{
    public class AddMember_PhoneFragment : DialogFragment
    {

        public event EventHandler<string> OnNewMemberPhoneCompleted;
        private Button btnNext;
        private EditText editTextPhone;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.NewMember_Phone, container, false);

            btnNext = view.FindViewById<Button>(Resource.Id.btnNewMemberNext);
            editTextPhone = view.FindViewById<EditText>(Resource.Id.editTextNewMemberPhone);

            editTextPhone.AfterTextChanged += TxtviewPhone_AfterTextChanged;

            btnNext.Click += BtnNext_Click;
            btnNext.Enabled = false;

            return view;
        }

        private void TxtviewPhone_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            btnNext.Enabled = editTextPhone.Length() == 11;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (OnNewMemberPhoneCompleted != null)
            {
                var phone = editTextPhone.Text;
                OnNewMemberPhoneCompleted.Invoke(this, phone);
            }
        }
    }
}