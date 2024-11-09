using System;
using System.Collections;
using UnityEngine;

public class CooldownTimer
{
    public float cooldown;
    private MonoBehaviour mono;
    public EventHandler OnStart;
    public EventHandler OnFinished;
    public bool ready { get; private set; } = true;
    public bool cooling = false;
    private Coroutine runningCoroutine;

    public CooldownTimer(MonoBehaviour calling_mono, float cooldown_time)
    {
        mono = calling_mono;
        cooldown = cooldown_time;
    }

    public bool Activate()
    {
        if (ready)
        {
            ready = false;
            cooling = true;
            runningCoroutine = mono.StartCoroutine(CountdownTimer());
            return true;
        }
        return false;
    }

    public void Stop(bool invokeOnFinished = false)
    {
        if (runningCoroutine != null)
        {
            mono.StopCoroutine(runningCoroutine);
            runningCoroutine = null;
            cooling = false;
            ready = true; // Resetting state after stopping
            if (invokeOnFinished)
            {
                OnFinished?.Invoke(this, EventArgs.Empty); // Trigger OnFinished if requested
            }
        }
    }

    private IEnumerator CountdownTimer()
    {
        cooling = true;
        OnStart?.Invoke(this, EventArgs.Empty);
        yield return new WaitForSeconds(cooldown);
        ready = true;
        cooling = false;
        OnFinished?.Invoke(this, EventArgs.Empty);
    }
}
