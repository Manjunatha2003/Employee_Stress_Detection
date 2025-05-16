using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Collections;
using System.Threading;
using System.Configuration;

namespace finalyearProject
{
    public partial class _RFAlgorithm : System.Web.UI.Page
    {
        public static OleDbConnection oledbConn;
        DataTable dt = new DataTable();
        DataTable dtDistinct = new DataTable();
        static ArrayList _arrayPatientsCnt = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                TrainingDS();
                TestingDS();
            }
            catch
            {

            }
        }

        private void TestingDS()
        {
            string FileName = "TestingDataset.xls";

            string Extension = ".xls";

            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

            string _Location = "TestingDataset";

            string FilePath = Server.MapPath(FolderPath + FileName);

            ImportTestingDS(FilePath, Extension, _Location);
        }

        private string[] loadparameters()
        {
            string[] parameters = { "P1", "P2", "P3", "P4", "P5", "P6", "P7" };

            return parameters;
        }
        //function which contains 
        private string __RandomForest(string[] values)
        {
            ArrayList _Distance = new ArrayList();
            ArrayList _RecordId = new ArrayList();

            ArrayList s = new ArrayList();
            output.Clear();

            //try
            //{
            s = GetSubject();

            int m = 30; //k value

            //finding the distance between the objects
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double _val = 0.0;

                for (int j = 0; j < values.Length; j++)
                {
                    string _valluee = dt.Rows[i][j].ToString();

                    if (_valluee.Equals("?") || values[j].ToString().Equals("?") ||
                        _valluee.Equals("") || values[j].ToString().Equals(""))
                    {

                    }
                    else
                    {
                        _val += Math.Pow(double.Parse(dt.Rows[i][j].ToString()) - double.Parse(values[j].ToString()), 2);
                    }
                }

                _val = Math.Sqrt(_val);

                _Distance.Add(Math.Round(_val, 1));
                _RecordId.Add(i);
            }

            ArrayList temp = new ArrayList();
            ArrayList arrayRecords = new ArrayList();

            ArrayList arrayExists = new ArrayList();
            int d = 0;

            for (int x = 0; x < _Distance.Count; x++)
            {
                temp.Add(_Distance[x]);
            }

            temp.Sort();

            for (int y = 0; y < m; y++)
            {
                d = 0;

                for (int z = 0; z < _Distance.Count; z++)
                {
                    if (_Distance[z].Equals(temp[y]))
                    {
                        if (d == 0 && !arrayExists.Contains(_RecordId[z]))
                        {
                            arrayRecords.Add(_RecordId[z]);

                            arrayExists.Add(_RecordId[z]);

                            ++d;
                        }
                    }
                }
            }

            string _output = null;

            if (arrayRecords.Count > 0)
            {
                int cnt;

                ArrayList arrayCnt = new ArrayList();
                ArrayList arrayOutcome = new ArrayList();

                for (int i = 0; i < s.Count; i++)
                {
                    cnt = 0;

                    for (int j = 0; j < arrayRecords.Count; j++)
                    {
                        if (dt.Rows[int.Parse(arrayRecords[j].ToString())]["Result"].ToString().Equals(s[i]))
                        {
                            ++cnt;
                        }
                    }

                    arrayCnt.Add(cnt);
                    arrayOutcome.Add(s[i]);
                }

                ArrayList temp1 = new ArrayList();

                for (int x = 0; x < arrayCnt.Count; x++)
                {
                    temp1.Add(arrayCnt[x]);
                }

                temp1.Sort();
                temp1.Reverse();



                for (int y = 0; y < arrayCnt.Count; y++)
                {
                    if (arrayCnt[y].Equals(temp1[0]))
                    {
                        _output = s[y].ToString();

                        //if (_output.Equals("0"))
                        //{
                        //    _output = "No";
                        //}
                        //else
                        //{
                        //    _output = "Yes";
                        //}

                        return _output;

                    }
                }
            }

            return _output;
        }

        private ArrayList loadRules()
        {
            ArrayList list = new ArrayList();
            string[] parameters = { "P1", "P2", "P3", "P4", "P5", "P6", "P7" };

            return list;
        }

        private void ImportTestingDS(string FilePath, string Extension, string _Location)
        {
            string conStr = "";

            switch (Extension)
            {

                case ".xls": //Excel 97-03

                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                             .ConnectionString;

                    break;

                case ".xlsx": //Excel 07

                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]

                              .ConnectionString;

                    break;

            }

            conStr = String.Format(conStr, FilePath, _Location);

            OleDbConnection connExcel = new OleDbConnection(conStr);

            OleDbCommand cmdExcel = new OleDbCommand();

            OleDbDataAdapter oda = new OleDbDataAdapter();

            DataTable dt = new DataTable();

            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet

            connExcel.Open();

            DataTable dtExcelSchema;

            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

            connExcel.Close();



            //Read Data from First Sheet

            connExcel.Open();

            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

            oda.SelectCommand = cmdExcel;

            oda.Fill(dt);

            //BLL obj = new BLL();

            if (dt.Rows.Count > 0)
            {

                //Bind Data to GridView

                GridView1.Caption = Path.GetFileName(FilePath);

                GridView1.DataSource = dt;

                GridView1.DataBind();

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('No Testing Dataset Found!!!')</script>");
            }



            connExcel.Close();





        }

        private void TrainingDS()
        {
            string FileName = "TrainingDataset.xls";

            string Extension = ".xls";

            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

            string _Location = "TrainingDataset";

            string FilePath = Server.MapPath(FolderPath + FileName);

            ImportTrainingDS(FilePath, Extension, _Location);
        }

        private void ImportTrainingDS(string FilePath, string Extension, string _Location)
        {
            string conStr = "";

            switch (Extension)
            {
                case ".xls": //Excel 97-03

                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                             .ConnectionString;

                    break;

                case ".xlsx": //Excel 07

                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]

                              .ConnectionString;

                    break;

            }

            conStr = String.Format(conStr, FilePath, _Location);

            OleDbConnection connExcel = new OleDbConnection(conStr);

            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbCommand cmdDistinct = new OleDbCommand();
            OleDbCommand cmdPatientsCnt = new OleDbCommand();

            OleDbDataAdapter oda = new OleDbDataAdapter();
            OleDbDataAdapter odaDistinct = new OleDbDataAdapter();

            cmdExcel.Connection = connExcel;
            cmdDistinct.Connection = connExcel;
            cmdPatientsCnt.Connection = connExcel;
            //Get the name of First Sheet

            connExcel.Open();

            DataTable dtExcelSchema;

            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

            connExcel.Close();

            //Read Data from First Sheet

            connExcel.Open();

            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            cmdDistinct.CommandText = "SELECT DISTINCT(Result) From [" + SheetName + "]";

            oda.SelectCommand = cmdExcel;
            odaDistinct.SelectCommand = cmdDistinct;

            oda.Fill(dt);
            odaDistinct.Fill(dtDistinct);

            //BLL obj = new BLL();

            if (dt.Rows.Count > 0)
            {
                if (dtDistinct.Rows.Count > 0)
                {
                    //for (int i = 0; i < dtDistinct.Rows.Count; i++)
                    //{
                    //    cmdPatientsCnt.CommandText = "SELECT COUNT(*) From [" + SheetName + "] where result=" + dtDistinct.Rows[i]["result"].ToString() + "";
                    //    _arrayPatientsCnt.Add(cmdPatientsCnt.ExecuteScalar());
                    //}
                }

                connExcel.Close();

            }
            else
            {
                btnPrediction.Visible = false;
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('No Training Dataset!!!')</script>");
            }
        }

        protected void btnPrediction_Click(object sender, EventArgs e)
        {
            try
            {
                string FileName = "TestingDataset.xls";

                string Extension = ".xls";

                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                string _Location = "TestingDataset";

                string FilePath = Server.MapPath(FolderPath + FileName);

                string conStr = "";

                switch (Extension)
                {

                    case ".xls": //Excel 97-03

                        conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                                 .ConnectionString;

                        break;

                    case ".xlsx": //Excel 07

                        conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]

                                  .ConnectionString;

                        break;

                }

                conStr = String.Format(conStr, FilePath, _Location);

                OleDbConnection connExcel = new OleDbConnection(conStr);

                OleDbCommand cmdExcel = new OleDbCommand();

                OleDbDataAdapter oda = new OleDbDataAdapter();

                DataTable tabData = new DataTable();

                cmdExcel.Connection = connExcel;

                //Get the name of First Sheet

                connExcel.Open();

                DataTable dtExcelSchema;

                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

                connExcel.Close();



                //Read Data from First Sheet

                connExcel.Open();

                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

                oda.SelectCommand = cmdExcel;

                oda.Fill(tabData);

                //BLL obj = new BLL();

                int slNo = 1;

                if (tabData.Rows.Count > 0)
                {
                    Session["Output"] = null;
                    string _Predictedoutput = null;
                    string _timeNB = null;

                    tablePrediction.Rows.Clear();

                    tablePrediction.BorderStyle = BorderStyle.Double;
                    tablePrediction.GridLines = GridLines.Both;
                    tablePrediction.BorderColor = System.Drawing.Color.Black;

                    TableRow mainrow = new TableRow();
                    mainrow.Height = 30;
                    mainrow.ForeColor = System.Drawing.Color.Black;
                    mainrow.BackColor = System.Drawing.Color.DarkOrange;

                    TableCell cell0 = new TableCell();
                    cell0.Width = 100;
                    cell0.Text = "<b>SlNo</b>";
                    mainrow.Controls.Add(cell0);

                    //TableCell cellRegNo = new TableCell();
                    //cellRegNo.Width = 100;
                    //cellRegNo.Text = "<b>RegNo</b>";
                    //mainrow.Controls.Add(cellRegNo);

                    //TableCell cellI = new TableCell();
                    //cellI.Width = 100;
                    //cellI.Text = "<b>Income</b>";
                    //mainrow.Controls.Add(cellI);

                    //TableCell cell1 = new TableCell();
                    //cell1.Width = 100;
                    //cell1.Text = "<b>Regular</b>";
                    //mainrow.Controls.Add(cell1);

                    //TableCell cell2 = new TableCell();
                    //cell2.Text = "<b>Interaction</b>";
                    //mainrow.Controls.Add(cell2);

                    //TableCell cellTM = new TableCell();
                    //cellTM.Text = "<b>TimeManagement</b>";
                    //mainrow.Controls.Add(cellTM);

                    //TableCell cellGC = new TableCell();
                    //cellGC.Text = "<b>GraspingCapability</b>";
                    //mainrow.Controls.Add(cellGC);

                    //TableCell cellEX = new TableCell();
                    //cellEX.Text = "<b>ExActivities</b>";
                    //mainrow.Controls.Add(cellEX);

                    //TableCell cell3 = new TableCell();
                    //cell3.Text = "<b>Aggregate</b>";
                    //mainrow.Controls.Add(cell3);

                    //TableCell cell26 = new TableCell();
                    //cell26.Text = "<b>IHS</b>";
                    //mainrow.Controls.Add(cell26);

                    TableCell cell25 = new TableCell();
                    cell25.Text = "<b>Result</b>";
                    mainrow.Controls.Add(cell25);

                    tablePrediction.Controls.Add(mainrow);

                    var watch = System.Diagnostics.Stopwatch.StartNew();

                    for (int i = 0; i < tabData.Rows.Count; i++)
                    {
                        string _data = tabData.Rows[i]["Gender"].ToString() + "," +
                            tabData.Rows[i]["Age"].ToString() + "," +
                            tabData.Rows[i]["Financial_Issues"].ToString() + "," +
                            tabData.Rows[i]["Family_Issues"].ToString() + "," +
                            tabData.Rows[i]["Working_Hours"].ToString() + "," +
                            tabData.Rows[i]["Learning_Method"].ToString() + "," +
                            tabData.Rows[i]["Health_Issues"].ToString() + "," +
                            tabData.Rows[i]["Partiality_Fix"].ToString() + "," +
                            tabData.Rows[i]["Collegues_Issue"].ToString() + "," +
                            tabData.Rows[i]["Pressure"].ToString() + "," +
                            tabData.Rows[i]["Regular"].ToString() + "," +
                            tabData.Rows[i]["Interaction"].ToString();


                        string[] values = _data.Split(',');

                        string _output = __RandomForest(values);

                        TableRow row = new TableRow();

                        TableCell _cell0 = new TableCell();
                        _cell0.Text = slNo + i + ".";
                        row.Controls.Add(_cell0);

                        //TableCell _CellRG = new TableCell();
                        //_CellRG.Text = tabData.Rows[i]["RegNo"].ToString();
                        //row.Controls.Add(_CellRG);

                        //TableCell _cell1IN = new TableCell();
                        //_cell1IN.Text = tabData.Rows[i]["Income"].ToString();
                        //row.Controls.Add(_cell1IN);

                        //TableCell _cell1 = new TableCell();
                        //_cell1.Text = tabData.Rows[i]["Regular"].ToString();
                        //row.Controls.Add(_cell1);

                        //TableCell _cell2 = new TableCell();
                        //_cell2.Text = tabData.Rows[i]["CommunicationSkills"].ToString();
                        //row.Controls.Add(_cell2);

                        //TableCell _cellTMM = new TableCell();
                        //_cellTMM.Text = tabData.Rows[i]["TimeManagement"].ToString();
                        //row.Controls.Add(_cellTMM);


                        //TableCell _cell2GC = new TableCell();
                        //_cell2GC.Text = tabData.Rows[i]["GraspingAbility"].ToString();
                        //row.Controls.Add(_cell2GC);


                        //TableCell _cell2EA = new TableCell();
                        //_cell2EA.Text = tabData.Rows[i]["EXActivities"].ToString();
                        //row.Controls.Add(_cell2EA);


                        //TableCell _cell11 = new TableCell();
                        //_cell11.Text = tabData.Rows[i]["Aggregate"].ToString();
                        //row.Controls.Add(_cell11);


                        //TableCell _cell13IHS = new TableCell();
                        //_cell13IHS.Text = tabData.Rows[i]["IHS"].ToString();
                        //row.Controls.Add(_cell13IHS);

                        TableCell cellResult = new TableCell();
                        cellResult.Width = 250;
                        cellResult.Text = _output;
                        row.Controls.Add(cellResult);

                        tablePrediction.Controls.Add(row);

                        //if (_output.Equals("0"))
                        //{
                        //    ++_array0Res;
                        //}
                        //else if (_output.Equals("1"))
                        //{
                        //    ++_array1Res;
                        //}         

                        _Predictedoutput += _output + ",";
                    }

                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    _timeNB = elapsedMs.ToString();

                    Session["RFOutput"] = _timeNB + "," + _Predictedoutput.Substring(0, _Predictedoutput.Length - 1);
                }
            }
            catch
            {

            }
        }

        ArrayList output = new ArrayList();
        ArrayList mul = new ArrayList();

        //function to load subject
        public ArrayList GetSubject()
        {
            ArrayList s = new ArrayList();

            if (dtDistinct.Rows.Count > 0)
            {
                s.Clear();

                for (int i = 0; i < dtDistinct.Rows.Count; i++)
                {
                    if (dtDistinct.Rows[i]["Result"].Equals(" ") || dtDistinct.Rows[i]["Result"].Equals("") || dtDistinct.Rows[i]["Result"] == null)
                    {

                    }
                    else
                    {
                        s.Add(dtDistinct.Rows[i]["Result"].ToString());
                    }
                }
            }

            return s;
        }

        protected void btnResults_Click(object sender, EventArgs e)
        {
            btnPrediction_Click(sender, e);
            Response.Redirect("_RFResults.aspx");
        }

       

        //function to get distinct values of a specific parameter
        private ArrayList _DistinctValuesofSP(string parameter)
        {
            string FileName = "TrainingDataset.xls";

            string Extension = ".xls";

            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

            string _Location = "TrainingDataset";

            string FilePath = Server.MapPath(FolderPath + FileName);

            ArrayList _AValues = new ArrayList();

            _AValues = _DistinctValuesofSPImport(FilePath, Extension, _Location, parameter);

            return _AValues;
        }

        private ArrayList _DistinctValuesofSPImport(string FilePath, string Extension, string _Location, string parameter)
        {
            string conStr = "";

            switch (Extension)
            {
                case ".xls": //Excel 97-03

                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                             .ConnectionString;

                    break;

                case ".xlsx": //Excel 07

                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]

                              .ConnectionString;

                    break;

            }

            conStr = String.Format(conStr, FilePath, _Location);

            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable tabDValues = new DataTable();
            ArrayList _arrayValues = new ArrayList();

            cmdExcel.Connection = connExcel;

            connExcel.Open();

            DataTable dtExcelSchema;

            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

            connExcel.Close();

            //Read Data from First Sheet

            connExcel.Open();

            cmdExcel.CommandText = "SELECT DISTINCT(" + parameter + ") From [" + SheetName + "]";

            oda.SelectCommand = cmdExcel;
            oda.Fill(tabDValues);

            if (tabDValues.Rows.Count > 0)
            {
                for (int i = 0; i < tabDValues.Rows.Count; i++)
                {
                    _arrayValues.Add(tabDValues.Rows[i]["" + parameter + ""]);
                }
            }

            connExcel.Close();

            return _arrayValues;
        }

        //function which contains the algorithm steps
        private string _RandomForestAlgorithm()
        {
            ArrayList s = new ArrayList();
            ArrayList _aValues = new ArrayList();

            ArrayList _rules = new ArrayList();

            string _outcomeCondition = null;

            //try
            //{
            s.Add("0");
            s.Add("1");
            s.Add("2");
            s.Add("3");

            string[] parameters = loadparameters();

            //finding gini slpit
            for (int i = 0; i < parameters.Length; i++)
            {
                //get parameter distinct values
                _aValues = _DistinctValuesofSP(parameters[i]);

                ArrayList _arrayGSplit = new ArrayList();

                //now find g1, g2 and g split
                for (int j = 0; j < _aValues.Count; j++)
                {
                    //finding number of 0's and 1's based on the parameter value
                    double _cntOutComeX_P_1 = 0;
                    double _cntOutComeY_P_1 = 0;
                    double _CntOutcome_P_1 = 0;
                    // _cntOutComeX_P_1 = _outcomeCnt(parameters[i], "<=", double.Parse(_aValues[j].ToString()), int.Parse(s[0].ToString()));
                    // _cntOutComeY_P_1 = _outcomeCnt(parameters[i], "<=", double.Parse(_aValues[j].ToString()), int.Parse(s[1].ToString()));                                        
                    // _CntOutcome_P_1 = _cntOutComeX_P_1 + _cntOutComeY_P_1;

                    for (int k = 0; k < s.Count; k++)
                    {
                        _cntOutComeX_P_1 += _outcomeCnt(parameters[i], "<=", double.Parse(_aValues[j].ToString()), int.Parse(s[k].ToString()));
                    }

                    _CntOutcome_P_1 = _cntOutComeX_P_1;

                    double _cntOutComeX_P_2 = 0;
                    double _cntOutComeY_P_2 = 0;
                    double _CntOutcome_P_2 = 0;

                    // _cntOutComeX_P_2 = _outcomeCnt(parameters[i], ">", double.Parse(_aValues[j].ToString()), int.Parse(s[0].ToString()));
                    //_cntOutComeY_P_2 = _outcomeCnt(parameters[i], ">", double.Parse(_aValues[j].ToString()), int.Parse(s[1].ToString()));
                    // _CntOutcome_P_2 = _cntOutComeX_P_2 + _cntOutComeY_P_2;

                    for (int k = 0; k < s.Count; k++)
                    {
                        _cntOutComeX_P_2 += _outcomeCnt(parameters[i], ">", double.Parse(_aValues[j].ToString()), int.Parse(s[k].ToString()));
                    }

                    _CntOutcome_P_2 = _cntOutComeX_P_2;

                    //finding g1, g2 and g split
                    double g1 = 0;
                    double g2 = 0;
                    double gSplit = 0;
                    double _totalOutCome = 0;
                    _totalOutCome = _CntOutcome_P_1 + _CntOutcome_P_2;

                    g1 = 1 - (Math.Pow((_cntOutComeX_P_1 / _CntOutcome_P_1), 2) + Math.Pow((_cntOutComeY_P_1 / _CntOutcome_P_1), 2));

                    double _cal = Math.Pow((_cntOutComeX_P_2 / _CntOutcome_P_2), 2) + Math.Pow((_cntOutComeY_P_2 / _CntOutcome_P_2), 2);

                    if (double.IsNaN(g1))
                    {
                        g1 = 1;
                    }

                    g2 = 1 - _cal;

                    if (double.IsNaN(g2))
                    {
                        g2 = 1;
                    }

                    gSplit = (_CntOutcome_P_1 / _totalOutCome) * g1 + (_CntOutcome_P_2 / _totalOutCome) * g2;

                    _arrayGSplit.Add(gSplit);
                }

                //0.40
                // 0.26
                // 0.46
                // 0.30
                // 0.48

                //so we got all gini split for the parameter, now identify least number.
                ArrayList _leastTemp = new ArrayList();

                for (int k = 0; k < _arrayGSplit.Count; k++)
                {
                    _leastTemp.Add(_arrayGSplit[k]);
                }

                _leastTemp.Sort();

                double _bestSplit = 0;

                for (int x = 0; x < _arrayGSplit.Count; x++)
                {
                    if (_arrayGSplit[x].Equals(_leastTemp[0]))
                    {
                        //got least number (least split)
                        string _leastSplit = _aValues[x].ToString();

                        _bestSplit = (double.Parse(_leastSplit) + double.Parse(_aValues[x + 1].ToString())) / 2;

                    }
                }

                //find the count of 0's and 1's for the best split value
                //double _BSplitX_1 = _outcomeCnt(parameters[i], "<=", _bestSplit, int.Parse(s[0].ToString()));
                //double _BSplitY_1 = _outcomeCnt(parameters[i], "<=", _bestSplit, int.Parse(s[1].ToString()));

                double _BSplitX_1 = 0;

                for (int k = 0; k < s.Count; k++)
                {
                    _BSplitX_1 += _outcomeCnt(parameters[i], "<=", _bestSplit, int.Parse(s[k].ToString()));
                }

                //double _BSplitX_2 = _outcomeCnt(parameters[i], ">", _bestSplit, int.Parse(s[0].ToString()));
                //double _BSplitY_2 = _outcomeCnt(parameters[i], ">", _bestSplit, int.Parse(s[1].ToString()));

                double _BSplitX_2 = 0;

                for (int k = 0; k < s.Count; k++)
                {
                    _BSplitX_2 += _outcomeCnt(parameters[i], ">", _bestSplit, int.Parse(s[k].ToString()));
                }

                //generating rules
                //if (_BSplitX_1 > _BSplitY_1)
                //{
                //    _rules.Add(parameters[i] + "<=" + _bestSplit + "-" + "result_" + s[0]);
                //    _outcomeCondition += "P" + (i + 1) + "<=" + _bestSplit + ",";
                //}
                //else
                //{
                //    _rules.Add(parameters[i] + "<=" + _bestSplit + "-" + "result_" + s[1]);
                //}

                //if (_BSplitX_2 > _BSplitY_2)
                //{
                //    _rules.Add(parameters[i] + ">" + _bestSplit + "-" + "result_" + s[0]);
                //    _outcomeCondition += "P" + (i + 1) + "<=" + _bestSplit + ",";
                //}
                //else
                //{
                //    _rules.Add(parameters[i] + ">" + _bestSplit + "-" + "result_" + s[1]);
                //}

                _rules = loadRules();

            }

            return _outcomeCondition;
        }

        //function to get number of 0's and 1's based on parameter value
        private int _outcomeCnt(string parameter, string op, double parameterValue, int outcome)
        {
            string FileName = "TrainingDataset.xls";

            string Extension = ".xls";

            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

            string _Location = "TrainingDataset";

            string FilePath = Server.MapPath(FolderPath + FileName);

            int _cnt = 0;

            _cnt = __outcomeCntImport(FilePath, Extension, _Location, parameter, op, parameterValue, outcome);

            return _cnt;
        }

        private int __outcomeCntImport(string FilePath, string Extension, string _Location, string parameter, string op, double parameterValue, int outcome)
        {
            string conStr = "";

            switch (Extension)
            {
                case ".xls": //Excel 97-03

                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                             .ConnectionString;

                    break;

                case ".xlsx": //Excel 07

                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]

                              .ConnectionString;

                    break;

            }

            conStr = String.Format(conStr, FilePath, _Location);

            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable tabDValues = new DataTable();
            ArrayList _arrayValues = new ArrayList();

            cmdExcel.Connection = connExcel;

            connExcel.Open();

            DataTable dtExcelSchema;

            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

            connExcel.Close();

            //Read Data from First Sheet

            connExcel.Open();

            cmdExcel.CommandText = "SELECT COUNT(*) From [" + SheetName + "] WHERE " + parameter + op + parameterValue + " AND Result= " + outcome + "";
            int _Cnt = int.Parse(cmdExcel.ExecuteScalar().ToString());

            connExcel.Close();

            return _Cnt;
        }
       
             
    }
}