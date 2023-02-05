using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public static class WindowUtils
    {
        public static void CreateWindow(string resourcePath)
        {
            var window = Resources.Load<GameObject>(resourcePath);
            var canvas = GameObject.FindWithTag("MainUICanvas").GetComponent<Canvas>();
            UnityEngine.Object.Instantiate(window, canvas.transform);
        }
    }
}
