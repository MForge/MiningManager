using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MiningManager
{
    public partial class MinerListFrm : Form
    {
        private Settings m_settings;

        public MinerListFrm(Settings aSettings, bool forceAddMiner = false)
        {
            InitializeComponent();

            m_settings = aSettings;

            if (forceAddMiner)
            {
                addNewClient();
            }

            showMiners();
        }

        private void showMiners()
        {
            dgvMinsers.Rows.Clear();
            dgvMinsers.Refresh();

            int minersCount = m_settings.MinerList.count();

            foreach (Miner m in m_settings.MinerList)
            {
                DataGridViewRow row = new DataGridViewRow();

                row.DefaultCellStyle.ForeColor = checkMinerSoftware(m.Path) == false ? Color.Red : Color.Black;

                if (minersCount == 1)
                {
                    row.CreateCells(dgvMinsers, Properties.Resources.WithImg, Properties.Resources.edit, Properties.Resources.delete, m.Name, m.Path, Properties.Resources.WithImg, Properties.Resources.WithImg);
                }
                else
                {
                    if (m.Order == 1)
                    {
                        row.CreateCells(dgvMinsers, Properties.Resources.WithImg, Properties.Resources.edit, Properties.Resources.delete, m.Name, m.Path, Properties.Resources.WithImg, Properties.Resources.go_down);
                    }
                    else if (m.Order == minersCount)
                    {
                        row.CreateCells(dgvMinsers, Properties.Resources.WithImg, Properties.Resources.edit, Properties.Resources.delete, m.Name, m.Path, Properties.Resources.go_up, Properties.Resources.WithImg);
                    }
                    else
                    {
                        row.CreateCells(dgvMinsers, Properties.Resources.WithImg, Properties.Resources.edit, Properties.Resources.delete, m.Name, m.Path, Properties.Resources.go_up, Properties.Resources.go_down);
                    }
                }

                dgvMinsers.Rows.Add(row);
            }
            DataGridViewRow extraRow = new DataGridViewRow();
            extraRow.DefaultCellStyle.ForeColor = Color.Green;
            extraRow.CreateCells(dgvMinsers, Properties.Resources.list_add, Properties.Resources.WithImg, Properties.Resources.WithImg, "", "Click + to add a new link", Properties.Resources.WithImg, Properties.Resources.WithImg);
            dgvMinsers.Rows.Add(extraRow);
        }

        private bool checkMinerSoftware(string ClientPath)
        {
            return File.Exists(ClientPath);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            if (m_settings.MinerList.count() == 0)
            {
                DialogResult frwInstall = MessageBox.Show(@"To work the Mining Manager needs a link to a mining software. " + Environment.NewLine + "Do you really close this windows ?", "Mining Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (frwInstall == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMinsers.CurrentCell.ColumnIndex.Equals(0) && e.RowIndex != -1 && dgvMinsers.Rows[dgvMinsers.CurrentCell.RowIndex].Cells[4].Value.ToString() == "Click + to add a new link")
            {
                // Add
                addNewClient();
            }
            else if (dgvMinsers.CurrentCell.ColumnIndex.Equals(1) && e.RowIndex != -1 && dgvMinsers.Rows[dgvMinsers.CurrentCell.RowIndex].Cells[4].Value.ToString() != "Click + to add a new link")
            {
                // Edit
                addNewClient(dgvMinsers.Rows[dgvMinsers.CurrentCell.RowIndex].Cells[4].Value.ToString(), dgvMinsers.Rows[dgvMinsers.CurrentCell.RowIndex].Cells[3].Value.ToString());
            }
            else if (dgvMinsers.CurrentCell.ColumnIndex.Equals(2) && e.RowIndex != -1 && dgvMinsers.Rows[dgvMinsers.CurrentCell.RowIndex].Cells[4].Value.ToString() != "Click + to add a new link")
            {
                // Dell
                DialogResult frwInstall = MessageBox.Show("Do you realy want to delete this link (" + dgvMinsers.Rows[dgvMinsers.CurrentCell.RowIndex].Cells[3].Value.ToString() + ") ?", "Mining Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (frwInstall == DialogResult.Yes)
                {
                    m_settings.MinerList.delete(dgvMinsers.Rows[dgvMinsers.CurrentCell.RowIndex].Cells[3].Value.ToString(), dgvMinsers.Rows[dgvMinsers.CurrentCell.RowIndex].Cells[4].Value.ToString());
                    //m_settings.saveToXml();
                    showMiners();
                }
            }
            else if (dgvMinsers.CurrentCell.ColumnIndex.Equals(5) && e.RowIndex != -1 && dgvMinsers.Rows[dgvMinsers.CurrentCell.RowIndex].Cells[4].Value.ToString() != "Click + to add a new link")
            {
                // up
                switchclients(true);
            }
            else if (dgvMinsers.CurrentCell.ColumnIndex.Equals(6) && e.RowIndex != -1 && dgvMinsers.Rows[dgvMinsers.CurrentCell.RowIndex].Cells[4].Value.ToString() != "Click + to add a new link")
            {
                // down
                switchclients(false);
            }
        }

        private void switchclients(bool up)
        {
            int cmpClient = m_settings.MinerList.count();

            if (cmpClient > 1)
            {
                bool changed = false;
                if (up)
                {
                    for (int index = 0; index <= cmpClient; index++)
                    {
                        Miner m = m_settings.MinerList.getMiner(index);

                        if (m.Name == dgvMinsers.Rows[dgvMinsers.CurrentCell.RowIndex].Cells[3].Value.ToString() &&
                            m.Path == dgvMinsers.Rows[dgvMinsers.CurrentCell.RowIndex].Cells[4].Value.ToString())
                        {
                            if (index == 0) // first record pas d'up
                                break;
                            m.Order--;
                            m_settings.MinerList.getMiner(index - 1).Order++;
                            changed = true;
                            break;
                        }

                        

                    }
                }
                else // down
                {
                    for (int index = 0; index <= cmpClient; index++)
                    {
                        Miner m = m_settings.MinerList.getMiner(index);

                        if (m.Name == dgvMinsers.Rows[dgvMinsers.CurrentCell.RowIndex].Cells[3].Value.ToString() &&
                            m.Path == dgvMinsers.Rows[dgvMinsers.CurrentCell.RowIndex].Cells[4].Value.ToString())
                        {
                            if (index == cmpClient - 1) // first record pas d'up
                                break;

                            m.Order++;
                            m_settings.MinerList.getMiner(index + 1).Order--;
                            changed = true;
                            break;
                        }
                    }
                }

                if (changed)
                {
                    m_settings.MinerList.Sort();
                    //m_settings.saveToXml();
                    showMiners();
                }
            }
        }

        private void addNewClient(string aPath = "", string aName = "")
        {
            MinerFrm newMinerFrm = new MinerFrm(aPath, aName, m_settings.MinerList);
            newMinerFrm.ShowDialog();
            if (newMinerFrm.MinerAdded)
            {
                newMinerFrm.Miner.Order = m_settings.MinerList.count() + 1;
                m_settings.MinerList.add(newMinerFrm.Miner);
                //m_settings.saveToXml();
                showMiners();
            }
            else if (newMinerFrm.MinerEdited)
            {
                //m_settings.saveToXml();
                showMiners();
            }
        }
    }
}
