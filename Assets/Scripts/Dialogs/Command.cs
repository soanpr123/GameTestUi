// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.Dialogs.Command
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 705B5AB7-C97A-43C5-B3FB-6A8B004045E9
// Assembly location: C:\Users\luuvi\Downloads\RongThanOnl\Rong Than Online_Data\Managed\Assembly-CSharp.dll

using Assets.Scripts.Actions;
using Assets.Scripts.GraphicCustoms;

namespace Assets.Scripts.Dialogs
{
    public class Command
    {
        public string caption;
        public string[] subCaption;
        public IActionListener actionListener;
        public int idAction;
        public int x;
        public int y;
        public int w;
        public int h;
        public bool isFocus;
        public object p;
        public bool isMini;

        public Command(
          string caption,
          IActionListener actionListener,
          int action,
          object p,
          int x,
          int y)
        {
            this.caption = caption;
            this.idAction = action;
            this.actionListener = actionListener;
            this.p = p;
            this.x = x;
            this.y = y;
            this.w = 220;
            this.h = 65;
            this.isMini = false;
        }

        public Command(string caption, IActionListener actionListener, int action, object p)
        {
            this.caption = caption;
            this.idAction = action;
            this.actionListener = actionListener;
            this.p = p;
            this.w = 220;
            this.h = 65;
            this.isMini = false;
        }

        public Command(
          string caption,
          IActionListener actionListener,
          int action,
          object p,
          int x,
          int y,
          bool isMini)
        {
            this.caption = caption;
            this.idAction = action;
            this.actionListener = actionListener;
            this.p = p;
            this.x = x;
            this.y = y;
            this.w = 128;
            this.h = 37;
            this.isMini = isMini;
        }

        public Command(
          string caption,
          IActionListener actionListener,
          int action,
          object p,
          bool isMini)
        {
            this.caption = caption;
            this.idAction = action;
            this.actionListener = actionListener;
            this.p = p;
            this.w = 130;
            this.h = 40;
            this.isMini = isMini;
        }

        public void paint(MyGraphics g)
        {
            if (this.isMini)
            {
                if (this.caption != string.Empty)
                {
                    g.setColor(119f, 69f, 6f);
                    g.fillRect(this.x, this.y, this.w, this.h, 10, 10, 10, 10);
                    if (!this.isFocus)
                        g.setColor(246f, 181f, 115f);
                    else
                        g.setColor(219f, 119f, 21f);
                    g.fillRect(this.x + 2, this.y + 2, this.w - 4, this.h - 4, 8, 8, 8, 8);
                }
                if (this.isFocus)
                    MyFont.text_mini_white.drawString(g, this.caption, this.x + this.w / 2, this.y + 8, 2);
                else
                    MyFont.text_mini_brown.drawString(g, this.caption, this.x + this.w / 2, this.y + 8, 2);
            }
            else
            {
                if (this.caption != string.Empty)
                {
                    g.setColor(119f, 69f, 6f);
                    g.fillRect(this.x, this.y, this.w, this.h, 16, 16, 16, 16);
                    if (!this.isFocus)
                        g.setColor(246f, 181f, 115f);
                    else
                        g.setColor(219f, 119f, 21f);
                    g.fillRect(this.x + 4, this.y + 4, this.w - 8, this.h - 8, 12, 12, 12, 12);
                }
                if (this.isFocus)
                    MyFont.text_white.drawString(g, this.caption, this.x + this.w / 2, this.y + 16, 2);
                else
                    MyFont.text_brown.drawString(g, this.caption, this.x + this.w / 2, this.y + 16, 2);
            }
        }

        public void pointerClicked(int x, int y)
        {
            if (x < this.x || x > this.x + this.w || y < this.y || y > this.y + this.h)
                return;
            this.isFocus = true;
        }

        public void pointerReleased(int x, int y)
        {
            this.isFocus = false;
            if (x < this.x || x > this.x + this.w || y < this.y || y > this.y + this.h)
                return;
            this.isFocus = true;
            this.performAction();
        }

        public void pointerMove(int x, int y)
        {
            if (x >= this.x && x <= this.x + this.w && y >= this.y && y <= this.y + this.h)
                this.isFocus = true;
            else
                this.isFocus = false;
        }

        public void performAction()
        {
            if (this.idAction <= 0 || this.actionListener == null)
                return;
            this.isFocus = false;
            this.actionListener.perform(this.idAction, this.p);
        }
    }
}
