namespace WorldBuilder
{
    partial class WorldBuilder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorldBuilder));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.addTexturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bNewWorld = new System.Windows.Forms.ToolStripButton();
            this.bOpenWorld = new System.Windows.Forms.ToolStripButton();
            this.bSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bOpenTextures = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bShowGrid = new System.Windows.Forms.ToolStripButton();
            this.bGridAlign = new System.Windows.Forms.ToolStripButton();
            this.bDeleteUnderlap = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bZoomIn = new System.Windows.Forms.ToolStripButton();
            this.bResetZoom = new System.Windows.Forms.ToolStripButton();
            this.bZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bStartGame = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.WorldTree = new System.Windows.Forms.TreeView();
            this.imageIcons = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.bAddNode = new System.Windows.Forms.ToolStripButton();
            this.bMoveNodeUp = new System.Windows.Forms.ToolStripButton();
            this.bMoveNodeDown = new System.Windows.Forms.ToolStripButton();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.lMouseScreen = new System.Windows.Forms.Label();
            this.lMouse = new System.Windows.Forms.Label();
            this.lLayer = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listTextures = new System.Windows.Forms.ListView();
            this.textureList = new System.Windows.Forms.ImageList(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tvObjects = new System.Windows.Forms.TreeView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.contextMenuWorld = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openTextures = new System.Windows.Forms.OpenFileDialog();
            this.glWorld = new Tao.Platform.Windows.SuperOpenGlControl();
            this.glMiniMap = new Tao.Platform.Windows.SuperOpenGlControl();
            this.saveWorldDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWorldToolStripMenuItem,
            this.openWorldToolStripMenuItem,
            this.saveWorldToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator5,
            this.addTexturesToolStripMenuItem,
            this.toolStripSeparator6,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newWorldToolStripMenuItem
            // 
            this.newWorldToolStripMenuItem.Name = "newWorldToolStripMenuItem";
            this.newWorldToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newWorldToolStripMenuItem.Text = "New";
            this.newWorldToolStripMenuItem.Click += new System.EventHandler(this.newWorldToolStripMenuItem_Click);
            // 
            // openWorldToolStripMenuItem
            // 
            this.openWorldToolStripMenuItem.Name = "openWorldToolStripMenuItem";
            this.openWorldToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openWorldToolStripMenuItem.Text = "Open";
            this.openWorldToolStripMenuItem.Click += new System.EventHandler(this.openWorldToolStripMenuItem_Click);
            // 
            // saveWorldToolStripMenuItem
            // 
            this.saveWorldToolStripMenuItem.Name = "saveWorldToolStripMenuItem";
            this.saveWorldToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveWorldToolStripMenuItem.Text = "Save";
            this.saveWorldToolStripMenuItem.Click += new System.EventHandler(this.saveWorldToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
            // 
            // addTexturesToolStripMenuItem
            // 
            this.addTexturesToolStripMenuItem.Name = "addTexturesToolStripMenuItem";
            this.addTexturesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addTexturesToolStripMenuItem.Text = "Open Textures";
            this.addTexturesToolStripMenuItem.Click += new System.EventHandler(this.addTexturesToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(52, 20);
            this.toolStripMenuItem1.Text = "About";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bNewWorld,
            this.bOpenWorld,
            this.bSave,
            this.toolStripSeparator1,
            this.bOpenTextures,
            this.toolStripSeparator3,
            this.bShowGrid,
            this.bGridAlign,
            this.bDeleteUnderlap,
            this.toolStripSeparator2,
            this.bZoomIn,
            this.bResetZoom,
            this.bZoomOut,
            this.toolStripSeparator4,
            this.bStartGame});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bNewWorld
            // 
            this.bNewWorld.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bNewWorld.Image = ((System.Drawing.Image)(resources.GetObject("bNewWorld.Image")));
            this.bNewWorld.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bNewWorld.Name = "bNewWorld";
            this.bNewWorld.Size = new System.Drawing.Size(23, 22);
            this.bNewWorld.Text = "New World";
            this.bNewWorld.Click += new System.EventHandler(this.bNewWorld_Click);
            // 
            // bOpenWorld
            // 
            this.bOpenWorld.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bOpenWorld.Image = ((System.Drawing.Image)(resources.GetObject("bOpenWorld.Image")));
            this.bOpenWorld.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bOpenWorld.Name = "bOpenWorld";
            this.bOpenWorld.Size = new System.Drawing.Size(23, 22);
            this.bOpenWorld.Text = "Open";
            this.bOpenWorld.ToolTipText = "Open";
            this.bOpenWorld.Click += new System.EventHandler(this.bOpenWorld_Click);
            // 
            // bSave
            // 
            this.bSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bSave.Image = ((System.Drawing.Image)(resources.GetObject("bSave.Image")));
            this.bSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(23, 22);
            this.bSave.Text = "Save";
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bOpenTextures
            // 
            this.bOpenTextures.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bOpenTextures.Image = ((System.Drawing.Image)(resources.GetObject("bOpenTextures.Image")));
            this.bOpenTextures.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bOpenTextures.Name = "bOpenTextures";
            this.bOpenTextures.Size = new System.Drawing.Size(23, 22);
            this.bOpenTextures.Text = "Open Textures";
            this.bOpenTextures.Click += new System.EventHandler(this.bOpenTextures_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bShowGrid
            // 
            this.bShowGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bShowGrid.Image = ((System.Drawing.Image)(resources.GetObject("bShowGrid.Image")));
            this.bShowGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bShowGrid.Name = "bShowGrid";
            this.bShowGrid.Size = new System.Drawing.Size(23, 22);
            this.bShowGrid.Text = "Show Grid";
            this.bShowGrid.Click += new System.EventHandler(this.bShowGrid_Click);
            // 
            // bGridAlign
            // 
            this.bGridAlign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bGridAlign.Image = ((System.Drawing.Image)(resources.GetObject("bGridAlign.Image")));
            this.bGridAlign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bGridAlign.Name = "bGridAlign";
            this.bGridAlign.Size = new System.Drawing.Size(23, 22);
            this.bGridAlign.Text = "Snap To Grid (Bottom Left)";
            this.bGridAlign.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // bDeleteUnderlap
            // 
            this.bDeleteUnderlap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bDeleteUnderlap.Image = ((System.Drawing.Image)(resources.GetObject("bDeleteUnderlap.Image")));
            this.bDeleteUnderlap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bDeleteUnderlap.Name = "bDeleteUnderlap";
            this.bDeleteUnderlap.Size = new System.Drawing.Size(23, 22);
            this.bDeleteUnderlap.Text = "Toggle Delete Underlap";
            this.bDeleteUnderlap.Click += new System.EventHandler(this.bDeleteUnderlap_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bZoomIn
            // 
            this.bZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("bZoomIn.Image")));
            this.bZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bZoomIn.Name = "bZoomIn";
            this.bZoomIn.Size = new System.Drawing.Size(23, 22);
            this.bZoomIn.Text = "Zoom In";
            // 
            // bResetZoom
            // 
            this.bResetZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bResetZoom.Image = ((System.Drawing.Image)(resources.GetObject("bResetZoom.Image")));
            this.bResetZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bResetZoom.Name = "bResetZoom";
            this.bResetZoom.Size = new System.Drawing.Size(23, 22);
            this.bResetZoom.Text = "Reset Zoom";
            this.bResetZoom.Click += new System.EventHandler(this.bResetZoom_Click);
            // 
            // bZoomOut
            // 
            this.bZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("bZoomOut.Image")));
            this.bZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bZoomOut.Name = "bZoomOut";
            this.bZoomOut.Size = new System.Drawing.Size(23, 22);
            this.bZoomOut.Text = "Zoom Out";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bStartGame
            // 
            this.bStartGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bStartGame.Image = ((System.Drawing.Image)(resources.GetObject("bStartGame.Image")));
            this.bStartGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bStartGame.Name = "bStartGame";
            this.bStartGame.Size = new System.Drawing.Size(23, 22);
            this.bStartGame.Text = "Execute Game";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 681);
            this.splitContainer1.SplitterDistance = 212;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.WorldTree);
            this.splitContainer3.Panel1.Controls.Add(this.toolStrip2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.propertyGrid);
            this.splitContainer3.Size = new System.Drawing.Size(212, 681);
            this.splitContainer3.SplitterDistance = 448;
            this.splitContainer3.TabIndex = 0;
            // 
            // WorldTree
            // 
            this.WorldTree.AllowDrop = true;
            this.WorldTree.CheckBoxes = true;
            this.WorldTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorldTree.HideSelection = false;
            this.WorldTree.ImageIndex = 0;
            this.WorldTree.ImageList = this.imageIcons;
            this.WorldTree.Location = new System.Drawing.Point(0, 25);
            this.WorldTree.Name = "WorldTree";
            this.WorldTree.SelectedImageIndex = 0;
            this.WorldTree.Size = new System.Drawing.Size(212, 423);
            this.WorldTree.TabIndex = 1;
            this.WorldTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.WorldTree_DragDrop);
            this.WorldTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.WorldTree_AfterSelect);
            this.WorldTree.DragEnter += new System.Windows.Forms.DragEventHandler(this.WorldTree_DragEnter);
            this.WorldTree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.WorldTree_ItemDrag);
            // 
            // imageIcons
            // 
            this.imageIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageIcons.ImageStream")));
            this.imageIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageIcons.Images.SetKeyName(0, "application_key.png");
            this.imageIcons.Images.SetKeyName(1, "book.png");
            this.imageIcons.Images.SetKeyName(2, "box.png");
            this.imageIcons.Images.SetKeyName(3, "bug.png");
            this.imageIcons.Images.SetKeyName(4, "camera.png");
            this.imageIcons.Images.SetKeyName(5, "car.png");
            this.imageIcons.Images.SetKeyName(6, "chart_bar.png");
            this.imageIcons.Images.SetKeyName(7, "chart_curve.png");
            this.imageIcons.Images.SetKeyName(8, "chart_pie.png");
            this.imageIcons.Images.SetKeyName(9, "clock.png");
            this.imageIcons.Images.SetKeyName(10, "color_wheel.png");
            this.imageIcons.Images.SetKeyName(11, "comment.png");
            this.imageIcons.Images.SetKeyName(12, "computer.png");
            this.imageIcons.Images.SetKeyName(13, "contrast.png");
            this.imageIcons.Images.SetKeyName(14, "controller.png");
            this.imageIcons.Images.SetKeyName(15, "door.png");
            this.imageIcons.Images.SetKeyName(16, "eye.png");
            this.imageIcons.Images.SetKeyName(17, "film.png");
            this.imageIcons.Images.SetKeyName(18, "font.png");
            this.imageIcons.Images.SetKeyName(19, "group.png");
            this.imageIcons.Images.SetKeyName(20, "heart.png");
            this.imageIcons.Images.SetKeyName(21, "hourglass.png");
            this.imageIcons.Images.SetKeyName(22, "image.png");
            this.imageIcons.Images.SetKeyName(23, "information.png");
            this.imageIcons.Images.SetKeyName(24, "layers.png");
            this.imageIcons.Images.SetKeyName(25, "lightbulb.png");
            this.imageIcons.Images.SetKeyName(26, "map.png");
            this.imageIcons.Images.SetKeyName(27, "music.png");
            this.imageIcons.Images.SetKeyName(28, "palette.png");
            this.imageIcons.Images.SetKeyName(29, "photo.png");
            this.imageIcons.Images.SetKeyName(30, "picture.png");
            this.imageIcons.Images.SetKeyName(31, "rainbow.png");
            this.imageIcons.Images.SetKeyName(32, "script.png");
            this.imageIcons.Images.SetKeyName(33, "script_code.png");
            this.imageIcons.Images.SetKeyName(34, "script_edit.png");
            this.imageIcons.Images.SetKeyName(35, "shape_square.png");
            this.imageIcons.Images.SetKeyName(36, "sport_8ball.png");
            this.imageIcons.Images.SetKeyName(37, "sport_basketball.png");
            this.imageIcons.Images.SetKeyName(38, "star.png");
            this.imageIcons.Images.SetKeyName(39, "time.png");
            this.imageIcons.Images.SetKeyName(40, "user.png");
            this.imageIcons.Images.SetKeyName(41, "user_female.png");
            this.imageIcons.Images.SetKeyName(42, "user_green.png");
            this.imageIcons.Images.SetKeyName(43, "user_suit.png");
            this.imageIcons.Images.SetKeyName(44, "world.png");
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bAddNode,
            this.bMoveNodeUp,
            this.bMoveNodeDown});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(212, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // bAddNode
            // 
            this.bAddNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bAddNode.Image = ((System.Drawing.Image)(resources.GetObject("bAddNode.Image")));
            this.bAddNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bAddNode.Name = "bAddNode";
            this.bAddNode.Size = new System.Drawing.Size(23, 22);
            this.bAddNode.Text = "Add";
            // 
            // bMoveNodeUp
            // 
            this.bMoveNodeUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bMoveNodeUp.Image = ((System.Drawing.Image)(resources.GetObject("bMoveNodeUp.Image")));
            this.bMoveNodeUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bMoveNodeUp.Name = "bMoveNodeUp";
            this.bMoveNodeUp.Size = new System.Drawing.Size(23, 22);
            this.bMoveNodeUp.Text = "Move Up";
            this.bMoveNodeUp.Click += new System.EventHandler(this.bMoveNodeUp_Click);
            // 
            // bMoveNodeDown
            // 
            this.bMoveNodeDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bMoveNodeDown.Image = ((System.Drawing.Image)(resources.GetObject("bMoveNodeDown.Image")));
            this.bMoveNodeDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bMoveNodeDown.Name = "bMoveNodeDown";
            this.bMoveNodeDown.Size = new System.Drawing.Size(23, 22);
            this.bMoveNodeDown.Text = "Move Down";
            this.bMoveNodeDown.Click += new System.EventHandler(this.bMoveNodeDown_Click);
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(212, 229);
            this.propertyGrid.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(792, 681);
            this.splitContainer2.SplitterDistance = 512;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.glWorld);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer4.Panel2.Controls.Add(this.lLayer);
            this.splitContainer4.Size = new System.Drawing.Size(512, 681);
            this.splitContainer4.SplitterDistance = 487;
            this.splitContainer4.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.button1);
            this.splitContainer5.Panel1.Controls.Add(this.lMouseScreen);
            this.splitContainer5.Panel1.Controls.Add(this.lMouse);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.glMiniMap);
            this.splitContainer5.Size = new System.Drawing.Size(512, 190);
            this.splitContainer5.SplitterDistance = 272;
            this.splitContainer5.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(80, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 22);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lMouseScreen
            // 
            this.lMouseScreen.AutoSize = true;
            this.lMouseScreen.Location = new System.Drawing.Point(146, 168);
            this.lMouseScreen.Name = "lMouseScreen";
            this.lMouseScreen.Size = new System.Drawing.Size(0, 13);
            this.lMouseScreen.TabIndex = 10;
            // 
            // lMouse
            // 
            this.lMouse.AutoSize = true;
            this.lMouse.Location = new System.Drawing.Point(3, 168);
            this.lMouse.Name = "lMouse";
            this.lMouse.Size = new System.Drawing.Size(0, 13);
            this.lMouse.TabIndex = 9;
            // 
            // lLayer
            // 
            this.lLayer.AutoSize = true;
            this.lLayer.Location = new System.Drawing.Point(23, 168);
            this.lLayer.Name = "lLayer";
            this.lLayer.Size = new System.Drawing.Size(0, 13);
            this.lLayer.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(276, 681);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listTextures);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(268, 655);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Textures";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listTextures
            // 
            this.listTextures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTextures.Location = new System.Drawing.Point(3, 3);
            this.listTextures.MultiSelect = false;
            this.listTextures.Name = "listTextures";
            this.listTextures.Size = new System.Drawing.Size(262, 649);
            this.listTextures.SmallImageList = this.textureList;
            this.listTextures.TabIndex = 0;
            this.listTextures.UseCompatibleStateImageBehavior = false;
            this.listTextures.View = System.Windows.Forms.View.SmallIcon;
            this.listTextures.DoubleClick += new System.EventHandler(this.listTextures_DoubleClick);
            // 
            // textureList
            // 
            this.textureList.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.textureList.ImageSize = new System.Drawing.Size(64, 64);
            this.textureList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tvObjects);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(268, 655);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Objects";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tvObjects
            // 
            this.tvObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvObjects.Location = new System.Drawing.Point(0, 0);
            this.tvObjects.Name = "tvObjects";
            this.tvObjects.Size = new System.Drawing.Size(268, 655);
            this.tvObjects.TabIndex = 0;
            this.tvObjects.DoubleClick += new System.EventHandler(this.tvObjects_DoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(268, 655);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tilesheet";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // contextMenuWorld
            // 
            this.contextMenuWorld.Name = "contextMenuWorld";
            this.contextMenuWorld.Size = new System.Drawing.Size(61, 4);
            // 
            // openTextures
            // 
            this.openTextures.Filter = "Images|*.png;*.ico;*.jpg;*.jpeg;*.bmp;*.tga;*.gif";
            this.openTextures.Multiselect = true;
            // 
            // glWorld
            // 
            this.glWorld.AccumBits = ((byte)(0));
            this.glWorld.AutoCheckErrors = false;
            this.glWorld.AutoFinish = false;
            this.glWorld.AutoMakeCurrent = true;
            this.glWorld.AutoSwapBuffers = true;
            this.glWorld.BackColor = System.Drawing.Color.Black;
            this.glWorld.ColorBits = ((byte)(32));
            this.glWorld.DepthBits = ((byte)(16));
            this.glWorld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glWorld.Location = new System.Drawing.Point(0, 0);
            this.glWorld.Name = "glWorld";
            this.glWorld.Size = new System.Drawing.Size(512, 487);
            this.glWorld.StencilBits = ((byte)(0));
            this.glWorld.TabIndex = 0;
            this.glWorld.Load += new System.EventHandler(this.glWorld_Load);
            this.glWorld.Paint += new System.Windows.Forms.PaintEventHandler(this.glWorld_Paint);
            this.glWorld.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glWorld_MouseMove);
            this.glWorld.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glWorld_MouseDown);
            this.glWorld.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glWorld_MouseUp);
            this.glWorld.KeyDown += new System.Windows.Forms.KeyEventHandler(this.glWorld_KeyDown);
            // 
            // glMiniMap
            // 
            this.glMiniMap.AccumBits = ((byte)(0));
            this.glMiniMap.AutoCheckErrors = false;
            this.glMiniMap.AutoFinish = false;
            this.glMiniMap.AutoMakeCurrent = true;
            this.glMiniMap.AutoSwapBuffers = true;
            this.glMiniMap.BackColor = System.Drawing.Color.Black;
            this.glMiniMap.ColorBits = ((byte)(32));
            this.glMiniMap.DepthBits = ((byte)(16));
            this.glMiniMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glMiniMap.Location = new System.Drawing.Point(0, 0);
            this.glMiniMap.Name = "glMiniMap";
            this.glMiniMap.Size = new System.Drawing.Size(236, 190);
            this.glMiniMap.StencilBits = ((byte)(0));
            this.glMiniMap.TabIndex = 11;
            this.glMiniMap.Paint += new System.Windows.Forms.PaintEventHandler(this.glMiniMap_Paint);
            this.glMiniMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbMinimap_MouseMove);
            this.glMiniMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbMinimap_MouseDown);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // WorldBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "WorldBuilder";
            this.Text = "World Builder";
            this.Load += new System.EventHandler(this.WorldBuilder_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
   

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton bNewWorld;
        private System.Windows.Forms.TreeView WorldTree;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private Tao.Platform.Windows.SuperOpenGlControl glWorld;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripMenuItem newWorldToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuWorld;
        private System.Windows.Forms.ToolStripMenuItem addTexturesToolStripMenuItem;
        private System.Windows.Forms.ListView listTextures;
        private System.Windows.Forms.ImageList textureList;
        private System.Windows.Forms.OpenFileDialog openTextures;
        private System.Windows.Forms.Label lLayer;
        private System.Windows.Forms.ToolStripButton bSave;
        private System.Windows.Forms.ToolStripButton bMoveNodeUp;
        private System.Windows.Forms.ToolStripButton bStartGame;
        private System.Windows.Forms.ToolStripButton bOpenWorld;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bShowGrid;
        private System.Windows.Forms.ToolStripButton bGridAlign;
        private System.Windows.Forms.ToolStripButton bMoveNodeDown;
        private System.Windows.Forms.ToolStripButton bZoomIn;
        private System.Windows.Forms.TreeView tvObjects;
        private System.Windows.Forms.ToolStripButton bZoomOut;
        private System.Windows.Forms.ToolStripButton bOpenTextures;
        private System.Windows.Forms.ToolStripButton bAddNode;
        private System.Windows.Forms.ImageList imageIcons;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton bResetZoom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton bDeleteUnderlap;
        private System.Windows.Forms.ToolStripMenuItem saveWorldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openWorldToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Label lMouseScreen;
        private System.Windows.Forms.Label lMouse;
        private Tao.Platform.Windows.SuperOpenGlControl glMiniMap;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveWorldDialog;
    }
}

