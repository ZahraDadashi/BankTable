using System.ComponentModel.DataAnnotations; // [Required], [StringLength]
using System.ComponentModel.DataAnnotations.Schema; // [Column]
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace Packt.Shared;

//using logProject;


public class trans
{
   [Key]
    public int TransID { get; set; }
    public double changeAmt { get; set; }
    public double Balance { get; set; }
    public string? Date { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public int Hour { get; set; }
    public int Minute { get; set; }
    public int Second { get; set; }
    public int AccNum { get; set; }
    

}
