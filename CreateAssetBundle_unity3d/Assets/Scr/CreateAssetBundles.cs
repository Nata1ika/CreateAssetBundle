#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class CreateAssetBundles
{
    [MenuItem("Gulyaeva/MarkerAssetBundles")]
    public static void BuildAllAssetBundles()
    {
        var graphics = new List<Prefabs>(); //TODO получить список префабов

        foreach (var element in graphics)
        {
            var path = string.Format("Assets/Prefabs/{0}.prefab", element.path);
            var assetImporter = AssetImporter.GetAtPath(path);
            if (assetImporter == null)
            {
                Debug.LogErrorFormat("Asset key =<<{0}>> not found at path <<{1}>>", element.path, element.bundle);
                return;
            }
            assetImporter.SetAssetBundleNameAndVariant(element.bundle, null);
        }
        //BuildPipeline.BuildAssetBundles("Assets/StreamingAssets", BuildAssetBundleOptions.None, BuildTarget.Android);
    }

    public class Prefabs
    {
        public string path;
        public string bundle;
    }
}
#endif
