using TMPro;
using UnityEngine;

public class CounterViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.MouseButtonClicked += Display;
    }

    private void OnDisable()
    {
        _counter.MouseButtonClicked -= Display;
    }

    private void Start()
    {
        _text.text = "0";
    }
    
    private void Display(int count)
    {
        _text.text = count.ToString();
    }
}
