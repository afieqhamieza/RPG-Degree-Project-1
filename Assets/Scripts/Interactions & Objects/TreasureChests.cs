using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChests : Dialog
{
    //  private SpriteRenderer spriteRenderer;
    //  private Sprite openSprite, closedSprite;
    public Item contents;
    private bool isOpen; 
    public SignalSender raiseItem;
    private Animator anim;
    public Inventory playerInventory;
    public GameObject chestOpened;
    public GameObject chestClosed;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && playerInRange){
            if(!isOpen){
                OpenChest();
            }else{
                OpenedChest();
            }
        }
    }

    // open the chest
    public void OpenChest(){
        // dialogs
        // add contents to inventory
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        // raise signal
        // set chest to open
        isOpen = true;
        chestClosed.SetActive(false);
        chestOpened.SetActive(true);
        Debug.Log("heree");
        // raise context clue
    }

    // is the chest already opened?
    public void OpenedChest(){
        // off dialogs
        // set contents to empty
        // playerInventory.currentItem = null;
    } 

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player") && !other.isTrigger && !isOpen){
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player") && !other.isTrigger && !isOpen){
            playerInRange = false;
        }
    }


}