using UnityEngine;
using System.Collections;

public class ItemInformation : MonoBehaviour 
{
    public enum ItemType { Defence, SafeCode, Evidence, CarKeys, Fuel, BathroomKey, BedroomKey, DoorKey, GarageKey, HouseKey, LibraryKey, StudyKey };

    public ItemType itemType;

    public ItemLookup.Item item;

    public bool beenUsed { get; set; }

    public void Start()
    {
        beenUsed = false;
    }

    public void FixedUpdate()
    {
        if (beenUsed && item.m_OneUse)
            Destroy(this);
    }
}
