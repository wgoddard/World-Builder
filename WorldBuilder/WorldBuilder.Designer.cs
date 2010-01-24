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
            this.addTexturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.WorldTree = new System.Windows.Forms.TreeView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.glWorld = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.lMouseScreen = new System.Windows.Forms.Label();
            this.lMouse = new System.Windows.Forms.Label();
            this.lLayer = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listTextures = new System.Windows.Forms.ListView();
            this.textureList = new System.Windows.Forms.ImageList(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.contextMenuWorld = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openTextures = new System.Windows.Forms.OpenFileDialog();
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
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
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
            this.addTexturesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newWorldToolStripMenuItem
            // 
            this.newWorldToolStripMenuItem.Name = "newWorldToolStripMenuItem";
            this.newWorldToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newWorldToolStripMenuItem.Text = "New World";
            this.newWorldToolStripMenuItem.Click += new System.EventHandler(this.newWorldToolStripMenuItem_Click);
            // 
            // addTexturesToolStripMenuItem
            // 
            this.addTexturesToolStripMenuItem.Name = "addTexturesToolStripMenuItem";
            this.addTexturesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.addTexturesToolStripMenuItem.Text = "Add Textures";
            this.addTexturesToolStripMenuItem.Click += new System.EventHandler(this.addTexturesToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
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
            this.WorldTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorldTree.Location = new System.Drawing.Point(0, 25);
            this.WorldTree.Name = "WorldTree";
            this.WorldTree.Size = new System.Drawing.Size(212, 423);
            this.WorldTree.TabIndex = 1;
            this.WorldTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.WorldTree_DragDrop);
            this.WorldTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.WorldTree_AfterSelect);
            this.WorldTree.DragEnter += new System.Windows.Forms.DragEventHandler(this.WorldTree_DragEnter);
            this.WorldTree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.WorldTree_ItemDrag);
            this.WorldTree.Click += new System.EventHandler(this.WorldTree_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(212, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
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
            this.splitContainer4.Panel2.Controls.Add(this.lMouseScreen);
            this.splitContainer4.Panel2.Controls.Add(this.lMouse);
            this.splitContainer4.Panel2.Controls.Add(this.lLayer);
            this.splitContainer4.Panel2.Controls.Add(this.button1);
            this.splitContainer4.Size = new System.Drawing.Size(512, 681);
            this.splitContainer4.SplitterDistance = 487;
            this.splitContainer4.TabIndex = 0;
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
            // 
            // lMouseScreen
            // 
            this.lMouseScreen.AutoSize = true;
            this.lMouseScreen.Location = new System.Drawing.Point(342, 165);
            this.lMouseScreen.Name = "lMouseScreen";
            this.lMouseScreen.Size = new System.Drawing.Size(0, 13);
            this.lMouseScreen.TabIndex = 3;
            // 
            // lMouse
            // 
            this.lMouse.AutoSize = true;
            this.lMouse.Location = new System.Drawing.Point(138, 168);
            this.lMouse.Name = "lMouse";
            this.lMouse.Size = new System.Drawing.Size(0, 13);
            this.lMouse.TabIndex = 2;
            // 
            // lLayer
            // 
            this.lLayer.AutoSize = true;
            this.lLayer.Location = new System.Drawing.Point(23, 168);
            this.lLayer.Name = "lLayer";
            this.lLayer.Size = new System.Drawing.Size(0, 13);
            this.lLayer.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.textureList.ImageSize = new System.Drawing.Size(32, 32);
            this.textureList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(268, 655);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Objects";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            this.openTextures.Multiselect = true;
            // 
            // WorldBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "WorldBuilder";
            this.Text = "World Builder";
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TreeView WorldTree;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private Tao.Platform.Windows.SimpleOpenGlControl glWorld;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lMouse;
        private System.Windows.Forms.Label lLayer;
        private System.Windows.Forms.Label lMouseScreen;
    }
}

