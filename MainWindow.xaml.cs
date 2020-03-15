using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace CertificateCheck
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //X509Certificate cert = new X509Certificate();
            // string[] files = Directory.GetFiles(@"C:\\Certificates", "*.*", SearchOption.AllDirectories);
            OleDbConnection connDS = new OleDbConnection();
            OleDbConnection connCSCA = new OleDbConnection();
            OleDbDataReader reader;
            connDS.ConnectionString = "Provider=OraOLEDB.Oracle;Data Source=10.3.20.63;User Id=ds;Password=dspwd;OLEDB.NET = True; ";
            connCSCA.ConnectionString = "Provider=OraOLEDB.Oracle;Data Source=10.3.20.39;User Id=idca;Password=IDCA;OLEDB.NET = True; ";
            string sqlDS = "SELECT NOTAFTER FROM AUTHORITIES";
            string sqlCSCA = "SELECT NOT_AFTER FROM X509_CERTIFICATES";
            DateTime dt_expiry = new DateTime();
            DateTime dt_now = DateTime.Today;
            TimeSpan dt_result = new TimeSpan();

            OleDbCommand cmdDS = new OleDbCommand(sqlDS, connDS);
            OleDbCommand cmdCSCA = new OleDbCommand(sqlCSCA, connCSCA);
            //var result = cmd.ExecuteReader();
            //foreach (string mycer in files)
            //string filepath = "C:\\Certificates";
            try
            {
                connDS.Open();                
                reader = cmdDS.ExecuteReader();
                while (reader.Read())
                {
                    string res = reader[0].ToString();
                    dt_expiry = Convert.ToDateTime(res);
                    dt_result = dt_expiry.Subtract(dt_now);

                    if (dt_result.Days <= 10)
                    {
                        //IEmailService 
                    }
                }
                reader.Close();
                cmdDS.Dispose();
                connDS.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                connCSCA.Open();
                reader = cmdCSCA.ExecuteReader();
                while (reader.Read())
                {
                    string res = reader[0].ToString();
                    dt_expiry = Convert.ToDateTime(res);
                    dt_result = dt_expiry.Subtract(dt_now);

                    if (dt_result.Days <= 10)
                    {

                    }
                }
                reader.Close();
                cmdCSCA.Dispose();
                connCSCA.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
            
            
            // string[] mycer = Directory.GetFiles(filepath, "*.crt", SearchOption.AllDirectories);
            //     cert.Import(mycer[0]);
            //     string strExpiry = cert.GetExpirationDateString().ToString();

            //  DateTime dt_expiry = new DateTime();
           // DateTime dt_expiry = cmd.ExecuteNonQuery();
               



               // dt_expiry = Convert.ToDateTime(strExpiry);

               // TimeSpan difference = dt_expiry - dt_now;
                //double days = difference.TotalDays;

                //if (days <= 10)
                //{
                  //  MessageBox.Show("You still have 10 days for your certificate to expire please renew!");

                    

//                }
  //              else
    //            {
      //              MessageBox.Show("Your certificate is valid!");
        //        }
            //}

            

            

            




        
    }
}
