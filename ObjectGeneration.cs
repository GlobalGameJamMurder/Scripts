using UnityEngine;
using System.Collections;

public class ObjectGeneration : MonoBehaviour {

	public enum ROOM
	{
		BATHROOM,
		CONSERVATORY,
		DININGROOM,
		ENTRANCEHALL,
		ENSUITE,
		GARDEN,
		GARAGE, 
		GUESTROOM,
		KITCHEN,
		LIVINGROOM,
		LIBRARY,
		MASTERBEDROOM,
		PANTRY,
		STUDY
	}

	public GameObject Safe_PF;
	public GameObject Toilet_PF;
	public GameObject Bath_PF;
	public GameObject Car_PF;
	public GameObject Bookshelf_PF;
	public GameObject Clock_PF;
	public GameObject Plant_PF;
	public GameObject Passage_PF;
	public GameObject Sofa_PF;
	public GameObject Bed_PF;
	public GameObject Drawer_PF;
	public GameObject Trash_PF;
	public GameObject Fireplace_PF;
	public GameObject Fridge_PF;

	public int m_SafeCount;
	public int m_ToiletCount;
	public int m_BathCount;
	public int m_CarCount;
	public int m_BookshelfCount;
	public int m_ClockCount;
	public int m_PlantCount;
	public int m_SecretPassageWayCount;
	public int m_SofaCount;
	public int m_BedCount;
	public int m_DrawerCount;
	public int m_TrashCount;
	public int m_FireplaceCount;
	public int m_FridgeCount;

	public static ObjectGeneration m_Object;

	void Start()
	{
		m_Object = this;
	}
	public GameObject GetObject(ROOM room)
	{
		switch (room)
		{
		case ROOM.BATHROOM:
			return BathroomObject();
		case ROOM.CONSERVATORY:
			return ConservatoryObject();
		case ROOM.DININGROOM:
			return BathroomObject();
		case ROOM.ENSUITE:
			return BathroomObject();
		case ROOM.ENTRANCEHALL:
			return EntranceObject();
		case ROOM.GARAGE:
			return GarageObject();
		case ROOM.GARDEN:
			return GardenObject();
		case ROOM.GUESTROOM:
			return GuestroomObject();
		case ROOM.KITCHEN:
			return KitchenObject();
		case ROOM.LIBRARY:
			return LibraryObject();
		case ROOM.LIVINGROOM:
			return LivingRoomObject();
		case ROOM.MASTERBEDROOM:
			return GuestroomObject();
		case ROOM.PANTRY:
			return KitchenObject();
		case ROOM.STUDY:
			return LibraryObject();
		}
		return null;
	}

	GameObject BathroomObject()
	{
		int toilet = 60;
		int bath = 100;

		int r = Random.Range (0, 101);

		if(m_ToiletCount > 0)
		if(r < toilet)
		{
			m_ToiletCount--;
			return (GameObject)GameObject.Instantiate(Toilet_PF);
			
		}

		if(m_BathCount > 0)
		{
			m_BathCount--;
			return (GameObject)GameObject.Instantiate(Bath_PF);
		}
		return null;
	}
	GameObject ConservatoryObject()
	{
		int bookshelf = 30;
		int sofa = 65;
		int Trash = 100; 

		int r = Random.Range (0, 101);
		
		if(m_BookshelfCount > 0)
			if(r < bookshelf)
		{
			m_BookshelfCount--;
			return (GameObject)GameObject.Instantiate(Bookshelf_PF);
			
		}
		if(m_SofaCount > 0)
			if(r < sofa)
		{
			m_SofaCount--;
			return (GameObject)GameObject.Instantiate(Sofa_PF);
			
		}
		if(m_TrashCount > 0)
		{
			m_TrashCount--;
			return (GameObject)GameObject.Instantiate(Trash_PF);
			
		}
		return null;
	}
	
