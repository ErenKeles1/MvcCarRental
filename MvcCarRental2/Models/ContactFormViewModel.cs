using System.ComponentModel.DataAnnotations;

namespace MvcCarRental2.Web.Models
{
    public class ContactFormViewModel
    {
        [Display(Name = "E-Posta")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Display(Name = "Ad ve Soyad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        [DataType(DataType.Text)]
        public string? NameSurname { get; set; }


        [Display(Name = "Telefon No.")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }


        [Display(Name = "Mesajınız")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        [DataType(DataType.MultilineText)]
        public string? Message { get; set; }
    }
}
