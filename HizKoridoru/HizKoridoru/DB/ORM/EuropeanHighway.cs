using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HizKoridoru.DB.ORM
{
   public class EuropeanHighway
   {
      [Key]
      public int ID { get; set; }
      public string Title { get; set; }
      public ICollection<Toll> Tolls { get; set; }
   }
}
