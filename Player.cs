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
				m_Instance = FindObjectOfType<Player>();
			}
			return m_Instance;
		}
	}

	//When the action usage faze starts or a room is entered this function should be called
	public void CheckActions()
	{
		GameObject[] ObjectsInRoom = new GameObject[12];// = m_CurrentRoom.GetObjects();
		GameObject[] DoorsInRoom = new GameObject[12];// = m_CurrentRoom.GetDoors();
		for (int i = 0; i < m_ActionCont.m_QueuedActions.Count; i++) 
		{
			bool ButtonEnabled = false;
			switch (m_ActionCont.m_QueuedActions[i].m_ActionType)
			{
			case ActionController.ACTIONS.EXAMINE:
				for(int j = 0; j < ObjectsInRoom.Length; i++)
				{
					//switch case Object types
					//if an object is found that can be examined then
					ButtonEnabled = true;
				}
				break;
			case ActionController.ACTIONS.LOCKPICK:
				for(int j = 0; j < DoorsInRoom.Length; i++)
				{
					//if an door is found that can be unlocked then
					ButtonEnabled = true;
				}
				break;
			case ActionController.ACTIONS.SAFECRACK:
				for(int j = 0; j < ObjectsInRoom.Length; i++)
				{
					//if a locked safe is found then
					ButtonEnabled = true;
				}
				break;
			case ActionController.ACTIONS.LISTENDOOR:
			case ActionController.ACTIONS.LISTENRADIUS:
			case ActionController.ACTIONS.MOVE:
				//I am going to assume there will always be doors
				ButtonEnabled = true;
				break;
			case ActionController.ACTIONS.NONE:
				Debug.LogError("Queued action is set to NONE");
				break;
			}
			if(ButtonEnabled)
			{
				//should change this to enabling collider or button comp
				m_ActionCont.m_QueueButtons[i].SetActive(true);
				//colour button normally
			}
			else
			{
				//should change this to disabling collider or button comp
				m_ActionCont.m_QueueButtons[i].SetActive(false);
				//gray out button
			}
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
		return true;
	}

	//this funtion will be called by a object button call back
	public void ObjectSelected(GameObject selectecObject)
	{
		//m_CurrentSelectedObject = selectedObject;
		//check compatibility with action?
		UseAction ();
	}

	public void MoveRoom(Room newRoom)
	{
		//check actions called here?
		m_CurrentRoom = newRoom;
	}
}
