using System;

namespace Assets.Scripts.Weapons
{
    public interface IReloadable : IWeaponable
    {
        public event Action Reloaded;
    }
}