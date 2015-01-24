using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

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

	public void UseAction(ActionController.ACTIONS actionType, GameObject useOn)
	{
		switch(actionType)
		{
		case ActionController.ACTIONS.EXAMINE:
		case ActionController.ACTIONS.LISTENDOOR:
		case ActionController.ACTIONS.LISTENRADIUS:
		case ActionController.ACTIONS.LOCKPICK:
		case ActionController.ACTIONS.MOVE:
		case ActionController.ACTIONS.NONE:
			break;
		}
	}

	public void SwitchState(GAMESTATE nextState)
	{
		m_CurrentState = nextState;
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void FireDialogue(string text)
	{
		//Call the UI function.
	}
}
