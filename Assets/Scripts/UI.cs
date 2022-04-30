using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private bool BoolLerp1 = false;
    private bool BoolLerp2 = false;
    private bool BoolLerp3 = false;

    float timeLeft = 3.0f;
    bool TimerEnabled = false;

    public Canvas myCanvas;
    GameObject Player;
    Movement PlayerMovement;
    //public Animator VideoCardInAnim;
    //public Button VideoCardBtn;
    //public GameObject VideoCard;
    //int Score = 0;

    public Vector3 d1 = new Vector3(-1.604f, 1.259f, 0.014f);
    public Quaternion dq1 = new Quaternion(0f, 90f, 0f, 0f);

    public Vector3 d2 = new Vector3(-1.756f, 2.879f, -0.087f);
    public Quaternion dq2 = new Quaternion(90f, 0f, 0f, 0f);

    public Vector3 d3 = new Vector3(-1.756f, 2.879f, -0.087f);
    public Quaternion dq3 = new Quaternion(0f, 0f, 0f, 0f);
    public float smoothing = 6f;

    float ElapsedTime=0;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement = Player.GetComponent<Movement>();
        //VideoCardBtn.onClick.AddListener(VideoCardInFunc);
        ShowUI(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerEnabled)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                BoolLerp3 = false;
                TimerEnabled = false;
            }
        }

        if (BoolLerp1)
        {
            ElapsedTime += Time.deltaTime;
            float PersentageComplete = ElapsedTime / smoothing;

            Player.transform.position = Vector3.Lerp(Player.transform.position, d1, Mathf.Clamp(PersentageComplete, 0f, 0.99f));
            Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, dq1, Mathf.Clamp(PersentageComplete, 0f, 0.99f));
            GameObject.FindGameObjectWithTag("MainCamera").transform.rotation = Quaternion.Lerp(GameObject.FindGameObjectWithTag("MainCamera").transform.rotation, dq1, Mathf.Clamp(PersentageComplete, 0f, 0.99f));
        }

        if (BoolLerp2)
        {
            ElapsedTime += Time.deltaTime;
            float PersentageComplete = ElapsedTime / smoothing;

            Player.transform.position = Vector3.Lerp(Player.transform.position, d2, Mathf.Clamp(PersentageComplete, 0f, 0.99f));
            Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, dq2, Mathf.Clamp(PersentageComplete, 0f, 0.99f));
            GameObject.FindGameObjectWithTag("MainCamera").transform.rotation = Quaternion.Lerp(GameObject.FindGameObjectWithTag("MainCamera").transform.rotation, dq2, Mathf.Clamp(PersentageComplete, 0f, 0.99f));
        }

        if (BoolLerp3)
        {
            ElapsedTime += Time.deltaTime;
            float PersentageComplete = ElapsedTime / smoothing;

            Player.transform.position = Vector3.Lerp(Player.transform.position, d3, Mathf.Clamp(PersentageComplete, 0f, 0.99f));
            Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, dq3, Mathf.Clamp(PersentageComplete, 0f, 0.99f));
            GameObject.FindGameObjectWithTag("MainCamera").transform.rotation = Quaternion.Lerp(GameObject.FindGameObjectWithTag("MainCamera").transform.rotation, dq3, Mathf.Clamp(PersentageComplete, 0f, 0.99f));
        }

        if (Input.GetKey(KeyCode.E))
            ShowUI(true);
        if (Input.GetKey(KeyCode.Q))
            ShowUI(false);
        if (Input.GetKey(KeyCode.R))
            ShowCursor(true);
        if (Input.GetKey(KeyCode.T))
            ShowCursor(false);
        if (Input.GetKey(KeyCode.Alpha1))
        {
            //ShowCursor(true);
            //PlayerMovement.camSens = 0f;
            PlayerMovement.CanMove = false;
            PlayerMovement.CharacterController.enabled = false;
            BoolLerp1 = true;
            BoolLerp2 = false;
            BoolLerp3 = false;
            Player.GetComponent<Rigidbody>().useGravity = false;
            Player.GetComponent<Collider>().enabled = false;
            timeLeft = 3.0f;
            ElapsedTime = 0;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            //ShowCursor(true);
            //PlayerMovement.camSens = 0f;
            PlayerMovement.CanMove = false;
            PlayerMovement.CharacterController.enabled = false;
            BoolLerp1 = false;
            BoolLerp2 = true;
            BoolLerp3 = false;
            Player.GetComponent<Rigidbody>().useGravity = false;
            Player.GetComponent<Collider>().enabled = false;
            timeLeft = 3.0f;
            ElapsedTime = 0;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
           // ShowCursor(false);
            // PlayerMovement.camSens = 0.25f;
            PlayerMovement.CanMove = true;
            Player.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            PlayerMovement.CharacterController.enabled = true;
            BoolLerp1 = false;
            BoolLerp2 = false;
            BoolLerp3 = true;
            Player.GetComponent<Rigidbody>().useGravity = true;
            Player.GetComponent<Collider>().enabled = true;
            TimerEnabled = true;
            timeLeft = 3.0f;
            ElapsedTime = 0;
        }
    }
    private void ShowCursor(bool Enabled)
    {
        //myCanvas.enabled = Enabled;
        //Time.timeScale = 0;

        //Cursor.visible = Enabled;
        if (Enabled)
        {
            //PlayerMovement.camSens = 0f;
            PlayerMovement.CharacterController.enabled = false;
            PlayerMovement.CanMove = false;
        }
        else
        {
            //PlayerMovement.camSens = 0.25f;
            PlayerMovement.CharacterController.enabled = true;
            PlayerMovement.CanMove = true;
        }
    }

    private void ShowUI(bool Enabled)
    {
        myCanvas.enabled = Enabled;
        Time.timeScale = Enabled ? 0 : 1;

        Cursor.visible = Enabled;
        //PlayerMovement.camSens = Enabled ? 0f : 0.25f;
        PlayerMovement.CanMove = Enabled ? false : true;
        //Cursor.lockState = CursorLockMode.None;
    }

    //void VideoCardInFunc()
    //{
    //    Animator m_Animator = VideoCard.GetComponent<Animator>();
    //    Debug.Log("You have clicked the button!");
    //    //VideoCardInAnim.Play("Base Layer.VideoCardIn");
    //    //m_Animator.SetFloat("Speed", 1);
    //    if (Score % 2 == 0)
    //        m_Animator.Play("Base Layer.OUT", 0, 0.25f);
    //    else
    //        m_Animator.Play("Base Layer.VCIN", 0, 0.25f);
    //    Score++;
    //}
}
