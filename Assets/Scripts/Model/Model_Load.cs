using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{

    public class Model_Load : MonoBehaviour
    {

        void Start()
        {
            Model_Data.Instance.LoadObj.Add((GameObject)Resources.Load("Chair"));
            Model_Data.Instance.LoadObj.Add((GameObject)Resources.Load("Sofa"));
            Model_Data.Instance.LoadObj.Add((GameObject)Resources.Load("Lamp"));
        }

    }
}
