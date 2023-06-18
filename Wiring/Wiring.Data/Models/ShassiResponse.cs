using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiring.Data;

public class ShassiResponse
{
    public Harness? Harness1 { get; set; } 

    public Harness? Harness2 { get; set; } 

    public string? Housing { get; set; }

    public bool IsValid { get; set; }
}
