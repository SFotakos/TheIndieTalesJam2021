using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    [SerializeField] Sprite removedSprite;

    SpriteRenderer paintingRenderer;
    PolygonCollider2D paintingCollider;

    void Start()
    {
        GameController gameController = FindObjectOfType<GameController>();
        gameController.AddCallback(9, RemovePainting);

        paintingRenderer = GetComponent<SpriteRenderer>();
        paintingCollider = GetComponent<PolygonCollider2D>();
    }

    void RemovePainting()
    {
        transform.position = new Vector2(5.48f, -2.35f);
        paintingRenderer.sprite = removedSprite;
        paintingCollider.enabled = false;

        Safe safe = FindObjectOfType<Safe>();
        safe.safeCollider.enabled = true;
    }
}
