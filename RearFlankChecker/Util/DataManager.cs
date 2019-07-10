
namespace RearFlankChecker.Util
{
    public class DataManager
    {
        private PluginMain plugin;
        private PluginSettings settings;

        public DataManager(PluginMain _plugin)
        {
            plugin = _plugin;
            settings = new PluginSettings(this);

            ACTTabControl ctl = plugin.ACTTabControl;
            settings.AddControlSetting("SoundEnable", ctl.checkSoundEnable);
            settings.AddControlSetting("ViewVisible", ctl.checkViewVisible);
            settings.AddControlSetting("ViewMouseEnable", ctl.checkViewMouseEnable);
            settings.AddControlSetting("ViewX", ctl.udViewX);
            settings.AddControlSetting("ViewY", ctl.udViewY);
            // 互換性のため OpacityPercentage で保存
            //settings.AddControlSetting("Opacity", ctl.trackBarOpacity);
            settings.AddIntSetting("OpacityPercentage");
        }

        public int OpacityPercentage
        {
            get { return plugin.ACTTabControl.trackBarOpacity.Value; }
            set { plugin.ACTTabControl.trackBarOpacity.Value = value; }
        }

        public void Load()
        {
            settings.Load();
        }

        public void Save()
        {
            settings.Save();
        }
    }
}
