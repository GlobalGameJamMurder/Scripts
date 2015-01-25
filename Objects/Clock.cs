using UnityEngine;
using System.Collections;
public class Clock : ObjectClass {
	
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
			GameController.Instance.FireDialogue("They don't make them like these anymore. \nNever know what could be inside a clock. ");
			break;
			
			//if i find an item something new hey yoo la gorgeous bastard 101!!!!!!!
			
		case ActionController.ACTIONS.SAFECRACK:
			GameController.Instance.FireDialogue("I can only use this on a safe.\n I wonder if there's one around here");
			break;
		case ActionController.ACTIONS.LOCKPICK:
			GameController.Instance.FireDialogue("I can't use this here.");
			
			break;
		}
	}
}