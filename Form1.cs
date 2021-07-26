using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
//using System.Net.Http;
//using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace sssAPITester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //static HttpClient client = new HttpClient();

        private void Form1_Load(object sender, EventArgs e)
        {
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test();

            return;
            rtb.Clear();
            pagibigWS.ACC_MS_WEBSERVICE service = new pagibigWS.ACC_MS_WEBSERVICE();
            pagibigWS.RequestAuth reqAuth = new pagibigWS.RequestAuth();
            reqAuth.wsUser = "ulilangkawayan";
            reqAuth.wsPass = "ragMANOK2kx";

            pagibigWS.requestCreate request = new pagibigWS.requestCreate();
            pagibigWS.customer customer = new pagibigWS.customer();
            pagibigWS.ubpName name = new pagibigWS.ubpName();
            pagibigWS.account account = new pagibigWS.account();
            name.first = "John";
            name.middle = "";
            name.last = "Dela Cruz";
            customer.name = name;
            customer.email = "jdcruz@email.com";
            customer.fullMobileNumber = "+639990001234";
            customer.birthDate = Convert.ToDateTime("1993-08-12").Date;
            customer.title = "MR";
            customer.getGoNumber = "";
            account.schemeCode = "SB140";
            account.subheadCode = "21211";
            account.operationMode = "1";
            account.solId = "1985";
            account.currency = "PHP";
            request.customer = customer;
            request.account = account;
            
            var response = service.UBPDAO_CreateApplication(reqAuth, request);
            //Console.Write(Newtonsoft.Json.JsonConvert.DeserializeObject(Of UBP.DAO.createApplication.responseSuccess)(response));            
            rtb.AppendText(Newtonsoft.Json.JsonConvert.SerializeObject(response));
        }

        private void Test()
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            dt1.Columns.Add("f1", typeof(Int32));
            dt1.Columns.Add("f2", typeof(Int32));
            dt1.Columns.Add("f3", typeof(Int32));
            dt1.Columns.Add("f4", typeof(Int32));
            dt1.Columns.Add("f5", typeof(Int32));
            dt1.Columns.Add("f6", typeof(Int32));

            dt2.Columns.Add("f1", typeof(Int32));            

            dt3.Columns.Add("f1", typeof(Int32));
            dt3.Columns.Add("Count", typeof(Int32));
            using (StreamReader sr = new StreamReader(@"D:\WORK\digits.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line.Trim() != "")
                    {
                        DataRow rw1 = dt1.NewRow();                        
                        rw1[0] = Convert.ToInt32(line.Split('-')[0]);
                        rw1[1] = Convert.ToInt32(line.Split('-')[1]);
                        rw1[2] = Convert.ToInt32(line.Split('-')[2]);
                        rw1[3] = Convert.ToInt32(line.Split('-')[3]);
                        rw1[4] = Convert.ToInt32(line.Split('-')[4]);
                        rw1[5] = Convert.ToInt32(line.Split('-')[5]);
                        dt1.Rows.Add(rw1);                        
                    }
                }
                sr.Close();
                sr.Dispose();
            }

            DataTable _dtF1 = dt1.DefaultView.ToTable(true, "f1");
            foreach (DataRow rwF1 in _dtF1.Rows)
            {
                DataRow rwNewF1 = dt2.NewRow();
                rwNewF1[0] = rwF1[0];               
                dt2.Rows.Add(rwNewF1);
            }

            DataTable _dtF2 = dt1.DefaultView.ToTable(true, "f2");
            foreach (DataRow rwF2 in _dtF2.Rows)
            {
                DataRow rwNewF2 = dt2.NewRow();
                rwNewF2[0] = rwF2[0];                
                dt2.Rows.Add(rwNewF2);
            }

            DataTable _dtF3 = dt1.DefaultView.ToTable(true, "f3");
            foreach (DataRow rwF3 in _dtF3.Rows)
            {
                DataRow rwNewF3 = dt2.NewRow();
                rwNewF3[0] = rwF3[0];                
                dt2.Rows.Add(rwNewF3);
            }

            DataTable _dtF4 = dt1.DefaultView.ToTable(true, "f4");
            foreach (DataRow rwF4 in _dtF4.Rows)
            {
                DataRow rwNewF4 = dt2.NewRow();
                rwNewF4[0] = rwF4[0];                
                dt2.Rows.Add(rwNewF4);
            }

            DataTable _dtF5 = dt1.DefaultView.ToTable(true, "f5");
            foreach (DataRow rwF5 in _dtF5.Rows)
            {
                DataRow rwNewF5 = dt2.NewRow();
                rwNewF5[0] = rwF5[0];                
                dt2.Rows.Add(rwNewF5);
            }

            DataTable _dtF6 = dt1.DefaultView.ToTable(true, "f6");
            foreach (DataRow rwF6 in _dtF6.Rows)
            {
                DataRow rwNewF6 = dt2.NewRow();
                rwNewF6[0] = rwF6[0];                
                dt2.Rows.Add(rwNewF6);
            }

            DataTable _dtF7 = dt2.DefaultView.ToTable(true, "f1");
            foreach (DataRow rwF7 in _dtF7.Rows)
            {
                DataRow rwNewF7 = dt3.NewRow();
                rwNewF7[0] = rwF7[0];
                rwNewF7[1] = 0;
                dt3.Rows.Add(rwNewF7);
            }

            foreach (DataRow rw3 in dt3.Rows)
            {
                rw3[1] = dt1.Select("f1=" + rw3[0]).Length + dt1.Select("f2=" + rw3[0]).Length + dt1.Select("f3=" + rw3[0]).Length + dt1.Select("f4=" + rw3[0]).Length + dt1.Select("f5=" + rw3[0]).Length + dt1.Select("f6=" + rw3[0]).Length;
            }

            dt3.DefaultView.Sort = "Count";

            //DataTable dtFinal = dt2.DefaultView.ToTable(true, "f1");


            MessageBox.Show("Done!");
        }
    }
}

