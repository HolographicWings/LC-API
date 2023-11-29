﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LC_API.GameInterfaceAPI
{
    internal class GameTips
    {
        private static List<string> tipHeaders = new List<string>();
        private static List<string> tipBodys = new List<string>();
        private static float lastMessageTime;

        public static void ShowTip(string header, string body)
        {
            tipHeaders.Add(header);
            tipBodys.Add(body);
        }

        public static void UpdateInternal()
        {
            lastMessageTime -= Time.deltaTime;
            if (tipHeaders.Count > 0 & lastMessageTime < 0)
            {
                lastMessageTime = 5f;
                HUDManager.Instance.DisplayTip(tipHeaders[0], tipBodys[0]);
                tipHeaders.RemoveAt(0);
                tipBodys.RemoveAt(0);
            }
        }
    }
}