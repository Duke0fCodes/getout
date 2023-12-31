using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask solidobjectslayer;
    public LayerMask interactablelayer;
    private bool isMoving;
    private Vector2 input;
<<<<<<< Updated upstream:GETOUT/Assets/Scripts/Player/Playercontrols.cs
    private Animator animator;
    
    private void Awake()
    {
        animator=GetComponent<Animator>();

      
=======
    private static Animator animator;
    private Inventory inventory;
    private void Awake()
    {
        animator=GetComponent<Animator>();
>>>>>>> Stashed changes:GETOUT/Assets/Scripts/Characters/PlayerController.cs
    } 
    public void HandleUpdate()
    {
        if(!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            if(input.x!=0) input.y=0;
            if(input!= Vector2.zero)
            {
                animator.SetFloat("moveX",input.x);
                animator.SetFloat("moveY",input.y);
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;
                if(IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));

            }
        }
        
        animator.SetBool("isMoving",isMoving);
        if(Input.GetKeyDown(KeyCode.Z))
            Interact();
    }
     void Interact()
    {
        var facingDir= new Vector3(animator.GetFloat("moveX"),animator.GetFloat("moveY"));
        var interactPos= transform.position + facingDir;
        //Debug.DrawLine(transform.position, interactPos, Color.green, 0.5f);
        var collider=Physics2D.OverlapCircle(interactPos, 0.3f, interactablelayer);
        if(collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving=true;
        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position=Vector3.MoveTowards(transform.position,targetPos,moveSpeed*Time.deltaTime);
            yield return null;

        }
        transform.position=targetPos;
        isMoving=false;
    }
    private bool IsWalkable(Vector3 targetPos)
        {
            if (Physics2D.OverlapCircle(targetPos, 0.2f, solidobjectslayer | interactablelayer) != null)
            {
                return false;
            }
            
        if (Physics2D.OverlapCircle(targetPos, 0.2f, wallsLayer) != null)
            {
                return false;
            }
            return true;
        }
}
