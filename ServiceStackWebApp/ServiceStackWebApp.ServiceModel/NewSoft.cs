using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace ServiceStackWebApp.ServiceModel
{
    [Route("/s/add")]
    public class NewSoft : IReturn<NewSoftResponse>
    {
        public string Name { get; set; }
        public string AliseName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsRunning { get; set; }
        public string Auther { get; set; }
        public string Desc { get; set; }
    }

    public class NewSoftResponse : IHasResponseStatus
    {
        public long? Id { get; set; }
        public string Guid { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }


    
}
