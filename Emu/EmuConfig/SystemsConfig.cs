using System;
using System.Xml.Linq;

namespace EmuConfig
{
    public class SystemsConfig
    {
        //private String workingDir = Directory.GetCurrentDirectory();
        private String workingDir = @"C:\Projects\Emulation\ProjectEmu";
        private String systemsConfigSubPath = @"\EmulationStation\.emulationstation\es_systems.cfg";
        private String romRoot = null;

        private string GetCOnfigFilePath()
        {
            return workingDir + systemsConfigSubPath;
        }

        public string GetRomRoot()
        {
            return romRoot;
        }

        public void LoadSystemsConfigFile()
        {
            XDocument configFile = XDocument.Load(GetCOnfigFilePath());
            foreach (var node in configFile.Descendants("system"))
            {
                String systemName = (String)node.Element("name");
                String systemPath = (String)node.Element("path");
                String systemRoot = systemPath.Replace($"\\{systemName}", "");
                if (romRoot != null && romRoot != systemRoot)
                {
                    // TODO Throw if there are romRoot path differences between systems
                }
                else
                {
                    romRoot = systemRoot;
                }
            }
        }
    }
}