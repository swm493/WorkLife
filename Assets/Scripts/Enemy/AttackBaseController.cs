using UnityEngine;
public class AttackBaseController : MonoBehaviour
{
    virtual public void Attack(EnemyData data)
    {
        Debug.Log("Normal");
    }
}