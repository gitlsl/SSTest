using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;
using ServiceStack.DataAnnotations;
using ServiceStack.Model;

namespace ServiceStackWebApp.ServiceInterface
{
    public class UserInfo : IHasIntId
    {
        [AutoIncrement]
        public int Id { get; }

        public  string UserAuthId { get; set; }

        public  decimal Money { get; set; }
       
    }
}
