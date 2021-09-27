using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    
    [SerializeField] float changeSequenceWait = 1f;
    [SerializeField] AudioClip crashAudio;
    [SerializeField] AudioClip finishAudio;
    Movement movementScript;
    AudioSource audioSource;
    bool isTransitioning = false;
    private void Start() {
        movementScript = GetComponent<Movement>();
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other) 
    {
        if(!isTransitioning){
            switch(other.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log(other.gameObject.tag);
                    break;
                case "Finish":
                    StartFinishSequence();
                    break;
                default:
                    StartCrashSequence();
                    break;
            }
        }
    }

    void StartCrashSequence()
    {
        //todo add particle effect upon crash
            isTransitioning = true ;
            audioSource.Stop();
            audioSource.PlayOneShot(crashAudio);
            movementScript.enabled = false ; 
            Invoke("ReloadLevel", changeSequenceWait);        
    }
    void StartFinishSequence()
    {
        //todo add particle effect upon success
            isTransitioning = true;
            audioSource.Stop();
            audioSource.PlayOneShot(finishAudio);
            movementScript.enabled = false ; 
            Invoke("LoadNextLevel", changeSequenceWait);
    }


    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex +1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings){
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
