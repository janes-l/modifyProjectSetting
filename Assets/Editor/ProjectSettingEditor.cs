using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ProjectSettingEditor
{
    private const string IOSLogoTexName = "LanchScreen_logo.png";
    private const string VirtualRealitySplashTexName = "LanchScreen_logo.png";
    private const string LegacyLaunchImageTexName = "LanchScreen_logo.png";
    private const string IOSIconTexName = "LanchScreen_logo.png";

    [MenuItem("Settings/ModifyIOSLogoSettings")]
    private static void ModifySettings()
    {

        var tex = GetLogoTex(IOSLogoTexName);
        if (tex)
        {
            PlayerSettings.SplashScreen.show = false;
            PlayerSettings.iOS.SetLaunchScreenImage(tex, iOSLaunchScreenImageType.iPhonePortraitImage);
            PlayerSettings.iOS.SetLaunchScreenImage(tex, iOSLaunchScreenImageType.iPhoneLandscapeImage);
            PlayerSettings.iOS.SetiPhoneLaunchScreenType(iOSLaunchScreenType.ImageAndBackgroundRelative);

            PlayerSettings.iOS.SetLaunchScreenImage(tex, iOSLaunchScreenImageType.iPadImage);
            PlayerSettings.iOS.SetiPadLaunchScreenType(iOSLaunchScreenType.ImageAndBackgroundRelative);
            ModifyIphoneAndIPadBackgroundColor(Color.white, Color.white, 40f, 26f);
        }
        else
        {
            Debug.LogError("cann't find LanchScreen_logo.png in path Assets/");
        }
    }

    static void ModifyIphoneAndIPadBackgroundColor(Color32 iphoneBg, Color32 ipadBg, float fillPct, float ipadFillPect)

    {

        const string projectSettings = "ProjectSettings/ProjectSettings.asset";

        UnityEngine.Object obj = UnityEditor.AssetDatabase.LoadAllAssetsAtPath(projectSettings)[0];

        SerializedObject psObj = new SerializedObject(obj);

        SerializedProperty iPhoneBgColor = psObj.FindProperty("iOSLaunchScreenBackgroundColor.rgba");

        SerializedProperty iPadBgColor = psObj.FindProperty("iOSLaunchScreeniPadBackgroundColor.rgba");

        UInt32 iphoneBgC = ((UInt32)iphoneBg.a) << 24 | ((UInt32)iphoneBg.b) << 16 | ((UInt32)iphoneBg.g) << 8 | ((UInt32)iphoneBg.r);

        iPhoneBgColor.longValue = iphoneBgC;

        UInt32 ipadBgC = ((UInt32)ipadBg.a) << 24 | ((UInt32)ipadBg.b) << 16 | ((UInt32)ipadBg.g) << 8 | ((UInt32)ipadBg.r);

        iPadBgColor.longValue = ipadBgC;

        SerializedProperty fillpencentage = psObj.FindProperty("iOSLaunchScreenFillPct");
        fillpencentage.floatValue = fillPct;
        
        SerializedProperty fillIpadpencentage = psObj.FindProperty("iOSLaunchScreeniPadFillPct");
        fillIpadpencentage.floatValue = ipadFillPect;

        psObj.ApplyModifiedProperties();

    }


    [MenuItem("Settings/ModifyVirtualRealitySplashScreen")]
    public static void ModifyVirtualRealitySplashScreen()
    {
        const string projectSettings = "ProjectSettings/ProjectSettings.asset";

        UnityEngine.Object obj = UnityEditor.AssetDatabase.LoadAllAssetsAtPath(projectSettings)[0];

        SerializedObject psObj = new SerializedObject(obj);

        SerializedProperty virtualRealitySplashScreen = psObj.FindProperty("m_VirtualRealitySplashScreen");

        var tex = GetLogoTex(VirtualRealitySplashTexName);
        if (tex)
        {
            virtualRealitySplashScreen.objectReferenceInstanceIDValue = tex.GetInstanceID();
        }

            psObj.ApplyModifiedProperties();
    }

    [MenuItem("Settings/ModifyLegacy Launch Images")]
    public static void ModifyLegacyLaunchImages()
    {
        const string projectSettings = "ProjectSettings/ProjectSettings.asset";

        UnityEngine.Object obj = UnityEditor.AssetDatabase.LoadAllAssetsAtPath(projectSettings)[0];

        SerializedObject psObj = new SerializedObject(obj);

        SerializedProperty iPhoneSplashScreen = psObj.FindProperty("iPhoneSplashScreen");
        SerializedProperty iPhoneHighResSplashScreen = psObj.FindProperty("iPhoneHighResSplashScreen");
        SerializedProperty iPhoneTallHighResSplashScreen = psObj.FindProperty("iPhoneTallHighResSplashScreen");
        SerializedProperty iPhone55inPortraitSplashScreen = psObj.FindProperty("iPhone55inPortraitSplashScreen");
        SerializedProperty iPhone55inLandscapeSplashScreen = psObj.FindProperty("iPhone55inLandscapeSplashScreen");
        SerializedProperty iPhone58inPortraitSplashScreen = psObj.FindProperty("iPhone58inPortraitSplashScreen");
        SerializedProperty iPhone58inLandscapeSplashScreen = psObj.FindProperty("iPhone58inLandscapeSplashScreen");
        SerializedProperty iPadPortraitSplashScreen = psObj.FindProperty("iPadPortraitSplashScreen");
        SerializedProperty iPadHighResPortraitSplashScreen = psObj.FindProperty("iPadHighResPortraitSplashScreen");
        SerializedProperty iPadLandscapeSplashScreen = psObj.FindProperty("iPadLandscapeSplashScreen");
        SerializedProperty iPadHighResLandscapeSplashScreen = psObj.FindProperty("iPadHighResLandscapeSplashScreen");
        SerializedProperty iPhone47inSplashScreen = psObj.FindProperty("iPhone47inSplashScreen");

        var tex = GetLogoTex(LegacyLaunchImageTexName);
        if (tex)
        {
            iPhoneSplashScreen.objectReferenceInstanceIDValue = tex.GetInstanceID();
            iPhoneHighResSplashScreen.objectReferenceInstanceIDValue = tex.GetInstanceID();
            iPhoneTallHighResSplashScreen.objectReferenceInstanceIDValue = tex.GetInstanceID();
            iPhone55inPortraitSplashScreen.objectReferenceInstanceIDValue = tex.GetInstanceID();
            iPhone55inLandscapeSplashScreen.objectReferenceInstanceIDValue = tex.GetInstanceID();
            iPhone58inPortraitSplashScreen.objectReferenceInstanceIDValue = tex.GetInstanceID();
            iPhone58inLandscapeSplashScreen.objectReferenceInstanceIDValue = tex.GetInstanceID();
            iPadPortraitSplashScreen.objectReferenceInstanceIDValue = tex.GetInstanceID();
            iPadHighResPortraitSplashScreen.objectReferenceInstanceIDValue = tex.GetInstanceID();
            iPadLandscapeSplashScreen.objectReferenceInstanceIDValue = tex.GetInstanceID();
            iPadHighResLandscapeSplashScreen.objectReferenceInstanceIDValue = tex.GetInstanceID();
            iPhone47inSplashScreen.objectReferenceInstanceIDValue = tex.GetInstanceID();
        }

        psObj.ApplyModifiedProperties();
    }

    [MenuItem("Settings/ModifyIOSIcons")]
    public static void ModifyIOSIcons()
    {
        ModifyIcons(false, false);

    }

    [MenuItem("Settings/ClearIOSIcons")]
    public static void ClearIOSIcons()
    {
        ModifyIcons(false, true);
    }


    [MenuItem("Settings/ModifyAndroidIcons")]
    public static void ModifyAndroidIcons()
    {
        ModifyIcons(true, false);

    }

    [MenuItem("Settings/ClearAndroidIcons")]
    public static void ClearAndroidIcons()
    {
        ModifyIcons(true, true);
    }

    private static void ModifyIcons(bool isAndroid, bool isClear)
    {
        const string projectSettings = "ProjectSettings/ProjectSettings.asset";

        UnityEngine.Object obj = UnityEditor.AssetDatabase.LoadAllAssetsAtPath(projectSettings)[0];

        SerializedObject psObj = new SerializedObject(obj);

        SerializedProperty buildTargetPlatformIcons = psObj.FindProperty("m_BuildTargetPlatformIcons");
        var data1 = buildTargetPlatformIcons.GetArrayElementAtIndex(0);
        var childData = data1.FindPropertyRelative("m_Icons");
        if (isAndroid)
        {
            data1 = buildTargetPlatformIcons.GetArrayElementAtIndex(1);
            childData = data1.FindPropertyRelative("m_Icons");
        }

        var tex = GetLogoTex(IOSIconTexName);
        for (int count = 0; count < childData.arraySize; count++)
        {
            var childData0 = childData.GetArrayElementAtIndex(count);
            var texture = childData0.FindPropertyRelative("m_Textures");
            var width = childData0.FindPropertyRelative("m_Width");
            var subkind = childData0.FindPropertyRelative("m_SubKind");
            var kind = childData0.FindPropertyRelative("m_Kind");


            var setIosTexAction = new Action(() =>
            {
                if (tex)
                {

                    if (texture.arraySize > 0)
                    {
                        for (int id = 0; id < texture.arraySize; id++)
                        {
                            texture.GetArrayElementAtIndex(id).objectReferenceValue = null;
                            if (!isClear)
                                texture.GetArrayElementAtIndex(id).objectReferenceInstanceIDValue = tex.GetInstanceID();
                        }

                        if (isAndroid && kind.intValue == 2 && texture.arraySize == 1)
                        {
                            texture.InsertArrayElementAtIndex(1);
                            texture.GetArrayElementAtIndex(1).objectReferenceInstanceIDValue = tex.GetInstanceID();
                        }
                    }
                    else
                    {
                        if (!isClear)
                        {
                            texture.InsertArrayElementAtIndex(0);
                            texture.GetArrayElementAtIndex(0).objectReferenceInstanceIDValue = tex.GetInstanceID();

                            if (isAndroid && kind.intValue == 2)
                            {
                                texture.InsertArrayElementAtIndex(1);
                                texture.GetArrayElementAtIndex(1).objectReferenceInstanceIDValue = tex.GetInstanceID();
                            }
                        }

                    }

                }
            });

            var action = new Action(() =>
            {
                setIosTexAction.Invoke();
                //Application icons
                if (kind.intValue == 0)
                {
                    if (subkind.stringValue.Equals("iPhone"))
                    {

                    }
                    if (subkind.stringValue.Equals("iPad"))
                    {

                    }
                }
                //Spotlight icons
                if (kind.intValue == 1)
                {
                    if (subkind.stringValue.Equals("iPhone"))
                    {

                    }
                    if (subkind.stringValue.Equals("iPad"))
                    {

                    }

                }
                //Settings icons
                if (kind.intValue == 2)
                {
                    if (subkind.stringValue.Equals("iPhone"))
                    {

                    }
                    if (subkind.stringValue.Equals("iPad"))
                    {

                    }
                }
                //Notifications icons
                if (kind.intValue == 3)
                {
                    if (subkind.stringValue.Equals("iPhone"))
                    {

                    }
                    if (subkind.stringValue.Equals("iPad"))
                    {

                    }
                }
                //Marketing icons
                if (kind.intValue == 4)
                {

                }
            });

            action.Invoke();

        }



        psObj.ApplyModifiedProperties();

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        AssetDatabase.ForceReserializeAssets();
    }


    private static Texture2D GetLogoTex(string logoName)
    {
        var list = GetAllLocalSubDirs("Assets/");
        for (int id = 0; id < list.Count; id++)
        {
            var path = list[id] + "/" + logoName;
            var logoObj = AssetDatabase.LoadAssetAtPath<Texture2D>(path);
            if (logoObj)
            {
                return logoObj;
            }
        }

        return null;
    }


    public static List<string> GetAllLocalSubDirs(string rootPath)
    {
        if (string.IsNullOrEmpty(rootPath))
            return null;
        string fullRootPath = System.IO.Path.GetFullPath(rootPath);
        if (string.IsNullOrEmpty(fullRootPath))
            return null;

        string[] dirs = System.IO.Directory.GetDirectories(fullRootPath);
        if ((dirs == null) || (dirs.Length <= 0))
            return null;
        List<string> ret = new List<string>();

        for (int i = 0; i < dirs.Length; ++i)
        {
            string dir = GetAssetRelativePath(dirs[i]);
            ret.Add(dir);
        }
        for (int i = 0; i < dirs.Length; ++i)
        {
            string dir = dirs[i];
            List<string> list = GetAllLocalSubDirs(dir);
            if (list != null)
                ret.AddRange(list);
        }

        ret.Add(rootPath.TrimEnd('/'));
        return ret;
    }

    public static string GetAssetRelativePath(string fullPath)
    {
        if (string.IsNullOrEmpty(fullPath))
            return string.Empty;
        fullPath = fullPath.Replace("\\", "/");
        int index = fullPath.IndexOf("Assets/", StringComparison.CurrentCultureIgnoreCase);
        if (index < 0)
            return fullPath;
        string ret = fullPath.Substring(index);
        return ret;
    }


}
