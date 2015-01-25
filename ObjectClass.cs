using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ObjectClass : MonoBehaviour {

	public Button m_Button;
	public List<ActionController.ACTIONS> m_PossibleActions = new List<ActionController.ACTIONS> ();
	public List<int> m_Items = new List<int> ();
	[System.NonSerialized]public List<int> m_PossibleItems = new List<int> ();//items that can be put in the object

	// Use this for initialization
	void Start () {
		m_Button.onClick.AddListener(() => { OnClick(); });
	}	
	void OnDestroy()
	{
		m_Button.onClick.RemoveAllListeners();
	}

	private void OnClick()
	{
		Player.Instance.UseAction (this);
	}

	// Use this for initialization
	public virtual void Interact (ActionController.ACTIONS action) 
	{
		
	}

	public void CheckContents()
	{
		if(m_Items.Count > 0)
		{
			ItemLookup.Item item = ItemLookup.Instance.GetItem(m_Items[0]);
			item.InInventory = true;

			GameController.Instance.GetComponent<UIManager>().AddToInventory(item);
			GameController.Instance.FireDialogue(item.FindDescription);
			m_Items.Remove(0);
			return;
		}
		GameController.Instance.FireDialogue("...Nothing.");
	}
}
