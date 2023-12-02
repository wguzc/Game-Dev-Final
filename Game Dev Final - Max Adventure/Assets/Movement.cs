using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] protected float speed = 5;
    [SerializeField] AnimationStateChanger animationStateChanger;
    [SerializeField] Transform body;
    //[SerializeField] float speed = 1;
    protected Rigidbody2D rb;

    void Awake(){
         rb = GetComponent<Rigidbody2D>();
    }

    void Start(){

    }

    //ignore this
    // public void MoveTransform(Vector3 vel){
    //     transform.position += vel * speed * Time.deltaTime;
    // }

    public void MoveRB(Vector3 vel)
{
    rb.velocity = vel * speed;

    if (vel.magnitude > 0)
    {
        if (Mathf.Abs(vel.y) > Mathf.Abs(vel.x))
        {
            // Moving Up or Down
            if (vel.y > 0)
            {
                // Moving Up
                animationStateChanger.ChangeAnimationState("WalkUp", speed / 5);
            }
            else
            {
                // Moving Down
                animationStateChanger.ChangeAnimationState("WalkDown", speed / 5);
            }
        }
        else
        {
            // Moving Left or Right
            if (vel.x > 0)
            {
                // Moving Right
                animationStateChanger.ChangeAnimationState("Walk", speed / 5);
                body.localScale = new Vector3(1, 1, 1);
            }
            else if (vel.x < 0)
            {
                // Moving Left
                animationStateChanger.ChangeAnimationState("Walk", speed / 5);
                body.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
    else
    {
        // Standing still
        animationStateChanger.ChangeAnimationState("Idle");
    }
}


    // public void MoveRB(Vector3 vel){
    //     rb.velocity = vel * speed;

    //     if(vel.magnitude > 0){
            
    //         animationStateChanger.ChangeAnimationState("Walk", speed/5);
            
    //         if(vel.x > 0){
    //             body.localScale = new Vector3(1,1,1);
    //         }else if(vel.x < 0 ){
    //             body.localScale = new Vector3(-1,1,1);
    //         }

    //     }else{
    //         animationStateChanger.ChangeAnimationState("Idle");
    //     }
    // }


    //and this
    //     //rb.MovePosition(transform.position + (vel*Time.fixedDeltaTime));
    //     //rb.AddForce(vel);
    // }

    // public void StepMove(Vector3 direction){
    //     transform.position += direction;
    // }
       
}