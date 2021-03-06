﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using epos.Droid.Adapters;
using epos.Droid.Service;
using System.Collections.Generic;
using System.Linq;
using epos.Droid.ViewModels;

namespace epos.Droid
{
    [Activity(Label = "epos.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ListView mListView;
        IDataService mDataService;
        MemberListAdapter mAdapter;
        Button btnAddMember;
        Toolbar mListToolbar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            mDataService = new SQLiteDataService();
            var newMemberId = mDataService.AddMember(new Models.MemberInfo { AccountId = 1, MemberId = 1, Name = "jesse", Phone = "18502138674" });

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MemberList);

            
            mListView = FindViewById<ListView>(Resource.Id.memberListView);

            var members = mDataService.GetMemberList(1).Select(m =>
            new MemberListItem { AccountId = m.AccountId, Id = m.MemberId, Name = m.Name, Phone = m.Phone }).ToList();

            mAdapter = new MemberListAdapter(BaseContext, members);
            mListView.Adapter = mAdapter;

            // 创建会员事件
            btnAddMember = FindViewById<Button>(Resource.Id.btnAddMember);
            btnAddMember.Click += BtnAddMember_Click;

            mListToolbar = FindViewById<Toolbar>(Resource.Id.newMemberListToolbar);
            SetActionBar(mListToolbar);


        }

        private void BtnAddMember_Click(object sender, EventArgs e)
        {
            var transaction = FragmentManager.BeginTransaction();
            var newMemberPhone = new Fragments.AddMember_PhoneFragment();

            newMemberPhone.OnNewMemberPhoneCompleted += NewMemberPhone_OnNewMemberPhoneCompleted;
            newMemberPhone.Show(transaction, "newMember_phone");
        }

        private void NewMemberPhone_OnNewMemberPhoneCompleted(object sender, string e)
        {
            var newMemberInfo = new Intent(this,typeof(NewMemberInfoActivity));
            newMemberInfo.PutExtra("phone", e);
            StartActivityForResult(newMemberInfo,1);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if(requestCode==1)
            {
                var content = data.GetStringExtra("content");
                Toast.MakeText(this, content, ToastLength.Long);
            }
        }
    }
}

