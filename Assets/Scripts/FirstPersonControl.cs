using System.Net;
using System.Threading;
using UnityEngine;

public class FirstPersonControl : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    public Camera playerCamera;
    private float xRotation = 0f;

    public float bobbingSpeed = 0.08f;
    public float bobbingAmount = 0.1f;
    public float bobbingMidpoint = 2f;
    private float bobbingTimer = 0f;

    public float cameraSwaySpeed = 4f;
    public float swayAmount = 0.05f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
          Cursor.lockState = CursorLockMode.Locked;
         Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseLook();
        HandleMovement();
        HandleHeadBob();
        // HandleCameraSway();

    }

    private void LateUpdate()
    {
        
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerBody.transform.position += playerBody.transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerBody.transform.position += -playerBody.transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerBody.transform.position += -playerBody.transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerBody.transform.position += playerBody.transform.right * speed * Time.deltaTime;
        }
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //check
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -50f, 50f);

        transform.localRotation = Quaternion.Euler(xRotation,0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

    }

    void HandleHeadBob()
    {
        //float waveslice = 0.0f;
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");
        //print(horizontal + " " + vertical);
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        //reset
        if (!isMoving)
        {
            bobbingTimer = 0.0f;
        }
        else
        {
            float waveslice = Mathf.Sin(bobbingTimer);
            bobbingTimer = bobbingTimer + bobbingSpeed;
            if (bobbingTimer > Mathf.PI * 2)
            {
                bobbingTimer = bobbingTimer - (Mathf.PI * 2);
            }
            Vector3 localPos = transform.localPosition;
            if (waveslice != 0)
            {
                float translateChange = waveslice * bobbingAmount;
                //float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
                //totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
                //translateChange = totalAxes * translateChange;
                localPos.y = bobbingMidpoint + translateChange;
            }
            else
            {
                localPos.y = bobbingMidpoint;
            }

            transform.localPosition = localPos;
            //}
        }

        void HandleCameraSway()
        {
            float movementX = Mathf.Clamp(Input.GetAxis("Mouse X") * swayAmount, -swayAmount, swayAmount);
        }
    }
}

