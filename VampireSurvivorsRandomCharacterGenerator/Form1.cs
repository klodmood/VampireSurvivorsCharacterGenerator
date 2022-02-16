using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VampireSurvivorsRandomCharacterGenerator
{
    public partial class Form1 : Form
    {
        
        public static string installPath = "";
        public static string minValueStr;
        public static string maxValueStr;
        public static string textToEdit = "";
        public static string editedText = "";
        public static string[] mainBundleJs = new string[0];
        public static Dictionary<string, string> customFieldValues = new Dictionary<string, string>();
        public static Dictionary<string, string> weaponsAndIds = new Dictionary<string, string>();
        public static string[] variableNamesToRandomiseWholeNumber = new string[] { "maxHp", "armor", "regen", "amount", "revivals", "rerolls", "skips" };
        public static string[] variableNamesToRandomisePercentage = new string[] { "moveSpeed", "power", "cooldown", "area", "speed", "duration", "greed", "luck", "growth", "magnet" };
        public static string[] startingWeapons = new string[] { "_0x54938d[_0x4f2463(0x416)]", "_0x54938d[_0x4f2463(0x587)]", "_0x54938d[_0x4f2463(0x465)]", "_0x54938d[_0x4f2463(0x6ff)]", "_0x54938d[_0x4f2463(0x517)]", "_0x54938d['FIREBALL']", "_0x54938d[_0x4f2463(0x726)]", "_0x54938d[_0x4f2463(0x25a)]", "_0x54938d[_0x4f2463(0x681)]", "_0x54938d['HOLYBOOK']", "_0x54938d[_0x4f2463(0x14f)]", "_0x54938d['SILVER']", "_0x54938d[_0x4f2463(0x7b8)]", "_0x54938d['SILF2']", "_0x54938d[_0x4f2463(0x8b4)]", "_0x54938d['SCYTHE']", "_0x54938d[_0x4f2463(0x8d2)]", "_0x54938d[_0x4f2463(0x526)]", "_0x54938d['VESPERS']", "_0x54938d[_0x4f2463(0x533)]", "_0x54938d[_0x4f2463(0x8c7)]", "_0x54938d[_0x4f2463(0x5da)]", "_0x54938d[_0x4f2463(0x5ad)]", "_0x54938d[_0x4f2463(0x44b)]" };
        public Form1()
        {
            InitializeComponent();
            InitialiseFields();
            //Starting weapons
            PopulateWeaponsAndIds();
        }

        public void PopulateWeaponsAndIds()
        {
            //Weapons...
            //
            //Whip = [_0x54938d['WHIP']]
            //Bloody Tear = [_0x54938d[_0x4f2463(0x587)]]
            //Magic Wand = [_0x54938d['MAGIC_MISSILE']]
            //Holy Wand = [_0x54938d['HOLY_MISSILE']]
            //Knife = [_0x54938d[_0x4f2463(0x517)]]
            //Thousand Edge = [_0x54938d['THOUSAND']]
            //Axe = [_0x54938d[_0x4f2463(0x16a)]]
            //Scythe = [_0x54938d[_0x4f2463(0x2e1)]]
            //Cross = [_0x54938d[_0x4f2463(0x14f)]]
            //Heaven Sword = [_0x54938d[_0x4f2463(0x526)]]
            //King Bible = [_0x54938d['HOLYBOOK']]
            //Unholy Vespers = [_0x54938d['VESPERS']]
            //Fire Wand = [_0x54938d[_0x4f2463(0x32d)]]
            //Hellfire = _0x54938d[_0x4f2463(0x533)]
            //Garlic = [_0x54938d[_0x4f2463(0x25a)]]
            //Soul Eater = [_0x54938d[_0x4f2463(0x8c7)]]
            //Santa Water = [_0x54938d['HOLYWATER']]
            //La Borra = [_0x54938d[_0x4f2463(0x5da)]]
            //Lightning Ring = [_0x54938d['LIGHTNING']]
            //Thunder Loop = [_0x54938d[_0x4f2463(0x5ad)]]
            //Peachone = [_0x54938d[_0x4f2463(0x36a)]]
            //Ebony Wings = [_0x54938d[_0x4f2463(0x407)]]
            //Vandelier = [_0x54938d[_0x4f2463(0x44b)]]
            //Runetracer = [_0x54938d['DIAMOND']]
            //Pentagram = [_0x54938d['PENTAGRAM']]
            //Clock Lancet = [_0x54938d['LANCET']]
            //Laurel = [_0x54938d[_0x4f2463(0x54e)]]
            //Bone = [_0x54938d[_0x4f2463(0x7b8)]]
            //Unknown??? = [_0x54938d[_0x4f2463(0x695)]]
            //
            weaponsAndIds = new Dictionary<string, string>();
            weaponsAndIds.Add("Whip", "_0x54938d['WHIP']");
            weaponsAndIds.Add("Bloody Tear", "_0x54938d[_0x4f2463(0x587)]");
            weaponsAndIds.Add("Magic Wand", "_0x54938d['MAGIC_MISSILE']");
            weaponsAndIds.Add("Holy Wand", "_0x54938d['HOLY_MISSILE']");
            weaponsAndIds.Add("Knife", "_0x54938d[_0x4f2463(0x517)]");
            weaponsAndIds.Add("Thousand Edge", "_0x54938d['THOUSAND']");
            weaponsAndIds.Add("Axe", "_0x54938d[_0x4f2463(0x16a)]");
            weaponsAndIds.Add("Scythe", "_0x54938d[_0x4f2463(0x2e1)]");
            weaponsAndIds.Add("Cross", "_0x54938d[_0x4f2463(0x14f)]");
            weaponsAndIds.Add("Heaven Sword", "_0x54938d[_0x4f2463(0x526)]");
            weaponsAndIds.Add("King Bible", "_0x54938d['HOLYBOOK']");
            weaponsAndIds.Add("Unholy Vespers", "_0x54938d['VESPERS']");
            weaponsAndIds.Add("Fire Wand", "_0x54938d[_0x4f2463(0x32d)]");
            weaponsAndIds.Add("Hellfire", "_0x54938d[_0x4f2463(0x533)]");
            weaponsAndIds.Add("Garlic", "_0x54938d[_0x4f2463(0x25a)]");
            weaponsAndIds.Add("Soul Eater", "_0x54938d[_0x4f2463(0x8c7)]");
            weaponsAndIds.Add("Santa Water", "_0x54938d['HOLYWATER']");
            weaponsAndIds.Add("La Borra", "_0x54938d[_0x4f2463(0x5da)]");
            weaponsAndIds.Add("Lightning Ring", "_0x54938d['LIGHTNING']");
            weaponsAndIds.Add("Thunder Loop", "_0x54938d[_0x4f2463(0x5ad)]");
            weaponsAndIds.Add("Peachone", "_0x54938d[_0x4f2463(0x36a)]");
            weaponsAndIds.Add("Ebony Wings", "_0x54938d[_0x4f2463(0x407)]");
            weaponsAndIds.Add("Vandelier", "_0x54938d[_0x4f2463(0x44b)]");
            weaponsAndIds.Add("Runetracer", "_0x54938d['DIAMOND']");
            weaponsAndIds.Add("Pentagram", "_0x54938d['PENTAGRAM']");
            weaponsAndIds.Add("Clock Lancet", "_0x54938d['LANCET']");
            weaponsAndIds.Add("Laurel", "_0x54938d[_0x4f2463(0x54e)]");
            weaponsAndIds.Add("Bone", "_0x54938d[_0x4f2463(0x7b8)]");
            weaponsAndIds.Add("Flamethrower", "_0x54938d[_0x4f2463(0x695)]");
            startingWeapons = weaponsAndIds.Values.ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool generateRandom = true;
            if(checkBox1.Checked)
            {
                generateRandom = false;
            }
            if(checkBox1.Checked && customFieldValues.Count() == 0)
            {
                DialogResult dlg = MessageBox.Show("You have selected to generate a CUSTOM character, but all custom attributes are default. Generate with default values?", "Custom or Random?", MessageBoxButtons.YesNo);
                if (dlg == DialogResult.Yes)
                {
                    generateRandom = false;
                }
                else
                {
                    return;
                }
            }
            if(customFieldValues.Count() > 0 && checkBox2.Checked)
            {
                DialogResult dlg = MessageBox.Show("You have set custom character attributes, but have selected to generate a RANDOM character. Would you like to generate a CUSTOM character using the attributes you chose instead?", "Custom or Random?", MessageBoxButtons.YesNo);
                if(dlg == DialogResult.Yes)
                {
                    generateRandom = false;
                }
            }


            minValueStr = ConfigurationManager.AppSettings["MinValue"];
            maxValueStr = ConfigurationManager.AppSettings["MaxValue"];
            int maxValue = 0;
            int minValue = 0;
            int defaultMinValue = 0;
            int defaultMaxValue = 0;
            //set default values if not available

            if (string.IsNullOrEmpty(minValueStr))
            {
                minValueStr = "-255";
            }
            if (string.IsNullOrEmpty(maxValueStr))
            {
                maxValueStr = "255";
            }

            try
            {
                int.TryParse(minValueStr, out defaultMinValue);
                int.TryParse(maxValueStr, out defaultMaxValue);
            }
            catch (Exception ex)
            {

            }
            installPath = GetInstallPath();
            if (string.IsNullOrEmpty(installPath))
            {
                MessageBox.Show("Could not get install path");
            }
            else
            {
                mainBundleJs = LoadFile("main.bundle.js");

                int indexStart = mainBundleJs[0].IndexOf("[_0x5a0603['NOSTRO']]:");
                if (indexStart >= 0)
                {
                    textToEdit = mainBundleJs[0].Substring(indexStart);
                    int indexEnd = textToEdit.IndexOf("}],");
                    if (indexEnd >= 0)
                    {
                        textToEdit = textToEdit.Substring(0, indexEnd + "}],".Length);
                        int arrayStartIdx = textToEdit.IndexOf(":");
                        editedText = textToEdit;
                        if (arrayStartIdx >= 0)
                        {
                            
                            if(generateRandom)
                            {
                                GenerateRandomCharacter(minValue, maxValue, defaultMinValue, defaultMaxValue);
                            }
                            else
                            {
                                GenerateCharacterFromAttributes();
                            }


                            //BACKUP ORIGINAL FILE FIRST
                            if (!string.IsNullOrEmpty(installPath))
                            {
                                string filePath = Path.Combine(installPath, @"resources\app\.webpack\renderer\main.bundle.js");
                                string backupFilePath = Path.Combine(installPath, @"resources\app\.webpack\renderer\BACKUP_main.bundle.js");
                                if (!File.Exists(backupFilePath))
                                {
                                    File.Copy(filePath, backupFilePath);
                                }

                                File.WriteAllText(filePath, mainBundleJs[0]);
                                DialogResult dialogResult = MessageBox.Show("Would you like to launch Vampire Survivors now?", "File altered successfully!", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    System.Diagnostics.Process.Start(@"steam://rungameid/1794680");
                                }
                            }

                        }
                    }
                }
            }
            //Find string starting from...
            //[_0x5a0603['NOSTRO']]:
            //ending with...
            //}],

            //Features...
            //
            //Set Variables to certain value:
            //
            //Price
            //IsBought
            //Hidden
            //
            //Variables that can -100 - 1000%:
            //
            //Move Speed
            //MaxHP
            //Armor
            //Regen
            //MoveSpeed
            //Power
            //Cooldown
            //Area
            //Speed
            //Duration
            //Amount
            //Luck
            //Gorwth
            //Greed
            //Magnet
            //
            //Special cases:
            //
            //Revivals (number is how many, 0x0 = 0)
            //Starting Weapon
            //Growth (decide on a number of factors and levels in which to evolve)

            //Variables:
            //moveSpeed 0x1 = 0%, 0x2 = 100%, 0x3 = 200%. Can use 1.5 = 50% 0.6 = -40%, -1.5 = -250%
            //startingWeapon _0x54938d['SCYTHE']
            //isBought !0x1
            //'price':0x29a
            //'maxHp':0xff
            //'armor':0x0,
            ////'regen':0x0,
            //'moveSpeed':0x2,
            //'power':1.2,
            //'cooldown':0x1,
            //'area':0x1,
            //'speed':0x1,
            //'duration':0x1,
            //'amount':0x0,
            //'luck':0x1,
            //'growth':0x1,
            //'greed':0x1,
            //'magnet':0x0,
            //'revivals':0x0,
            //'rerolls':0x0,
            //'skips':0x0,
            //'showcase':[]},{'growth':0x1,'level':0x14},{'growth':0x1,'level':0x28},{'level':0x15,'growth':-0x1},{'level':0x29,'growth':-0x1}]  
            //ANTONIOS SECTION AFTER SHOWCASE:
            //{'power':0.1,'level':0xa},{'power':0.1,'level':0x14,'growth':0x1},{'power':0.1,'level':0x1e},{'power':0.1,'level':0x28,'growth':0x1},{'power':0.1,'level':0x32},{'level':0x15,'growth':-0x1},{'level':0x29,'growth':-0x1}
            //Power increments by 10% every 10 levels

            //Load main.bundle.js file
            //Backup if first time?
            //
            //Find section to edit
            //Remove WHOLE JSON for that character
            //



        }

        public static void GenerateCharacterFromAttributes()
        {
            int valueInt = 0;
            string value = "";
            SetVariableValue("prefix", "", false, true);
            if (customFieldValues.Count() > 0)
            {
                if(customFieldValues.ContainsKey("name"))
                {
                    value = customFieldValues["name"];
                    SetVariableValue("charName", value, false, true);
                }
                else
                {
                    SetVariableValue("charName", "MissingNo", false, true);
                }
            }
            foreach (string variableName in variableNamesToRandomiseWholeNumber)
            {
                value = "";
                valueInt = 0;
                if(customFieldValues.ContainsKey(variableName))
                {
                    try
                    {
                        value = customFieldValues[variableName];
                        if(variableName != "name")
                        {
                            int.TryParse(value, out valueInt);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Couldn't parse variable " + variableName + " with value " + customFieldValues[variableName]);
                    }
                }
                else
                {
                    value = "1";
                    valueInt = 1;
                }
                SetVariableValue(variableName, valueInt.ToString("X"), true);

            }
            foreach (string variableName in variableNamesToRandomisePercentage)
            {
                value = "";
                valueInt = 0;
                if (customFieldValues.ContainsKey(variableName))
                {
                    try
                    {
                        value = customFieldValues[variableName];
                        if (variableName != "name")
                        {
                            int.TryParse(value, out valueInt);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Couldn't parse variable " + variableName + " with value " + customFieldValues[variableName]);
                    }
                }
                else
                {
                    value = "1";
                    valueInt = 1;
                }
                double valueIntPercentage = (valueInt + 100) / 100.0;
                SetVariableValue(variableName, valueIntPercentage.ToString());
            }

            SetVariableValue("hidden", "0", true);
            SetVariableValue("price", "0", true);

            string weaponValue = GetWeaponValue();
            if (!string.IsNullOrEmpty(weaponValue))
            {
                SetVariableValue("startingWeapon", weaponValue, false);
            }
            else
            {
                Random r = new Random();
                int startingWeaponIdx = r.Next(0, startingWeapons.Count() - 1);
                SetVariableValue("startingWeapon", startingWeapons[startingWeaponIdx], false);
            }
            mainBundleJs[0] = mainBundleJs[0].Replace(textToEdit, editedText);
        }

        public static string GetWeaponValue()
        {
            string textVal = "";
            string returnVal = "";
            if(customFieldValues.ContainsKey("startingWeapon"))
            {
                textVal = customFieldValues["startingWeapon"];
            }
            if(!string.IsNullOrEmpty(textVal))
            {
                returnVal = weaponsAndIds[textVal];
            }
            return returnVal;
        }

        public static void GenerateRandomCharacter(int minValue, int maxValue, int defaultMinValue, int defaultMaxValue)
        {
            /*string arrayOfVars = textToEdit.Substring(arrayStartIdx + 1);
                            if(arrayOfVars.EndsWith(","))
                            {
                                arrayOfVars = arrayOfVars.Remove(arrayOfVars.Length - 1, 1);
                            }*/

            Random rnd = new Random();
            SetVariableValue("prefix", "", false, true);
            SetVariableValue("charName", "MissingNo", false, true);
            foreach (string variableName in variableNamesToRandomiseWholeNumber)
            {
                minValue = defaultMinValue;
                maxValue = defaultMaxValue;
                switch (variableName)
                {
                    case "maxHp":
                        //minValue = minValHPSlider.Value;
                        //maxValue = maxValHPSlider.Value;
                        break;
                    case "revivals":
                    case "rerolls":
                    case "skips":
                        break;
                    case "regen":
                    case "armor":
                        break;
                    case "amount":
                        break;
                }
                int randomNumber = rnd.Next(minValue, maxValue);
                double randomNumberDouble = randomNumber;
                randomNumber = Math.Abs(randomNumber);
                switch (variableName)
                {
                    case "maxHp":
                        break;
                    case "revivals":
                    case "rerolls":
                    case "skips":
                        break;
                    case "regen":
                    case "armor":
                        if (randomNumber >= 100)
                        {
                            randomNumber = randomNumber / 10;
                            randomNumberDouble = randomNumberDouble / 10;
                        }
                        break;
                    case "amount":
                        randomNumber = randomNumber / 10;
                        if (Math.Abs(randomNumber) >= 50)
                        {
                            randomNumber = randomNumber / 5;
                        }
                        break;
                }
                if (variableName == "regen")
                {
                    SetVariableValue(variableName, randomNumberDouble.ToString(), false);
                }
                else
                {
                    SetVariableValue(variableName, randomNumber.ToString("X"), true);
                }

            }
            foreach (string variableName in variableNamesToRandomisePercentage)
            {
                minValue = defaultMinValue;
                maxValue = defaultMaxValue;
                int randomNumber = rnd.Next(minValue, maxValue);
                double randomNumberPercentage = (randomNumber + 100) / 100.0;
                SetVariableValue(variableName, randomNumberPercentage.ToString());
            }

            SetVariableValue("hidden", "0", true);
            SetVariableValue("price", "0", true);
            Random r = new Random();
            int startingWeaponIdx = r.Next(0, startingWeapons.Count() - 1);
            SetVariableValue("startingWeapon", startingWeapons[startingWeaponIdx], false);
            mainBundleJs[0] = mainBundleJs[0].Replace(textToEdit, editedText);
        }

        public static string GetInstallPath()
        {
            string installPath = "";
            try
            {
                string keyPath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 1794680";
                string keyName = "InstallLocation";
                object connectionString = RegistryHelpers.GetRegistryValue(keyPath, keyName);
                installPath = (string)connectionString;

            }
            catch
            {

            }
            return installPath;
        }

        public static void SetVariableValue(string variableName, string newValue, bool hex = false, bool stringValue = false)
        {
            if (hex)
            {
                newValue = "0x" + newValue;
            }
            //
            string variableValue = "";
            variableName = variableName.Trim();
            if (!variableName.StartsWith("'"))
            {
                variableName = variableName.Insert(0, "'");
            }
            if (!variableName.EndsWith("'"))
            {
                variableName = variableName += "'";
            }
            variableName = variableName += ":";

            int idx = textToEdit.IndexOf(variableName);
            if (idx >= 0)
            {
                variableValue = textToEdit.Substring(idx + variableName.Length);
                int idx2 = variableValue.IndexOf(",");
                if (idx2 >= 0)
                {
                    variableValue = variableValue.Substring(0, idx2);
                    newValue = newValue.Trim();
                    if (stringValue)
                    {
                        if(string.IsNullOrEmpty(newValue))
                        {
                            newValue = "''";
                        }
                        else
                        {
                            if (!newValue.StartsWith("'"))
                            {
                                newValue = "'" + newValue;
                            }
                            if (!newValue.EndsWith("'"))
                            {
                                newValue = newValue + "'";
                            }
                        }

                    }
                    editedText = editedText.Replace(variableName + variableValue, variableName + newValue);
                }
            }


        }

        public static string GetVariableValue(string variableName)
        {
            string variableValue = "";
            variableName = variableName.Trim();
            if (!variableName.StartsWith("'"))
            {
                variableName = variableName.Insert(0, "'");
            }
            if (!variableName.EndsWith("'"))
            {
                variableName = variableName += "'";
            }
            variableName = variableName += ":";

            int idx = textToEdit.IndexOf(variableName);
            if (idx >= 0)
            {
                variableValue = textToEdit.Substring(idx + variableName.Length);
                int idx2 = variableValue.IndexOf(",");
                if (idx2 >= 0)
                {
                    variableValue = variableValue.Substring(0, idx2);
                }
            }
            return variableValue;

        }
        public static string[] LoadFile(string filename)
        {
            string fullPathToDataFile = Path.Combine(installPath, @"resources\app\.webpack\renderer", filename);
            return System.IO.File.ReadAllLines(fullPathToDataFile);
        }

        public void InitialiseFields()
        {
            //Get these from config/last user preference file (create in dir)
            //minValHP.Text = "1";
            //minValHPSlider.Value = 1;
            //maxValHP.Text = "255";
            //maxValHPSlider.Value = 255;


        }

        private bool KeyPressLogic(KeyPressEventArgs e)
        {
            bool handled = false;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                handled = true;
            }

            return handled;
        }

        private void SyncScrollFromTextBox(TrackBar trackBar, TextBox textBox)
        {
            string textboxValue = textBox.Text;

            // Retrieve as integer
            int valueInt = Int32.Parse(textboxValue);
            if (valueInt > trackBar.Maximum)
            {
                valueInt = trackBar.Maximum;
                textBox.Text = valueInt.ToString();
            }
            if (valueInt < trackBar.Minimum)
            {
                valueInt = trackBar.Minimum;
                textBox.Text = valueInt.ToString();
            }
            trackBar.Value = valueInt;
        }

        private void SyncTextBoxFromScroll(TrackBar trackBar, TextBox textBox)
        {
            textBox.Text = "" + trackBar.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            installPath = GetInstallPath();
            if (string.IsNullOrEmpty(installPath))
            {
                MessageBox.Show("Could not get install path");
            }
            else
            {

                string filePath = Path.Combine(installPath, @"resources\app\.webpack\renderer\main.bundle.js");
                string backupFilePath = Path.Combine(installPath, @"resources\app\.webpack\renderer\BACKUP_main.bundle.js");
                if (File.Exists(backupFilePath))
                {
                    if(File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    File.Copy(backupFilePath, filePath);
                    MessageBox.Show("Original game data restored!");
                }
                else
                {
                    MessageBox.Show("Backup file doesn't exist!");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                checkBox2.Checked = false;
            }
            else
            {
                checkBox2.Checked = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            bool alreadyOpen = false;
            foreach(Form frm in fc)
            {
                if(frm.Name == "Form2")
                {
                    alreadyOpen = true;
                }
            }
            if(!alreadyOpen)
            {
                var myForm = new Form2();
                myForm.Show();
            }
            else
            {
                MessageBox.Show("Custom Character Attributes Window Already Open!");
            }
        }

        //private void minValHPSlider_Scroll(object sender, EventArgs e)
        //{
        //    SyncTextBoxFromScroll(minValHPSlider, minValHP);
        //    if(minValHPSlider.Value > maxValHPSlider.Value)
        //    {
        //        maxValHPSlider.Value = minValHPSlider.Value;
        //        maxValHP.Text = "" + maxValHPSlider.Value;
        //    }
        //}

        //private void maxValHPSlider_Scroll_1(object sender, EventArgs e)
        //{
        //    SyncTextBoxFromScroll(maxValHPSlider, maxValHP);
        //    if (maxValHPSlider.Value < minValHPSlider.Value)
        //    {
        //        minValHPSlider.Value = maxValHPSlider.Value;
        //        minValHP.Text = "" + minValHPSlider.Value;
        //    }
        //}

        //private void minValHP_TextChanged(object sender, EventArgs e)
        //{
        //    SyncScrollFromTextBox(minValHPSlider, minValHP);
        //}

        //private void minValHP_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.Handled = KeyPressLogic(e);
        //}
    }
    public class RegistryHelpers
    {

        public static RegistryKey GetRegistryKey()
        {
            return GetRegistryKey(null);
        }

        public static RegistryKey GetRegistryKey(string keyPath)
        {
            RegistryKey localMachineRegistry
                = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                                          Environment.Is64BitOperatingSystem
                                              ? RegistryView.Registry64
                                              : RegistryView.Registry32);

            return string.IsNullOrEmpty(keyPath)
                ? localMachineRegistry
                : localMachineRegistry.OpenSubKey(keyPath);
        }

        public static object GetRegistryValue(string keyPath, string keyName)
        {
            RegistryKey registry = GetRegistryKey(keyPath);
            return registry.GetValue(keyName);
        }
    }
}
