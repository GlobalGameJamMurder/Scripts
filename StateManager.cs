using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StateManager : MonoBehaviour {

	public GameObject m_AbilitySelectScreen;
	public GameObject m_GameScreen;

	public Image blackScreen;

	public GameObject[] m_ActionTriggerButtons;

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
		blackScreen.gameObject.SetActive (true);
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

		ActionController actionController = GameController.Instance.gameObject.GetComponent<ActionController>();
		
		for(int i = 0; i < actionController.m_QueuedActions.Count; i++)
		{
			m_ActionTriggerButtons[i].SetActive(true);
			m_ActionTriggerButtons[i].GetComponent<Action>().SetAction(actionController.m_QueuedActions[i].m_ActionType);
			m_ActionTriggerButtons[i].GetComponentInChildren<Text>().text = actionController.m_QueuedActions[i].m_Title;
			//m_ActionTriggerButtons[i] = m_ActionTriggerButtons[i].GetComponent<Action>();
		}

		while (Time.time < endtime)
		{
			float s  = (endtime - Time.time)/0.5f;
			color.a = s;
			blackScreen.color = color;
			yield return null;
		}

		blackScreen.gameObject.SetActive (false);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
