using UnityEngine;

[System.Serializable]
public class StoryBlock
{
    public string speaker;
    public Sprite sprite;
    [TextArea(3, 10)]
    public string conversation;
}