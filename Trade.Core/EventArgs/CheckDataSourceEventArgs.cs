using System.ComponentModel;

namespace Trade.Core.EventArgs
{
    public class CheckDataSourceEventArgs : CancelEventArgs
    {
        public CheckDataSourceEventArgs(string source)
        {
            Source = source;
        }

        public string Source { get; set; }
    }
}