using UnityEngine;
using UnityEngine;
using System.Collections;
public class Bath : ObjectClass {
	
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
			GameController.Instance.FireDialogue("A very large bath. Two people\n would fit easily in this.");
			break;
			
			//if i find an item something new hey yoo la gorgeous bastard 101!!!!!!!
			
		case ActionController.ACTIONS.SAFECRACK:
			GameController.Instance.FireDialogue("A bath disguised as a safe!?\n Maybe one day but not this day.");
			break;
		case ActionController.ACTIONS.LOCKPICK:
			GameController.Instance.FireDialogue("Where's the keyhole? Oh wait... \n There isn't one.");
			
			break;
		}
	}
}
