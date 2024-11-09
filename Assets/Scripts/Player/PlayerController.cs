using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float playerSpeed;
    public int maxHp;

    public int hp
    {
        get { return _hp; }
        set
        {
            _hp -= value;
            if (_hp <= 0)
            {
                // TODO: destory
            }
        }
    }
    private int _hp;
    private bool isInvincible = false;
    private float invincibleCooldown = 1.0f;
    private CooldownTimer invincibleCooldownTimer;

    void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        GameManager.Instance.Player = gameObject;

        invincibleCooldownTimer = new CooldownTimer(this, invincibleCooldown);
        invincibleCooldownTimer.OnStart += (object sender, System.EventArgs e) => ActivateInvincible();
        invincibleCooldownTimer.OnFinished += (object sender, System.EventArgs e) => DeactivateInvincible();

    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        rigidbody.MovePosition(transform.position + move * Time.deltaTime * playerSpeed);
    }

    void ActivateInvincible()
    {
        GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }

    void DeactivateInvincible()
    {
        GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            hp -= damage;
            invincibleCooldownTimer.Activate();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.gameObject.GetComponent<EnemyBase>();
        TakeDamage(enemy.damage);
    }
}
