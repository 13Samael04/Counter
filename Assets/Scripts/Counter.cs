using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _currentValue;
    private Coroutine _coroutine;

    public event Action<int> ValueChanged;

    private void Start()
    {
        _currentValue = 0;
    }

    public void ActivateTimer()
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        else
        {
            _coroutine = StartCoroutine(IncreaseScore());
        }
    }

    private IEnumerator IncreaseScore()
    {
        WaitForSeconds wait = new WaitForSeconds(0.5f);

        while (true)
        {
            _currentValue++;
            ValueChanged?.Invoke(_currentValue);

            yield return wait;
        }
    }
}
