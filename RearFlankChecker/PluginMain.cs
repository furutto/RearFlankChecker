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
        }

        public void DeInitPlugin()
        {
            ActGlobals.oFormActMain.AfterCombatAction -= AfterCombatAction;
            ActGlobals.oFormActMain.OnCombatStart -= CombatStarted;

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
            AttackMissView.Reset();
        }

        private void AfterCombatAction(bool isImport, CombatActionEventArgs actionInfo)
        {
            if (CombatActionChecker.IsMySkill(actionInfo))
            {
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

        public int OpacityPercentage
        {
            get { return (int)(AttackMissView.MyOpacity * 100.0); }
            set { AttackMissView.MyOpacity = (double)value / 100.0; }
        }

    }

}
