using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Model;
using Control;

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
                GameObject ChairObj =  Instantiate(Model_Data.Instance.LoadObj.Find(s => s.name.Equals("Chair")), new Vector3(100, 100, 100), Quaternion.identity);
                int i = GameTool.FindGameObjNumWithTag("Chair");
                ChairObj.name = ChairObj.name + i.ToString();
                GameTool.ChangeChooseActive(Model_Data.Instance.SceneObj, ChairObj.name);
                Model_Data.Instance.SceneObj.Add(ChairObj);
            });

            Button_Sofa.onClick.AddListener(delegate()
            {
                GameObject SofaObj = Instantiate(Model_Data.Instance.LoadObj.Find(s => s.name.Equals("Sofa")), new Vector3(100, 100, 100), Quaternion.identity);
                int i = GameTool.FindGameObjNumWithTag("Sofa");
                SofaObj.name = SofaObj.name + i.ToString();
                GameTool.ChangeChooseActive(Model_Data.Instance.SceneObj, SofaObj.name);
                Model_Data.Instance.SceneObj.Add(SofaObj);
            });

            Button_Lamp.onClick.AddListener(delegate ()
            {
                GameObject LampObj = Instantiate(Model_Data.Instance.LoadObj.Find(s => s.name.Equals("Lamp")), new Vector3(100, 100, 100), Quaternion.identity);
                int i = GameTool.FindGameObjNumWithTag("Lamp");
                LampObj.name = LampObj.name + i.ToString();
                GameTool.ChangeChooseActive(Model_Data.Instance.SceneObj, LampObj.name);
                Model_Data.Instance.SceneObj.Add(LampObj);
            });
        }

    }

}