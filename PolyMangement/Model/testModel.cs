using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.Model
{
    public class testModel
    {
        [DisplayName("Dopant年份")]
        [Required(ErrorMessage = "請輸入Dopant年份")]
        [StringLength(4, ErrorMessage = "請輸入Dopant年份")]
        public string startYear { get; set; }


        [DisplayName("Dopant日期")]
        [Required(ErrorMessage = "請輸入Dopant日期")]
        [StringLength(5, MinimumLength = 3, ErrorMessage = "請輸入Dopant日期")]
        public string startMonthDay { get; set; }


        [DisplayName("Dopant時間")]
        [Required(ErrorMessage = "請輸入Dopant時間")]
        [StringLength(5, MinimumLength = 4, ErrorMessage = "請輸入Dopant時間")]
        public string startHourMins { get; set; }


        [DisplayName("熔完年份")]
        [Required(ErrorMessage = "請輸入熔完年份")]
        [StringLength(4, ErrorMessage = "請輸入熔完年份")]
        public string endYear { get; set; }


        [DisplayName("熔完日期")]
        [Required(ErrorMessage = "請輸入熔完日期")]
        [StringLength(5, MinimumLength = 3, ErrorMessage = "請輸入熔完日期")]
        public string endMonthDay { get; set; }


        [DisplayName("熔完時間")]
        [Required(ErrorMessage = "請輸入熔完時間")]
        [StringLength(5, MinimumLength = 4, ErrorMessage = "請輸入熔完時間")]
        public string endHourMins { get; set; }
    }
}
