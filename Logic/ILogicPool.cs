using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public interface ILogicPool
    {
        public IDataPool Pool { get; }
        public void Prepare(int balls);
        public void Update();
    }
}
