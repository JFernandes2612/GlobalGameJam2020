using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class repairTool : MonoBehaviour
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
        if (FindObjectOfType<clickController>().currentMoney >= myCost)
        {
            FindObjectOfType<clickController>().currentMoney -= myCost;
            toolsInUse[toolnumber].GetComponent<toolButton>().maxToolDurability = myDurabilityNow;
            toolsInUse[toolnumber].GetComponent<toolButton>().Start2();
        }
        else
        {
            Debug.Log("Can't buy!");
        }
    }
}
