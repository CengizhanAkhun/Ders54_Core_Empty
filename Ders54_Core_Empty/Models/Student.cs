using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Ders54_Core_Empty.Models
{
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Öğrenci Adı Zorunludur")]
        [DisplayName("Adı")]
        public string? StudentName { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Bölümü")]
        public string? Department { get; set; }


        [Required(ErrorMessage = "Öğrenci Yaşı Zorunludur")]
        [DisplayName("Yaşı")]
        public int Age 
        {
            get;set;
        }

        //public int _Age 
        //{
        //    get { return Age; } 
        //    set
        //    {
        //        if(value <18)
        //        {
        //            Age = 18;

        //        }
        //        else
        //        {
        //            Age = value;
        //        }
        //    }
        //}



        [Column(TypeName = "nvarchar(30)")]
        [Required(ErrorMessage = "Öğrenci No Zorunludur")]
        [DisplayName("Numarası")]
        public string? StudentNumber { get; set; }


        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string? Email { get; set; }


        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 character")]
        [DataType(DataType.Password)]
        [DisplayName("Şifre")]
        public string? Password { get; set; }


        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 character")]
        [DataType(DataType.Password)]
        [DisplayName("Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Password must match")]
        public string? PasswordAgain { get; set; }
    }
}
