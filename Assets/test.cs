using UnityEngine;

public class test : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.MainCharacter = gameObject;
    }
}
