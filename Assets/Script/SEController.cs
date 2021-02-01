using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1ゲーム内で何回も鳴るSE用スクリプト

public class SEController : MonoBehaviour
{

    PlayerParamClass
    paramClass = PlayerParamClass.GetInstance();

    private bool[] seBool = new bool[4];

    [Range(0.0f, 1.0f)]
    public float
        vol = 0.1f;
    public bool
        mute = false;

    [SerializeField]
    private float
        delay = 0.1f;

    public AudioClip Jump_SE;
    public AudioClip Slide_SE;
    public AudioClip Run_SE;
    public AudioClip Dmg_SE;
    public Animator Anm;

    bool a =false;
    bool b = false;
    bool c = false;

    AudioSource SoundEffecter;

    GameObject Player;
    Anim_Con script;
    int run;
    void Start()
    { 
        SoundEffecter = gameObject.AddComponent<AudioSource>();
        Player = GameObject.Find("Player");
        script = Player.GetComponent<Anim_Con>();
    }
    void FixedUpdate()
    {
        a = Anm.GetBool("Runs");
        b = Anm.GetBool("Jump");
        c = Anm.GetBool("Sliding");

       run = script.Run + 1;
    }
    void Update()
    {

        if (paramClass.playerSpeed != 0 && paramClass.isGround && !SoundEffecter.isPlaying)
        {
            SoundEffecter.clip = Run_SE;
            SoundEffecter.PlayScheduled(delay);
            SoundEffecter.SetScheduledEndTime(AudioSettings.dspTime + Run_SE.length / run + delay);
        }
        else if (b)
        {
            SoundEffecter.clip = Jump_SE;
            SoundEffecter.PlayScheduled(delay);
            SoundEffecter.SetScheduledEndTime(AudioSettings.dspTime + Jump_SE.length + delay);
        }
        else if (c)
        {
            SoundEffecter.clip = Slide_SE;
            SoundEffecter.PlayScheduled(delay);
            SoundEffecter.SetScheduledEndTime(AudioSettings.dspTime + Slide_SE.length + delay);
        }

        SoundEffecter.mute = mute;
        SoundEffecter.volume = vol;
    }

    public void DamageSE()
    {
        SoundEffecter.PlayOneShot(Dmg_SE);
        SoundEffecter.mute = mute;
        SoundEffecter.volume = vol;
    }

}
