﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class Door 
{
	public Button door;
	public int doorModifier;
	public bool doorUse;
	public Room doorTo;
	public int doorKey = -1;
}

public class Room : MonoBehaviour 
{
	public Image roomImage;
	public Image roomBorderImage;

	[SerializeField] public Door BottomDoor1;
	[SerializeField] public Door BottomDoor2;
	[SerializeField] public Door TopDoor1;
	[SerializeField] public Door TopDoor2;
	[SerializeField] public Door LeftDoor1;
	[SerializeField] public Door LeftDoor2;
	[SerializeField] public Door RightDoor1;
	[SerializeField] public Door RightDoor2;

	public int roomSizeX = 100;
	public int roomSizeY = 100;

	public string roomLabel = "Room";

	public RectTransform objectSlots;

	public ObjectSlot ObjectSlotTL;
	public ObjectSlot ObjectSlotTC;
	public ObjectSlot ObjectSlotTR;

	public ObjectSlot ObjectSlotCL;
	public ObjectSlot ObjectSlotCC;
	public ObjectSlot ObjectSlotCR;

	public ObjectSlot ObjectSlotBL;
	public ObjectSlot ObjectSlotBC;
	public ObjectSlot ObjectSlotBR;

	private ObjectSlot[] Objects;
	
	public Text roomText; 

	public RectTransform roomTextRect; 

	private RectTransform doorBottom1Rect;
	private RectTransform doorTop1Rect;
	private RectTransform doorLeft1Rect;
	private RectTransform doorRight1Rect;
	private RectTransform doorBottom2Rect;
	private RectTransform doorTop2Rect;
	private RectTransform doorLeft2Rect;
	private RectTransform doorRight2Rect;

	public Sprite activeImage;
	public Sprite inactiveImage;
	public Sprite doorImage;
	public Sprite lockImage;

	public void EnableDoors()
	{
		if (BottomDoor1.doorKey == -1|| ItemLookup.Instance.GetItem(BottomDoor1.doorKey).InInventory) {
						BottomDoor1.door.enabled = true;
			BottomDoor1.door.image.overrideSprite = doorImage;
			BottomDoor1.door.image.SetNativeSize();
				} else {
			BottomDoor1.door.enabled = false;
			BottomDoor1.door.image.overrideSprite = lockImage;
			BottomDoor1.door.image.SetNativeSize();
				}

		if (BottomDoor2.doorKey == -1 || ItemLookup.Instance.GetItem(BottomDoor2.doorKey).InInventory) {
						BottomDoor2.door.enabled = true;
			BottomDoor2.door.image.overrideSprite = doorImage;
			BottomDoor2.door.image.SetNativeSize();
				}
		else {
			BottomDoor2.door.enabled = false;
			BottomDoor2.door.image.overrideSprite = lockImage;
			BottomDoor2.door.image.SetNativeSize();
		}

		if (TopDoor1.doorKey == -1 || ItemLookup.Instance.GetItem(TopDoor1.doorKey).InInventory) {
						TopDoor1.door.enabled = true;
			TopDoor1.door.image.overrideSprite = doorImage;
			TopDoor1.door.image.SetNativeSize();
				}
		else {
			TopDoor1.door.enabled = false;
			TopDoor1.door.image.overrideSprite = lockImage;
			TopDoor1.door.image.SetNativeSize();
		}

		if (TopDoor2.doorKey == -1 || ItemLookup.Instance.GetItem(TopDoor2.doorKey).InInventory) {
						TopDoor2.door.enabled = true;
			TopDoor2.door.image.overrideSprite = doorImage;
			TopDoor2.door.image.SetNativeSize();
				}
		else {
			TopDoor2.door.enabled = false;
			TopDoor2.door.image.overrideSprite = lockImage;
			TopDoor2.door.image.SetNativeSize();
		}

		if (LeftDoor1.doorKey == -1 || ItemLookup.Instance.GetItem(LeftDoor1.doorKey).InInventory) {
						LeftDoor1.door.enabled = true;
			LeftDoor1.door.image.overrideSprite = doorImage;
			LeftDoor1.door.image.SetNativeSize();
		}else {
			LeftDoor1.door.enabled = false;
			LeftDoor1.door.image.overrideSprite = lockImage;
			LeftDoor1.door.image.SetNativeSize();
		}
		
		if (LeftDoor2.doorKey == -1 || ItemLookup.Instance.GetItem(LeftDoor2.doorKey).InInventory) {
						LeftDoor2.door.enabled = true;
			LeftDoor2.door.image.overrideSprite = doorImage;
			LeftDoor2.door.image.SetNativeSize();
		}else {
			LeftDoor2.door.enabled = false;
			LeftDoor2.door.image.overrideSprite = lockImage;
			LeftDoor2.door.image.SetNativeSize();
		}

		if (RightDoor1.doorKey == -1 || ItemLookup.Instance.GetItem(RightDoor1.doorKey).InInventory) {
						RightDoor1.door.enabled = true;
			RightDoor1.door.image.overrideSprite = doorImage;
			RightDoor1.door.image.SetNativeSize();
		}else {
			RightDoor1.door.enabled = false;
			RightDoor1.door.image.overrideSprite = lockImage;
			RightDoor2.door.image.SetNativeSize();
		}

		if (RightDoor2.doorKey == -1 || ItemLookup.Instance.GetItem(RightDoor2.doorKey).InInventory) {
						RightDoor2.door.enabled = true;
			RightDoor2.door.image.overrideSprite = doorImage;
			RightDoor2.door.image.SetNativeSize();
		}else {
			RightDoor2.door.enabled = false;
			RightDoor2.door.image.overrideSprite = lockImage;
			RightDoor2.door.image.SetNativeSize();
		}
	}

