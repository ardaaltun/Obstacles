using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    Rigidbody rb;
    bool grounded = false;
    [SerializeField]
    float jumpForce = 20f;
    Vector2 startTouchPosition;
    Vector2 currentPosition;
    Vector2 endTouchPosition;
    bool stopTouch = false;
    public float swipeRange;
    public float tapRange;

    

    public Text text;
    string position = " already mid";
    bool left = false;
    bool mid = true;
    bool right = false;
    float speed = 10f;

    void Start()
    {
        text.text = position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = position;
        if(mid)
        {
            Vector3 target = new Vector3(0f, transform.localPosition.y, transform.localPosition.z);
            transform.localPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime * speed);
        }
        else if (left)
        {
            Vector3 target = new Vector3(-1f, transform.localPosition.y, transform.localPosition.z);
            transform.localPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime * speed);
        }
        else if (right)
        {
            Vector3 target = new Vector3(1f, transform.localPosition.y, transform.localPosition.z);
            transform.localPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime * speed);
        }

        //text.text = transform.localPosition.ToString();
        Swipe();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
            grounded = true;
        if (collision.gameObject.tag == "box")
            SceneManager.LoadScene(2);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
            grounded = false;
    }

    void Jump()
    {
        //if (joystick.Direction.y >= 0.5f && grounded)
            //rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    void Swipe()
    {
        
            
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 distance = currentPosition - startTouchPosition;

            if (!stopTouch)
            {
                if (distance.x < -swipeRange)
                {
                    //left
                    if (left)
                    {
                        left = true;
                        mid = false;
                        right = false;
                        position = "already left";
                        //Move("left","left");
                        //transform.localPosition = new Vector3(-1f, transform.localPosition.y, transform.localPosition.z);
                    }
                    else if (mid)
                    {
                        mid = false;
                        left = true;
                        right = false;
                        position = "mid to left";
                        //Move("mid", "left");
                        //transform.localPosition = new Vector3(-1f, transform.localPosition.y, transform.localPosition.z);
                    }

                    else if(right)
                    {
                        right = false;
                        mid = true;
                        left = false;
                        position = "right to mid";
                        //Move("right", "left");
                        //transform.localPosition = new Vector3(0f, transform.localPosition.y, transform.localPosition.z);
                    }

                    stopTouch = true;

                }
                else if (distance.x > swipeRange)
                {
                    //right
                    if (left)
                    {
                        left = false;
                        mid = true;
                        right = false;
                        position = "left to mid";
                        //Move("left", "right");
                        //transform.localPosition = new Vector3(0f, transform.localPosition.y, transform.localPosition.z);
                    }
                    else if (mid)
                    {
                        mid = false;
                        left = false;
                        right = true;
                        position = "mid to right";
                        //Move("mid", "right");
                        //transform.localPosition = new Vector3(1f, transform.localPosition.y, transform.localPosition.z);
                    }

                    else if (right)
                    {
                        right = true;
                        mid = false;
                        left = false;
                        position = "already right";
                        //Move("right", "right");
                        
                        //transform.localPosition = new Vector3(1f, transform.localPosition.y, transform.localPosition.z);
                    }
                    stopTouch = true;
                }
                else if (distance.y > swipeRange)
                {
                    //up

                    //transform.localPosition = new Vector3(-1f, transform.localPosition.y, transform.localPosition.z);

                    stopTouch = true;
                }
                else if (distance.y < -swipeRange)
                {
                    //down
                    //transform.localPosition = new Vector3(-1f, transform.localPosition.y, transform.localPosition.z);
                    stopTouch = true;
                }
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
            endTouchPosition = Input.GetTouch(0).position;
            Vector2 distance = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(distance.x) < tapRange && Mathf.Abs(distance.y) < tapRange)
            {
                //tap
            }
        }
    }
    /*
    void Move(string position, string swipe)
    {
        
        if(position == "left" && swipe == "left")
        {
            text.text = "already left";
        }
        else if (position == "mid" && swipe == "left")
        {
            text.text = "mid to left";
        }
        else if (position == "right" && swipe == "left")
        {
            text.text = "right to mid";
        }
        else if (position == "right" && swipe == "right")
        {
            text.text = "already right";
        }
        else if (position == "mid" && swipe == "right")
        {
            text.text = "mid to right";
        }
        else if (position == "left" && swipe == "right")
        {
            text.text = "left to mid";
        }
    }
    */

}
