using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Action : MonoBehaviour {

	public ActionController.ACTIONS m_ActionType;
	public string m_Title; 
	public string m_Description;
	public int m_ActionCost;

	public Text m_NameText;
	public Text m_DescriptionText;

	// Use this for initialization
	void Start () {
		SetAction (m_ActionType);
	
	}

	public void SetAction(ActionController.ACTIONS action)
	{
		m_ActionType = action;

		switch (m_ActionType)
		{
		case ActionController.ACTIONS.EXAMINE:
			m_Title = "Examine";
			m_Description = "Clues become clear to you!";
			m_ActionCost = 1;
			break;
		case ActionController.ACTIONS.LISTENDOOR:
			m_Title = "Listen at the Door";
			m_Description = "See if there is anyone in the next room.";
			m_ActionCost = 2;
			break;
		case ActionController.ACTIONS.LISTENRADIUS:
			m_Title = "Focus";
			m_Description = "Detect anyone close by.";
			m_ActionCost = 3;
			break;
		case ActionController.ACTIONS.LOCKPICK:
			m_Title = "Pick Lock";
			m_Description = "Unlock a locked door.";
			m_ActionCost = 2;
			break;
		case ActionController.ACTIONS.MOVE:
			m_Title = "Move";
			m_Description = "Move to an adjacent room.";
			m_ActionCost = 2;
			break;
		case ActionController.ACTIONS.SAFECRACK:
			m_Title = "Crack Safe";
			m_Description = "Opens the safe.";
			m_ActionCost = 5;
			break;
		case ActionController.ACTIONS.NONE:
			m_Title = "";
			m_Description = "";
			m_ActionCost = 0;
			break;
		}
		m_Description += "\nCost = " + m_ActionCost;

		if(m_NameText != null)
		{
			m_NameText.text = m_Title;
		}

		if (m_DescriptionText != null)
		{
			m_DescriptionText.text = m_Description;
		}
	}

	public void SelectItem()
	{
		Player.Instance.ActionTypeSelected (this);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
