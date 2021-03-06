﻿using UnityEngine;
using System.Collections;

public class ToiletCistern : ObjectClass {
	
	protected override void Initialise(){
		m_PossibleActions.Add (ActionController.ACTIONS.EXAMINE);
		m_PossibleActions.Add (ActionController.ACTIONS.SAFECRACK);
		m_PossibleActions.Add (ActionController.ACTIONS.LOCKPICK);

		m_PossibleItems.Add (0);
		m_PossibleItems.Add (2);
		m_PossibleItems.Add (6);
		m_PossibleItems.Add (8);
		m_PossibleItems.Add (9);
	}
	
	public override void Interact (ActionController.ACTIONS action) 
	{
		switch(action)
		{
		case ActionController.ACTIONS.EXAMINE:
			GameController.Instance.FireDialogueCallBack("The toliet looks like its never been used. \n", CheckContents);
			break;
			
			//if i find an item something new hey yoo la gorgeous bastard 101!!!!!!!
			
		case ActionController.ACTIONS.SAFECRACK:
			GameController.Instance.FireDialogue("I can only use this on a safe.\n I wonder if there's one around here.");
			break;
		case ActionController.ACTIONS.LOCKPICK:
			GameController.Instance.FireDialogue("I can't use this here.");
			
			break;
		}
	}
}