using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Commons
{
    public class LogFile : MonoBehaviour
    {
        private static string logFilePath = Application.dataPath + "/log.txt";
        public static void Log(string message)
        {
            string formattedMessage = string.Format("[INFO] {0}: {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), message);
            Debug.Log(formattedMessage);
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine(formattedMessage);
            }
        }

        public static void LogWarning(string message)
        {
            string formattedMessage = string.Format("[WARNING] {0}: {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), message);
            Debug.LogWarning(formattedMessage);
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine(formattedMessage);
            }
        }

        public static void LogError(string message)
        {
            string formattedMessage = string.Format("[ERROR] {0}: {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), message);
            Debug.LogError(formattedMessage);
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine(formattedMessage);
            }
        }
    }
}