using UnityEngine;
using EnumData;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Object/Enemy")]
public class EnemyData : ScriptableObject
{
    public Sprite frontSprite;
    public Sprite backSprite;
    public Sprite sideSprite;
    public SightColor color;
    public EnemyType type;
    public int maxHp;
    public float speed;
    public int bodyDamage;
    public int attackDamage;
    public float attackCooldown;
    public float recognitionDistance = 5.0f; 

    // bullet
    public float bulletSpeed;
    public Sprite bulletSprite;
}
