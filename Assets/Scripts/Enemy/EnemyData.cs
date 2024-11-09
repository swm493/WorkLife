using UnityEngine;
using EnumData;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Object/Enemy")]
public class EnemyData : ScriptableObject
{
    // TODO: Sprite
    public SightColor color;
    public EnemyType type;
    public int maxHp;
    public float speed;
    public int bodyDamage;
    public int attackDamage;
}
