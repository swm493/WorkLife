using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBaseController : MonoBehaviour
{
    public EnemyData data;

    public int Damage => data.bodyDamage;

    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private NavMeshAgent navMeshAgent;
    private bool isRecognized = false;
    private CooldownTimer attackTimer;
    private CooldownTimer directionSwitchTimer;

    private Vector3 currentDirection = Vector3.zero;
    void Awake()
    {
        InitializeComponents();
        SetupNavMeshAgent();
        SetupDirectionSwitchTimer();

        EnemyBuilder.buildAttack(gameObject, data);
    }

    void Start()
    {
        Assert.IsNotNull(data, "Enemy data must be assigned.");
        attackTimer.Activate();
    }

    void FixedUpdate()
    {
        MoveEnemy();
    }

    void Update()
    {
        UpdateRecognitionStatus();
        HandleDirectionSwitching();
        UpdateSpriteDirection();
    }

    private void InitializeComponents()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void SetupNavMeshAgent()
    {
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    private void SetupDirectionSwitchTimer()
    {
        attackTimer = new CooldownTimer(this, data.attackCooldown);
        attackTimer.OnFinished += (_, _) => OnFinishedAttackTimer();

        directionSwitchTimer = new CooldownTimer(this, 2.0f);
        directionSwitchTimer.OnStart += (_, _) => DisableAgent();
        directionSwitchTimer.OnFinished += (_, _) => SwitchDirection();
    }
    void OnFinishedAttackTimer()
    {
        AttackBaseController[] attackControllers = GetComponents<AttackBaseController>();
        for (int i = 0; i < attackControllers.Length; i++)
        {
            attackControllers[i].Attack(data);
        }
        attackTimer.Activate();
    }


    private void DisableAgent()
    {
        navMeshAgent.enabled = false;
    }

    private void SwitchDirection()
    {
        // Generate a random normalized direction vector
        float randomAngle = Random.Range(0f, 360f);
        float radians = randomAngle * Mathf.Deg2Rad;
        currentDirection = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0f).normalized;

        directionSwitchTimer.Activate();
    }

    private void MoveEnemy()
    {
        var playerPosition = GameManager.Instance.Player.transform.position;

        if (directionSwitchTimer.cooling)
        {
            rigidbody2D.MovePosition(transform.position + currentDirection * Time.deltaTime * data.speed);
        }
        else
        {
            navMeshAgent.enabled = true;
            navMeshAgent.destination = playerPosition;
        }
    }

    private void UpdateRecognitionStatus()
    {
        var playerPosition = GameManager.Instance.Player.transform.position;
        Vector3 directionToPlayer = playerPosition - transform.position;
        isRecognized = directionToPlayer.magnitude < data.recognitionDistance;

        if (isRecognized)
        {
            attackTimer.Activate();
        }
        else
        {
            attackTimer.Stop();
        }
    }

    private void HandleDirectionSwitching()
    {
        if (isRecognized)
        {
            directionSwitchTimer.Stop();
        }
        else if (!directionSwitchTimer.cooling)
        {
            directionSwitchTimer.Activate();
        }
    }

    private void UpdateSpriteDirection()
    {
        var playerPosition = GameManager.Instance.Player.transform.position;
        Vector3 directionToPlayer = playerPosition - transform.position;

        Sprite spriteToSet = DetermineSpriteForDirection(directionToPlayer, out bool flipX);
        UpdateSprite(spriteToSet, flipX);
    }

    private Sprite DetermineSpriteForDirection(Vector3 direction, out bool flipX)
    {
        flipX = false;
        var angle = Vector3.Angle(Vector3.right, direction);
        var crossProductZ = Vector3.Cross(Vector3.right, direction).z;
        int index = (int)(angle + 45) / 90;

        return index switch
        {
            0 => SetSpriteWithFlip(data.sideSprite, true, out flipX),
            2 => crossProductZ > 0 ? data.sideSprite : data.frontSprite,
            1 => data.backSprite,
            _ => null,
        };
    }

    private Sprite SetSpriteWithFlip(Sprite sprite, bool shouldFlip, out bool flipX)
    {
        flipX = shouldFlip;
        return sprite;
    }

    private void UpdateSprite(Sprite sprite, bool flipX)
    {
        if (sprite != null)
        {
            spriteRenderer.flipX = flipX;
            spriteRenderer.sprite = sprite;
        }
    }
}

