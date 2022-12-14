using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapScreen : MonoBehaviour
{

    public Rigidbody2D rb;
    private Vector2 currPosition;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        currPosition = rb.position;
   //     Debug.Log(currPosition);
    }


    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "WrapScreenColliderX")
        {

                Vector2 pos = new Vector2(-currPosition.x - 2.155656f, currPosition.y);
                rb.MovePosition(pos);
        }
        if (other.gameObject.tag == "WrapScreenColliderY")
        {

           Vector2 pos = new Vector2(currPosition.x, -currPosition.y);
           rb.MovePosition(pos);

        }

    }





}
