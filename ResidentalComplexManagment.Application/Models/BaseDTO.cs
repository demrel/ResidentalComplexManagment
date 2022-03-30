using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Models;

public class BaseDTO
{
    public virtual string Id { get; set; }
    public DateTime Created { get; set; }
}
