using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private UserInputter _userInputter;

    private float _delay = 0.5f;
    private int _count;
    private bool _canRun = false;

    private Coroutine _coroutine;

    public event Action<int> MouseButtonClicked;

    private void OnEnable()
    {
        _userInputter.MouseButtonClicked += Run;
    }

    private void OnDisable()
    {
        _userInputter.MouseButtonClicked -= Run;
    }

    private void Run()
    {
        _canRun = !_canRun;

        if (_canRun)
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
            MouseButtonClicked?.Invoke(_count);

            _count++;

            yield return wait;
        }
    }
}
