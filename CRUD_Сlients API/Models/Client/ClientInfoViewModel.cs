using CRUD_Сlients_API.Models;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Сlients_API.Models.Client
{
    public class Child
    {
        public Guid id { get; set; }

        [Display(Name = "Имя")]
        public string name { get; set; }
        [Display(Name = "Фамилия")]
        public string? surname { get; set; }
        //[Required]
        [Display(Name = "Отчество")]
        public string? patronymic { get; set; }
        [Display(Name = "День рождения")]
        public DateTime dob { get; set; }
    }

    public class ClientInfoViewModel
    {
        //[Required]
        public Guid id { get; set; }
        // [Required]
        [Display(Name = "Имя")]
        public string? name { get; set; }
        //[Required]
        [Display(Name = "Фамилия")]
        public string? surname { get; set; }
        //[Required]
        [Display(Name = "Отчество")]
        public string? patronymic { get; set; }

        [Display(Name = "День рождения")]
        public DateTime dob { get; set; }
        public IEnumerable<Child>? children { get; set; }
       // public string[]? documentIds { get; set; }
        //[Required]
        //public PassportModel? passport { get; set; }
        //////[Required]
        //public LivingAddressModel livingAddress { get; set; }
        ////[Required]
        //public RegAddressModel regAddress { get; set; }

        //public string[]? jobs { get; set; }

        public int? curWorkExp { get; set; }
        public string? typeEducation { get; set; }
        public float? monIncome { get; set; }
        public float? monExpenses { get; set; }
        //public string[]? communications { get; set; }

        [Display(Name = "Дата изменения")]
        public DateTime createdAt { get; set; }

        [Display(Name = "Дата последнего изменеия")]
        public DateTime updatedAt { get; set; }
    }
}
