using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class Door 
{
	public Button door;
	public int doorModifier;
	public bool doorUse;
	public Room doorTo;
 
}

[ExecuteInEditMode]
public class Room : MonoBehaviour 
{
	public Image roomImage;
	public Image roomBorderImage;

	[SerializeField] private Door BottomDoor1;
	[SerializeField] private Door BottomDoor2;
	[SerializeField] private Door TopDoor1;
	[SerializeField] private Door TopDoor2;
	[SerializeField] private Door LeftDoor1;
	[SerializeField] private Door LeftDoor2;
	[SerializeField] private Door RightDoor1;
	[SerializeField] private Door RightDoor2;

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

	public void EnableDoors()
	{
		BottomDoor1.door.enabled = true;
		BottomDoor2.door.enabled = true;
		TopDoor1.door.enabled = true;
		TopDoor2.door.enabled = true;
		LeftDoor1.door.enabled = true;
		LeftDoor2.door.enabled = true;
		RightDoor1.door.enabled = true;
		RightDoor2.door.enabled = true;
	}

	public void DisableDoors()
	{
		BottomDoor1.door.enabled = false;
		BottomDoor2.door.enabled = false;
		TopDoor1.door.enabled = false;
		TopDoor2.door.enabled = false;
		LeftDoor1.door.enabled = false;
		LeftDoor2.door.enabled = false;
		RightDoor1.door.enabled = false;
		RightDoor2.door.enabled = false;
	}

	public void DoorLeft1()
	{
		if (LeftDoor1.doorTo != null) {
			roomImage.overrideSprite = inactiveImage;
			LeftDoor1.doorTo.roomImage.overrideSprite = activeImage;
			Player.Instance.UseAction(LeftDoor1.doorTo);
			DisableDoors();
		}
	}

	public void DoorLeft2()
	{
		if (LeftDoor2.doorTo != null) {
			roomImage.overrideSprite = inactiveImage;
			LeftDoor2.doorTo.roomImage.overrideSprite = activeImage;
			Player.Instance.UseAction(LeftDoor2.doorTo);
			DisableDoors();
		}
	

	}

	public void DoorRight1()
	{
		if (RightDoor1.doorTo != null) {
			roomImage.overrideSprite = inactiveImage;
			RightDoor1.doorTo.roomImage.overrideSprite = activeImage;
			Player.Instance.UseAction(RightDoor1.doorTo );
			DisableDoors();
		}
	}

	public void DoorRight2()
	{
		if (RightDoor2.doorTo != null) {
			roomImage.overrideSprite = inactiveImage;
			RightDoor2.doorTo.roomImage.overrideSprite = activeImage;
			Player.Instance.UseAction(RightDoor2.doorTo);
			DisableDoors();
		}
	}
	

	public void DoorTop1()
	{
		if (TopDoor1.doorTo != null) {
			roomImage.overrideSprite = inactiveImage;
			TopDoor1.doorTo.roomImage.overrideSprite = activeImage;
			Player.Instance.UseAction(TopDoor1.doorTo );
			DisableDoors();
		}
	}

	public void DoorTop2()
	{
		if (TopDoor2.doorTo != null) {
			roomImage.overrideSprite = inactiveImage;
			TopDoor2.doorTo.roomImage.overrideSprite = activeImage;
			Player.Instance.UseAction(TopDoor2.doorTo);
			DisableDoors();
		}
	}

	public void DoorBottom2()
	{
		if (BottomDoor2.doorTo != null) {
			roomImage.overrideSprite = inactiveImage;
			BottomDoor2.doorTo.roomImage.overrideSprite = activeImage;
			Player.Instance.UseAction(BottomDoor2.doorTo );
			DisableDoors();
		}
	}

	public void DoorBottom1()
	{
		if (BottomDoor1.doorTo != null) {
			roomImage.overrideSprite = inactiveImage;
			BottomDoor1.doorTo.roomImage.overrideSprite = activeImage;
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
