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
        public IReadOnlyCollection<ILogicBall> Balls { get; }

        public void StartMovement();
        public void StopMovement();
    }
}
