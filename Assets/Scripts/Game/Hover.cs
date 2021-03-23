//chris campbell - march 18, 2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI text;
    public PauseMenuBehaviour pauseMenu;


//show text on hover
    public void OnPointerEnter(PointerEventData eventData){
        if(pauseMenu.infoIsActive){
            text.gameObject.SetActive(true);
        }
    }

    //hide text
    public void OnPointerExit(PointerEventData eventData){
        text.gameObject.SetActive(false);  
    }
}
    