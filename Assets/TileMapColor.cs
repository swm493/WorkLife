using System.Collections;
using EnumData;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapColor : MonoBehaviour
{
    public SightColor color;
    TilemapRenderer tilemapRenderer;
    TilemapCollider2D tilemapCollider;

    private void Awake()
    {
        tilemapRenderer = GetComponent<TilemapRenderer>();
        tilemapCollider = GetComponent<TilemapCollider2D>();
    }

    void Update()
    {
        if (GameManager.Instance.sightColor == color)
        {
            tilemapRenderer.enabled = false;
            tilemapCollider.enabled = false;
        }
        else
        {
            tilemapRenderer.enabled = true;
            tilemapCollider.enabled = true;
        }
    }
}
