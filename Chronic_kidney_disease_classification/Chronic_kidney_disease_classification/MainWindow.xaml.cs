using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CallRequestResponseService;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Chronic_kidney_disease_classification
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            bool invalidInputFlag = false;
            string age_ = age.Text.ToLower();
            string bp_ = bp.Text.ToLower();
            string sg_, al_, su_, rbc_, pc_, pcc_,ba_,htn_,dm_,cad_,pe_,ane_,appet_ = string.Empty;
            if (sg1.IsChecked== true )
            {
                 sg_ = "1.005";
            }
            else if (sg2.IsChecked == true)
            {
                 sg_ = "1.010";
            }
            else if (sg3.IsChecked == true)
            {
                 sg_ = "1.015";
            }
            else if (sg4.IsChecked == true)
            {
                 sg_ = "1.020";
            }
            else
            {
                sg_ = String.Empty;
                invalidInputFlag= true;
            }

            if(al1.IsChecked== true)
            {
                 al_ = "0";
            }
            else if(al2.IsChecked== true)
            {
                al_ = "1";
            }
            else if (al3.IsChecked == true)
            {
                 al_ = "2";
            }

            else if (al4.IsChecked == true)
            {
                 al_ = "3";
            }

            else if (al5.IsChecked == true)
            {
                 al_ = "4";
            }
            else
            {
                invalidInputFlag= true;
                al_ = string.Empty;
            }

            if (su1.IsChecked == true)
            {
                 su_ = "0";
            }
            else if (su2.IsChecked == true)
            {
                 su_ = "1";
            }
            else if (su3.IsChecked == true)
            {
                 su_ = "2";
            }

            else if (su4.IsChecked == true)
            {
                 su_ = "3";
            }

            else if (su5.IsChecked == true)
            {
                 su_ = "4";
            }
            else
            {
                invalidInputFlag= true;
                su_ = string.Empty;
            }

            if (rbc1.IsChecked == true)
            {
                 rbc_ = "normal";
            }
            else if(rbc2.IsChecked == true)
            {
                rbc_ = "abnormal";
            }
            else
            {
                invalidInputFlag = true;
                rbc_=string.Empty;
            }

            if (pc1.IsChecked == true)
            {
                 pc_ = "normal";
            }
            else if (pc2.IsChecked == true)
            {
                 pc_ = "abnormal";                
            }
            else
            {
                invalidInputFlag = true;
                pc_=string.Empty;
            }

            if (pcc1.IsChecked == true)
            {
                 pcc_ = "present";
            }
            else if (pcc2.IsChecked == true)
            {
                 pcc_ = "notpresent";
            }
            else
            {
                invalidInputFlag = true;
                pcc_=string.Empty;
            }

            if (ba1.IsChecked == true)
            {
                 ba_ = "present";
            }
            else if (ba2.IsChecked == true)
            {
                 ba_ = "notpresent";
            }
            else
            {
                invalidInputFlag = true;
                ba_= string.Empty;
            }

            if (htn1.IsChecked == true)
            {
                 htn_ = "yes";
            }
            else if (htn2.IsChecked == true)
            {
                 htn_ = "no";
            }
            else
            {
                invalidInputFlag = true;
                htn_= string.Empty; 
            }

            if (dm1.IsChecked == true)
            {
                 dm_ = "yes";
            }
            else if (dm2.IsChecked == true)
            {
                 dm_ = "no";
            }
            else
            {
                invalidInputFlag = true;
                dm_= string.Empty;
            }
            if (cad1.IsChecked == true)
            {
                 cad_ = "yes";
            }
            else if (cad2.IsChecked == true)
            {
                 cad_ = "no";
            }
            else
            {
                invalidInputFlag = true;
                cad_= string.Empty;
            }
            if (pe1.IsChecked == true)
            {
                 pe_ = "yes";
            }
            else if (pe2.IsChecked == true)
            {
                 pe_ = "no";
            }
            else
            {
                invalidInputFlag = true;
                pe_= string.Empty;
            }
            if (ane1.IsChecked == true)
            {
                 ane_ = "yes";
            }
            else if (ane2.IsChecked == true)
            {
                 ane_ = "no";
            }
            else
            {
                invalidInputFlag = true;
                ane_= string.Empty;
            }
            if (appet1.IsChecked == true)
            {
                 appet_ = "good";
            }
            else if (appet2.IsChecked == true)
            {
                 appet_ = "poor";
            }
            else
            {
                invalidInputFlag = true;
                appet_= string.Empty;
            }

            string bgr_ = bgr.Text.ToLower();
            string bu_ = bu.Text.ToLower();
            string sc_ = sc.Text.ToLower();
            string sod_ = sod.Text.ToLower();
            string pot_ = pot.Text.ToLower();
            string hemo_ = hemo.Text.ToLower();
            string pcv_ = pcv.Text.ToLower();
            string wbcc_ = wbcc.Text.ToLower();
            string rbcc_ = rbcc.Text.ToLower();
            
            string[] textBoxValues = {bgr_,bu_,sc_,sod_, pot_, hemo_, pcv_, wbcc_, rbcc_, sg_, al_, su_, rbc_, pc_, pcc_, ba_, htn_, dm_, cad_, pe_, ane_, appet_, age_, bp_};
            if (textBoxValues.Contains(string.Empty))
            {
                invalidInputFlag= true;
            }

            if (invalidInputFlag != true)
            {

                var results = await Program.InvokeRequestResponseService(age_, bp_, sg_, al_, su_, rbc_, pc_, pcc_, ba_, bgr_, bu_, sc_, sod_, pot_, hemo_, pcv_, wbcc_, rbcc_, htn_, dm_, cad_, appet_, pe_, ane_);

                JObject data = JObject.Parse(results);
                string scored_labels = (string)data["Results"]["output1"]["value"]["Values"][0][25];
                string isDisease = "not ";
                if (scored_labels == "ckd")
                {
                    isDisease = string.Empty;
                }
                MessageBox.Show($"The model predicts it is {isDisease}chronic kidney disease");
            }
            else
            {
                MessageBox.Show("Please enter all the required information.");
            }
        }
    }
}
