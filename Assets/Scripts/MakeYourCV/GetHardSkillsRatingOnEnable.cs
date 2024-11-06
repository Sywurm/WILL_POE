using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetHardSkillsRatingOnEnable : MonoBehaviour
{
    [Header("Common components")]
	[SerializeField] private Slider sliderOutput;
    [SerializeField] private TextMeshProUGUI percentageTextOutput_component;
    [Header("Hard Skill Specifics")]
    [SerializeField] private Slider marketingSlider;
    [SerializeField] private Slider designingSlider;
    [SerializeField] private Slider programmingSlider;
    [SerializeField] private Slider storyWritingSlider;

    private void OnEnable()
    {
        sliderOutput.value = (marketingSlider.value + designingSlider.value + programmingSlider.value + storyWritingSlider.value) / 4.0f;
        percentageTextOutput_component.text = (sliderOutput.value * 100.0f).ToString("F1") + "%";

        marketingSlider.interactable = false;
        designingSlider.interactable = false;
        programmingSlider.interactable = false;
        storyWritingSlider.interactable = false;
    }
}
