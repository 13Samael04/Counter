using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _currentValue;
    private Coroutine _coroutine;
    private float _delay;

    public event Action<int> ValueChanged;

    private void Start()
    {
        _currentValue = 0;
        _delay = 0.5f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ActivateTimer();
        }
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
            _coroutine = StartCoroutine(IncreaseScore(_delay));
        }
    }

    private IEnumerator IncreaseScore(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            _currentValue++;
            ValueChanged?.Invoke(_currentValue);

            yield return wait;
        }
    }
}
