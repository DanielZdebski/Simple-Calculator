using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using ScallingLaws_example.Model;

namespace ScallingLaws_example.ViewModel.Helpers
{
    public class ScalingLawsHelper
    {
        public static List<ScalingLaw> GetDefaultScalingLaws(string path)
        {
            Dictionary<string, ScalingLaw>? ScalingLaws = JsonSerializer.Deserialize<Dictionary<string, ScalingLaw>>(File.ReadAllText(path));
            return new List<ScalingLaw>(ScalingLaws.Select(x => x.Value));
        }
    }
}
