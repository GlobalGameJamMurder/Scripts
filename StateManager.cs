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
			StartCoroutine(FadeScenes(MenuOnly));
			break;
		case GameController.GAMESTATE.ACTIONUSE:
			blackScreen.gameObject.SetActive(false);
			StartCoroutine(FadeScenes(TransferActions));
			break;
		case GameController.GAMESTATE.AITURN:
			blackScreen.gameObject.SetActive(true);
			break;
		case GameController.GAMESTATE.WAITING:
			StartCoroutine(FadeScenes(DisableBoth));
			break;
		}

		GameController.Instance.m_CurrentState = (GameController.GAMESTATE)state;
	}

	private void DisableBoth()
	{
		m_GameScreen.SetActive(false);
		m_AbilitySelectScreen.SetActive(false);
	}

	private void MenuOnly()
	{
		m_GameScreen.SetActive(false);
		m_AbilitySelectScreen.SetActive(true);
	}

	IEnumerator FadeScenes(System.Action Foo)
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

		Foo ();

		endtime = Time.time + 0.5f;
		while (Time.time < endtime)
		{
			float s  = (endtime - Time.time)/0.5f;
			color.a = s;
			blackScreen.color = color;
			yield return null;
		}
		
		blackScreen.gameObject.SetActive (false);
	}

	void TransferActions()
	{

		m_GameScreen.SetActive(true);
		m_AbilitySelectScreen.SetActive(false);

		ActionController actionController = GameController.Instance.gameObject.GetComponent<ActionController>();
		
		for(int i = 0; i < actionController.m_QueuedActions.Count; i++)
		{
			m_ActionTriggerButtons[i].SetActive(true);
			m_ActionTriggerButtons[i].GetComponent<Action>().SetAction(actionController.m_QueuedActions[i].m_ActionType);
			Text text = m_ActionTriggerButtons[i].GetComponentInChildren<Text>();

			m_ActionTriggerButtons[i].GetComponentInChildren<Text>().text = actionController.m_QueuedActions[i].m_Title;
			//m_ActionTriggerButtons[i] = m_ActionTriggerButtons[i].GetComponent<Action>();
		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
