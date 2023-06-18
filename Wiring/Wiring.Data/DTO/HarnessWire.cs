using System;
using System.Collections.Generic;

namespace Wiring.Data.DTO;

public partial class HarnessWire
{
    public long Id { get; set; }

    public long HarnessId { get; set; }

    public float? Length { get; set; }

    public string? Color { get; set; }

    public string? Housing1 { get; set; }

    public string? Housing2 { get; set; }
}
