using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetBioRatingOnEnable : MonoBehaviour
{
	[Header("Common components")]
	[SerializeField] private Slider sliderOutput;
	[SerializeField] private TextMeshProUGUI percentageTextOutput_component;
	[Header("Biography Specifics")]
	[SerializeField] private GameObject wordReplace1;
	[SerializeField] private GameObject wordReplace2;
	[SerializeField] private GameObject wordReplace3;
	[SerializeField] private GameObject wordReplace4;
	[SerializeField] private GameObject adviceText;
	[SerializeField] private TMP_InputField nameInput_component;

	private void OnEnable()
	{
		adviceText.SetActive(false);
		// rgb(210, 231, 244)
		float score = 0.0f; // Should be mapped 0..100
		if (wordReplace1.transform.childCount > 0)
		{
			bool success = wordReplace1.transform.GetChild(0).TryGetComponent(out AdjectiveScore component);
			if (success)
			{
				score += component.scoreValue1;
				wordReplace1.transform.GetChild(0).GetComponent<DraggableUIImage>().currentlyDraggable = false;
				wordReplace1.transform.GetChild(0).GetComponent<Image>().color = new Color32(210, 231, 244, 255);
			}
		}
		if (wordReplace2.transform.childCount > 0)
		{
			bool success = wordReplace2.transform.GetChild(0).TryGetComponent(out AdjectiveScore component);
			if (success)
			{
				score += component.scoreValue2;
				wordReplace2.transform.GetChild(0).GetComponent<DraggableUIImage>().currentlyDraggable = false;
				wordReplace2.transform.GetChild(0).GetComponent<Image>().color = new Color32(210, 231, 244, 255);
			}
		}
		if (wordReplace3.transform.childCount > 0)
		{
			bool success = wordReplace3.transform.GetChild(0).TryGetComponent(out AdjectiveScore component);
			if (success)
			{
				score += component.scoreValue3;
				wordReplace3.transform.GetChild(0).GetComponent<DraggableUIImage>().currentlyDraggable = false;
				wordReplace3.transform.GetChild(0).GetComponent<Image>().color = new Color32(210, 231, 244, 255);
			}
		}
		if (wordReplace4.transform.childCount > 0)
		{
			bool success = wordReplace4.transform.GetChild(0).TryGetComponent(out AdjectiveScore component);
			if (success)
			{
				score += component.scoreValue4;
				wordReplace4.transform.GetChild(0).GetComponent<DraggableUIImage>().currentlyDraggable = false;
				wordReplace4.transform.GetChild(0).GetComponent<Image>().color = new Color32(210, 231, 244, 255);
			}
		}
		score = Mathf.Clamp(score, 0, 100); // just in case, but really should never be out of this range anyways.
		sliderOutput.value = score / 100.0f;
		percentageTextOutput_component.text = score.ToString("F1") + "%";

		if (nameInput_component.text.Length <= 0)
		{
			adviceText.SetActive(true);
		}
	}
}
