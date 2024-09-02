using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
#nullable enable annotations

[System.Serializable]
public class DialoguePiece
{
    public string MainTextContents;
    public bool requireGivenGameObjectActive;
    public GameObject? activePassCheck;
}
public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private List<DialoguePiece> dialogueItems = new();
    private Image panelImg;
    private int curDialogueIdx = 0;

    private void Start()
    {
        panelImg = GetComponent<Image>();
        textComponent.text = dialogueItems[curDialogueIdx].MainTextContents;
    }

    public void OnProceedButtonPress()
    {
        if (curDialogueIdx + 1 >= dialogueItems.Count)
        {
            FinishTutorial();
            return;
        }

        if (dialogueItems[curDialogueIdx].requireGivenGameObjectActive)
        {
            if (dialogueItems[curDialogueIdx].activePassCheck == null || !dialogueItems[curDialogueIdx].activePassCheck.activeInHierarchy)
                return;

            textComponent.text = dialogueItems[curDialogueIdx + 1].MainTextContents;
        }
        else
        {
            Debug.Log("B");
            textComponent.text = dialogueItems[curDialogueIdx + 1].MainTextContents;
        }
        panelImg.raycastTarget = !dialogueItems[curDialogueIdx + 1].requireGivenGameObjectActive;
        curDialogueIdx++;
    }


    public void FinishTutorial()
    {
        // Note: this just disables the Tutorial panel, but this could load another scene, or do whatever you want when the tutorial is over.
        gameObject.SetActive(false);
    }
}
