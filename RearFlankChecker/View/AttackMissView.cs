using System;
using System.Windows.Forms;
using RearFlankChecker.Util;

namespace RearFlankChecker
{
    public partial class AttackMissView : Form
    {
        private PluginMain plugin;
        public AttackMissView(PluginMain _plugin)
        {
            InitializeComponent();

            this.plugin = _plugin;
            MoveByDrag = true;

            this.Move += AttackMissView_Move;
            this.MouseDown += AttackMissView_MouseDown;

            Reset();
        }


        private bool moveByDrag;
        public bool MoveByDrag
        {
            get { return moveByDrag; }
            set
            {
                moveByDrag = value;
                Win32APIUtils.SetWS_EX_TRANSPARENT(Handle, !moveByDrag);
            }
        }

        void AttackMissView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && MoveByDrag)
            {
                Win32APIUtils.DragMove(Handle);
            }
        }

        private void AttackMissView_Move(object sender, EventArgs e)
        {
            plugin.ACTTabControl.AttackMissView_Move(sender, e);
        }

        public void Reset()
        {
            dataGridView1.Rows.Clear();
            UpdateLayout();
        }

        public void CountUp(string skill)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if(row.Cells[0].Value != null)
                {
                    if (row.Cells[0].Value.ToString().Equals(skill))
                    {
                        int count = Convert.ToInt32(row.Cells[1].Value);
                        row.Cells[1].Value = ++count;
                        return;
                    }
                }
            }

            dataGridView1.Rows.Add(skill, 1);
            UpdateLayout();
        }

        private void UpdateLayout()
        {
            // グリッドの行数変化に合わせてフォームサイズも変える
            this.Height = this.dataGridView1.ColumnHeadersHeight + this.dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.None);
        }
    }




}
