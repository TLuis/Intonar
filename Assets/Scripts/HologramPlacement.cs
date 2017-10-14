using UnityEngine;

public class HologramPlacement : MonoBehaviour
{
    public enum Mode
    {
        FIXED, 
        MOVING,
        ROTATING
    };

    public enum Axis
    {
        ALL, X, Y, Z
    };

    public Mode currentMode = Mode.FIXED;
    public Axis axis = Axis.ALL;
    public Vector3 initialPosHolgram;
    public Quaternion initialRotationHologram; 
    public Vector3 initialPosCamera;
    public Quaternion initialRotationCamera;
    public GameObject cameraObj;

    /*
    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        // TODO toggle placement mode
        if(currentMode == Mode.FIXED)
        {
            currentMode = Mode.MOVING;
            initialPosHolgram = this.transform.localPosition;
            initialRotationHologram = this.transform.rotation;
            initialPosCamera = cameraObj.transform.localPosition;
            initialRotationCamera = cameraObj.transform.rotation;
        } else if(currentMode == Mode.MOVING)
        {
            currentMode = Mode.FIXED;
        } else
        {
            Debug.LogError("Unknown placement mode!");
        }
    }
    */

    void OnFix()
    {
        currentMode = Mode.FIXED;
    }

    void OnMoving(Axis axis)
    {
        this.axis = axis;
        currentMode = Mode.MOVING;
        initialPosHolgram = this.transform.localPosition;
        initialPosCamera = cameraObj.transform.localPosition;
    }

    void OnRotating()
    {
        currentMode = Mode.ROTATING;
    }

    private void Update()
    {
        if (currentMode == Mode.FIXED)
        {

        } else if (currentMode == Mode.MOVING)
        {
            this.transform.localPosition = initialPosHolgram + (cameraObj.transform.localPosition - initialPosCamera);
        } else if (currentMode == Mode.ROTATING)
        {
            float cameraRotation = cameraObj.transform.localRotation.eulerAngles.y;
            float initialCameraRotation = initialRotationCamera.eulerAngles.y;
            float rotateHologramAngle = cameraRotation - initialCameraRotation;
            Quaternion rotation = Quaternion.Euler(0.0f, rotateHologramAngle, 0.0f);
            this.transform.localRotation = rotation * initialRotationHologram;
        } else 
        {
            Debug.LogError("Unknown placement mode!");
        }
    }
}