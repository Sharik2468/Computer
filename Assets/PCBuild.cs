using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PCBuild : MonoBehaviour, IPointerClickHandler
{
    public Button VideoCardBtn;
    public GameObject VideoCard;
    int VCE = 0;
    public Button ProcessorBtn;
    public GameObject Processor;
    int PE = 0;
    public Button CoolerBtn;
    public GameObject Cooler;
    public GameObject Cooler1;
    int CE = 0;
    public Button PUBtn;
    public GameObject PU;
    int PUE = 0;
    public Button RAMBtn;
    public GameObject RAM1;
    int RAM1E = 0;
    public GameObject RAM2;
    int RAM2E = 0;
    public Button MBBtn;
    public GameObject MB;
    int MBE = 0;//?????? - ?????????
    public Button KrBtn;
    public GameObject Kr;
    int KrE = 0;
    public Button PowerButtonButton;
    public GameObject PowerButton;
    int PBE = 0;

    public GameObject MonitorScreen;
    public Material[] ScreenMaterials;

    MeshRenderer MeshRender;
    float timeLeft = -1.0f;

    int l;

    AudioSource m_MyAudioSource;

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
        KrBtn.onClick.AddListener(KrFunc);
        PowerButtonButton.onClick.AddListener(PowerButtonClick);
        PU.GetComponent<Button>().onClick.AddListener(PUFunc);
        Cooler.GetComponent<Button>().onClick.AddListener(CoolerFunc);
        VideoCard.GetComponent<Button>().onClick.AddListener(VideoCardInFunc);
        Processor.GetComponent<Button>().onClick.AddListener(ProcessorFunc);
        RAM1.GetComponent<Button>().onClick.AddListener(RAMFunc);
        RAM2.GetComponent<Button>().onClick.AddListener(RAM1Func);
        MB.GetComponent<Button>().onClick.AddListener(MBFunc);
        Kr.GetComponent<Button>().onClick.AddListener(KrFunc);
        PowerButton.GetComponent<Button>().onClick.AddListener(PowerButtonClick);

        MeshRender = MonitorScreen.GetComponent<MeshRenderer>();

        m_MyAudioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {

        if (timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                PCChangeMaterial();
            }
        }

        if (CE % 2 == 0)
            ProcessorBtn.enabled = false;
        else
            ProcessorBtn.enabled = true;

        if (VCE % 2 == 0 && //
            PE % 2 == 0 && //
            CE % 2 == 0 &&//
            PUE % 2 == 0 &&//
            RAM1E % 2 == 0 &&//
            RAM2E % 2 == 0)
            MBBtn.enabled = false;
        else
            MBBtn.enabled = true;

        if (VCE % 2 == 0 && //
            PE % 2 == 0 && //
            CE % 2 == 0 &&//
            PUE % 2 == 0 &&//
            RAM1E % 2 == 0 &&//
            RAM2E % 2 == 0 &&
            MBE % 2 == 0)
            KrBtn.enabled = true;
        else
            KrBtn.enabled = false;

        if (MBE % 2 == 0)
        {
            VideoCardBtn.enabled = true;
            ProcessorBtn.enabled = true;
            CoolerBtn.enabled = true;
            PUBtn.enabled = true;
            RAMBtn.enabled = true;
        }
        else
        {
            VideoCardBtn.enabled = false;
            ProcessorBtn.enabled = false;
            CoolerBtn.enabled = false;
            PUBtn.enabled = false;
            RAMBtn.enabled = false;
        }

        if (KrE % 2 == 0)
        {
            VideoCardBtn.enabled = false;
            ProcessorBtn.enabled = false;
            CoolerBtn.enabled = false;
            PUBtn.enabled = false;
            RAMBtn.enabled = false;
            MBBtn.enabled = false;
        }
        else
        {
            VideoCardBtn.enabled = true;
            ProcessorBtn.enabled = true;
            CoolerBtn.enabled = true;
            PUBtn.enabled = true;
            RAMBtn.enabled = true;
            MBBtn.enabled = true;
        }

        if (VCE % 2 == 0 && //
            PE % 2 == 0 && //
            CE % 2 == 0 &&//
            PUE % 2 == 0 &&//
            RAM1E % 2 == 0 &&//
            RAM2E % 2 == 0 &&
            MBE % 2 == 0)
            PowerButtonButton.enabled = true;
        else
            PowerButtonButton.enabled = false;
    }

    void VideoCardInFunc()
    {
        if (MBE % 2 == 0 && KrE % 2 != 0 && PBE==0)
        {
            Animator m_Animator = VideoCard.GetComponent<Animator>();
            Debug.Log("You have clicked the button!");
            m_Animator.SetTrigger("ButtonClick");
            VCE++;
        }
    }

    void ProcessorFunc()
    {
        if (CE % 2 != 0 && MBE % 2 == 0 && KrE % 2 != 0 && PBE == 0)
        {
            Animator m_Animator = Processor.GetComponent<Animator>();
            Debug.Log("You have clicked the button!");
            m_Animator.SetTrigger("ButtonClick");
            PE++;
        }
    }

    void CoolerFunc()
    {
        if (MBE % 2 == 0 && KrE % 2 != 0 && PBE == 0)
        {
            Animator m_Animator = Cooler.GetComponent<Animator>();
            Debug.Log("You have clicked the button!");
            m_Animator.SetTrigger("ButtonClick");
            CE++;
        }
    }

    void PUFunc()
    {
        if (MBE % 2 == 0 && KrE % 2 != 0 && PBE == 0)
        {
            Animator m_Animator = PU.GetComponent<Animator>();
            Debug.Log("You have clicked the button!");
            m_Animator.SetTrigger("ButtonClick");
            PUE++;
        }
    }
    void RAMFunc()
    {
        if (MBE % 2 == 0 && KrE % 2 != 0 && PBE == 0)
        {
            Animator m_Animator = RAM1.GetComponent<Animator>();
            Debug.Log("You have clicked the button!");
            m_Animator.SetTrigger("ButtonClick");
            RAM1E++;
        }
    }

    void RAM1Func()
    {
        if (MBE % 2 == 0 && KrE % 2 != 0 && PBE == 0)
        {
            Animator m_Animator = RAM2.GetComponent<Animator>();
            Debug.Log("You have clicked the button!");
            m_Animator.SetTrigger("ButtonClick");
            RAM2E++;
        }
    }

    void MBFunc()
    {
        if (VCE % 2 != 0 && //
            PE % 2 != 0 && //
            CE % 2 != 0 &&//
            PUE % 2 != 0 &&//
            RAM1E % 2 != 0 &&//
            RAM2E % 2 != 0 &&
            KrE % 2 != 0 && PBE == 0)
        {
            Animator m_Animator = MB.GetComponent<Animator>();
            Debug.Log("You have clicked the button!");
            m_Animator.SetTrigger("ButtonClick");
            MBE++;
        }
    }

    void KrFunc()
    {
        if (VCE % 2 == 0 && //
            PE % 2 == 0 && //
            CE % 2 == 0 &&//
            PUE % 2 == 0 &&//
            RAM1E % 2 == 0 &&//
            RAM2E % 2 == 0 &&
            MBE % 2 == 0)
        {
            Animator m_Animator = Kr.GetComponent<Animator>();
            Debug.Log("You have clicked the button!");
            m_Animator.SetTrigger("ButtonClick");
            KrE++;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click Received");
    }

    void PowerButtonClick()
    {
        if (VCE % 2 == 0 && //
            PE % 2 == 0 && //
            CE % 2 == 0 &&//
            PUE % 2 == 0 &&//
            RAM1E % 2 == 0 &&//
            RAM2E % 2 == 0 &&
            MBE % 2 == 0)
        {
            Animator m_Animator = Cooler1.GetComponent<Animator>();
            Debug.Log("PC Power Button Clicked");
            m_Animator.SetTrigger("PowerButtonClick");
            timeLeft = 3.0f;
            m_MyAudioSource.Play();
            //PBE++;
        }
    }

    private void PCChangeMaterial()
    {
        if (PBE % 2 != 0)
        {
            if (PBE == 3)
            {
                PBE = 0;
                MeshRender.material = ScreenMaterials[0];
                m_MyAudioSource.Stop();
                return;
            }
            PBE++;
            MeshRender.material = ScreenMaterials[PBE];
            //MBE++;
        }
        else
        {
            PBE++;
            MeshRender.material = ScreenMaterials[PBE];
            //MBE++;
            timeLeft = 3.0f;
        }
    }

}
