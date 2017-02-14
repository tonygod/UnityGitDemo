using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;

public class AnalyticsModule : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SetCountry();
		BuyLevelIncrease();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void BuyLevelIncrease()
	{
		Analytics.Transaction("LevelIncrease", 1, "EUR");
		LevelUp();
	}

	void LevelUp()
	{
		Analytics.CustomEvent("levelUp", new Dictionary<string, object>
		{
			{ "newLevel", 2 },
			{ "trigger", "purchase" },
		});
	}

	void SetCountry()
	{
		Analytics.CustomEvent("demographics", new Dictionary<string, object>
		{
			{ "country", "UK" },
		});
	}
}
