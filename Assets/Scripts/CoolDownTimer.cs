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
    public CooldownTimer(MonoBehaviour calling_mono, float cooldown_time)
    {
        mono = calling_mono;
        cooldown = cooldown_time;
    }
    public bool Activate()
    {
        if (ready == true)
        {
            ready = false;
            mono.StartCoroutine(CountdownTimer());
            return true;
        }
        return false;
    }
    IEnumerator CountdownTimer()
    {
        OnStart?.Invoke(this, EventArgs.Empty);
        yield return new WaitForSeconds(cooldown);
        ready = true;
        OnFinished?.Invoke(this, EventArgs.Empty);
    }
}
