using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    [SerializeField] Sprite openStateSprite;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        GameController gameController = FindObjectOfType<GameController>();
        gameController.AddCallback(13, Open);
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void Open()
    {
        spriteRenderer.sprite = openStateSprite;
    }
}
