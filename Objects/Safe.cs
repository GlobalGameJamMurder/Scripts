using UnityEngine;
using System.Collections;

public class Safe : ObjectClass {
	[SerializeField]int SafeCodeID;
	bool m_Locked = true;
	// Use this for initialization
	void Start () {
		m_PossibleActions.Add (ActionController.ACTIONS.EXAMINE);
		m_PossibleActions.Add (ActionController.ACTIONS.SAFECRACK);
		m_PossibleActions.Add (ActionController.ACTIONS.LOCKPICK);

		m_PossibleItems.Add (0);
		m_PossibleItems.Add (2);
		m_PossibleItems.Add (3);
		m_PossibleItems.Add (4);
		m_PossibleItems.Add (5);
		m_PossibleItems.Add (6);
		m_PossibleItems.Add (7);
		m_PossibleItems.Add (8);
		m_PossibleItems.Add (9);
		m_StartFinished = true;
	}
	
	public override void Interact (ActionController.ACTIONS action) 
	{
		if(m_Locked)
		{
			switch(action)
			{
					
			case ActionController.ACTIONS.EXAMINE:
				if(ItemLookup.Instance.GetItem(SafeCodeID).InInventory)
				{
					GameController.Instance.FireDialogueCallBack("After typing in the code, the safe opens.\nI wonder whats inside...", CheckContents);
					m_Locked = false;
				}
				else
					GameController.Instance.FireDialogue("The safe is locked.\nIt looks too sturdy to break...");
				break;
			case ActionController.ACTIONS.SAFECRACK:
				GameController.Instance.FireDialogue("After a lot of fiddling, the safe,\nsprings open...");
				m_Locked = false;
				break;
			case ActionController.ACTIONS.LOCKPICK:
				GameController.Instance.FireDialogue("The lock pick is no use; this safe\nuses a combination to open...");
				break;
			}
		}
		else
		{
			switch(action)
			{
				
			case ActionController.ACTIONS.EXAMINE:
				GameController.Instance.FireDialogueCallBack("Its unlocked!.\n I wonder whats inside...", CheckContents);
				break;
			case ActionController.ACTIONS.SAFECRACK:
				GameController.Instance.FireDialogue("Why am I doing this? \n I don't need to do this.");
				m_Locked = false;
				break;
			case ActionController.ACTIONS.LOCKPICK:
				GameController.Instance.FireDialogue("I don't need to do this.");
				break;

			}
		}
	}
}
