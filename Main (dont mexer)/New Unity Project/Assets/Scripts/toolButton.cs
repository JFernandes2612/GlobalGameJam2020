using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toolButton : MonoBehaviour
{
    public int repairAmount;
    public int maxToolDurability;
    public int toolNumber;
    public Slider sliderOfDurability;
    public Button[] repairTools;
    [HideInInspector] public int durabilityNow;
    void Start()
    {
        sliderOfDurability.maxValue = maxToolDurability;
        sliderOfDurability.value = maxToolDurability;
    }
    public void onClick()
    {
        FindObjectOfType<clickController>().currentRepairAmount = repairAmount;
        repairTools[toolNumber].interactable = false;
        for (int i=0; i<repairTools.Length; i++)
        {
            if (i != toolNumber)
            {
                repairTools[i].interactable = true;
            }
        }
    }
}
