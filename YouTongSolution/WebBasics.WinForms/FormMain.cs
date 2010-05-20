using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebBasics.Utilities;

namespace WebBasics.WinForms
{
	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Int32 row = 10;
			this.textBox1.AppendText(row.ToString() + "\t\t"
							+ InsertComb(row).TotalMilliseconds.ToString() + "\t\t"
							+ InsertComb2(row).TotalMilliseconds.ToString() + "\r\n");

			row = 100;
			this.textBox1.AppendText(row.ToString() + "\t\t"
							+ InsertComb(row).TotalMilliseconds.ToString() + "\t\t"
							+ InsertComb2(row).TotalMilliseconds.ToString() + "\r\n");

			row = 500;
			this.textBox1.AppendText(row.ToString() + "\t\t"
							+ InsertComb(row).TotalMilliseconds.ToString() + "\t\t"
							+ InsertComb2(row).TotalMilliseconds.ToString() + "\r\n");

			row = 1000;
			this.textBox1.AppendText(row.ToString() + "\t\t"
							+ InsertComb(row).TotalMilliseconds.ToString() + "\t\t"
							+ InsertComb2(row).TotalMilliseconds.ToString() + "\r\n");

			row = 2000;
			this.textBox1.AppendText(row.ToString() + "\t\t"
							+ InsertComb(row).TotalMilliseconds.ToString() + "\t\t"
							+ InsertComb2(row).TotalMilliseconds.ToString() + "\r\n");

			row = 3000;
			this.textBox1.AppendText(row.ToString() + "\t\t"
							+ InsertComb(row).TotalMilliseconds.ToString() + "\t\t"
							+ InsertComb2(row).TotalMilliseconds.ToString() + "\r\n");

			row = 4000;
			this.textBox1.AppendText(row.ToString() + "\t\t"
							+ InsertComb(row).TotalMilliseconds.ToString() + "\t\t"
							+ InsertComb2(row).TotalMilliseconds.ToString() + "\r\n");

			row = 5000;
			this.textBox1.AppendText(row.ToString() + "\t\t"
							+ InsertComb(row).TotalMilliseconds.ToString() + "\t\t"
							+ InsertComb2(row).TotalMilliseconds.ToString() + "\r\n");

			row = 10000;
			this.textBox1.AppendText(row.ToString() + "\t\t"
							+ InsertComb(row).TotalMilliseconds.ToString() + "\t\t"
							+ InsertComb2(row).TotalMilliseconds.ToString() + "\r\n");
		}

		private TimeSpan InsertComb(int row)
		{
			String sql = "Insert Into CombTest(Comb,A,B,C) Values(@Comb,@A,@B,@C)";
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UT_YouTong"].ConnectionString);
			conn.Open();

			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = sql;

			SqlParameter pComb = new SqlParameter("Comb", SqlDbType.NVarChar);
			SqlParameter pA = new SqlParameter("A", SqlDbType.NVarChar);
			SqlParameter pB = new SqlParameter("B", SqlDbType.NVarChar);
			SqlParameter pC = new SqlParameter("C", SqlDbType.NVarChar);

			cmd.Parameters.Add(pComb);
			cmd.Parameters.Add(pA);
			cmd.Parameters.Add(pB);
			cmd.Parameters.Add(pC);

			Stopwatch watch = new Stopwatch();
			watch.Start();

			for (int i = 0; i < row; i++)
			{
				pComb.Value = Guid.NewGuid().ToString();
				pA.Value = pB.Value = pC.Value = pComb.Value;
				cmd.ExecuteNonQuery();
			}

			var ms = watch.Elapsed;
			watch.Stop();

			conn.Close();

			return ms;
		}

		private TimeSpan InsertComb2(int row)
		{
			String sql = "Insert Into Comb2Test(Comb,A,B,C) Values(@Comb,@A,@B,@C)";
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UT_YouTong"].ConnectionString);
			conn.Open();

			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = sql;

			SqlParameter pComb = new SqlParameter("Comb", SqlDbType.NVarChar);
			SqlParameter pA = new SqlParameter("A", SqlDbType.NVarChar);
			SqlParameter pB = new SqlParameter("B", SqlDbType.NVarChar);
			SqlParameter pC = new SqlParameter("C", SqlDbType.NVarChar);

			cmd.Parameters.Add(pComb);
			cmd.Parameters.Add(pA);
			cmd.Parameters.Add(pB);
			cmd.Parameters.Add(pC);

			Stopwatch watch = new Stopwatch();
			watch.Start();

			for (int i = 0; i < row; i++)
			{
				pComb.Value = Comb.NewComb2().ToString();
				pA.Value = pB.Value = pC.Value = pComb.Value;
				cmd.ExecuteNonQuery();
			}

			var ms = watch.Elapsed;
			watch.Stop();

			conn.Close();

			return ms;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Int32 row = Int32.Parse(this.textBox3.Text);

			for (int i = 1; i < 10; i++)
			{
				this.textBox2.AppendText(row.ToString() + "\t\t"
					+ InsertComb2(row).TotalMilliseconds.ToString() + "\t\t"
					+ InsertComb(row).TotalMilliseconds.ToString() + "\r\n");
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			for (int i = 1; i < 10; i++)
			{
				this.textBox1.AppendText(SelectCombOrderBy().TotalMilliseconds.ToString() + "\t\t"
				+ SelectComb2OrderBy().TotalMilliseconds.ToString() + "\r\n");
			}

		}

		private TimeSpan SelectCombOrderBy()
		{
			String sql = "Select * From CombTest Order by Comb";

			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UT_YouTong"].ConnectionString);
			conn.Open();

			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = sql;

			Stopwatch watch = new Stopwatch();
			watch.Start();

			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);

			var ms = watch.Elapsed;
			watch.Stop();

			conn.Close();

			return ms;
		}

		private TimeSpan SelectComb2OrderBy()
		{
			String sql = "Select * From Comb2Test Order by Comb";

			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UT_YouTong"].ConnectionString);
			conn.Open();

			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = sql;

			Stopwatch watch = new Stopwatch();
			watch.Start();

			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);

			var ms = watch.Elapsed;
			watch.Stop();

			conn.Close();

			return ms;
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			this.textBox1.Clear();
			this.textBox2.Clear();
		}
	}
}
