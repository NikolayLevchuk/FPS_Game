using System;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IWeaponable
    {
        public GameObject gameObject => gameObject;
        public int CurrentRounds { get; }
        public int RoundsAmount { get; }
        public int AllRounrs { get; }

    }
}