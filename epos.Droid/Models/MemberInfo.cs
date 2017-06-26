using SQLite;
using System;

namespace epos.Droid.Models
{
    [Table("Members")]
    public class MemberInfo
    {
        [PrimaryKey, AutoIncrement]

        public int MemberId { get; set; }

        public int AccountId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public int Gender { get; set; }

        public DateTime Birth { get; set; }

        public int ProvinceId { get; set; }

        public string ProvinceName { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }

        public string Remark { get; set; }

    }
}