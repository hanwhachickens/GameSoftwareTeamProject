using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TransparentObject : MonoBehaviour
{
    public GameObject player;
    GridLayout gridLayout;
    Tilemap trans;
    TilemapCollider2D tileCollider;

    void Start()
    {
        gridLayout = transform.parent.GetComponentInParent<GridLayout>();
        trans = GetComponent<Tilemap>();
        tileCollider = GetComponent<TilemapCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Vector3Int cellPosition = gridLayout.WorldToCell(player.transform.position);
            
            Vector3Int up = new Vector3Int(cellPosition.x, cellPosition.y+1, 0);
            Vector3Int down = new Vector3Int(cellPosition.x, cellPosition.y-1, 0);
            Vector3Int left = new Vector3Int(cellPosition.x-1, cellPosition.y, 0);
            Vector3Int right = new Vector3Int(cellPosition.x+1, cellPosition.y, 0);

            Color color = new Color(1, 1, 1, 0.3f);
            trans.SetColor(up, color);
            trans.SetColor(down, color);
            trans.SetColor(left, color);
            trans.SetColor(right, color);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Vector3Int cellPosition = gridLayout.WorldToCell(player.transform.position);

            Vector3Int up = new Vector3Int(cellPosition.x, cellPosition.y + 1, 0);
            Vector3Int down = new Vector3Int(cellPosition.x, cellPosition.y - 1, 0);
            Vector3Int left = new Vector3Int(cellPosition.x - 1, cellPosition.y, 0);
            Vector3Int right = new Vector3Int(cellPosition.x + 1, cellPosition.y, 0);

            Color color = new Color(1, 1, 1, 1f);
            trans.SetColor(up, color);
            trans.SetColor(down, color);
            trans.SetColor(left, color);
            trans.SetColor(right, color);
        }
    }
}
