using System;
using System.Windows.Forms;

namespace lab_databesa
{
    public partial class frmanalysis : Form
    {
        WorkTable1 wrk = new WorkTable1();

        public frmanalysis()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // تحميل البيانات من جدول patient_analysis
            dataGridView1.DataSource = wrk.runQuery("SELECT * FROM patient_analysis");
        }

        private void button1_Click(object sender, EventArgs e) // زر الإضافة
        {
            string s = wrk.RunDML("INSERT INTO patient_analysis (analysis_code, analysis_name, description, requirements) VALUES (" +
                "'" + txtanalysiscode.Text + "', " + // كود التحليل
                "N'" + txtanalysisname.Text + "', " + // اسم التحليل
                "N'" + richtxtdiscription.Text + "', " + // الوصف
                "N'" + richtxtrequirements.Text + "')"); // المتطلبات

            if (s == "ok")
            {
                MessageBox.Show("تمت الإضافة بنجاح");
                dataGridView1.DataSource = wrk.runQuery("SELECT * FROM patient_analysis");
            }
            else
            {
                MessageBox.Show(s);
            }
        }

        private void button2_Click(object sender, EventArgs e) // زر الحذف
        {
            if (!string.IsNullOrEmpty(txtanalysiscode.Text))
            {
                string s = wrk.RunDML("DELETE FROM patient_analysis WHERE analysis_code = '" + txtanalysiscode.Text + "'");

                if (s == "ok")
                {
                    MessageBox.Show("تم الحذف بنجاح");
                    dataGridView1.DataSource = wrk.runQuery("SELECT * FROM patient_analysis");
                }
                else
                {
                    MessageBox.Show("حدث خطأ أثناء الحذف: " + s);
                }
            }
            else
            {
                MessageBox.Show("يرجى إدخال كود التحليل لحذفه.");
            }
        }

        private void button3_Click(object sender, EventArgs e) // زر التعديل
        {
            string s = wrk.RunDML("UPDATE patient_analysis SET analysis_name = N'" + txtanalysisname.Text + "', " +
                "description = N'" + richtxtdiscription.Text + "', " +
                "requirements = N'" + richtxtrequirements.Text + "' " +
                "WHERE analysis_code = '" + txtanalysiscode.Text + "'");

            if (s == "ok")
            {
                MessageBox.Show("تم التعديل بنجاح");
                dataGridView1.DataSource = wrk.runQuery("SELECT * FROM patient_analysis");
            }
            else
            {
                MessageBox.Show(s);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // تحميل البيانات المحددة في DataGridView
            if (dataGridView1.CurrentRow != null)
            {
                txtanalysiscode.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtanalysisname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                richtxtdiscription.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                richtxtrequirements.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
        }
    }
}
