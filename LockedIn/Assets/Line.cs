using System;

public class Line
{

    public string text, objectOfInteraction;
    public int reference, id;
    public bool hasBeenRead = false;
    public Action callback;

    public Line(string text, string objectOfInteraction, int reference, int id)
    {
        this.text = text;
        this.objectOfInteraction = objectOfInteraction;
        this.reference = reference;
        this.id = id;
    }


}
