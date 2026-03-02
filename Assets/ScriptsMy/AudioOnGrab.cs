using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class AudioOnGrab : MonoBehaviour
{
    private AudioSource kaskaAudioSource;
    private AudioSource ognetushitelAudioSource;
    private AudioSource spetsobuvAudioSource;
    private AudioSource VRAudioSource;
    private AudioSource raspiratorAudioSource;
    private AudioSource naushniki2MAudioSource;
    private AudioSource whitekaskaAudioSource;
    private AudioSource glovesAudioSource;
    private AudioSource HardKostumAudioSource;
    private AudioSource glovesHardAudioSource;
    private AudioSource glovesEasyAudioSource;
    private AudioSource EasyKostumAudioSource;
    private AudioSource glassesAudioSource;
    private AudioSource naushniki3MAudioSource;
    private AudioSource trapglovesAudioSource;
    private AudioSource kaskaglassnaushAudioSource;
    private AudioSource glovesRezinAudioSource;
    private AudioSource glovesHardRedAudioSource;
    private ParticleSystem ognetushitelParticleSystem;
    private bool isPlaying1;
    private bool isPlaying2;
    private bool isPlaying3;
    private bool isPlaying4;
    private bool isPlaying5;
    private bool isPlaying6;
    private bool isPlaying7;
    private bool isPlaying8;
    private bool isPlaying9;
    private bool isPlaying10;
    private bool isPlaying11;
    private bool isPlaying12;
    private bool isPlaying13;
    private bool isPlaying14;
    private bool isPlaying15;
    private bool isPlaying16;
    private bool isPlaying17;
    private bool isPlaying18;
    public bool koltso;

    private SteamVR_Action_Boolean m_Grip;
    private SteamVR_Behaviour_Pose m_Pose;

    private void Awake()
    {
        m_Grip = SteamVR_Actions._default.GrabGrip;

        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }


    void Start()
    {
        isPlaying1 = false;
        isPlaying2 = false;
        isPlaying3 = false;
        isPlaying4 = false;
        isPlaying5 = false;
        isPlaying6 = false;
        isPlaying7 = false;
        isPlaying8 = false;
        isPlaying9 = false;
        isPlaying10 = false;
        isPlaying11 = false;
        isPlaying12 = false;
        isPlaying13 = false;
        isPlaying14 = false;
        isPlaying15 = false;
        isPlaying16 = false;
        isPlaying17 = false;
        isPlaying18 = false;
        koltso = true;
    }

    void Update()
    {
        Transform kaskaObject = gameObject.transform.Find("kaska");
        if (kaskaObject != null && !isPlaying1) {
            kaskaAudioSource = kaskaObject.GetComponent<AudioSource>();
            kaskaAudioSource.Play();
            isPlaying1 = true;
        }
        else if (kaskaObject == null && isPlaying1)
        {
            kaskaAudioSource.Stop();
            isPlaying1 = false;
        }

        Transform ognetushitelObject = gameObject.transform.Find("ognetushitel");
        if (ognetushitelObject != null && ognetushitelObject.Find("koltso"))
            koltso = true;
        else if (ognetushitelObject != null) koltso = false;

        if (ognetushitelObject != null && !isPlaying2)
        {
            ognetushitelAudioSource = ognetushitelObject.GetComponent<AudioSource>();
            ognetushitelParticleSystem = ognetushitelObject.transform.Find("Particle System").GetComponent<ParticleSystem>();
            ognetushitelAudioSource.Play();
            isPlaying2 = true;
        }
        else if (ognetushitelObject != null && m_Grip.GetStateDown(m_Pose.inputSource) && koltso)
        {
            koltso = false;
            Destroy(ognetushitelObject.transform.Find("koltso").gameObject);
        }
        else if (ognetushitelObject != null && m_Grip.GetStateDown(m_Pose.inputSource) && !koltso)
        {
            GameObject ParticleSystem = ognetushitelObject.Find("Particle System").gameObject;
            ParticleSystem.SetActive(true);
            ParticleSystem.GetComponent<ParticleSystem>().Play();
        }
        else if (ognetushitelObject != null && m_Grip.GetStateUp(m_Pose.inputSource) && !koltso)
        {
            GameObject ParticleSystem = ognetushitelObject.transform.Find("Particle System").gameObject;
            ParticleSystem.GetComponent<ParticleSystem>().Stop(false);
        }
        else if (ognetushitelObject == null && isPlaying2)
        {
            ognetushitelAudioSource.Stop();
            ognetushitelParticleSystem.Stop(false);
            isPlaying2 = false;
        }

        Transform spetsobuvlObject = gameObject.transform.Find("spetsobuv");
        if (spetsobuvlObject != null && !isPlaying3)
        {
            spetsobuvAudioSource = spetsobuvlObject.GetComponent<AudioSource>();
            spetsobuvAudioSource.Play();
            isPlaying3 = true;
        }
        else if (spetsobuvlObject == null && isPlaying3)
        {
            spetsobuvAudioSource.Stop();
            isPlaying3 = false;
        }

        Transform VRObject = gameObject.transform.Find("VROch");
        if (VRObject != null && !isPlaying4)
        {
            VRAudioSource = VRObject.GetComponent<AudioSource>();
            VRAudioSource.Play();
            isPlaying4 = true;
        }
        else if (VRObject == null && isPlaying4)
        {
            VRAudioSource.Stop();
            isPlaying4 = false;
        }

        Transform raspiratorObject = gameObject.transform.Find("respirator");
        if (raspiratorObject != null && !isPlaying5)
        {
            raspiratorAudioSource = raspiratorObject.GetComponent<AudioSource>();
            raspiratorAudioSource.Play();
            isPlaying5 = true;
        }
        else if (raspiratorObject == null && isPlaying5)
        {
            raspiratorAudioSource.Stop();
            isPlaying5 = false;
        }

        Transform naushniki2MObject = gameObject.transform.Find("naushniki2M");
        if (naushniki2MObject != null && !isPlaying6)
        {
            naushniki2MAudioSource = naushniki2MObject.GetComponent<AudioSource>();
            naushniki2MAudioSource.Play();
            isPlaying6 = true;
        }
        else if (naushniki2MObject == null && isPlaying6)
        {
            naushniki2MAudioSource.Stop();
            isPlaying6 = false;
        }

        Transform whitekaskaObject = gameObject.transform.Find("maska1");
        if (whitekaskaObject != null && !isPlaying7)
        {
            whitekaskaAudioSource = whitekaskaObject.GetComponent<AudioSource>();
            whitekaskaAudioSource.Play();
            isPlaying7 = true;
        }
        else if (whitekaskaObject == null && isPlaying7)
        {
            whitekaskaAudioSource.Stop();
            isPlaying7 = false;
        }

        Transform glovesObject = gameObject.transform.Find("Gloves");
        if (glovesObject != null && !isPlaying8)
        {
            glovesAudioSource = glovesObject.GetComponent<AudioSource>();
            glovesAudioSource.Play();
            isPlaying8 = true;
        }
        else if (glovesObject == null && isPlaying8)
        {
            glovesAudioSource.Stop();
            isPlaying8 = false;
        }

        Transform hardKostumObject = gameObject.transform.Find("HardKostum");
        if (hardKostumObject != null && !isPlaying9)
        {
            HardKostumAudioSource = hardKostumObject.GetComponent<AudioSource>();
            HardKostumAudioSource.Play();
            isPlaying9 = true;
        }
        else if (hardKostumObject == null && isPlaying9)
        {
            HardKostumAudioSource.Stop();
            isPlaying9 = false;
        }

        Transform glovesHardObject = gameObject.transform.Find("glovesHard");
        if (glovesHardObject != null && !isPlaying10)
        {
            glovesHardAudioSource = glovesHardObject.GetComponent<AudioSource>();
            glovesHardAudioSource.Play();
            isPlaying10 = true;
        }
        else if (glovesHardObject == null && isPlaying10)
        {
            glovesHardAudioSource.Stop();
            isPlaying10 = false;
        }

        Transform easyGlovesObject = gameObject.transform.Find("EasyGloves");
        if (easyGlovesObject != null && !isPlaying11)
        {
            glovesEasyAudioSource = easyGlovesObject.GetComponent<AudioSource>();
            glovesEasyAudioSource.Play();
            isPlaying11 = true;
        }
        else if (easyGlovesObject == null && isPlaying11)
        {
            glovesEasyAudioSource.Stop();
            isPlaying11 = false;
        }

        Transform easyKostumObject = gameObject.transform.Find("EasyKostum");
        if (easyKostumObject != null && !isPlaying12)
        {
            EasyKostumAudioSource = easyKostumObject.GetComponent<AudioSource>();
            EasyKostumAudioSource.Play();
            isPlaying12 = true;
        }
        else if (easyKostumObject == null && isPlaying12)
        {
            EasyKostumAudioSource.Stop();
            isPlaying12 = false;
        }

        Transform glassesObject = gameObject.transform.Find("glasses");
        if (glassesObject != null && !isPlaying13)
        {
            glassesAudioSource = glassesObject.GetComponent<AudioSource>();
            glassesAudioSource.Play();
            isPlaying13 = true;
        }
        else if (glassesObject == null && isPlaying13)
        {
            glassesAudioSource.Stop();
            isPlaying13 = false;
        }

        Transform naushniki3MObject = gameObject.transform.Find("naushniki3M");
        if (naushniki3MObject != null && !isPlaying14)
        {
            naushniki3MAudioSource = naushniki3MObject.GetComponent<AudioSource>();
            naushniki3MAudioSource.Play();
            isPlaying14 = true;
        }
        else if (naushniki3MObject == null && isPlaying14)
        {
            naushniki3MAudioSource.Stop();
            isPlaying14 = false;
        }

        Transform trapGlovesObject = gameObject.transform.Find("trapgloves");
        if (trapGlovesObject != null && !isPlaying15)
        {
            trapglovesAudioSource = trapGlovesObject.GetComponent<AudioSource>();
            trapglovesAudioSource.Play();
            isPlaying15 = true;
        }
        else if (trapGlovesObject == null && isPlaying15)
        {
            trapglovesAudioSource.Stop();
            isPlaying15 = false;
        }

        Transform kaskaglassnaushObject = gameObject.transform.Find("kaskaglassnaush");
        if (kaskaglassnaushObject != null && !isPlaying16)
        {
            kaskaglassnaushAudioSource = kaskaglassnaushObject.GetComponent<AudioSource>();
            kaskaglassnaushAudioSource.Play();
            isPlaying16 = true;
        }
        else if (kaskaglassnaushObject == null && isPlaying16)
        {
            kaskaglassnaushAudioSource.Stop();
            isPlaying16 = false;
        }

        Transform glovesRezinObject = gameObject.transform.Find("GlovesRezin");
        if (glovesRezinObject != null && !isPlaying17)
        {
            glovesRezinAudioSource = glovesRezinObject.GetComponent<AudioSource>();
            glovesRezinAudioSource.Play();
            isPlaying17 = true;
        }
        else if (glovesRezinObject == null && isPlaying17)
        {
            glovesRezinAudioSource.Stop();
            isPlaying17 = false;
        }

        Transform glovesHardRedObject = gameObject.transform.Find("glovesHardRed");
        if (glovesHardRedObject != null && !isPlaying18)
        {
            glovesHardRedAudioSource = glovesHardRedObject.GetComponent<AudioSource>();
            glovesHardRedAudioSource.Play();
            isPlaying18 = true;
        }
        else if (glovesHardRedObject == null && isPlaying18)
        {
            glovesHardRedAudioSource.Stop();
            isPlaying18 = false;
        }
    }
}
