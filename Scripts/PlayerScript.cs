using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float pSpeed = 5;
    private Animator anim;
    private float verticalValue;
    public bool isShooting = false;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>(); 
    }
    private void Update()
    {
        verticalValue = Input.GetAxisRaw("Vertical");
        if ( ! isShooting)
        {
            Move();
        }
        
        Turn();

    }
    private void Move()
    {
       
        if(verticalValue > 0)
        {
            anim.SetBool("Running" ,true);
            anim.SetFloat("Direction", verticalValue);
            transform.position = transform.position + transform.forward * verticalValue * pSpeed * Time.deltaTime;
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }
    private void Turn()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit groundHit;
        if (Physics.Raycast(cameraRay , out groundHit , Mathf.Infinity))
        {
            if (Vector3.Distance(transform.position, groundHit.point) < 7)
            {
                return;
            }
            Vector3 playerToMouse = groundHit.point - transform.position;
            playerToMouse.y = 0;
            

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * 5);
        }
    }
}
