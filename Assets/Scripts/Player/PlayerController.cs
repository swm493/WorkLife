using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float playerSpeed;
    public int maxHp;

    private int hp;
    
    void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        GameManager.Instance.Player = gameObject;
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        rigidbody.MovePosition(transform.position + move * Time.deltaTime * playerSpeed);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // if(other.gameObject.layer == Layer)
        var enemy = other.gameObject.GetComponent<EnemyBase>();
        Debug.Log(enemy.damage);
        // Debug.Log("enter");
        // enemy
    }
}
