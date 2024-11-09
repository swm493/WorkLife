using EnumData;
using UnityEngine;

public class EXPController : MonoBehaviour
{
    public SightColor sightColor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.dataManager.ExpValue[sightColor] += 1;
        Destroy(gameObject);
    }
}