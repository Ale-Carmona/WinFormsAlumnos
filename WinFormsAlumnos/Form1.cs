using System;
using System.Windows.Forms;
using WinFormsAlumnos.Controller;
using WinFormsAlumnos.Models;

namespace WinFormsAlumnos
{
    public partial class Form1 : Form
    {
        private readonly APIController _api = new();

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnMostrar_Click(object sender, EventArgs e)
        {
            btnMostrar.Enabled = false;
            try
            {
                var url = "https://localhost:7079/api/Alumno";
                var alumnos = await _api.GetAlumnosAsync(url);

                if (alumnos == null || alumnos.Count == 0)
                {
                    MessageBox.Show("No se obtuvieron alumnos o la lista está vacía.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgDatos.DataSource = null;
                }
                else
                {
                    var bs = new BindingSource { DataSource = alumnos };
                    dgDatos.DataSource = bs;
                    dgDatos.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error llamando a la API:\n{ex.GetType().Name}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnMostrar.Enabled = true;
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            try
            {
                // Ajusta los nombres de los controles si difieren
                if (!int.TryParse(txbMatricula.Text, out int matricula))
                {
                    MessageBox.Show("Matrícula inválida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txbEdad.Text, out int edad))
                {
                    MessageBox.Show("Edad inválida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var alumno = new AlumnoModels
                {
                    Matricula = matricula,
                    Nombre = txbNombre.Text.Trim(),
                    Apellido = txbApellido.Text.Trim(),
                    Edad = edad
                };

                var creado = await _api.PostAlumnoAsync(alumno);

                if (creado != null)
                {
                    MessageBox.Show("Alumno agregado correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Refrescar lista
                    var alumnos = await _api.GetAlumnosAsync();
                    dgDatos.DataSource = new BindingSource { DataSource = alumnos };
                    dgDatos.AutoResizeColumns();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el alumno. Revisa la API o el servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar alumno:\n{ex.GetType().Name}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAgregar.Enabled = true;
            }
        }
            
        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            btnActualizar.Enabled = false;
            try
            {
                if (dgDatos.CurrentRow == null)
                {
                    MessageBox.Show("Selecciona un alumno para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el alumno seleccionado en el DataGridView
                var alumnoSel = dgDatos.CurrentRow.DataBoundItem as AlumnoModels;
                if (alumnoSel == null)
                {
                    MessageBox.Show("No se pudo obtener la información del alumno seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar y actualizar con los datos de los TextBox
                if (!int.TryParse(txbMatricula.Text, out int matricula))
                {
                    MessageBox.Show("Matrícula inválida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!int.TryParse(txbEdad.Text, out int edad))
                {
                    MessageBox.Show("Edad inválida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                alumnoSel.Matricula = matricula;
                alumnoSel.Nombre = txbNombre.Text.Trim();
                alumnoSel.Apellido = txbApellido.Text.Trim();
                alumnoSel.Edad = edad;

                // Llamar al método PUT usando Matricula como identificador
                var actualizado = await _api.PutAlumnoAsync(alumnoSel.Matricula, alumnoSel);

                if (actualizado)
                {
                    MessageBox.Show("Alumno actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var alumnos = await _api.GetAlumnosAsync();
                    dgDatos.DataSource = new BindingSource { DataSource = alumnos };

                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el alumno. Verifica la API.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar alumno:\n{ex.GetType().Name}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnActualizar.Enabled = true;
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            btnEliminar.Enabled = false;
            try
            {
                if (dgDatos.CurrentRow == null)
                {
                    MessageBox.Show("Selecciona un alumno para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var alumnoSel = dgDatos.CurrentRow.DataBoundItem as AlumnoModels;
                if (alumnoSel == null)
                {
                    MessageBox.Show("No se pudo obtener la información del alumno seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirmar = MessageBox.Show($"¿Seguro que deseas eliminar al alumno {alumnoSel.Nombre} {alumnoSel.Apellido}?",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmar == DialogResult.Yes)
                {
                    var eliminado = await _api.DeleteAlumnoAsync(alumnoSel.Matricula);
                    if (eliminado)
                    {
                        MessageBox.Show("Alumno eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var alumnos = await _api.GetAlumnosAsync();
                        dgDatos.DataSource = new BindingSource { DataSource = alumnos };
                        dgDatos.AutoResizeColumns();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el alumno. Revisa la API.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar alumno:\n{ex.GetType().Name}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnEliminar.Enabled = true;
            }
        }
    }
    
}