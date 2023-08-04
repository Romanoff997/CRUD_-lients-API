using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CRUD_Сlients_API.Models.Client
{
    public class LivingAddressModel
    {
        public Guid? id { get; set; }

        [Display(Name = "Индекс")]
        public int? zipCode { get; set; }
        [Required]
        [Display(Name = "Страна")]
        public string country { get; set; }
        [Required]
        [Display(Name = "Область")]
        public string region { get; set; }
        [Required]
        [Display(Name = "Город")]
        public string city { get; set; }
        [Required]
        [Display(Name = "Улица")]
        public string? street { get; set; }
        [Required]
        [Display(Name = "Дом")]
        public string? house { get; set; }
        [Required]
        [Display(Name = "Квартира")]
        public string? apartment { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
