using System.Collections;
using EnumData;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float time;
    public int Damage;
    public Sprite sprite;
    public float speed = 0.1f;
    public Vector3 direction = Vector3.zero;
    public BulletType bulletType;
    
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody2d;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidbody2d.MovePosition(transform.position + Time.deltaTime * speed * direction);
    }

    IEnumerator Cooltime()
    {
        yield return new WaitForSeconds(time);
        GameManager.Instance.factoryManager.bulletFactory.DeleteObject(gameObject, bulletType);
    }
}
