using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Сlients_API.Models
{
    public class PassportModel
    {
        public Guid? id { get; set; }
        [Required]
        [Display(Name ="Серия")]
        public int series { get; set; }
        [Required]
        [Display(Name = "Номер")]
        public int number { get; set; }
        [Required]
        [Display(Name = "Выдано")]
        public string giver { get; set; }
        [Required]
        [Display(Name = "Дата выдачи")]
        public DateTime dateIssued { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
