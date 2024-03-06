using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI speaker;
    [SerializeField] private TextMeshProUGUI conversation;
    [SerializeField] private GameObject continueIcon;
    [SerializeField] private StoryBlock[] stories;

    private int current = 0;

    private void Start()
    {
        image.sprite = stories[current].sprite;
        speaker.text = stories[current].speaker;
        conversation.text = stories[current].conversation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Next();
        }
    }

    public void Next()
    {
        current++;
        if (current < stories.Length)
        {
            image.sprite = stories[current].sprite;
            speaker.text = stories[current].speaker;
            conversation.text = stories[current].conversation;
            if (current == stories.Length - 1)
            {
                continueIcon.SetActive(false);
            }
        }
    }
}
