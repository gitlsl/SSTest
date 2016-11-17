using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using ServiceStack.DataAnnotations;

namespace ServiceStackWebApp.ServiceModel
{

    public class ShopItem
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string AliseName { get; set; }
        public DateTime? StarTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Owner { get; set; }
        public string Desc { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}

  