using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyPad : Interactable
{
   [SerializeField] private GameObject door;
    private bool doorOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // where we design interaction using code
    protected override void Interact()
    {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("isOpen", doorOpen);
    }
}
