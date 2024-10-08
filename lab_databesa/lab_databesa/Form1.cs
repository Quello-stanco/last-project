using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lab_databesa
{
    public partial class frmPatient : Form
    {
        WorkTable1 wrk = new WorkTable1();

        public frmPatient()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string s = wrk.RunDML("INSERT INTO patient (patients_name, age, number_phone) VALUES (N'" + txtpatientname.Text + "', " + txtpatientage.Text + ", N'" + txtCustomerPhone.Text + "')");
            if (s == "ok")
            {
                MessageBox.Show("تم الإضافة بنجاح");
                dataGridView1.DataSource = wrk.runQuery("SELECT * FROM patient");
            }
            else
            {
                MessageBox.Show(s);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // التأكد من أن جميع الحقول ممتلئة
                if (string.IsNullOrWhiteSpace(txtpatientname.Text) ||
                    string.IsNullOrWhiteSpace(txtpatientage.Text) ||
                    string.IsNullOrWhiteSpace(txtCustomerPhone.Text) ||
                    string.IsNullOrWhiteSpace(txtpatientcode.Text))
                {
                    MessageBox.Show("يرجى ملء جميع الحقول.");
                    return;
                }

                // التحقق من أن العمر ورمز المريض أرقام صحيحة
                int age;
                if (!int.TryParse(txtpatientage.Text, out age))
                {
                    MessageBox.Show("يرجى إدخال العمر بشكل صحيح.");
                    return;
                }

                int patientCode;
                if (!int.TryParse(txtpatientcode.Text, out patientCode))
                {
                    MessageBox.Show("يرجى إدخال رمز المريض بشكل صحيح.");
                    return;
                }

                // جملة التحديث بدون استخدام SqlParameter
                string query = "UPDATE patient SET patients_name = N'" + txtpatientname.Text + "', age = " + age + ", number_phone = N'" + txtCustomerPhone.Text + "' WHERE patient_code = " + patientCode;

                // تنفيذ جملة SQL باستخدام الدالة RunDML
                string result = wrk.RunDML(query);

                // التحقق من نتيجة التحديث
                if (result == "ok")
                {
                    MessageBox.Show("تم التعديل بنجاح.");
                    // تحديث DataGridView بعد التعديل
                    dataGridView1.DataSource = wrk.runQuery("SELECT * FROM patient");
                }
                else
                {
                    MessageBox.Show("حدث خطأ أثناء التعديل: " + result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث استثناء: " + ex.Message);
            }
        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            // تأكد من وجود قيمة في txtpatientcode لأنك ستستخدمها في عملية الحذف
            if (!string.IsNullOrEmpty(txtpatientcode.Text))
            {
                try
                {
                    // جملة SQL لحذف المريض بناءً على patient_code
                    string s = wrk.RunDML("DELETE FROM patient WHERE patient_code = " + txtpatientcode.Text);

                    if (s == "ok")
                    {
                        MessageBox.Show("تم الحذف بنجاح");
                        // تحديث DataGridView بعد الحذف
                        dataGridView1.DataSource = wrk.runQuery("SELECT * FROM patient");
                    }
                    else
                    {
                        MessageBox.Show("حدث خطأ أثناء الحذف: " + s);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث استثناء: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("يرجى إدخال رمز المريض لحذفه.");
            }
        }

        private void txtpatientAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
