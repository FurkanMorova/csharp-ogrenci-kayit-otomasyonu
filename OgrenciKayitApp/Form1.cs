using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OgrenciKayitApp
{
    
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        void Listele()
        {
            string connectionString = "Server=localhost;Database=OgrenciKayitDB;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Ogrenciler", conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=OgrenciKayitDB;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            string query = @"INSERT INTO Ogrenciler 
    (Ad, Soyad, TC, Telefon, Okul, Adres, Puan, DogumTarihi, ResimYolu) 
    VALUES (@Ad, @Soyad, @TC, @Telefon, @Okul, @Adres, @Puan, @DogumTarihi, @ResimYolu)";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@Soyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@TC", textBox3.Text);
            cmd.Parameters.AddWithValue("@Telefon", textBox6.Text);
            cmd.Parameters.AddWithValue("@Okul", textBox4.Text);
            cmd.Parameters.AddWithValue("@Adres", textBox5.Text);
            cmd.Parameters.AddWithValue("@Puan", double.Parse(textBox7.Text));
            cmd.Parameters.Add("@DogumTarihi", SqlDbType.Date).Value = dtpDogumTarihi.Value.Date;
            cmd.Parameters.AddWithValue("@ResimYolu", pictureBox1.ImageLocation);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Resim Seç";
            openFileDialog1.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Seçilen resmi PictureBox'ta göster
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells["Ad"].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells["Soyad"].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells["TC"].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells["Telefon"].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells["Okul"].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells["Adres"].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells["Puan"].Value.ToString();
                dtpDogumTarihi.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["DogumTarihi"].Value);
                pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells["ResimYolu"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=OgrenciKayitDB;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                SqlCommand cmd = new SqlCommand("DELETE FROM Ogrenciler WHERE ID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Listele();
            }
        }
    }
}