	public void DisableDoors()
	{
		BottomDoor1.door.enabled = false;
		BottomDoor1.door.image.overrideSprite = doorImage;
		BottomDoor1.door.image.SetNativeSize();

		BottomDoor2.door.enabled = false;
		BottomDoor2.door.image.overrideSprite = doorImage;
		BottomDoor2.door.image.SetNativeSize();

		TopDoor1.door.enabled = false;
		TopDoor1.door.image.overrideSprite = doorImage;
		TopDoor1.door.image.SetNativeSize();

		TopDoor2.door.enabled = false;
		TopDoor2.door.image.overrideSprite = doorImage;
		TopDoor2.door.image.SetNativeSize();

		LeftDoor1.door.enabled = false;
		LeftDoor1.door.image.overrideSprite = doorImage;
		LeftDoor1.door.image.SetNativeSize();

		LeftDoor2.door.enabled = false;
		LeftDoor2.door.image.overrideSprite = doorImage;
		LeftDoor2.door.image.SetNativeSize();

		RightDoor1.door.enabled = false;
		RightDoor1.door.image.overrideSprite = doorImage;
		RightDoor1.door.image.SetNativeSize();

		RightDoor2.door.enabled = false;
		RightDoor2.door.image.overrideSprite = doorImage;
		RightDoor2.door.image.SetNativeSize();
	}

	public void DoorLeft1()
	{
		if (LeftDoor1.doorTo != null) {
			if(Player.m_CurrentSelectedAction.m_ActionType == ActionController.ACTIONS.MOVE)
			{
				roomImage.overrideSprite = inactiveImage;
				LeftDoor1.doorTo.roomImage.overrideSprite = activeImage;
			}
			Player.Instance.UseAction(LeftDoor1.doorTo);
			DisableDoors();
		}
	}

	public void DoorLeft2()
	{
		if (LeftDoor2.doorTo != null) {
			if(Player.m_CurrentSelectedAction.m_ActionType == ActionController.ACTIONS.MOVE)
			{
			roomImage.overrideSprite = inactiveImage;
			LeftDoor2.doorTo.roomImage.overrideSprite = activeImage;
			}
			Player.Instance.UseAction(LeftDoor2.doorTo);
			DisableDoors();
		}
	

	}

	public void DoorRight1()
	{
		if (RightDoor1.doorTo != null) {
			if(Player.m_CurrentSelectedAction.m_ActionType == ActionController.ACTIONS.MOVE)
				{
			roomImage.overrideSprite = inactiveImage;
			RightDoor1.doorTo.roomImage.overrideSprite = activeImage;
				}
			Player.Instance.UseAction(RightDoor1.doorTo );
			DisableDoors();
		}
	}

	public void DoorRight2()
	{
		if (RightDoor2.doorTo != null) {
			if(Player.m_CurrentSelectedAction.m_ActionType == ActionController.ACTIONS.MOVE)
					{
			roomImage.overrideSprite = inactiveImage;
			RightDoor2.doorTo.roomImage.overrideSprite = activeImage;
					}
			Player.Instance.UseAction(RightDoor2.doorTo);
			DisableDoors();
		}
	}
	

	public void DoorTop1()
	{
		if (TopDoor1.doorTo != null) {
			if(Player.m_CurrentSelectedAction.m_ActionType == ActionController.ACTIONS.MOVE)
						{
			roomImage.overrideSprite = inactiveImage;
			TopDoor1.doorTo.roomImage.overrideSprite = activeImage;
						}
			Player.Instance.UseAction(TopDoor1.doorTo );
			DisableDoors();
		}
	}

	public void DoorTop2()
	{
		if (TopDoor2.doorTo != null) {
							if(Player.m_CurrentSelectedAction.m_ActionType == ActionController.ACTIONS.MOVE)
							{
			roomImage.overrideSprite = inactiveImage;
			TopDoor2.doorTo.roomImage.overrideSprite = activeImage;
							}
			Player.Instance.UseAction(TopDoor2.doorTo);
			DisableDoors();
		}
	}

