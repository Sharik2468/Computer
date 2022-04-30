using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //public float mainSpeed = 100.0f; //regular speed
    //public float shiftAdd = 250.0f; //multiplied by how long shift is held.  Basically running
    //public float maxShift = 1000.0f; //Maximum speed when holdin gshift
    //public float camSens = 0.25f; //How sensitive it with mouse
    //private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)
    //private float totalRun = 1.0f;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    //Cursor.lockState = CursorLockMode.Locked;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    lastMouse = Input.mousePosition - lastMouse;
    //    lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
    //    lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
    //    transform.eulerAngles = lastMouse;
    //    lastMouse = Input.mousePosition;
    //    //Mouse  camera angle done.  

    //    //Keyboard commands
    //    Vector3 p = GetBaseInput();
    //    if (Input.GetKey(KeyCode.LeftShift))
    //    {
    //        totalRun += Time.deltaTime;
    //        p = p * totalRun * shiftAdd;
    //        p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
    //        p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
    //        p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
    //    }
    //    else
    //    {
    //        totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
    //        p = p * mainSpeed;
    //    }

    //    p = p * Time.deltaTime;
    //    Vector3 newPosition = transform.position;
    //    if (Input.GetKey(KeyCode.Space))
    //    { //If player wants to move on X and Z axis only
    //        transform.Translate(p);
    //        newPosition.x = transform.position.x;
    //        newPosition.z = transform.position.z;
    //        transform.position = newPosition;
    //    }
    //    else
    //    {
    //        transform.Translate(p);
    //    }

    //}

    //private Vector3 GetBaseInput()
    //{ //returns the basic values, if it's 0 than it's not active.
    //    Vector3 p_Velocity = new Vector3();
    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        p_Velocity += new Vector3(0, 0, 1);
    //    }
    //    if (Input.GetKey(KeyCode.S))
    //    {
    //        p_Velocity += new Vector3(0, 0, -1);
    //    }
    //    if (Input.GetKey(KeyCode.A))
    //    {
    //        p_Velocity += new Vector3(-1, 0, 0);
    //    }
    //    if (Input.GetKey(KeyCode.D))
    //    {
    //        p_Velocity += new Vector3(1, 0, 0);
    //    }
    //    return p_Velocity;
    //}

    public bool CanMove { get; set; } = true;
    [Header("Movement Parameters")]
    [SerializeField] private float WalkSpeed = 3.0f;
    [SerializeField] private float Gravity = 30.0f;

    [Header("Look Parameters")]
    [SerializeField, Range(1, 10)] private float LookSpeedX = 2.0f;
    [SerializeField, Range(1, 10)] private float LookSpeedY = 2.0f;
    [SerializeField, Range(1, 180)] private float UpperLookLimit = 80.0f;
    [SerializeField, Range(1, 180)] private float LowerLookLimit = 80.0f;

    private Camera PlayerCamera;
    public CharacterController CharacterController;

    private Vector3 MoveDirection;
    private Vector2 CurrentInput;

    private float RotationX = 0;

    private void Awake()
    {
        PlayerCamera = GetComponentInChildren<Camera>();
        CharacterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (CanMove)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            HandleMovementInput();
            HandleMouseLook();

            ApplyFinalMovements();
        }
        else 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void HandleMovementInput()
    {
        CurrentInput = new Vector2(WalkSpeed * Input.GetAxis("Vertical"), WalkSpeed * Input.GetAxis("Horizontal"));

        float MoveDirectionY = MoveDirection.y;
        MoveDirection = (transform.TransformDirection(Vector3.forward) * CurrentInput.x) + (transform.TransformDirection(Vector3.right) * CurrentInput.y);
    }

    private void HandleMouseLook()
    {
        RotationX -= Input.GetAxis("Mouse Y") * LookSpeedY;
        RotationX = Mathf.Clamp(RotationX, -UpperLookLimit, LowerLookLimit);
        PlayerCamera.transform.localRotation = Quaternion.Euler(RotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * LookSpeedX, 0);
    }

    private void ApplyFinalMovements()
    {
        if (!CharacterController.isGrounded)
            MoveDirection.y -= Gravity * Time.deltaTime;

        CharacterController.Move(MoveDirection * Time.deltaTime);
    }
}
