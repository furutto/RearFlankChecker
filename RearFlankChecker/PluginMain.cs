using Advanced_Combat_Tracker;
using System;
using System.Windows.Forms;
using RearFlankChecker.Util;
using System.Media;

namespace RearFlankChecker
{
    public class PluginMain : IActPluginV1
    {
        public PluginSettings Settings { get; private set; }
        public ACTTabControl ACTTabControl { get; private set; }
        public AttackMissView AttackMissView { get; private set; }
        private SoundPlayer soundPlayer;
        private String actorId;

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            Settings = new PluginSettings(this);
            Settings.AddIntSetting("OpacityPercentage");

            AttackMissView = new AttackMissView();

            ACTTabControl = new ACTTabControl(this);
            pluginScreenSpace.Text = "Rear And Flank Checker";
            pluginScreenSpace.Controls.Add(ACTTabControl);
            ACTTabControl.Show();

            Settings.Load();

            String path = ResourceLocator.findResourcePath("resources/wav/miss.wav");
            if(path != null)
                soundPlayer = new SoundPlayer(path);
            
            ActGlobals.oFormActMain.AfterCombatAction += AfterCombatAction;
            ActGlobals.oFormActMain.OnCombatStart += CombatStarted;
            ActGlobals.oFormActMain.OnLogLineRead += OnLogLineRead;
        }

        public void DeInitPlugin()
        {
            ActGlobals.oFormActMain.AfterCombatAction -= AfterCombatAction;
            ActGlobals.oFormActMain.OnCombatStart -= CombatStarted;
            ActGlobals.oFormActMain.OnLogLineRead -= OnLogLineRead;

            if (Settings != null)
                Settings.Save();

            if (AttackMissView != null)
                AttackMissView.Close();

            if (soundPlayer != null)
            {
                soundPlayer.Dispose();
            }
        }

        private void CombatStarted(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            actorId = null;
            AttackMissView.Reset();
        }

        private void AfterCombatAction(bool isImport, CombatActionEventArgs actionInfo)
        {
            if (CombatActionChecker.IsMySkill(actionInfo))
            {
                if (actorId == null)
                {
                    actorId = CombatActionChecker.GetActorId(actionInfo);
                }

                if (!CombatActionChecker.JudgeFlankOrRearSkill(actionInfo))
                {
                    AttackMissView.CountUp(actionInfo.theAttackType);

                    if (soundPlayer != null && ACTTabControl.IsSoundEnable())
                    {
                        soundPlayer.Play();
                    }
                }
            }
        }

        private void OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            String logLine = logInfo.logLine;

            // "[07:23:04.000] 15:FFFFFF"
            if (logLine.Length < 18)
            {
                return;
            }

            // 15: から始まるなら 戦闘スキル発動っぽい
            if (!logLine.Substring(15, 3).Equals("15:"))
                return;


            string[] lineDatas = logLine.Split(':');


            if (lineDatas.Length < 16)
            {
                return;
            }

            if (!lineDatas[3].Equals(actorId))
            {
                return;
            }

            if (!CombatActionChecker.JudgeFlankOrRearSkillForLog(lineDatas, actorId))
            {
                AttackMissView.CountUp(lineDatas[6]);

                if (soundPlayer != null && ACTTabControl.IsSoundEnable())
                {
                    soundPlayer.Play();
                }
            }
        }

        public int OpacityPercentage
        {
            get { return (int)(AttackMissView.MyOpacity * 100.0); }
            set { AttackMissView.MyOpacity = (double)value / 100.0; }
        }

    }

}
