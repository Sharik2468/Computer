using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    bool Visible = false;
    public Canvas myCanvas;
    GameObject Player;
    Movement PlayerMovement;
    //public Animator VideoCardInAnim;
    //public Button VideoCardBtn;
    //public GameObject VideoCard;
    //int Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement = Player.GetComponent<Movement>();
        //VideoCardBtn.onClick.AddListener(VideoCardInFunc);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
            Visible = true;
        if (Input.GetKey(KeyCode.Q))
            Visible = false;
        if (Visible)
        {
            myCanvas.enabled = true;
            Time.timeScale = 0;

            Cursor.visible = true;
            PlayerMovement.camSens = 0f;
            //Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            myCanvas.enabled = false;
            Time.timeScale = 1;
            PlayerMovement.camSens = 0.25f;
            //Cursor.lockState = CursorLockMode.Locked;
        }
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
