using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Сlients_API.Models
{
    public class ClientErrorModel
    {
        public int status { get; set; }
        public string code { get; set; }
        ExceptionErrorModel? [] exceptions{ get; set; }
  
    }
}
