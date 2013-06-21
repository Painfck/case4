using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BussinesLayer.Mindmap;

namespace BussinesLayer
{
    public class Project
    {
        #region attributen

        public IList<Mindmap.MindMap> mindmaplist;
        public Mindmap.MindMap activeMindmap;
        public bool saved;
        #endregion

        public Project()
        {
            mindmaplist = new List<Mindmap.MindMap>();
            mindmaplist.Add(new Mindmap.MindMap("Naamloos"));
            activeMindmap = mindmaplist.ElementAt<Mindmap.MindMap>(0);
        }

        public MindMap createMindmap()
        {
            mindmaplist.Add(new Mindmap.MindMap(String.Format("Naamloos{0}", (mindmaplist.Count() + 1))));
            return mindmaplist.Last<Mindmap.MindMap>();
        }
    }
}
