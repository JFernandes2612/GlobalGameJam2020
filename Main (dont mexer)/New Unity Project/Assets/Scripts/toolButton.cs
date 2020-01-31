using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toolButton : MonoBehaviour
{
    public void onClick(int repairAmount)
    {
        FindObjectOfType<clickController>().currentRepairAmount = repairAmount;
    }
}
