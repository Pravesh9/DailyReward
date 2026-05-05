#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using System;

public class DailyRewardEditorWindow : EditorWindow
{
    private const string LAST_DAY_KEY = "LAST_DAY";
    private const string LAST_DATE_KEY = "LAST_DATE";

    private int selectedDay = 1;

    [MenuItem("Tools/Daily Reward Debugger")]
    public static void ShowWindow()
    {
        GetWindow<DailyRewardEditorWindow>(
            "Daily Reward Debugger");
    }

    private void OnGUI()
    {
        GUILayout.Space(10);

        EditorGUILayout.LabelField(
            "Daily Reward Debug Tool",
            EditorStyles.boldLabel);

        GUILayout.Space(10);

        DrawCurrentProgress();

        GUILayout.Space(20);

        DrawUnlockSection();

        GUILayout.Space(20);

        DrawUtilityButtons();
    }

    private void DrawCurrentProgress()
    {
        int currentDay =
            PlayerPrefs.GetInt(LAST_DAY_KEY, 0);

        string lastDate =
            PlayerPrefs.GetString(LAST_DATE_KEY, "None");

        EditorGUILayout.LabelField(
            "Current Claimed Day",
            currentDay.ToString());

        EditorGUILayout.LabelField(
            "Last Claim Date",
            lastDate);
    }

    private void DrawUnlockSection()
    {
        EditorGUILayout.LabelField(
            "Unlock Reward Day",
            EditorStyles.boldLabel);

        selectedDay =
            EditorGUILayout.IntField(
                "Day",
                selectedDay);

        if (GUILayout.Button("Unlock Day"))
        {
            UnlockDay(selectedDay);
        }
    }

    private void DrawUtilityButtons()
    {
        if (GUILayout.Button("Reset Rewards"))
        {
            ResetRewards();
        }

        // if (GUILayout.Button("Claim Today Again"))
        // {
        //     AllowClaimToday();
        // }
    }

    private void UnlockDay(int day)
    {
        PlayerPrefs.SetInt(LAST_DAY_KEY, day - 1);

        PlayerPrefs.SetString(
            LAST_DATE_KEY,
            DateTime.UtcNow.AddDays(-1).ToString());

        PlayerPrefs.Save();

        Debug.Log(
            $"Reward Day {day} unlocked.");
    }

    private void ResetRewards()
    {
        PlayerPrefs.DeleteKey(LAST_DAY_KEY);
        PlayerPrefs.DeleteKey(LAST_DATE_KEY);

        PlayerPrefs.Save();

        Debug.Log("Rewards Reset");
    }

    private void AllowClaimToday()
    {
        PlayerPrefs.SetString(
            LAST_DATE_KEY,
            DateTime.UtcNow.AddDays(-1).ToString());

        PlayerPrefs.Save();

        Debug.Log("Player can claim today again.");
    }
}

#endif