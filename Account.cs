using static System.Console;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Packt.Shared;

public class Account
{
    public string? Name{ get; set; }
    [Key]
    public int AccountID{ get; set; }
    public double Balance{ get; set; }
    
}
