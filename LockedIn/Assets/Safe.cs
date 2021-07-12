using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Safe : MonoBehaviour
{
    [SerializeField] Sprite openStateSprite;

    SpriteRenderer spriteRenderer;
    public BoxCollider2D safeCollider;

    private void Start()
    {
        GameController gameController = FindObjectOfType<GameController>();
        gameController.AddCallback(24, Unlock);

        safeCollider = GetComponent<BoxCollider2D>();
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void Unlock()
    {
        spriteRenderer.sprite = openStateSprite;
    }

}
