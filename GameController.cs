using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int m_ChooseActionCountDown;
	public int m_UseActionCountDown;
	//public int m_UseItemCountDown;

	public static GameController s_Instance;

	public GAMESTATE m_CurrentState;

	public enum GAMESTATE
	{
		ACTIONSELECT,
		ACTIONUSE,
		AITURN,
		WAITING,
		NONE
	}

	public static GameController Instance
	{
		get {return s_Instance;}
	}

	// Use this for initialization
	void Start () {
		if(s_Instance == null)
		{
			s_Instance = this;
		}
	}

	public int GetWaitTime
	{
		get 
		{
			switch (m_CurrentState)
			{
			case GAMESTATE.ACTIONSELECT:
				return m_ChooseActionCountDown;
			case GAMESTATE.ACTIONUSE:
				return m_UseActionCountDown;
			default:
				return 0;

			}
		}
	}

	public void UseAction(ActionController.ACTIONS actionType, GameObject useOn)
	{
		Debug.Log("ACION");
		if(m_CurrentState == GAMESTATE.ACTIONUSE)
		{
			switch(actionType)
			{
				case ActionController.ACTIONS.EXAMINE:
				case ActionController.ACTIONS.LISTENDOOR:
				case ActionController.ACTIONS.LISTENRADIUS:
				case ActionController.ACTIONS.LOCKPICK:
				case ActionController.ACTIONS.MOVE:
				Debug.Log("ACION MOVE");
					RoomManager.Instance.CurrentRoom.EnableDoors ();
				break;
				case ActionController.ACTIONS.SAFECRACK:
				case ActionController.ACTIONS.NONE:
					break;
			}
		}
	}

	public void UseActionClick(Action clickAction)
	{
		Debug.Log("ACION");
		Action action = clickAction.GetComponent<Action> ();
		//if(m_CurrentState == GAMESTATE.ACTIONUSE)
		//{
		switch(clickAction.m_ActionType)
			{
			case ActionController.ACTIONS.EXAMINE:
			case ActionController.ACTIONS.LISTENDOOR:
			case ActionController.ACTIONS.LISTENRADIUS:
			case ActionController.ACTIONS.LOCKPICK:
			case ActionController.ACTIONS.MOVE:
				Debug.Log("ACION MOVE");
				RoomManager.Instance.CurrentRoom.EnableDoors();
				break;
			case ActionController.ACTIONS.SAFECRACK:
			case ActionController.ACTIONS.NONE:
				break;
			}
		//}
	}

	public void SwitchState(GAMESTATE nextState)
	{
		m_CurrentState = nextState;
	}

	public Room PlayerRoom()
	{
		//Player Room
		return null;
	}

	public void FireDialogue(string text)
	{
		//Call the UI function.
	}
}
