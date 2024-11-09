using System;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Sprite frontSprite;
    public Sprite backSprite;
    public Sprite sideSprite;
    private Rigidbody2D rigidbody;
    private SpriteRenderer imageComponent;
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
        rigidbody = GetComponent<Rigidbody2D>();
        imageComponent = GetComponent<SpriteRenderer>();
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

    void Update()
    {
        Sprite spriteToSet = null;
        bool flipX = false;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            spriteToSet = sideSprite;
            flipX = Input.GetKey(KeyCode.D);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            spriteToSet = backSprite;
        }
        else if(Input.GetKey(KeyCode.S)){
            spriteToSet = frontSprite;
        }
        else
        {
            return; // 움직임이 없을 경우 실행을 종료
        }

        UpdateSprite(spriteToSet, flipX);
    }

    private void UpdateSprite(Sprite sprite, bool flipX)
    {
        imageComponent.flipX = flipX;
        imageComponent.sprite = sprite;
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
