using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BottleScript : MonoBehaviour
{
    //public GameObject Bottle;
    public float forceAmount = 2.5f; 
    public float xMovementAmount = 2.5f;
    public float rotationSpeed = 360f;
    private int clickCount = 0;     
    private bool isGrounded = false;
    private bool isRotating = false;
    private float rotationStartTime; 
    private bool gameWon;
    private Quaternion startRotation; 
    public GameObject WinningPartcals;
    Rigidbody rb;
    BoxCollider boxCollider;

    public ScoreManager scoreManager1;
    public  UiHanadler UiHandler;
    public SoundManager soundManager1;
    public GameObject Bottle;
    public GameObject BrokenBottle;
    public GameObject TrailRandere;

    public bool isMoving;

    void Start()
    {
        gameWon = false;
        isMoving = true;
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (!isMoving)
        {
            if (!isGrounded && rb.velocity.y < 0 && !isRotating)
            {
                transform.rotation = Quaternion.identity;
                //isLanding = true;
                //StartCoroutine(Landing());

                //transform.rotation = Quaternion.Lerp(startRotation, Quaternion.identity, rotationStartTime);
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    if (isGrounded || clickCount < 2)
                    {
                        clickCount++;
                        if (clickCount == 1 && !isRotating)
                        {
                            ApplyForce(Vector3.up * forceAmount, Vector3.right * xMovementAmount);
                            StartRotation();
                            soundManager1.BottleJumpSound();
                        }
                        else if (clickCount == 2)
                        {
                            ApplyForce(Vector3.up * forceAmount, Vector3.right * xMovementAmount);
                            StartRotation();
                            soundManager1.BottleJumpSound();

                        }
                    }
                }
            }
        }

        if (isRotating)
        {
            // Update the rotation
            float elapsedTime = Time.time - rotationStartTime;
            float rotationAmount = elapsedTime * rotationSpeed;

            if (rotationAmount >= 360f)
            {
                rotationAmount = 360f; 
                isRotating = false;   
            }

            transform.rotation = startRotation * Quaternion.Euler(0, 0, -rotationAmount);
        }
    }

    public void PlayGame()
    {
        isMoving = false;
        UiHandler.MainMainScreen();
    }

    private IEnumerator Landing()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = new Quaternion(0, 0, 1, 1);
        float progress = 0;

        while (progress < 1)
        {
            progress += Time.deltaTime * 10;
            transform.rotation = Quaternion.Lerp(startRotation, Quaternion.identity, progress);
            
            yield return null;
        }

        yield break;
    }

    void ApplyForce(Vector3 forceUpward, Vector3 forceX)
    {
        if (rb != null)
        {
            rb.velocity = Vector3.zero;  
            rb.AddForce(forceUpward, ForceMode.Impulse);
            rb.AddForce(forceX, ForceMode.Impulse);
        }
    }

    void StartRotation()
    {
        if (clickCount == 2)
            startRotation = transform.rotation;
        else 
            startRotation = Quaternion.identity; 
        rotationStartTime = Time.time;
        isRotating = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (gameWon) return;

        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            isGrounded = true;
            clickCount = 0;  
            transform.rotation = Quaternion.identity;
            rb.velocity = Vector3.zero;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("gameOver");
            isMoving = true;
            UiHandler.GameOver();
            TrailRandere.SetActive(false);
            Bottle.SetActive(false);
            BrokenBottle.SetActive(true);
            soundManager1.BottleBreakSound();
            rb.isKinematic = true;
            boxCollider.enabled = false;
            transform.parent = null;
            return;
        }

        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(collision.gameObject.transform, true);
        }
        else
        {
            transform.parent = null;
        }
       
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("WinningCollider"))
        {
            WinningPartcals.SetActive(true);
            UiHandler.LevelComScreen();
            soundManager1.LevelCompSound();
            isMoving = true;
            gameWon = true;
            return;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Coins"))
        {
            scoreManager1.CoinsCollect();
            soundManager1.CoinsSound();
           Destroy(other.gameObject);
           
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            transform.rotation = Quaternion.identity;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            isGrounded = false;
        }
       
    }
}
