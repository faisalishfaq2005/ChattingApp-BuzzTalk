using SecSemesterProjOOP.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPProject.UI.Chat
{
    public partial class ChannelPostsPage : Form
    {
        Channels Channel;
        List<string> ImagePaths;
        Panel ParentPanel;
        User SignedInUser;
        public ChannelPostsPage(Channels channel,List<string> imagePaths,User signedInUser,Panel parentpanel)
        {
            InitializeComponent();
            Channel = channel;
            ImagePaths = imagePaths;
            SignedInUser = signedInUser;
            ParentPanel = parentpanel;
            DisplayImages(imagePaths,panel11);
        }

        private void ChannelPostsPage_Load(object sender, EventArgs e)
        {

        }

        private Image LoadImageFromPath(string path)
        {
            try
            {
                
                return Image.FromFile(path);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Error loading image from path '{path}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null; 
            }
        }

        private void DisplayImages(List<string> images,Panel panel)
        {
            const int pictureBoxSize = 100; // Size of each picture box
            const int padding = 10; // Padding between picture boxes

            int x = padding; // Initial X position
            int y = padding; // Initial Y position

            foreach (string path in images)
            {
                Image image = LoadImageFromPath(path); // Step 2
                PictureBox pictureBox = new PictureBox
                {
                    Image = image,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(pictureBoxSize, pictureBoxSize),
                    Margin = new Padding(padding), // Add margin to create spacing between picture boxes
                    Location = new Point(x, y) // Set the location of the picture box
                };

                // Add picture box to the panel
                panel.Controls.Add(pictureBox);

                // Update X position for the next picture box
                x += pictureBoxSize + padding;

                // Check if the next picture box will fit horizontally
                if (x + pictureBoxSize + padding > panel1.Width)
                {
                    // Reset X position and move to the next row
                    x = padding;
                    y += pictureBoxSize + padding;
                }
            }
            panel.AutoScroll = true;
        }
    }
}