	public void DoorBottom2()
	{
		if (BottomDoor2.doorTo != null) {
			if(Player.m_CurrentSelectedAction.m_ActionType == ActionController.ACTIONS.MOVE)
								{
			roomImage.overrideSprite = inactiveImage;
			BottomDoor2.doorTo.roomImage.overrideSprite = activeImage;
								}
			Player.Instance.UseAction(BottomDoor2.doorTo );
			DisableDoors();
		}
	}

	public void DoorBottom1()
	{
		if (BottomDoor1.doorTo != null) {
			if(Player.m_CurrentSelectedAction.m_ActionType == ActionController.ACTIONS.MOVE)
									{
			roomImage.overrideSprite = inactiveImage;
			BottomDoor1.doorTo.roomImage.overrideSprite = activeImage;
									}
			Player.Instance.UseAction(BottomDoor1.doorTo );
			DisableDoors();
			}
	}

	// Use this for initialization
	void Start () {

		if (Player.Instance.m_CurrentRoom == this) {
						//EnableDoors ();
			DisableDoors ();
            roomImage.overrideSprite = activeImage;
				} else {
			DisableDoors ();
				}

		Objects = new ObjectSlot[] {
						ObjectSlotBC,
						ObjectSlotBL,
						ObjectSlotBR,
						ObjectSlotCC,
						ObjectSlotCL,
						ObjectSlotCR,
						ObjectSlotTC,
						ObjectSlotTL,
						ObjectSlotTR
				};



		doorBottom1Rect = BottomDoor1.door.GetComponent<RectTransform> ();
		doorTop1Rect = TopDoor1.door.GetComponent<RectTransform> ();
		doorLeft1Rect = LeftDoor1.door.GetComponent<RectTransform> ();
		doorRight1Rect = RightDoor1.door.GetComponent<RectTransform> ();
		doorBottom2Rect = BottomDoor2.door.GetComponent<RectTransform> ();
		doorTop2Rect = TopDoor2.door.GetComponent<RectTransform> ();
		doorLeft2Rect = LeftDoor2.door.GetComponent<RectTransform> ();
		doorRight2Rect = RightDoor2.door.GetComponent<RectTransform> ();

		roomTextRect = roomText.GetComponent<RectTransform> ();
	}

	public Room GetRandomRoom()
	{
		int count = 0;
		while (++count < 100)
		{
			int rand = Random.Range (0,8);


			switch (rand)
			{
			case 0:
				if(RightDoor1.doorTo != null)
				{
					return RightDoor1.doorTo;
				}
				break;
			case 1:
				if(LeftDoor1.doorTo != null)
				{
					return LeftDoor1.doorTo;
				}
				break;
			case 2:
				if(TopDoor1.doorTo != null)
				{
					return TopDoor1.doorTo;
				}
				break;
			case 3:
				if(BottomDoor1.doorTo != null)
				{
					return BottomDoor1.doorTo;
				}
				break;
			case 4:
				if(RightDoor2.doorTo != null)
				{
					return RightDoor2.doorTo;
				}
				break;
			case 5:
				if(LeftDoor2.doorTo != null)
				{
					return LeftDoor2.doorTo;
				}
				break;
			case 6:
				if(TopDoor2.doorTo != null)
				{
					return TopDoor2.doorTo;
				}
				break;
			case 7:
				if(BottomDoor2.doorTo != null)
				{
					return BottomDoor2.doorTo;
				}
				break;
			}
		}
		Debug.LogError("Iterated 100 times, GetRandomRoom");
		return this;
	}
	
