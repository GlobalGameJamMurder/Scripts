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
	public RectTransform m_Queue;

	public GameObject[] m_QueueButtons;

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
		m_DialogueBox.text = "Remaining Action Points: " + m_CurrentActionPoints;
		

		foreach (GameObject b in m_QueueButtons)
		{
			b.SetActive(false);
		}

		GetComponent<StateManager> ().ResetActions ();
	}

	public void AddAction (Action action)
	{
		if(action.m_ActionCost <= m_CurrentActionPoints)
		{

			m_CurrentActionPoints -= action.m_ActionCost;

			m_QueueButtons[m_QueuedActions.Count].SetActive(true);
			m_QueueButtons[m_QueuedActions.Count].GetComponent<Action>().SetAction(action.m_ActionType);
			m_QueueButtons[m_QueuedActions.Count].GetComponentInChildren<Text>().text = action.m_Title;
			m_QueuedActions.Add(m_QueueButtons[m_QueuedActions.Count].GetComponent<Action>());

			m_DialogueBox.text = "Remaining Action Points: " + m_CurrentActionPoints;
		}

		else
			GameController.Instance.FireDialogue("You Don't Have Enough\nActionPoints!");
	}

	public void RemoveItem(Action action)
	{
		int index = 0;
		while (action != m_QueueButtons[index].GetComponent<Action>() && index-1 < m_QueuedActions.Count-1)
		{
			++index;
		}

		int removalIndex = index;
		int cost = action.m_ActionCost;

		if(index < m_QueuedActions.Count)
		{
			for(int i = index + 1 ; i < m_QueuedActions.Count ; ++i)
			{
				m_QueueButtons[index].GetComponent<Action>().SetAction(m_QueueButtons[i].GetComponent<Action>().m_ActionType);
				++index;
			}
			m_QueueButtons[index].SetActive(false);
			m_CurrentActionPoints += cost;
			m_QueuedActions.RemoveAt(removalIndex);
			m_DialogueBox.text = "Remaining Action Points: " + m_CurrentActionPoints;
			
		}
	}

	public void RemoveItemActions(Action action)
	{
		if (m_QueuedActions.Count > 0)
		{
			int index = 0;
			GameObject[] buttons = GetComponent<StateManager>().m_ActionTriggerButtons;
			while (action.gameObject != buttons[index] && index-1 < m_QueuedActions.Count-1)
			{
				++index;
			}
			
			int removalIndex = index;
			int cost = action.m_ActionCost;
			
			if(index < m_QueuedActions.Count)
			{
				for(int i = index + 1 ; i < m_QueuedActions.Count ; ++i)
				{
					buttons[index].GetComponent<Action>().SetAction(buttons[i].GetComponent<Action>().m_ActionType);
					++index;
				}
				buttons[index].SetActive(false);
				m_CurrentActionPoints += cost;
				m_QueuedActions.RemoveAt(removalIndex);
				
			}
		}

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

	public void UseAction(Action action)
	{
		RemoveItem (action);
	}

}
