using TMPro;
using UnityEngine;

public class TimerDisplayer : MonoBehaviour
{
    [SerializeField] private TimerController _timerController;
    [SerializeField] private TextMeshProUGUI _timerText;

    private void OnEnable()
    {
        _timerController.TimerChanged += DisplayTimer;
    }

    private void OnDisable()
    {
        _timerController.TimerChanged -= DisplayTimer;
    }

    private void DisplayTimer(int counter)
    {
        _timerText.text = counter.ToString();
    }
}
