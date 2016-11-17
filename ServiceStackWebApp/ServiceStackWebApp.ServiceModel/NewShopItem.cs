using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStackWebApp.ServiceModel
{
    public class NewShopItem
    {
        public string Name { get; set; }
        public string AliseName { get; set; }
        public DateTime? StarTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Owner { get; set; }
        public string Desc { get; set; }
    }
}
