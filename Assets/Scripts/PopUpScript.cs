using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpScript : MonoBehaviour
{
    [Header("Click Functions")]
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;

    [Header("Random Fuctions")]
    private Vector2 min;
    private Vector2 max;
    private float xPos;
    private float yPos;
    public Vector2 newPosition;
    
    [Header("Pop Up Functions")]
    private bool shouldPopUp;
    private bool stayOnScreen;    
    public float MaxPopUpTimer;
    public float currentPopUpTimer;
    private Vector3 originalScale;
    
    
    private bool isScaling;
    
    
    
    void Start()
    {
       SetRanges();
       shouldPopUp = false;
       stayOnScreen = false;
       currentPopUpTimer = MaxPopUpTimer;
       //originalScale = gameObject.transform.localScale;
       originalScale = new Vector3(0,0,0);
       isScaling = false;

    }

    
    void Update()
    {
        xPos = Random.Range(min.x, max.x);
        yPos = Random.Range(min.y, max.y);
        
        if (stayOnScreen == false)
        {
            currentPopUpTimer = currentPopUpTimer - 0.5f * Time.deltaTime;
            
        
        }
        
        //Code that randomly sets the Ad to appear on screen
        if (currentPopUpTimer <= 0)
        {
            shouldPopUp = true;
            stayOnScreen = true;
            currentPopUpTimer = MaxPopUpTimer;
            gameObject.transform.localScale = originalScale;
            StartCoroutine(scaleOverTime(gameObject.transform, new Vector3(0.8f, 0.8f, 0), 5));

        }

        if (shouldPopUp)
        {
            newPosition = new Vector2(xPos,yPos);
            this.gameObject.transform.position = newPosition;
            shouldPopUp = false;
        }
        
        //Code that moves the pop up ad.
        if (isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            //Convert screen point of mouse to be exclusive to the game world
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            //Code that changes its transform when being dragged by Mouse
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX,mousePos.y - startPosY,0);
            //Decrease time and size once clicked on.
            stayOnScreen = false;
            StartCoroutine(scaleOverTime(gameObject.transform, new Vector3(0, 0, 0), currentPopUpTimer));
            
        }
        
        
    }
    
    private void SetRanges()
    {
        min = new Vector2(-7, 0.2f); //Random value.
        max = new Vector2(8, 4); //Another ramdon value, just for the example.
    }

    

    IEnumerator scaleOverTime(Transform objectToScale, Vector3 toScale, float duration)
    {
        //Make sure there is only one instance of this function running
        if (isScaling)
        {
            yield break; //exit if this is still running
        }
        isScaling = true;

        float counter = 0;

        //Get the current scale of the object to be moved
        Vector3 startScaleSize = objectToScale.localScale;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            objectToScale.localScale = Vector3.Lerp(startScaleSize, toScale, counter/duration );
            yield return null;
        }

        isScaling = false;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            //Convert screen point of mouse to be exclusive to the game world
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            
            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;  
        }
       
    }

    private void OnMouseUp()
    {
        
        isBeingHeld = false;
    }
}
