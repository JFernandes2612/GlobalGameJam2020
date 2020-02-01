using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairTool : MonoBehaviour
{

    public int myCost;
    public int myDurabilityNow;
    public Button[] toolsInUse;
    public int toolnumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ClickToRepair()
    {
        if (FindObjectOfType<ClickController>().currentMoney >= myCost)
        {
            FindObjectOfType<ClickController>().currentMoney -= myCost;
            toolsInUse[toolnumber].GetComponent<ToolButton>().maxToolDurability = myDurabilityNow;
            toolsInUse[toolnumber].GetComponent<ToolButton>().Start2();
        }
        else
        {
            Debug.Log("Can't buy!");
        }
    }
}
