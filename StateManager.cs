using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StateManager : MonoBehaviour {

	public GameObject m_AbilitySelectScreen;
	public GameObject m_GameScreen;

	public Image blackScreen;

	public void SetState(int state)
	{
		switch ((GameController.GAMESTATE)state)
		{
		case GameController.GAMESTATE.ACTIONSELECT:
			StartCoroutine(SwitchScreen(m_AbilitySelectScreen, m_GameScreen));
			break;
		case GameController.GAMESTATE.ACTIONUSE:
			StartCoroutine(SwitchScreen(m_GameScreen, m_AbilitySelectScreen));
			break;
		case GameController.GAMESTATE.AITURN:
			break;
		case GameController.GAMESTATE.WAITING:
			break;
		}
	}

	IEnumerator SwitchScreen(GameObject activate, GameObject deactivate)
	{
		Color color = blackScreen.color;
		float endtime = Time.time + 0.5f;
		while (Time.time < endtime)
		{
			float s  = (endtime - Time.time)/0.5f;
			color.a = 1-s;
			blackScreen.color = color;
			yield return null;
		}
		activate.SetActive (true);
		deactivate.SetActive (false);
		endtime = Time.time + 0.5f;
		while (Time.time < endtime)
		{
			float s  = (endtime - Time.time)/0.5f;
			color.a = s;
			blackScreen.color = color;
			yield return null;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
