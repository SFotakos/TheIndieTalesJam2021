using UnityEngine;

[RequireComponent(typeof(InteractionsLine))]
public class Interaction : MonoBehaviour
{
    InteractionsLine interactions;

    void Awake()
    {
        interactions = GetComponent<InteractionsLine>();
    }

    public void Click()
    {
        TooltipSystem.Show("", interactions.lines[0].line);
    }
}
