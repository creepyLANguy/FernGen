using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarnsleyFern
{
    public partial class AdvancedForm : Form
    {
        double sum = 0;

        public AdvancedForm()
        {
            InitializeComponent();

            InitialSetUp();
        }

        void InitialSetUp()
        {
            TextBox[,] textboxes =
            {
            {f1a,f1b,f1c,f1d,f1e,f1f,f1p},
            {f2a,f2b,f2c,f2d,f2e,f2f,f2p},
            {f3a,f3b,f3c,f3d,f3e,f3f,f3p},
            {f4a,f4b,f4c,f4d,f4e,f4f,f4p}
            };

            for (int row = 0; row < 4; ++row)
            {
                for (int col = 0; col < 7; ++col)
                {
                    textboxes[row, col].Text = Convert.ToString(Form1.coeffs[row, col]);
                }
            }

            CalcPSum();
        }
        
        private void ResetButton_Click(object sender, EventArgs e)
        {
            SetDefaults();
        }

        void SetDefaults()
        {
            TextBox[,] textboxes =
            {
            {f1a,f1b,f1c,f1d,f1e,f1f,f1p},
            {f2a,f2b,f2c,f2d,f2e,f2f,f2p},
            {f3a,f3b,f3c,f3d,f3e,f3f,f3p},
            {f4a,f4b,f4c,f4d,f4e,f4f,f4p}
            };

            for (int row = 0; row < 4; ++row)
            {
                for (int col = 0; col < 7; ++col)
                {
                    textboxes[row, col].Text = Convert.ToString(BarnsleyCommon.defaultCoeffs[row, col]);
                }
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            TextBox[,] textboxes =
            {
            {f1a,f1b,f1c,f1d,f1e,f1f,f1p},
            {f2a,f2b,f2c,f2d,f2e,f2f,f2p},
            {f3a,f3b,f3c,f3d,f3e,f3f,f3p},
            {f4a,f4b,f4c,f4d,f4e,f4f,f4p}
            };

            for (int row = 0; row < 4; ++row)
            {
                for (int col = 0; col < 7; ++col)
                {
                    try
                    {
                        Form1.coeffs[row, col] = Convert.ToDouble(textboxes[row, col].Text);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            this.Close();
        }

        void HandleProbabilityChanges()
        {
            OKButton.Enabled = false;
            
            try
            {
                CalcPSum();

                if (sum == 1.0)
                {
                    OKButton.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        void CalcPSum()
        {
            sum = 0;
            sum += Convert.ToDouble(f1p.Text);
            sum += Convert.ToDouble(f2p.Text);
            sum += Convert.ToDouble(f3p.Text);
            sum += Convert.ToDouble(f4p.Text);

            GuideLabel.Text = "" + sum;
        }

        private void f1p_TextChanged(object sender, EventArgs e)
        {
            HandleProbabilityChanges();
        }

        private void f2p_TextChanged(object sender, EventArgs e)
        {
            HandleProbabilityChanges();
        }

        private void f3p_TextChanged(object sender, EventArgs e)
        {
            HandleProbabilityChanges();
        }

        private void f4p_TextChanged(object sender, EventArgs e)
        {
            HandleProbabilityChanges();
        }

        private void GuideLabel_Click(object sender, EventArgs e)
        {
            f1p.Text = Convert.ToString(BarnsleyCommon.defaultCoeffs[0, 6]);
            f2p.Text = Convert.ToString(BarnsleyCommon.defaultCoeffs[1, 6]);
            f3p.Text = Convert.ToString(BarnsleyCommon.defaultCoeffs[2, 6]);
            f4p.Text = Convert.ToString(BarnsleyCommon.defaultCoeffs[3, 6]);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
