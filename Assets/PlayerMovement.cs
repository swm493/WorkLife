using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public float playerSpeed;
    
    void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        GameManager.Instance.Player = gameObject;
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        controller.Move(move * Time.deltaTime * playerSpeed);
    }
}
