using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T_Cubed
{
    public partial class Form2 : Form
    {
        public Form2(string selectedFile)
        {
            InitializeComponent();

            if(selectedFile == "File 1")
            {
                textLabel.Text = "Engineers, as practitioners of engineering, are people who invent, design, analyze, build, and test machines, systems, structures and materials to fulfill objectives and requirements while considering the limitations imposed by practicality, regulation, safety, and cost. The work of engineers forms the link between scientific discoveries and their subsequent applications to human and business needs and quality of life.";
            } 
            else if (selectedFile == "File 2")
            {
                textLabel.Text = "There are many idiosyncratic typing styles in between novice-style \"hunt and peck\" and touch typing. For example, many \"hunt and peck\" typists have the keyboard layout memorized and are able to type while focusing their gaze on the screen. Some use just two fingers, while others use 3-6 fingers. Some use their fingers very consistently, with the same finger being used to type the same character every time, while others vary the way they use their fingers.";
            }
            else if (selectedFile == "File 3")
            {
                textLabel.Text = "A late 20th century trend in typing, primarily used with devices with small keyboards (such as PDAs and Smartphones), is thumbing or thumb typing. This can be accomplished using one or both thumbs. Similar to desktop keyboards and input devices, if a user overuses keys which need hard presses and/or have small and unergonomic layouts, it could cause thumb tendonitis or other repetitive strain injury. (Wikipedia)";
            }
            else
            {
                textLabel.Text = "A freelancer or freelance worker, is a term commonly used for a person who is self-employed and is not necessarily committed to a particular employer long-term. Freelance workers are sometimes represented by a company or a temporary agency that resells freelance labor to clients; others work independently or use professional associations or websites to get work. While the term \"independent contractor\" would be used in a higher register of English to designate the tax and employment classes of this type of worker, the term freelancing is most common in culture and creative industries and this term specifically motions to participation therein. Fields, professions, and industries where freelancing is predominant include: music, writing, acting, computer programming, web design, graphic design, translating and illustrating, film and video production and other forms of piece work which some cultural theorists consider as central to the cognitive-cultural economy.";
            }
        }
    }
}
