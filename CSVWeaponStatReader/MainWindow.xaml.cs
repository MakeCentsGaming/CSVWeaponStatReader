using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace MWRStatReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Weapon
        {
            public string WEAPONFILE { get; set; }
            public string WeaponType = "bulletweapon";
            public bool isCSVWeapon = false;
            public List<WeaponSetting> weapon_settings = new List<WeaponSetting>();
            public override string ToString()
            {
                return WEAPONFILE;
            }
        }
        public class WeaponSetting
        {
            public string key { get; set; }
            public string val { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        public static Weapon[] LoadCSV(string filename)
        {
            string[] lines = System.IO.File.ReadLines(filename).ToArray();
            // Split header to find columns
            string[] header = lines[0].Split(',');
            // Array
            Weapon[] weapons = new Weapon[lines.Length - 1];
            // Return if WEAPONFILE isn't in header
            if (!header.Contains("WEAPONFILE"))
                return weapons;
            for (int i = 1; i < lines.Length; i++)
            {
                string[] linesplit = lines[i].Split(',');
                Weapon weapon = new Weapon();
                weapon.isCSVWeapon = true;
                weapon.WEAPONFILE = linesplit[Array.IndexOf(header, "WEAPONFILE")];
                weapons[i - 1] = weapon;
                // Weapon Data
                string[] settings = new string[]
                {
                    "displayName",
                    "locNone",
                    "locHelmet",
                    "locHead",
                    "locNeck",
                    "locTorsoUpper",
                    "locTorsoLower",
                    "locRightArmUpper",
                    "locLeftArmUpper",
                    "locRightArmLower",
                    "locLeftArmLower",
                    "locRightHand",
                    "locLeftHand",
                    "locRightLegUpper",
                    "locLeftLegUpper",
                    "locRightLegLower",
                    "locLeftLegLower",
                    "locRightFoot",
                    "locLeftFoot",
                    "locGun",
                    "locShield",
                    "locArmor",
                    "locSoft",
                    "weaponType",
                    "weaponClass",
                    "penetrateType",
                    "fireType",
                    "burstFireCooldown",
                    "startAmmo",
                    "ammoIndex",
                    "maxAmmo",
                    "clipSize",
                    "shotCount",
                    "damage",
                    "meleeDamage",
                    "fireDelay",
                    "meleeDelay",
                    "meleeChargeDelay",
                    "detonateDelay",
                    "fireTime",
                    "rechamberTime",
                    "rechamberBoltTime",
                    "holdFireTime",
                    "holdPrimeTime",
                    "detonateTime",
                    "meleeTime",
                    "meleeChargeTime",
                    "reloadTime",
                    "reloadEmptyTime",
                    "reloadAddTime",
                    "reloadEmptyAddTime",
                    "reloadStartTime",
                    "reloadStartAddTime",
                    "reloadEndTime",
                    "reloadQuickTime",
                    "reloadQuickAddTime",
                    "reloadQuickEmptyTime",
                    "reloadQuickEmptyAddTime",
                    "reloadSpeedTime",
                    "reloadSpeedAddTime",
                    "dropTime",
                    "raiseTime",
                    "altDropTime",
                    "altRaiseTime",
                    "quickDropTime",
                    "quickRaiseTime",
                    "firstRaiseTime",
                    "emptyRaiseTime",
                    "emptyDropTime",
                    "sprintInTime",
                    "sprintLoopTime",
                    "sprintOutTime",
                    "fuseTime",
                    "primeTime",
                    "fireDelayAkimbo",
                    "meleeDelayAkimbo",
                    "meleeChargeDelayAkimbo",
                    "detonateDelayAkimbo",
                    "fireTimeAkimbo",
                    "rechamberTimeAkimbo",
                    "rechamberBoltTimeAkimbo",
                    "holdFireTimeAkimbo",
                    "holdPrimeTimeAkimbo",
                    "detonateTimeAkimbo",
                    "meleeTimeAkimbo",
                    "meleeChargeTimeAkimbo",
                    "reloadTimeAkimbo",
                    "reloadEmptyTimeAkimbo",
                    "reloadAddTimeAkimbo",
                    "reloadEmptyAddTimeAkimbo",
                    "reloadStartTimeAkimbo",
                    "reloadStartAddTimeAkimbo",
                    "reloadEndTimeAkimbo",
                    "reloadQuickTimeAkimbo",
                    "reloadQuickAddTimeAkimbo",
                    "reloadQuickEmptyTimeAkimbo",
                    "reloadQuickEmptyAddTimeAkimbo",
                    "reloadSpeedTimeAkimbo",
                    "reloadSpeedAddTimeAkimbo",
                    "dropTimeAkimbo",
                    "raiseTimeAkimbo",
                    "altDropTimeAkimbo",
                    "altRaiseTimeAkimbo",
                    "quickDropTimeAkimbo",
                    "quickRaiseTimeAkimbo",
                    "firstRaiseTimeAkimbo",
                    "emptyRaiseTimeAkimbo",
                    "emptyDropTimeAkimbo",
                    "sprintInTimeAkimbo",
                    "sprintLoopTimeAkimbo",
                    "sprintOutTimeAkimbo",
                    "fuseTimeAkimbo",
                    "primeTimeAkimbo",
                    "autoAimRange",
                    "aimAssistRange",
                    "aimAssistRangeAds",
                    "enemyCrosshairRange",
                    "moveSpeedScale",
                    "adsMoveSpeedScale",
                    "sprintDurationScale",
                    "adsZoomFov",
                    "adsZoomInFrac",
                    "adsZoomOutFrac",
                    "adsBobFactor",
                    "adsViewBobMult",
                    "hipSpreadStandMin",
                    "hipSpreadDuckedMin",
                    "hipSpreadProneMin",
                    "hipSpreadMax",
                    "hipSpreadSprintMax",
                    "hipSpreadSlideMax",
                    "hipSpreadDuckedMax",
                    "hipSpreadProneMax",
                    "hipSpreadDecayRate",
                    "hipSpreadFireAdd",
                    "hipSpreadTurnAdd",
                    "hipSpreadMoveAdd",
                    "hipSpreadDuckedDecay",
                    "hipSpreadProneDecay",
                    "adsIdleAmount",
                    "hipIdleAmount",
                    "adsIdleSpeed",
                    "hipIdleSpeed",
                    "idleCrouchFactor",
                    "idleProneFactor",
                    "gunMaxPitch",
                    "gunMaxYaw",
                    "adsIdleLerpStartTime",
                    "adsIdleLerpTime",
                    "adsTransInTime",
                    "adsTransInTimeSprint",
                    "adsTransOutTime",
                    "adsFireAnimFrac",
                    "adsZoomFovFocus",
                    "adsFovLerpStartTime",
                    "adsFovLerpTime",
                    "fireAnimLength",
                    "fireAnimLengthAkimbo",
                    "explosionRadius",
                    "explosionRadiusMin",
                    "explosionInnerDamage",
                    "explosionOuterDamage",
                    "damageConeAngle",
                    "bulletExplDmgMult",
                    "bulletExplRadiusMult",
                    "projectileSpeed",
                    "projectileSpeedUp",
                    "projectileSpeedForward",
                    "projectileActivateDist",
                    "projectileLifetime",
                    "timeToAccelerate",
                    "projectileCurvature",
                    "adsGunKickReducedKickBullets",
                    "adsGunKickReducedKickPercent",
                    "adsGunKickPitchMin",
                    "adsGunKickPitchMax",
                    "adsGunKickYawMin",
                    "adsGunKickYawMax",
                    "adsGunKickMagMin",
                    "adsGunKickAccel",
                    "adsGunKickSpeedMax",
                    "adsGunKickSpeedDecay",
                    "adsGunKickStaticDecay",
                    "adsViewKickPitchMin",
                    "adsViewKickPitchMax",
                    "adsViewKickYawMin",
                    "adsViewKickYawMax",
                    "adsViewKickMagMin",
                    "adsViewKickCenterSpeed",
                    "adsSpread",
                    "hipGunKickReducedKickBullets",
                    "hipGunKickReducedKickPercent",
                    "hipGunKickPitchMin",
                    "hipGunKickPitchMax",
                    "hipGunKickYawMin",
                    "hipGunKickYawMax",
                    "hipGunKickMagMin",
                    "hipGunKickAccel",
                    "hipGunKickSpeedMax",
                    "hipGunKickSpeedDecay",
                    "hipGunKickStaticDecay",
                    "hipViewKickPitchMin",
                    "hipViewKickPitchMax",
                    "hipViewKickYawMin",
                    "hipViewKickYawMax",
                    "hipViewKickMagMin",
                    "hipViewKickCenterSpeed",
                    "medDamage",
                    "minDamage",
                    "maxDamageRange",
                    "minDamageRange",
                    "damageFirstBullets",
                    "damageFirst",
                    "medDamageFirst",
                    "minDamageFirst",
                    "maxDamageRangeFirst",
                    "minDamageRangeFirst",
                    "destabilizationRateTime",
                    "destabilizationCurvatureMax",
                    "destabilizeDistance",
                    "overheatUpRate",
                    "overheatDownRate",
                    "overheatDownRateFast",
                    "overheatPenalty",
                    "introFireTime",
                    "introFireLength",
                    "introFireLerp",
                    "sharedAmmo",
                    "rifleBullet",
                    "armorPiercing"
                };

                foreach (string setting in settings)
                {
                    if(header.Contains(setting))
                        weapon.weapon_settings.Add(
                            new WeaponSetting { key = setting, val = linesplit[Array.IndexOf(header, setting)] });
                }
            }
            return weapons;
        }
        private void LoadWeaponFile(string file)
        {
            string[] weaponfile = System.IO.File.ReadAllText(file).Split('\\');

            if (weaponfile[0] != "WEAPONFILE")
                return;

            Weapon weapon = new Weapon();

            weapon.WEAPONFILE = System.IO.Path.GetFileNameWithoutExtension(file);

            for (int i = 1; i < weaponfile.Length; i+=2)
            {
                    weapon.weapon_settings.Add(
                        new WeaponSetting { key = weaponfile[i], val = weaponfile[i + 1]});
            }

            WEAPON_LIST.Items.Add(weapon);

        }
        private void LoadCSVFile(string filename)
        {
            if (System.IO.Path.GetExtension(filename) == ".csv")
            {
                string[] current_items = new string[WEAPON_LIST.Items.Count];
                // Doing a .Contains on Items list didn't work. ;-;
                for (int i = 0; i < WEAPON_LIST.Items.Count; i++)
                {
                    current_items[i] = WEAPON_LIST.Items[i].ToString();
                }
                Weapon[] weapons = LoadCSV(filename);
                for (int i = 0; i < weapons.Length; i++)
                {
                    if (current_items.Contains(weapons[i].ToString()))
                    {
                        weapons[i] = null;
                        continue;
                    }
                    if (weapons[i] == null)
                        continue;
                    if (string.IsNullOrEmpty(weapons[i].WEAPONFILE))
                        continue;
                    WEAPON_LIST.Items.Add(weapons[i]);
                }
            }
            /*
            else
            {
                LoadWeaponFile(file);
            }
            */
        }
        private void listBox_Drop(object sender, DragEventArgs dropped_items)
        {
            if (dropped_items.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // File List
                string[] files = (string[])dropped_items.Data.GetData(DataFormats.FileDrop);
                foreach (string file in files)
                {
                    LoadCSVFile(file);
                }
            }
        }

        private void WEAPON_LIST_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SETTINGS_LIST.Items.Clear();
            Weapon weapon = (Weapon)WEAPON_LIST.SelectedItem;
            if (weapon != null)
            {
                foreach (WeaponSetting setting in weapon.weapon_settings)
                {
                    SETTINGS_LIST.Items.Add(setting);
                }
                ComboBoxItem comboBoxItem = WEAP_TYPE_BOX.Items.OfType<ComboBoxItem>().FirstOrDefault(
                    x => x.Content.ToString() == weapon.WeaponType.ToString());
                WEAP_TYPE_BOX.SelectedIndex = WEAP_TYPE_BOX.Items.IndexOf(comboBoxItem);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void CLEAR_BUTTON_Click(object sender, RoutedEventArgs e)
        {
            /*
             I noticed if we kept loading in CSVs, simply clearing
             the listview wasn't enough and memory usage would keep
             increasing, so we need to clear everything and force
             the garbage collector to remove them.
            */
            for(int i = 0; i < WEAPON_LIST.Items.Count; i++)
            {
                Weapon item = (Weapon)WEAPON_LIST.Items[i];
                item = null;
            }
            WEAPON_LIST.Items.Clear();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private string GetSetting(Dictionary<string, string> settings, string value, bool intdivide = false, double divider = 1000.000000)
        {
            string val;

            if (settings.TryGetValue(value, out val))
            {
                if(intdivide)
                {
                    double int_div;
                    if (double.TryParse(val, out int_div))
                        return (int_div / divider).ToString("0.000000");

                }
                return val.Replace("FALSE", "0").Replace("TRUE", "1");
            }

            return "";
        }
        private void WriteGDTFile(string filename, bool selected = false)
        {
            using (System.IO.StreamWriter gdt_file = new System.IO.StreamWriter(filename))
            {
                gdt_file.WriteLine();
                gdt_file.WriteLine("{");
                for (int i = 0; i < WEAPON_LIST.Items.Count; i++)
                {
                    if (selected)
                        if (WEAPON_LIST.Items[i] != WEAPON_LIST.SelectedItem)
                            continue;
                    Dictionary<string, string> settings = new Dictionary<string, string>();
                    Weapon weapon = (Weapon)WEAPON_LIST.Items[i];
                    foreach (WeaponSetting value in weapon.weapon_settings)
                    {
                        settings.Add(value.key, value.val);
                    }
                    gdt_file.WriteLine("	\"{0}\" ( \"{1}.gdf\" )", weapon.WEAPONFILE, weapon.WeaponType);
                    gdt_file.WriteLine("	{");
                    gdt_file.WriteLine("		\"displayName\" \"{0}\"", GetSetting(settings, "displayName"));
                    gdt_file.WriteLine("		\"locNone\" \"{0}\"", GetSetting(settings, "locNone"));
                    gdt_file.WriteLine("		\"locHelmet\" \"{0}\"", GetSetting(settings, "locHelmet"));
                    gdt_file.WriteLine("		\"locHead\" \"{0}\"", GetSetting(settings, "locHead"));
                    gdt_file.WriteLine("		\"locNeck\" \"{0}\"", GetSetting(settings, "locNeck"));
                    gdt_file.WriteLine("		\"locTorsoUpper\" \"{0}\"", GetSetting(settings, "locTorsoUpper"));
                    gdt_file.WriteLine("		\"locTorsoLower\" \"{0}\"", GetSetting(settings, "locTorsoLower"));
                    gdt_file.WriteLine("		\"locRightArmUpper\" \"{0}\"", GetSetting(settings, "locRightArmUpper"));
                    gdt_file.WriteLine("		\"locLeftArmUpper\" \"{0}\"", GetSetting(settings, "locLeftArmUpper"));
                    gdt_file.WriteLine("		\"locRightArmLower\" \"{0}\"", GetSetting(settings, "locRightArmLower"));
                    gdt_file.WriteLine("		\"locLeftArmLower\" \"{0}\"", GetSetting(settings, "locLeftArmLower"));
                    gdt_file.WriteLine("		\"locRightHand\" \"{0}\"", GetSetting(settings, "locRightHand"));
                    gdt_file.WriteLine("		\"locLeftHand\" \"{0}\"", GetSetting(settings, "locLeftHand"));
                    gdt_file.WriteLine("		\"locRightLegUpper\" \"{0}\"", GetSetting(settings, "locRightLegUpper"));
                    gdt_file.WriteLine("		\"locLeftLegUpper\" \"{0}\"", GetSetting(settings, "locLeftLegUpper"));
                    gdt_file.WriteLine("		\"locRightLegLower\" \"{0}\"", GetSetting(settings, "locRightLegLower"));
                    gdt_file.WriteLine("		\"locLeftLegLower\" \"{0}\"", GetSetting(settings, "locLeftLegLower"));
                    gdt_file.WriteLine("		\"locRightFoot\" \"{0}\"", GetSetting(settings, "locRightFoot"));
                    gdt_file.WriteLine("		\"locLeftFoot\" \"{0}\"", GetSetting(settings, "locLeftFoot"));
                    gdt_file.WriteLine("		\"locGun\" \"{0}\"", GetSetting(settings, "locGun"));
                    gdt_file.WriteLine("		\"locShield\" \"{0}\"", GetSetting(settings, "locShield"));
                    gdt_file.WriteLine("		\"locArmor\" \"{0}\"", GetSetting(settings, "locArmor"));
                    gdt_file.WriteLine("		\"locSoft\" \"{0}\"", GetSetting(settings, "locSoft"));
                    gdt_file.WriteLine("		\"weaponType\" \"{0}\"", GetSetting(settings, "weaponType"));
                    gdt_file.WriteLine("		\"weaponClass\" \"{0}\"", GetSetting(settings, "weaponClass"));
                    gdt_file.WriteLine("		\"penetrateType\" \"{0}\"", GetSetting(settings, "penetrateType"));
                    gdt_file.WriteLine("		\"fireType\" \"{0}\"", GetSetting(settings, "fireType"));
                    gdt_file.WriteLine("		\"burstFireCooldown\" \"{0}\"", GetSetting(settings, "burstFireCooldown"));
                    gdt_file.WriteLine("		\"startAmmo\" \"{0}\"", GetSetting(settings, "startAmmo"));
                    gdt_file.WriteLine("		\"ammoIndex\" \"{0}\"", GetSetting(settings, "ammoIndex"));
                    gdt_file.WriteLine("		\"maxAmmo\" \"{0}\"", GetSetting(settings, "maxAmmo"));
                    gdt_file.WriteLine("		\"clipSize\" \"{0}\"", GetSetting(settings, "clipSize"));
                    gdt_file.WriteLine("		\"shotCount\" \"{0}\"", GetSetting(settings, "shotCount"));
                    gdt_file.WriteLine("		\"damage\" \"{0}\"", GetSetting(settings, "damage"));
                    gdt_file.WriteLine("		\"meleeDamage\" \"{0}\"", GetSetting(settings, "meleeDamage"));
                    gdt_file.WriteLine("		\"fireDelay\" \"{0}\"", GetSetting(settings, "fireDelay"));
                    gdt_file.WriteLine("		\"meleeDelay\" \"{0}\"", GetSetting(settings, "meleeDelay"));
                    gdt_file.WriteLine("		\"meleeChargeDelay\" \"{0}\"", GetSetting(settings, "meleeChargeDelay"));
                    gdt_file.WriteLine("		\"detonateDelay\" \"{0}\"", GetSetting(settings, "detonateDelay"));
                    gdt_file.WriteLine("		\"fireTime\" \"{0}\"", GetSetting(settings, "fireTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"rechamberTime\" \"{0}\"", GetSetting(settings, "rechamberTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"rechamberBoltTime\" \"{0}\"", GetSetting(settings, "rechamberBoltTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"holdFireTime\" \"{0}\"", GetSetting(settings, "holdFireTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"holdPrimeTime\" \"{0}\"", GetSetting(settings, "holdPrimeTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"detonateTime\" \"{0}\"", GetSetting(settings, "detonateTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"meleeTime\" \"{0}\"", GetSetting(settings, "meleeTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"meleeChargeTime\" \"{0}\"", GetSetting(settings, "meleeChargeTime"));
                    gdt_file.WriteLine("		\"reloadTime\" \"{0}\"", GetSetting(settings, "reloadTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadEmptyTime\" \"{0}\"", GetSetting(settings, "reloadEmptyTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadAddTime\" \"{0}\"", GetSetting(settings, "reloadAddTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadEmptyAddTime\" \"{0}\"", GetSetting(settings, "reloadEmptyAddTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadStartTime\" \"{0}\"", GetSetting(settings, "reloadStartTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadStartAddTime\" \"{0}\"", GetSetting(settings, "reloadStartAddTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadEndTime\" \"{0}\"", GetSetting(settings, "reloadEndTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadQuickTime\" \"{0}\"", GetSetting(settings, "reloadQuickTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadQuickAddTime\" \"{0}\"", GetSetting(settings, "reloadQuickAddTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadQuickEmptyTime\" \"{0}\"", GetSetting(settings, "reloadQuickEmptyTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadQuickEmptyAddTime\" \"{0}\"", GetSetting(settings, "reloadQuickEmptyAddTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadSpeedTime\" \"{0}\"", GetSetting(settings, "reloadSpeedTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadSpeedAddTime\" \"{0}\"", GetSetting(settings, "reloadSpeedAddTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"dropTime\" \"{0}\"", GetSetting(settings, "dropTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"raiseTime\" \"{0}\"", GetSetting(settings, "raiseTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"altDropTime\" \"{0}\"", GetSetting(settings, "altDropTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"altRaiseTime\" \"{0}\"", GetSetting(settings, "altRaiseTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"quickDropTime\" \"{0}\"", GetSetting(settings, "quickDropTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"quickRaiseTime\" \"{0}\"", GetSetting(settings, "quickRaiseTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"firstRaiseTime\" \"{0}\"", GetSetting(settings, "firstRaiseTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"emptyRaiseTime\" \"{0}\"", GetSetting(settings, "emptyRaiseTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"emptyDropTime\" \"{0}\"", GetSetting(settings, "emptyDropTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"sprintInTime\" \"{0}\"", GetSetting(settings, "sprintInTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"sprintLoopTime\" \"{0}\"", GetSetting(settings, "sprintLoopTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"sprintOutTime\" \"{0}\"", GetSetting(settings, "sprintOutTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"fuseTime\" \"{0}\"", GetSetting(settings, "fuseTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"primeTime\" \"{0}\"", GetSetting(settings, "primeTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"fireDelayAkimbo\" \"{0}\"", GetSetting(settings, "fireDelayAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"meleeDelayAkimbo\" \"{0}\"", GetSetting(settings, "meleeDelayAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"meleeChargeDelayAkimbo\" \"{0}\"", GetSetting(settings, "meleeChargeDelayAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"detonateDelayAkimbo\" \"{0}\"", GetSetting(settings, "detonateDelayAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"fireTimeAkimbo\" \"{0}\"", GetSetting(settings, "fireTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"rechamberTimeAkimbo\" \"{0}\"", GetSetting(settings, "rechamberTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"rechamberBoltTimeAkimbo\" \"{0}\"", GetSetting(settings, "rechamberBoltTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"holdFireTimeAkimbo\" \"{0}\"", GetSetting(settings, "holdFireTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"holdPrimeTimeAkimbo\" \"{0}\"", GetSetting(settings, "holdPrimeTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"detonateTimeAkimbo\" \"{0}\"", GetSetting(settings, "detonateTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"meleeTimeAkimbo\" \"{0}\"", GetSetting(settings, "meleeTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"meleeChargeTimeAkimbo\" \"{0}\"", GetSetting(settings, "meleeChargeTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadTimeAkimbo\" \"{0}\"", GetSetting(settings, "reloadTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadEmptyTimeAkimbo\" \"{0}\"", GetSetting(settings, "reloadEmptyTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadAddTimeAkimbo\" \"{0}\"", GetSetting(settings, "reloadAddTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadEmptyAddTimeAkimbo\" \"{0}\"", GetSetting(settings, "reloadEmptyAddTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadStartTimeAkimbo\" \"{0}\"", GetSetting(settings, "reloadStartTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadStartAddTimeAkimbo\" \"{0}\"", GetSetting(settings, "reloadStartAddTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadEndTimeAkimbo\" \"{0}\"", GetSetting(settings, "reloadEndTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadQuickTimeAkimbo\" \"{0}\"", GetSetting(settings, "reloadQuickTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadQuickAddTimeAkimbo\" \"{0}\"", GetSetting(settings, "reloadQuickAddTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadQuickEmptyTimeAkimbo\" \"{0}\"", GetSetting(settings, "reloadQuickEmptyTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadQuickEmptyAddTimeAkimbo\" \"{0}\"", GetSetting(settings, "reloadQuickEmptyAddTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadSpeedTimeAkimbo\" \"{0}\"", GetSetting(settings, "reloadSpeedTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"reloadSpeedAddTimeAkimbo\" \"{0}\"", GetSetting(settings, "reloadSpeedAddTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"dropTimeAkimbo\" \"{0}\"", GetSetting(settings, "dropTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"raiseTimeAkimbo\" \"{0}\"", GetSetting(settings, "raiseTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"altDropTimeAkimbo\" \"{0}\"", GetSetting(settings, "altDropTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"altRaiseTimeAkimbo\" \"{0}\"", GetSetting(settings, "altRaiseTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"quickDropTimeAkimbo\" \"{0}\"", GetSetting(settings, "quickDropTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"quickRaiseTimeAkimbo\" \"{0}\"", GetSetting(settings, "quickRaiseTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"firstRaiseTimeAkimbo\" \"{0}\"", GetSetting(settings, "firstRaiseTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"emptyRaiseTimeAkimbo\" \"{0}\"", GetSetting(settings, "emptyRaiseTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"emptyDropTimeAkimbo\" \"{0}\"", GetSetting(settings, "emptyDropTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"sprintInTimeAkimbo\" \"{0}\"", GetSetting(settings, "sprintInTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"sprintLoopTimeAkimbo\" \"{0}\"", GetSetting(settings, "sprintLoopTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"sprintOutTimeAkimbo\" \"{0}\"", GetSetting(settings, "sprintOutTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"fuseTimeAkimbo\" \"{0}\"", GetSetting(settings, "fuseTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"primeTimeAkimbo\" \"{0}\"", GetSetting(settings, "primeTimeAkimbo", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"autoAimRange\" \"{0}\"", GetSetting(settings, "autoAimRange"));
                    gdt_file.WriteLine("		\"aimAssistRange\" \"{0}\"", GetSetting(settings, "aimAssistRange"));
                    gdt_file.WriteLine("		\"aimAssistRangeAds\" \"{0}\"", GetSetting(settings, "aimAssistRangeAds"));
                    gdt_file.WriteLine("		\"enemyCrosshairRange\" \"{0}\"", GetSetting(settings, "enemyCrosshairRange"));
                    gdt_file.WriteLine("		\"moveSpeedScale\" \"{0}\"", GetSetting(settings, "moveSpeedScale"));
                    gdt_file.WriteLine("		\"adsMoveSpeedScale\" \"{0}\"", GetSetting(settings, "adsMoveSpeedScale"));
                    gdt_file.WriteLine("		\"sprintDurationScale\" \"{0}\"", GetSetting(settings, "sprintDurationScale"));
                    gdt_file.WriteLine("		\"adsZoomFov\" \"{0}\"", GetSetting(settings, "adsZoomFov"));
                    gdt_file.WriteLine("		\"adsZoomInFrac\" \"{0}\"", GetSetting(settings, "adsZoomInFrac"));
                    gdt_file.WriteLine("		\"adsZoomOutFrac\" \"{0}\"", GetSetting(settings, "adsZoomOutFrac"));
                    gdt_file.WriteLine("		\"adsBobFactor\" \"{0}\"", GetSetting(settings, "adsBobFactor"));
                    gdt_file.WriteLine("		\"adsViewBobMult\" \"{0}\"", GetSetting(settings, "adsViewBobMult"));
                    gdt_file.WriteLine("		\"hipSpreadStandMin\" \"{0}\"", GetSetting(settings, "hipSpreadStandMin"));
                    gdt_file.WriteLine("		\"hipSpreadDuckedMin\" \"{0}\"", GetSetting(settings, "hipSpreadDuckedMin"));
                    gdt_file.WriteLine("		\"hipSpreadProneMin\" \"{0}\"", GetSetting(settings, "hipSpreadProneMin"));
                    gdt_file.WriteLine("		\"hipSpreadMax\" \"{0}\"", GetSetting(settings, "hipSpreadMax"));
                    gdt_file.WriteLine("		\"hipSpreadSprintMax\" \"{0}\"", GetSetting(settings, "hipSpreadSprintMax"));
                    gdt_file.WriteLine("		\"hipSpreadSlideMax\" \"{0}\"", GetSetting(settings, "hipSpreadSlideMax"));
                    gdt_file.WriteLine("		\"hipSpreadDuckedMax\" \"{0}\"", GetSetting(settings, "hipSpreadDuckedMax"));
                    gdt_file.WriteLine("		\"hipSpreadProneMax\" \"{0}\"", GetSetting(settings, "hipSpreadProneMax"));
                    gdt_file.WriteLine("		\"hipSpreadDecayRate\" \"{0}\"", GetSetting(settings, "hipSpreadDecayRate"));
                    gdt_file.WriteLine("		\"hipSpreadFireAdd\" \"{0}\"", GetSetting(settings, "hipSpreadFireAdd"));
                    gdt_file.WriteLine("		\"hipSpreadTurnAdd\" \"{0}\"", GetSetting(settings, "hipSpreadTurnAdd"));
                    gdt_file.WriteLine("		\"hipSpreadMoveAdd\" \"{0}\"", GetSetting(settings, "hipSpreadMoveAdd"));
                    gdt_file.WriteLine("		\"hipSpreadDuckedDecay\" \"{0}\"", GetSetting(settings, "hipSpreadDuckedDecay"));
                    gdt_file.WriteLine("		\"hipSpreadProneDecay\" \"{0}\"", GetSetting(settings, "hipSpreadProneDecay"));
                    gdt_file.WriteLine("		\"adsIdleAmount\" \"{0}\"", GetSetting(settings, "adsIdleAmount"));
                    gdt_file.WriteLine("		\"hipIdleAmount\" \"{0}\"", GetSetting(settings, "hipIdleAmount"));
                    gdt_file.WriteLine("		\"adsIdleSpeed\" \"{0}\"", GetSetting(settings, "adsIdleSpeed"));
                    gdt_file.WriteLine("		\"hipIdleSpeed\" \"{0}\"", GetSetting(settings, "hipIdleSpeed"));
                    gdt_file.WriteLine("		\"idleCrouchFactor\" \"{0}\"", GetSetting(settings, "idleCrouchFactor"));
                    gdt_file.WriteLine("		\"idleProneFactor\" \"{0}\"", GetSetting(settings, "idleProneFactor"));
                    gdt_file.WriteLine("		\"gunMaxPitch\" \"{0}\"", GetSetting(settings, "gunMaxPitch"));
                    gdt_file.WriteLine("		\"gunMaxYaw\" \"{0}\"", GetSetting(settings, "gunMaxYaw"));
                    gdt_file.WriteLine("		\"adsIdleLerpStartTime\" \"{0}\"", GetSetting(settings, "adsIdleLerpStartTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"adsIdleLerpTime\" \"{0}\"", GetSetting(settings, "adsIdleLerpTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"adsTransInTime\" \"{0}\"", GetSetting(settings, "adsTransInTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"adsTransInTimeSprint\" \"{0}\"", GetSetting(settings, "adsTransInTimeSprint"));
                    gdt_file.WriteLine("		\"adsTransOutTime\" \"{0}\"", GetSetting(settings, "adsTransOutTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"adsFireAnimFrac\" \"{0}\"", GetSetting(settings, "adsFireAnimFrac"));
                    gdt_file.WriteLine("		\"adsZoomFovFocus\" \"{0}\"", GetSetting(settings, "adsZoomFovFocus"));
                    gdt_file.WriteLine("		\"adsFovLerpStartTime\" \"{0}\"", GetSetting(settings, "adsFovLerpStartTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"adsFovLerpTime\" \"{0}\"", GetSetting(settings, "adsFovLerpTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"fireAnimLength\" \"{0}\"", GetSetting(settings, "fireAnimLength"));
                    gdt_file.WriteLine("		\"fireAnimLengthAkimbo\" \"{0}\"", GetSetting(settings, "fireAnimLengthAkimbo"));
                    gdt_file.WriteLine("		\"explosionRadius\" \"{0}\"", GetSetting(settings, "explosionRadius"));
                    gdt_file.WriteLine("		\"explosionRadiusMin\" \"{0}\"", GetSetting(settings, "explosionRadiusMin"));
                    gdt_file.WriteLine("		\"explosionInnerDamage\" \"{0}\"", GetSetting(settings, "explosionInnerDamage"));
                    gdt_file.WriteLine("		\"explosionOuterDamage\" \"{0}\"", GetSetting(settings, "explosionOuterDamage"));
                    gdt_file.WriteLine("		\"damageConeAngle\" \"{0}\"", GetSetting(settings, "damageConeAngle"));
                    gdt_file.WriteLine("		\"bulletExplDmgMult\" \"{0}\"", GetSetting(settings, "bulletExplDmgMult"));
                    gdt_file.WriteLine("		\"bulletExplRadiusMult\" \"{0}\"", GetSetting(settings, "bulletExplRadiusMult"));
                    gdt_file.WriteLine("		\"projectileSpeed\" \"{0}\"", GetSetting(settings, "projectileSpeed"));
                    gdt_file.WriteLine("		\"projectileSpeedUp\" \"{0}\"", GetSetting(settings, "projectileSpeedUp"));
                    gdt_file.WriteLine("		\"projectileSpeedForward\" \"{0}\"", GetSetting(settings, "projectileSpeedForward"));
                    gdt_file.WriteLine("		\"projectileActivateDist\" \"{0}\"", GetSetting(settings, "projectileActivateDist"));
                    gdt_file.WriteLine("		\"projectileLifetime\" \"{0}\"", GetSetting(settings, "projectileLifeTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"timeToAccelerate\" \"{0}\"", GetSetting(settings, "timeToAccelerate"));
                    gdt_file.WriteLine("		\"projectileCurvature\" \"{0}\"", GetSetting(settings, "projectileCurvature"));
                    gdt_file.WriteLine("		\"adsGunKickReducedKickBullets\" \"{0}\"", GetSetting(settings, "adsGunKickReducedKickBullets"));
                    gdt_file.WriteLine("		\"adsGunKickReducedKickPercent\" \"{0}\"", GetSetting(settings, "adsGunKickReducedKickPercent"));
                    gdt_file.WriteLine("		\"adsGunKickPitchMin\" \"{0}\"", GetSetting(settings, "adsGunKickPitchMin"));
                    gdt_file.WriteLine("		\"adsGunKickPitchMax\" \"{0}\"", GetSetting(settings, "adsGunKickPitchMax"));
                    gdt_file.WriteLine("		\"adsGunKickYawMin\" \"{0}\"", GetSetting(settings, "adsGunKickYawMin"));
                    gdt_file.WriteLine("		\"adsGunKickYawMax\" \"{0}\"", GetSetting(settings, "adsGunKickYawMax"));
                    gdt_file.WriteLine("		\"adsGunKickMagMin\" \"{0}\"", GetSetting(settings, "adsGunKickMagMin"));
                    gdt_file.WriteLine("		\"adsGunKickAccel\" \"{0}\"", GetSetting(settings, "adsGunKickAccel"));
                    gdt_file.WriteLine("		\"adsGunKickSpeedMax\" \"{0}\"", GetSetting(settings, "adsGunKickSpeedMax"));
                    gdt_file.WriteLine("		\"adsGunKickSpeedDecay\" \"{0}\"", GetSetting(settings, "adsGunKickSpeedDecay"));
                    gdt_file.WriteLine("		\"adsGunKickStaticDecay\" \"{0}\"", GetSetting(settings, "adsGunKickStaticDecay"));
                    gdt_file.WriteLine("		\"adsViewKickPitchMin\" \"{0}\"", GetSetting(settings, "adsViewKickPitchMin"));
                    gdt_file.WriteLine("		\"adsViewKickPitchMax\" \"{0}\"", GetSetting(settings, "adsViewKickPitchMax"));
                    gdt_file.WriteLine("		\"adsViewKickYawMin\" \"{0}\"", GetSetting(settings, "adsViewKickYawMin"));
                    gdt_file.WriteLine("		\"adsViewKickYawMax\" \"{0}\"", GetSetting(settings, "adsViewKickYawMax"));
                    gdt_file.WriteLine("		\"adsViewKickMagMin\" \"{0}\"", GetSetting(settings, "adsViewKickMagMin"));
                    gdt_file.WriteLine("		\"adsViewKickCenterSpeed\" \"{0}\"", GetSetting(settings, "adsViewKickCenterSpeed"));
                    gdt_file.WriteLine("		\"adsSpread\" \"{0}\"", GetSetting(settings, "adsSpread"));
                    gdt_file.WriteLine("		\"hipGunKickReducedKickBullets\" \"{0}\"", GetSetting(settings, "hipGunKickReducedKickBullets"));
                    gdt_file.WriteLine("		\"hipGunKickReducedKickPercent\" \"{0}\"", GetSetting(settings, "hipGunKickReducedKickPercent"));
                    gdt_file.WriteLine("		\"hipGunKickPitchMin\" \"{0}\"", GetSetting(settings, "hipGunKickPitchMin"));
                    gdt_file.WriteLine("		\"hipGunKickPitchMax\" \"{0}\"", GetSetting(settings, "hipGunKickPitchMax"));
                    gdt_file.WriteLine("		\"hipGunKickYawMin\" \"{0}\"", GetSetting(settings, "hipGunKickYawMin"));
                    gdt_file.WriteLine("		\"hipGunKickYawMax\" \"{0}\"", GetSetting(settings, "hipGunKickYawMax"));
                    gdt_file.WriteLine("		\"hipGunKickMagMin\" \"{0}\"", GetSetting(settings, "hipGunKickMagMin"));
                    gdt_file.WriteLine("		\"hipGunKickAccel\" \"{0}\"", GetSetting(settings, "hipGunKickAccel"));
                    gdt_file.WriteLine("		\"hipGunKickSpeedMax\" \"{0}\"", GetSetting(settings, "hipGunKickSpeedMax"));
                    gdt_file.WriteLine("		\"hipGunKickSpeedDecay\" \"{0}\"", GetSetting(settings, "hipGunKickSpeedDecay"));
                    gdt_file.WriteLine("		\"hipGunKickStaticDecay\" \"{0}\"", GetSetting(settings, "hipGunKickStaticDecay"));
                    gdt_file.WriteLine("		\"hipViewKickPitchMin\" \"{0}\"", GetSetting(settings, "hipViewKickPitchMin"));
                    gdt_file.WriteLine("		\"hipViewKickPitchMax\" \"{0}\"", GetSetting(settings, "hipViewKickPitchMax"));
                    gdt_file.WriteLine("		\"hipViewKickYawMin\" \"{0}\"", GetSetting(settings, "hipViewKickYawMin"));
                    gdt_file.WriteLine("		\"hipViewKickYawMax\" \"{0}\"", GetSetting(settings, "hipViewKickYawMax"));
                    gdt_file.WriteLine("		\"hipViewKickMagMin\" \"{0}\"", GetSetting(settings, "hipViewKickMagMin"));
                    gdt_file.WriteLine("		\"hipViewKickCenterSpeed\" \"{0}\"", GetSetting(settings, "hipViewKickCenterSpeed"));
                    gdt_file.WriteLine("		\"medDamage\" \"{0}\"", GetSetting(settings, "medDamage"));
                    gdt_file.WriteLine("		\"minDamage\" \"{0}\"", GetSetting(settings, "minDamage"));
                    gdt_file.WriteLine("		\"maxDamageRange\" \"{0}\"", GetSetting(settings, "maxDamageRange"));
                    gdt_file.WriteLine("		\"minDamageRange\" \"{0}\"", GetSetting(settings, "minDamageRange"));
                    gdt_file.WriteLine("		\"damageFirstBullets\" \"{0}\"", GetSetting(settings, "damageFirstBullets"));
                    gdt_file.WriteLine("		\"damageFirst\" \"{0}\"", GetSetting(settings, "damageFirst"));
                    gdt_file.WriteLine("		\"medDamageFirst\" \"{0}\"", GetSetting(settings, "medDamageFirst"));
                    gdt_file.WriteLine("		\"minDamageFirst\" \"{0}\"", GetSetting(settings, "minDamageFirst"));
                    gdt_file.WriteLine("		\"maxDamageRangeFirst\" \"{0}\"", GetSetting(settings, "maxDamageRangeFirst"));
                    gdt_file.WriteLine("		\"minDamageRangeFirst\" \"{0}\"", GetSetting(settings, "minDamageRangeFirst"));
                    gdt_file.WriteLine("		\"destabilizationRateTime\" \"{0}\"", GetSetting(settings, "destabilizationRateTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"destabilizationCurvatureMax\" \"{0}\"", GetSetting(settings, "destabilizationCurvatureMax"));
                    gdt_file.WriteLine("		\"destabilizeDistance\" \"{0}\"", GetSetting(settings, "destabilizeDistance"));
                    gdt_file.WriteLine("		\"overheatUpRate\" \"{0}\"", GetSetting(settings, "overheatUpRate"));
                    gdt_file.WriteLine("		\"overheatDownRate\" \"{0}\"", GetSetting(settings, "overheatDownRate"));
                    gdt_file.WriteLine("		\"overheatDownRateFast\" \"{0}\"", GetSetting(settings, "overheatDownRateFast"));
                    gdt_file.WriteLine("		\"overheatPenalty\" \"{0}\"", GetSetting(settings, "overheatPenalty"));
                    gdt_file.WriteLine("		\"introFireTime\" \"{0}\"", GetSetting(settings, "introFireTime", weapon.isCSVWeapon));
                    gdt_file.WriteLine("		\"introFireLength\" \"{0}\"", GetSetting(settings, "introFireLength"));
                    gdt_file.WriteLine("		\"introFireLerp\" \"{0}\"", GetSetting(settings, "introFireLerp"));
                    gdt_file.WriteLine("		\"sharedAmmo\" \"{0}\"", GetSetting(settings, "sharedAmmo"));
                    gdt_file.WriteLine("		\"rifleBullet\" \"{0}\"", GetSetting(settings, "rifleBullet"));
                    gdt_file.WriteLine("		\"armorPiercing\" \"{0}\"", GetSetting(settings, "armorPiercing"));

                    gdt_file.WriteLine("	}");


                }
                gdt_file.WriteLine("}");
                gdt_file.WriteLine();

            }
        }
        private void SAVE_BUTTON_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            bool selected = button.Name == "SAVE_BUTTON" ? true : false;
            if (WEAPON_LIST.Items.Count == 0)
                return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "GDT File (*.GDT)|*.gdt";
            saveFileDialog.InitialDirectory = Environment.GetEnvironmentVariable("TA_TOOLS_PATH");
            if (saveFileDialog.ShowDialog() == true)
                WriteGDTFile(saveFileDialog.FileName, selected);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Comma Seperated Value File (*.CSV)|*.csv";
            if (openFileDialog.ShowDialog() == true)
                LoadCSVFile(openFileDialog.FileName);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            CSVWeaponStatReader.AboutWindow window = new CSVWeaponStatReader.AboutWindow();
            window.Owner = this;
            window.Show();
        }

        private void WEAP_TYPE_BOX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WEAP_TYPE_BOX.IsDropDownOpen)
            {
                string value = ((ComboBoxItem)WEAP_TYPE_BOX.SelectedItem).Content.ToString();
                Weapon weap = (Weapon)WEAPON_LIST.SelectedItem;
                if (weap != null)
                    weap.WeaponType = value;

                WEAP_TYPE_BOX.IsDropDownOpen = false;
            }
        }
    }
}
