using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiring.Data;

namespace Wiring.Services;

public interface IShassiService
{
    Task<IEnumerable<Harness>> GenerateShassi();
}
