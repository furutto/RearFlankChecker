using System;
using System.Windows.Forms;

namespace RearFlankChecker
{
    public partial class ACTTabControl : UserControl
    {
        private PluginMain plugin;
        private bool updateFromOverlayMove;

        public ACTTabControl(PluginMain _plugin)
        {
            InitializeComponent();

            plugin = _plugin;
            updateFromOverlayMove = false;

            var settings = plugin.Settings;
            settings.AddControlSetting("SoundEnable", checkSoundEnable);

            settings.AddControlSetting("ViewVisible", checkViewVisible);
            settings.AddControlSetting("ViewMouseEnable", checkViewMouseEnable);
            settings.AddControlSetting("ViewX", udViewX);
            settings.AddControlSetting("ViewY", udViewY);

            plugin.AttackMissView.OpacityChanged += AttackMissView_OpacityChanged;

            AttackMissView_OpacityChanged(this, null);
            plugin.AttackMissView.Move += AttackMissView_Move;

            checkViewVisible_CheckedChanged(this, null);
            checkViewMouseEnable_CheckedChanged(this, null);
        }

        private void AttackMissView_Move(object sender, EventArgs e)
        {
            updateFromOverlayMove = true;
            udViewX.Value = plugin.AttackMissView.Left;
            udViewY.Value = plugin.AttackMissView.Top;
            updateFromOverlayMove = false;
        }

        private void AttackMissView_OpacityChanged(object sender, EventArgs e)
        {
            int percentage = (int)(plugin.AttackMissView.MyOpacity * 100);

            labelCurrOpacity.Text = String.Format("{0}%", percentage);

            percentage = Math.Min(trackBarOpacity.Maximum, percentage);
            percentage = Math.Max(trackBarOpacity.Minimum, percentage);
            trackBarOpacity.Value = percentage;
        }

        private void trackBarOpacity_Scroll(object sender, EventArgs e)
        {
            plugin.AttackMissView.MyOpacity = ((double)trackBarOpacity.Value) / 100;
        }

        private void checkViewVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (checkViewVisible.Checked)
            {
                plugin.AttackMissView.Show();
            }
            else
            {
                plugin.AttackMissView.Hide();
            }
        }

        private void checkViewMouseEnable_CheckedChanged(object sender, EventArgs e)
        {
            plugin.AttackMissView.MoveByDrag = checkViewMouseEnable.Checked;
        }

        public bool IsSoundEnable()
        {
            return checkSoundEnable.Checked;
        }

        private void udViewX_ValueChanged(object sender, EventArgs e)
        {
            if (!updateFromOverlayMove)
                plugin.AttackMissView.Left = (int)udViewX.Value;
        }

        private void udViewY_ValueChanged(object sender, EventArgs e)
        {
            if (!updateFromOverlayMove)
                plugin.AttackMissView.Top = (int)udViewY.Value;
        }
    }
}
