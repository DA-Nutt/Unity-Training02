using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDirection : MonoBehaviour
{
    #region Variables
    public float speed = 4;
    public MovementPattern movementPattern = MovementPattern.NormalForward;
    public float movementBuffer = 0.5f;

    private Vector3 moveDirection;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        switch (movementPattern)
        {
            case MovementPattern.NormalForward:
                moveDirection = Vector3.forward;
                break;
            case MovementPattern.BoomerangForward:
                StartCoroutine(BoomerangForwardRoutine());
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * Time.deltaTime * speed);
    }

    private IEnumerator BoomerangForwardRoutine()
    {
        while (true)
        {
            moveDirection = Vector3.forward;
            yield return new WaitForSeconds(movementBuffer);
            moveDirection = Vector3.back;
            yield return new WaitForSeconds(movementBuffer);
        }
    }
}
