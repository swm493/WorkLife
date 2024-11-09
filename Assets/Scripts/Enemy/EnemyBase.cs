using System;
using EnumData;
using NUnit.Framework;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public EnemyData data;
    public int damage
    {
        get
        {
            return data.bodyDamage;
        }
    }
    private Rigidbody2D rigidbody;
    private SpriteRenderer imageComponent;
    private NavMeshAgent agent;
    private bool isRecognized = false;
    private float cooldown = 2.0f;
    private CooldownTimer directionSwitchTimer;
    private Vector3 direction = Vector3.zero;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        imageComponent = GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;

        directionSwitchTimer = new CooldownTimer(this, cooldown);
        directionSwitchTimer.OnStart += (object sender, System.EventArgs e) => turnOnDirectionSwitch();
        directionSwitchTimer.OnFinished += (object sender, System.EventArgs e) => SwtichDirection();

    }
    void Start()
    {
        Assert.IsNotNull(data);
    }
    void turnOnDirectionSwitch(){
        agent.enabled = false;
    }
    void SwtichDirection()
    {
        // Generate a random direction vector (normalized)
        float randomAngle = UnityEngine.Random.Range(0f, 360f);
        float radians = randomAngle * Mathf.Deg2Rad;
        direction = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0f).normalized;

        // Restart the cooldown timer
        Debug.Log("Switch");
        directionSwitchTimer.Activate();
    }

    void FixedUpdate()
    {
        var playerPosition = GameManager.Instance.Player.transform.position;
        if (directionSwitchTimer.cooling)
        {
            rigidbody.MovePosition(transform.position + direction.normalized * Time.deltaTime * data.speed);
        }
        else
        {
            agent.enabled = true;
            agent.destination = playerPosition;
        }
    }

    void Update()
    {
        var playerPosition = GameManager.Instance.Player.transform.position;
        Vector3 direction = playerPosition - transform.position;
        isRecognized = direction.magnitude < data.recognitionDistance;

        if (isRecognized)
        {
            // stop timer
            directionSwitchTimer.Stop();
        }
        else
        {
            if (!directionSwitchTimer.cooling)
            {
                directionSwitchTimer.Activate();
            }
        }

        Sprite spriteToSet = null;
        bool flipX = false;
        var angle = Vector3.Angle(Vector3.right, direction);

        int i = (int)(angle + 45) / 90;

        switch (i)
        {
            case 0:
                spriteToSet = data.sideSprite;
                flipX = true;
                break;
            case 2:
                spriteToSet = data.sideSprite;
                break;
            case 1:
                spriteToSet = data.backSprite;
                break;
            case 3:
                spriteToSet = data.frontSprite;
                break;
        }

        UpdateSprite(spriteToSet, flipX);
    }

    private void UpdateSprite(Sprite sprite, bool flipX)
    {
        imageComponent.flipX = flipX;
        imageComponent.sprite = sprite;
    }
}
