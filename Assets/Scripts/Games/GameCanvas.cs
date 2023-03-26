// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.Games.GameCanvas
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 705B5AB7-C97A-43C5-B3FB-6A8B004045E9
// Assembly location: C:\Users\luuvi\Downloads\RongThanOnl\Rong Than Online_Data\Managed\Assembly-CSharp.dll

using Assets.Scripts.Actions;
using Assets.Scripts.Commons;
// using Assets.Scripts.Dialogs;
// using Assets.Scripts.GraphicCustoms;
using Assets.Scripts.IOs;
using Assets.Scripts.Models;
// using Assets.Scripts.Screens;
// using LitJson;

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using Assets.Scripts.GraphicCustoms;
using Assets.Scripts.Screens;
using LitJson;
using System.Collections;

namespace Assets.Scripts.Games
{
    public class GameCanvas : IActionListener
    {
        public static bool isLoading;
        // public static MyScreen currentScreen;
        public static bool isPointerJustDown = false;
        public static int gameTick;
        public static int w;
        public static int h;
        public static int hw;

        public static int hh;
        public static Image imgLoading;
        public static Image imgMenu;
        public static Image imageFlare;
        public static MyScreen currentScreen;


        // public static LoginScr loginScr;
        // public static HomeScr homeScr;
        // public static RegisterScr registerScr;
        // public static Menu menu;
        public static Image[] imgBorder = new Image[3];
        public static Image imgLbtn;
        public static Image imgLbtnFocus;
        // public static Paint paintz;
        // public static Dialog dialog = new Dialog();
        public static Image imgLogoScr;
        public static Image imgClear;
        public static GameCanvas instance = new GameCanvas();
        public static sbyte versionItemClient;
        public static sbyte versionItemServer;

        // public static List<ItemOptionTemplate> itemOptionTemplates;
        // public static List<ItemTemplate> itemTemplates;
        // public static Dictionary<int, Part> parts;
        public static Dictionary<int, Frame> frames;
        // public static SkillPaint[] skillPaints;
        // public static List<MobTemplate> mobTemplates;
        // public static List<NpcTemplate> npcTemplates;
        public static List<MapTemplate> mapTemplates;
        // public static List<SkillTemplate> skillTemplates;
        // public static List<SkillOptionTemplate> skillOptionTemplates;
        // public static List<Skill> skills;
        // public static List<SkillOptionJson> skillOptionJsons;
        // public static PanelScr panel;

        public GameCanvas()
        {
            // GameCanvas.paintz = new Paint();
            // GameCanvas.menu = new Menu();

            GameCanvas.w = (int)ScaleGUI.WIDTH;
            GameCanvas.h = (int)ScaleGUI.HEIGHT;
            GameCanvas.hw = w / 2;
            GameCanvas.hh = h / 2;
            Debug.Log("GameCanvas.w" + GameCanvas.w);
            GameCanvas.currentScreen = GameScr.gI();
            // GameCanvas.panel = new PanelScr();
            // GameCanvas.imgLoading = GameCanvas.loadImage("loading.png");
            // GameCanvas.imgMenu = GameCanvas.loadImage("myTexture2dmenu.png");
            // GameCanvas.imageFlare = GameCanvas.loadImage("myTexture2dflare.png");
            // GameCanvas.imgLbtn = GameCanvas.loadImage("myTexture2dbtnl.png");
            // GameCanvas.imgLbtnFocus = GameCanvas.loadImage("myTexture2dbtnlf.png");
            // GameCanvas.imgLogoScr = GameCanvas.loadImage("logohome.png");
            // for (int index = 0; index < 3; ++index)
            //     GameCanvas.imgBorder[index] = GameCanvas.loadImage("myTexture2dbd" + index.ToString() + ".png");
            // MyScreen.ITEM_HEIGHT = MyFont.text_big_white.getHeight() + 16;
            // GameCanvas.imgClear = GameCanvas.loadImage("imgClear.png");
            // GameCanvas.homeScr = new HomeScr();
            // GameCanvas.registerScr = new RegisterScr();
            sbyte[] numArray = Rms.loadRMS("RTitemVersion");
            if (numArray == null)
                return;
            GameCanvas.versionItemClient = numArray[0];

        }

