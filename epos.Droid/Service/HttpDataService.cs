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
using epos.Droid.Models;


namespace epos.Droid.Service
{
    public class HttpDataService : IDataService
    {
        public int AddMember(MemberInfo member)
        {
            throw new NotImplementedException();
        }

        public string GetAuthCode(string phone)
        {
            throw new NotImplementedException();
        }

        public MemberInfo GetMember(int accountId, int memberId)
        {
            throw new NotImplementedException();
        }

        public List<MemberInfo> GetMemberList(int accountId)
        {
            throw new NotImplementedException();
        }

        public List<MemberInfo> GetMemberList(int accountId, string query)
        {
            throw new NotImplementedException();
        }

        public void UpdateMemberBirth(int accountId, int memberId, DateTime birth)
        {
            throw new NotImplementedException();
        }

        public void UpdateMemberGender(int accountId, int memberId, int gender)
        {
            throw new NotImplementedException();
        }

        public void UpdateMemberLocation(int accountId, int memberId, int provinceId, int cityId)
        {
            throw new NotImplementedException();
        }

        public void UpdateMemberName(int accountId, int memberId, string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateMemberRemark(int accountId, int memberId, string remark)
        {
            throw new NotImplementedException();
        }
    }
}