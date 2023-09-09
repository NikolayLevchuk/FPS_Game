using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireDamage : MonoBehaviour
{
    [SerializeField] private int _damage;
    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent<IDamageble>(out IDamageble damageble))
        {
            damageble.ApplyDamage(_damage);           
        }
    }
}
