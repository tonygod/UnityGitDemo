using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class AdPlayer : MonoBehaviour
{
	bool hasPlayed = false;

	private void Start()
	{
		//StartCoroutine(AdPlay(1));
		StartCoroutine(RewardedAdPlay(5));
	}

	IEnumerator AdPlay(float seconds)
	{
		while (!hasPlayed)
		{
			ShowAd();
			yield return new WaitForSeconds(seconds);
		}
	}


	IEnumerator RewardedAdPlay(float seconds)
	{
		while (!hasPlayed)
		{
			ShowRewardedAd();
			yield return new WaitForSeconds(seconds);
		}
	}

	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			hasPlayed = true;
			Advertisement.Show();
		}
	}

	public void ShowRewardedAd()
	{
		if (Advertisement.IsReady("rewardedVideoZone"))
		{
			hasPlayed = true;
			Debug.Log("Showing Rewarded Ad");
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideoZone", options);
		} else
		{
			Debug.Log("Rewareded Ad not ready");
		}
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
			case ShowResult.Finished:
				Debug.Log("The ad was successfully shown.");
				hasPlayed = true;
				//
				// YOUR CODE TO REWARD THE GAMER
				// Give coins etc.
				break;
			case ShowResult.Skipped:
				Debug.Log("The ad was skipped before reaching the end.");
				break;
			case ShowResult.Failed:
				Debug.LogError("The ad failed to be shown.");
				break;
		}
	}
}
