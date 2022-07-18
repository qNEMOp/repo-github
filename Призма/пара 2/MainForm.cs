using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;


namespace пара_2
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
           AnT.InitializeContexts();
		}
		
		void MainForm_Load(object sender, EventArgs e)
		{
			Glut.glutInit();
			Glut.glutInitDisplayMode(Glut.GLUT_RGBA | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
			Gl.glEnable(Gl.GL_DEPTH_TEST);
			Gl.glClearColor(0,0,0,1);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(-10.0,10.0,-10.0,10.0,-10.0,10.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
		}
		void coordinates()
		{
			/*Gl.glBegin(Gl.GL_LINES);

			Gl.glColor3f(0.3f,0.0f,0.0f);
			Gl.glVertex3d(-10.0,-10.0,-10.0);
			Gl.glVertex3d(10.0,-10.0,-10.0);
			
			Gl.glColor3f(0.0f,0.3f,0.0f);
			Gl.glVertex3d(-10.0, -10.0, -10.0);
			Gl.glVertex3d(-10.0,10.0,-10.0);

			Gl.glColor3f(0.0f,0.0f,0.3f);
			Gl.glVertex3d(-10.0, -10.0, -10.0);
			Gl.glVertex3d(-10.0,-10.0,10.0);
			
			Gl.glEnd();*/
			Gl.glBegin(Gl.GL_LINES);

			Gl.glColor3f(0.3f, 0.0f, 0.0f);
			Gl.glVertex3d(0.0, 0.0, 0.0);
			Gl.glVertex3d(0.5, 0.0, 0.0);

			Gl.glColor3f(0.0f, 0.3f, 0.0f);
			Gl.glVertex3d(0.0, 0.0, 0.0);
			Gl.glVertex3d(0.0, 0.5, 0.0);

			Gl.glColor3f(0.0f, 0.0f, 0.3f);
			Gl.glVertex3d(0.0, 0.0, 0.0);
			Gl.glVertex3d(0.0, 0.0, 0.5);

			Gl.glEnd();
		}

		double dx = 0, dy = 0;
		double a, b, x, y, z, r = 1.0, A11 = -3, A12 = -3, B11 = 0, B12 = 3, C11 = 3, C12 = -3, A21, A22, B21, B22, C21, C22;

        private void trackBar4_Scroll(object sender, EventArgs e)
        {

        }

        double z11, z12, z21, z22, z31, z32;

        private void button2_Click(object sender, EventArgs e)
        {
			
		}

        double alphaA, alphaB, alphaC, betaA, betaB, betaC;
		double min = 0, max = 0, angle, angle1, r1, r2, r3;
		double lyambda, center;
		double x1, x2, x3, x4, x5, x6, y1, y2, y3, y4, y5, y6, w1, w2, lambda;
		//double[,] coordHexagon = new double[6, 2];
		double[,] vertexHexagon;
		double zAxisChange;

		private void button1_Click(object sender, EventArgs e)
        {
			z11 = Convert.ToDouble(textBox1.Text);
			z12 = Convert.ToDouble(textBox2.Text);
			z21 = Convert.ToDouble(textBox3.Text);
			z22 = Convert.ToDouble(textBox4.Text);
			z31 = Convert.ToDouble(textBox5.Text);
			z32 = Convert.ToDouble(textBox6.Text);
			dx = Convert.ToDouble(textBox7.Text);
			dy = Convert.ToDouble(textBox7.Text);

			alphaA = -Math.Acos((z11 * (B11 - A11) + z12 * (B12 - A12)) / Math.Sqrt(z11 * z11 + z12 * z12) / Math.Sqrt(Math.Pow(B11 - A11, 2) + Math.Pow(B12 - A12, 2))) * 180 / Math.PI;
			betaA = Math.Acos((z11 * (C11 - A11) + z12 * (C12 - A12)) / Math.Sqrt(z11 * z11 + z12 * z12) / Math.Sqrt(Math.Pow(C11 - A11, 2) + Math.Pow(C12 - A12, 2))) * 180 / Math.PI;

			alphaB = -Math.Acos((z31 * (A11 - B11) + z32 * (A12 - B12)) / Math.Sqrt(z31 * z31 + z32 * z32) / Math.Sqrt(Math.Pow(A11 - B11, 2) + Math.Pow(A12 - B12, 2))) * 180 / Math.PI;
			betaB = Math.Acos((z31 * (C11 - B11) + z32 * (C12 - B12)) / Math.Sqrt(z31 * z31 + z32 * z32) / Math.Sqrt(Math.Pow(C11 - B11, 2) + Math.Pow(C12 - B12, 2))) * 180 / Math.PI;

			alphaC = -Math.Acos((z21 * (A11 - C11) + z22 * (A12 - C12)) / Math.Sqrt(z21 * z21 + z22 * z22) / Math.Sqrt(Math.Pow(A11 - C11, 2) + Math.Pow(A12 - C12, 2))) * 180 / Math.PI;
			betaC = Math.Acos((z21 * (B11 - C11) + z22 * (B12 - C12)) / Math.Sqrt(z21 * z21 + z22 * z22) / Math.Sqrt(Math.Pow(B11 - C11, 2) + Math.Pow(B12 - C12, 2))) * 180 / Math.PI;


			min = Math.Max(Math.Max(alphaA, alphaB), Math.Max(alphaB, alphaC));
			max = Math.Min(Math.Min(betaA, betaB), Math.Min(betaB, betaC));

			richTextBox1.Text += min.ToString() + '\n';
			richTextBox1.Text += max.ToString() + '\n';
		}
       
		void calc()
		{
			x=r*Math.Sin(Math.PI*b)*Math.Cos(2*Math.PI*a);
			y=r*Math.Sin(Math.PI*b)*Math.Sin(2*Math.PI*a);
			z=r*Math.Cos(Math.PI*b);

			if (angle < 0)
			{
				angle1 = angle * (-min);
			}
			else angle1 = angle * max;

			A21 = A11 + dx; A22 = A12 + dy; B21 = B11 + dx; B22 = B12 + dy; C21 = C11 + dx; C22 = C12 + dy;

			r1 = Norma(A21, A22);
			r2 = Norma(B21, B22);
			r3 = Norma(C21, C22);

			x1 = -3;
			x2 = 3;
			x3 = 0;
			x4 = r1 * Math.Cos(5 * Math.PI / 4 + angle1 * Math.PI / 180);
			x5 = r3 * Math.Cos(7 * Math.PI / 4 + angle1 * Math.PI / 180);
			x6 = r2 * Math.Cos(Math.PI / 2 + angle1 * Math.PI / 180);
			y1 = -3;
			y2 = -3;
			y3 = 3;
			y4 = r1 * Math.Sin(5 * Math.PI / 4 + angle1 * Math.PI / 180);
			y5 = r3 * Math.Sin(7 * Math.PI / 4 + angle1 * Math.PI / 180);
			y6 = r2 * Math.Sin(Math.PI / 2 + angle1 * Math.PI / 180);

			zAxisChange = 10 * lyambda - 5;
		}

		double Norma(double X, double Y)
        {
			return Math.Sqrt(X * X + Y * Y);
        }
		
		void TriangleBot()
        {
			Gl.glLineWidth(1);
			Gl.glColor3f(0.0f, 1.0f, 0.0f);
			Gl.glBegin(Gl.GL_LINE_LOOP);
			Gl.glVertex3d(A11, A12, -5.0);
			Gl.glVertex3d(B11, B12, -5.0);
			Gl.glVertex3d(C11, C12, -5.0);
			Gl.glEnd();

			Gl.glPointSize(5);
			Gl.glBegin(Gl.GL_POINTS);
			Gl.glVertex3d(A11, A12, -5.0);
			Gl.glVertex3d(B11, B12, -5.0);
			Gl.glVertex3d(C11, C12, -5.0);
			Gl.glEnd();
		}

		void CalcTriangleTop()
        {
			A21 = r1 * Math.Cos(5 * Math.PI / 4 + angle1 * Math.PI / 180);
			A22 = r1 * Math.Sin(5 * Math.PI / 4 + angle1 * Math.PI / 180);
			B21 = r2 * Math.Cos(Math.PI / 2 + angle1 * Math.PI / 180);
			B22 = r2 * Math.Sin(Math.PI / 2 + angle1 * Math.PI / 180);
			C21 = r3 * Math.Cos(7 * Math.PI / 4 + angle1 * Math.PI / 180);
			C22 = r3 * Math.Sin(7 * Math.PI / 4 + angle1 * Math.PI / 180);
		}

		void TriangleTop()
		{
			Gl.glLineWidth(1);
			Gl.glColor3f(0.0f, 1.0f, 0.0f);
			Gl.glBegin(Gl.GL_LINE_LOOP);
			Gl.glVertex3d(A21, A22, 5.0);
			Gl.glVertex3d(B21, B22, 5.0);
			Gl.glVertex3d(C21, C22, 5.0);
			Gl.glEnd();

			Gl.glPointSize(5);
			Gl.glBegin(Gl.GL_POINTS);
			Gl.glVertex3d(A21, A22, 5.0);
			Gl.glVertex3d(B21, B22, 5.0);
			Gl.glVertex3d(C21, C22, 5.0);
			Gl.glEnd();
		}

		void Edge()
		{
			Gl.glLineWidth(1);
			Gl.glColor3f(0.0f, 1.0f, 0.0f);
			Gl.glBegin(Gl.GL_LINES);
			Gl.glVertex3d(A11, A12, -5.0);
			Gl.glVertex3d(A21, A22, 5.0);
			Gl.glVertex3d(B11, B12, -5.0);
			Gl.glVertex3d(B21, B22, 5.0);
			Gl.glVertex3d(C11, C12, -5.0);
			Gl.glVertex3d(C21, C22, 5.0);
			Gl.glEnd();

			if(angle1>0)
            {
				Gl.glColor3f(0.0f, 1.0f, 0.0f);
				Gl.glBegin(Gl.GL_LINES);
				Gl.glVertex3d(A11, A12, -5.0);
				Gl.glVertex3d(B21, B22, 5.0);
				Gl.glVertex3d(B11, B12, -5.0);
				Gl.glVertex3d(C21, C22, 5.0);
				Gl.glVertex3d(C11, C12, -5.0);
				Gl.glVertex3d(A21, A22, 5.0);
				Gl.glEnd();
			}
			else if(angle1 < 0)
            {
				Gl.glColor3f(0.0f, 1.0f, 0.0f);
				Gl.glBegin(Gl.GL_LINES);
				Gl.glVertex3d(A11, A12, -5.0);
				Gl.glVertex3d(C21, C22, 5.0);
				Gl.glVertex3d(B11, B12, -5.0);
				Gl.glVertex3d(A21, A22, 5.0);
				Gl.glVertex3d(C11, C12, -5.0);
				Gl.glVertex3d(B21, B22, 5.0);
				Gl.glEnd();
			}
		}

		void vector()
		{
			Gl.glLineWidth(3);
			Gl.glColor3f(1.0f, 1.0f, 0.0f);
			Gl.glBegin(Gl.GL_LINES);
			Gl.glVertex3d(0.0, 0.0, zAxisChange);
			Gl.glVertex3d(15.0 * (z11), 15.0 * (z12), zAxisChange);
			Gl.glVertex3d(0.0, 0.0, zAxisChange);
			Gl.glVertex3d(15.0 * (z21), 15.0 * (z22), zAxisChange);
			Gl.glVertex3d(0.0, 0.0, zAxisChange);
			Gl.glVertex3d(15.0 * (z31), 15.0 * (z32), zAxisChange);
			Gl.glEnd();
		}

        void hexagon()
        {
			Gl.glColor3f(1.0f, 0.0f, 0.0f);
			Gl.glLineWidth(3);

			Gl.glBegin(Gl.GL_LINE_LOOP);
				Gl.glVertex3d(vertexHexagon[0, 0], vertexHexagon[0, 1], zAxisChange);
				Gl.glVertex3d(vertexHexagon[1, 0], vertexHexagon[1, 1], zAxisChange);
				Gl.glVertex3d(vertexHexagon[2, 0], vertexHexagon[2, 1], zAxisChange);
				Gl.glVertex3d(vertexHexagon[3, 0], vertexHexagon[3, 1], zAxisChange);
				Gl.glVertex3d(vertexHexagon[4, 0], vertexHexagon[4, 1], zAxisChange);
				Gl.glVertex3d(vertexHexagon[5, 0], vertexHexagon[5, 1], zAxisChange);
			Gl.glEnd();
		}

		double[] X = new double[6];
		double[] Y = new double[6];

		void CalcInternalHexagon()
        {
			double a1,a2,b1,b2,c1,c2;
			if (angle1 < 0)
			{
				a1 = B12 - A12;
				b1 = A11 - B11;
				c1 = A11 * B12 - B11 * A12;
				a2 = B22 - A22;
				b2 = A21 - B21;
				c2 = A21 * B22 - B21 * A22;
				X[0] = (c1 * b2 - c2 * b1) / (a1 * b2 - b1 * a2);
				Y[0] = (c2 * a1 - c1 * a2) / (a1 * b2 - b1 * a2);

				a1 = C12 - B12;
				b1 = B11 - C11;
				c1 = B11 * C12 - C11 * B12;
				X[1] = (c1 * b2 - c2 * b1) / (a1 * b2 - b1 * a2);
				Y[1] = (c2 * a1 - c1 * a2) / (a1 * b2 - b1 * a2);

				a2 = C22 - B22;
				b2 = B21 - C21;
				c2 = B21 * C22 - C21 * B22;
				X[2] = (c1 * b2 - c2 * b1) / (a1 * b2 - b1 * a2);
				Y[2] = (c2 * a1 - c1 * a2) / (a1 * b2 - b1 * a2);

				a1 = A12 - C12;
				b1 = C11 - A11;
				c1 = C11 * A12 - A11 * C12;
				X[3] = (c1 * b2 - c2 * b1) / (a1 * b2 - b1 * a2);
				Y[3] = (c2 * a1 - c1 * a2) / (a1 * b2 - b1 * a2);

				a2 = A22 - C22;
				b2 = C21 - A21;
				c2 = C21 * A22 - A21 * C22;
				X[4] = (c1 * b2 - c2 * b1) / (a1 * b2 - b1 * a2);
				Y[4] = (c2 * a1 - c1 * a2) / (a1 * b2 - b1 * a2);

				a1 = B12 - A12;
				b1 = A11 - B11;
				c1 = A11 * B12 - B11 * A12;
				X[5] = (c1 * b2 - c2 * b1) / (a1 * b2 - b1 * a2);
				Y[5] = (c2 * a1 - c1 * a2) / (a1 * b2 - b1 * a2);
			}
			else if (angle1>0)
            {
				a1 = B12 - A12;
				b1 = A11 - B11;
				c1 = A11 * B12 - B11 * A12;
				a2 = C22 - B22;
				b2 = B21 - C21;
				c2 = B21 * C22 - C21 * B22;
				X[0] = (c1 * b2 - c2 * b1) / (a1 * b2 - b1 * a2);
				Y[0] = (c2 * a1 - c1 * a2) / (a1 * b2 - b1 * a2);

				a1 = C12 - B12;
				b1 = B11 - C11;
				c1 = B11 * C12 - C11 * B12;
				X[1] = (c1 * b2 - c2 * b1) / (a1 * b2 - b1 * a2);
				Y[1] = (c2 * a1 - c1 * a2) / (a1 * b2 - b1 * a2);

				a2 = A22 - C22;
				b2 = C21 - A21;
				c2 = C21 * A22 - A21 * C22;
				X[2] = (c1 * b2 - c2 * b1) / (a1 * b2 - b1 * a2);
				Y[2] = (c2 * a1 - c1 * a2) / (a1 * b2 - b1 * a2);

				a1 = A12 - C12;
				b1 = C11 - A11;
				c1 = C11 * A12 - A11 * C12;
				X[3] = (c1 * b2 - c2 * b1) / (a1 * b2 - b1 * a2);
				Y[3] = (c2 * a1 - c1 * a2) / (a1 * b2 - b1 * a2);

				a2 = B22 - A22;
				b2 = A21 - B21;
				c2 = A21 * B22 - B21 * A22;
				X[4] = (c1 * b2 - c2 * b1) / (a1 * b2 - b1 * a2);
				Y[4] = (c2 * a1 - c1 * a2) / (a1 * b2 - b1 * a2);

				a1 = B12 - A12;
				b1 = A11 - B11;
				c1 = A11 * B12 - B11 * A12;
				X[5] = (c1 * b2 - c2 * b1) / (a1 * b2 - b1 * a2);
				Y[5] = (c2 * a1 - c1 * a2) / (a1 * b2 - b1 * a2);
			}
		}
		
		void DrawInternalHexagon()
        {
			Gl.glBegin(Gl.GL_LINE_LOOP);
			Gl.glColor3f(1.0f, 1.0f, 1.0f);
			for(int i = 0; i < 6; i++)
            {
				Gl.glVertex3d(X[i], Y[i], 10 * lyambda - 5);
            }
			Gl.glEnd();
        }

		void Calc_w()
        {
				if (center < 100)
				{
					lambda = center / 100.0;
					w1 = (1 - lambda) * vertexHexagon[0, 0] + (lambda) * vertexHexagon[1, 0];
					w2 = (1 - lambda) * vertexHexagon[0, 1] + (lambda) * vertexHexagon[1, 1];
				}
				else if (center >= 100 && center < 200)
				{
					lambda = (200 - center) / 100.0;
					w1 = lambda * vertexHexagon[1, 0] + (1 - lambda) * vertexHexagon[2, 0];
					w2 = lambda * vertexHexagon[1, 1] + (1 - lambda) * vertexHexagon[2, 1];
				}
				else if (center >= 200 && center < 300)
				{
					lambda = (300 - center) / 100.0;
					w1 = lambda * vertexHexagon[2, 0] + (1 - lambda) * vertexHexagon[3, 0];
					w2 = lambda * vertexHexagon[2, 1] + (1 - lambda) * vertexHexagon[3, 1];
				}
				else if (center >= 300 && center < 400)
				{
					lambda = (400 - center) / 100.0;
					w1 = lambda * vertexHexagon[3, 0] + (1 - lambda) * vertexHexagon[4, 0];
					w2 = lambda * vertexHexagon[3, 1] + (1 - lambda) * vertexHexagon[4, 1];
				}
				else if (center >= 400 && center < 500)
				{
					lambda = (500 - center) / 100.0;
					w1 = lambda * vertexHexagon[4, 0] + (1 - lambda) * vertexHexagon[5, 0];
					w2 = lambda * vertexHexagon[4, 1] + (1 - lambda) * vertexHexagon[5, 1];
				}
				else if (center >= 500 && center <= 600)
				{
					lambda = (600 - center) / 100.0;
					w1 = lambda * vertexHexagon[5, 0] + (1 - lambda) * vertexHexagon[1, 0];
					w2 = lambda * vertexHexagon[5, 1] + (1 - lambda) * vertexHexagon[1, 1];
				}
		}

		void VertexHexagon()
        {
			vertexHexagon = new double[6,2];

			if (angle1 < 0)
			{
				vertexHexagon[0, 0] = x1 + lyambda * (x4 - x1);
				vertexHexagon[0, 1] = y1 + lyambda * (y4 - y1);
				vertexHexagon[1, 0] = x1 + lyambda * (x5 - x1);
				vertexHexagon[1, 1] = y1 + lyambda * (y5 - y1);
				vertexHexagon[2, 0] = x2 + lyambda * (x5 - x2);
				vertexHexagon[2, 1] = y2 + lyambda * (y5 - y2);
				vertexHexagon[3, 0] = x2 + lyambda * (x6 - x2);
				vertexHexagon[3, 1] = y2 + lyambda * (y6 - y2);
				vertexHexagon[4, 0] = x3 + lyambda * (x6 - x3);
				vertexHexagon[4, 1] = y3 + lyambda * (y6 - y3);
				vertexHexagon[5, 0] = x3 + lyambda * (x4 - x3);
				vertexHexagon[5, 1] = y3 + lyambda * (y4 - y3);
			}
			else
			{
				vertexHexagon[0, 0] = x1 + lyambda * (x6 - x1);
				vertexHexagon[0, 1] = y1 + lyambda * (y6 - y1);
				vertexHexagon[1, 0] = x1 + lyambda * (x4 - x1);
				vertexHexagon[1, 1] = y1 + lyambda * (y4 - y1);
				vertexHexagon[2, 0] = x2 + lyambda * (x4 - x2);
				vertexHexagon[2, 1] = y2 + lyambda * (y4 - y2);
				vertexHexagon[3, 0] = x2 + lyambda * (x5 - x2);
				vertexHexagon[3, 1] = y2 + lyambda * (y5 - y2);
				vertexHexagon[4, 0] = x3 + lyambda * (x5 - x3);
				vertexHexagon[4, 1] = y3 + lyambda * (y5 - y3);
				vertexHexagon[5, 0] = x3 + lyambda * (x6 - x3);
				vertexHexagon[5, 1] = y3 + lyambda * (y6 - y3);
			}
		}

		void DrawVertex()
        {
			for (int i = 0; i < 6; i++)
			{
				float k = i % 2;
				Gl.glColor3f(0.0f, k, 1.0f);
				Gl.glBegin(Gl.GL_POINTS);
				Gl.glVertex3d(vertexHexagon[i, 0], vertexHexagon[i, 1], zAxisChange);
				Gl.glEnd();
			}
		}

		double[,] intersectionPoints = new double[4,2];

		void CalcPointsC()
        {
			double[] beta = new double[4];

			for(int i = 0; i < 3; i++)
            {
				intersectionPoints[i, 0] = ((vertexHexagon[4, 1] - vertexHexagon[4, 0] - vertexHexagon[i, 1]) * (vertexHexagon[i+1, 0] - vertexHexagon[i, 0]) + vertexHexagon[i, 0] * (vertexHexagon[i+1, 1] - vertexHexagon[i, 1])) / (vertexHexagon[i+1, 1] - vertexHexagon[i, 1] - vertexHexagon[i+1, 0] + vertexHexagon[i, 0]);
				intersectionPoints[i, 1] = intersectionPoints[i, 0] - vertexHexagon[4, 0] + vertexHexagon[4, 1];
				beta[i] = (intersectionPoints[i, 0] - vertexHexagon[i, 0]) / (vertexHexagon[i+1, 0] - vertexHexagon[i, 0]);
				if (beta[i] >= 0 && beta[i] <= 1)
				{
					Gl.glColor3f(1.0f, 0.0f, 1.0f);
					Gl.glBegin(Gl.GL_POINTS);
					Gl.glVertex3d(intersectionPoints[i, 0], intersectionPoints[i, 1], zAxisChange);
					Gl.glEnd();
				}
			}
			/*intersectionPoints[0,0] = ((vertexHexagon[4, 1] - vertexHexagon[4, 0] - vertexHexagon[1, 1]) * (vertexHexagon[2, 0] - vertexHexagon[1, 0]) + vertexHexagon[1, 0] * (vertexHexagon[2, 1] - vertexHexagon[1, 1])) / (vertexHexagon[2, 1] - vertexHexagon[1, 1] - vertexHexagon[2, 0] + vertexHexagon[1, 0]);
			intersectionPoints[0,1] = intersectionPoints[0,0] - vertexHexagon[4, 0] + vertexHexagon[4, 1];
			beta[0] = (intersectionPoints[0, 0] - vertexHexagon[1, 0]) / (vertexHexagon[2, 0] - vertexHexagon[1, 0]);
			//beta = (Y - vertexHexagon[1, 1]) / (vertexHexagon[2, 1] - vertexHexagon[1, 1]);
			if (beta[0] >= 0 && beta[0] <= 1)
			{
				Gl.glColor3f(1.0f, 0.0f, 1.0f);
				Gl.glBegin(Gl.GL_POINTS);
				Gl.glVertex3d(intersectionPoints[0, 0], intersectionPoints[0, 1], zAxisChange);
				Gl.glEnd();
			}

			intersectionPoints[1, 0] = ((vertexHexagon[4, 1] - vertexHexagon[4, 0] - vertexHexagon[2, 1]) * (vertexHexagon[3, 0] - vertexHexagon[2, 0]) + vertexHexagon[2, 0] * (vertexHexagon[3, 1] - vertexHexagon[2, 1])) / (vertexHexagon[3, 1] - vertexHexagon[2, 1] - vertexHexagon[3, 0] + vertexHexagon[2, 0]);
			intersectionPoints[1, 1] = intersectionPoints[1, 0] - vertexHexagon[4, 0] + vertexHexagon[4, 1];
			beta[1] = (intersectionPoints[1, 0] - vertexHexagon[2, 0]) / (vertexHexagon[3, 0] - vertexHexagon[2, 0]);
			if (beta[1] >= 0 && beta[1] <= 1)
			{
				Gl.glColor3f(1.0f, 0.0f, 1.0f);
				Gl.glBegin(Gl.GL_POINTS);
				Gl.glVertex3d(intersectionPoints[1, 0], intersectionPoints[1, 1], zAxisChange);
				Gl.glEnd();
			}

			intersectionPoints[2, 0] = ((vertexHexagon[4, 1] - vertexHexagon[4, 0] - vertexHexagon[0, 1]) * (vertexHexagon[1, 0] - vertexHexagon[0, 0]) + vertexHexagon[0, 0] * (vertexHexagon[1, 1] - vertexHexagon[0, 1])) / (vertexHexagon[1, 1] - vertexHexagon[0, 1] - vertexHexagon[1, 0] + vertexHexagon[0, 0]);
			intersectionPoints[2, 1] = intersectionPoints[2, 0] - vertexHexagon[4, 0] + vertexHexagon[4, 1];
			beta[2] = (intersectionPoints[2, 0] - vertexHexagon[0, 0]) / (vertexHexagon[1, 0] - vertexHexagon[0, 0]);
			if (beta[2] >= 0 && beta[2] <= 1)
			{
				Gl.glColor3f(1.0f, 0.0f, 1.0f);
				Gl.glBegin(Gl.GL_POINTS);
				Gl.glVertex3d(intersectionPoints[2, 0], intersectionPoints[2, 1], zAxisChange);
				Gl.glEnd();
			}*/
		}

		void delta()
        {
			double alpha, beta;

			/*alpha = (y3 + lyambda * (y6 - y3) - x3 + lyambda * (x6 - x3) + x2 + lyambda * (x4 - x2) - y2 + lyambda * (y4 - y2)) / (y1 + lyambda * (y4 - y1) - x1 + lyambda * (x4 - x1)  + x2 + lyambda * (x4 - x2) - y2 + lyambda * (y4 - y2));
			beta = (x3 + lyambda * (x6 - x3) - x2 + lyambda * (x4 - x2) - alpha * (x1 + lyambda * (x4 - x1) - x2 + lyambda * (x4 - x2))) / Norma(z11, z12);

			Gl.glColor3f(0.0f, 0.0f, 1.0f);
			Gl.glBegin(Gl.GL_LINES);
			Gl.glVertex3d(alpha* (x1 + lyambda * (x4 - x1))+(1-alpha)*(x2 + lyambda * (x4 - x2)), alpha*(y1 + lyambda * (y4 - y1))+(1-alpha)*(y2 + lyambda * (y4 - y2)), 10 * lyambda - 5);
			Gl.glVertex3d(alpha * (x1 + lyambda * (x4 - x1)) + (1 - alpha) * (x2 + lyambda * (x4 - x2))+beta*z11, alpha * (y1 + lyambda * (y4 - y1)) + (1 - alpha) * (y2 + lyambda * (y4 - y2))+beta*z12, 10 * lyambda - 5);
			Gl.glEnd();*/

			alpha = (y5 - y4 + z21 / z11 * x5 - z21 / z11 * x4) / (y1 - y4 - z21 / z11 * x1 + z21 / z11 * x4);
			beta = (x5 - alpha * x1 - x4 + alpha * x4) / z11;

			Gl.glColor3f(0.0f, 0.0f, 1.0f);
			Gl.glBegin(Gl.GL_LINES);
			Gl.glVertex3d(alpha * x1 + (1 - alpha) * x4, alpha * y1 + (1 - alpha) * y4, 10 * lyambda - 5);
			Gl.glVertex3d(x5,y5, 10 * lyambda - 5);
			Gl.glEnd();
		}

		void AnTLoad(object sender, EventArgs e)
		{
			
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			a=Convert.ToDouble(trackBar1.Value)/100;
			b=Convert.ToDouble(trackBar2.Value)/100;
			angle = Convert.ToDouble(trackBar3.Value) / 100;
			lyambda = Convert.ToDouble(trackBar4.Value) / 100;
			center = Convert.ToDouble(trackBar5.Value);

			

			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
			calc();
			CalcTriangleTop();
			CalcInternalHexagon();
			VertexHexagon();
			Calc_w();

			Gl.glPushMatrix();
			Glu.gluLookAt(x,y,z,0,0,0,0,0,1);
			coordinates();
			TriangleBot();
			TriangleTop();
			Edge();
			DrawVertex();
			hexagon();
			CalcPointsC();
			if (checkBox1.Checked)
			{
				DrawInternalHexagon();
			}
			Gl.glTranslated(w1, w2, 0);
			vector();
			//delta();
			Gl.glPopMatrix();

			AnT.Invalidate();
		}
	}
}





