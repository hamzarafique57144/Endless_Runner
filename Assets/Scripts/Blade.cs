using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    bool isCutting = false;
    private Rigidbody2D rb;
    Camera cam;
    public GameObject bladeTrailPrefab;
    GameObject currentTrail;
    CircleCollider2D circleCollider2D;
    Vector2 previousPosition;
    public float minCutVelocity = 0.001f;
    private void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
      if(Input.GetMouseButtonDown(0))
        {
            StartCutting();
            rb = GetComponent<Rigidbody2D>();
            cam = Camera.main;
        } 
      else if(Input.GetMouseButtonUp(0))
            {
            StopCutting();
        }
      if(isCutting)
        {
            UpdateCutting();
        }
    }
   void StartCutting()
    {
        isCutting = true;
        currentTrail = Instantiate(bladeTrailPrefab, transform);
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        circleCollider2D.enabled = true;
    }
    void StopCutting()
    {
        isCutting = false;
        currentTrail.transform.SetParent(null);
        Destroy(currentTrail,2f);
        circleCollider2D.enabled = false;
    }
    void UpdateCutting()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position =newPosition;
        float velocity = (newPosition - previousPosition).magnitude/Time.deltaTime;
        if(velocity>minCutVelocity)
        {
            circleCollider2D.enabled = true;
        }
        else
        {
            circleCollider2D.enabled = false;
        }
        previousPosition = newPosition;
    }
    
}
