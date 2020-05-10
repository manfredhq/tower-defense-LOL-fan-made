﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationSystem
{
    public enum Language
    {
        English,
        French
    }

    public static Language language = Language.French;

    private static Dictionary<string, string> localizedEN;
    private static Dictionary<string, string> localizedFR;

    public static bool isInit;

    public static void Init()
    {
        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        localizedEN = csvLoader.GetDictionaryValues("en");
        localizedFR = csvLoader.GetDictionaryValues("fr");


        isInit = true;
    }

    public static Dictionary<string, string> GetDictionaryForEditor()
    {
        if (!isInit) { Init(); }
        return localizedEN;
    }

    public static string GetLocalizedValue(string key)
    {
        if (!isInit)
        {
            Init();
        }
        string value = key;

        switch (language)
        {
            case Language.English:
                localizedEN.TryGetValue(key, out value);
                break;
            case Language.French:
                localizedFR.TryGetValue(key, out value);
                break;
        }

        return value;
    }


}
