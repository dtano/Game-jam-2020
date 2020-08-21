using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour, IInventoryItem
{   
    public Dialogue dialogue;
    public Inventory2 inventory;
    public string Name
    {
        get
        {
            return "Recorder";
        }
    }

    public Sprite _Image = null;
    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    
    private void OnMouseDown() {
        Transform transform = GameObject.Find("Player").transform;
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        StopAllCoroutines();
        StartCoroutine(AddToInventory(transform));
        
    }
    
    IEnumerator AddToInventory(Transform target){
        while(Mathf.Abs(transform.position.x - target.position.x) > 1.0f){
                yield return null;
        }

        Debug.Log("Dialogue started");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        

        // Add the item to the inventory here
        IInventoryItem item = this.GetComponent<IInventoryItem>();
        if(item != null){
            
            inventory.AddItem(item);
            Debug.Log("Item added to inventory");    
        }

        Debug.Log("Coroutine is now finished");
        StopCoroutine(AddToInventory(target));
        

    }
    public void OnPickup()
    {
        gameObject.GetComponent<HoverOver>().hoverOver.SetActive(false);
        gameObject.SetActive(false);
    }

    
    public void OnDrop()
    {   
        
        float laser = 1f;
        int layerMask = LayerMask.GetMask("Furniture");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, laser, layerMask);

        if (hit.collider != null)
        {
            
            Debug.Log("Hitting: " + hit.collider.tag);
        }
 
        Debug.DrawRay(transform.position, Vector2.left * laser, Color.red);
        
        Debug.Log("drop");
    }
    /*
    private void OnCollisionEnter2D(Collision2D col) {
        
        if(col.gameObject.name == "Trashcan")
        {
            Debug.Log("hit");
        }
    }
    */




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