//void hexagon()
//{
//	Gl.glColor3f(1.0f, 0.0f, 0.0f);
//	Gl.glLineWidth(3);
//	if (angle1 < 0)
//	{
//		//Gl.glBegin(Gl.GL_POLYGON);
//		Gl.glBegin(Gl.GL_LINES);

//		Gl.glVertex3d(x1 + lyambda * (x4 - x1), y1 + lyambda * (y4 - y1), 10 * lyambda - 5);
//		Gl.glVertex3d(x1 + lyambda * (x5 - x1), y1 + lyambda * (y5 - y1), 10 * lyambda - 5);

//		Gl.glVertex3d(x1 + lyambda * (x5 - x1), y1 + lyambda * (y5 - y1), 10 * lyambda - 5);
//		Gl.glVertex3d(x2 + lyambda * (x5 - x2), y2 + lyambda * (y5 - y2), 10 * lyambda - 5);

//		Gl.glVertex3d(x2 + lyambda * (x5 - x2), y2 + lyambda * (y5 - y2), 10 * lyambda - 5);
//		Gl.glVertex3d(x2 + lyambda * (x6 - x2), y2 + lyambda * (y6 - y2), 10 * lyambda - 5);

//		Gl.glVertex3d(x2 + lyambda * (x6 - x2), y2 + lyambda * (y6 - y2), 10 * lyambda - 5);
//		Gl.glVertex3d(x3 + lyambda * (x6 - x3), y3 + lyambda * (y6 - y3), 10 * lyambda - 5);

