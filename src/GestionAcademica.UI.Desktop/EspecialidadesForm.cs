using GestionAcademica.Services;
using MediatR;

namespace GestionAcademica.UI.Desktop
{
    public partial class EspecialidadesForm : Form
    {
        private readonly IMediator mediator;

        private FormMode CurrentFormMode { get; set; }
        private long? CurrentId { get; set; }

        public EspecialidadesForm(IMediator mediator)
        {
            this.InitializeComponent();

            this.mediator = mediator;
        }

        private async void EspecialidadesForm_Load(object sender, EventArgs e) => await TryExecute(async () =>
        {
            await this.LoadGrid();
            this.SetFormMode(FormMode.Read);
        });

        private async void btnGuardar_Click(object sender, EventArgs e) => await TryExecute(async () =>
        {
            string nombre = this.txtNombre.Text;

            IBaseRequest request = this.CurrentId.HasValue
                ? new ModificarEspecialidadCommand(this.CurrentId.Value, nombre)
                : new CrearEspecialidadCommand(nombre);

            await this.mediator.Send(request);

            await this.LoadGrid();
            this.CleanInputFields();
            this.SetFormMode(FormMode.Read);
        });

        private async Task LoadGrid() => await TryExecute(async () =>
        {
            var request = new EspecialidadesQuery();
            IEnumerable<EspecialidadDto> especialidades = await this.mediator.Send(request);

            this.grdEspecialidades.DataSource = especialidades;
        });

        private void CleanInputFields() => this.txtNombre.Text = string.Empty;

        private static async Task TryExecute(Func<Task> actionAsync)
        {
            try
            {
                await actionAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SGA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetFormMode(FormMode mode)
        {
            this.grdEspecialidades.Enabled = mode == FormMode.Read;
            this.btnNuevo.Enabled = mode == FormMode.Read;

            this.txtNombre.Enabled = mode == FormMode.Create || mode == FormMode.Update;
            this.btnGuardar.Enabled = mode == FormMode.Create || mode == FormMode.Update;
            this.btnCancelar.Enabled = mode == FormMode.Create || mode == FormMode.Update;

            this.btnModificar.Enabled = this.btnEliminar.Enabled = mode == FormMode.Read && this.grdEspecialidades.SelectedRows.Count > 0;
        }

        private enum FormMode
        {
            Create,
            Read,
            Update,
            Delete
        }

        private void grdEspecialidades_SelectionChanged(object sender, EventArgs e)
        {
            if (this.grdEspecialidades.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = this.grdEspecialidades.SelectedRows[0];
            var id = (long) row.Cells["Id"].Value;
            var nombre = (string) row.Cells["Nombre"].Value;

            this.CurrentId = id;
            this.txtNombre.Text = nombre;

            this.btnModificar.Enabled = this.btnEliminar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.CleanInputFields();
            this.SetFormMode(FormMode.Read);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.CurrentId = null;
            this.SetFormMode(FormMode.Create);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.SetFormMode(FormMode.Update);
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("¿Desea eliminar el registro seleccionado?", "SGA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (answer == DialogResult.No)
                return;

            await TryExecute(async () =>
            {
                var request = new EliminarEspecialidadCommand(this.CurrentId!.Value);
                await this.mediator.Send(request);
                await this.LoadGrid();
            });
        }
    }
}
