using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private int _start;
    [SerializeField] private float _delay;

    private bool _isPaused;

    private void Start()
    {
        _text.text = "";
        _isPaused = false;
        StartCoroutine(Countdown(_delay, _start));
    }

    public void SwitchState(int state)
    {
        _isPaused = Convert.ToBoolean(state);
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
                DisplayCorutine(i);
                yield return wait;
                ++i;
            }
        }
    }

    private void DisplayCorutine(int count)
    {
        _text.text = count.ToString();
    }
}
