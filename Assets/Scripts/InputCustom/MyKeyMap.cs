using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InputCustoms
{
    public class MyKeyMap
    {
        // Token: 0x06000233 RID: 563 RVA: 0x0001BD24 File Offset: 0x00019F24
        static MyKeyMap()
        {
            MyKeyMap.keyInputs.Add(KeyCode.A);
            MyKeyMap.keyInputs.Add(KeyCode.B);
            MyKeyMap.keyInputs.Add(KeyCode.C);
            MyKeyMap.keyInputs.Add(KeyCode.D);
            MyKeyMap.keyInputs.Add(KeyCode.E);
            MyKeyMap.keyInputs.Add(KeyCode.F);
            MyKeyMap.keyInputs.Add(KeyCode.G);
            MyKeyMap.keyInputs.Add(KeyCode.H);
            MyKeyMap.keyInputs.Add(KeyCode.I);
            MyKeyMap.keyInputs.Add(KeyCode.J);
            MyKeyMap.keyInputs.Add(KeyCode.K);
            MyKeyMap.keyInputs.Add(KeyCode.L);
            MyKeyMap.keyInputs.Add(KeyCode.M);
            MyKeyMap.keyInputs.Add(KeyCode.N);
            MyKeyMap.keyInputs.Add(KeyCode.O);
            MyKeyMap.keyInputs.Add(KeyCode.P);
            MyKeyMap.keyInputs.Add(KeyCode.Q);
            MyKeyMap.keyInputs.Add(KeyCode.R);
            MyKeyMap.keyInputs.Add(KeyCode.S);
            MyKeyMap.keyInputs.Add(KeyCode.T);
            MyKeyMap.keyInputs.Add(KeyCode.U);
            MyKeyMap.keyInputs.Add(KeyCode.V);
            MyKeyMap.keyInputs.Add(KeyCode.W);
            MyKeyMap.keyInputs.Add(KeyCode.X);
            MyKeyMap.keyInputs.Add(KeyCode.Y);
            MyKeyMap.keyInputs.Add(KeyCode.Z);
            MyKeyMap.keyInputs.Add(KeyCode.Space);
            MyKeyMap.keyInputs.Add(KeyCode.BackQuote);
            MyKeyMap.keyInputs.Add(KeyCode.Alpha0);
            MyKeyMap.keyInputs.Add(KeyCode.Alpha1);
            MyKeyMap.keyInputs.Add(KeyCode.Alpha2);
            MyKeyMap.keyInputs.Add(KeyCode.Alpha3);
            MyKeyMap.keyInputs.Add(KeyCode.Alpha4);
            MyKeyMap.keyInputs.Add(KeyCode.Alpha5);
            MyKeyMap.keyInputs.Add(KeyCode.Alpha6);
            MyKeyMap.keyInputs.Add(KeyCode.Alpha7);
            MyKeyMap.keyInputs.Add(KeyCode.Alpha8);
            MyKeyMap.keyInputs.Add(KeyCode.Alpha9);
            MyKeyMap.keyInputs.Add(KeyCode.Minus);
            MyKeyMap.keyInputs.Add(KeyCode.Plus);
            MyKeyMap.keyInputs.Add(KeyCode.Tilde);
            MyKeyMap.keyInputs.Add(KeyCode.Exclaim);
            MyKeyMap.keyInputs.Add(KeyCode.At);
            MyKeyMap.keyInputs.Add(KeyCode.Hash);
            MyKeyMap.keyInputs.Add(KeyCode.Dollar);
            MyKeyMap.keyInputs.Add(KeyCode.Percent);
            MyKeyMap.keyInputs.Add(KeyCode.Caret);
            MyKeyMap.keyInputs.Add(KeyCode.Ampersand);
            MyKeyMap.keyInputs.Add(KeyCode.Asterisk);
            MyKeyMap.keyInputs.Add(KeyCode.LeftParen);
            MyKeyMap.keyInputs.Add(KeyCode.RightParen);
            MyKeyMap.keyInputs.Add(KeyCode.Underscore);
            MyKeyMap.keyInputs.Add(KeyCode.LeftBracket);
            MyKeyMap.keyInputs.Add(KeyCode.RightBracket);
            MyKeyMap.keyInputs.Add(KeyCode.Backslash);
            MyKeyMap.keyInputs.Add(KeyCode.Semicolon);
            MyKeyMap.keyInputs.Add(KeyCode.DoubleQuote);
            MyKeyMap.keyInputs.Add(KeyCode.Period);
            MyKeyMap.keyInputs.Add(KeyCode.Comma);
            MyKeyMap.keyInputs.Add(KeyCode.Slash);
            MyKeyMap.keyInputs.Add(KeyCode.LeftCurlyBracket);
            MyKeyMap.keyInputs.Add(KeyCode.RightCurlyBracket);
            MyKeyMap.keyInputs.Add(KeyCode.Pipe);
            MyKeyMap.keyInputs.Add(KeyCode.Less);
            MyKeyMap.keyInputs.Add(KeyCode.Greater);
            MyKeyMap.keyInputs.Add(KeyCode.Question);
            MyKeyMap.keyInputs.Add(KeyCode.Colon);
            MyKeyMap.keyActions = new List<KeyCode>();
            MyKeyMap.keyActions.Add(KeyCode.F1);
            MyKeyMap.keyActions.Add(KeyCode.F2);
            MyKeyMap.keyActions.Add(KeyCode.Tab);
            MyKeyMap.keyActions.Add(KeyCode.UpArrow);
            MyKeyMap.keyActions.Add(KeyCode.DownArrow);
            MyKeyMap.keyActions.Add(KeyCode.LeftArrow);
            MyKeyMap.keyActions.Add(KeyCode.RightArrow);
            MyKeyMap.keyActions.Add(KeyCode.Return);
            MyKeyMap.keyActions.Add(KeyCode.Backspace);
            MyKeyMap.keyActions.Add(KeyCode.LeftShift);
            MyKeyMap.keyActions.Add(KeyCode.RightShift);
            MyKeyMap.keyActions.Add(KeyCode.KeypadEnter);
        }

        // Token: 0x040002B4 RID: 692
        public static List<KeyCode> keyInputs = new List<KeyCode>();

        // Token: 0x040002B5 RID: 693
        public static List<KeyCode> keyActions;
    }
}