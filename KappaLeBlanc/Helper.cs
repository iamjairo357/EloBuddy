﻿using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using Version = System.Version;

namespace KappaLeBlanc
{
    public class Helper
    {
        public static bool CastCheckbox(Menu obj, string value)
        {
            return obj[value].Cast<CheckBox>().CurrentValue;
        }
        public static int CastSlider(Menu obj, string value)
        {
            return obj[value].Cast<Slider>().CurrentValue;
        }

        public static AIHeroClient myHero { get { return ObjectManager.Player; } }

        public static float ComboDamage(AIHeroClient hero)
        {
            double damage = 0;
            if (Lib.Q.IsReady() && CastCheckbox(LBMenu.ComboM, "Q"))
            {
                damage += myHero.GetSpellDamage(hero, SpellSlot.Q);
            }
            if (Lib.W.IsReady() && CastCheckbox(LBMenu.ComboM, "W"))
            {
                damage += myHero.GetSpellDamage(hero, SpellSlot.W);
            }
            if (Lib.E.IsReady() && CastCheckbox(LBMenu.ComboM, "E"))
            {
                damage += myHero.GetSpellDamage(hero, SpellSlot.W);
            }
            if (Lib.R.IsReady() && CastCheckbox(LBMenu.ComboM, "R"))
            {
                damage += myHero.GetSpellDamage(hero, SpellSlot.R);
            }
            return (float)damage;
        }
        public static void CheckForUpdates()
        {
            string RawVersion = new WebClient().DownloadString("https://raw.githubusercontent.com/Phandaros/EloBuddy/master/" + Assembly.GetExecutingAssembly().GetName().Name + "/Properties/AssemblyInfo.cs");
            var Try = new Regex(@"\[assembly\: AssemblyVersion\(""(\d{1,})\.(\d{1,})\.(\d{1,})\.(\d{1,})""\)\]").Match(RawVersion);
            if (Try.Success)
            {
                if (new Version(string.Format("{0}.{1}.{2}.{3}", Try.Groups[1], Try.Groups[2], Try.Groups[3], Try.Groups[4])) > Assembly.GetExecutingAssembly().GetName().Version)
                {
                    Chat.Print("You have an older version of KappaLeblanc, please update :)", Color.Red);
                }
                else
                {
                    Chat.Print(Assembly.GetExecutingAssembly().GetName().Name + " loaded, Enjoy free elo Kappa", Color.AliceBlue);
                }
            }
        }
    }
}