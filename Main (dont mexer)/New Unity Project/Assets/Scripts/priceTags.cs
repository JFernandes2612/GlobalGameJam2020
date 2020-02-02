using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class priceTags : MonoBehaviour
{
    public int price;
    public GameObject me;
    public GameObject myUpgradeList;
    public GameObject selectionTool;

    // Update is called once per frame
    public void click()
    {
        if (FindObjectOfType<clickController>().currentMoney >= price)
        {
            FindObjectOfType<clickController>().currentMoney -= price;
            myUpgradeList.SetActive(true);
            selectionTool.SetActive(true);
            me.SetActive(false);
        }
        else
        {
            Debug.Log("Can't buy");
        }
        
    }
}
