using Unity.XR.CoreUtils;
using UnityEngine;

public class ARMazeMovement : MonoBehaviour
{
    public GameObject playerCube;         
    public float movementSpeed = 15f;     
    private XROrigin xrOrigin;           
    private Camera xrCamera;             
    private GameObject cameraOffset;     
    private bool isCollidingWithWall = false;
    private Vector3[] myNum;
    private int i = 0;
    private Vector3 lastValidPosition; 
    private Vector3 initialPosition; 

    void Start()
    {
        initialPosition = playerCube.transform.position;
        InitializeCamera();
    }

    void Update()
    {
        // Check if the xrCamera reference is still valid
        if (xrCamera == null)
        {
            Debug.LogWarning("Camera not found, trying to reinitialize.");
            InitializeCamera();
            if (xrCamera == null)
            {
                return; 
            }
        }

        lastValidPosition = xrOrigin.transform.position;

        if (i == 0)
        {
            i = 1;
            myNum[i] = lastValidPosition;
        }
        else
        {
            i = 0;
            myNum[i] = lastValidPosition;
        }

        // Get the camera's pitch angle (X axis rotation)
        float pitch = xrCamera.transform.rotation.eulerAngles.x;

        // Normalize the pitch value to the -180 to 180 range (to detect if the camera looks down)
        if (pitch > 180) pitch -= 360;

        float tiltThreshold = 10f; 
        if (pitch > tiltThreshold)  // Looking down condition
        {
            Vector3 forwardDirection = new Vector3(xrCamera.transform.forward.x, 0, xrCamera.transform.forward.z).normalized;

            Vector3 nextPosition = playerCube.transform.position + forwardDirection * movementSpeed * Time.deltaTime;

            // Check if the predicted position is inside a wall
            if (!IsInsideWall(nextPosition)) // Only move if it's valid
            {
                playerCube.transform.position = nextPosition;
                xrOrigin.transform.position = nextPosition; 
            }
        }
    }

    void InitializeCamera()
    {
        // Get the XROrigin component from the scene (ensure this GameObject exists)
        xrOrigin = FindObjectOfType<XROrigin>(); // If it's in the scene, find it dynamically

        // Check if xrOrigin is found
        if (xrOrigin != null)
        {
            // Now find the Camera Offset GameObject, which should be a child of XROrigin
            cameraOffset = xrOrigin.transform.Find("Camera Offset")?.gameObject;

            if (cameraOffset != null)
            {
                // Get the Camera component from the Camera Offset GameObject
                xrCamera = cameraOffset.GetComponentInChildren<Camera>();

                if (xrCamera == null)
                {
                    Debug.LogError("Camera not found in Camera Offset.");
                }
            }
            else
            {
                Debug.LogError("Camera Offset not found in the XROrigin. Please check the hierarchy.");
            }
        }
        else
        {
            Debug.LogError("XROrigin not found in the scene!");
        }

        // Initialize the positions array and set the last valid position
        myNum = new Vector3[2];
        lastValidPosition = xrOrigin.transform.position;
        myNum[i] = lastValidPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("camera"))
        {
            isCollidingWithWall = true;

            // Reset the position to the last valid position
            xrOrigin.transform.position = myNum[1];
            if (lastValidPosition == myNum[1])
            {
                xrOrigin.transform.position = myNum[0];
            }
        }
    }

    private bool IsInsideWall(Vector3 position)
    {
        float detectionRadius = 0.5f; // Adjust this based on your needs
        Collider[] colliders = Physics.OverlapSphere(position, detectionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Walls"))
            {
                return true;
            }
        }
        return false; 
    }
    public void ResetPlayerPosition()
    {
        // Reset the player position to the initial position
        playerCube.transform.position = initialPosition;
    }
}
