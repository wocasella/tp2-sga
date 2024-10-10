using Microsoft.Extensions.DependencyInjection;

namespace GestionAcademica.UI.Desktop
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider serviceProvider;

        public MainForm(IServiceProvider serviceProvider)
        {
            this.InitializeComponent();

            this.serviceProvider = serviceProvider;
        }

        private void itemMenuEspecialidades_Click(object sender, EventArgs e) => this.OpenForm<EspecialidadesForm>();

        private void OpenForm<TForm>() where TForm : Form
        {
            if (!this.TryActivateAlreadyOpenForm<TForm>())
            {
                this.ShowNewForm<TForm>();
            }
        }

        private void ShowNewForm<TForm>() where TForm : Form
        {
            var form = this.serviceProvider.GetRequiredService<TForm>();
            form.MdiParent = this;
            form.Show();
        }

        private bool TryActivateAlreadyOpenForm<TForm>() where TForm : Form
        {
            var form = this.MdiChildren.OfType<TForm>().SingleOrDefault();
            form?.Activate();
            return form != null;
        }
    }
}