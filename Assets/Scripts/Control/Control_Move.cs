using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;

namespace Control
{

    public class Control_Move : MonoBehaviour
    {
        public static Control_Move Instance;

        public GameObject MainObj;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            MainObj = Model_Data.Instance.LoadObj[0];
        }

        void Update()
        {
            HelloARController.Instance.HandleTouch_Single(MainObj);
        }
    }
}
