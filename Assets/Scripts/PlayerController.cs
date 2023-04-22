using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera sceneCamera;

    public int maxCol;

    public float moveSpeed;
    public float dashSpeed;
    public float interactRadius;
    public float focusLinger;

    public Rigidbody2D rb;

    public Interactable focusedInteractable;

    public Collider2D[] nearbyObjects;

    private Vector2 moveDirection;
    private Vector2 mousePosition;

    private float oldIntDistance = 9999f;

    

    void Update()
    {
        ProcessInputs();
        SetFocus();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            dash();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            interact();
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    void dash()
    {
        rb.position = new Vector2(rb.position.x + moveDirection.x * moveSpeed * dashSpeed, rb.position.y + moveDirection.y * moveSpeed * dashSpeed);
    }

    void interact()
    {
        if(focusedInteractable != null)
        {
            focusedInteractable.Interact(); 
        }
    }

    void SetFocus()
    {
        if (focusedInteractable != null)
        {
            oldIntDistance = Vector3.Distance(transform.position, focusedInteractable.transform.position) - focusLinger;
            if (oldIntDistance > interactRadius)
            {
                focusedInteractable.GetComponent<Outline>().enabled = false;
                focusedInteractable = null;
            }
        }
        else
        {
            oldIntDistance = 9999f;
        }

        nearbyObjects = new Collider2D[maxCol];
        int nObjects = Physics2D.OverlapCircleNonAlloc(transform.position, interactRadius, nearbyObjects);
        for (int i = 0; i < nObjects; i++)
        {
            Collider2D currentObject = nearbyObjects[i];
            if (currentObject.GetComponent<Interactable>() != null)
            {
                float dist = Vector3.Distance(transform.position, currentObject.transform.position);
                if (dist < oldIntDistance)
                {
                    if (focusedInteractable != null)
                    {
                        focusedInteractable.GetComponent<Outline>().enabled = false;
                    }
                    focusedInteractable = currentObject.GetComponent<Interactable>();
                    focusedInteractable.GetComponent<Outline>().enabled = true;
                    oldIntDistance = dist;
                }
            }
        }
    }
}
