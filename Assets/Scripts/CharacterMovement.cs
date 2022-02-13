using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
 
public class CharacterMovement : MonoBehaviour
{
    //NavMeshAgent variable control player movement
    public NavMeshAgent playerNavMeshAgent;
 
    //A Camera that follow player movement
    public Camera playerCamera;
 
    //Control the animation clips of player object 
    public Animator playerAnimator;
    
    //check player is running(moving) or not
    public bool isRunning;

    ////////////////////////////////////////

    public bool Move = false;
    public Rigidbody MovingRigidbody;
    public Vector3 Destination;
 
    public Transform Balancer;
    public Rigidbody BalancerRb;

    private void OnEnable() {
        if(BalancerRb == null)
        {
            BalancerRb = Balancer.GetComponent<Rigidbody>();
        }
    }
    private void Update()
 
    {
        if(Input.GetMouseButtonDown(0))
        {
            RagdollUp();
        }

        if(Input.GetMouseButtonUp(0))
        {
            //RagdollDown();
        }
        
        if (Input.GetMouseButton(0))
        {
            //Unity cast a ray from the position of mouse cursor on-screen toward the 3D scene.
            Ray myRay = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit myRaycastHit;
 
            //if (Physics.Raycast(myRay, out myRaycastHit))
            {
                //if(myRaycastHit.rigidbody.mo GetComponentInParent<GameObject>().name == "Fighter")
                {
                    Destination = Input.mousePosition;
                    Balancer.gameObject.SetActive(false);
                    //FollowPointer();
                }
                //Assign ray hit point as Destination of Navemesh Agent (Player)
                //playerNavMeshAgent.SetDestination(myRaycastHit.point);
            }
        }
 
        //Compare the value of the remaining distance and the stopping distance(Destination point)
        
        /*if (playerNavMeshAgent.remainingDistance <= playerNavMeshAgent.stoppingDistance)
        {
            //The remaining distance are less or equal than the stopping distance it means character stop moving and reached destination
            isRunning = false;
        }
        else
        {
            //If remaining distance are greater than the stopping distance than character still moving toward Destination
            isRunning = true;
        }*/
 
        //playerAnimator.SetBool("IsRun", isRunning);
 
    }

    
    public void RagdollUp()
    {
        Move = true;
        Balancer.transform.SetPositionAndRotation((transform.position + new Vector3(0, 10, 0)), Quaternion.identity);
        //MovingRigidbody.AddForce(new Vector3(0, 110, 0), ForceMode.Force);
    }

    public void RagdollDown()
    {
        Move = false;
        //Balancer.transform.SetPositionAndRotation((transform.position - new Vector3(0, 0, 0)), Quaternion.identity);
    }

    public void FollowPointer() 
    {
        BalancerRb.MovePosition(Destination);
    }
}