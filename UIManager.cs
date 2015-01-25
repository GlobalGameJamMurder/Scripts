using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using System;

public class UIManager : MonoBehaviour 
{
    public Animator inventory;
    public Transform inventoryGridTransform;
    public Text evidenceCounterText;
    public Text messengerText;
    public Text timerText;
	public Sprite sprite;

	private bool execute;
	private System.Action onClickAction;

    public List<ItemLookup.Item> m_itemList = new List<ItemLookup.Item>();

    public List<GameObject> m_displayList = new List<GameObject>();

    void Start()
    {
		timerText.enabled = false;
		
        // Fill a list with dummy tiles
        for (int i = 0; i < 10; ++i)
        {
            GameObject tileObject = (GameObject)Instantiate(Resources.Load("BlankItemInfo"));
            tileObject.transform.SetParent(inventoryGridTransform, false);
            m_displayList.Add(tileObject);
        }

        // Debug
        //AddToInventory(item);

        //UpdateTimer();
    }

    // Toggles the slide action for the inventory
    public void ToggleInventory()
    {
        inventory.SetBool("isVisible", !inventory.GetBool("isVisible"));
    }

    // Adds an item to the inventory UI
    public void AddToInventory(ItemLookup.Item item)
    {
        m_itemList.Add(item);

        // If there are not enough objects in pool add another
        if (m_itemList.IndexOf(item) > m_displayList.Count - 1)
        {
            GameObject newTile = (GameObject)Instantiate(Resources.Load("BlankItemInfo"));
            newTile.SetActive(true);
            newTile.transform.SetParent(inventoryGridTransform, false);


            ItemUITile tile = newTile.GetComponent<ItemUITile>();
            tile.text.text = item.Name;
            tile.img.sprite = item.Sprite;

            m_displayList.Add(newTile);
        }
        else
        {
            ItemUITile tile = m_displayList[m_itemList.IndexOf(item)].GetComponent<ItemUITile>();
            tile.text.text = item.Name;
            tile.img.sprite = item.Sprite;

            tile.gameObject.SetActive(true);
        }
    }

    // Removes an item from the UI
    public void RemoveFromInventory(ItemLookup.Item item)
    {
        int index = m_itemList.IndexOf(item);
        m_itemList.Remove(item);
        m_displayList[index].SetActive(false);
    }

    // Change evidence counter
    public void EvidenceCounter(int counter)
    {
        evidenceCounterText.text = counter + "/3";
    }

    // Receives and outputs string to message box
    public void DisplayMessengerText(string text)
    {
        messengerText.transform.parent.gameObject.SetActive(true);
        messengerText.text = text;
    }

	public void DisplayMessengerText(string text, System.Action onFinish)
	{
		messengerText.transform.parent.gameObject.SetActive(true);
		messengerText.text = text;

		onClickAction = onFinish;
		execute = true;
	}

	public void ShowTimer(bool show)
	{
		timerText.enabled = show;
	}

	public void OnDialogExit()
	{
		Time.timeScale = 1;
		if (execute)
		{
			onClickAction();
			execute = false;
		}
	}
    // Updates Timer on upper left quadrant
    public void UpdateTimer(int timeLeftInSeconds)
    {
        int minutes = (int)timeLeftInSeconds / 60;
        int seconds = (int)timeLeftInSeconds % 60;

        timerText.text = string.Format("Timer: {0:00}:{1:00}", minutes, seconds);
    }
}