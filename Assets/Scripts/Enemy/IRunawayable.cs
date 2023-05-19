using System;

namespace Assets.Scripts
{
    public interface IRunawayable
    {
        public event Action GotLost;
    }
}