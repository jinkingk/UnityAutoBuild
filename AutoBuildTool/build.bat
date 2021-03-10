@echo off 

set Unity="C:/Program Files/Unity/Editor/Unity.exe"
set ProjetcPath="C:/UserDriver-D/git/UnityAutoBuild"
set LogFile="C:/UserDriver-D/git/UnityAutoBuild/AutoBuildTool/build.log"
set JenkinsWorkPath="C:/Windows/System32/config/systemprofile/AppData/Local/Jenkins/.jenkins/workspace/AutoBuildUnity/"
set ExeFailPath="C:/UserDriver-D/git/UnityAutoBuild/Win"
set WinRAR="C:/Program Files/WinRAR/WinRAR.exe"

echo start build %DATE% %TIME%

%Unity% -quit -batchmode -projectPath %ProjetcPath% -executeMethod AutoBuildTool.BuildWindows -logFile %LogFile%

echo zipwin

%WinRAR% a -ag -k -r -s %JenkinsWorkPath% %ExeFailPath%

echo end build %DATE% %TIME%

pause