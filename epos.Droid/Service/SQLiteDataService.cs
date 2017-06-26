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
using System.IO;
using SQLite;

namespace epos.Droid.Service
{
    public class SQLiteDataService : IDataService
    {
        private SQLiteConnection db;
        private const string TableName = "Members";
        private string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MemberDb.db3");
        private static object collisionLock = new object();

        public SQLiteDataService()
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<MemberInfo>();
        }

        public int AddMember(MemberInfo member)
        {
            lock (collisionLock)
            {
                return db.Insert(member);
            }
        }

        public string GetAuthCode(string phone)
        {
            return "111111";
        }

        public MemberInfo GetMember(int accountId, int memberId)
        {
            lock (collisionLock)
            {
                return db.Table<MemberInfo>().Where(_ => _.AccountId == accountId 
                && _.MemberId == memberId)
                .SingleOrDefault();
            }
        }

        public List<MemberInfo> GetMemberList(int accountId)
        {
            lock (collisionLock)
            {
                return db.Table<MemberInfo>().Where(_ => _.AccountId == accountId)
                    .ToList();
            }
        }

        public List<MemberInfo> GetMemberList(int accountId, string query)
        {
            lock (collisionLock)
            {
                return db.Table<MemberInfo>().Where(_ => _.AccountId == accountId && (
                    _.Name.Contains(query) ||
                    _.Phone.Contains(query)))
                    .ToList();
            }
        }

        public void UpdateMemberBirth(int accountId, int memberId, DateTime birth)
        {
            lock (collisionLock)
            {
                var member = db.Table<MemberInfo>().SingleOrDefault(_ => _.AccountId == accountId && _.MemberId == memberId);
                member.Birth = birth;

                db.Update(member);
            }
            
        }

        public void UpdateMemberGender(int accountId, int memberId, int gender)
        {
            lock (collisionLock)
            {
                var member = db.Table<MemberInfo>().SingleOrDefault(_ => _.AccountId == accountId && _.MemberId == memberId);
                member.Gender = gender;

                db.Update(member);
            }
        }

        public void UpdateMemberLocation(int accountId, int memberId, int provinceId, int cityId)
        {
            lock (collisionLock)
            {
                //var member = db.Table<MemberInfo>().SingleOrDefault(_ => _.AccountId == accountId && _.MemberId == memberId);
                

                //db.Update(member);
            }
        }

        public void UpdateMemberName(int accountId, int memberId, string name)
        {
            lock (collisionLock)
            {
                var member = db.Table<MemberInfo>().SingleOrDefault(_ => _.AccountId == accountId && _.MemberId == memberId);
                member.Name = name;

                db.Update(member);
            }
        }

        public void UpdateMemberRemark(int accountId, int memberId, string remark)
        {
            lock (collisionLock)
            {
                var member = db.Table<MemberInfo>().SingleOrDefault(_ => _.AccountId == accountId && _.MemberId == memberId);
                member.Remark = remark;

                db.Update(member);
            }
        }
    }
}