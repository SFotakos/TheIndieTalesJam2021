using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour
{
    void Start()
    {
        GameController gameController = FindObjectOfType<GameController>();
        gameController.AddCallback(3, Move);
    }

    void Move()
    {
        transform.position = new Vector2(-3.76f, transform.position.y);
    }
}
