using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] private InputReceiver _inputReceiver;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _delay;
    [SerializeField] private int _start;

    private int _timerCounter = 0;

    private Coroutine _coroutine;

    public event Action<int> TimerChanged;

    private void OnEnable()
    {
        _inputReceiver.MouseLeftClicked += SwitchState;
        _inputReceiver.MouseRightClicked += ResetTimer;
    }

    private void OnDisable()
    {
        _inputReceiver.MouseLeftClicked -= SwitchState;
        _inputReceiver.MouseRightClicked -= ResetTimer;
    }

    private void SwitchState()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(Coroutine());
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void ResetTimer()
    {
        _timerCounter = 0;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        
        TimerChanged.Invoke(_timerCounter);
    }

    private IEnumerator Coroutine()
    {
        var wait = new WaitForSeconds(_delay);

        while (true)
        {
            TimerChanged.Invoke(_timerCounter++);
            yield return wait;
        }
    }
}