        public static void loadJson()
        {
            try
            {


                // GameCanvas.parts = JsonConvert.DeserializeObject<Dictionary<int, Part>>(File.ReadAllText("Player//Part.json"));

                // GameCanvas.skillPaints = JsonMapper.ToObject<SkillPaint[]>(PlayerUtil.loadJson("SkillPaint"));
                // GameCanvas.npcTemplates = JsonMapper.ToObject<List<NpcTemplate>>(PlayerUtil.loadJson("Npc"));
                // GameCanvas.mapTemplates = JsonMapper.ToObject<List<MapTemplate>>(PlayerUtil.loadJson("Maps"));
                // GameCanvas.skillTemplates = JsonMapper.ToObject<List<SkillTemplate>>(PlayerUtil.loadJson("SkillTemplate"));
                // GameCanvas.skillOptionTemplates = JsonMapper.ToObject<List<SkillOptionTemplate>>(PlayerUtil.loadJson("SkillOptionTemplate"));
                // GameCanvas.skillOptionJsons = JsonMapper.ToObject<List<SkillOptionJson>>(PlayerUtil.loadJson("SkillOption"));
                // GameCanvas.itemTemplates = JsonMapper.ToObject<List<ItemTemplate>>(PlayerUtil.loadJson("ItemTemplate"));
                // GameCanvas.itemOptionTemplates = JsonMapper.ToObject<List<ItemOptionTemplate>>(PlayerUtil.loadJson("ItemOptionTemplate"));
                // GameCanvas.skills = new List<Skill>();
                // foreach (SkillTemplate skillTemplate in GameCanvas.skillTemplates)
                //     GameCanvas.skills.Add(new Skill()
                //     {
                //         id = skillTemplate.id,
                //         template = skillTemplate,
                //         level = 0
                //     });
                // foreach (SkillOptionJson skillOptionJson in GameCanvas.skillOptionJsons)
                //     GameCanvas.getSkillByTemplateId(skillOptionJson.templateId)?.options.Add(new SkillOption()
                //     {
                //         param = skillOptionJson.param,
                //         paramWithLevel = skillOptionJson.paramWithLevel,
                //         template = GameCanvas.getOptionTemplateById(skillOptionJson.optionId)
                //     });
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.ToString());
                LogFile.LogError("GameCanvas: " + ex.ToString());
            }
        }

        // public static List<Skill> createSkill(int gender)
        // {
        //     List<Skill> skill1 = new List<Skill>();
        //     foreach (Skill skill2 in GameCanvas.skills)
        //     {
        //         if (skill2.template.gender == gender || skill2.template.gender == -1)
        //         {
        //             Skill skill3 = new Skill();
        //             skill3.template = skill2.template;
        //             skill3.level = 0;
        //             foreach (SkillOption option in skill2.options)
        //                 skill3.options.Add(new SkillOption()
        //                 {
        //                     param = option.param,
        //                     paramWithLevel = option.paramWithLevel,
        //                     template = option.template
        //                 });
        //             skill1.Add(skill3);
        //         }
        //     }
        //     return skill1;
        // }

        // public static Skill getSkillByTemplateId(int id)
        // {
        //     foreach (Skill skill in GameCanvas.skills)
        //     {
        //         if (skill.template.id == id)
        //             return skill;
        //     }
        //     return (Skill)null;
        // }

        // public static SkillOptionTemplate getOptionTemplateById(int id)
        // {
        //     foreach (SkillOptionTemplate skillOptionTemplate in GameCanvas.skillOptionTemplates)
        //     {
        //         if (skillOptionTemplate.id == id)
        //             return skillOptionTemplate;
        //     }
        //     return (SkillOptionTemplate)null;
        // }

        public static void update()
        {
            ++GameCanvas.gameTick;
            if (GameCanvas.gameTick > 10000)
                GameCanvas.gameTick = 0;
            if (GameCanvas.gameTick % 2 == 0)
            {
                try
                {
                    // GameCanvas.parts = JsonConvert.DeserializeObject<Dictionary<int, Part>>(File.ReadAllText("Player//Part.json"));
                    Player.frames = JsonConvert.DeserializeObject<Dictionary<int, Dictionary<string, Frame>>>(File.ReadAllText("Player//SmallImages//Part.json"));
                }
                catch (Exception ex)
                {
                    Debug.Log(ex.ToString());
                    LogFile.LogError("Gamecanvas: " + ex.ToString());
                }
            }
            try
            {
                if (GameCanvas.currentScreen != null)
                    GameCanvas.currentScreen.updateKey();
                if (GameCanvas.currentScreen != null)
                {
                    // if (GameCanvas.dialog.isShow)
                    //     GameCanvas.dialog.update();
                    // else if (GameCanvas.menu.isShow)
                    //     GameCanvas.menu.update();
                    // if (GameCanvas.panel.isShow)
                    //     GameCanvas.panel.update();
                    if (!GameCanvas.isLoading)
                        GameCanvas.currentScreen.update();
                }
                // InfoDlg.update();
            }
            catch
            {
            }
        }

        public static void paint(MyGraphics g)
        {
            try
            {
                if (GameCanvas.currentScreen != null)
                    GameCanvas.currentScreen.paint(g);
                // g.translate(-g.getTranslateX(), -g.getTranslateY());
                // g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
                // // if (GameCanvas.panel.isShow)
                // //     GameCanvas.panel.paint(g);
                // g.translate(-g.getTranslateX(), -g.getTranslateY());
                // g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
                // InfoDlg.paint(g);
                // if (GameCanvas.dialog.isShow)
                //     GameCanvas.dialog.paint(g);
                // else if (GameCanvas.menu.isShow)
                //     GameCanvas.menu.paint(g);
                // InfoMe.paint(g);
                // if (Player.isLoadingMap)
                //     GameCanvas.paintChangeMap(g);
                // GameCanvas.resetTrans(g);
            }
            catch
            {
            }
        }


