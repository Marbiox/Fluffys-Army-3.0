using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenUtils
{
    //resolution support
    static float screenWidth;
    static float screenHeight;

    //initialize variables
    static float screenLeft;
    static float screenRight;
    static float screenBottom;
    static float screenTop;

    //retrieves screen sizes
    public static float ScreenLeft
    {
        get
        {
            CheckResolutionChanges();
            return screenLeft;
        }
    }
    public static float ScreenRight
    {
        get
        {
            CheckResolutionChanges();
            return screenRight;
        }
    }
    public static float ScreenBottom
    {
        get
        {
            CheckResolutionChanges();
            return screenBottom;
        }
    }
    public static float ScreenTop
    {
        get
        {
            CheckResolutionChanges();
            return screenTop;
        }
    }

    
    public static void Initialize()
    {
        //updates for resolution changes
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        //gets cornors of world
        Vector3 lowerLeftCorner = Camera.main.ScreenToWorldPoint(new Vector3(0,0,0));
        Vector3 upperRightCorner = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth,screenHeight,0));

        //sets variables
        screenLeft = lowerLeftCorner.x;
        screenRight = upperRightCorner.x;
        screenBottom = lowerLeftCorner.y;
        screenTop = upperRightCorner.y;
    }

    public static void CheckResolutionChanges()
    {
        if (screenWidth != Screen.width || screenHeight != Screen.height)
        {
            Initialize();
        }
    }

}
