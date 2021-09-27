using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    Movement movementScript;
    [SerializeField] float changeSequenceWait = 0.6f;
    private void Start() {
        movementScript = GetComponent<Movement>();
    }
    void OnCollisionEnter(Collision other) 
    {
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

    void StartCrashSequence()
    {
        //todo add SFX upon crash
        //todo add particle effect upon crash
        movementScript.enabled = false ; 
        Invoke("ReloadLevel", changeSequenceWait);
    }
    void StartFinishSequence()
    {
        //todo add SFX upon crash
        //todo add particle effect upon crash
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
