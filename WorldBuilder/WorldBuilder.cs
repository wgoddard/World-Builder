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
        Point screenTranslation = new Point();

        public WorldBuilder()
        {
            InitializeComponent();

            glWorld.InitializeContexts();
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
                world = new World(WorldTree, "World");
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
            Point pos = new Point();
            pos.X -= screenTranslation.X;
            pos.Y -= screenTranslation.Y;
            texture.Position = pos;
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
            Gl.glTranslated((double)(screenTranslation.X), (double)(screenTranslation.Y), 0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glViewport(0, 0, width, height);

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            try
            {
                world.GetLevel().Draw();
            }
            catch(Exception)
            {}

            foreach (Entity entity in selectedEntities)
            {
                entity.DrawBox();
            }


            //Gl.glMatrixMode(Gl.GL_PROJECTION);
            //Gl.glLoadIdentity();
            //Gl.glOrtho(0, width, 0, height, 0, 1.0);
            //Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Point p1 = AdjustPoint(mouseStart);
            Point p2 = AdjustPoint(mouseCurrent);

            switch (mousemode)
            {
                case MouseMode.SelectEntity:
                    Gl.glColor4f(0.6f, 0.5f, 0.5f, 0.3f);
                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
                    Gl.glBegin(Gl.GL_QUADS);
                    Gl.glVertex2i(p1.X, p1.Y);
                    Gl.glVertex2i(p2.X, p1.Y);
                    Gl.glVertex2i(p2.X, p2.Y);
                    Gl.glVertex2i(p1.X, p2.Y);
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

        Point AdjustPoint(Point point)
        {
            Point p = new Point(point.X, point.Y);
            p.X -= screenTranslation.X;
            p.Y -= screenTranslation.Y;
            return p;
        }

        Rectangle AdjustRectangle(Rectangle rect)
        {
            Rectangle r = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
            r.X -= screenTranslation.X;
            r.Y -= screenTranslation.Y;
            return r;
        }

        private void glWorld_MouseDown(object sender, MouseEventArgs e)
        {
            mouseStart = e.Location;
            mouseStart.Y = glWorld.Height - mouseStart.Y;
            //mouseStart.X -= screenTranslation.X;
            Layer currentLayer = world.GetLayer();
            Entity selectedEntity = null;
            if (currentLayer != null)
            {
                selectedEntity = currentLayer.SelectEntity(AdjustPoint(mouseStart));
               // if (selectedEntity != null)
                propertyGrid.SelectedObject = selectedEntity;
                if (selectedEntity != null)
                    selectedEntity.Select();
            }

            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (selectedEntity != null)
                    {
                        if (selectedEntities.Contains(selectedEntity) == false)
                        {
                            selectedEntities.Clear();
                            selectedEntities.Add(selectedEntity);
                        }
                        mousemode = MouseMode.TranslateEntity;
                        return;
                    }
                    selectedEntities.Clear();
                    mousemode = MouseMode.SelectEntity;
                    break;
                case MouseButtons.Right:
                    if (selectedEntities.Count > 0)
                    { }
                    else
                    {
                        mousemode = MouseMode.TranslateScreen;
                    }
                    break;
                default:
                    break;
            }
            
        }

        private void glWorld_MouseMove(object sender, MouseEventArgs e)
        {

            mouseCurrent = e.Location;
            mouseCurrent.Y = glWorld.Height - mouseCurrent.Y;

            lMouse.Text = "World Position (" + AdjustPoint(mouseCurrent).X.ToString() + ", " + AdjustPoint(mouseCurrent).Y.ToString() + ")";
            lMouseScreen.Text = "Mouse Position (" + mouseCurrent.X.ToString() + ", " + mouseCurrent.Y.ToString() + ")";
            //mouseCurrent.X -= screenTranslation.X;
            int tx, ty = 0;
            switch (mousemode)
            {
                case MouseMode.TranslateEntity:
                    
                    tx = mouseCurrent.X - mouseStart.X;
                    ty = mouseCurrent.Y - mouseStart.Y;
                    mouseStart = mouseCurrent;
                    foreach (Entity entity in selectedEntities)
                    {
                        entity.Translate(tx, ty);
                    }
                    break;
                case MouseMode.TranslateScreen:
                    tx = mouseCurrent.X - mouseStart.X;
                    ty = mouseCurrent.Y - mouseStart.Y;
                    mouseStart = mouseCurrent;
                    screenTranslation.X += tx;
                    screenTranslation.Y += ty;
                    break;
                default:
                    break;
            }


            glWorld.Draw();
            //propertyGrid.Update();

        }

        private void glWorld_MouseUp(object sender, MouseEventArgs e)
        {
            if (mousemode == MouseMode.SelectEntity)
            {
                Layer selectedLayer = world.GetLayer();
                if (selectedLayer != null)
                {
                    Rectangle rect = new Rectangle
                        (mouseStart.X > mouseCurrent.X ? mouseCurrent.X : mouseStart.X,
                        mouseStart.Y > mouseCurrent.Y ? mouseCurrent.Y : mouseStart.Y,
                        Math.Abs(mouseCurrent.X - mouseStart.X),
                        Math.Abs(mouseCurrent.Y - mouseStart.Y));
                    selectedEntities = selectedLayer.SelectEntities(AdjustRectangle(rect));
                    if (selectedEntities.Count > 0)
                        propertyGrid.SelectedObject = selectedEntities[selectedEntities.Count - 1];
                   // MessageBox.Show("Selected " + selectedEntities.Count.ToString() + " entities" + selectedEntities.ToString());
                }
            }
            mousemode = MouseMode.None;
        }

    }
}
