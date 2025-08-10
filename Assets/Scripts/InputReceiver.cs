using System;
using UnityEngine;

public class InputReceiver : MonoBehaviour
{
    public event Action MouseLeftClicked;
    public event Action MouseRightClicked;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            MouseLeftClicked?.Invoke();

        else if (Input.GetKeyDown(KeyCode.Mouse1))
            MouseRightClicked?.Invoke();
    }
}
