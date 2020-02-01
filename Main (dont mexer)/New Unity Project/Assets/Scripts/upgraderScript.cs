using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class upgraderScript : MonoBehaviour
{
    public int myDurabilityNow;
    public int myCost;
    public int myRepairAmount;
    public Button toolInUse;

    public void IGotClicked()
    {
        if (FindObjectOfType<clickController>().currentMoney >= myCost)
        {
            FindObjectOfType<clickController>().currentMoney -= myCost;
            toolInUse.GetComponent<toolButton>().maxToolDurability = myDurabilityNow;
            toolInUse.GetComponent<toolButton>().repairAmount = myRepairAmount;
            toolInUse.GetComponent<toolButton>().Start2();
        }
        else
        {
            Debug.Log("Can't buy!");
            /*
            FindObjectOfType<clickController>().currentMoney -= myCost;
            toolInUse.GetComponent<toolButton>().maxToolDurability = myDurabilityNow;
            toolInUse.GetComponent<toolButton>().repairAmount = myRepairAmount;
            toolInUse.GetComponent<toolButton>().Start2();
            */
        }
    }
}
