using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiring.Data;

public class HarnessWire
{
    public int Id { get; set; }

    public int HarnessId { get; set; }

    public float? Length { get; set; }

    public string? Color { get; set; }

    public string? Housing1Port { get; set; }

    public string? Housing1Pin { get; set; }

    public string? Housing2Port { get; set; }

    public string? Housing2Pin { get; set; }
}
