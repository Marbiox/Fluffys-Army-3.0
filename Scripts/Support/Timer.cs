using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    float elapsedSeconds = 0;
    float totalSeconds = 0;
    bool started = false;
    bool running = false;


    public bool Finished
    {
        get { return started && !running; }
    }

    public bool Started
    {
        get { return started; }
    }

    public float ElapsedSeconds
    {
        get { return elapsedSeconds; }
    }

    public float TotalSeconds
    {
        get {  return totalSeconds; }
    }
    public float Duration
    {
        set { totalSeconds = value; }
    }

    void Update()
    {
        if (running)
        {
            elapsedSeconds += Time.deltaTime;
        }
        if (elapsedSeconds >= totalSeconds && started)
        {
            running = false;
        }
    }

    public void Run()
    {
        if (totalSeconds != 0)
        {
            started = true;
            running = true;
            elapsedSeconds = 0;
        }
    }

    public void Reset() {
        started = false;
    }
}
