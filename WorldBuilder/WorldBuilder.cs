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
        List<Entity> selectedEntities = new List<Entity>();

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
            Gl.glClearColor(0.0f, 0.0f, 0.0f,0.0f);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            Gl.glDisable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
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
            if (node.Tag.GetType().BaseType == typeof(Entity))
            {
                layer = (Layer)node.Parent.Tag;
                level = (Level)node.Parent.Parent.Tag;
            }

           // MessageBox.Show(typeof(Entity).ToString());
           //MessageBox.Show(node.Tag.GetType().ToString());

            world.Select(level, layer);
        }

        private void addTexturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = openTextures;

            DialogResult r = d.ShowDialog();

            if (r == DialogResult.OK)
            {
                foreach (string file in d.FileNames)
                {
                    textureList.Images.Add(new Bitmap(file));
                    ListViewItem item = new ListViewItem(file);
                    item.ImageIndex = listTextures.Items.Count;
                    listTextures.Items.Add(item);
                    Resources.Manager.AddImage(new Image(file));
                }
            }
        }

        private void listTextures_DoubleClick(object sender, EventArgs e)
        {
            Layer layer = world.GetLayer();
            if (layer == null) return;

            //MessageBox.Show(sender.ToString());

            Texture texture = new Texture(Resources.Manager.GetImage(((ListView)sender).SelectedItems[0].Text));
            layer.AddEntity(texture);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(world.GetLevel().Name);

            glWorld.Draw();

        }

        private void glWorld_Paint(object sender, PaintEventArgs e)
        {
            int width = glWorld.Width;
            int height = glWorld.Height;




            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(0, width, 0, height, 0, 1.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glViewport(0, 0, width, height);

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            try
            {
                world.GetLevel().Draw();
            }
            catch(Exception)
            {}


            switch (mousemode)
            {
                case MouseMode.SelectEntity:
                    Gl.glColor4f(0.6f, 0.5f, 0.5f, 0.3f);
                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
                    Gl.glBegin(Gl.GL_QUADS);
                    Gl.glVertex2i(mouseStart.X, mouseStart.Y);
                    Gl.glVertex2i(mouseCurrent.X, mouseStart.Y);
                    Gl.glVertex2i(mouseCurrent.X, mouseCurrent.Y);
                    Gl.glVertex2i(mouseStart.X, mouseCurrent.Y);
                    Gl.glEnd();
                    break;
                default:
                    break;

            }

            Gl.glColor3f(1.0f, 1.0f, 1.0f);



        }

        Point mouseStart;
        Point mouseCurrent;

        enum MouseMode { None, TranslateEntity, RotateEntity, ScaleEntity, TranslateScreen, SelectEntity };
        MouseMode mousemode = MouseMode.None;

        private void glWorld_MouseDown(object sender, MouseEventArgs e)
        {
            mouseStart = e.Location;
            mouseStart.Y = glWorld.Height - mouseStart.Y;
            Layer currentLayer = world.GetLayer();
            if (selectedEntities.Count > 0)
            {
                // if mouse clicks on entity
                if (currentLayer != null && currentLayer.SelectEntity(mouseStart) != null)
                {

                    switch (e.Button)
                    {
                        case MouseButtons.Left:
                            mousemode = MouseMode.TranslateEntity;
                            return;
                        default:
                            mousemode = MouseMode.None;
                            break;
                    }
                    //switch mousebutton
                        //mousemode = TranslateEntity(s)/Rotate/Scale
                }
                else
                { 
                    propertyGrid.SelectedObject = null;
                    selectedEntities.Clear();
                    //unselected entities
                }
            }
            switch (e.Button)
            {
                case MouseButtons.Left:
                    //Test Point for Entity
                    //Layer currentLayer = world.GetLayer();
                    if (currentLayer != null && currentLayer.SelectEntity(mouseStart) != null)
                    {
                        propertyGrid.SelectedObject = world.GetLayer().SelectEntity(mouseStart);
                        mousemode = MouseMode.TranslateEntity;
                        selectedEntities.Add(currentLayer.SelectEntity(mouseStart));
                    }
                      // if entity
                      // mousemode = TranslateEntity
                    //else
                    mousemode = MouseMode.SelectEntity;
                    break;
                case MouseButtons.Right:
                    //TranslateScreen
                    break;
                default:
                    break;
            }
        }

        private void glWorld_MouseMove(object sender, MouseEventArgs e)
        {

            mouseCurrent = e.Location;
            mouseCurrent.Y = glWorld.Height - mouseCurrent.Y;
            glWorld.Draw();

        }

        private void glWorld_MouseUp(object sender, MouseEventArgs e)
        {
            mousemode = MouseMode.None;
        }

    }
}