	// Update is called once per frame
	void Update () {

		if (doorBottom1Rect == null) 
		{
			doorBottom1Rect = BottomDoor1.door.GetComponent<RectTransform> ();
			doorTop1Rect = TopDoor1.door.GetComponent<RectTransform> ();
			doorLeft1Rect = LeftDoor1.door.GetComponent<RectTransform> ();
			doorRight1Rect = RightDoor1.door.GetComponent<RectTransform> ();
			doorBottom2Rect = BottomDoor2.door.GetComponent<RectTransform> ();
			doorTop2Rect = TopDoor2.door.GetComponent<RectTransform> ();
			doorLeft2Rect = LeftDoor2.door.GetComponent<RectTransform> ();
			doorRight2Rect = RightDoor2.door.GetComponent<RectTransform> ();
		}

		roomText.text = roomLabel;

		GetComponent<RectTransform> ().sizeDelta = new Vector2((float)roomSizeX,(float)roomSizeY);
		roomBorderImage.rectTransform.sizeDelta = new Vector2((float)roomSizeX+16,(float)roomSizeY+16);
		roomImage.rectTransform.sizeDelta = new Vector2((float)roomSizeX,(float)roomSizeY);
		objectSlots.sizeDelta = new Vector2((float)roomSizeX,(float)roomSizeY);
		roomText.rectTransform.sizeDelta = new Vector2(256.0f,128.0f);



		BottomDoor1.door.gameObject.SetActive(BottomDoor1.doorUse);
		TopDoor1.door.gameObject.SetActive(TopDoor1.doorUse);		
		LeftDoor1.door.gameObject.SetActive(LeftDoor1.doorUse);		
		RightDoor1.door.gameObject.SetActive(RightDoor1.doorUse);

		BottomDoor2.door.gameObject.SetActive(BottomDoor2.doorUse);
		TopDoor2.door.gameObject.SetActive(TopDoor2.doorUse);		
		LeftDoor2.door.gameObject.SetActive(LeftDoor2.doorUse);		
		RightDoor2.door.gameObject.SetActive(RightDoor2.doorUse);

		//ObjectSlotTC.gameObject.SetActive(!doorTopUse);
		//ObjectSlotCL.gameObject.SetActive(!doorLeftUse);
		//ObjectSlotCR.gameObject.SetActive(!doorRightUse);
		//ObjectSlotBC.gameObject.SetActive(!doorBottomUse);



		BottomDoor1.door.GetComponent<RectTransform> ().localPosition = 
			new Vector3 (Mathf.Clamp(BottomDoor1.doorModifier,-(roomSizeX / 2)  + (doorBottom1Rect.sizeDelta.x/2), (roomSizeX / 2)- (doorBottom1Rect.sizeDelta.x/2)),
			             -(roomSizeY / 2) - (doorTop1Rect.sizeDelta.y/2), 0);

		TopDoor1.door.GetComponent<RectTransform> ().localPosition = 
			new Vector3 (Mathf.Clamp(TopDoor1.doorModifier,-(roomSizeX / 2) + (doorTop1Rect.sizeDelta.x/2), (roomSizeX / 2) - (doorTop1Rect.sizeDelta.x/2)),
			             (roomSizeY / 2) + (doorBottom1Rect.sizeDelta.y/2), 0);

		LeftDoor1.door.GetComponent<RectTransform> ().localPosition = 
			new Vector3 (-(roomSizeX / 2) - (doorLeft1Rect.sizeDelta.y/2) , Mathf.Clamp(LeftDoor1.doorModifier,-(roomSizeY / 2) + (doorLeft1Rect.sizeDelta.y/2), (roomSizeY / 2) - (doorLeft1Rect.sizeDelta.y/2)),  0);

		RightDoor1.door.GetComponent<RectTransform> ().localPosition = 
			new Vector3 ((roomSizeX / 2) + (doorRight1Rect.sizeDelta.y/2), Mathf.Clamp(RightDoor1.doorModifier,-(roomSizeY / 2) + (doorRight1Rect.sizeDelta.y/2) , (roomSizeY / 2) - (doorRight1Rect.sizeDelta.y/2)) , 0);

		BottomDoor2.door.GetComponent<RectTransform> ().localPosition = 
			new Vector3 (Mathf.Clamp(BottomDoor2.doorModifier,-(roomSizeX / 2)  + (doorBottom2Rect.sizeDelta.x/2), (roomSizeX / 2)- (doorBottom2Rect.sizeDelta.x/2)),
			             -(roomSizeY / 2) - (doorTop1Rect.sizeDelta.y/2), 0);
		
		TopDoor2.door.GetComponent<RectTransform> ().localPosition = 
			new Vector3 (Mathf.Clamp(TopDoor2.doorModifier,-(roomSizeX / 2) + (doorTop2Rect.sizeDelta.x/2), (roomSizeX / 2) - (doorTop2Rect.sizeDelta.x/2)),
			             (roomSizeY / 2) + (doorBottom1Rect.sizeDelta.y/2), 0);
		
		LeftDoor2.door.GetComponent<RectTransform> ().localPosition = 
			new Vector3 (-(roomSizeX / 2) - (doorLeft2Rect.sizeDelta.y/2) , Mathf.Clamp(LeftDoor2.doorModifier,-(roomSizeY / 2) + (doorLeft2Rect.sizeDelta.y/2), (roomSizeY / 2) - (doorLeft1Rect.sizeDelta.y/2)),  0);
		
		RightDoor2.door.GetComponent<RectTransform> ().localPosition = 
			new Vector3 ((roomSizeX / 2) + (doorRight2Rect.sizeDelta.y/2), Mathf.Clamp(RightDoor2.doorModifier,-(roomSizeY / 2) + (doorRight2Rect.sizeDelta.y/2) , (roomSizeY / 2) - (doorRight1Rect.sizeDelta.y/2)) , 0);

	}

	public ObjectSlot[] ObjectSlots
	{
		get {return Objects;}
	}
}
