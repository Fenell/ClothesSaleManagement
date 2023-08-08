using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ClothesSaleManagement.WebApp.Models
{
    public class CategoryVM
    {
        public Guid Id { get; set; }
        [Display(Name = "Tên danh mục")]
        [Required(ErrorMessage = "Tên không được trống")]
        [MaxLength(10, ErrorMessage = "Nhập trên 10 kt")]
        public string Name{ get; set; } = string.Empty;
       
    }
}
