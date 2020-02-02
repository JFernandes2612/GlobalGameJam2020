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
    [HideInInspector] public int level = 1;
    public Text textLv;
    public string str;
    public Button me;
    public int defaultRepairAmount;
    public int defaultCost;
    public string defaultText;
    public Text text;

    public Sprite lv10;
    public Sprite lv20;
    private void Update()
    {

        text.text = defaultText + myCost + "$";

        if (level == 20)
        {
            toolsInUse[toolnumber].image.sprite = lv20;
            me.interactable = false;
        }
        if (level >= 10 && level < 20)
        {
            toolsInUse[toolnumber].image.sprite = lv10;
        }
        if (toolsInUse[toolnumber].GetComponent<toolButton>().sliderOfDurability.value == 0)
        {
            level = 1;
            textLv.text = str + " " + level.ToString();
            toolsInUse[toolnumber].GetComponent<toolButton>().repairAmount = defaultRepairAmount;
            mainButton.GetComponent<clickController>().currentRepairAmount = defaultRepairAmount;
            myCost = defaultCost;
        }
    }
    public void IGotClicked()
    {
        if (level < 20)
        {
            if (FindObjectOfType<clickController>().currentMoney >= myCost)
            {
                FindObjectOfType<clickController>().currentMoney -= myCost;
                toolsInUse[toolnumber].GetComponent<toolButton>().repairAmount += myRepairAmountIncrement;
                mainButton.GetComponent<clickController>().currentRepairAmount += myRepairAmountIncrement;
                level += 1;
                myCost = myCost + (myCost * 2) / level;
                textLv.text = str + " " + level.ToString();
            }
            else
            {
                Debug.Log("Can't buy!");
            }
        }
    }
}
