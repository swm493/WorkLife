using UnityEngine;
using EnumData;
public class RedPlayerAttackController : PlayerAttackBaseController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private const SightColor color = SightColor.Red;
    public int damage = 2;
    override public void Attack(Vector3 pos)
    {
        if(color != GameManager.Instance.sightColor) return;
        GameObject bullet = GameManager.Instance.factoryManager.bulletFactory.GetObject(BulletType.PlayerRed);

        PlayerBulletController bulletController = bullet.GetComponent<PlayerBulletController>();

        Vector3 playerPosition = GameManager.Instance.Player.transform.position;

        bulletController.direction = Vector3.Normalize(pos - playerPosition);
        bulletController.Damage = damage;
        bulletController.speed = 10;
        bulletController.color = SightColor.Red;
        bulletController.transform.position = transform.position;
        bulletController.gameObject.SetActive(true);
    }
}
