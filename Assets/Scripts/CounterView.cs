using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _counterText;

    private void OnEnable()
    {
        _counter.ValueChanged += ShowScore;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= ShowScore;
    }

    private void ShowScore(int number)
    {
        _counterText.text = number.ToString();
    }
}
