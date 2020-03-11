using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using USBEasy.Properties;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.CSharp;

namespace USBEasy
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.AllFilesAndFolders)]
    public class USBCore : SharpContextMenu
    {
        protected override bool CanShowMenu()
        {
            return true;
        }

        protected override ContextMenuStrip CreateMenu()
        {
            var drives = DriveInfo.GetDrives();
            var menu = new ContextMenuStrip();

            var subItemContainer = new ToolStripMenuItem { Text = "USBEasy" };

            subItemContainer.Image = Resources.USBEasy_icon6;

            foreach (var drive in drives)
                if (drive.DriveType == DriveType.Removable)
                {
                    float freeSpacePercentage = ((float)drive.TotalFreeSpace / (float)drive.TotalSize) * 100;

                    var ctxMenuItem = new ToolStripMenuItem { Text = "Copy To " + drive.Name.ToString() + drive.VolumeLabel + " [" + freeSpacePercentage.ToString("0.00") + " % free]" };

                    ctxMenuItem.Image = Resources.USBEasy_icon6;
                    ctxMenuItem.Click += (sender, args) => ExecuteCopy(drive.Name);

                    menu.Items.Add(ctxMenuItem);
                }
            return menu;
        }

        public void ExecuteCopy(String driveName)
        {
            Thread t = new Thread(() =>
            {
                SHFileOperationAPI shFileOp = new SHFileOperationAPI(FormatPathForShell(driveName), driveName);
                shFileOp.Execute();
            });

            t.Start();
        }

        public String FormatPathForShell(String driveName)
        {
            List<String> formattedList = new List<string>();

            foreach (var item in SelectedItemPaths)
                formattedList.Add(item + "\0");

            return String.Join("", formattedList.ToArray());
        }
    }
}
