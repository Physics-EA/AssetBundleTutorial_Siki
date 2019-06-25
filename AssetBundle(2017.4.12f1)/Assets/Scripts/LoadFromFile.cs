using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class LoadFromFile : MonoBehaviour
{

    // Use this for initialization
    IEnumerator Start()
    {
        //string path = "AssetBundles/cubewall.ab";

        //AssetBundle ab2 = AssetBundle.LoadFromFile("AssetBundles/share.ab");
        //AssetBundle ab = AssetBundle.LoadFromFile("AssetBundles/cubewall.ab");
        //AssetBundle ab3 = AssetBundle.LoadFromFile("AssetBundles/capsualwall.ab");


        //GameObject wallPrefab = ab.LoadAsset<GameObject>("CubeWall");
        //GameObject capsaulPrefab = ab3.LoadAsset<GameObject>("CapsuleWall");

        //Instantiate(wallPrefab);
        //Instantiate(capsaulPrefab);

        //Object[] objs = ab2.LoadAllAssets();
        //foreach (var item in objs)
        //{
        //    Instantiate(item);
        //}

        //第一种加载方式
        //AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));
        //yield return request;//等待上面一步加载完成
        //AssetBundle ab = request.assetBundle;

        //第二种加载方式
        //AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(path);
        //yield return request;
        //AssetBundle ab = request.assetBundle;

        //第三种加载AB的方式
        //string wwwPath = @"file:///D:\Desktop\AssetBundle(2017.4.12f1)\cubewall.ab";
        //while (Caching.ready == false)
        //{
        //    yield return null;
        //}
        ////WWW www = WWW.LoadFromCacheOrDownload(@"file://D:\Desktop\AssetBundle(2017.4.12f1)\AssetBundles\cubewall.ab", 1);
        //WWW www = WWW.LoadFromCacheOrDownload(@"http://localhost/AssetBundles\cubewall.ab", 1);
        //yield return www;
        //if (string.IsNullOrEmpty(www.error)==false)
        //{
        //    Debug.Log(www.error);
        //    yield break;
        //}
        //AssetBundle ab = www.assetBundle;

        //第四种方式
        //string uri = @"file:///D:\Desktop\AssetBundle(2017.4.12f1)\AssetBundles\cubewall.ab";
        string uri = @"http://localhost/AssetBundles/cubewall.ab";
        UnityWebRequest request = UnityWebRequest.GetAssetBundle(uri);

        yield return request.Send();
        //AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);
        AssetBundle ab = (request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;


        //使用
        GameObject wallPrefab = ab.LoadAsset<GameObject>("CubeWall");
        Instantiate(wallPrefab);

        AssetBundle maniestAB = AssetBundle.LoadFromFile("AssetBundles/AssetBundles");
        AssetBundleManifest manifest = maniestAB.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        foreach (var item in manifest.GetAllAssetBundles())
        {
            print(item);
        }
        string[] strs = manifest.GetAllDependencies("cubewall.ab");
        foreach (var item in strs)
        {
            print(item);
            AssetBundle.LoadFromFile("AssetBundles/" + item);
        }


    }


}
