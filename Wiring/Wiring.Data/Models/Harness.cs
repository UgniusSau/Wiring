using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Wiring.Data;

public class Harness
{
    [JsonIgnore]
    public int Id { get; set; }

    public string? HarnessTitle { get; set; }

    public string? HarnessVersion { get; set; }

    public string? Drawing { get; set; }

    public string? DrawingVersion { get; set; }

    [JsonIgnore]
    public List<HarnessWireDTO> Wires { get; set; } = new List<HarnessWireDTO>();

    public override string ToString()
    {
        return $"Harness: {HarnessTitle}, HarnessVersion: {HarnessVersion}, Drawing: {Drawing}, DrawingVersion: {DrawingVersion}";
    }
}

