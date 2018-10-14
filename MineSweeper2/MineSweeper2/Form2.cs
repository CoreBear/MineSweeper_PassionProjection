using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper2
{
    public partial class Form2 : Form
    {
        int[] beginner;
        int[] intermediate;
        int[] expert;
        int[] custom;

        public Form2()
        {
            InitializeComponent();
            beginner = new int[3] { 9, 9, 10 };
            intermediate = new int[3] { 16, 16, 40};
            expert = new int[3] { 16, 30, 99 };
            custom = new int[3];
        }
        
        public int GetDifficultyLevel()
        {
            if (radioButtonBeginner.Checked)
                return 0;
            else if (radioButtonIntermediate.Checked)
                return 1;
            else if (radioButtonExpert.Checked)
                return 2;
            else
                return 3;
        }

        public int[] GetBeginnerDimensions() { return beginner; }
        public int[] GetIntermediateDimensions() { return intermediate; }
        public int[] GetExpertDimensions() { return expert; }
        public int[] GetCustomDimensions()
        {
            custom[0] = int.Parse(textBoxCH.Text);
            custom[1] = int.Parse(textBoxCW.Text);
            custom[2] = int.Parse(textBoxCM.Text);
            return custom;
        }

        public void SetCustomDifficulty(int height, int width, int mines)
        {
            textBoxCH.Text = height.ToString();
            textBoxCW.Text = width.ToString();
            textBoxCM.Text = mines.ToString();
        }
        
    }
}
