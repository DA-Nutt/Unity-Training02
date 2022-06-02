using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region variables
    public float moveSpeed;
    private float xInput;
    private float zInput;
    public CharacterController characterController;
    private Vector3 moveDirection;

    public GameObject[] abilities;
    private Camera cam;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        LookAtMouse();
    }

    private void FixedUpdate()
    {
        /*   if (moveDirection != Vector3.zero)
           {
               gameObject.transform.forward = moveDirection; //Makes the player face the direction they are moving in
           } */

        moveDirection = new Vector3(xInput, 0, zInput);
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void LookAtMouse()
    {

    }
}
