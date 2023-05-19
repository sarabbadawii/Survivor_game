using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            
            Destroy(collision.gameObject);
            FindObjectOfType<PlayerScore>().IncreaseScore();
        }
        Destroy(gameObject);
    }
}
