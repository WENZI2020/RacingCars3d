using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        private GameObject firstCamera, thirdCamera;
        private bool isFirstPersonView = false;


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            firstCamera = GameObject.Find("Camera First");
            thirdCamera = GameObject.Find("Camera Third");
        }
        private void Update()
        {
            if (Input.GetKey(KeyCode.V))
            {
                isFirstPersonView = !isFirstPersonView;
            }

            if (isFirstPersonView)
            {
                firstCamera.SetActive(true);
                thirdCamera.SetActive(false);
            }
            else
            {
                firstCamera.SetActive(false);
                thirdCamera.SetActive(true);
            }
        }

        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
