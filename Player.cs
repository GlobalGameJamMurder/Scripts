using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField]ActionController m_ActionCont;
	public Room m_CurrentRoom; //Serializable so the start room can be set
	private static Player m_Instance = null;
	public static Action m_CurrentSelectedAction = null;
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
		ObjectSlot[] objectSlots = m_CurrentRoom.ObjectSlots;

		for (int index = 0 ; index < m_ActionCont.m_QueuedActions.Count ; ++index)
	    {
			ActionController.ACTIONS actionType = m_ActionCont.m_QueuedActions[index].m_ActionType;
			for (int i = 0 ; i < objectSlots.Length ; ++i)
			{
				if(objectSlots[i].m_Object != null && objectSlots[i].m_Object.m_PossibleActions.Contains(actionType))
				{
					m_ActionCont.m_QueuedActions[index].GetComponent<Button>().enabled = true;
					break;
				}

				if(i >= objectSlots.Length-1)
				{
					m_ActionCont.m_QueuedActions[index].GetComponent<Button>().enabled = false;
				}

			}
		}
	}

	//this funtion will be called by a actiontype button call back
	public void ActionTypeSelected(Action action)
	{
		ObjectSlot[] objectSlots = m_CurrentRoom.ObjectSlots;

		for (int i = 0 ; i < objectSlots.Length ; ++i)
		{
			if(objectSlots[i].m_Object != null)
				objectSlots[i].enabled = objectSlots[i].m_Object.m_PossibleActions.Contains(action.m_ActionType);
		}

		m_CurrentSelectedAction = action;

		if(action.m_ActionType == ActionController.ACTIONS.MOVE)
		{
			m_CurrentRoom.EnableDoors();
		}
		else 
		{
			m_CurrentRoom.DisableDoors();
		}

	}

	public bool UseAction(ObjectClass obj)
	{
		if(m_CurrentSelectedAction != null)
		{
			obj.Interact (m_CurrentSelectedAction.m_ActionType);
			m_ActionCont.RemoveItemActions (m_CurrentSelectedAction);
			m_CurrentSelectedAction = null;
			return true;
		}
		return false;
	}

	public bool UseAction(Room obj)
	{
		if(m_CurrentSelectedAction != null && m_CurrentSelectedAction.m_ActionType == ActionController.ACTIONS.MOVE)
		{
			m_ActionCont.RemoveItemActions (m_CurrentSelectedAction);
			m_CurrentSelectedAction = null;
			m_CurrentRoom = obj;
			m_CurrentRoom.DisableDoors();
			CheckActions();
			
			return true;
		}
		return false;
	}
}
