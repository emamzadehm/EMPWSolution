using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PW.ApplicationContracts.ViewModels
{
    public class TestimonialViewModel
    {
        public long Id { get; set; }

        [DisplayName("نام و نام خانوادگی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفاً {0} خود را وارد نمائید.")]
        [StringLength(100, ErrorMessage = "حداکثر طول {0} تعداد {1} کاراکتر می باشد.")]
        public string StudentName { get; set; }
        
        public IFormFile IMG { get; set; }
        public string StudentImg { get; set; }

        [DisplayName("ایمیل")]
        [EmailAddress(ErrorMessage = "لطفا {0} خود را بصورت صحیح وارد نمائید.")]
        public string StudentEmail { get; set; }

        [DisplayName("نام درس")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفاً {0} خود را وارد نمائید.")]
        [StringLength(100, ErrorMessage = "حداکثر " +
            "طول {0} تعداد {1} کاراکتر می باشد.")]
        public string CourseName { get; set; }

        [DisplayName("نام دانشگاه")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفاً {0} خود را وارد نمائید.")]
        [StringLength(100, ErrorMessage = "حداکثر طول {0} تعداد {1} کاراکتر می باشد.")]
        public string UniversityName { get; set; }

        [DisplayName("ورودی سال (سال گذراندن درس)")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفاً {0} خود را وارد نمائید.")]
        //[MaxLength(4, ErrorMessage = "حداکثر طول {0} تعداد {1} کاراکتر می باشد.")]
        [RangeAttribute(1354, 1500, ErrorMessage = "فیلد {0} میبایست حداقل {1} باشد.")]
        public int EduYear { get; set; }

        [DisplayName("عنوان خاطره")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفاً {0} خود را وارد نمائید.")]
        [StringLength(500, ErrorMessage = "حداکثر طول {0} تعداد {1} کاراکتر می باشد.")]
        public string Title { get; set; }

        [DisplayName("شرح خاطره")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفاً {0} خود را وارد نمائید.")]
        public string Description { get; set; }
        public bool Status { get; set; }
        public bool IsVisible { get; set; }
        public DateTime CreatedDate { get; set; }

        
    }
}
