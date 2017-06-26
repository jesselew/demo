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
    public interface IDataService
    {
        string GetAuthCode(string phone);

        List<MemberInfo> GetMemberList(int accountId);

        List<MemberInfo> GetMemberList(int accountId, string query);

        MemberInfo GetMember(int accountId, int memberId);

        int AddMember(MemberInfo member);

        void UpdateMemberName(int accountId, int memberId, string name);

        void UpdateMemberGender(int accountId, int memberId, int gender);

        void UpdateMemberBirth(int accountId, int memberId, DateTime birth);

        void UpdateMemberLocation(int accountId, int memberId, int provinceId, int cityId);

        void UpdateMemberRemark(int accountId, int memberId, string remark);

    }
}