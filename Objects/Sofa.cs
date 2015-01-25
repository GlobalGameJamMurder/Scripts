using UnityEngine;
using System.Collections;

public class Sofa : ObjectClass {

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
			GameController.Instance.FireDialogue("The sofa looks cumfy.\n I found nothing useful...");
			break;

			//if i find an item something new hey yoo la gorgeous bastard 101!!!!!!!

		case ActionController.ACTIONS.SAFECRACK:
			GameController.Instance.FireDialogue("If only everything was a safe.\n The safecrack is no use here...");
			break;
		case ActionController.ACTIONS.LOCKPICK:
			GameController.Instance.FireDialogue("The lock pick is no use but the\n sofa is good for sitting on. ");
			
			break;
		}
	}
}
