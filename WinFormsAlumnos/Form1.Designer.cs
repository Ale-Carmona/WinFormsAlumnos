namespace WinFormsAlumnos
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgDatos = new DataGridView();
            btnMostrar = new Button();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            lbMatricula = new Label();
            lbNombre = new Label();
            lbApellido = new Label();
            lbEdad = new Label();
            txbMatricula = new TextBox();
            txbNombre = new TextBox();
            txbApellido = new TextBox();
            txbEdad = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgDatos).BeginInit();
            SuspendLayout();
            // 
            // dgDatos
            // 
            dgDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgDatos.Location = new Point(452, 67);
            dgDatos.Name = "dgDatos";
            dgDatos.RowHeadersWidth = 82;
            dgDatos.Size = new Size(878, 300);
            dgDatos.TabIndex = 0;
            // 
            // btnMostrar
            // 
            btnMostrar.Location = new Point(546, 419);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Size = new Size(304, 46);
            btnMostrar.TabIndex = 1;
            btnMostrar.Text = "Mostrar Alumno";
            btnMostrar.UseVisualStyleBackColor = true;
            btnMostrar.Click += btnMostrar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(962, 419);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(274, 46);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar Alumno";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(546, 510);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(304, 46);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "Actualizar Alumno";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(962, 510);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(274, 46);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar Alumno";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lbMatricula
            // 
            lbMatricula.AutoSize = true;
            lbMatricula.Location = new Point(58, 78);
            lbMatricula.Name = "lbMatricula";
            lbMatricula.Size = new Size(118, 32);
            lbMatricula.TabIndex = 5;
            lbMatricula.Text = "Matricula:";
            // 
            // lbNombre
            // 
            lbNombre.AutoSize = true;
            lbNombre.Location = new Point(69, 165);
            lbNombre.Name = "lbNombre";
            lbNombre.Size = new Size(107, 32);
            lbNombre.TabIndex = 6;
            lbNombre.Text = "Nombre:";
            // 
            // lbApellido
            // 
            lbApellido.AutoSize = true;
            lbApellido.Location = new Point(69, 257);
            lbApellido.Name = "lbApellido";
            lbApellido.Size = new Size(107, 32);
            lbApellido.TabIndex = 7;
            lbApellido.Text = "Apellido:";
            // 
            // lbEdad
            // 
            lbEdad.AutoSize = true;
            lbEdad.Location = new Point(105, 355);
            lbEdad.Name = "lbEdad";
            lbEdad.Size = new Size(71, 32);
            lbEdad.TabIndex = 8;
            lbEdad.Text = "Edad:";
            // 
            // txbMatricula
            // 
            txbMatricula.Location = new Point(209, 78);
            txbMatricula.Name = "txbMatricula";
            txbMatricula.Size = new Size(200, 39);
            txbMatricula.TabIndex = 9;
            // 
            // txbNombre
            // 
            txbNombre.Location = new Point(209, 165);
            txbNombre.Name = "txbNombre";
            txbNombre.Size = new Size(200, 39);
            txbNombre.TabIndex = 10;
            // 
            // txbApellido
            // 
            txbApellido.Location = new Point(209, 257);
            txbApellido.Name = "txbApellido";
            txbApellido.Size = new Size(200, 39);
            txbApellido.TabIndex = 11;
            // 
            // txbEdad
            // 
            txbEdad.Location = new Point(209, 355);
            txbEdad.Name = "txbEdad";
            txbEdad.Size = new Size(200, 39);
            txbEdad.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1385, 617);
            Controls.Add(txbEdad);
            Controls.Add(txbApellido);
            Controls.Add(txbNombre);
            Controls.Add(txbMatricula);
            Controls.Add(lbEdad);
            Controls.Add(lbApellido);
            Controls.Add(lbNombre);
            Controls.Add(lbMatricula);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnAgregar);
            Controls.Add(btnMostrar);
            Controls.Add(dgDatos);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgDatos;
        private Button btnMostrar;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Label lbMatricula;
        private Label lbNombre;
        private Label lbApellido;
        private Label lbEdad;
        private TextBox txbMatricula;
        private TextBox txbNombre;
        private TextBox txbApellido;
        private TextBox txbEdad;
    }
}
