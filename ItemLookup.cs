using UnityEngine;
using System.Collections;

public class ItemLookup: MonoBehaviour {
	static ItemLookup m_Instance;
	public static ItemLookup Instance{
		get{ return m_Instance;}
	}
	[System.Serializable]
	public class Item{
		[SerializeField]private Sprite m_sprite;
		public Sprite Sprite{
			get{return m_sprite;}
		}
		[SerializeField]private string m_Name;
		[SerializeField]private string m_FindDescription;
		public string Name{
			get{return m_Name;}
		}
		public string FindDescription{
			get{return m_FindDescription;}
		}
		[System.NonSerialized]
		private bool m_InInventory = false;
		public bool InInventory{
			set{m_InInventory = value;}
			get{return m_InInventory;}
		}
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
