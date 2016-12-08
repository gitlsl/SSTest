using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using ServiceStack.DataAnnotations;
using ServiceStack.Model;

namespace ServiceStackWebApp.ServiceModel
{

    public class SoftInfo : IHasIntId
    {
        [AutoIncrement]
        public int Id { get; set; }
        [Index]
        public string Guid { get; set; }
        [Index]
        public string Name { get; set; }
        public string AliseName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsRunning { get; set; }
        public string Auther { get; set; }
        public string Desc { get; set; }
        public DateTime? CreateTime { get; set; } = DateTime.Now;

        
    }

    public class SoftKey:IHasLongId
    {
        [AutoIncrement]
        public long Id { get; set; }
        [Index]
        public string Key { get; set; }
        public string SoftGuid { get; set; }
        public string Auther { get; set; }
        public int KeyValue { get; set; } = 1;
        public SoftKeyType KeyType { get; set; } = SoftKeyType.Day;
        public DateTime? CreateTime { get; set; } = DateTime.Now;
        public DateTime? EndTime { get; set; }
        public DateTime? UsedTime { get; set; }
        public string User { get; set; }
    }

    public enum SoftKeyType : short
    {
        Minute,
        Hour,
        Day,
        Week,
        Month,
        Year,
    }
}

  