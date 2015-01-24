using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	[SerializeField]ActionController m_ActionCont;
	[SerializeField]Room m_CurrentRoom; //Serializable so the start room can be set
	private static Player m_Instance = null;
	private static ActionController.ACTIONS m_CurrentSelectedAction = ActionController.ACTIONS.NONE;
	//private static Object? m_CurrentSelectedObject;

	public 
	// Use this for initialization
	void Start () {
		if (m_Instance == null) 
		{
			m_Instance = this;
		}
		
	}
	
	public static Player Instance {
		get {
			if(m_Instance == null) 
			{
				m_Instance = FindObjectOfType<RoomManager>();
			}
			return m_Instance;
		}
	}

	//this funtion will be called by a actiontype button call back
	public void ActionTypeSelected(int EnumID)
	{
		m_CurrentSelectedAction = (ActionController.ACTIONS)EnumID;
		switch (m_CurrentSelectedAction)
		{
			//activate as in allow the player to click on it
			//m_CurrentRoom.getObjects?
			//m_CurrentRoom.getDoors?
		case ActionController.ACTIONS.EXAMINE:
			//light/activate? container objects
			break;
		case ActionController.ACTIONS.LISTENDOOR:
			//light/activate? doors
			break;
		case ActionController.ACTIONS.LISTENRADIUS:
			//m_CurrentSelectedObject = gameObject;
			UseAction();//use the action straight away
			break;
		case ActionController.ACTIONS.LOCKPICK:
			//light/activate? doors
			break;
		case ActionController.ACTIONS.MOVE:
			//light/activate? doors
			break;
		case ActionController.ACTIONS.SAFECRACK:
			//light/activate? the safe or maybe just safe crack it instantly.
			break;
		case ActionController.ACTIONS.NONE:
			GameController.Instance.FireDialogue("Something Went Wrong in Action");
			break;
		}

	}

	public bool UseAction()
	{
		//m_ActionCont.UseAction(GetAction(m_CurrentSelectedAction), m_CurrentSelectedObject);
		m_CurrentSelectedAction = ActionController.ACTIONS.NONE;
	}

	//this funtion will be called by a object button call back
	public void ObjectSelected(GameObject selectecObject)
	{
		//m_CurrentSelectedObject = selectecObject;
		//check compatibility with action?
		UseAction ();
	}

	public void MoveRoom(Room newRoom)
	{
		m_CurrentRoom = newRoom;
	}
}
