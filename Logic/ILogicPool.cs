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
        public void ClearBalls();
        public void Update();
        public IReadOnlyCollection<ILogicBall> Balls { get; }
    }
}
