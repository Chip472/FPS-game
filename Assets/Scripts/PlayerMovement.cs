using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private Rigidbody playerRigid;
    [SerializeField] private float speed;
    [SerializeField] private float mouseSensitivity;

    float inputHorizontal;
    float inputVertical;
    float inputMouseX;
    float inputMouseY;

    float verticalLookRot;

    Vector3 smoothMoveVelocity;
    Vector3 moveAmt;
    float smoothTime;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        inputMouseX = Input.GetAxisRaw("Mouse X");
        inputMouseY = Input.GetAxisRaw("Mouse Y");

        Movement(inputHorizontal, inputVertical);
        Look();
    }

    public void Movement(float h, float v)
    {
        Vector3 moveDir = new Vector3(inputHorizontal, 0, inputVertical).normalized;
        moveAmt = Vector3.SmoothDamp(moveAmt, moveDir * speed, ref smoothMoveVelocity, smoothTime);

        //playerRigid.AddForce(h * speed, 0, v * speed);
        playerRigid.MovePosition(playerRigid.position + transform.TransformDirection(moveAmt) * Time.deltaTime);
    }

    public void Look()
    {
        transform.Rotate(Vector3.up * inputMouseX * mouseSensitivity);

        verticalLookRot += inputMouseY * mouseSensitivity;
        verticalLookRot = Mathf.Clamp(verticalLookRot, -90, 90);
        cam.transform.localEulerAngles = Vector3.left * verticalLookRot;
    }
}