//		Gl.glVertex3d(x3 + lyambda * (x6 - x3), y3 + lyambda * (y6 - y3), 10 * lyambda - 5);
//		Gl.glVertex3d(x3 + lyambda * (x4 - x3), y3 + lyambda * (y4 - y3), 10 * lyambda - 5);

//		Gl.glVertex3d(x3 + lyambda * (x4 - x3), y3 + lyambda * (y4 - y3), 10 * lyambda - 5);
//		Gl.glVertex3d(x1 + lyambda * (x4 - x1), y1 + lyambda * (y4 - y1), 10 * lyambda - 5);

//		Gl.glEnd();
//	}
//	else
//	{
//		Gl.glBegin(Gl.GL_LINES);

//              Gl.glVertex3d(x1 + lyambda * (x6 - x1), y1 + lyambda * (y6 - y1), 10 * lyambda - 5);
//              Gl.glVertex3d(x1 + lyambda * (x4 - x1), y1 + lyambda * (y4 - y1), 10 * lyambda - 5);

//              Gl.glVertex3d(x1 + lyambda * (x4 - x1), y1 + lyambda * (y4 - y1), 10 * lyambda - 5);
//              Gl.glVertex3d(x2 + lyambda * (x4 - x2), y2 + lyambda * (y4 - y2), 10 * lyambda - 5);

