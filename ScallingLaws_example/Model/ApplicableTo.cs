using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScallingLaws_example.Model
{
    public class ApplicableTo
    {
        #region public properties
        public bool ZeroDComponent { get; set; }
        public bool OneDComponent { get; set; }
        public bool ThreeDComponent { get; set; }
        #endregion

        #region Constructors
        public ApplicableTo(bool zeroDComponent, bool oneDComponent, bool threeDComponent)
        {
            ZeroDComponent = zeroDComponent;
            OneDComponent = oneDComponent;
            ThreeDComponent = threeDComponent;
        }
        #endregion
    }
}
