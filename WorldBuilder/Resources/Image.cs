using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.DevIl;
using Tao.OpenGl;

namespace WorldBuilder
{
    public class Image
    {
        int height;
        int width;
        int textureID;
        string filename;

        public Image(string file_name)
        {
            filename = file_name;
            // Il.ilDeleteImage(images[0]);

            try
            {
                textureID = Ilut.ilutGLLoadImage(filename);

                //Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureID);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST);

                width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show( e.ToString());
            }
        }

        ~Image()
        {
            //Ilu.iluDeleteImage(textureID);
            Il.ilDeleteImage(textureID);
        }

        public string FileName
        {
            get { return filename; }
        }

        public int TextureID
        {
            get { return textureID; }
        }

        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }
    }
}
