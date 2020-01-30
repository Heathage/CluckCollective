using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLostBehaviour : StateMachineBehaviour
{
    public float speed;
    public float angularSpeed;
    private float startSearchTime = 5f;
    private float searchTime;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        searchTime = 5f;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /**if (Vector3.Distance(animator.transform.position, FOVDetection.playerLastKnownPos) > 0.2f)
        {
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, FOVDetection.playerLastKnownPos, speed * Time.deltaTime);
            Vector3 targetDirection = FOVDetection.playerLastKnownPos - animator.transform.position;
            float singleStep = angularSpeed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(animator.transform.forward, targetDirection, singleStep, 0.0f).normalized;
            animator.transform.rotation = Quaternion.LookRotation(newDirection);
            
        }
        else
        {
            if(searchTime <= 0)
            {
                
                searchTime = startSearchTime;
                animator.SetBool("isPatrolling", false);

            }
            else
            {
                animator.transform.Rotate(Vector3.up * angularSpeed * Time.deltaTime);
                //if (FOVDetection.isInFov)
                //{
                //    animator.SetBool("isPlayerLost", false);
                //}
                searchTime -= Time.deltaTime;
            }
        }**/
        

        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
