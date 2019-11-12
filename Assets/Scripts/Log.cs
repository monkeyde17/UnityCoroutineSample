using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log 
{
    public class LogUnit
    {
        public LogUnit(string tag)
        {
            Tag = tag;
        }

        public string Tag { get; private set; }

        public void I(string format, params object[] args)
        {
            Log.I(Tag, format, args);//string.Format("帧:{0} [{1}] {2}", Time.frameCount, Tag, string.Format(format, args)));
        }

    }

    public static void I(string tag, string format, params object[] args)
    {
        Debug.Log(string.Format("帧:{0} [{1}] {2}", Time.frameCount, tag, string.Format(format, args)));
    }

    public static LogUnit Get(string tag)
    {
        return new LogUnit(tag);
    }
}