//              Gl.glVertex3d(x2 + lyambda * (x4 - x2), y2 + lyambda * (y4 - y2), 10 * lyambda - 5);
//              Gl.glVertex3d(x2 + lyambda * (x5 - x2), y2 + lyambda * (y5 - y2), 10 * lyambda - 5);

//              Gl.glVertex3d(x2 + lyambda * (x5 - x2), y2 + lyambda * (y5 - y2), 10 * lyambda - 5);
//              Gl.glVertex3d(x3 + lyambda * (x5 - x3), y3 + lyambda * (y5 - y3), 10 * lyambda - 5);

//              Gl.glVertex3d(x3 + lyambda * (x5 - x3), y3 + lyambda * (y5 - y3), 10 * lyambda - 5);
//              Gl.glVertex3d(x3 + lyambda * (x6 - x3), y3 + lyambda * (y6 - y3), 10 * lyambda - 5);

//              Gl.glVertex3d(x3 + lyambda * (x6 - x3), y3 + lyambda * (y6 - y3), 10 * lyambda - 5);
//              Gl.glVertex3d(x1 + lyambda * (x6 - x1), y1 + lyambda * (y6 - y1), 10 * lyambda - 5);

//              Gl.glEnd();

//	}
//		}
/*else
			{
				if (center < 100)
				{
					lambda = center / 100.0;
					w1 = (1 - lambda) * (x1 + lyambda * (x4 - x1)) + (lambda) * (x1 + lyambda * (x5 - x1));
					w2 = (1 - lambda) * (y1 + lyambda * (y4 - y1)) + (lambda) * (y1 + lyambda * (y5 - y1));
				}
				else if (center >= 100 && center < 200)
				{
					lambda = (200 - center) / 100.0;
					w1 = lambda * (x1 + lyambda * (x5 - x1)) + (1 - lambda) * (x2 + lyambda * (x5 - x2));
					w2 = lambda * (y1 + lyambda * (y5 - y1)) + (1 - lambda) * (y2 + lyambda * (y5 - y2));
				}
				else if (center >= 200 && center < 300)
				{
					lambda = (300 - center) / 100.0;
					w1 = lambda * (x2 + lyambda * (x5 - x2)) + (1 - lambda) * (x2 + lyambda * (x6 - x2));
					w2 = lambda * (y2 + lyambda * (y5 - y2)) + (1 - lambda) * (y2 + lyambda * (y6 - y2));
				}
				else if (center >= 300 && center < 400)
				{
					lambda = (400 - center) / 100.0;
					w1 = lambda * (x2 + lyambda * (x6 - x2)) + (1 - lambda) * (x3 + lyambda * (x6 - x3));
					w2 = lambda * (y2 + lyambda * (y6 - y2)) + (1 - lambda) * (y3 + lyambda * (y6 - y3));
				}
				else if (center >= 400 && center < 500)
				{
					lambda = (500 - center) / 100.0;
					w1 = lambda * (x3 + lyambda * (x6 - x3)) + (1 - lambda) * (x3 + lyambda * (x4 - x3));
					w2 = lambda * (y3 + lyambda * (y6 - y3)) + (1 - lambda) * (y3 + lyambda * (y4 - y3));
				}
				else if (center >= 500 && center <= 600)
				{
					lambda = (600 - center) / 100.0;
					w1 = lambda * (x3 + lyambda * (x4 - x3)) + (1 - lambda) * (x1 + lyambda * (x4 - x1));
					w2 = lambda * (y3 + lyambda * (y4 - y3)) + (1 - lambda) * (y1 + lyambda * (y4 - y1));
				}
			}*/