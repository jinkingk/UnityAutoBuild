using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class AutoBuildTool
{
    private static string outputWin
    {
        get
        {
            var basePath = @"./WIN";
            if (System.IO.Directory.Exists(basePath))
                System.IO.Directory.Delete(basePath, true);
            System.IO.Directory.CreateDirectory(basePath);
            var fileName = "game.exe";
            return System.IO.Path.Combine(basePath, fileName);
        }
    }

    private static string outputAndroid
    {
        get
        {
            var basePath = @"./Android";
            if (System.IO.Directory.Exists(basePath))
                System.IO.Directory.Delete(basePath, true);
            System.IO.Directory.CreateDirectory(basePath);
            var fileName = "game.apk";
            return System.IO.Path.Combine(basePath, fileName);
        }
    }

    [MenuItem("Tool/BuildWindows")]
    public static void BuildWindows()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows64);

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.targetGroup = BuildTargetGroup.Standalone;
        buildPlayerOptions.options = BuildOptions.None;
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
        buildPlayerOptions.locationPathName = outputWin;

        BuildReport buildReport = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary buildSummary = buildReport.summary;
        if (buildSummary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build Windows Succeeded");
        }
        else
        {
            Debug.LogError("Build Windows Failed");
        }
    }

    [MenuItem("Tool/BuildAndroid")]
    public static void BuildAndroid()
    {
        bool switchTarget = EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
        if (switchTarget == false)
        {
            Debug.LogError("SwitchActiveBuildTarget Failed! Please check if the target can be switched");
            return;
        }

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.targetGroup = BuildTargetGroup.Android;
        buildPlayerOptions.options = BuildOptions.None;
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
        buildPlayerOptions.locationPathName = outputAndroid;

        BuildReport buildReport = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary buildSummary = buildReport.summary;
        if (buildSummary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build Android Succeeded");
        }
        else
        {
            Debug.LogError("Build Android Failed");
        }
    }
}
