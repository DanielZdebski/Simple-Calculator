using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScallingLaws_example.Model
{
    public record ScalingLawResults(Interpreter? type, Dictionary<string, object>? results);
}
