using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickController : MonoBehaviour
{

    public Button itemToFix;

    [HideInInspector] public int itemIndex;

    public Sprite[] itemSpriteArray;
    [HideInInspector] public Sprite currentSprite;

    public int[] toolRepairAmount;
    [HideInInspector] public int currentRepairAmount;

    public Slider durabilitySlider;
    [HideInInspector] public int maxDurability;
    [HideInInspector] public int currentDurability;

    public int[] maxDurabilityArray;

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

        currentSprite = itemSpriteArray[itemIndex];
        maxDurability = maxDurabilityArray[itemIndex];

        currentRepairAmount = 1;


        itemToFix.image.sprite = currentSprite;
        durabilitySlider.maxValue = maxDurability;
        durabilitySlider.value = durabilitySlider.maxValue;
        currentDurability = maxDurability;
    }



    public void WasClicked()
    {
        currentDurability = currentDurability - currentRepairAmount;
        durabilitySlider.value = currentDurability;
    }
    
}
