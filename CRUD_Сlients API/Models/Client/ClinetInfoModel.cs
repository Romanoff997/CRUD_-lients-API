using CRUD_Сlients_API.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CRUD_Сlients_API.Models.Client
{
    public class ClientInfoModel
    {
        [Required]
        public Guid id { get; set; }
        public string name { get; set; }
        public string? surname { get; set; }
        public string? patronymic { get; set; }
        public DateTime dob { get; set; }
        public string[] сhildren { get; set; }
        //public string[]? documentIds { get; set; }
        public PassportModel passport { get; set; }
        public LivingAddressModel livingAddress { get; set; }
        public RegAddressModel regAddress { get; set; }
        public string[] jobs { get; set; }

    }
}
