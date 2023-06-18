using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiring.Data;

public class Harness
{
    public int Id { get; set; }

    public string? HarnessTitle { get; set; }

    public string? HarnessVersion { get; set; }

    public string? Drawing { get; set; }

    public string? DrawingVersion { get; set; }

    public List<HarnessWire> Wires { get; set; } = new List<HarnessWire>();
}

