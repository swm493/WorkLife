using EnumData;
using UnityEngine;
public class GunAttackController : AttackBaseController
{
    public override void Attack(){
        Debug.Log("Gun");
        // create the bullet

        GameManager.Instance.factoryManager.bulletFactory.GetObject(BulletType.Enemy);
    }
}