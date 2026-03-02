using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private UserInputter _userInputter;

    private bool _canRun = false;

    public event Action<bool> MouseButtonClicked;

    private void OnEnable()
    {
        _userInputter.MouseButtonClicked += RunViewer;
    }

    private void OnDisable()
    {
        _userInputter.MouseButtonClicked -= RunViewer;
    }

    private void RunViewer()
    {
        _canRun = !_canRun;

        MouseButtonClicked?.Invoke(_canRun);
    }
}
