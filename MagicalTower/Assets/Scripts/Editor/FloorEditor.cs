using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using System;

using NGame.NData;
using NUtility.NHelper;
using NGame.NManager.NTower;

namespace NEditor
{
    public class FloorEditor
        : EditorWindow
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
            JsonHelper.LoadJsonFloorDataList(out _floorDataList);

            _foldOutList.Clear();

            for (int i = _floorDataList.Count - 1; i >= 0; --i)
            {
                _foldOutList.Add(false);
            }
        }

        #region Draw GUI
        void OnGUI()
        {
            scrollPos = GUILayout.BeginScrollView(scrollPos);

            DrawButton();
            DrawDescription();

            FloorData floorData = null;

            for (int i = _floorDataList.Count - 1; i >= 0; --i)
            {
                floorData = _floorDataList[i];

                if (floorData == null)
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

        void DrawDescription()
        {
            EditorGUILayout.BeginVertical(GUI.skin.box);

            EditorGUILayout.LabelField("Disable Puszzles - [각 층에서 막을 퍼즐!! ',' 로 구분자.]");
            EditorGUILayout.LabelField("Total Monster Count - [각 층에 나올 수 있는 전체 몬스터 수.]");
            EditorGUILayout.LabelField("Limit Turn - [각 층의 게임을 끝내야 하는 제한 턴. 0 일 경우 제한 턴이 없음.]");

            EditorGUILayout.EndVertical();
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
                EditorGUILayout.BeginVertical(GUI.skin.box);

                DrawDisablePuzzles(floorData);
                DrawTotalMonsterCount(floorData);
                DrawLimitTurn(floorData);

                EditorGUILayout.EndVertical();
            }
        }

        void DrawTotalMonsterCount(FloorData floorData)
        {
            if(floorData == null)
            {
                return;
            }

            var totalMonsterCount = floorData.TotalMonsterCount.ToString();
            totalMonsterCount = EditorGUILayout.TextField("Total Monster Count", totalMonsterCount);

            var parseTotalMonsterCount = 1;
            if (int.TryParse(totalMonsterCount, out parseTotalMonsterCount) == false)
            {
                parseTotalMonsterCount = 1;
            }

            floorData.TotalMonsterCount = parseTotalMonsterCount > 0 ? parseTotalMonsterCount : 1;
        }

        void DrawDisablePuzzles(FloorData floorData)
        {
            if(floorData == null)
            {
                return;
            }

            var disablePuzzles = string.Empty;

            if (floorData.DisablePuzzles != null &&
               floorData.DisablePuzzles.Length > 0)
            {
                foreach(int disablePuzzle in floorData.DisablePuzzles)
                {
                    if(disablePuzzle <= 0)
                    {
                        continue;
                    }

                    disablePuzzles += disablePuzzle;
                    disablePuzzles += ",";
                }

                if(disablePuzzles.Length > 0)
                {
                    disablePuzzles = disablePuzzles.Substring(0, disablePuzzles.Length - 1);
                }
            }
            
            disablePuzzles = EditorGUILayout.TextField("Disable Puzzles", disablePuzzles);

            if(disablePuzzles.Equals(string.Empty) == true)
            {
                floorData.DisablePuzzles = null;
                return;
            }

            var splitDisablePuzzles = disablePuzzles.Split(',');

            if (splitDisablePuzzles.Length > 0)
            {
                List<int> list = new List<int>();
                list.Clear();

                int parseDisablePuzzle = 0;
                foreach(var disablePuzzle in splitDisablePuzzles)
                {
                    parseDisablePuzzle = 0;

                    if (int.TryParse(disablePuzzle, out parseDisablePuzzle) == false)
                    {
                        continue;
                    }

                    if (parseDisablePuzzle <= 0)
                    {
                        continue;
                    }

                    if(list.Contains(parseDisablePuzzle) == true)
                    {
                        continue;
                    }

                    list.Add(parseDisablePuzzle);
                }

                floorData.DisablePuzzles = list.ToArray();
            }
        }

        void DrawLimitTurn(FloorData floorData)
        {
            if (floorData == null)
            {
                return;
            }

            var limitTurn = floorData.LimitTurn.ToString();
            limitTurn = EditorGUILayout.TextField("Limit Turn", limitTurn);

            var parseLimitTurn = 0;
            if (int.TryParse(limitTurn, out parseLimitTurn) == false)
            {
                parseLimitTurn = 0;
            }

            floorData.LimitTurn = parseLimitTurn >= 0 ? parseLimitTurn : 0;
        }
        #endregion GUI

        void AddFloor()
        {
            var floorData = FloorData.Create();
            floorData.Floor = _floorDataList.Count + 1;

            _floorDataList.Add(floorData);

            _foldOutList.Add(true);
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

            File.WriteAllText(NUtility.GameData.FloorDataFilePath, toJson);
        }
    }
}
