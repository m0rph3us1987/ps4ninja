namespace PS4FileNinja
{
    public class MountPoint
    {
        public string Path;
        public int DeviceID;

        public MountPoint()
        {

        }

        public MountPoint(string path, int deviceid)
        {
            this.Path = path;
            this.DeviceID = deviceid;
        }
    }
}
