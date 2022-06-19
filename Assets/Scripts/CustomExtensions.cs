using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomExtensions
{
    public static class StringExtension
    {
        public static void FancyDebug(this string str)
        {
            Debug.LogFormat("Ten ciąg znaków zawiera {0} znaków.", str.Length);
        }
    }
}

