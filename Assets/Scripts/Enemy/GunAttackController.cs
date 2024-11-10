using EnumData;
using UnityEngine;
public class GunAttackController : AttackBaseController
{
    public GameObject bulletPrefab;
    void Awake(){
        bulletPrefab = Resources.Load("Bullet", typeof(GameObject)) as GameObject;
    }
    public override void Attack(EnemyData data)
    {
        Debug.Log("Gun");
        GameObject bullet = GameManager.Instance.factoryManager.bulletFactory.GetObject(BulletType.EnemyBlack);
        switch (data.color)
        {
            case SightColor.Black:
                bullet = GameManager.Instance.factoryManager.bulletFactory.GetObject(BulletType.EnemyBlack);
                break;
            case SightColor.Red:
                bullet = GameManager.Instance.factoryManager.bulletFactory.GetObject(BulletType.EnemyRed);
                break;
            case SightColor.Blue:
                bullet = GameManager.Instance.factoryManager.bulletFactory.GetObject(BulletType.EnemyBlue);
                break;
        }
        BulletController bulletController = bullet.GetComponent<BulletController>();

        Vector3 playerPosition = GameManager.Instance.Player.transform.position;

        bulletController.gameObject.transform.position = playerPosition;
        bulletController.Damage = data.attackDamage;
        bulletController.direction = Vector3.Normalize(playerPosition - transform.position);
        bulletController.sprite = data.bulletSprite;
        bulletController.speed = data.bulletSpeed;
        bulletController.color = data.color;
        bulletController.transform.position = transform.position;
    }
}