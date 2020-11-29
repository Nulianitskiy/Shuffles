using System;
using System.Diagnostics; // для таймера
using System.IO;
using System.Windows.Forms;

namespace Shuffles
{
    public partial class Form_Face : Form
    {
        public Form_Face()
        {
            InitializeComponent();
        }

        Random Rand = new Random();

        private void TimePrint(TimeSpan ts)
        {
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);//Формат времени секндомера
            RTB.Text += "\n" + elapsedTime + "\n";
        }

        private void PrintTxt (int[] array)
        {
            string writePath = @"Out.txt";
            StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default);//Файл
            foreach (int number in array)
                sw.Write(number + " ");
            sw.Close();
        }

        private int[] Fuller(string TBC)
        {
            int n;
            if (TBC == "")
            {
                n = Rand.Next(0, 100000);
            }
            else
            {
                n = Convert.ToInt32(TBC);
            }

            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = i + 1;
            return arr;
        }

        private void FY_Click(object sender, EventArgs e)
        {
            int[] A = Fuller(TBCount1.Text);

            Fisher_Yates FY = new Fisher_Yates();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            FY.Shuffle(A);


            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            RTB.Text += "Фишер-Йетс, при n = " + A.Length;
            TimePrint(ts);

            PrintTxt(A);
        }

        private void Permutations_Click(object sender, EventArgs e)
        {
            int[] A = Fuller(TBCount2.Text);
            int n = Rand.Next();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < n; i++)
                Permutation.Next(A);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            RTB.Text += "Перестановки, при n = " + n;
            TimePrint(ts);

            PrintTxt(A);
        }

        private void Rand_Throw_Click(object sender, EventArgs e)
        {
            int[] A = Fuller(TBCount3.Text);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Random_Throw.Mix(A);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            RTB.Text += "Перекидывание, при n = " + A.Length;
            TimePrint(ts);

            PrintTxt(A);
        }

        private void RC_4_Click(object sender, EventArgs e)
        {
            int[] A = Fuller(TBCount4.Text);
            int[] key = new int[A.Length];
            for (int i = 0; i < A.Length; i++)
                key[i] = Rand.Next(A.Length);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            A = RC4.Mix(key, A);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            RTB.Text += "RC 4, при n = " + A.Length;
            TimePrint(ts);

            PrintTxt(A);
        }

        private void RTB_TextChanged(object sender, EventArgs e)
        {
            RTB.SelectionStart = RTB.Text.Length;
            RTB.ScrollToCaret();
        }
    }
}
