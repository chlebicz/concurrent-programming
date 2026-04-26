using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationModel
{
    public class ModelPoolFactory : IModelPoolFactory
    {
        public IModelPool CreatePool(ILogicPool logicPool)
        {
            return new ModelPool(logicPool);
        }
    }
}
