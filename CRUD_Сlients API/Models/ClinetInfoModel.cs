using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Сlients_API.Models
{
    public class ClientInfoModel
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string? surname { get; set; }
        public string? patronymic { get; set; }
        public DateTime dob { get; set; }
        public string[]? сhildren { get; set; }
        public string[]? documentIds { get; set; }
        public PassportModel passport { get; set; }
        public LivingAddressModel livingAddress { get; set; }
        public  RegAddressModel regAddress { get; set; }
        public string[]? jobs { get; set; }
        public int curWorkExp { get; set; }
        public string? typeEducation { get; set; }
        public float monIncome { get; set; }
        public float monExpenses { get; set; }
        public string[]? communications { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

    }
}
