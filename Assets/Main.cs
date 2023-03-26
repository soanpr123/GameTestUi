using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Assets.Scripts.Games;
using Assets.Scripts.GraphicCustoms;
using Assets.Scripts.InputCustoms;
using Assets.Scripts.IOs;
using Assets.Scripts.Models;
using UnityEngine;

public class Main : MonoBehaviour
{// Token: 0x04000001 RID: 1
    public static bool isStarted;

    // Token: 0x04000002 RID: 2
    public static bool isPC;

    // Token: 0x04000003 RID: 3
    public static int count;

    // Token: 0x04000004 RID: 4
    private static bool isRun;

    // Token: 0x04000005 RID: 5
    public static Main main;

    // Token: 0x04000006 RID: 6
    public static string mainThreadName;

    // Token: 0x04000007 RID: 7
    public static MyGraphics g;
    public static GameCanvas gameCanvas;

    // Token: 0x04000008 RID: 8
    public static int f;
    void Start()
    {
        bool flag = !Main.isStarted;
        if (flag)
        {
            bool flag2 = Thread.CurrentThread.Name != "Main";
            if (flag2)
            {
                Thread.CurrentThread.Name = "Main";
            }
            Main.mainThreadName = Thread.CurrentThread.Name;
            Main.isStarted = true;
            Main.isPC = true;
            bool flag3 = Main.isPC;
            if (flag3)
            {
                Screen.SetResolution(1366, 768, false);
            }
        }

    }
    private void OnGUI()
    {
        if (Main.count < 10)
            return;
        this.checkInput();
        // Session.update();
        if (Event.current.type.Equals((object)EventType.Repaint))
        {
            GameCanvas.paint(Main.g);
            Main.g.reset();
        }
    }
    private void FixedUpdate()
    {
        Main.mainThreadName = "Main";
        Main.isPC = true;
        // Rms.update();
        Main.count++;
        bool flag = Main.count >= 10;
        if (flag)
        {
            this.setsizeChange();
            GameCanvas.update();
            Image.update();
            DataInputStream.update();
            Main.f++;
            bool flag2 = Main.f > 8;
            if (flag2)
            {
                Main.f = 0;
            }
        }

    }
    private void SetInit()
    {
        base.enabled = true;
    }
    private void OnApplicationQuit()
    {
        // Session.close();
        bool flag = Main.isPC;
        if (flag)
        {
            Application.Quit();
        }
    }

    // 	public void doClearRMS()
    // {
    // 	if (isPC)
    // 	{
    // 		int num = Rms.loadRMSInt("lastZoomlevel");
    // 		if (num != mGraphics.zoomLevel)
    // 		{
    // 			Rms.clearAll();
    // 			Rms.saveRMSInt("lastZoomlevel", mGraphics.zoomLevel);
    // 			Rms.saveRMSInt("levelScreenKN", level);
    // 		}
    // 	}
    // }
    private void OnHideUnity(bool isGameShown)
    {
        bool flag = !isGameShown;
        if (flag)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void setsizeChange()
    {
        bool flag = !Main.isRun;
        if (flag)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            Application.runInBackground = true;
            Application.targetFrameRate = -1;
            base.useGUILayout = false;
            bool flag2 = Main.main == null;
            if (flag2)
            {
                Main.main = this;
            }
            Main.isRun = true;
            ScaleGUI.initScaleGUI();
            bool flag3 = Main.isPC;
            if (flag3)
            {
                Screen.fullScreen = false;
            }

            g = new MyGraphics();
            gameCanvas = new GameCanvas();
            GameCanvas.loadJson();
            // Main.g.CreateLineMaterial();
        }
    }
    private void checkInput()
    {
        bool mouseButtonDown = Input.GetMouseButtonDown(0);
        if (mouseButtonDown)
        {

            Vector3 mousePosition = Input.mousePosition;
            GameCanvas.pointerClicked((int)mousePosition.x, (int)((float)Screen.height - mousePosition.y));

        }

        bool mouseButton = Input.GetMouseButton(0);
        if (mouseButton)
        {
            Vector3 mousePosition = Input.mousePosition;
            GameCanvas.pointerDragged((int)mousePosition.x, (int)((float)Screen.height - mousePosition.y));

        }
        bool mouseButtonUp = Input.GetMouseButtonUp(0);
        if (mouseButtonUp)
        {
            Vector3 mousePosition = Input.mousePosition;
            GameCanvas.pointerReleased((int)mousePosition.x, (int)((float)Screen.height - mousePosition.y));

        }

        bool flag = Main.isPC;
        if (flag)
        {
            GameCanvas.pointerMove((int)Input.mousePosition.x, (int)((float)Screen.height - Input.mousePosition.y));
        }
        bool flag2 = Input.anyKeyDown && Event.current.type == EventType.KeyDown && (MyKeyMap.keyInputs.Contains(Event.current.keyCode) || MyKeyMap.keyActions.Contains(Event.current.keyCode));
        if (flag2)
        {
            KeyCode keyCode = Event.current.keyCode;
            bool flag3 = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            if (flag3)
            {
                KeyCode keyCode2 = keyCode;
                KeyCode keyCode3 = keyCode2;
                if (keyCode3 != KeyCode.Minus)
                {
                    if (keyCode3 == KeyCode.Alpha2)
                    {
                        keyCode = KeyCode.At;
                    }
                }
                else
                {
                    keyCode = KeyCode.Underscore;
                }
            }
            GameCanvas.keyPress(keyCode);
        }
        bool flag4 = Input.anyKeyDown && Input.anyKeyDown;
        if (flag4)
        {
            EventType type = Event.current.type;
        }
        bool flag5 = Event.current.type == EventType.KeyUp && MyKeyMap.keyActions.Contains(Event.current.keyCode);
        if (flag5)
        {
            switch (Event.current.keyCode)
            {
                case KeyCode.UpArrow:
                    Player.isMoveUp = false;
                    break;
                case KeyCode.RightArrow:
                    Player.isMoveRight = false;
                    break;
                case KeyCode.LeftArrow:
                    Player.isMoveLeft = false;
                    break;
            }
        }
    }

}
