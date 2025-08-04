using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Collections;
using ScallingLaws_example.Model;
using ScallingLaws_example.ViewModel.Helpers;

namespace ScallingLaws_example.ViewModel
{
    partial class ScalingLawsViewModel: ObservableObject
    {
        public ObservableCollection<ScalingLaw> ScalingLaws { get; set; }
        public ScalingLawsViewModel()
        {
            ScalingLaws = new();
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                #region Design Mode property
                ScalingLaws.Add(new ScalingLaw
                {
                    Title = "ScalingLaw 1",
                    Description = "This is my first scaling law",
                    Formula = "15 + 3 * 5",
                    RequeiredInputs = new List<string> { "a", "Pws", "b" },
                    Interpreter = Interpreter.NCalc,
                    Expression = new List<string>
                    {"15 + [a] * [Pws]/[b] - [a]"},
                    ApplicableTo = new ApplicableTo(true, true, true)
                });

                ScalingLaws.Add(new ScalingLaw
                {
                    Title = "ScalingLaw 2",
                    Description = "This is my first scaling law",
                    Formula = "10",
                    RequeiredInputs = new List<string> { "a", "Pws", "b" },
                    Interpreter = Interpreter.NCalc,
                    Expression = new List<string>
                    {"15 + [a] * [Pws]/[b] - [a]"},
                    ApplicableTo = new ApplicableTo(true, true, true)
                });

                #endregion
            }
            else 
            {
                ScalingLaws = new ObservableCollection<ScalingLaw>(ScalingLawsHelper.GetDefaultScalingLaws(@"c:\Working\DefaultScalingLaws.json"));
            }
        }
    }
}
