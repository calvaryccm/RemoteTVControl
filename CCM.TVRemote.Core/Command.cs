using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.TVRemote.Core
{
    /// <summary>
    /// 0: Power Off
    /// 1: Power On
    /// 2: Power On Command Setting
    /// 3: Input Selection
    /// 4: AV Mode Selection
    /// 5: Toggle Mute
    /// 6: Volume Up
    /// 7: Volume Down
    /// 8: HDMI1
    /// 9: Channel 5
    /// </summary>
    public static class Command
    {
        public const string TurnOn = "POWR1   \r"; //0 - Turn on
        public const string TurnOff = "POWR0   \r"; //1 - Turn off
        public const string EnableRemoteCommands = "RSPW2   \r"; //2 - Enable remote commands
        public const string InputToggle = "ITGDx   \r"; //3 - Input Toggle
        public const string AVModeSelection = "AVMD000 \r"; //4 - AV Mode Selection
        public const string MuteToggle = "MUTE0   \r"; //5 - Mute Toggle
        public const string VolumeUp = "VOLMUP"; //6 - Volume Up
        public const string VolumeDown = "VOLMDN"; //7 - Volume Down
        public const string SwitchToHDMI1 = "IAVD1   \r"; //8 - HDMI1
        public const string SwitchToChannel5 = "DCCH0005\r"; //9 - Channel 5
    }
}
