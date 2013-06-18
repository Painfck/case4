using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinesLayer
{
    public class Project
    {
        #region attributen

        public IList<Mindmap.MindMap> mindmaplist;

        #endregion

        public Project()
        {
            mindmaplist = new List<Mindmap.MindMap>();
            mindmaplist.Add(new Mindmap.MindMap("Naamloos"));
        }

        public Mindmap.MindMap createMindmap()
        {
            mindmaplist.Add(new Mindmap.MindMap(String.Format("Naamloos{0}", (mindmaplist.Count() + 1))));
            return mindmaplist.Last<Mindmap.MindMap>();
        }
    }
}
