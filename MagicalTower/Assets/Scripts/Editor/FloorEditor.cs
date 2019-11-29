using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

using NGame.NData;
using NUtility.NHelper;

namespace NEditor
{
    public class FloorEditor
        : ScriptableWizard
    {
        Vector2 scrollPos;

        bool _foldOut;
        int _totalFloor;

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
            _totalFloor = 0;

            _foldOutList.Clear();

            for (int i = 0; i < _totalFloor; ++i)
            {
                _foldOutList.Add(false);
            }

            //LoadJson();
        }

        void OnGUI()
        {
            scrollPos = GUILayout.BeginScrollView(scrollPos);

            DrawButton();

            for (int i = 0; i < _totalFloor; ++i)
            {
                DrawFloor(i + 1);
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

            GUILayout.Button("Save");

            EditorGUILayout.EndHorizontal();
        }

        void DrawFloor(int floor)
        {
            FloorData floorData = new FloorData();

            string totalMonsterCount = string.Empty;

            _foldOutList[floor - 1] = EditorGUILayout.Foldout(_foldOutList[floor - 1], floor.ToString());

            if (_foldOutList[floor - 1] == true)
            {
                EditorGUILayout.BeginHorizontal(GUI.skin.box);

                //EditorGUILayout.LabelField("Floor", floor.ToString());

                totalMonsterCount = "1";
                totalMonsterCount = EditorGUILayout.TextField("Total Monster Count", totalMonsterCount);

                EditorGUILayout.EndHorizontal();

                GUILayout.Space(5f);
            }

            //_floorDataList.Add(new FloorData()
            //{
            //    Floor = floor,
            //    TotalMonsterCount = int.Parse(totalMonsterCount),
            //});
        }

        void AddFloor()
        {
            ++_totalFloor;

            _foldOutList.Add(false);
        }

        void RemoveFloor()
        {
            if (_totalFloor <= 0)
            {
                return;
            }

            --_totalFloor;
        }

        void LoadJson()
        {
            if (File.Exists(FloorDataFilePath) == true)
            {
                var json = File.ReadAllText(FloorDataFilePath);

                var datas = JsonHelper.FromJson<FloorData>(json);

                _floorDataList.Clear();
                _floorDataList.AddRange(datas);
            }
        }

        string FloorDataFilePath
        {
            get
            {
                return Application.dataPath + "/GameData/FloorData.json";
            }
        }
    }
}
