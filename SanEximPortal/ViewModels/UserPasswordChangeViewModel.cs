using EntityLayer.Models;
using System.ComponentModel.DataAnnotations;
namespace SanEximPortal.ViewModels
{
    public class UserPasswordChangeViewModel: User
    {
        [Display(Name = "Şifre"), Required(ErrorMessage = "Şifre Alanı Zorunludur")]
        [DataType(DataType.Password)]
        [StringLength(100,MinimumLength =4,ErrorMessage ="Şifre en az 4 karakter olmalıdır")]
        public string ChangedPassword { get; set; }
        [Display(Name="Şifre Tekrar"), Required(ErrorMessage = "Şifre Tekrar Alanı Zorunludur")]
        [DataType(DataType.Password)]
        [Compare("ChangedPassword",ErrorMessage ="Şifreler Eşleşmiyor")]
        public string ChangedPasswordConfirm { get; set; }
    }
}