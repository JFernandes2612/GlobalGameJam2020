using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickController : MonoBehaviour
{


    [HideInInspector] public int previousItemIndex = -1;
    public Button itemToFix;

    [HideInInspector] public int itemIndex;

    public Sprite[] itemSpriteArray;
    [HideInInspector] public Sprite currentSprite;

    [HideInInspector] public int currentRepairAmount;

    public Slider durabilitySlider;
    [HideInInspector] public int maxDurability;
    [HideInInspector] public int currentDurability;

    public int[] maxDurabilityArray;

    public int[] moneyItemValue;

    public Text moneyText;
    [HideInInspector] public int currentMoney;

    void Start()
    {
        currentMoney = 0;
        moneyText.text = "Money : " + currentMoney;
        SelectNewItem();
    }

    public void SelectNewItem()
    {
        
        itemIndex = Random.Range(0, itemSpriteArray.Length);

        while (itemIndex == previousItemIndex)
        {
            itemIndex = Random.Range(0, itemSpriteArray.Length);
        }

        currentSprite = itemSpriteArray[itemIndex];
        maxDurability = maxDurabilityArray[itemIndex];

        itemToFix.image.sprite = currentSprite;
        durabilitySlider.maxValue = maxDurability;

        durabilitySlider.value = 0;
        currentDurability = 0;

        previousItemIndex = itemIndex;
       
    }



    public void WasClicked()
    {
        currentDurability = currentDurability + currentRepairAmount;
        durabilitySlider.value = currentDurability;
        
        if (currentDurability >= maxDurability)
        {
            currentMoney = currentMoney + moneyItemValue[itemIndex];
            moneyText.text = "Money : " + currentMoney;
            SelectNewItem();
        }
    }

}
