using System.Collections;
using UnityEngine;

public class BikeMove : MonoBehaviour
{
    public Transform targetPosition;
    public float speed = 2;
    private bool startMoving;

    private void Start()
    {
        startMoving = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (startMoving) return;
        if (transform.position == targetPosition.position) return;
        
        Debug.Log("bike moved");
        if (collision.gameObject.CompareTag("Bottle"))
        {
            startMoving = true;
            SoundManager.instance.CarSound();
            StartCoroutine(MoveOverTime(2.5f));
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bottle"))
        {
            Debug.Log("Collision Exit");
            //collision.gameObject.transform.parent = null;
            //BottleScript1.isMoving = false;
        }
    }

    private IEnumerator MoveOverTime(float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition.position; 
    }
}
