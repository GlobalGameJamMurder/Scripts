using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
    
    public Text evidenceCounterText;
    public Text messengerText;
    public Text timerText;




    void Start()
    {



        UpdateTimer(124);
    }

    public void ToggleInventory()
    {
        
    }

    public void AddToInventory(ItemLookup.Item item)
    {

    }

    public void RemoveFromInventory(ItemLookup.Item item)
    {

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

    public void UpdateTimer(int timeLeftInSeconds)
    {
        int minutes = (int)timeLeftInSeconds / 60;
        int seconds = (int)timeLeftInSeconds % 60;

        timerText.text = string.Format("Timer: {0:00}:{1:00}", minutes, seconds);
    }
}