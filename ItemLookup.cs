using UnityEngine;
using System.Collections;

public class ItemLookup: MonoBehaviour {
	static ItemLookup m_Instance;
	public static ItemLookup Instance{
		get{ return m_Instance;}
	}
	[System.Serializable]
	public class Item{
		public string m_Name;
		public Texture m_Texture;
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
