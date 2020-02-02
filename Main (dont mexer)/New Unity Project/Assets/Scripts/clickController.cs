using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//SCRIPT QUE CONTROLA A DURABILIDADE DE TUDO E O ESTADO DAS COISAS
public class clickController : MonoBehaviour
{

    [HideInInspector] public int previousItemIndex = -1;

    //item de reparação
    public Button itemToFix;
    public AudioSource itemToFixAudioSource;
    public GameObject itemToFixGameObject;

    //index do item que vais ser escolhido aleatoriamente
    [HideInInspector] public int itemIndex;

    //imagem do item (lista) e do item escolhido
    public Sprite[] itemSpriteArrayNotFixed;
    public Sprite[] itemSpriteArrayFixed;
    [HideInInspector] public Sprite currentSprite;

    //valor de reparação atual. valor a adicionar quando se clicar o botão
    [HideInInspector] public float currentRepairAmount;
    [HideInInspector] public float incre = 0f;

    //slider de nível de reparação, nível de reparação máxima (valor quando o objeto está reparado) do objeto a ser reparado, nível de reparação atual do objeto selecionado, array de valores de reparação máximos dos objetos
    public Slider repairedAmmountSlider;
    [HideInInspector] public float maxRepairLevel;
    [HideInInspector] public float currentRepairLevel;
    public int[] maxDurabilityArray;

    //array de valores dos itens e dinheiro atual
    public float[] moneyItemValue;
    public Text moneyText;
    [HideInInspector] public float currentMoney;

    //array com todos os botões das tools, array de sliders de durability das tools, valor atual de durability (do slider da tool selecionada atualmente)
    public Button[] repairTools;
    public Slider[] slidersOfDurabilityTools;
    [HideInInspector] public float currentToolDurability;

    //coisinhas para o passive income:
    public int baseCostIncrement;
    public string baseCostIncrementText;

    public int baseCostDecrement;
    public string baseCostDecrementText;

    [HideInInspector] public float passiveIncomeTime;
    [HideInInspector] public int passiveIncomeAmount;
    public Button incomeTimeButton;
    public Text tickTime;
    public Button incomeAmountIncreaseButton;
    public Text incomePerTick;


    public Image image;

    public Sprite[] hands;

