using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField] private int curDialogueIdx = 0;

    public GameObject blackBG;
    public GameObject OfficeSliders;
    public GameObject menus;
    public GameObject CVExample;
    public GameObject EmployeeManagementExample;

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
        StartCoroutine(GoToMainGame());
        //gameObject.SetActive(false);
    }

    private void Update()
    {
        if(curDialogueIdx == 2 || curDialogueIdx == 3 || curDialogueIdx == 4 || curDialogueIdx == 8)
        {
            blackBG.gameObject.SetActive(true);
        }
        else
        {
            blackBG.gameObject.SetActive(false);
        }

        if (curDialogueIdx == 2)
        {
            CVExample.SetActive(true);
        }
        else
        {
            CVExample.SetActive(false);
        }

        if (curDialogueIdx == 3)
        {
            menus.SetActive(true);
        }
        else
        {
            menus.SetActive(false);
        }

        if (curDialogueIdx == 4)
        {
            EmployeeManagementExample.SetActive(true);
        }
        else
        {
            EmployeeManagementExample.SetActive(false);
        }

        if (curDialogueIdx == 6)
        {
            OfficeSliders.SetActive(true);
        }
        else
        {
            OfficeSliders.SetActive(false);
        }

        if (curDialogueIdx == 8)
        {
            menus.SetActive(true);
        }
        else
        {
            menus.SetActive(false);
        }
    }

    IEnumerator GoToMainGame()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainGame");
    }
}
