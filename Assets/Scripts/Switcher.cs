using TMPro;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    private int _switchCounter = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Switch();
        }
    }

    public void Switch()
    {
        int state = ++_switchCounter % 2;

        _timer.SwitchState(state);
    }
}
