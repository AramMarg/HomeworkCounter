using System.Collections;
using TMPro;
using UnityEngine;

public class CounterViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private Counter _counter;

    private Coroutine _coroutine;

    private float _delay = 0.5f;

    private int _count;

    private void OnEnable()
    {
        _counter.MouseButtonClicked += RunCounter;
    }

    private void OnDisable()
    {
        _counter.MouseButtonClicked -= RunCounter;
    }

    private void Start()
    {
        _text.text = "0";
    }

    private void RunCounter(bool mustRun)
    {
        if (mustRun)
        {
            _coroutine = StartCoroutine(CountUp(_delay));
        }
        else
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }
    }

    private IEnumerator CountUp(float delay)
    {
        WaitForSeconds wait = new(delay);

        while (enabled)
        {
            Display(_count);

            _count++;

            yield return wait;
        }
    }
    
    private void Display(int count)
    {
        _text.text = count.ToString();
    }
}
