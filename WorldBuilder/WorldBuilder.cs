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
        double screenZoom = 1.0f;
        bool gridAlign = false;
        bool showGrid = true;

        public WorldBuilder()
        {
            InitializeComponent();

            glWorld.InitializeContexts();
            Il.ilInit();
            Ilu.iluInit();
            Ilut.ilutInit();
            Ilut.ilutEnable(Ilut.ILUT_OPENGL_CONV);
            Ilut.ilutRenderer(Ilut.ILUT_OPENGL);

            this.MouseWheel += new MouseEventHandler(WorldBuilder_MouseWheel);
        }

        void WorldBuilder_MouseWheel(object sender, MouseEventArgs e)
        {
            //Point newMouse = new Point(mouseCurrent.X, mouseCurrent.Y);
            //newMouse.X = (int)(newMouse.X * screenZoom);
            //newMouse.Y = (int)(newMouse.Y * screenZoom);

            //if (e.Delta > 0)
            //{
            //    //screenTranslation.X += -(mouseCurrent.X - glWorld.Width / 2);
            //    //screenTranslation.Y += -(mouseCurrent.Y - glWorld.Height / 2);
            //}
            screenZoom += 0.001 * e.Delta;
            if (screenZoom < 0.1)
                screenZoom = 0.01;


            //newMouse.X = (int)(newMouse.X / screenZoom);
            //newMouse.Y = (int)(newMouse.Y / screenZoom);

            //screenTranslation.X += newMouse.X - mouseCurrent.X;
            //screenTranslation.Y += newMouse.Y - mouseCurrent.Y;


            //throw new NotImplementedException();
            glWorld.Draw();
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
           // if (mousemode == MouseMode.StampEntity) return;

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
                selectedEntities.Clear();
                selectedEntities.Add((Entity)node.Tag);
            }

           // MessageBox.Show(typeof(Entity).ToString());
           //MessageBox.Show(node.Tag.GetType().ToString());

            world.Select(level, layer);
            glWorld.Draw();

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
           // Layer layer = world.GetLayer();
           // if (layer == null) return;

            //MessageBox.Show(sender.ToString());

            Texture texture = new Texture(Resources.Manager.GetImage(((ListView)sender).SelectedItems[0].Text));
            //Point pos = new Point();
            //pos.X -= screenTranslation.X;
            //pos.Y -= screenTranslation.Y;
            //texture.Position = pos;
            //layer.AddEntity(texture);
            mousemode = MouseMode.StampEntity;
            mouseStamp = texture;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(world.GetLevel().Name);

            screenZoom = 1;
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
            Gl.glScaled(screenZoom, screenZoom, 0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glViewport(0, 0, width, height);

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            try
            {
                world.GetLevel().Draw();
                Layer l = world.GetLayer();
                if (showGrid && l.GridX > 0 && l.GridY > 0)
                {
                    Gl.glColor3f(1, 1, 1);
                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
                    Gl.glBegin(Gl.GL_LINES);
             
                    for (int x = 0; x < (glWorld.Width - screenTranslation.X) / screenZoom; x += l.GridX)
                    {
                        for (int y = 0; y < (glWorld.Height - screenTranslation.Y) / screenZoom; y += l.GridY)
                        {
                            Gl.glVertex2i(x,y);
                            Gl.glVertex2i(x,y + glWorld.Height);

                            Gl.glVertex2i(x, y);
                            Gl.glVertex2i(x + glWorld.Width, y);
                        }
                    }
                    Gl.glEnd();
                }
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
                case MouseMode.StampEntity:
                    Gl.glColor4f(1.0f, 1.0f, 1.0f, 0.5f);
                    Point mouse = AdjustPoint(mouseCurrent);
                    mouseStamp.X = mouse.X;
                    mouseStamp.Y = mouse.Y;
                    if (gridAlign == true && world.GetLayer().GridX > 0 && world.GetLayer().GridY > 0)
                    {
                        mouseStamp.X = mouseStamp.X - mouseStamp.X % world.GetLayer().GridX + mouseStamp.Width/2;
                        //mouseStamp.X -= (mouse.X - mouseStamp.Width / 2) % world.GetLayer().GridX;
                        mouseStamp.Y = mouseStamp.Y - mouseStamp.Y % world.GetLayer().GridY + mouseStamp.Height / 2;
                       // mouseStamp.Y -= (mouse.Y - mouseStamp.Height / 2) % world.GetLayer().GridY;
                    }
                    mouseStamp.Draw();
                    break;
                case MouseMode.TileEntity:
                    Gl.glColor4f(1.0f, 1.0f, 1.0f, 0.5f);
                    Point mouseNow = AdjustPoint(mouseCurrent);
                    Point mouseS = AdjustPoint(mouseStart);
                    if (gridAlign == true && world.GetLayer().GridX > 0 && world.GetLayer().GridY > 0)
                    {
                        //mouseNow.X = mouseNow.X - mouseNow.X % world.GetLayer().GridX + mouseStamp.Width / 2;
                        //mouseNow.Y = mouseNow.Y - mouseNow.Y % world.GetLayer().GridY + mouseStamp.Height / 2;
                        mouseS.X = mouseS.X - mouseS.X % world.GetLayer().GridX + mouseStamp.Width / 2 - mouseStamp.Width;
                        mouseS.Y = mouseS.Y - mouseS.Y % world.GetLayer().GridY + mouseStamp.Height / 2 + mouseStamp.Height;
                    }
                    else
                    {
                        mouseS.X -= mouseStamp.Width / 2;
                        mouseS.Y += mouseStamp.Height / 2;
                    }
                    mouseNow.X += mouseStamp.Width / 2;
                    mouseNow.Y -= mouseStamp.Height / 2;

                    int startY = mouseS.Y;
                    do
                    {
                        mouseS.X += mouseStamp.Width;
                        while (mouseS.Y - mouseNow.Y > mouseStamp.Height)
                        {
                            mouseS.Y -= mouseStamp.Height;
                            mouseStamp.X = mouseS.X;
                            mouseStamp.Y = mouseS.Y;
                            mouseStamp.Draw();
                        }
                        mouseS.Y = startY;
                    } while (mouseNow.X - mouseS.X > mouseStamp.Width);
                    break;
                case MouseMode.ScaleEntity:
                    //Gl.glColor4f(1, 1, 1, 0);
                   // Gl.glPointSize(2);
                    Gl.glBegin(Gl.GL_LINES);
                    Gl.glVertex2i(p1.X, p1.Y);
                    Gl.glVertex2i(p2.X, p2.Y);
                    Gl.glEnd();
                    break;
                default:
                    break;

            }

            Gl.glColor3f(1.0f, 1.0f, 1.0f);



        }

        Point mouseStart;
        Point mouseCurrent;

        enum MouseMode { None, TranslateEntity, RotateEntity, ScaleEntity, TranslateScreen, SelectEntity, StampEntity, TileEntity };
        MouseMode mousemode = MouseMode.None;
        Entity mouseStamp = null;

        bool mouseLeftDown = false;

        Point AdjustPoint(Point point)
        {
            Point p = new Point(point.X, point.Y);
            p.X -= screenTranslation.X;
            p.X = (int)(p.X / screenZoom);
            p.Y -= screenTranslation.Y;
            p.Y = (int)(p.Y / screenZoom);
            return p;
        }

        Rectangle AdjustRectangle(Rectangle rect)
        {
            Rectangle r = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
            r.X -= screenTranslation.X;
            r.X = (int)(r.X / screenZoom);
            r.Width = (int)(r.Width / screenZoom);
            r.Y -= screenTranslation.Y;
            r.Y = (int)(r.Y / screenZoom);
            r.Height = (int)(r.Height / screenZoom);
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
                    if (mousemode == MouseMode.None)
                    {
                        if (selectedEntity != null)
                        {
                            //MessageBox.Show("There are " + selectedEntities.Count.ToString() + " entities.");
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
                    }
                    if (mousemode == MouseMode.StampEntity)
                    {
                        mouseLeftDown = true;
                    }
                    break;
                case MouseButtons.Right:
                    if (mousemode == MouseMode.StampEntity)
                        mousemode = MouseMode.None;
                    if (selectedEntities.Count > 0)
                    {
                        mousemode = MouseMode.ScaleEntity;
                    }
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

            Point mouseAdjust = AdjustPoint(mouseCurrent);
            lMouse.Text = "World Position (" + mouseAdjust.X.ToString() + ", " + mouseAdjust.Y.ToString() + ")";
            lMouseScreen.Text = "Mouse Position (" + mouseCurrent.X.ToString() + ", " + mouseCurrent.Y.ToString() + ")";
            //mouseCurrent.X -= screenTranslation.X;
            float tx, ty = 0;
            switch (mousemode)
            {
                case MouseMode.TranslateEntity:
                    
                    tx = mouseCurrent.X - mouseStart.X;
                    ty = mouseCurrent.Y - mouseStart.Y;
                    mouseStart = mouseCurrent;
                    if (screenZoom != 1)
                    {
                        tx = (tx / (float)screenZoom);
                        ty = (ty / (float)screenZoom);
                    }
                    foreach (Entity entity in selectedEntities)
                    {
                        entity.Translate(tx, ty);
                    }
                    break;
                case MouseMode.TranslateScreen:
                    tx = mouseCurrent.X - mouseStart.X;
                    ty = mouseCurrent.Y - mouseStart.Y;
                    mouseStart = mouseCurrent;
                    screenTranslation.X += (int)tx;
                    screenTranslation.Y += (int)ty;
                    break;
                case MouseMode.ScaleEntity:
                    float scale = (mouseCurrent.X - mouseStart.X) * 0.001f;
                    foreach (Entity entity in selectedEntities)
                    {
                        entity.ScaleX += scale;
                        entity.ScaleY += scale;
                    }
                    break;
                case MouseMode.StampEntity:
                    if (mouseLeftDown == true && (Math.Abs(mouseCurrent.X - mouseStart.X) > 10 || Math.Abs(mouseStart.Y - mouseCurrent.Y) > 10))
                    {
                        mousemode = MouseMode.TileEntity;
                    }
                    break;
                default:
                    break;
            }


            glWorld.Draw();
            //propertyGrid.Update();

        }

        private void glWorld_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mouseLeftDown = false;
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
            else if (mousemode == MouseMode.ScaleEntity)
            {
                if (mouseCurrent.X == mouseStart.X && mouseCurrent.Y == mouseStart.Y)
                {
                    mousemode = MouseMode.None;
                    selectedEntities.Clear();
                }
            }
            else if (mousemode == MouseMode.StampEntity)
            {
                mouseStamp.Position = AdjustPoint(mouseCurrent);
                if (gridAlign == true && world.GetLayer().GridX > 0 && world.GetLayer().GridY > 0)
                {
                    mouseStamp.X = mouseStamp.X - mouseStamp.X % world.GetLayer().GridX + mouseStamp.Width / 2;
                    //mouseStamp.X -= (mouse.X - mouseStamp.Width / 2) % world.GetLayer().GridX;
                    mouseStamp.Y = mouseStamp.Y - mouseStamp.Y % world.GetLayer().GridY + mouseStamp.Height / 2;
                    // mouseStamp.Y -= (mouse.Y - mouseStamp.Height / 2) % world.GetLayer().GridY;
                }
                Layer currentLayer = world.GetLayer();
                currentLayer.AddEntity(mouseStamp.Clone());
                mousemode = MouseMode.StampEntity;
                //mouseStamp.
                //MessageBox.Show(mouseStamp.Name);
            }
            else if (mousemode == MouseMode.TileEntity)
            {
                Point mouseNow = AdjustPoint(mouseCurrent);
                Point mouseS = AdjustPoint(mouseStart);
                if (gridAlign == true && world.GetLayer().GridX > 0 && world.GetLayer().GridY > 0)
                {
                    //mouseNow.X = mouseNow.X - mouseNow.X % world.GetLayer().GridX + mouseStamp.Width / 2;
                    //mouseNow.Y = mouseNow.Y - mouseNow.Y % world.GetLayer().GridY + mouseStamp.Height / 2;
                    mouseS.X = mouseS.X - mouseS.X % world.GetLayer().GridX + mouseStamp.Width / 2 - mouseStamp.Width;
                    mouseS.Y = mouseS.Y - mouseS.Y % world.GetLayer().GridY + mouseStamp.Height / 2 + mouseStamp.Height;
                }
                else
                {
                    mouseS.X -= mouseStamp.Width / 2;
                    mouseS.Y += mouseStamp.Height / 2;
                }
                mouseNow.X += mouseStamp.Width / 2;
                mouseNow.Y -= mouseStamp.Height / 2;

                int startY = mouseS.Y;
                do
                {
                    mouseS.X += mouseStamp.Width;
                    while (mouseS.Y - mouseNow.Y > mouseStamp.Height)
                    {
                        mouseS.Y -= mouseStamp.Height;
                        mouseStamp.X = mouseS.X;
                        mouseStamp.Y = mouseS.Y;
                        //mouseStamp.Draw();
                        Layer currentLayer = world.GetLayer();
                        currentLayer.AddEntity(mouseStamp.Clone());
                        mousemode = MouseMode.StampEntity;
                    }
                    mouseS.Y = startY;
                } while (mouseNow.X - mouseS.X > mouseStamp.Width);
            }

            if (mousemode != MouseMode.StampEntity )
            {
                mousemode = MouseMode.None;
                mouseStamp = null;
            }

            //MessageBox.Show("There are now " + selectedEntities.Count.ToString() + " entities selected and mouse type is " + mousemode.ToString());
        }

        private void WorldTree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void WorldTree_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void WorldTree_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode SourceNode;


            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);
                SourceNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");

                if (SourceNode == DestinationNode) return;

                //MessageBox.Show("Source " + SourceNode.Tag.ToString() + " Dest " + DestinationNode.Tag.ToString());
                if (DestinationNode.Tag.GetType().BaseType == typeof(Entity))
                {
                    if (SourceNode.Tag.GetType().BaseType == typeof(Entity))
                    {
                        //Move SourceNode above Destination
                        //Remove from previous Layer
                        ((Layer)SourceNode.Parent.Tag).DeleteNode(SourceNode);
                        DestinationNode.Parent.Nodes.Insert(DestinationNode.Index, SourceNode);
                        SourceNode.TreeView.SelectedNode = SourceNode;
                        ((Layer)SourceNode.Parent.Tag).SortNodes();
                        //Add to target's layer (above target)
                    }
                }
                if (DestinationNode.Tag.GetType() == typeof(Layer))
                {
                    if (SourceNode.Tag.GetType().BaseType == typeof(Entity))
                    {
                        //Move entity to bottom of layer
                        ((Layer)SourceNode.Parent.Tag).DeleteNode(SourceNode);
                        DestinationNode.Nodes.Add(SourceNode);
                        SourceNode.TreeView.SelectedNode = SourceNode;
                        ((Layer)SourceNode.Parent.Tag).SortNodes();
                    }
                    if (SourceNode.Tag.GetType() == typeof(Layer))
                    {
                        //Move SourceNode above DestNode
                    }

                    

                }
            }

            glWorld.Draw();

        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            gridAlign = !gridAlign;

        }

        private void bShowGrid_Click(object sender, EventArgs e)
        {
            showGrid = !showGrid;
        }


    }
}
