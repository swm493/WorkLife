using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int Damage;
    public Sprite sprite;
    public float speed = 0.0f;
    public Vector3 direction = Vector3.zero;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        spriteRenderer.sprite = sprite;
    }
    // Update is called once per frame
    void Update()
    {
        rigidbody.MovePosition(transform.position + Time.deltaTime * speed * direction);
    }
}
