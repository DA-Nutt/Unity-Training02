using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Variables
    public float moveSpeed; //Move speed for the enemy GameObject
    public float movementBuffer; //
    public float minMovementBuffer; // Randomizes the movementBuffer variable
    public float mmaxMovementBuffer;
    private Vector3 moveDirection;

    private CharacterController characterController;
    private Vector3 actualDirection;
    private Transform playerTransform;
    
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        characterController = GetComponent<CharacterController>();
        StartCoroutine(EnemyMovementRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerTransform);
        actualDirection = transform.TransformDirection(moveDirection);
        characterController.Move(moveSpeed * actualDirection * Time.deltaTime); //Moves object based on global orientation
    }

    //What is a Coroutine? 
    private IEnumerator EnemyMovementRoutine() //A Coroutine that makes the enemy zigzag left to right as it follows the player
    {
        while(true) //Infinite Loop
        {
            movementBuffer = UnityEngine.Random.Range(minMovementBuffer, mmaxMovementBuffer);

            moveDirection = Vector3.right + Vector3.forward; // Zig to the right for movementBuffer seconds
            yield return new WaitForSeconds(movementBuffer);

            moveDirection = Vector3.left + Vector3.forward; // Zag to the left for movementBuffer seconds
            yield return new WaitForSeconds(movementBuffer);
        }
    }

}
