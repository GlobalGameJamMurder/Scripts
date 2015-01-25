using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoomClassifier : MonoBehaviour {

	public ObjectGeneration.ROOM m_Room;

	public void PopulateWithObjects()
	{
		ObjectSlot[] Slots = GetComponent<Room> ().ObjectSlots;

		for (int i = 0 ; i < Slots.Length ; ++i)
		{
			if (Slots[i] != null)
			{
				if(Random.Range(1,5) == 1)
				{
					GameObject temp = ObjectGeneration.m_Object.GetObject(m_Room);
					if(temp != null)
					{
						Slots[i].m_Object = temp.GetComponent<ObjectClass>();
						temp.transform.SetParent(Slots[i].transform);
						temp.transform.parent.gameObject.SetActive(true);
						temp.transform.localPosition = Vector3.zero;
						temp.transform.position += (Vector3)temp.transform.parent.GetComponent<Image>().GetPixelAdjustedRect().center;
						temp.transform.parent.GetComponent<Image>().enabled = false;
						temp.transform.localScale *= 0.75f;
					}
				}
			}
		}
	}

	// Use this for initialization
	void Start () {
		PopulateWithObjects ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
