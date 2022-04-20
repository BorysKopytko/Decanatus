using System.ComponentModel.DataAnnotations;

namespace Decanatus.DAL.Abstractions
{
    public abstract class Person : Entity
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "По-батькові")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Стать")]
        public Sex Sex { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата народження")]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Електронна пошта")]
        public string EmailAdress { get; set; }

        [Required]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(12)]
        [Display(Name = "Номер мобільного телефону")]
        public string MobilePhoneNumber { get; set; }
    }

    public enum Sex
    {
        [Display(Name = "Чоловіча")]
        Male,

        [Display(Name = "Жіноча")]
        Female
    }
}
