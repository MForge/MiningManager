using System;
using System.IO;
using System.Windows.Forms;

namespace MiningManager
{
    public partial class MinerFrm : Form
    {
        private Miner m_miner;
        private bool m_minerAdded;
        private bool m_minerEdited;
        private bool editMode;
        private MinerList m_MinerList;
        private string oldName;
        private string oldPath;

        public MinerFrm(MinerList aMinerList)
        {
            InitializeComponent();
            m_minerAdded = false;
            m_minerEdited = false;
            m_MinerList = aMinerList;
            editMode = false;
        }

        public MinerFrm(string aPath, string aName, MinerList aMinerList)
        {
            InitializeComponent();
            m_minerAdded = false;
            m_minerEdited = false;
            m_MinerList = aMinerList;
            oldPath = tbMinerPath.Text = aPath;
            oldName = tbMinerName.Text = aName;

            if (aPath != "" && aName != "")
            {
                editMode = true;
            }
            else
            {
                editMode = false;
            }
        }

        internal Miner Miner
        {
            get
            {
                return m_miner;
            }

            set
            {
                m_miner = value;
            }
        }

        public bool MinerAdded
        {
            get
            {
                return m_minerAdded;
            }

            set
            {
                m_minerAdded = value;
            }
        }

        public bool MinerEdited
        {
            get
            {
                return m_minerEdited;
            }

            set
            {
                m_minerEdited = value;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveAndclosebtn_Click(object sender, EventArgs e)
        {
            if (tbMinerPath.Text == "")
            {
                MessageBox.Show("Please initialize the path to your mining software.", "Mining Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (tbMinerName.Text == "")
            {
                MessageBox.Show("Please give a name to your mining software", "Mining Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!File.Exists(tbMinerPath.Text))
            {
                MessageBox.Show(@"This directory don't contains your miner software", "Mining Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (editMode)
            {
                foreach (Miner cd in m_MinerList)
                {
                    if (cd.Name == oldName && cd.Path == oldPath)
                    {
                        cd.Name = tbMinerName.Text;
                        cd.Path = tbMinerPath.Text;
                        m_minerEdited = true;
                        break;
                    }
                }
                this.Close();
            }
            else
            {
                if (isClientAlreadyReferenced())
                {
                    MessageBox.Show(@"This mining software is already in your miner list", "Mining Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    m_miner = new Miner(tbMinerName.Text, tbMinerPath.Text);
                    m_minerAdded = true;
                    this.Close();
                }
            }
        }

        private bool isClientAlreadyReferenced()
        {
            bool toReturn = false;
            if (m_MinerList.content(tbMinerPath.Text, tbMinerName.Text))
            {
                toReturn = true;
            }
            return toReturn;
        }

        private void filedialofBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"c:\";
            //openFileDialog1.Filter = @"dll files (game.dll)|game.dll";
            //openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbMinerPath.Text = openFileDialog1.FileName; //Path.GetDirectoryName(openFileDialog1.FileName) + @"\";

                if (!File.Exists(tbMinerPath.Text))
                {
                    MessageBox.Show(@"This directory don't contains your miner software.", "Mining Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}