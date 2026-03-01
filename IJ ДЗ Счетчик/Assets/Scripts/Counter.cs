using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action<int> TextRunning;

    private Coroutine _coroutine;

    [SerializeField] private UserInputter _userInputter;

    private float _delay = 0.5f;
    private bool _canRun = false;
    private int _count;

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
            TextRunning?.Invoke(_count);

            _count++;

            yield return wait;
        }
    }    
}
