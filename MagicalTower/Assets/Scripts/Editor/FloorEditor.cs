using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;

using NGame.NData;
using NUtility.NHelper;

namespace NEditor
{
    public class FloorEditor
        : ScriptableWizard
    {
        Vector2 scrollPos;

        List<bool> _foldOutList = new List<bool>();
        List<FloorData> _floorDataList = new List<FloorData>();

        [MenuItem("Data/Floor")]
        static void OpenEditor()
        {
            var window = GetWindow<FloorEditor>(false, "Floor Editor", true);

            if (window != null)
            {
                window.Init();
            }
        }

        void Init()
        {
            LoadJson();

            _foldOutList.Clear();

            for (int i = 0; i < _floorDataList.Count; ++i)
            {
                _foldOutList.Add(false);
            }
        }

        void OnGUI()
        {
            scrollPos = GUILayout.BeginScrollView(scrollPos);

            DrawButton();

                foreach(var floorData in _floorDataList)
            {
                if(floorData == null)
                {
                    continue;
                }

                DrawFloor(floorData);
            }

            GUILayout.EndScrollView();
        }

        void DrawButton()
        {
            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Add Floor") == true)
            {
                AddFloor();
            }

            if (GUILayout.Button("Remove Floor") == true)
            {
                RemoveFloor();
            }

            if(GUILayout.Button("Save") == true)
            {
                SaveJson();
            }

            EditorGUILayout.EndHorizontal();
        }

        void DrawFloor(FloorData floorData)
        {
            if(floorData == null)
            {
                return;
            }

            int index = floorData.Floor - 1;
        
            _foldOutList[index] = EditorGUILayout.Foldout(_foldOutList[index], floorData.Floor.ToString());

            if (_foldOutList[index] == true)
            {
                EditorGUILayout.BeginHorizontal(GUI.skin.box);

                //EditorGUILayout.LabelField("Floor", floor.ToString());

                var totalMonsterCount = floorData.TotalMonsterCount.ToString();
                totalMonsterCount = EditorGUILayout.TextField("Total Monster Count", totalMonsterCount);

                var parseTotalMonsterCount = 1;
                if(int.TryParse(totalMonsterCount, out parseTotalMonsterCount) == false)
                {
                    parseTotalMonsterCount = 1;
                }
                _floorDataList[index].TotalMonsterCount = parseTotalMonsterCount > 0 ? parseTotalMonsterCount : 1;

                EditorGUILayout.EndHorizontal();

                GUILayout.Space(5f);
            }
        }

        void AddFloor()
        {
            _floorDataList.Add(new FloorData()
            {
                Floor = _floorDataList.Count + 1,
                TotalMonsterCount = 1,
            });

            _foldOutList.Add(false);
        }

        void RemoveFloor()
        {
            if (_floorDataList.Count <= 0)
            {
                return;
            }

            _floorDataList.RemoveAt(_floorDataList.Count - 1);
        }

        void SaveJson()
        {
            var toJson = JsonHelper.ToJson(_floorDataList.ToArray());
            Debug.Log("toJson : " + toJson);

            File.WriteAllText(FloorDataFilePath, toJson);
        }

        void LoadJson()
        {
            _floorDataList.Clear();

            if (File.Exists(FloorDataFilePath) == true)
            {
                var jsonString = File.ReadAllText(FloorDataFilePath);
                var jsonDatas = JsonHelper.FromJson(jsonString);

                var floorData = new FloorData();

                foreach(LitJson.JsonData jsonData in jsonDatas)
                {
                    floorData = new FloorData();

                    floorData.Floor = int.Parse(jsonData["Floor"].ToString());
                    floorData.TotalMonsterCount = int.Parse(jsonData["TotalMonsterCount"].ToString());

                    _floorDataList.Add(floorData);
                }
            }
        }

        string FloorDataFilePath
        {
            get
            {
                return Application.dataPath + "/Resources/GameData/FloorData.json";
            }
        }
    }
}
