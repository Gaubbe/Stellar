using System;
using System.Collections.Generic;
using System.Text;

namespace Stellar.Timer
{
    public class PhysicsFrameTimer
    {
        public int FrameCount { get; private set; }
    
        public PhysicsFrameTimer(int initialFrameCount)
        {
            FrameCount = initialFrameCount;
        }

        public PhysicsFrameTimer() : this(0) { }

        public void OnPhysicsFrame()
        {
            FrameCount++;
        }

        public void Reset()
        {
            FrameCount = 0;
        }
    }
}
