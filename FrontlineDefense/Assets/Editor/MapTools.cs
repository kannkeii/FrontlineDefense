using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MapTools
{
    private const int MAP_W = 16;
    private const int MAP_H = 11;
    private const float blockSize = 1.5f;

    [MenuItem("MapSetting/CreateMap")]
    private static void CreateMap()
    {
        Material mat = Resources.Load("Material/testTexture2", typeof(Material)) as Material;

        if (mat == null)
        {
            Debug.LogError("マップマテリアルが見つかりません。");
            return;
        }

        int blockCnt = 0;

        for (int h = 0; h < MAP_H; h++)
        {
            for (int w = 0; w < MAP_W; w++)
            {
                GameObject mapblock = GameObject.CreatePrimitive(PrimitiveType.Plane);
                var flags = StaticEditorFlags.NavigationStatic | StaticEditorFlags.NavigationStatic;
                GameObjectUtility.SetStaticEditorFlags(mapblock, flags);


                mapblock.tag = "Ground";
                mapblock.transform.parent = GameObject.FindGameObjectWithTag("Stage").transform;
                Vector3 newXYZ = new Vector3(blockSize / 1.3f + blockSize / 1.16f * w - (MAP_W * blockSize / 2 - blockSize), 0, blockSize / 1.5f + blockSize * h - MAP_H * blockSize / 2.5f);
                if (h % 2 == 0)
                {
                    newXYZ.x -= (float)blockSize / (2f + .3f);
                }
                {
                    newXYZ.z -= (float)blockSize / (2f + blockSize + .5f) * h;
                }

                mapblock.transform.position = new Vector3(newXYZ.x, 0, newXYZ.z);
                mapblock.transform.localScale = new Vector3(blockSize * .1f, 1f, blockSize * .1f);
                mapblock.transform.rotation = Quaternion.Euler(0, 180, 0);
                mapblock.name = "mapblock_"+ w+"_"+h+"_"+ blockCnt;
                mapblock.GetComponent<MeshRenderer>().material = mat;
                
                blockCnt++;
            }
        }
    }

    [MenuItem("MapSetting/DeleteAllMap")]
    private static void DeleteAllMap()
    {
        
        Transform stage = GameObject.FindGameObjectWithTag("Stage").transform;

        int childCount = stage.childCount;
        for (int i = 0; i < childCount; i++)
        {
            GameObject.DestroyImmediate(stage.GetChild(0).gameObject);
        }
    }
}