        public static void paintBGGameScr(MyGraphics g)
        {
            // if (Player.isLoadingMap)
            //     return;
            g.translate(-g.getTranslateX(), -g.getTranslateY());
            g.setColor(999999999);
            g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
        }

        public static Image loadImage(string path)
        {
            path = GameCanvas.cutPng(path);
            Image image = (Image)null;
            try
            {
                return Image.createImage(path);
            }
            catch (Exception ex)
            {
                Debug.Log((object)ex.ToString());
                return image;
            }
        }

        public static string cutPng(string str)
        {
            string str1 = str;
            if (str.Contains(".png"))
                str1 = str.Replace(".png", string.Empty);
            return str1;
        }

        public static void keyPress(KeyCode keyCode)
        {
            // if (GameCanvas.dialog.isShow)
            //     GameCanvas.dialog.keyPress(keyCode);
            // else if (GameCanvas.menu.isShow)
            //     GameCanvas.menu.keyPress(keyCode);
            // else if (GameCanvas.panel.isShow)
            // {
            //     GameCanvas.panel.keyPress(keyCode);
            // }
            // else
            // {
            //     if (GameCanvas.currentScreen == null)
            //         return;
            GameCanvas.currentScreen.keyPress(keyCode);
            // }
        }

        public static void pointerReleased(int x, int y)
        {
            // if (GameCanvas.dialog.isShow)
            //     GameCanvas.dialog.pointerReleased(x, y);
            // else if (GameCanvas.menu.isShow)
            //     GameCanvas.menu.pointerReleased(x, y);
            // else if (GameCanvas.panel.isShow)
            // {
            //     GameCanvas.panel.pointerReleased(x, y);
            // }
            // else
            // {
            //     if (GameCanvas.currentScreen == null)
            //         return;

            GameCanvas.currentScreen.pointerReleased(x, y);
            // }
        }
        public static void pointerDragged(int x, int y)
        {

            GameCanvas.currentScreen.pointerDragged(x, y);
        }
        public static void pointerClicked(int x, int y)
        {

            // if (GameCanvas.dialog.isShow)
            //     GameCanvas.dialog.pointerClicked(x, y);
            // else if (GameCanvas.menu.isShow)
            //     GameCanvas.menu.pointerClicked(x, y);
            // else if (GameCanvas.panel.isShow)
            // {
            //     GameCanvas.panel.pointerClicked(x, y);
            // }
            // else
            // {
            //     if (GameCanvas.currentScreen == null)
            //         return;
            GameCanvas.currentScreen.pointerClicked(x, y);
            // }
        }

        public static void pointerMove(int x, int y)
        {
            // if (GameCanvas.dialog.isShow)
            //     GameCanvas.dialog.pointerMove(x, y);
            // else if (GameCanvas.menu.isShow)
            //     GameCanvas.menu.pointerMove(x, y);
            // else if (GameCanvas.panel.isShow)
            // {
            //     GameCanvas.panel.pointerMove(x, y);
            // }
            // else
            // {
            //     if (GameCanvas.currentScreen == null)
            //         return;

            GameCanvas.currentScreen.pointerMove(x, y);
            // }
        }

        public void perform(int idAction, object p)
        {
            // switch (idAction)
            // {
            //     case 1:
            //         GameCanvas.dialog.isShow = false;
            //         break;
            //     case 2:
            //         GameCanvas.dialog.isShow = false;
            //         Application.OpenURL(GameMidlet.LINKWEB);
            //         GameMidlet.exit();
            //         break;
            // }
        }

        // public static void startOKDlg(string info) => GameCanvas.dialog.setInfo(info, (Command)null, new Command(PlayerText.OK, (IActionListener)GameCanvas.instance, 1, (object)null), (Command)null);

        // public static void startOKDlgOpenUrl(string info) => GameCanvas.dialog.setInfo(info, (Command)null, new Command(PlayerText.OK, (IActionListener)GameCanvas.instance, 2, (object)null), (Command)null);

        // public static void startWaitDlg(string info) => GameCanvas.dialog.setInfo(info, (Command)null, new Command(PlayerText.CANCEL, (IActionListener)GameCanvas.instance, 1, (object)null), (Command)null);

        // public static void startOKDlg(string info, bool isError) => GameCanvas.dialog.setInfo(info, (Command)null, new Command(PlayerText.CANCEL, (IActionListener)GameCanvas.instance, 1, (object)null), (Command)null);

        // public static void startWaitDlg() => Player.isLoadingMap = true;
    }
}
