using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    static PlayerController player = null;
    Vector2 oldPlayerPosition = Vector2.zero;
    [SerializeField] float outOfReachDistance = 4f;

    bool showingOutOfReach = false, showingHoverTooltip = false;

    void Awake()
    {
        if (player == null)
            player = FindObjectOfType<PlayerController>();
    }

    private void OnMouseOver()
    {
        Vector2 playerPosition = player.transform.position;
        if (oldPlayerPosition.magnitude != playerPosition.magnitude)
        {
            oldPlayerPosition = player.transform.position;
            if (Mathf.Abs(this.transform.position.magnitude - playerPosition.magnitude) < outOfReachDistance)
            {
                showingOutOfReach = false;
                if (!showingHoverTooltip)
                {
                    showingHoverTooltip = true;
                    Debug.Log("Hovering over: " + this.name);
                }
            }
            else
            {
                showingHoverTooltip = false;
                if (!showingOutOfReach)
                {
                    showingOutOfReach = true;
                    Debug.Log("Out of reach");
                }
            }
        }
    }

    private void OnMouseExit()
    {
        oldPlayerPosition = Vector2.zero;
        showingHoverTooltip = false;
        showingOutOfReach = false;
    }
}
