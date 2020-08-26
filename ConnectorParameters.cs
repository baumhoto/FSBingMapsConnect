using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SimMapsConnect.Main;

namespace FSBingMapsConnect
{
    public class ConnectorParameters
    {
        public FsSimResponse Response { get; set; }

        public int ZoomLevel { get; set; }

        public bool AlignZoom { get; set; }

        public string MapType { get; set; }

        public int Pitch { get; set; }

    }
}
