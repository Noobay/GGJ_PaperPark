using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Constraints
{
    public interface IConstraint
    {
        bool isUserInputLegal(params object[] inputs);
        bool isConAllowed { get; }
    }
}
