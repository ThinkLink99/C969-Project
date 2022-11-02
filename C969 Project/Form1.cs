namespace C969_Project
{
    public partial class Form1 : Form
    {
        bool loggedIn = false;

        public Form1()
        {
            InitializeComponent();

            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!loggedIn)
            {
                Forms.Login login = new Forms.Login();
                login.ShowDialog();
            }
        }
    }
}