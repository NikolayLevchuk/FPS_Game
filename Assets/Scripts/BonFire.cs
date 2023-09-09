using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class BonFire : MonoBehaviour
{
    [SerializeField] private Light _pointLight; 
    [SerializeField] private float _maxDelay = 0.3f;
    [SerializeField] private float _minDelay = 0.01f;
    [SerializeField] private float _maxRange = 3.25f;
    [SerializeField] private float _minRange = 2.75f; 
    
    void Update()
    {
        StartCoroutine(nameof(RangeChanger));
    }
    
    private void ChangeRange() 
    {
        _pointLight.range = Random.Range(_minRange, _maxRange);
    }
    
    private IEnumerator RangeChanger()
    {
        ChangeRange();
        yield return new WaitForSeconds(Random.Range(_minDelay, _maxDelay));
    }
}
