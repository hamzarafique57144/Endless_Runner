using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedWaterMelon;
    private Rigidbody2D rb;
    public float startForce=5f;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Blade"))
        {
            Vector3 direction = (collision.transform.position-transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            Destroy(gameObject);
         GameObject slicedFruit =  Instantiate(slicedWaterMelon,collision.transform.position,rotation);
            Destroy(slicedFruit, 3f);
        }
    }
}
