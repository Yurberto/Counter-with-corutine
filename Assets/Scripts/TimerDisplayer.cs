using TMPro;
using UnityEngine;

public class TimerDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Timer _timer;

    public void OnEnable()
    {
        _timer.TimeChanged += DisplayTimer;
    }

    public void OnDisable()
    {
        _timer.TimeChanged -= DisplayTimer;
    }

    private void DisplayTimer(int count)
    {
        _text.text = count.ToString();
    }
}
