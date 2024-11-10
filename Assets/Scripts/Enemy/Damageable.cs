using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public int health;
    public UnityEvent DeathEvent;

    public void Damage(int damage)
    {
        health -= damage;
        if (health < 0)
            DeathEvent.Invoke();
    }
}