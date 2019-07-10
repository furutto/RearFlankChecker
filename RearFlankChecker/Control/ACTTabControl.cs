using RearFlankChecker.Util;
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
        }

        public void AttackMissView_Move(object sender, EventArgs e)
        {
            updateFromOverlayMove = true;
            udViewX.Value = plugin.AttackMissView.Left;
            udViewY.Value = plugin.AttackMissView.Top;
            updateFromOverlayMove = false;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            linkUpdate.Text = UpdateChecker.DoCheck();
        }

        private void linkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(UpdateChecker.GetReleaseFileUrl());
        }

        private void trackBarOpacity_ValueChanged(object sender, EventArgs e)
        {
            plugin.AttackMissView.Opacity = ((double)trackBarOpacity.Value) / 100;
            labelCurrOpacity.Text = String.Format("{0}%", trackBarOpacity.Value);
        }

        public void InitializeSettings()
        {
            linkUpdate.Text = "";
            checkSoundEnable.Checked = true;

            udViewX.Value = 100;
            udViewX_ValueChanged(this, null);

            udViewY.Value = 100;
            udViewY_ValueChanged(this, null);

            trackBarOpacity.Value = 70;
            trackBarOpacity_ValueChanged(this, null);

            checkViewMouseEnable.Checked = true;
            checkViewMouseEnable_CheckedChanged(this, null);

            checkViewVisible.Checked = true;
            checkViewVisible_CheckedChanged(this, null);
        }
    }
}
