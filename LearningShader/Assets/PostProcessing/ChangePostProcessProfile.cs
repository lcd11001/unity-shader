using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class ChangePostProcessProfile : MonoBehaviour {
	public PostProcessProfile[] profiles;
	public Text text;
	int currentIndex;
	PostProcessVolume volume;

	// Use this for initialization
	void Start () 
	{
		currentIndex = (profiles != null && profiles.Length > 0) ? 0 : -1;
		volume = GetComponent<PostProcessVolume>();
		
		if (currentIndex != -1)
		{
			text.text = GetProfileName();
			volume.profile = profiles[currentIndex];
		}
	}
	
	public void NextProfile()
	{
		if (volume != null && currentIndex != -1)
		{
			currentIndex = (currentIndex + 1) % profiles.Length;
			// Debug.Log("next " + currentIndex);
			text.text = GetProfileName();
			volume.profile = profiles[currentIndex];
		}
	}

	public void PrevProfile()
	{
		if (volume != null && currentIndex != -1)
		{
			currentIndex = (currentIndex - 1 + profiles.Length) % profiles.Length;
			// Debug.Log("prev " + currentIndex);
			text.text = GetProfileName();
			volume.profile = profiles[currentIndex];
		}
	}

	public string GetProfileName()
	{
		if (currentIndex != -1)
		{
			return profiles[currentIndex].name;
		}

		return "unknown index " + currentIndex;
	}
}
