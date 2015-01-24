using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class ActionController : MonoBehaviour {

	public int m_ActionPointsPerTurn = 5;
	public int m_CurrentActionPoints = 5;

	public int m_CountdownTime = 20;

	public List<Action> m_QueuedActions = new List<Action> ();
	public Text m_DialogueBox;

	public enum ACTIONS
	{
		MOVE,
		LISTENDOOR,
		LISTENRADIUS,
		LOCKPICK,
		SAFECRACK,
		EXAMINE,
		NONE
	}

	// Use this for initialization
	void Start () {
		
	}

	public void ResetActions()
	{
		m_QueuedActions.Clear ();
		m_CurrentActionPoints = m_ActionPointsPerTurn;
		m_DialogueBox.text = "No Queued Actions";
	}

	public void AddAction (Action action)
	{
		if(action.m_ActionCost <= m_CurrentActionPoints)
		{
			m_QueuedActions.Add(action);
			m_CurrentActionPoints -= action.m_ActionCost;

			string actions = "";

			foreach (Action a in m_QueuedActions)
			{
				actions += a.m_Title + "\n";
			}

			m_DialogueBox.text = "Queued Actions:\n" + actions + "\nRemaining Action Points: " + m_CurrentActionPoints;
		}

		else
			GameController.Instance.FireDialogue("You Don't Have Enough\nActionPoints!");
	}

	public Action GetAction(ACTIONS requiredAction)
	{
		Action temp = null;
		foreach (Action a in m_QueuedActions)
		{
			if(a.m_ActionType == requiredAction)
			{
				temp = a;
				break;
			}
		}
		return temp;
	}

	public void UseAction(Action action, GameObject useOn)
	{
		m_QueuedActions.Remove(action);
		GameController.Instance.UseAction (action.m_ActionType, useOn);
	}
	// Update is called once per frame
	IEnumerator ActionSelect () 
	{
		float endTime = Time.time + m_CountdownTime;
		m_CurrentActionPoints = m_ActionPointsPerTurn;
		while(Time.time < endTime && GameController.Instance.m_CurrentState == GameController.GAMESTATE.ACTIONSELECT)
		{
			//Wait For Choice To Be Made
			yield return null;
		}
		GameController.Instance.SwitchState (GameController.GAMESTATE.ACTIONUSE);
		StartCoroutine (ActionUse ());

	}

	IEnumerator ActionUse()
	{
		float endTime = Time.time + GameController.Instance.GetWaitTime;
		while (Time.time < endTime && GameController.Instance.m_CurrentState == GameController.GAMESTATE.ACTIONUSE)
		{
			yield return null;
		}
	}
}
