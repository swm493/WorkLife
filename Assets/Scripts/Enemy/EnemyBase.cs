using EnumData;
using NUnit.Framework;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public EnemyData data;
    public int damage{
        get {
            return data.bodyDamage;
        }
    }
    void Start()
    {
        Assert.IsNotNull(data);
    }

    // Update is called once per frame
    void Update()
    {
        // var player = GameManager.Instance.Player;
        // Debug.Log(player);
        // Move to player
    }
}
