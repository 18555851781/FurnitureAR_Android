using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;
using UnityEngine.EventSystems;

using StandardAR;
using StandardARInternal;

namespace Control
{

    public class Control_Move : MonoBehaviour
    {

        private bool IsTouchObj;
        private Touch BeginTouch1;
        private Touch BeginTouch2;

        private void Update()
        {
            Move();
        }

        public void Move()
        {
            Session.SetHitTestMode(ApiHitTestMode.PolygonPersistence);

            if (Input.touchCount == 0)
                return;

            //  未点击到UI时
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId) == false)
                    IsTouchObj = false;
                else
                    IsTouchObj = true;
            }

            if (Frame.TrackingState != TrackingState.Tracking)
                return;

            TrackableHit hit;
            TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinBounds | TrackableHitFlags.PlaneWithinPolygon;

            //  判断是否点击到UI  以及将屏幕点击坐标转换为空间坐标
            if (IsTouchObj == false && Session.Raycast(Input.touches[0].position.x, Input.touches[0].position.y, raycastFilter, out hit) && Input.touchCount == 1 && ( Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved) )
            {
                this.gameObject.transform.position = hit.Pose.position;
            }

            if(IsTouchObj == false && Input.touchCount >= 2)
            {
                Touch touch1 = Input.GetTouch(0);
                Touch touch2 = Input.GetTouch(1);


                if (touch1.phase == TouchPhase.Began && touch2.phase == TouchPhase.Began)
                {
                    BeginTouch1 = touch1;
                    BeginTouch2 = touch2;
                    return;
                }
                if (touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Moved)
                {
                    float x1 = BeginTouch1.position.x - touch1.position.x;
                    float x2 = BeginTouch2.position.x - touch2.position.x;
                    transform.eulerAngles += new Vector3(0, x2 / 2, 0);
                    BeginTouch1 = touch1;
                    BeginTouch2 = touch2;
                }
            }
        }
    }
}
