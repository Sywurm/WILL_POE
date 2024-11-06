using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetSoftSkillsRatingOnEnable : MonoBehaviour
{
    [Header("Common components")]
    [SerializeField] private Slider sliderOutput;
    [SerializeField] private TextMeshProUGUI percentageTextOutput_component;
    [Header("Soft Skill Specifics")]
    [SerializeField] private Slider communicationSlider;
    [SerializeField] private Slider teamWorkSlider;
    [SerializeField] private Slider projectManagementSlider;
    [SerializeField] private Slider timeManagementSlider;

    private void OnEnable()
    {
        sliderOutput.value = (communicationSlider.value + teamWorkSlider.value + projectManagementSlider.value + timeManagementSlider.value) / 4.0f;
        percentageTextOutput_component.text = (sliderOutput.value * 100.0f).ToString("F1") + "%";
        
        communicationSlider.interactable = false;
        teamWorkSlider.interactable = false;
        projectManagementSlider.interactable = false;
        timeManagementSlider.interactable = false;
    }
}
