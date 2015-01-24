using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class Room : MonoBehaviour 
{
	public Image roomImage;
	public Image roomBorderImage;

	public Button doorBottom;
	public int doorModifierBottom;
	public bool doorBottomUse;
	public Room doorBottomTo;
	public Button doorTop;
	public int doorModifierTop;
	public bool doorTopUse;
	public Room doorTopTo;
	public Button doorLeft;
	public int doorModifierLeft;
	public bool doorLeftUse;
	public Room doorLeftTo;
	public Button doorRight;
	public int doorModifierRight;
	public bool doorRightUse;
	public Room doorRightTo;

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
	
	public Text roomText; 

	public RectTransform roomTextRect; 

	private RectTransform doorBottomRect;
	private RectTransform doorTopRect;
	private RectTransform doorLeftRect;
	private RectTransform doorRightRect;

	public Sprite activeImage;
	public Sprite inactiveImage;

	public void EnableDoors()
	{
		doorBottom.enabled = true;
		doorTop.enabled = true;
		doorLeft.enabled = true;
		doorRight.enabled = true;
	}

	public void DisableDoors()
	{
		doorBottom.enabled = false;
		doorTop.enabled = false;
		doorLeft.enabled = false;
		doorRight.enabled = false;
	}

	public void DoorLeft()
	{
		if (doorLeftTo != null) {
			roomImage.overrideSprite = inactiveImage;
			doorLeftTo.roomImage.overrideSprite = activeImage;
			RoomManager.Instance.CurrentRoom = doorLeftTo;
			doorLeftTo.EnableDoors();
			DisableDoors();
				}
	}

	public void DoorRight()
	{
		if (doorRightTo != null) {
			roomImage.overrideSprite = inactiveImage;
			doorRightTo.roomImage.overrideSprite = activeImage;
			RoomManager.Instance.CurrentRoom = doorRightTo;
			doorRightTo.EnableDoors();
			DisableDoors();
				}
		
	}

	public void DoorTop()
	{
		if (doorTopTo != null) {
			roomImage.overrideSprite = inactiveImage;
			doorTopTo.roomImage.overrideSprite = activeImage;
			RoomManager.Instance.CurrentRoom = doorTopTo;
			doorTopTo.EnableDoors();
			DisableDoors();
				}
	}
	
	public void DoorBottom()
	{
		if (doorBottomTo != null) {
			roomImage.overrideSprite = inactiveImage;
			doorBottomTo.roomImage.overrideSprite = activeImage;
			RoomManager.Instance.CurrentRoom = doorBottomTo;
			doorBottomTo.EnableDoors();
			DisableDoors();
				}
	}

	// Use this for initialization
	void Start () {

		if (RoomManager.Instance.CurrentRoom == this) {
						EnableDoors ();
            roomImage.overrideSprite = activeImage;
				} else {
			DisableDoors ();
				}

		doorBottomRect = doorBottom.GetComponent<RectTransform> ();
		doorTopRect = doorTop.GetComponent<RectTransform> ();
		doorLeftRect = doorLeft.GetComponent<RectTransform> ();
		doorRightRect = doorRight.GetComponent<RectTransform> ();

		roomTextRect = roomText.GetComponent<RectTransform> ();
	}

	public Room GetRandomRoom()
	{
		int count = 0;
		while (count < 100)
		{
			int rand = Random.Range (0,4);
			switch (rand)
			{
			case 0:
				if(doorRightTo != null)
				{
					return doorRightTo;
				}
				break;
			case 1:
				if(doorLeftTo != null)
				{
					return doorLeftTo;
				}
				break;
			case 2:
				if(doorTopTo != null)
				{
					return doorTopTo;
				}
				break;
			case 3:
				if(doorBottomTo != null)
				{
					return doorBottomTo;
				}
				break;
			}
		}
		Debug.LogError("Iterated 100 times, GetRandomRoom");
		return this;
	}
	
	// Update is called once per frame
	void Update () {

		if (doorBottomRect == null) 
		{
			doorBottomRect = doorBottom.GetComponent<RectTransform> ();
			doorTopRect = doorTop.GetComponent<RectTransform> ();
			doorLeftRect = doorLeft.GetComponent<RectTransform> ();
			doorRightRect = doorRight.GetComponent<RectTransform> ();
		}

		roomText.text = roomLabel;

		GetComponent<RectTransform> ().sizeDelta = new Vector2((float)roomSizeX,(float)roomSizeY);
		roomBorderImage.rectTransform.sizeDelta = new Vector2((float)roomSizeX+16,(float)roomSizeY+16);
		roomImage.rectTransform.sizeDelta = new Vector2((float)roomSizeX,(float)roomSizeY);
		objectSlots.sizeDelta = new Vector2((float)roomSizeX,(float)roomSizeY);
		roomText.rectTransform.sizeDelta = new Vector2((float)roomSizeX,(float)roomSizeY);

		doorBottom.gameObject.SetActive(doorBottomUse);
		doorTop.gameObject.SetActive(doorTopUse);		
		doorLeft.gameObject.SetActive(doorLeftUse);		
		doorRight.gameObject.SetActive(doorRightUse);

		ObjectSlotTC.gameObject.SetActive(!doorTopUse);
		ObjectSlotCL.gameObject.SetActive(!doorLeftUse);
		ObjectSlotCR.gameObject.SetActive(!doorRightUse);
		ObjectSlotBC.gameObject.SetActive(!doorBottomUse);

		doorBottom.GetComponent<RectTransform> ().localPosition = 
			new Vector3 (Mathf.Clamp(doorModifierBottom,-(roomSizeX / 2)  + (doorBottomRect.sizeDelta.x/2), (roomSizeX / 2)- (doorBottomRect.sizeDelta.x/2)),
			             -(roomSizeY / 2) - (doorTopRect.sizeDelta.y/2), 0);

		doorTop.GetComponent<RectTransform> ().localPosition = 
			new Vector3 (Mathf.Clamp(doorModifierTop,-(roomSizeX / 2) + (doorTopRect.sizeDelta.x/2), (roomSizeX / 2) - (doorTopRect.sizeDelta.x/2)),
			             (roomSizeY / 2) + (doorBottomRect.sizeDelta.y/2), 0);

		doorLeft.GetComponent<RectTransform> ().localPosition = 
			new Vector3 (-(roomSizeX / 2) - (doorLeftRect.sizeDelta.y/2) , Mathf.Clamp(doorModifierLeft,-(roomSizeY / 2) + (doorLeftRect.sizeDelta.y/2), (roomSizeY / 2) - (doorLeftRect.sizeDelta.y/2)),  0);

		doorRight.GetComponent<RectTransform> ().localPosition = 
			new Vector3 ((roomSizeX / 2) + (doorRightRect.sizeDelta.y/2), Mathf.Clamp(doorModifierRight,-(roomSizeY / 2) + (doorLeftRect.sizeDelta.y/2) , (roomSizeY / 2) - (doorLeftRect.sizeDelta.y/2)) , 0);
	}
}
