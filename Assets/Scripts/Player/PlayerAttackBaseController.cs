using UnityEngine;
public class PlayerAttackBaseController : MonoBehaviour
{
    virtual public void Attack(Vector3 pos)
    {
        // 
        Debug.Log("Normal" + pos);
    }
}