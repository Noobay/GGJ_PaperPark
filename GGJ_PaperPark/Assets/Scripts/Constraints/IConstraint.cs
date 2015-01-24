using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Constraints
{
    interface IConstraint
    {
        bool isUserInputLegal(params object[] inputs);
        bool isConAllowed { get; }
    }
}
