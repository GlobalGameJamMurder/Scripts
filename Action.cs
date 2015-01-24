using UnityEngine;
using System.Collections;

public class Action : MonoBehaviour {

	public ActionController.ACTIONS m_ActionType;
	public string m_Name;
	public string m_Description;
	public int m_ActionCost;

	// Use this for initialization
	void Start () {
	
	}

	public void SetAction(ActionController.ACTIONS action)
	{
		m_ActionType = action;

		switch (m_ActionType)
		{
		case ActionController.ACTIONS.EXAMINE:
			m_Name = "Examine";
			m_Description = "Clues become clear to you!";
			m_ActionCost = 1;
			break;
		case ActionController.ACTIONS.LISTENDOOR:
			m_Name = "Listen at the Door";
			m_Description = "See if there is anyone in the next room.";
			m_ActionCost = 2;
			break;
		case ActionController.ACTIONS.LISTENRADIUS:
			m_Name = "Focus";
			m_Description = "Detect anyone close by.";
			m_ActionCost = 3;
			break;
		case ActionController.ACTIONS.LOCKPICK:
			m_Name = "Pick Lock";
			m_Description = "Unlock a locked door.";
			m_ActionCost = 2;
			break;
		case ActionController.ACTIONS.MOVE:
			m_Name = "Move";
			m_Description = "Move to an adjacent room.";
			m_ActionCost = 2;
			break;
		case ActionController.ACTIONS.SAFECRACK:
			m_Name = "Crack Safe";
			m_Description = "Opens the safe.";
			m_ActionCost = 5;
			break;
		case ActionController.ACTIONS.NONE:
			m_Name = "";
			m_Description = "";
			m_ActionCost = 0;
			break;
		}
		m_Description += " Cost = " + m_ActionCost;
	}

	public void OnUse(GameObject useAgainst)
	{
		switch (m_ActionType)
		{
		case ActionController.ACTIONS.EXAMINE:
			Examine(useAgainst);
			break;
		case ActionController.ACTIONS.LISTENDOOR:
			Listen(useAgainst);
			break;
		case ActionController.ACTIONS.LISTENRADIUS:
			Focus(useAgainst);
			break;
		case ActionController.ACTIONS.LOCKPICK:
			Pick(useAgainst);
			break;
		case ActionController.ACTIONS.MOVE:
			Move(useAgainst);
			break;
		case ActionController.ACTIONS.SAFECRACK:
			SafeCrack(useAgainst);
			break;
		case ActionController.ACTIONS.NONE:
			GameController.Instance.FireDialogue("Something Went Wrong in Action");
			break;
		}
	}

	void Examine(GameObject useAgainst)
	{

	}
	void Listen(GameObject useAgainst)
	{

	}
	void Focus (GameObject useAgainst)
	{

	}
	void Pick(GameObject useAgainst)
	{

	}
	void Move(GameObject useAgainst)
	{

	}
	void SafeCrack(GameObject useAgainst)
	{

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
