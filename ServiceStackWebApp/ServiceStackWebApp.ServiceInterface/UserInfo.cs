using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;
using ServiceStack.DataAnnotations;

namespace ServiceStackWebApp.ServiceInterface
{
    public class UserInfo 
    {
        [AutoIncrement]
        public  int Id { get; set; }

        public  int UserAuthId { get; set; }
    }
}
