using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public List<Line> lines = new List<Line>();
    public GameController gameController;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void Click()
    {
        int lastLine = lines.Count - 1;
        for (int i = 0; i <= lastLine; i++)
        {
            Line line = lines[i];

            if (line.reference == -1 || gameController.HasLineBeenRead(line.reference))
            {
                if (!line.hasBeenRead || i == lastLine)
                {
                    Debug.Log(line.text);
                    TooltipSystem.Show("", line.text);
                    line.hasBeenRead = true;
                    if (line.callback != null)
                        StartCoroutine(CallbackDelayed(line.callback));

                    break;
                }
            } else
            {
                bool hasPreviousLine = i != 0;
                if (hasPreviousLine)
                {
                    Debug.Log(lines[i - 1].text);
                    TooltipSystem.Show("", lines[i-1].text);
                    break;
                }
            }
        }        
    }

    IEnumerator CallbackDelayed(Action callback)
    {
        yield return new WaitForSeconds(2.5f);
        callback.Invoke();
    }
}
