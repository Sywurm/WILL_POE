using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MakeYourCVButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject createSectionPanel, evaluationSectionPanel;

    public void SwitchToEvaluation()
    {
        createSectionPanel.SetActive(false);
        evaluationSectionPanel.SetActive(true);

        // TODO: Disable UI for CV so they cant move items anymore
        // TODO: Calculate statistics to display.
    }
}
