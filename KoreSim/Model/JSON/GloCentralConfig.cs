// using System;
// using System.Collections;
// using System.Collections.Generic;

// // Static class wrapper for a single/central instance of a KoreConfig.

// public static class KoreCentralConfig
// {
//     private static KoreConfig configData;

//     static KoreCentralConfig()
//     {
//         configData = new KoreConfig();
//         configData.LoadOrCreateJSONConfig("CentralConfig.json");

//         // Setup default configs if not present
//         if (!KoreCentralConfig.HasParam("MapRootDir")) KoreCentralConfig.SetParam("MapRootDir", "C:/Util/KoreLibrary/Maps/", false);
//         if (!KoreCentralConfig.HasParam("CaptureDir")) KoreCentralConfig.SetParam("CaptureDir", "C:/Util/KoreCapture/", false);
//     }

//     public static void SetParam(string name, string value, bool WriteOnAssign = true)
//     {
//         configData.SetParam(name, value, WriteOnAssign);
//     }

//     public static bool HasParam(string name)
//     {
//         return configData.HasParam(name);
//     }

//     public static string GetParam(string name)
//     {
//         return configData.GetParam(name);
//     }

//     public static int GetParamAsInt(string name)
//     {
//         string value = GetParam(name);
//         if (value != null && int.TryParse(value, out int result))
//         {
//             return result;
//         }
//         else
//         {
//             return 0;
//         }
//     }

//     // ----------------------------------------------------------------------------------------------------------

//     public static string BoolToString(bool value)
//     {
//         return value ? "True" : "False";
//     }

//     public static bool StringToBool(string value)
//     {
//         return string.Equals(value.Trim(), "True", StringComparison.OrdinalIgnoreCase);
//     }

// }