	GameObject EntranceObject()
	{
		int clock = 30;
		int trash = 70;

		int r = Random.Range (0, 71);

		if(m_ClockCount > 0)
		if(r < clock)
		{
			m_ClockCount--;
			return (GameObject)GameObject.Instantiate(Clock_PF);
			
		}
		
		if(m_TrashCount > 0)
		{
			m_TrashCount--;
			return (GameObject)GameObject.Instantiate(Trash_PF);
			
		}
		return null;
	}
	GameObject GarageObject()
	{
		int car = 90;
		int safe = 10;

		int r = Random.Range (0, 101);

		if(m_CarCount > 0)
		if(r < car)
		{
			m_CarCount--;
			return (GameObject)GameObject.Instantiate(Car_PF);
			
		}

		if(m_SafeCount > 0)
		{
			m_SafeCount--;
			return (GameObject)GameObject.Instantiate(Safe_PF);
			
		}
		return null;
	}
	GameObject GardenObject()
	{
		if(m_PlantCount > 0)
		{
			m_PlantCount--;
			return (GameObject)GameObject.Instantiate(Plant_PF);
			
		}
		return null;
	}
	GameObject GuestroomObject()
	{
		int fireplace = 20;
		int bed = 50;
		int trash = 65;
		int safe = 80;
		int clock = 100;

		int r = Random.Range (0, 101);
		
		if (m_FireplaceCount > 0)
				if (r < fireplace) {
			m_FireplaceCount--;
			return (GameObject)GameObject.Instantiate(Fireplace_PF);
			
				}
		if (m_BedCount > 0) 
			if(r < bed)
			{
			m_BedCount--;
			return (GameObject)GameObject.Instantiate(Bed_PF);
			
				}
		if(m_TrashCount > 0)
			if(r < trash)
		{
			m_TrashCount--;
			return (GameObject)GameObject.Instantiate(Trash_PF);
		}
		if(m_SafeCount > 0)
			if(r < safe)
		{
			m_SafeCount--;
			return (GameObject)GameObject.Instantiate(Safe_PF);
		}
		if(m_ClockCount > 0)
		{
			m_ClockCount--;
			return (GameObject)GameObject.Instantiate(Clock_PF);
		}

		return null;
		
	}
	GameObject KitchenObject()
	{
		int drawers = 50;
		int fridge = 100;

		int r = Random.Range (0, 101);
		
		if(m_DrawerCount > 0)
		if(r < drawers)
		{
			m_DrawerCount--;
			return (GameObject)GameObject.Instantiate(Drawer_PF);
		}

		if(m_FridgeCount > 0)
		{
			m_FridgeCount--;
			return (GameObject)GameObject.Instantiate(Fridge_PF);
		}
		return null;
	}
	GameObject LibraryObject()
	{
		int fireplace = 30;
		int bookshelf = 100;

		int r = Random.Range (0, 101);

		if (m_FireplaceCount > 0)
		if (r < fireplace) {
			m_FireplaceCount--;
			return (GameObject)GameObject.Instantiate(Fireplace_PF);
		}
		if(m_BookshelfCount > 0)
			if(r < bookshelf)
		{
			m_BookshelfCount--;
			return (GameObject)GameObject.Instantiate(Bookshelf_PF);
		}
		return null;
	}
	GameObject LivingRoomObject()
	{
		int fireplace = 30;
		int sofa = 70;
		int bookshelf = 100;
		
		int r = Random.Range (0, 101);
		
		if (m_FireplaceCount > 0)
		if (r < fireplace) {
			m_FireplaceCount--;
			return (GameObject)GameObject.Instantiate(Fireplace_PF);
		}
		if(m_SofaCount > 0)
			if(r < sofa)
		{
			m_SofaCount--;
			return (GameObject)GameObject.Instantiate(Sofa_PF);
		}
		if(m_BookshelfCount > 0)
		{
			m_BookshelfCount--;
			return (GameObject)GameObject.Instantiate(Bookshelf_PF);
		}
		return null;
	}

}
