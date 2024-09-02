using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    public List<string> dialogues = new();
    private int currentDialogueSelected = 0;

    private void Awake()
    {
        textComponent.text = dialogues[currentDialogueSelected];
    }

    public void OnProceedButtonPress()
    {
        currentDialogueSelected++;
        if (currentDialogueSelected < dialogues.Count)
            textComponent.text = dialogues[currentDialogueSelected];
    }


    public void HideTutorial()
    {
        gameObject.SetActive(false);
    }
}
