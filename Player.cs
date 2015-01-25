using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField]ActionController m_ActionCont;
	[SerializeField]Image m_PlayerIcon;
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
		m_PlayerIcon.transform.position = m_CurrentRoom.transform.position;
		
		
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
		else if(action.m_ActionType == ActionController.ACTIONS.LISTENDOOR)
		{
			m_CurrentRoom.EnableDoors();
		}
		else if(action.m_ActionType == ActionController.ACTIONS.LOCKPICK)
		{
			Player.Instance.UseAction(Player.Instance.m_CurrentRoom);
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

	public void GameOver()
	{
		
		GameController.Instance.FireDialogueCallBack("GAME OVER",BackToMainMenu);
		GameController.Instance.m_StateManager.m_GameScreen.SetActive(false);
		GameController.Instance.m_StateManager.m_AbilitySelectScreen.SetActive(false);

		for (int i = 0; i < GameController.Instance.m_StateManager.m_ActionTriggerButtons.Length; i++) {
			GameController.Instance.m_StateManager.m_ActionTriggerButtons[i].SetActive (false);
				}
		//StartCoroutine (Flash ());
	}
	
	public void BackToMainMenu()
	{
		Application.LoadLevel ("MainMenu");
	}

	public bool UseAction(Room obj)
	{
		if(m_CurrentSelectedAction != null && m_CurrentSelectedAction.m_ActionType == ActionController.ACTIONS.MOVE)
		{
			m_ActionCont.RemoveItemActions (m_CurrentSelectedAction);
			m_CurrentSelectedAction = null;
			m_CurrentRoom = obj;
			m_PlayerIcon.transform.position = obj.transform.position;
			m_CurrentRoom.DisableDoors();
			CheckActions();

			if(GameController.Instance.m_AIController.m_CurrentRoom == Player.Instance.m_CurrentRoom)
			{
				GameController.Instance.m_StateManager.StartFade(GameOver, true);
				
			}
			return true;
		}
		else if(m_CurrentSelectedAction != null && m_CurrentSelectedAction.m_ActionType == ActionController.ACTIONS.LISTENDOOR)
		{
			m_ActionCont.RemoveItemActions (m_CurrentSelectedAction);
			m_CurrentSelectedAction = null;
			if(obj == GameController.Instance.m_AIController.m_CurrentRoom)
			{
				GameController.Instance.FireDialogue("You hear a sound on the other side of the dooor!!");
			}
			else
			{
				GameController.Instance.FireDialogue("All is quite on the other side of the door.");
			}

			m_CurrentRoom.DisableDoors();
			CheckActions();
			
			if(GameController.Instance.m_AIController.m_CurrentRoom == Player.Instance.m_CurrentRoom)
			{
				GameController.Instance.m_StateManager.StartFade(GameOver, true);
				
			}
			return true;
		}
		else if(m_CurrentSelectedAction != null && m_CurrentSelectedAction.m_ActionType == ActionController.ACTIONS.LOCKPICK)
		{
			m_ActionCont.RemoveItemActions (m_CurrentSelectedAction);
			m_CurrentSelectedAction = null;
			if(obj.LeftDoor2.doorKey == 8 )
			{
				obj.LeftDoor2.doorKey = -1;
				GameController.Instance.FireDialogue("You lock pick the door!");
			}
			else
			if(obj.TopDoor1.doorKey == 9 )
			{
				obj.TopDoor1.doorKey = -1;
				GameController.Instance.FireDialogue("You lock pick the door!");
			}
			else
			{
				GameController.Instance.FireDialogue("No door to lock pick.");
			}
			
			m_CurrentRoom.DisableDoors();
			CheckActions();
			
			if(GameController.Instance.m_AIController.m_CurrentRoom == Player.Instance.m_CurrentRoom)
			{
				GameController.Instance.m_StateManager.StartFade(GameOver, true);
				
			}
			return true;
		}
		return false;
	}
}
