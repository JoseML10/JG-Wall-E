using System;
using System.Drawing;
using System.Windows.Forms;

namespace Wall_E
{
    public partial class Form1 : Form
    {
        private PictureBox pictureBox;
        private TextBox console;
        private Button button;
        private string gSharpExpression;

        public Form1()
        {
            InitializeComponent();

            // Crear un nuevo PictureBox
            pictureBox = new PictureBox
            {
                Location = new Point(0, 0),
                BackColor = Color.Green,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            };

            // Crear una nueva consola
            console = new TextBox
            {
                Multiline = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right,
            };

            // Crear un nuevo botón
            button = new Button
            {
                Text = "Graficar",
                Anchor = AnchorStyles.Right | AnchorStyles.Bottom,
            };

            button.Click += Button_Click;

            // Agregar el PictureBox, la consola y el botón al formulario
            Controls.Add(pictureBox);
            Controls.Add(console);
            Controls.Add(button);

            // Manejar el evento Resize del formulario
            this.Resize += new EventHandler(Form1_Resize);
            Form1_Resize(this, EventArgs.Empty);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // Ajustar el tamaño de los controles cuando cambia el tamaño del formulario
            pictureBox.Size = new Size(this.ClientSize.Width, (int)(this.ClientSize.Height * 0.8));
            console.Location = new Point(0, pictureBox.Bottom);
            console.Size = new Size((int)(this.ClientSize.Width * 0.8), this.ClientSize.Height - pictureBox.Height);
            button.Location = new Point(console.Right, pictureBox.Bottom);
            button.Size = new Size(this.ClientSize.Width - console.Width, this.ClientSize.Height - pictureBox.Height);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // Guardar la expresión ingresada en la consola
            gSharpExpression = console.Text;

            // Aquí puedes agregar el código para analizar y graficar la expresión
        }
    }
}
