using System.Collections;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    PlayerController player = null;

    float outOfReachDistance = 4f;
    bool showingOutOfReach = false, showingHoverTooltip = false;
    [SerializeField] string content, header;

    Coroutine delayCoroutine;
    float delayTooltipTime = 0.25f;

    void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnMouseOver()
    {

        if (delayCoroutine == null)
            delayCoroutine = StartCoroutine(delay(player.transform.position));

    }

    private void OnMouseExit()
    {
        if (delayCoroutine != null)
        {
            StopCoroutine(delayCoroutine);
            delayCoroutine = null;
        }

        TooltipSystem.Hide();
        showingHoverTooltip = false;
        showingOutOfReach = false;
    }

    IEnumerator delay(Vector2 playerPosition)
    {
        yield return new WaitForSeconds(delayTooltipTime);
        if (Mathf.Abs(this.transform.position.magnitude - playerPosition.magnitude) < outOfReachDistance)
        {
            showingOutOfReach = false;
            if (!showingHoverTooltip)
            {
                TooltipSystem.Show(content, header);
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
        delayCoroutine = null;
    }
}
