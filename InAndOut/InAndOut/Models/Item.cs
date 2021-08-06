using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


// Model class'ı Databasele ilişkiyi sağlamak için oluşturulur. Database'deki columnlar ve onların get-setleri bulunur.

namespace InAndOut.Models
{
    public class Item
    {
        [Key] // Id'nin Primary Key olması için kullanılır.
        public int Id { get; set; }
        public string Borrower { get; set; }
        public string Lender { get; set; }
        [DisplayName("Item Name")]  // View'da gösterirken Item Name olarak gözükmesi için
        public string ItemName { get; set; }
    }
}
