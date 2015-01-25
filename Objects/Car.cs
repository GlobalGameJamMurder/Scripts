﻿using UnityEngine;
using System.Collections;

public class Car : ObjectClass {
	
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
			GameController.Instance.FireDialogue("The car is in top condition.\n If only I had the keys and a full tank...");
			break;
		case ActionController.ACTIONS.SAFECRACK:
			GameController.Instance.FireDialogue("If only the car had dials.\n The safecrack is no use here...");
			break;
		case ActionController.ACTIONS.LOCKPICK:
			GameController.Instance.FireDialogue("The lock pick is no use; this safe\nuses a combination to open...");
			
			break;
		}
	}
}
