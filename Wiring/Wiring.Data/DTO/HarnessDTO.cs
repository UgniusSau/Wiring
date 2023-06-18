using System;
using System.Collections.Generic;

namespace Wiring.Data;

public partial class HarnessDTO
{
    public int Id { get; set; }

    public string? Harness { get; set; }

    public string? HarnessVersion { get; set; }

    public string? Drawing { get; set; }

    public string? DrawingVersion { get; set; }
}
