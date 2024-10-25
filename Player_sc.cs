using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Player_sc : MonoBehaviour
{
    public float speed = 3.0f; //degisken public tanimlanirsa Inspector penceresinde gorunur
    public GameObject laserPrefab;
    float fireRate = 0.5f;  //atislar arasındaki sure 
    float nextFire = 0f; //atis yapmak icin beklenmesi gereken süre(en az)

    [SerializeField]
    private int _lives = 3;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        FireLaser();

    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * speed * Time.deltaTime);

        //Math.clamp, y koordinatının bir sınır icinde tutulmasını saglar
        transform.position = new Vector3(transform.position.x, Math.Clamp(transform.position.y, -3.8f,0), 0);

        if (transform.position.x >= 9.2f){
            transform.position = new Vector3(-9.2f, transform.position.y,0);
        }
        else if (transform.position.x <= -9.2f){
            transform.position = new Vector3(9.2f, transform.position.y,0);
        }
    }

    void FireLaser(){
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire){
            Instantiate(laserPrefab, transform.position + new Vector3(0,0.8f,0), Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    public void Damage()
    {
        _lives--;
        
        if(_lives < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
