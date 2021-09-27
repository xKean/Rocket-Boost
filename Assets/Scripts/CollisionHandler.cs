using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        switch(other.gameObject.tag)
        {
            case "Frienly":
                Debug.Log(other.gameObject.tag);
                break;
            case "Finish":
                Debug.Log(other.gameObject.tag);
                break;
            case "Fuel":
                Debug.Log(other.gameObject.tag);
                break;
            default:
                Debug.Log(other.gameObject.tag);
                break;
        }
    }
}
