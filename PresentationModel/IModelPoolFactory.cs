using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationModel
{
    public interface IModelPoolFactory
    {
        IModelPool CreatePool(ILogicPool logicPool);
    }
}
