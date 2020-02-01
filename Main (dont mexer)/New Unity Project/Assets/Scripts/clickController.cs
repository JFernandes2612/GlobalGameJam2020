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

    //index do item que vais ser escolhido aleatoriamente
    [HideInInspector] public int itemIndex;

    //imagem do item (lista) e escolha/aplicação
    public Sprite[] itemSpriteArray;
    [HideInInspector] public Sprite currentSprite;

    //reparação atual que será feira ao clicar o botão
    [HideInInspector] public int currentRepairAmount;

    //slider de durabilidade e valor de durabilidade máxima
    public Slider durabilitySlider;
    [HideInInspector] public int maxDurability;
    [HideInInspector] public int currentDurability;
    public int[] maxDurabilityArray;

    //valor do item e dinheiro atual
    public int[] moneyItemValue;
    public Text moneyText;
    [HideInInspector] public int currentMoney;

    //tools de reparação (lista) e durabilidade de estes tools
    public Button[] repairTools;
    public Slider[] slidersOfDurabilityTools;
    [HideInInspector] public float currentToolDurability;

    //code

    //quando o jogo começa
    void Start()
    {
        //inicialmente o dinheiro inicial é zero
        currentMoney = 0;
        moneyText.text = "Money : " + currentMoney;
        SelectNewItem();
    }

    private void FixedUpdate()
    {
        moneyText.text = "Money : " + currentMoney;
    }


    //quando é necessario selecionar um novo item para ser reparado.
    public void SelectNewItem()
    {
        //escolhe um item aleatório não escolhendo o mesmo que o anterior (para ser reparado)
        itemIndex = Random.Range(0, itemSpriteArray.Length);

        while (itemIndex == previousItemIndex)
        {
            itemIndex = Random.Range(0, itemSpriteArray.Length);
        }
        
        //escolhe a imagem corresponde a esse item que vai ser reparado
        currentSprite = itemSpriteArray[itemIndex];
        itemToFix.image.sprite = currentSprite;

        //atribuição da durabilidade máxima do objeto
        maxDurability = maxDurabilityArray[itemIndex];
        durabilitySlider.maxValue = maxDurability;

        //valores base de durabilidade para todos os objetos
        durabilitySlider.value = 0;
        currentDurability = 0;

        //variavel usada na verificação se o anterio é igual ao atual
        previousItemIndex = itemIndex;
       
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
                    currentDurability = currentDurability + currentRepairAmount;
                    durabilitySlider.value = currentDurability;
                }
                else
                {
                    break;
                }

                //no caso de repara o objeto diminui a durabilidade da ferramenta(tool) em 1
                currentToolDurability -= 1;
                slidersOfDurabilityTools[i].value = currentToolDurability;
                break;
            }

        }

        //se o objeto é reparado, adiciona ao dinheiro e seleciona um novo item
        if (currentDurability >= maxDurability)
        {
            currentMoney = currentMoney + moneyItemValue[itemIndex];
            moneyText.text = "Money : " + currentMoney;
            SelectNewItem();
        }

    }

}
