using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    List<Line> interactionLines = new List<Line>();

    string[] englishLines =
    {
        "It's locked.",
        "It's still locked.",
        "I don't have the key.",
        "This is heavy.",
        "Sometimes I put my keys over here. Let me check...",
        "Let me check under it.",
        "Oh, I found a number!",
        "Maybe I dropped it on the couch.",
        "Let me check the drawer.",
        "This painting is crooked. Oh, I forgot about the safe.",
        " What is the password now?!",
        "I can't remember the password. I know I wrote it somewhere!",
        "Maybe there is something behind the vase.",
        "Am I going crazy? Well, better safe than sorry! Let me check the vent...",
        "I can't believe I've found a number! This place is kind of a mess.",
        "Hold on! There is a number by the safe! ",
        "Better remember this number.",
        "No way I'm calling Alice again! She always says I can't find anything. Well...",
        "That's too high. I need something to help me reach it. ",
        "Yeah, that's it! A number!",
        "This is the fourth vase we bought. Hope we don't break this one.",
        "This cabinet was given by my mother on our third anniversary.",
        "We bought this painting on our second trip together. ",
        "The sofa was the first funiture we bought for the house.",
        "Finally I could open it!",
        "Oh yeah! Here is the key!",
        "Nice! Now...where is my wallet?!"
    };

    string[] objectsOfInteraction =
    {
        "door",
        "door",
        "door",
        "table",
        "bookshelf",
        "underbookshelf",
        "underbookshelf",
        "couch",
        "cabinet",
        "paintingbig",
        "safe",
        "safe",
        "vaselarge",
        "vent",
        "vent",
        "lightswitch",
        "number on the wall",
        "phone",
        "topshelf",
        "topshelf",
        "vasesmall",
        "cabinet",
        "paintingsmall",
        "sofa",
        "safe",
        "safe",
        "door"
    };

    int[] references =
    {
        -1,
        0,
        0,
        -1,
        -1,
        -1,
        5,
        -1,
        -1,
        -1,
        9,
        10,
        -1,
        -1,
        13,
        -1,
        15,
        -1,
        -1,
        -1,
        -1,
        -1,
        -1,
        -1,
        -1,
        24,
        -1
    };

    void Awake()
    {
        for (int i = 0; i < englishLines.Length; i++)
        {
            interactionLines.Add(new Line(englishLines[i], objectsOfInteraction[i], references[i], i));
        }

        List<GameObject> rootObjects = new List<GameObject>();
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjects);

        // iterate root objects and do something
        for (int i = 0; i < rootObjects.Count; ++i)
        {
            GameObject gameObject = rootObjects[i];
            foreach (Line line in interactionLines)
            {
                if (gameObject.name.ToLowerInvariant().Equals(line.objectOfInteraction)) {
                    gameObject.GetComponent<InteractionsLine>().lines.Add(line);
                }
            }
        }
    }
}
