using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Striker : MonoBehaviour
{
    public Transform target; // Reference to the target object
    public LineRenderer aimLine; // Line renderer to visualize aiming
    public Slider forceSlider; // Slider to control the shooting force
    public float maxForce = -20f; // Maximum shooting force
    public LayerMask board;
    public bool rayactive = true;
    public Transform pos;
    public float mouseX;
    public float shootingForce;

    RaycastHit hit;
    //int raycastDistance = 10;
    [SerializeField] LayerMask layerMask;

    public StrikerPosition switch2;


    public float minValue = 0f;
    public float maxValue = 50f;
    public float lerpSpeed = .2f;
    public GameController gameCon;
    public int currentIndex;

    private Coroutine lerpCoroutine;
    public bool forceApplied;

    RaycastHit hitX;

    private void Start()
    {
        aimLine.enabled = false; // Disable the aim line renderer initially
        forceSlider.value = 0f;
        forceApplied = false;
        GameObject scriptToDisableObject = GameObject.Find("Stricker");

        switch2 = scriptToDisableObject.GetComponent<StrikerPosition>();

        lerpCoroutine = StartCoroutine(LerpSlider());
    }

    private void Update()
    {

        currentIndex = gameCon.playerIndex;
        if (Input.GetKeyDown(KeyCode.F))
        {
            switch2.DisableScript();
            aimLine.enabled = true; // Enable aim line renderer
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            switch2.DisableScript3();
            aimLine.enabled = false; // Enable aim line renderer
        }
        if ((forceSlider.value >= 0))
        {
            if (rayactive)
            {
                if (Input.GetMouseButton(0))
                {
                    aimLine.enabled = true;
                    //aimLine.enabled = true; // Enable aim line renderer

                    Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if(Physics.Raycast(r, out hitX, Mathf.Infinity, layerMask))
                    {
                        aimLine.SetPosition(0, transform.position); 
                        aimLine.SetPosition(1, hitX.point);
                    }
                    else
                    {
                        aimLine.enabled = false;    
                    }
                    // we need striker position?
                   
                    
                    Vector3 direction = hitX.point - transform.position;
                    Debug.DrawLine(transform.position, transform.position + direction, Color.red);
                    transform.rotation = Quaternion.LookRotation(direction);
                    //if (Physics.Raycast(transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, layerMask))
                    //{
                    //    Vector3 direction = hit.point - transform.position;
                    //    direction.y = 0f;

                    //    aimLine.SetPositions(new Vector3[] { transform.position, transform.position + direction });

                    //    transform.rotation = Quaternion.LookRotation(direction);
                    //}

                }

                if (Input.GetMouseButtonUp(0))
                {
                    shootingForce = forceSlider.value + maxForce;
                    aimLine.enabled = false;
                }
            }
        }
        //rayactive = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * shootingForce, ForceMode.Impulse);
            rayactive = true;
            aimLine.enabled = false;
            forceSlider.value = 0f;
            //Debug.Log("ggsdfgh");
            SetPlayerTurns();
            forceApplied = true;    
        }
    }


    private IEnumerator LerpSlider()
    {
        float t = 0f;
        float currentValue = minValue;
        float targetValue = maxValue;

        while (true)
        {
            currentValue = Mathf.Lerp(minValue, maxValue, t);
            forceSlider.value = currentValue;

            t += Time.deltaTime * lerpSpeed;

            if (t >= 1f)
            {
                float temp = minValue;
                minValue = maxValue;
                maxValue = temp;

                t = 0f;
            }

            yield return null;
        }
    }

    void SetPlayerTurns()
    {
        if (currentIndex == 1 && gameCon.isPlayer1Turn)
        {
            Debug.Log("xchbfdh");
            gameCon.isPlayer1Turn = false;
            gameCon.playerIndex = 2;
            //gameCon.noOfPlayer1Turns--;
            //if (gameCon.noOfPlayer1Turns == 0 && gameCon.noOfPlayer2Turns == 0)
            //{
              //  gameCon.noOfPlayer2Turns++;
               // gameCon.playerIndex = 2;
                //gameCon.isPlayer1Turn = false;
                
            //}
        }
        if (currentIndex == 2 && !gameCon.isPlayer1Turn)
        {
            Debug.Log("dfhh");
            gameCon.isPlayer1Turn = true;
            gameCon.playerIndex = 1;
            //    gameCon.noOfPlayer2Turns--;
            //    if (gameCon.noOfPlayer2Turns == 0 && gameCon.noOfPlayer1Turns == 0)
            //    {
            //        gameCon.noOfPlayer1Turns++;
            //        gameCon.playerIndex = 1;
            //        gameCon.isPlayer1Turn = true;
            //    }
            //}
        }
    }
}
        
        
    
        /*if (rayactive) 
        {   
            // Check for mouse input to control aiming
            if (Input.GetMouseButton(0))
            {
                aimLine.enabled = true; // Enable aim line renderer

                // Raycast from the camera to determine the aiming direction
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Vector3 direction = hit.point - transform.position;
                    direction.y = 0f; // Ignore the y-axis component

                    // Update the aim line renderer positions
                    aimLine.SetPositions(new Vector3[] { transform.position, transform.position + direction });

                    // Rotate the striker to aim towards the target
                    transform.rotation = Quaternion.LookRotation(direction);
                    if (Input.GetMouseButtonUp(0))
                    {
                        rayactive= false;
                    }
                }
            else
            {
                aimLine.enabled = false; // Disable aim line renderer
            }
        

        }
        if (rayactive)
        {
            aimLine.enabled = true;

            mouseX= Input.mousePosition.x;

        }

            else
            {
                aimLine.enabled = false; // Disable aim line renderer
            }
        

        // Adjust shooting force based on the UI slider value
        float shootingForce = forceSlider.value + maxForce ;

        // Check for mouse button release to shoot the striker
        if ((forceSlider.value >0)&&(Input.GetKey(KeyCode.Space)))
        {
            // Apply the shooting force to shoot the striker
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * shootingForce, ForceMode.Impulse);
            rayactive = true;

        }*/
    

