using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tao.OpenGl;
using Tao.Platform.Windows;
using Tao.DevIl;


namespace WorldBuilder
{
    public partial class WorldBuilder : Form
    {
        private World world = null;

        public WorldBuilder()
        {
            InitializeComponent();

            Il.ilInit();
            Ilu.iluInit();
            Ilut.ilutInit();
            Ilut.ilutEnable(Ilut.ILUT_OPENGL_CONV);
            Ilut.ilutRenderer(Ilut.ILUT_OPENGL);
        }

        ~WorldBuilder()
        {
            glWorld.DestroyContexts();
        }

        private void glWorld_Load(object sender, EventArgs e)
        {
            glWorld.InitializeContexts();
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            Gl.glDisable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_BLEND);
        }

        private void newWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (world == null)
                world = new World(WorldTree, "Default");
            propertyGrid.SelectedObject = world;
        }

        private void WorldTree_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("test");
            //MessageBox.Show(((TreeView)(sender)).SelectedNode.Text);
            //MessageBox.Show(sender.GetType().ToString());
            //MessageBox.Show(sender.ToString());

        }

        private void WorldTree_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void WorldTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView tv = (TreeView)sender;
            TreeNode node = tv.SelectedNode;
            if (node == null) { MessageBox.Show("Null"); return; }
            propertyGrid.SelectedObject = node.Tag;

            Level level = null;
            Layer layer = null;
            if (node.Tag.GetType() == typeof(Level))
                level = (Level)node.Tag;
            if (node.Tag.GetType() == typeof(Layer))
            {
                layer = (Layer)node.Tag;
                level = (Level)node.Parent.Tag;
            }

            world.Select(level, layer);
        }

    }
}
