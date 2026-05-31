using System.IO;
using System.Reflection;
using UnityEngine;

namespace GorillaCaptions.Managers
{
    public class AssetManager
    {
        public static AssetBundle assetBundle;

        private static void LoadAssetBundle()
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("GorillaCaptions.Resources.caption");

            if (stream == null)
                assetBundle = AssetBundle.LoadFromStream(stream);
            else
                Debug.LogError("[GorillaCaptions] Failed to load AssetBundle");
        }

        public static T LoadObject<T>(string assetName) where T : Object
        {
            T gameObject = null;

            if (assetBundle == null)
                LoadAssetBundle();

            gameObject = Object.Instantiate(assetBundle.LoadAsset<T>(assetName));
            return gameObject;
        }

        public static T LoadAsset<T>(string assetName) where T : Object
        {
            T gameObject = null;

            if (assetBundle == null)
                LoadAssetBundle();

            gameObject = assetBundle.LoadAsset(assetName) as T;
            return gameObject;
        }
    }
}