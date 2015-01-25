using UnityEngine;
using System.Collections;

public class ItemLookup: MonoBehaviour {
	static ItemLookup m_Instance;
	public static ItemLookup Instance{
		get{ return m_Instance;}
	}
	[System.Serializable]
	public class Item{
		public Sprite m_sprite;
		public string m_Name, m_FindDescription;
		public bool m_OneUse;
		[System.NonSerialized]
		public bool m_InInventory = false;
		//Description?
	}

	[SerializeField]Item[] m_Items;
	void Start () {
		m_Instance = this;
	}
	public Item GetItem(int ID)
	{
		return m_Items [ID];
	}

}
