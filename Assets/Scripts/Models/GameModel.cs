using System.Collections.Generic;
using Data;

namespace Models
{
    public class GameModel
    {
        public List<SideSettings> SideRandomSettings { get; }

        public GameModel( List<SideSettings> sideRandomSettings)
        {
            SideRandomSettings = sideRandomSettings;
        }
    }
}