using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgraderScript : MonoBehaviour
{
    public int myCost;
    public int myRepairAmountIncrement;
    public Button[] toolsInUse;
    public int toolnumber;
    public Button mainButton;

    public void IGotClicked()
    {
        if (FindObjectOfType<ClickController>().currentMoney >= myCost)
        {
            FindObjectOfType<ClickController>().currentMoney -= myCost;
            toolsInUse[toolnumber].GetComponent<ToolButton>().repairAmount += myRepairAmountIncrement;
            mainButton.GetComponent<ClickController>().currentRepairAmount += myRepairAmountIncrement;
        }
        else
        {
            Debug.Log("Can't buy!");
        }
    }
}
