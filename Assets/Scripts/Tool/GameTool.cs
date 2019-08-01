using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTool : MonoBehaviour 
{

    public static Vector2 GoodsPlane_Display = new Vector2(-190,0);
    public static Vector2 GoodsPlane_Undisplay = new Vector2(100, 0);

    /// <summary>
    /// 发射射线检测物体
    /// </summary>
    /// <returns>The cast obejct.</returns>
    /// <param name="From">发射射线的物体.</param>
    /// <param name="To">射线发射的方向.</param>
    public static GameObject RayCastObejct(GameObject From,Vector3 To)
    { 
        Ray ray = new Ray(From.transform.position, To);

        RaycastHit Myhit;

        if(!Physics.Raycast(ray,out Myhit))
        {
            return null;
        }
        else
        {
            return Myhit.transform.gameObject;
        }
    }

    /// <summary>
    /// 从摄像机向屏幕点击位置发射射线
    /// </summary>
    /// <returns>The cast to touch.</returns>
    public static GameObject RayCastToTouch()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray,out hit))
        {
            return hit.transform.gameObject;
        }else
        {
            return null;
        }
    }

    /// <summary>
    /// 切换菜单的动画播放
    /// </summary>
    /// <param name="plane1">菜单Plane.</param>
    /// <param name="plane2">商品Plane.</param>
    /// <param name="IsPlane1Show">If set to <c>true</c> 判断菜单Plane是否进行显示.</param>
    /// <param name="IsPlane2Show">If set to <c>true</c> 判断商品Plane是否进行显示.</param>
    public static void PlaneExchange(RectTransform plane1,RectTransform plane2,bool IsPlane1Show,bool IsPlane2Show)
    {
        if(IsPlane1Show && !IsPlane2Show)
        {
            plane1.offsetMax = Vector2.Lerp(plane1.offsetMax, new Vector2(0, 0) * -1, 0.2f);
            plane2.offsetMax = Vector2.Lerp(plane2.offsetMax, new Vector2(-230, 0) * -1, 0.2f);
        }

        if(!IsPlane1Show && IsPlane2Show)
        {
            plane1.offsetMax = Vector2.Lerp(plane1.offsetMax, new Vector2(0, 0) * -1, 0.2f);
            plane2.offsetMax = Vector2.Lerp(plane2.offsetMax, new Vector2(0, 0) * -1, 0.2f);
        }
    }

	/// <summary>
    /// 颜色渐变
    /// </summary>
    /// <param name="image">所要改变颜色的物体上的image组件.</param>
    /// <param name="ToColor">所要渐变的颜色值</param>
    /// <param name="times">渐变时间</param>
    public static void ColorExchange(GameObject image,Color ToColor,float times)
    {
        Color ImageColor = image.GetComponent<Image>().color;

        ImageColor = Color.Lerp(ImageColor, ToColor, times);
    }

    /// <summary>
    /// 移动Plane位置
    /// </summary>
    /// <param name="plane">Plane.</param>
    /// <param name="Pos">移动后的位置.</param>
    public static void PlaneMove(GameObject plane,Vector2 Pos)
    {
        plane.GetComponent<RectTransform>().anchoredPosition = Pos;
    }

    /// <summary>
    /// 遍历子物体  然后加入到数组之中
    /// </summary>
    /// <returns>The child to list.</returns>
    /// <param name="name">父物体名称.</param>
    public static List<GameObject> AddChildToList(string name)
    {
        List<GameObject> child = new List<GameObject>();

        GameObject ParentObj = GameObject.Find(name);

        for (int i = 0; i < ParentObj.transform.childCount; i++)
        {
            child.Add(ParentObj.transform.GetChild(i).gameObject);
        }

        return child;
    }

    /// <summary>
    /// 切换物体的状态
    /// </summary>
    /// <param name="gameObject">Game object.</param>
    public static void ActiveExchange(GameObject gameObject)
    {
        if(gameObject == null)
        {
            gameObject = GameObject.Find(gameObject.name);
        }

        if(gameObject.activeSelf == true)
        {
            gameObject.SetActive(false);
        }else
        {
            gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 查看order下是否有该物体的条目
    /// </summary>
    /// <returns><c>true</c>, if is include object was ordered, <c>false</c> otherwise.</returns>
    /// <param name="parent">物体条目的父物体.</param>
    /// <param name="childname">子物体的名称.</param>
    public static bool OrderIsIncludeObj(GameObject parent,string childname)
    {
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            if(parent.transform.GetChild(i).name == childname)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 查看场景中有tag标签的物体数量
    /// </summary>
    /// <returns>The game object number with tag.</returns>
    /// <param name="tag">需要查看的标签.</param>
    public static int FindGameObjNumWithTag(string tag)
    {
        GameObject[] games = GameObject.FindGameObjectsWithTag(tag);

        return games.Length;
    }

    /// <summary>
    /// 清空物体数组
    /// </summary>
    /// <param name="MyList">所要传入的数组.</param>
    public static void ClearList(List<GameObject> MyList)
    {
        for (int i = 0; i < MyList.Count; i++)
        {
            Destroy(MyList[i]);
        }
        MyList.Clear();
    }

}

