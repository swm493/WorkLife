using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using EnumData;

public class EnemyBuilder
{
    public static void buildAttack(GameObject enemy, EnemyData data)
    {
        if (data.type == EnemyType.Normal) return;
        enemy.AddComponent<GunAttackController>();

    }
}   