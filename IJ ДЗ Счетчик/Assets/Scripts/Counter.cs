using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _delay = 0.5f;
    private bool _canRun = false;

    private void Start()
    {
        StartCoroutine(CountUp(_delay));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //CheckMouseClick();
        }
    }

    private IEnumerator CountUp(float delay)
    {
        WaitForSeconds wait = new(delay);
        WaitUntil condition = new(() => _canRun);

        for (int i = 0; ; i++)
        {
            DisplayCountUp(i);

            yield return condition;
            yield return wait;
        }

        //while (enabled)
        //{

        //}
    }

    //private void CheckMouseClick()
    //{
    //    if (_canRun)
    //        _canRun = false;
    //    else
    //        _canRun = true;
    //}

    private void DisplayCountUp(int count)
    {
    }
}
