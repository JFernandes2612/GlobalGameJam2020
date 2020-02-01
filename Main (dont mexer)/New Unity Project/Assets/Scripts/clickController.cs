using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//SCRIPT QUE CONTROLA A DURABILIDADE DE TUDO E O ESTADO DAS COISAS
public class clickController : MonoBehaviour
{
    public float timerAnimationChange;

    [HideInInspector] public int previousItemIndex = -1;

    //item de reparação
    public Button itemToFix;
    public AudioSource itemToFixAudioSource;

    //index do item que vais ser escolhido aleatoriamente
    [HideInInspector] public int itemIndex;

    //imagem do item (lista) e do item escolhido
    public Sprite[] itemSpriteArrayNotFixed;
    public Sprite[] itemSpriteArrayFixed;
    [HideInInspector] public Sprite currentSprite;

    //valor de reparação atual. valor a adicionar quando se clicar o botão
    [HideInInspector] public int currentRepairAmount;

    //slider de nível de reparação, nível de reparação máxima (valor quando o objeto está reparado) do objeto a ser reparado, nível de reparação atual do objeto selecionado, array de valores de reparação máximos dos objetos
    public Slider repairedAmmountSlider;
    [HideInInspector] public int maxRepairLevel;
    [HideInInspector] public int currentRepairLevel;
    public int[] maxDurabilityArray;

    //array de valores dos itens e dinheiro atual
    public int[] moneyItemValue;
    public Text moneyText;
    [HideInInspector] public int currentMoney;

    //array com todos os botões das tools, array de sliders de durability das tools, valor atual de durability (do slider da tool selecionada atualmente)
    public Button[] repairTools;
    public Slider[] slidersOfDurabilityTools;
    [HideInInspector] public float currentToolDurability;

    //code

    IEnumerator waitTime(float timer)
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
        repairedAmmountSlider.maxValue = maxRepairLevel;

        //valores base de durabilidade para todos os objetos
        repairedAmmountSlider.value = 0;
        currentRepairLevel = 0;

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
            currentMoney = currentMoney + moneyItemValue[itemIndex];
            moneyText.text = "Money : " + currentMoney;
            itemToFix.image.sprite = itemSpriteArrayFixed[itemIndex];
            StartCoroutine(waitTime(timerAnimationChange));
        }

    }

}
