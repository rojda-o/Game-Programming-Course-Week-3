using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    [SerializeField]
    
    private float _speed = 4.0f; //the enemy moves 4 meters per second


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y < -5f)  //Check if y position is less than -5f
        {
            float randomX = Random.Range(-8f,8f); //Select a random x value between -8 and 8
            transform.position = new Vector3(randomX, 7, 0); //Relocate the enemy at the top (y = 7f) with the given x value
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Hit: "+ other.transform.name);

        if (other.tag == "Player")
        {
            //Damage the player
            Player_sc player = other.transform.GetComponent<Player_sc>();

            if(player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }
        else if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