    //end deste snippet
    IEnumerator Timing1()               
    {
        Debug.Log(1);
        image.GetComponent<Animator>().SetTrigger("Trigeer");
        yield return new WaitForSeconds(1.2f);
        itemToFixGameObject.transform.localScale = new Vector2(0f, 0f);
    }
    IEnumerator Timing2()               
    {
        Debug.Log(2);
        //image.GetComponent<Animator>().SetTrigger("Trigeer");
        yield return new WaitForSeconds(1.5f);
        itemToFixGameObject.transform.localScale = new Vector2(0.0495f, 0.0495f);
    }
    IEnumerator PassiveIncomeTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(passiveIncomeTime);
            currentMoney += passiveIncomeAmount;
        }
    }

    public void ReducePassiveIncomeTime()
    {

        if (passiveIncomeTime > 0.5f)               // can level up
        {
            if (currentMoney >= baseCostDecrement)
            {
                currentMoney -= baseCostDecrement;
                passiveIncomeTime -= 0.5f;
                baseCostDecrement *= 2;
                incomeTimeButton.GetComponentInChildren<Text>().text = baseCostDecrementText + (baseCostDecrement).ToString() + "$";
            }
            else
            {
                Debug.Log("Can't buy!");
            }
        }

        if (passiveIncomeTime <= 0.5f)              // is maxed out
        {
            incomeTimeButton.interactable = false;
            incomeTimeButton.GetComponentInChildren<Text>().text = "Max LV";
        }

        tickTime.text = "Tick Time: " + passiveIncomeTime + " s";                //atualiza o texto do tempo de income
    }

    public void IncreasePassiveIncomeAmount()
    {

        if (passiveIncomeAmount < 1024)               // can level up
        {
            if (currentMoney >= baseCostIncrement)
            {
                currentMoney -= baseCostIncrement;
                passiveIncomeAmount *= 2;
                baseCostIncrement *= 2;
                incomeAmountIncreaseButton.GetComponentInChildren<Text>().text = baseCostDecrementText + (baseCostIncrement).ToString() + "$";
            }
            else
            {
                Debug.Log("Can't buy!");
            }
        }

        if (passiveIncomeAmount >= 1024)              // is maxed out
        {
            incomeAmountIncreaseButton.interactable = false;
            incomeAmountIncreaseButton.GetComponentInChildren<Text>().text = "Max LV";
        }

        incomePerTick.text = "Income: " + passiveIncomeAmount + "$/" + passiveIncomeTime + " s";                //atualiza o texto do income per tick
    }

    IEnumerator WaitTime(float timer)               //timer após reparar cada objeto
    {

        itemToFix.interactable = false;
        yield return new WaitForSeconds(timer);
        SelectNewItem();
    }

    //quando o jogo começa
    void Start()
    {
        //inicialmente o dinheiro inicial é zero
        currentMoney = 0;
        moneyText.text = "Money : " + "\n" + currentMoney + "$"; ;
        
        passiveIncomeTime = 10.0f;
        tickTime.text = "Tick Time: "+ passiveIncomeTime + " s";
        passiveIncomeAmount = 1;
        incomePerTick.text = "Income: " + passiveIncomeAmount + "$/10s";
        StartCoroutine(PassiveIncomeTimer());
        itemToFixGameObject.transform.localScale = new Vector2(0f, 0f);
        SelectNewItem();
    }

    private void FixedUpdate()
    {
        moneyText.text = "Money : " + "\n" + currentMoney + "$";
        incomePerTick.text = "Income: " + passiveIncomeAmount + "$/" + passiveIncomeTime + " s";
    }


    //quando é necessario selecionar um novo item para ser reparado.
    public void SelectNewItem()
    {
        itemToFix.interactable = true;
        //escolhe um item aleatório não escolhendo o mesmo que o anterior (para ser reparado)
        itemIndex = Random.Range(0, itemSpriteArrayNotFixed.Length);

        while (itemIndex == previousItemIndex)
        {
            itemIndex = Random.Range(0, itemSpriteArrayNotFixed.Length);
        }
        
        //escolhe a imagem corresponde a esse item que vai ser reparado
        currentSprite = itemSpriteArrayNotFixed[itemIndex];
        itemToFix.image.sprite = currentSprite;

        //atribuição da reparação máxima do objeto
        maxRepairLevel = maxDurabilityArray[itemIndex];
        incre += 1;
        maxRepairLevel = Mathf.Round(maxRepairLevel + 0.03f * incre * maxRepairLevel);
        repairedAmmountSlider.maxValue = maxRepairLevel;

        //valores base de durabilidade para todos os objetos
        repairedAmmountSlider.value = 0f;
        currentRepairLevel = 0f;

        //variavel usada na verificação se o anterio é igual ao atual
        previousItemIndex = itemIndex;
        StartCoroutine(Timing2());
        image.sprite = hands[Random.Range(0, hands.Length)];
    }


    //quando se clica no botão para reparar
    public void WasClicked()
    {
        //quando se clica para reparar percorre todos os tools de reparação e verifica qual deles está ativo
        for (int i=0; i<repairTools.Length; i++)
        {
            if (!repairTools[i].interactable)
            {
                //verifica se a durabilidade atual é maior que 0. Se for verdade aumenta o valor de durabilidade do objeto que esta a ser reparado
                currentToolDurability = slidersOfDurabilityTools[i].value;
                if (currentToolDurability > 0)
                {
                    itemToFixAudioSource.Play();
                    currentRepairLevel = currentRepairLevel + currentRepairAmount;
                    repairedAmmountSlider.value = currentRepairLevel;
                }
                else
                {
                    break;
                }

                //no caso de reparar o objeto, diminui a durabilidade da ferramenta(tool) em 1
                currentToolDurability -= 1;
                slidersOfDurabilityTools[i].value = currentToolDurability;
                break;
            }

        }

        //se o objeto é reparado, adiciona ao dinheiro e seleciona um novo item
        if (currentRepairLevel >= maxRepairLevel)
        {
            currentMoney = Mathf.Round(currentMoney + (moneyItemValue[itemIndex] + incre * 0.02f * moneyItemValue[itemIndex]));
            moneyText.text = "Money : " + currentMoney;
            itemToFix.image.sprite = itemSpriteArrayFixed[itemIndex];
            StartCoroutine(Timing1());
            StartCoroutine(WaitTime(1.2f));
        }

    }

}
