using UnityEngine;
using System.Collections;

public class Safe : ObjectClass {

	// Use this for initialization
	void Start () {
		m_PossibleActions.Add (ActionController.ACTIONS.EXAMINE);
		m_PossibleActions.Add (ActionController.ACTIONS.SAFECRACK);
		m_PossibleActions.Add (ActionController.ACTIONS.LOCKPICK);
	}
	
	public override void Interact (ActionController.ACTIONS action) 
	{
		switch(action)
		{
		case ActionController.ACTIONS.EXAMINE:
			GameController.Instance.FireDialogue("The safe is locked.\nIt looks too sturdy to break...");
			break;
		case ActionController.ACTIONS.SAFECRACK:
			GameController.Instance.FireDialogue("After a lot of fiddling, the safe,\nsprings open...");
			break;
		case ActionController.ACTIONS.LOCKPICK:
			GameController.Instance.FireDialogue("The lock pick is no use; this safe\nuses a combination to open...");
			
			break;
		}
	}
}
