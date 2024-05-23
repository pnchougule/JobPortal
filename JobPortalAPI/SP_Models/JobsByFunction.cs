using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortalAPI.Models;

namespace JobPortalAPI.SP_Models
{
    public class JobsByFunction
    {
        public string FunctionName {get;set;}
        public int Count {get;set;}
        public List<string> JobNames {get;set;}
    }
}