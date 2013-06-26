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
        public static Project project;
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

        public static Project projectInstance()
        {
            if (project != null)
            {
                return project;
            }
            else
            {
                project = new Project();
                return project;
            }
        }
        public MindMap searchMindmap(string name)
        {
            foreach(MindMap mindmap in mindmaplist)
            {
                if (mindmap.name == name)
                {
                    return mindmap;
                }
                else
                {
                    continue;
                }
            }
            return null;
        }
        public MindMap createMindmap()
        {
            mindmaplist.Add(new Mindmap.MindMap(String.Format("Naamloos{0}", (mindmaplist.Count() + 1))));
            return mindmaplist.Last<Mindmap.MindMap>();
        }


    }
}
