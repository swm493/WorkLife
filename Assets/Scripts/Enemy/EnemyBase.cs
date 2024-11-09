using System;
using EnumData;
using NUnit.Framework;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public EnemyData data;
    public int damage{
        get {
            return data.bodyDamage;
        }
    }
    private SpriteRenderer imageComponent;

    void Awake(){
        imageComponent = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        Assert.IsNotNull(data);
    }

    void Update()
    {
        Sprite spriteToSet = null;
        bool flipX = false;
        var playerPosition = GameManager.Instance.Player.transform.position;
        Vector3 direction = playerPosition - transform.position;

        var angle = Vector3.Angle(Vector3.right, direction);
        
        int i = (int)(angle + 45) / 90;
        Debug.Log(i);
        
        switch(i){
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
