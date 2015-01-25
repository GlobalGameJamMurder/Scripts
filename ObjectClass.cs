using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ObjectClass : MonoBehaviour {

	public Button m_Button;
	public List<ActionController.ACTIONS> m_PossibleActions = new List<ActionController.ACTIONS> ();
	public List<int> m_Items = new List<int> ();
	private static List<int> m_NonAllocatedItems = new List<int> () {0,1,2,3,4,5,6,7,8,9};
	[System.NonSerialized]public List<int> m_PossibleItems = new List<int> ();//items that can be put in the object

	// Use this for initialization
	void Start () {
		m_Button.onClick.AddListener(() => { OnClick(); });
		Initialise ();
		StartCoroutine (LateStart ());
	}	

	protected virtual void Initialise()
	{}

	void OnDestroy()
	{
		m_Button.onClick.RemoveAllListeners();
	}

	IEnumerator LateStart()
	{
		yield return new WaitForSeconds (Random.Range(0.0f, 1.0f));
		if(m_NonAllocatedItems.Count > 0)
		{
			List<int> PotentialItems = new List<int> ();
			for(int i = 0; i < m_NonAllocatedItems.Count; i++)
			{
				for(int j = 0; j < m_PossibleItems.Count; j++)
				{
					if(m_NonAllocatedItems[i] == m_PossibleItems[j])
					{
						PotentialItems.Add(m_NonAllocatedItems[i]);
					}
				}
			}
			if(PotentialItems.Count == 0)
				yield break;
			int id = Random.Range(0, PotentialItems.Count);
			m_Items.Add(PotentialItems[id]);
			m_NonAllocatedItems.Remove(PotentialItems[id]);
		}
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
			m_Items.Remove(m_Items[0]);
			if(item.IsEvidence)
			{
				GameController.Instance.GetComponent<UIManager>().IncrementEvidenceCounter();
			}
			return;
		}
		GameController.Instance.FireDialogue("...Nothing.");
	}
}
