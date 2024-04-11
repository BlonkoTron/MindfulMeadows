using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using UnityEngine;

public class WritingDataManager: MonoBehaviour
{
    public static WritingDataManager instance;

    public struct WriteData
    {
        public string prompt;
        public int textLength;
        public float writeTime;

        public WriteData(string prompt, int length, float time)
        {
            this.prompt = prompt;
            this.textLength = length;
            this.writeTime = time;
        }
    }
    public static List<WriteData> myWriteData = new List<WriteData>();

    private static string dataPath;
    private static string xmlFilePath;
    void Awake()
    {
        dataPath = Application.persistentDataPath + "/Player_Data/";
        xmlFilePath = dataPath + "data.xml";
        Debug.Log(dataPath);
        NewDirectory();
    }
    public void NewDirectory()
    {
        if (Directory.Exists(dataPath))
        {
            Debug.Log("Directory already exists...");
            return;
        }

        Directory.CreateDirectory(dataPath);
        Debug.Log("New directory created at: "+dataPath);
    }
    public static void SerializeXML()
    {
        var xmlSerializer = new XmlSerializer(typeof(List<WriteData>));

        using (FileStream stream = File.Create(xmlFilePath.ToString()))
        {
            xmlSerializer.Serialize(stream, myWriteData);
        }
    }

}
