﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 20f)]
    private float m_speedFactor;

    [SerializeField]
    private Camera m_camera;

    [SerializeField]
    [Range(0.01f, 0.8f)]
    private float m_touchBound;

    void Start()
    {
        m_camera = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount <= 0)
            return;

        Ray ray = m_camera.ScreenPointToRay(Input.GetTouch(0).position);
        Plane plane = new Plane(Vector3.up, transform.position);
        float distance = 0f;
        
        if (plane.Raycast(ray, out distance))
        {
            Vector3 movement = Vector3.zero;

            float touchX = ray.GetPoint(distance).x;
            float skewerX = transform.position.x;

            movement.x = GetHorizontalDirection(touchX, skewerX) * Mathf.Abs(touchX-skewerX) * m_speedFactor * Time.deltaTime;

            gameObject.transform.position += movement;
        }
	}

    float GetHorizontalDirection(float touchX, float skewerX)
    {
        Debug.Log("touchX: " + touchX);
        Debug.Log("skewerX: " + skewerX);
        if(touchX - skewerX > m_touchBound)
        {
            return 1f;
        }
        else if (skewerX - touchX > m_touchBound)
        {
            return -1f;
        }
        else
        {
            return 0f;
        }
    }
}