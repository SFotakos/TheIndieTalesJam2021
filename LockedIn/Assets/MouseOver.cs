using UnityEngine;

public class MouseOver : MonoBehaviour
{
    PlayerController player = null;

    float outOfReachDistance = 3.5f;
    bool showingOutOfReach = false, showingHoverTooltip = false;

    void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnMouseOver()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        var distanceVector = (Vector2) player.transform.position - mousePos2D;

        if (distanceVector.sqrMagnitude < outOfReachDistance * outOfReachDistance)
        {
            showingOutOfReach = false;
            if (!showingHoverTooltip)
            {
                TooltipSystem.Hide();
                showingHoverTooltip = true;
            }
        }
        else
        {
            showingHoverTooltip = false;
            if (!showingOutOfReach)
            {
                TooltipSystem.Show("I need to get closer", "Out of reach");
                showingOutOfReach = true;
            }
        }
    }

    private void OnMouseExit()
    {
        TooltipSystem.Hide();
        showingHoverTooltip = false;
        showingOutOfReach = false;
    }
}
