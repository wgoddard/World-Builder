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
using System.Drawing.Imaging;


namespace WorldBuilder
{
    public partial class WorldBuilder : Form
    {
        private World world = null;
        List<Entity> selectedEntities = new List<Entity>();
        Point screenTranslation = new Point();
        double screenZoom = 1.0f;

        //Interface Settings
        bool gridAlign = false;
        bool showGrid = true;
        bool deleteBottomTile = true;


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

            //double sz = screenZoom;

            double x = screenTranslation.X / screenZoom;
            double y = screenTranslation.Y / screenZoom;

            screenZoom += 0.001 * e.Delta;
            if (screenZoom < 0.1)
                screenZoom = 0.01;

            screenTranslation.X = (int)(x * screenZoom);
            screenTranslation.Y = (int)(y * screenZoom);



            glWorld.Draw();
        }

        ~WorldBuilder()
        {
            glWorld.DestroyContexts();
        }

        private void glWorld_Load(object sender, EventArgs e)
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f,0.0f);
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

        private void WorldTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
           // if (mousemode == MouseMode.StampEntity) return;

            TreeView tv = (TreeView)sender;
            TreeNode node = tv.SelectedNode;
            if (node == null) { MessageBox.Show("Null"); return; }
            propertyGrid.SelectedObject = node.Tag;

            Level level = null;
            Layer layer = null;

            if (node.Tag is Level)
                level = (Level)node.Tag;
            if (node.Tag is Layer)
            {
                layer = (Layer)node.Tag;
                level = (Level)node.Parent.Tag;
            }
            if (node.Tag is Entity)
            {
                layer = (Layer)node.Parent.Tag;
                level = (Level)node.Parent.Parent.Tag;
                if (e.Action != TreeViewAction.Unknown || tv.Focused)
                {
                    selectedEntities.Clear();
                    selectedEntities.Add((Entity)node.Tag);
                }
            }

           // MessageBox.Show(typeof(Entity).ToString());
           //MessageBox.Show(node.Tag.GetType().ToString());

            world.Select(level, layer);
            glWorld.Draw();

        }

        private void addTexturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTextures();
        }

        private void bOpenTextures_Click(object sender, EventArgs e)
        {
            OpenTextures();
        }

        private void OpenTextures()
        {
            OpenFileDialog d = openTextures;

            DialogResult r = d.ShowDialog();

            if (r == DialogResult.OK)
            {
                foreach (string file in d.FileNames)
                {
                    try
                    {
                        textureList.Images.Add(new Bitmap(file));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(file + " is invalid/unsupported.");
                        continue;
                    }
                    ListViewItem item = new ListViewItem(System.IO.Path.GetFileName(file));
                    item.ImageIndex = listTextures.Items.Count;
                    listTextures.Items.Add(item);
                    Image i = new Image(file);
                    Resources.Manager.AddImage(i);
                    item.Tag = i;
                }
            }
        }

        private void listTextures_DoubleClick(object sender, EventArgs e)
        {
           // Layer layer = world.GetLayer();
           // if (layer == null) return;

            //MessageBox.Show(sender.ToString());

            Texture texture = new Texture((Image)((ListView)sender).SelectedItems[0].Tag);

            mousemode = MouseMode.StampEntity;
            mouseStamp = texture;
            selectedEntities.Clear();
        }

        private void glWorld_Paint(object sender, PaintEventArgs e)
        {
            int width = glWorld.Width;
            int height = glWorld.Height;




            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(0, width, 0, height, 0, 1);
            //Gl.glOrtho(-width / 2, width / 2, -height / 2, height / 2, 0, 1);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glTranslated((double)(screenTranslation.X), (double)(screenTranslation.Y), 0);
            Gl.glScaled(screenZoom, screenZoom, 0);

            Gl.glViewport(0, 0, width, height);

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            try
            {
                Level level = world.GetLevel();

                Gl.glColor3f(1, 1, 1);
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);

                Gl.glBegin(Gl.GL_LINE_LOOP);

                Gl.glVertex2i(0, 0);
                Gl.glVertex2i(level.Width, 0);
                Gl.glVertex2i(level.Width, level.Height);
                Gl.glVertex2i(0, level.Height);

                Gl.glEnd();



                Layer layer = world.GetLayer();
                if (showGrid && layer.GridX > 0 && layer.GridY > 0)
                {
                    Gl.glBegin(Gl.GL_LINES);
                    int GridX = layer.GridX;
                    int GridY = layer.GridY;
             
                    //for (int x = 0; x < (width - screenTranslation.X) / screenZoom && x < world.GetLevel().Width; x += GridX)
                    //{
                    //    for (int y = 0; y < (height - screenTranslation.Y) / screenZoom && y < world.GetLevel().Height; y += GridY)
                    //    {
                    //        Gl.glVertex2i(x,y);
                    //        Gl.glVertex2i(x,y + height);

                    //        Gl.glVertex2i(x, y);
                    //        Gl.glVertex2i(x + width, y);
                    //    }
                    //}
                    for (int x = 0; x <= level.Width; x += GridX)
                    {
                        Gl.glVertex2i(x,0);
                        Gl.glVertex2i(x,level.Height);
                    }
                    for (int y = 0; y <= level.Height; y += GridY)
                    {
                        Gl.glVertex2i(0, y);
                        Gl.glVertex2i(level.Width, y);
                    }
                    Gl.glEnd();

                }
                level.Draw();
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
                    Gl.glColor4f(1.0f, 0.5f, 0.5f, 0.5f);
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
                case MouseMode.DrawRect:
                    Gl.glColor4f(1.0f, 1.0f, 1.0f, 0.5f);
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
                       
                        mouseS.X -= mouseStamp.Width;// / 2;
                        mouseS.Y += mouseStamp.Height;// / 2;
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

        enum MouseMode { None, TranslateEntity, RotateEntity, ScaleEntity, TranslateScreen, SelectEntity, StampEntity, TileEntity, DrawRect, PreDrawRect };
        MouseMode mousemode = MouseMode.None;
        Entity mouseStamp = null;
        Point mouseRectStart;

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
            if (world == null) return;
            if (world.GetLayer() == null) return;

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
                glWorld.Focus();
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
                    if (mousemode == MouseMode.PreDrawRect)
                    {
                        mousemode = MouseMode.DrawRect;
                        mouseRectStart = AdjustPoint(mouseCurrent);
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
            if (world == null) return;
            //if (world.GetLayer() == null) return;

            mouseCurrent = e.Location;
            mouseCurrent.Y = glWorld.Height - mouseCurrent.Y;

            Point mouseAdjust = AdjustPoint(mouseCurrent);
            lMouse.Text = "World (" + mouseAdjust.X.ToString() + ", " + mouseAdjust.Y.ToString() + ")";
            lMouseScreen.Text = "Mouse (" + mouseCurrent.X.ToString() + ", " + mouseCurrent.Y.ToString() + ")";
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
                case MouseMode.DrawRect:
                    Point a = AdjustPoint(mouseCurrent);
                    //Point b = AdjustPoint(mouseStart);
                    Point b = mouseRectStart;
                    if (gridAlign == true && world.GetLayer().GridX > 0 && world.GetLayer().GridY > 0)
                    {
                        b.X -= b.X % world.GetLayer().GridX;
                        b.Y += world.GetLayer().GridY - b.Y % world.GetLayer().GridY;
                        //a.X += world.GetLayer().GridX - a.X % world.GetLayer().GridX;
                        //a.Y += world.GetLayer().GridY - a.Y % world.GetLayer().GridY;
                        a.X += world.GetLayer().GridX - a.X % world.GetLayer().GridX;
                        a.Y -= a.Y % world.GetLayer().GridY;
                       // b.X -= b.X % world.GetLayer().GridX;
                        //b.Y -= b.Y % world.GetLayer().GridY;
                        if (a.X == b.X) b.X += world.GetLayer().GridX;
                        if (a.Y == b.Y) b.Y += world.GetLayer().GridY;

                    }
                    ((RectShape)mouseStamp).AdjustToPoints(a,b);
                    break;
                default:
                    break;
            }


            glWorld.Draw();
            //propertyGrid.Update();

        }

        private void glWorld_MouseUp(object sender, MouseEventArgs e)
        {
            if (world == null) return;
            if (world.GetLayer() == null) return;

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
                Layer currentLayer = world.GetLayer();
                mouseStamp.Position = AdjustPoint(mouseCurrent);
                if (gridAlign == true && world.GetLayer().GridX > 0 && world.GetLayer().GridY > 0)
                {
                    mouseStamp.X = mouseStamp.X - mouseStamp.X % world.GetLayer().GridX + mouseStamp.Width / 2;
                    //mouseStamp.X -= (mouse.X - mouseStamp.Width / 2) % world.GetLayer().GridX;
                    mouseStamp.Y = mouseStamp.Y - mouseStamp.Y % world.GetLayer().GridY + mouseStamp.Height / 2;
                    // mouseStamp.Y -= (mouse.Y - mouseStamp.Height / 2) % world.GetLayer().GridY;
                    if (deleteBottomTile)
                    {
                        Entity a = currentLayer.SelectEntity(new Point((int)mouseStamp.X, (int)mouseStamp.Y));
                        if (a != null)
                            a.Delete();
                    }
                }
                
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
                    mouseS.X -= mouseStamp.Width;//divide each by two to start at top left
                    mouseS.Y += mouseStamp.Height;
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
            else if (mousemode == MouseMode.DrawRect)
            {
                Layer currentLayer = world.GetLayer();
                currentLayer.AddEntity(mouseStamp.Clone());
                mousemode = MouseMode.PreDrawRect;
            }

            if (mousemode != MouseMode.StampEntity && mousemode != MouseMode.PreDrawRect )
            {
                mousemode = MouseMode.None;
                mouseStamp = null;
            }
            UpdateMiniMap();

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
                if (DestinationNode.Tag is Entity)
                {
                    if (SourceNode.Tag is Entity)
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
                if (DestinationNode.Tag is Layer)
                {
                    if (SourceNode.Tag is Entity)
                    {
                        //Move entity to bottom of layer
                        ((Layer)SourceNode.Parent.Tag).DeleteNode(SourceNode);
                        DestinationNode.Nodes.Add(SourceNode);
                        SourceNode.TreeView.SelectedNode = SourceNode;
                        ((Layer)SourceNode.Parent.Tag).SortNodes();
                    }
                    if (SourceNode.Tag is Layer)
                    {
                        //Move SourceNode above DestNode
                    }

                }
            }

            glWorld.Draw();
            UpdateMiniMap();

        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            gridAlign = !gridAlign;

        }

        private void bShowGrid_Click(object sender, EventArgs e)
        {
            showGrid = !showGrid;
        }

        private void glWorld_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    if (e.Control == true)
                    {
                        selectedEntities = world.GetLayer().SelectAll();
                    }
                    break;
                default:
                    break;
            }

            glWorld.Draw();

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            bool handled = false;

            switch (keyData)
            {
                case Keys.Delete:
                    foreach (Entity entity in selectedEntities)
                    {
                        entity.Delete();
                    }
                    selectedEntities.Clear();
                    break;

                case Keys.H:
                    foreach (Entity entity in selectedEntities)
                    {
                        entity.FlipHorizontal = !entity.FlipHorizontal;
                    }
                    if (mouseStamp != null)
                        mouseStamp.FlipHorizontal = !mouseStamp.FlipHorizontal;
                    break;
                case Keys.V:
                    foreach (Entity entity in selectedEntities)
                    {
                        entity.FlipVertical = !entity.FlipVertical;
                    }
                    if (mouseStamp != null)
                        mouseStamp.FlipVertical = !mouseStamp.FlipVertical;
                    break;
                case Keys.F:
                    foreach (Entity entity in selectedEntities)
                    {
                        entity.Rotation -= 90;
                    }
                    break;
                case Keys.G:
                    foreach (Entity entity in selectedEntities)
                    {
                        entity.Rotation += 90;
                    }
                    break;
                case Keys.Up:
                    foreach (Entity entity in selectedEntities)
                    {
                        entity.Y = entity.Y + 1;
                    }
                    handled = true;
                    break;
                case Keys.Down:
                    foreach (Entity entity in selectedEntities)
                    {
                        entity.Y -= 1;
                    }
                    handled = true;
                    break;
                case Keys.Right:
                    foreach (Entity entity in selectedEntities)
                    {
                        entity.X += 1;
                    }
                    handled = true;
                    break;
                case Keys.Left:
                    foreach (Entity entity in selectedEntities)
                    {
                        entity.X -= 1;
                    }
                    handled = true;
                    break;
                default:
                    break;
            }

            glWorld.Draw();
            return handled;

        }

        TreeNode shapes = new TreeNode("Shapes");
            TreeNode regPoly = new TreeNode("Regular Polygon");
            TreeNode rectangle = new TreeNode("Rectangle");
        TreeNode animations = new TreeNode("Animations");
        TreeNode entities = new TreeNode("Entities");

        private void WorldBuilder_Load(object sender, EventArgs e)
        {
            
            tvObjects.Nodes.Add(shapes); 
                shapes.Nodes.Add(regPoly);
                    regPoly.Tag = new RegularPoly();
                shapes.Nodes.Add(rectangle);
                    RectShape rec = new RectShape();
                    rectangle.Tag = rec;
                
            tvObjects.Nodes.Add(animations); 
            tvObjects.Nodes.Add(entities);
        }

        private void tvObjects_DoubleClick(object sender, EventArgs e)
        {
            TreeNode selected = ((TreeView)sender).SelectedNode;

            //if (selected == regPoly)
            //{
            //    RegularPoly texture = new RegularPoly();
            //    mousemode = MouseMode.StampEntity;
            //    mouseStamp = texture;
            //}

            if (selected == rectangle)
            {
                mouseStamp = (Entity)selected.Tag;
                mousemode = MouseMode.PreDrawRect;
                selectedEntities.Clear();
                return;
            }

            if (selected.Tag != null && selected.Tag is Entity)
            {
                mousemode = MouseMode.StampEntity;
                mouseStamp = (Entity)selected.Tag;
                selectedEntities.Clear();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.ShowDialog();
         
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bMoveNodeUp_Click(object sender, EventArgs e)
        {
            TreeNode selected = WorldTree.SelectedNode;
            if (selected == null)
                return;
            if (selected.Tag is Layer)
            {
                int index = selected.Parent.Nodes.IndexOf(selected);
                TreeNode parent = selected.Parent;
                selected.Parent.Nodes.Remove(selected);
                parent.Nodes.Insert(index - 1, selected);
                selected.TreeView.SelectedNode = selected;
                ((Level)parent.Tag).SortNodes();
                //((Level)selected.Parent.Tag).S
            }
            if (selected.Tag is Entity)
            {
                int index = selected.Parent.Nodes.IndexOf(selected);
                TreeNode parent = selected.Parent;
                selected.Parent.Nodes.Remove(selected);
                parent.Nodes.Insert(index - 1, selected);
                selected.TreeView.SelectedNode = selected;
                ((Layer)parent.Tag).SortNodes();
                //((Level)selected.Parent.Tag).S
            } 
        }

        private void bMoveNodeDown_Click(object sender, EventArgs e)
        {
            TreeNode selected = WorldTree.SelectedNode;
            if (selected == null)
                return;
            if (selected.Tag is Layer)
            {
                int index = selected.Parent.Nodes.IndexOf(selected);
                TreeNode parent = selected.Parent;
                selected.Parent.Nodes.Remove(selected);
                parent.Nodes.Insert(index + 1, selected);
                selected.TreeView.SelectedNode = selected;
                ((Level)parent.Tag).SortNodes();
                //((Level)selected.Parent.Tag).S
            }
             if (selected.Tag is Entity)
            {
                int index = selected.Parent.Nodes.IndexOf(selected);
                TreeNode parent = selected.Parent;
                selected.Parent.Nodes.Remove(selected);
                parent.Nodes.Insert(index + 1, selected);
                selected.TreeView.SelectedNode = selected;
                ((Layer)parent.Tag).SortNodes();
                //((Level)selected.Parent.Tag).S
           } 

        }

        private void bDeleteUnderlap_Click(object sender, EventArgs e)
        {
            deleteBottomTile = !deleteBottomTile;
        }

        private void pbMinimap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TranslateToMiniMap(e.Location);
            }
        }
        private void pbMinimap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TranslateToMiniMap(e.Location);
            }
        }

        void TranslateToMiniMap(Point p)
        {
            if (world == null || world.GetLevel() == null) return;
            p.Y = pbMinimap.Height - p.Y;
            screenTranslation.X = (int)(-(float)p.X / (float)pbMinimap.Width * (float)world.GetLevel().Width * screenZoom + (glWorld.Width / 2));
            screenTranslation.Y = (int)(-(float)p.Y / (float)pbMinimap.Height * (float)world.GetLevel().Height * screenZoom + (glWorld.Height / 2));

            lMouse.Text = "World (" + ((int)(screenTranslation.X / screenZoom)).ToString() + ", " + ((int)(screenTranslation.Y / screenZoom)).ToString() + ")";

            UpdateMiniMap();
            glWorld.Draw();
        }

        void UpdateMiniMap()
        {
            int width = glWorld.Width;
            int height = glWorld.Height;

            int wWidth = world.GetLevel().Width;
            int wHeight = world.GetLevel().Height;

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(0, wWidth, 0, wHeight, 0, 1);
            //Gl.glOrtho(-wWidth / 2, wWidth / 2, -wHeight / 2, wHeight / 2, 0, 1);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            //Gl.glTranslated((double)(screenTranslation.X), (double)(screenTranslation.Y), 0);
            //Gl.glScaled(screenZoom, screenZoom, 0);

            Gl.glViewport(0, 0, pbMinimap.Width, pbMinimap.Height);

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            try
            {
                Layer l = world.GetLayer();
                world.GetLevel().Draw();
                Gl.glColor3f(1.0f, 1.0f, 1.0f);
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
                Gl.glBegin(Gl.GL_LINE_LOOP);
                    Gl.glVertex2d(-screenTranslation.X / screenZoom, -screenTranslation.Y / screenZoom);
                    Gl.glVertex2d(-screenTranslation.X / screenZoom + glWorld.Width / screenZoom, -screenTranslation.Y / screenZoom);
                    Gl.glVertex2d(-screenTranslation.X / screenZoom + glWorld.Width / screenZoom, -screenTranslation.Y / screenZoom + glWorld.Height / screenZoom);
                    Gl.glVertex2d(-screenTranslation.X / screenZoom, -screenTranslation.Y / screenZoom + glWorld.Height / screenZoom);
                Gl.glEnd();
            }
            catch (Exception)
            { }



            Gl.glColor3f(1.0f, 1.0f, 1.0f);
            Gl.glFlush();

            Bitmap b = new Bitmap(pbMinimap.Width, pbMinimap.Height, PixelFormat.Format32bppArgb);
            BitmapData bd = b.LockBits(new System.Drawing.Rectangle(0, 0, pbMinimap.Width, pbMinimap.Height),
            ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Gl.glReadPixels(0, 0, pbMinimap.Width, pbMinimap.Height, Gl.GL_BGRA_EXT, Gl.GL_UNSIGNED_BYTE, bd.Scan0);

            b.UnlockBits(bd);
            b.RotateFlip(RotateFlipType.RotateNoneFlipY);

            pbMinimap.Image = b;
        }

        private void bNewWorld_Click(object sender, EventArgs e)
        {

        }

        private void bOpenWorld_Click(object sender, EventArgs e)
        {

        }

        private void bSave_Click(object sender, EventArgs e)
        {

        }

        private void bResetZoom_Click(object sender, EventArgs e)
        {

            screenZoom = 1;
            glWorld.Draw();
        }


    }
}
