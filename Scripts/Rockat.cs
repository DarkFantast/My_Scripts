using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//using UnityStandardAssets.CrossPlatformInput;   
using UnityEngine.Monetization;                 // реклама
using UnityEngine.Advertisements;               // реклама
public class Rockat : MonoBehaviour
{
    public float rotSeed = 170f;
    public float flySeed = 1550f;
    public AudioClip flySound;
    public AudioClip boomSound;
    public AudioClip winSound;
    public ParticleSystem flyParticle;
    public ParticleSystem boomParticle;
    public ParticleSystem winParticle;
    bool collisionOff = false;
    Rigidbody rigidBody;
    AudioSource audioSource;
    enum State {Playing, Dead, NextLevel};

    private static int advCount = 0;  // реклама
    //private bool funcDone;




    //сетка уровней
    public static Rockat instance = null;
    int sceneIndex;
    int levelComplete;

    



    //новый код под движение на андроид
    public float horizontalSpeed;
    float speedX;
    public float jumpSpeed;
    float speedY;
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject jumpButton;
    public GameObject pauseButton;
    public GameObject PanelLose;



    State state = State.Playing;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Playing;
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        leftButton.SetActive(true);
        rightButton.SetActive(true);
        jumpButton.SetActive(true);
        pauseButton.SetActive(true);
        PanelLose.SetActive(false);

        if (Advertisement.isSupported)     // реклама
        {
            Advertisement.Initialize("3384943", false);
        }
        

        //сетка уровней
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        if (instance == null)
        {
            instance = this;
        }
    }

    public void isEndGame()  //сетка уровней загрузка меню после последнего уровня
    {
        if (sceneIndex == 80) //максимальный уровень
        {
            Invoke("LoadFirstLevel",2f);
        }
        else
        {
            if (levelComplete < sceneIndex)
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
                Invoke("LoadNextLevel", 2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(state == State.Playing)
       {
       Launch();
       Rotation();
       }
       if(Debug.isDebugBuild)
       {
       DebugKeys();
       }

    }

    void DebugKeys()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            collisionOff = !collisionOff;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(state == State.Dead || state == State.NextLevel || collisionOff)
        {
            return;
        }
        switch(collision.gameObject.tag)
        {
            case "Frandly":
             print("OK");
            break;

            case "Finish":
            Win();
            break;

            case "Battery":
             print("PlusEnergy");
            break;

            default:
            Lose();
            break;
        }
    }
    void Win()
    {
            state = State.NextLevel;
            audioSource.Stop();
            audioSource.PlayOneShot(winSound);
            winParticle.Play();
            flyParticle.Stop();
            leftButton.SetActive(false);
            rightButton.SetActive(false);
            jumpButton.SetActive(false);
            pauseButton.SetActive(false);
             //Invoke("LoadNextLevel", 2f); 
            //SceneManager.LoadScene(Random.Range(18, SceneManager.sceneCount)); //рандом уровней после победы


            Rockat.instance.isEndGame(); //сетка уровней
    }
    void Lose()
    {
            state = State.Dead;
            audioSource.Stop();
            audioSource.PlayOneShot(boomSound);
            boomParticle.Play();
            flyParticle.Stop();
             print("BOOM!");
             //Invoke("LoadFirstLevel", 2f);
             leftButton.SetActive(false);
             rightButton.SetActive(false);
             jumpButton.SetActive(false);
             pauseButton.SetActive(false);
             PanelLose.SetActive(true);
        
            //funcDone = true;
        advCount++;                                         // реклама
        if (Advertisement.IsReady() && advCount %5 == 0)
           Advertisement.Show("video");
    }

    void LoadNextLevel() // Finish
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex + 1;

        if(nextLevelIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextLevelIndex = 1;
        }

        SceneManager.LoadScene(nextLevelIndex);

       //SceneManager.LoadScene(Random.Range(25, SceneManager.sceneCount));
    }

    public void LoadFirstLevel() // Lose
    {
        SceneManager.LoadScene(0);
    }

    public void Launch()  
    {
       if(Input.GetKey(KeyCode.Space))                                                
        {
            rigidBody.AddRelativeForce(Vector3.up * flySeed * Time.deltaTime);
            if(audioSource.isPlaying == false)
            audioSource.PlayOneShot(flySound);
            flyParticle.Play();
        }
        else
        {
            audioSource.Stop();
           // flyParticle.Stop();
        }
    }
    
    void Rotation()
    {
        float rotationSeed = rotSeed * Time.deltaTime;
        rigidBody.freezeRotation = true;

        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSeed);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationSeed);
        }
        rigidBody.freezeRotation = false;

    }


    //новый код под управление на андроид
    public void LeftButtonDown()
    {
        speedX = -horizontalSpeed;
    }
    public void RightButtonDown()
    {
        speedX = horizontalSpeed;
    }
    public void Stop()
    {
        speedX = 0;
    }
    
    void FixedUpdate()
    {
        transform.Translate(speedX, 0, 0);
        flyParticle.Play();

    }
    public void UpButtonDown()
    {
        speedY = jumpSpeed;
        rigidBody.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
    }
    public void ButtonRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
