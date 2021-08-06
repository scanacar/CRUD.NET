using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models
{
    public class Expense
    {
        [Key] // Primary Key
        public int Id { get; set; }
        [DisplayName("Expense")] // Ekranda görünen ismin Expense olması için
        [Required] // ExpenseName'in database'e veri eklerken zorunlu olması için
        public string ExpenseName { get; set; }
        [Required] 
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage ="Amount must be greater than 0!")] // Girilebilecek değer aralığı ve hata mesajı
        public int Amount { get; set; }
    }
}
