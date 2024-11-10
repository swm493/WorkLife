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
        GameObject bullet = Instantiate(bulletPrefab);
        BulletController bulletController = bullet.GetComponent<BulletController>();

        var playerPosition = GameManager.Instance.Player.transform.position;

        bulletController.Damage = data.attackDamage;
        bulletController.direction = Vector3.Normalize(playerPosition - transform.position);
        bulletController.sprite = data.bulletSprite;
        bulletController.speed = data.bulletSpeed;
        bulletController.color = data.color;
        bulletController.transform.position = transform.position;
    }
}