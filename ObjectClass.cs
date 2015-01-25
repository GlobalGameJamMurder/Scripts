using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ObjectClass : MonoBehaviour {

	public Button m_Button;
	public List<ActionController.ACTIONS> m_PossibleActions = new List<ActionController.ACTIONS> ();
	public List<ItemInformation> m_Items = new List<ItemInformation> ();

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
}
