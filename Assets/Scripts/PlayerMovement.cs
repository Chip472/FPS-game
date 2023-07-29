using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigid;
    [SerializeField] private float speed;

    float inputHorizontal;
    float inputVertical;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        Movement(inputHorizontal, inputVertical);
    }

    public void Movement(float h, float v)
    {
        playerRigid.AddForce(h * speed, 0, v * speed);
    }
}
