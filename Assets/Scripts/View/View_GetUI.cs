using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Model;

namespace View
{

    public class View_GetUI : MonoBehaviour
    {
        public static View_GetUI Instance;

        //  获取交互按钮
        public Button Button_Chair;
        public Button Button_Sofa;
        public Button Button_Lamp;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            Button_Chair = GameObject.FindGameObjectWithTag("Chair").transform.GetComponent<Button>();
            Button_Sofa = GameObject.FindGameObjectWithTag("Sofa").transform.GetComponent<Button>();
            Button_Lamp = GameObject.FindGameObjectWithTag("Lamp").transform.GetComponent<Button>();

            Button_Chair.onClick.AddListener(delegate ()
            {
                GameObject ChairObj =  Instantiate(Model_Data.Instance.LoadObj[0], new Vector3(100, 100, 100), Quaternion.identity);
                HelloARController.Instance.StandardARBasePrefab = ChairObj;
                HelloARController.Instance.bPlaceModel = true;
            });
        }

    }

}