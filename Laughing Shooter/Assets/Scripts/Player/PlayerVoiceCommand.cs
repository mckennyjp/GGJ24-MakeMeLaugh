using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlayerVoiceCommand : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public ParticleSystem muzzleFlash;
    private PlayerStats stats;
    
    [SerializeField] private AudioSource healSound;
    [SerializeField] private AudioSource gunSound;

    public Camera fpscam;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
        actions.Add("ha", Ha);
        actions.Add("he", He);

        stats = GetComponent<PlayerStats>();

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            stats.Heal(20f);
            healSound.Play();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Shoot();
        }
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }
    private void Ha()
    {
        Shoot();
    }

    private void He()
    {
        stats.Heal(20f);
        healSound.Play();
        
    }

    private void Shoot()
    {
        gunSound.Play();
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }


}
