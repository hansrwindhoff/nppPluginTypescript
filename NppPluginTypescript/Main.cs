using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using NppPluginNET;

namespace NppPluginTypescript
{
  class Main
  {
    #region " Fields "
    internal const string PluginName = "NppPluginTypescript";
    static string iniFilePath = null;
    static bool someSetting = false;
    static frmMyDlg frmMyDlg = null;
    static int idMyDlg = -1;
    static Bitmap tbBmp = Properties.Resources.star;
    static Bitmap tbBmp_tbTab = Properties.Resources.star_bmp;
    static Icon tbIcon = null;
    #endregion

    #region " StartUp/CleanUp "
    internal static void CommandMenuInit()
    {
      StringBuilder sbIniFilePath = new StringBuilder(Win32.MAX_PATH);
      Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETPLUGINSCONFIGDIR, Win32.MAX_PATH, sbIniFilePath);
      iniFilePath = sbIniFilePath.ToString();
      if (!Directory.Exists(iniFilePath)) Directory.CreateDirectory(iniFilePath);
      iniFilePath = Path.Combine(iniFilePath, PluginName + ".ini");
      someSetting = (Win32.GetPrivateProfileInt("SomeSection", "SomeKey", 0, iniFilePath) != 0);

      PluginBase.SetCommand(0, "Build typescript", BuildTypescript, new ShortcutKey(false, false, false, Keys.None));
      PluginBase.SetCommand(1, "Run (node.js) javascript", NodeRunTypescript, new ShortcutKey(false, false, false, Keys.None));
      PluginBase.SetCommand(2, "Plugin info", myDockableDialog); idMyDlg = 1;
    }
    internal static void SetToolBarIcon()
    {
      toolbarIcons tbIcons = new toolbarIcons();
      tbIcons.hToolbarBmp = tbBmp.GetHbitmap();
      IntPtr pTbIcons = Marshal.AllocHGlobal(Marshal.SizeOf(tbIcons));
      Marshal.StructureToPtr(tbIcons, pTbIcons, false);
      Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_ADDTOOLBARICON, PluginBase._funcItems.Items[idMyDlg]._cmdID, pTbIcons);
      Marshal.FreeHGlobal(pTbIcons);
    }
    internal static void PluginCleanUp()
    {
      Win32.WritePrivateProfileString("SomeSection", "SomeKey", someSetting ? "1" : "0", iniFilePath);
    }
    #endregion

    #region " Menu functions "
    internal static void BuildTypescript()
    {

      doBuildTypescript(true);
    }
    internal static void doBuildTypescript(bool alertme =true)
    {
      StringBuilder sbCurFilePath = new StringBuilder(Win32.MAX_PATH);
      Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_SAVECURRENTFILE, 0, 0);
      Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETFULLCURRENTPATH, Win32.MAX_PATH, sbCurFilePath);

      if (Path.GetExtension(sbCurFilePath.ToString()) == ".ts" && !sbCurFilePath.ToString().EndsWith(".d.ts"))
      {
        System.Diagnostics.Process p = new System.Diagnostics.Process();
        p.StartInfo.FileName = "cmd.exe";
        p.StartInfo.Arguments = "/k tsc.exe -v --target ES5 \"" + sbCurFilePath + "\"";
        p.StartInfo.CreateNoWindow = false;
        p.StartInfo.UseShellExecute = true;
        p.Start();
        p.WaitForExit();
        string targetjsFile =
                Path.GetDirectoryName(sbCurFilePath.ToString())
                + @"\"
                + Path.GetFileNameWithoutExtension(sbCurFilePath.ToString())
                + ".js";

        Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_DOOPEN, 0, targetjsFile);
        Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_RELOADFILE, 0, targetjsFile);
      }
      else
      {
        if (alertme)
          MessageBox.Show("This is not a ts file...");
      }
    }



    internal static void NodeRunTypescript()
    {
      StringBuilder sbCurFilePath = new StringBuilder(Win32.MAX_PATH);
      Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_SAVECURRENTFILE, 0, 0);
      Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETFULLCURRENTPATH, Win32.MAX_PATH, sbCurFilePath);

      if (Path.GetExtension(sbCurFilePath.ToString()) == ".js")
      {
        System.Diagnostics.Process p = new System.Diagnostics.Process();
        p.StartInfo.FileName = "cmd.exe";
        p.StartInfo.Arguments = "/k node.exe \"" + sbCurFilePath + "\"";
        p.StartInfo.CreateNoWindow = false;
        p.StartInfo.UseShellExecute = true;
        p.Start();
        p.WaitForExit();
      }
      else
      {
        MessageBox.Show("This is not a js file...");
      }
    }


    internal static void myDockableDialog()
    {
      if (frmMyDlg == null)
      {
        frmMyDlg = new frmMyDlg();

        using (Bitmap newBmp = new Bitmap(16, 16))
        {
          Graphics g = Graphics.FromImage(newBmp);
          ColorMap[] colorMap = new ColorMap[1];
          colorMap[0] = new ColorMap();
          colorMap[0].OldColor = Color.Fuchsia;
          colorMap[0].NewColor = Color.FromKnownColor(KnownColor.ButtonFace);
          ImageAttributes attr = new ImageAttributes();
          attr.SetRemapTable(colorMap);
          g.DrawImage(tbBmp_tbTab, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, attr);
          tbIcon = Icon.FromHandle(newBmp.GetHicon());
        }

        NppTbData _nppTbData = new NppTbData();
        _nppTbData.hClient = frmMyDlg.Handle;
        _nppTbData.pszName = "Typescript plugin info";
        _nppTbData.dlgID = idMyDlg;
        _nppTbData.uMask = NppTbMsg.DWS_DF_CONT_RIGHT | NppTbMsg.DWS_ICONTAB | NppTbMsg.DWS_ICONBAR;
        _nppTbData.hIconTab = (uint)tbIcon.Handle;
        _nppTbData.pszModuleName = PluginName;
        IntPtr _ptrNppTbData = Marshal.AllocHGlobal(Marshal.SizeOf(_nppTbData));
        Marshal.StructureToPtr(_nppTbData, _ptrNppTbData, false);

        Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_DMMREGASDCKDLG, 0, _ptrNppTbData);
      }
      else
      {
        Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_DMMSHOW, 0, frmMyDlg.Handle);
      }
    }
    #endregion
  }
}