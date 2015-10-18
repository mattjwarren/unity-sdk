﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using IBM.Watson.AdaptiveComputing;
using IBM.Watson.Utilities;

[RequireComponent(typeof (Text))]
public class SettingsMood : MonoBehaviour {

	MoodType[] moodTypeList = null;
	private int currentMood = 0;
	private Text m_Text;
	const string display = "Mood: {0}";
	// Use this for initialization
	void Start () {
		currentMood = (int)MoodManager.Instance.currentMood;
		moodTypeList = MoodManager.Instance.moodTypeList;
		m_Text = GetComponent<Text>();
		m_Text.text = string.Format(display, moodTypeList[currentMood].ToString());
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.M)){
			currentMood = (currentMood + 1) % moodTypeList.Length;
			EventManager.Instance.SendEvent(EventManager.onMoodChange, currentMood);
			m_Text.text = string.Format(display, moodTypeList[currentMood].ToString());
		}
	}
}