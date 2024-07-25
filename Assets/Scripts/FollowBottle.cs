using UnityEngine;

public class FollowBottle : MonoBehaviour
{
    public GameObject BottleFollow; 
    public Vector3 offset = new Vector3(0, 0, 0); 

    void Start()
    {
        if (BottleFollow == null)
        {
            Debug.LogError("BottleFollow GameObject is not assigned.");
        }
    }

    void Update()
    {
        if (BottleFollow != null)
        {
            transform.position = new Vector3(BottleFollow.transform.position.x, transform.position.y, transform.position.z);

            //transform.LookAt(BottleFollow.transform);
        }
    }
}
