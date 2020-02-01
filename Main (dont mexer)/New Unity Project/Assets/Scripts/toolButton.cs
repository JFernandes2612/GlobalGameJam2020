using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//SCRIPT QUE CONTROLA O BOTÃO DAS TOOLS E ATRIBUI A DURABILIDADE DADA AO OBJETO NA clickController.cs

public class toolButton : MonoBehaviour
{
    //reparação do objeto
    public int repairAmount;

    //durabilidade do tool de reparação
    public int maxToolDurability;

    //numero do tool
    public int toolNumber;

    //slider coorespondete a este tool
    public Slider sliderOfDurability;

    //lista de tools de reparação
    public Button[] repairTools;

    public Button[] Upgrades;

    void Start()
    {
        //atribui o valor de durabilidade inicial do tool definido publicamente no inspector
        sliderOfDurability.maxValue = maxToolDurability;
        sliderOfDurability.value = maxToolDurability;
        for (int i = 0; i < repairTools.Length; i++)
        {
           Upgrades[i].interactable = true;
        }
    }

    public void Start2()
    {
        //atribui o valor de durabilidade inicial do tool definido publicamente no inspector
        sliderOfDurability.maxValue = maxToolDurability;
        sliderOfDurability.value = maxToolDurability;
    }

    public void onClick()
    {
        //altera a variavel na outra script (quantidade de reparação(nivel))
        FindObjectOfType<clickController>().currentRepairAmount = repairAmount;

        //desativa o botão clicado mas ativa os outros
        //Upgrades[toolNumber].interactable = true;
        repairTools[toolNumber].interactable = false;
        for (int i=0; i<repairTools.Length; i++)
        {
            if (i != toolNumber)
            {
                //Upgrades[i].interactable = false;
                repairTools[i].interactable = true;
            }
        }
    }
}
