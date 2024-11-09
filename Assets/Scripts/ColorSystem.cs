using UnityEngine;
using UnityEngine.InputSystem;

public class ColorSystem : MonoBehaviour
{
    MainInputAction action;
    InputAction moveAction;

    private void Awake()
    {
        action = new MainInputAction();
    }


    void Started(InputAction.CallbackContext context)
    {
        Debug.Log("started!");
    }

    void Performed(InputAction.CallbackContext context)
    {
        Debug.Log("performed!");
    }

    void Canceled(InputAction.CallbackContext context)
    {
        Debug.Log("canceled!");
    }

    void MOVE(float _x, float _y)
    {
        this.transform.position = new Vector2(this.transform.position.x + _x, this.transform.position.y + _y);
    }
}