using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace _Traversal.Areas.Admin.Models.ViewModels
{
    public class DestinationUpdateFormViewModel
    {
        public int DestinationId { get; set; }

        [Required(ErrorMessage = "Şehir Alanı Zorunludur.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Süre Bilgisi Zorunludur.")]
        public string DayNight { get; set; }
        [Required(ErrorMessage = "Fiyat Alanı Zorunludur.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Açıklama Alanı Zorunludur.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Açıklama Alanı2 Zorunludur.")]
        public string Description2 { get; set; }

        public string? CoverImage { get; set; }
        public IFormFile? FileCoverImage { get; set; }

        public string? Image1 { get; set; }

        public IFormFile? FileImage1 { get; set; }
        public string? Image2 { get; set; }

        public IFormFile? FileImage2 { get; set; }


        [Required(ErrorMessage = "Kapasite Alanı Zorunludur.")]
        [Range(0, 500, ErrorMessage = "Kapasite alanı 0 ila 500 kişi arasında olmalıdır.")]
        public int? Capacity { get; set; }

        public int GuideId { get; set; }

        public List<SelectListItem> Guides { get; set; }
    }
}
