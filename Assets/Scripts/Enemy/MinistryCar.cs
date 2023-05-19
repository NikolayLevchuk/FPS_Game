using Assets.Scripts;
using System;
using UnityEngine;

public class MinistryCar : MonoBehaviour, IRunawayable
{
    public event Action GotLost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            GotLost?.Invoke();
        }     
    }
}
