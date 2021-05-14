using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Collections;

public class MyUtils
{
    public static string savePath = Application.persistentDataPath;
    public static float GetdBFromValue(float value)
    {
        if (value == 0)
            return -80;
        return 20f * Mathf.Log10(value);
    }

    public static void Save(string name, object serializeObj)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(Path.Combine(savePath, name), FileMode.Create);

        formatter.Serialize(stream, serializeObj);
        stream.Close();
    }
    public static object Load(string name)
    {
        object returnObj = null;
        if (File.Exists(Path.Combine(savePath, name)))
        {
            BinaryFormatter formatter = null;
            FileStream stream = null;
            try
            {
                formatter = new BinaryFormatter();
                stream = new FileStream(Path.Combine(savePath, name), FileMode.Open);

                returnObj = formatter.Deserialize(stream);
                stream.Close();
            }
            catch
            {
                if (stream != null)
                    stream.Close();

                Delete(name);
            }
        }

        return returnObj;
    }

    public static void Delete(string name)
    {
        if (File.Exists(Path.Combine(savePath, name)))
        {
            File.Delete(Path.Combine(savePath, name));
        }
    }

    public static IEnumerator WaitForSecondWithoutTimeScale(float time)
    {
        float start = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < start + time)
        {
            yield return null;
        }
    }
}
