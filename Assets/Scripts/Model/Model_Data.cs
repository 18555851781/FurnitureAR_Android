using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{

    public class Model_Data : MonoBehaviour
    {

        public static Model_Data Instance;

        //  从文件夹中加载出来的数据
        public List<GameObject> LoadObj = new List<GameObject>();

        //  场景中的模型资源
        public List<GameObject> SceneObj = new List<GameObject>();

        //  场景初始化脚本挂载物体
        public GameObject MainObj;

        private void Awake()
        {
            Instance = this;
        }


    }
}
