using System.ComponentModel.DataAnnotations; // [Required], [StringLength]
using System.ComponentModel.DataAnnotations.Schema; // [Column]
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared;

//using logProject;


public class trans
{
   [Key]
    public int TransID { get; set; }
    public double changeAmt { get; set; }
    public double Balance { get; set; }
    public DateTimeOffset time { get; set; }
    public int AccNum { get; set; }

}
