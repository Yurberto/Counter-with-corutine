using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private InputReceiver _receiver;
    [SerializeField] private int _start;
    [SerializeField] private int _end;
    [SerializeField] private float _delay;

    private bool _isPaused;
    private int _switchCounter;

    public event Action<int> TimeChanged;

    private void Start()
    {
        _isPaused = false;
        _switchCounter = 0;

        StartCoroutine(Countdown(_delay, _start, _end));
    }

    private void OnEnable()
    {
        _receiver.Mouse0Pressed += SwitchState;
    }

    private void OnDisable()
    {
        _receiver.Mouse0Pressed -= SwitchState;
    }

    public void SwitchState()
    {
        int stateDivider = 2;
        _isPaused = Convert.ToBoolean(++_switchCounter % stateDivider);
    }

    private IEnumerator Countdown(float delay, int start = 0, int end = 200000)
    {
        var wait = new WaitForSeconds(delay);

        for (int i = start; i <= end;)
        {
            if (_isPaused)
            {
                yield return null;
            }
            else 
            { 
                yield return wait;
                ++i;
                TimeChanged?.Invoke(i);
            }
        }
    }
}
