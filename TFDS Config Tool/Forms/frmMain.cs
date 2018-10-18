using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFDS_Config_Tool
{
    public partial class frmMain : Form
    {
        public string section, data;
        public static string settingsFile = @"C:\Users\user\AppData\LocalLow\SKS\TheForestDedicatedServer\ds\Server.cfg";
        StringBuilder sbText = new StringBuilder();

        public frmMain()
        {
            InitializeComponent();
            StartLoad();
            // Load Config Automatically
        }

        private void btnGetIP_Click(object sender, EventArgs e)
        {
            IPAddress ip = Dns.GetHostAddresses(Dns.GetHostName()).Where(address => address.AddressFamily == AddressFamily.InterNetwork).First();
            txtIP.Text = ip.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            sbText.AppendLine("// Dedicated Server Settings.");
            StartSave();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Use App ID: 242760");
            System.Diagnostics.Process.Start("https://steamcommunity.com/dev/managegameservers");
        }

        void StartLoad()
        {

            // Read each line of the file into a string array. Each element of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(settingsFile);

            // Display the file contents by using a foreach loop.
            foreach (string line in lines)
            {
                if (line != null || line != "")
                {
                    string _line = line;
                    if (_line.Substring(0, 2) != "//")
                    {
                        _line = line;
                        try
                        {
                            section = _line.Substring(0, _line.IndexOf(' '));
                            _line = line;
                            data = _line.Substring(_line.IndexOf(' '));
                        }
                        catch
                        {

                        }

                        if (section == "serverIP")
                        {
                            data = data.Replace(" ", "");
                            txtIP.Text = data;
                        }
                        if (section == "serverSteamPort")
                        {
                            data = data.Replace(" ", "");
                            txtSteamPort.Text = data;
                        }
                        if (section == "serverGamePort")
                        {
                            data = data.Replace(" ", "");
                            txtGamePort.Text = data;
                        }
                        if (section == "serverQueryPort")
                        {
                            data = data.Replace(" ", "");
                            txtQueryPort.Text = data;
                        }
                        if (section == "serverName")
                            txtServerName.Text = data.Substring(1, data.Length - 1);
                        if (section == "serverPlayers")
                        {
                            data = data.Replace(" ", "");
                            txtMaxPlayers.Text = data;
                        }
                        if (section == "enableVAC")
                        {
                            data = data.Replace(" ", "");
                            if (data == "on")
                            {
                                chkVAC.Checked = true;
                            }
                            else
                            {
                                chkVAC.Checked = false;
                            }
                        }
                        if (section == "serverPassword")
                        {   
                            txtPassword.Text = data.Substring(1, data.Length - 1);
                        }
                        if (section == "serverPasswordAdmin")
                        {
                            txtAdminPassword.Text = data.Substring(1, data.Length - 1);
                        }
                        if (section == "serverSteamAccount")
                        {   
                            txtSteamToken.Text = data.Substring(1, data.Length - 1);
                        }
                        if (section == "serverAutoSaveInterval")
                        {
                            txtSaveInterval.Text = data.Substring(1, data.Length - 1);
                        }
                        if (section == "difficulty")
                        {
                            cboDifficulty.SelectedItem = data.Substring(1, data.Length - 1);
                        }
                        if (section == "initType")
                        {
                            cboNewContinue.SelectedItem = data.Substring(1, data.Length - 1);
                        }
                        if (section == "slot")
                        {
                            cboSaveSlot.SelectedItem = data.Substring(1, data.Length - 1);
                        }
                        if (section == "showLogs")
                        {
                            data = data.Replace(" ", "");
                            if (data == "on")
                            {
                                chkShowLogs.Checked = true;
                            }
                            else
                            {
                                chkShowLogs.Checked = false;
                            }
                        }
                        if (section == "serverContact")
                        {
                            txtEmail.Text = data.Substring(1, data.Length - 1);
                        }
                        if (section == "veganMode")
                        {
                            data = data.Replace(" ", "");
                            if (data == "on")
                            {
                                chkVeganMode.Checked = true;
                            }
                            else
                            {
                                chkVeganMode.Checked = false;
                            }
                        }
                        if (section == "vegetarianMode")
                        {
                            data = data.Replace(" ", "");
                            if (data == "on")
                            {
                                chkVegetarianMode.Checked = true;
                            }
                            else
                            {
                                chkVegetarianMode.Checked = false;
                            }
                        }
                        if (section == "resetHolesMode")
                        {
                            data = data.Replace(" ", "");
                            if (data == "on")
                            {
                                chkResetHoles.Checked = true;
                            }
                            else
                            {
                                chkResetHoles.Checked = false;
                            }
                        }
                        if (section == "treeRegrowMode")
                        {
                            data = data.Replace(" ", "");
                            if (data == "on")
                            {
                                chkTreeRegrowMode.Checked = true;
                            }
                            else
                            {
                                chkTreeRegrowMode.Checked = false;
                            }
                        }
                        if (section == "allowBuildingDestruction")
                        {
                            data = data.Replace(" ", "");
                            if (data == "on")
                            {
                                chkAllowDestruction.Checked = true;
                            }
                            else
                            {
                                chkAllowDestruction.Checked = false;
                            }
                        }
                        if (section == "allowEnemiesCreativeMode")
                        {
                            data = data.Replace(" ", "");
                            if (data == "on")
                            {
                                chkEnemiesInCreative.Checked = true;
                            }
                            else
                            {
                                chkEnemiesInCreative.Checked = false;
                            }
                        }
                        if (section == "allowCheats")
                        {
                            data = data.Replace(" ", "");
                            if (data == "on")
                            {
                                chkAllowCheats.Checked = true;
                            }
                            else
                            {
                                chkAllowCheats.Checked = false;
                            }
                        }
                        if (section == "saveFolderPath")
                        {
                            txtCustomSaveDir.Text = data.Substring(1, data.Length - 1);
                        }
                        if (section == "targetFpsIdle")
                        {
                            txtIdleFPS.Text = data.Substring(1, data.Length - 1);
                        }
                        if (section == "targetFpsActive")
                        {
                            txtActiveFPS.Text = data.Substring(1, data.Length - 1);
                        }
                    }
                }
            }
        }

        void StartSave()
        {
            if (txtIP.Text != "" && txtSteamPort.Text != "" && txtGamePort.Text != "" && txtServerName.Text != "" && txtSaveInterval.Text !="" && txtIdleFPS.Text != "" && txtActiveFPS.Text != "" && txtSteamToken.Text != "")
            {
                AddLines("serverIP", txtIP.Text, "// Server IP address - Note: If you have a router, this address is the internal address, and you need to configure ports forwarding");
                AddLines("serverSteamPort", txtSteamPort.Text, "// Steam Communication Port - Note: If you have a router you will need to open this port.");
                AddLines("serverGamePort", txtGamePort.Text, "// Game Communication Port - Note: If you have a router you will need to open this port.");
                AddLines("serverQueryPort", txtQueryPort.Text, "// Query Communication Port - Note: If you have a router you will need to open this port.");
                AddLines("serverName", txtServerName.Text, "// Server display name");
                AddLines("serverPlayers", txtMaxPlayers.Text, "// Maximum number of players");
                if (chkVAC.Checked) {
                    AddLines("enableVAC", "on", "// Enable VAC (Valve Anti-cheat System at the server. Must be set off or on");
                } else {
                    AddLines("enableVAC", "off", "// Enable VAC (Valve Anti-cheat System at the server. Must be set off or on");
                }
                AddLines("serverPassword", txtPassword.Text, "// Server password. blank means no password");
                AddLines("serverPasswordAdmin", txtAdminPassword.Text, "// Server administration password. blank means no password");
                AddLines("serverSteamAccount", txtSteamToken.Text, "// Your Steam account name. blank means anonymous");
                AddLines("serverAutoSaveInterval", txtSaveInterval.Text, "// Time between server auto saves in minutes - The minumum time is 15 minutes, the default time is 30");
                AddLines("difficulty", cboDifficulty.SelectedItem.ToString(), "// Game difficulty mode. Must be set to Peaceful Normal or Hard");
                AddLines("initType", cboNewContinue.SelectedItem.ToString(), "// New or continue a game. Must be set to New or Continue");
                AddLines("slot", cboSaveSlot.SelectedItem.ToString(), "// Slot to save the game. Must be set 1 2 3 4 or 5");
                if (chkShowLogs.Checked) {
                    AddLines("showLogs", "on", "// Show event log. Must be set off or on");
                } else {
                    AddLines("showLogs", "off", "// Show event log. Must be set off or on");
                }
                AddLines("serverContact", txtEmail.Text, "// Contact email for server admin");
                if (chkVeganMode.Checked) {
                    AddLines("veganMode", "on", "// No enemies");
                } else {
                    AddLines("veganMode", "off", "// No enemies");
                }
                if (chkVegetarianMode.Checked) {
                    AddLines("vegetarianMode", "on", "// No enemies during day time");
                } else {
                    AddLines("vegetarianMode", "off", "// No enemies during day time");
                }
                if (chkResetHoles.Checked) {
                    AddLines("resetHolesMode", "on", "// Reset all structure holes when loading a save");
                } else {
                    AddLines("resetHolesMode", "off", "// Reset all structure holes when loading a save");
                }
                if (chkTreeRegrowMode.Checked) {
                    AddLines("treeRegrowMode", "on", "// Regrow 10% of cut down trees when sleeping");
                } else {
                    AddLines("treeRegrowMode", "off", "// Regrow 10% of cut down trees when sleeping");
                }
                if (chkAllowDestruction.Checked) {
                    AddLines("allowBuildingDestruction", "on", "// Allow building destruction");
                } else {
                    AddLines("allowBuildingDestruction", "off", "// Allow building destruction");
                }
                if (chkEnemiesInCreative.Checked) {
                    AddLines("allowEnemiesCreativeMode", "on", "// Allow enemies in creative games");
                } else {
                    AddLines("allowEnemiesCreativeMode", "off", "// Allow enemies in creative games");
                }
                if (chkAllowCheats.Checked) {
                    AddLines("allowCheats", "on", "// Allow clients to use the built in debug console");
                } else {
                    AddLines("allowCheats", "off", "// Allow clients to use the built in debug console");
                }
                AddLines("saveFolderPath", txtCustomSaveDir.Text, "// Allows defining a custom folder for save slots, leave empty to use the default location");
                AddLines("targetFpsIdle", txtIdleFPS.Text, "// Target FPS when no client is connected");
                AddLines("targetFpsActive", txtActiveFPS.Text, "// Target FPS when there is at least one client connected");

                // File is now Built to sbText Object.
                //MessageBox.Show(sbText.ToString());
                System.IO.File.WriteAllText(settingsFile, sbText.ToString());
                // Clearing Built sbText Object.
                sbText.Clear();
                MessageBox.Show("Settings Saved.");
            } else {
                if (txtIP.Text == "") { MessageBox.Show("IP is required."); }
                if (txtSteamPort.Text == "") { MessageBox.Show("Steam port is required"); }
                if (txtGamePort.Text == "") { MessageBox.Show("Game port is required"); }
                if (txtServerName.Text == "") { MessageBox.Show("Server Name is required"); }
                if (txtSaveInterval.Text == "") { MessageBox.Show("Save interval is required"); }
                if (txtIdleFPS.Text == "") { MessageBox.Show("Target Idle FPS is required"); }
                if (txtActiveFPS.Text == "") { MessageBox.Show("Target Active FPS is required"); }
                if (txtSteamToken.Text == "") { MessageBox.Show("Steam Login Token is required"); }
            }
        }

        void AddLines(string property, string data, string preface)
        {
            sbText.AppendLine(preface);
            sbText.AppendLine(property + " " + data);
        }
    }
}
