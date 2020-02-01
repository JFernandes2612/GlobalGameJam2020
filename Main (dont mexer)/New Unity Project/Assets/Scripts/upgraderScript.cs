using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class upgraderScript : MonoBehaviour
{
    public int myCost;
    public int myRepairAmountIncrement;
    public Button[] toolsInUse;
    public int toolnumber;
    public Button mainButton;

    public void IGotClicked()
    {
        if (FindObjectOfType<clickController>().currentMoney >= myCost)
        {
            FindObjectOfType<clickController>().currentMoney -= myCost;
            toolsInUse[toolnumber].GetComponent<toolButton>().repairAmount += myRepairAmountIncrement;
            mainButton.GetComponent<clickController>().currentRepairAmount += myRepairAmountIncrement;
        }
        else
        {
            Debug.Log("Can't buy!");
        }
    }
}
