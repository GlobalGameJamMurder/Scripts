using UnityEngine;
using System.Collections;
public class Bath : ObjectClass {
	
	void Start () {
		m_PossibleActions.Add (ActionController.ACTIONS.EXAMINE);
		m_PossibleActions.Add (ActionController.ACTIONS.SAFECRACK);
		m_PossibleActions.Add (ActionController.ACTIONS.LOCKPICK);

		m_PossibleItems.Add (0);
		m_PossibleItems.Add (1);
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
		switch(action)
		{
		case ActionController.ACTIONS.EXAMINE:
			GameController.Instance.FireDialogueCallBack("A very large bath. Two people\n would fit easily in this.", CheckContents);
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
