using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARSubsystems;
using System;

public class TransformMaze : MonoBehaviour
{
    public Transform objectToPlace;
    public GameObject placementIndicator;

    private ARRaycastManager arOrigin;
    private ARRaycastManager arRaycast;
    private Pose placementPose;
    private bool placementPoseIsValid = false;

    private bool canTransform;
    private GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        arOrigin = FindObjectOfType<ARRaycastManager>();
        arRaycast = arOrigin.GetComponent<ARRaycastManager>();
        canTransform = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Only when the transform button has been pressed
        if (canTransform)
        {
            UpdatePlacementPose();
            UpdatePlacementIndicator();

            if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                canTransform = false;
                placementIndicator.SetActive(false);
                PlaceObject();
                canvas = GameObject.Find("Canvas");
                canvas.transform.GetChild(0).gameObject.SetActive(true);
                canvas.transform.GetChild(2).gameObject.SetActive(true);
            }
        }
    }

    private void PlaceObject()
    {
        objectToPlace.position = placementPose.position;
        objectToPlace.rotation = placementPose.rotation;
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arRaycast.Raycast(screenCenter, hits, TrackableType.FeaturePoint);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }

    public void OnTransformButtonPress()
    {
        canTransform = true;
    }
}
