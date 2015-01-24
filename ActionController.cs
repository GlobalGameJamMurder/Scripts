﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ActionController : MonoBehaviour {

	public int m_ActionPointsPerTurn = 5;
	public int m_CurrentActionPoints = 5;

	public int m_CountdownTime = 20;

	public List<Action> m_QueuedActions = new List<Action> ();

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

	public void AddAction (Action action)
	{
		if(action.m_ActionCost <= m_CurrentActionPoints)
		{
			m_QueuedActions.Add(action);
			m_CurrentActionPoints -= action.m_ActionCost;
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
				m_QueuedActions.Remove(a);
				break;
			}
		}
		return temp;
	}

	public void UseAction(Action action)
	{

	}
	// Update is called once per frame
	IEnumerator ActionSelect () 
	{
		float endTime = Time.time + m_CountdownTime;
		m_CurrentActionPoints = m_ActionPointsPerTurn;
		while(Time.time < endTime)
		{
			//Wait For Choice To Be Made
			yield return null;
		}
		GameController.Instance.SwitchState (GameController.GAMESTATE.ACTIONUSE);
		StartCoroutine (ActionUse ());

	}

	IEnumerator ActionUse()
	{
		yield return null;
	}
}
