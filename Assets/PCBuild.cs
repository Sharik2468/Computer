using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCBuild : MonoBehaviour
{

    public Button VideoCardBtn;
    public GameObject VideoCard;
    public Button ProcessorBtn;
    public GameObject Processor;
    public Button CoolerBtn;
    public GameObject Cooler;
    public Button PUBtn;
    public GameObject PU;
    public Button RAMBtn;
    public GameObject RAM1;
    public GameObject RAM2;
    public Button MBBtn;
    public GameObject MB;
    int Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        VideoCardBtn.onClick.AddListener(VideoCardInFunc);
        ProcessorBtn.onClick.AddListener(ProcessorFunc);
        CoolerBtn.onClick.AddListener(CoolerFunc);
        PUBtn.onClick.AddListener(PUFunc);
        RAMBtn.onClick.AddListener(RAMFunc);
        RAMBtn.onClick.AddListener(RAM1Func);
        MBBtn.onClick.AddListener(MBFunc);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void VideoCardInFunc()
    {
        Animator m_Animator = VideoCard.GetComponent<Animator>();
        Debug.Log("You have clicked the button!");
        //VideoCardInAnim.Play("Base Layer.VideoCardIn");
       // m_Animator.SetFloat("Speed", 1);
        if (Score % 2 == 0)
            //m_Animator.Play("Base Layer.OUT", 0, 0.25f);
            m_Animator.SetTrigger("ButtonClick");
        else
            //m_Animator.Play("Base Layer.VCIN", 0, 0.25f);
            m_Animator.SetTrigger("ButtonClick");
        Score++;
    }

    void ProcessorFunc()
    {
        Animator m_Animator = Processor.GetComponent<Animator>();
        Debug.Log("You have clicked the button!");
        if (Score % 2 == 0)
            m_Animator.SetTrigger("ButtonClick");
        else
            m_Animator.SetTrigger("ButtonClick");
        Score++;
    }

    void CoolerFunc()
    {
        Animator m_Animator = Cooler.GetComponent<Animator>();
        Debug.Log("You have clicked the button!");
        if (Score % 2 == 0)
            m_Animator.SetTrigger("ButtonClick");
        else
            m_Animator.SetTrigger("ButtonClick");
        Score++;
    }

    void PUFunc()
    {
        Animator m_Animator = PU.GetComponent<Animator>();
        Debug.Log("You have clicked the button!");
        if (Score % 2 == 0)
            m_Animator.SetTrigger("ButtonClick");
        else
            m_Animator.SetTrigger("ButtonClick");
        Score++;
    }
    void RAMFunc()
    {
        Animator m_Animator = RAM1.GetComponent<Animator>();
        Debug.Log("You have clicked the button!");
        if (Score % 2 == 0)
            m_Animator.SetTrigger("ButtonClick");
        else
            m_Animator.SetTrigger("ButtonClick");
        Score++;
    }

    void RAM1Func()
    {
        Animator m_Animator = RAM2.GetComponent<Animator>();
        Debug.Log("You have clicked the button!");
        if (Score % 2 == 0)
            m_Animator.SetTrigger("ButtonClick");
        else
            m_Animator.SetTrigger("ButtonClick");
        Score++;
    }

    void MBFunc()
    {
        Animator m_Animator = MB.GetComponent<Animator>();
        Debug.Log("You have clicked the button!");
        if (Score % 2 == 0)
            m_Animator.SetTrigger("ButtonClick");
        else
            m_Animator.SetTrigger("ButtonClick");
        Score++;
    }
}
