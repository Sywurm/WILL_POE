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
	[SerializeField] private TextMeshProUGUI adviceTextOutput_component;
	[Header("Soft Skill Specifics")]
	[SerializeField] private Slider communicationSlider;
	[SerializeField] private Slider teamWorkSlider;
	[SerializeField] private Slider projectManagementSlider;
	[SerializeField] private Slider timeManagementSlider;

	private void OnEnable()
	{
		adviceTextOutput_component.gameObject.SetActive(false);
		sliderOutput.value = (communicationSlider.value + teamWorkSlider.value + projectManagementSlider.value + timeManagementSlider.value) / 4.0f;
		percentageTextOutput_component.text = (sliderOutput.value * 100.0f).ToString("F1") + "%";
		
		communicationSlider.interactable = false;
		teamWorkSlider.interactable = false;
		projectManagementSlider.interactable = false;
		timeManagementSlider.interactable = false;

		float min = Mathf.Min(communicationSlider.value, teamWorkSlider.value, projectManagementSlider.value, timeManagementSlider.value);
		if (communicationSlider.value < 0.5f && communicationSlider.value == min)
		{
			adviceTextOutput_component.gameObject.SetActive(true);
			adviceTextOutput_component.text = "Your Weakest skill is Communication, try to work on this!";
		}
		else if (teamWorkSlider.value < 0.5f && teamWorkSlider.value == min)
		{
			adviceTextOutput_component.gameObject.SetActive(true);
			adviceTextOutput_component.text = "Your Weakest skill is Team Work, try to work on this!";
		}
		else if (projectManagementSlider.value < 0.5f && projectManagementSlider.value == min)
		{
			adviceTextOutput_component.gameObject.SetActive(true);
			adviceTextOutput_component.text = "Your Weakest skill is Project Management, try to work on this!";
		}
		else if (timeManagementSlider.value < 0.5f && timeManagementSlider.value == min)
		{
			adviceTextOutput_component.gameObject.SetActive(true);
			adviceTextOutput_component.text = "Your Weakest skill is Time Management, try to work on this!";
		}
	}
}
