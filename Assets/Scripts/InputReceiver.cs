using System;
using UnityEngine;

public class InputReceiver : MonoBehaviour
{
    public event Action Mouse0Pressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Mouse0Pressed?.Invoke();
        }
    }
}
