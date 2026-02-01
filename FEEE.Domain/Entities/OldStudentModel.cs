using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FEEE.Infrastructure.Persistence.Entities
{
    [Table("Students")] // 👈 الاسم الحقيقي بالـ WIN DB
    public class OldStudent
    {
        public int ID { get; set; }

        public int UnivID { get; set; } // ✅ كان string

        public DateTime RegistDate { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }

        public string Father { get; set; }
        public string Mother { get; set; }

        public DateTime? BirthDay { get; set; }

        public int? SectionID { get; set; }
        public int? CityID { get; set; }

        public bool IsExist { get; set; }

        public DateTime LastModified { get; set; }
    }
}
