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
	[SerializeField] private TextMeshProUGUI adviceTextOutput_component;
	[Header("Hard Skill Specifics")]
	[SerializeField] private Slider marketingSlider;
	[SerializeField] private Slider designingSlider;
	[SerializeField] private Slider programmingSlider;
	[SerializeField] private Slider storyWritingSlider;

	private void OnEnable()
	{
		adviceTextOutput_component.gameObject.SetActive(false);
		sliderOutput.value = (marketingSlider.value + designingSlider.value + programmingSlider.value + storyWritingSlider.value) / 4.0f;
		percentageTextOutput_component.text = (sliderOutput.value * 100.0f).ToString("F1") + "%";

		marketingSlider.interactable = false;
		designingSlider.interactable = false;
		programmingSlider.interactable = false;
		storyWritingSlider.interactable = false;

		float min = Mathf.Min(marketingSlider.value, designingSlider.value, programmingSlider.value, storyWritingSlider.value);
		if (marketingSlider.value < 0.5f && marketingSlider.value == min)
		{
			adviceTextOutput_component.gameObject.SetActive(true);
			adviceTextOutput_component.text = "Your Weakest skill is Marketing, try to work on this!";
		}
		else if (designingSlider.value < 0.5f && designingSlider.value == min)
		{
			adviceTextOutput_component.gameObject.SetActive(true);
			adviceTextOutput_component.text = "Your Weakest skill is Designing, try to work on this!";
		}
		else if (programmingSlider.value < 0.5f && programmingSlider.value == min)
		{
			adviceTextOutput_component.gameObject.SetActive(true);
			adviceTextOutput_component.text = "Your Weakest skill is Programming, try to work on this!";
		}
		else if (storyWritingSlider.value < 0.5f && storyWritingSlider.value == min)
		{
			adviceTextOutput_component.gameObject.SetActive(true);
			adviceTextOutput_component.text = "Your Weakest skill is Story Writing, try to work on this!";
		}
	}
}
