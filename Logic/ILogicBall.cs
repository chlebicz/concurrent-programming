using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public interface ILogicBall
    {
        public IDataBall Ball { get; }
        public void Update();
    }
}
